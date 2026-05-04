using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace ServerAPI.Repositories.FileRepo;


public class AzureStorageFileRepository : IFileRepository
{
    private readonly BlobContainerClient _container;

    public AzureStorageFileRepository(IConfiguration config)
    {
        var connStr = config["AzureStorage:ConnectionString"];
        var containerName = config["AzureStorage:ContainerName"];
        _container = new BlobContainerClient(connStr, containerName);
        _container.CreateIfNotExists();
    }

    public string Add(IFormFile file)
    {
        var blobName = $"{Guid.NewGuid()}_{file.FileName}";
        var blobClient = _container.GetBlobClient(blobName);

        using var stream = file.OpenReadStream();
        blobClient.Upload(stream, overwrite: false);
        //await blobClient.UploadAsync(stream, overwrite: false);

        return blobName;
    }

    public List<string> GetAll()
    {
        List<string> blobNames = new();

        _container.GetBlobs().ToList().ForEach(b => blobNames.Add(b.Name));
        /*await foreach (var blobItem in _container.GetBlobsAsync())
        {
            //var blobClient = _container.GetBlobClient(blobItem.Name);
            //urls.Add(blobClient.Uri.ToString());
            blobNames.Add(blobItem.Name);
        }*/

        return blobNames;
    }
    
    public (Stream Stream, string ContentType)? GetStream(string blobName)
    {
        var blobClient = _container.GetBlobClient(blobName);

        if (!blobClient.Exists())
            return null;

        // Get properties for content type / metadata
        BlobProperties props = blobClient.GetProperties();

        var stream = blobClient.OpenRead();
        var contentType = props.ContentType ?? "application/octet-stream";

        return (stream, contentType);
    }
    

    public bool Delete(string blobName)
    {
        var blobClient = _container.GetBlobClient(blobName);

        // DeleteIfExists returns true/false
        var result = blobClient.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots);

        return result.Value; // true if deleted, false if blob didn’t exist
    }
}