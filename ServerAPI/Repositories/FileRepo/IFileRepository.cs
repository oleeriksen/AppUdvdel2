namespace ServerAPI.Repositories.FileRepo;

public interface IFileRepository
{
    // represent a repo of files. When a file is added, it is given a unique name
    // to retrieve the content of a file in the repo, you must provide its name.
    
    
    // will add [file] to the repo - return the unique name it is given
   string Add(IFormFile file);
   
   // Get all names of files in the repo
   List<string> GetAll();

   // get the content of file named [fileName] as a stream, the content-type
   (Stream Stream, string ContentType)? GetStream(
       string fileName);

   // delete the file named [fileName]. Return true if success, false otherwise.
   bool Delete(string fileName);
}