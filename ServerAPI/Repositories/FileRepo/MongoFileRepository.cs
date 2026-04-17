using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ServerAPI.Repositories.FileRepo;

public class MongoFileRepository : IFileRepository
{
    private readonly IMongoCollection<FileDocument> _collection;

    public MongoFileRepository()
    {
        // atlas database
        //var password = ""; //add
        //var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";
           
        //local mongodb
        var mongoUri = "mongodb://localhost:27017/";
            
        MongoClient client;
        try
        {
            client = new MongoClient(mongoUri);
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem connecting to your " +
                              "Atlas cluster. Check that the URI includes a valid " +
                              "username and password, and that your IP address is " +
                              $"in the Access List. Message: {e.Message}");
            throw; }

        // Provide the name of the database and collection you want to use.
        var dbName = "myDatabase";
        var collectionName = "files";

        _collection = client.GetDatabase(dbName)
            .GetCollection<FileDocument>(collectionName);
        
    }

    public string Add(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty");

        // Generér unikt navn
        var uniqueName = $"{DateTime.Now.Ticks}_{file.FileName}";

        // hele filen er i RAM
        using var ms = new MemoryStream();
        file.CopyTo(ms);

        var doc = new FileDocument
        {
            FileName = uniqueName,
            ContentType = ContentType(uniqueName),
            Content = new BsonBinaryData(ms.ToArray())
        };

        _collection.InsertOne(doc);

        return uniqueName;
    }

    private string ContentType(string fileName)
    {
        int idx = fileName.LastIndexOf('.');
        string extension = fileName.Substring(idx+1);
        switch (extension)
        {
            case "png": return "image/png";
            case "jpg": return "image/jpg";
            case "jpeg": return "image/jpeg";
            default: return "application/octet-stream";
        }
    }
    

    public List<string> GetAll()
    {
        return _collection
            .Find(_ => true)
            .Project(x => x.FileName)
            .ToList();
    }

    public (Stream Stream, string ContentType)? GetStream(string fileName)
    {
        var doc = _collection
            .Find(x => x.FileName == fileName)
            .FirstOrDefault();

        if (doc == null)
            return null;

        var stream = new MemoryStream(doc.Content.Bytes);

        return (stream, doc.ContentType);
    }

    public bool Delete(string fileName)
    {
        var result = _collection.DeleteOne(x => x.FileName == fileName);
        return result.DeletedCount > 0;
    }
    
 

    public class FileDocument
    {
        [BsonId]
        public string FileName { get; set; } = default!;

        public string ContentType { get; set; } = default!;

        public BsonBinaryData Content { get; set; } = default!;
    }
}