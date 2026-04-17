using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.FileRepo;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{

    private IFileRepository mFileRep;

    public FileController(IFileRepository fileRep)
    {
        mFileRep = fileRep;
    }

    // provide fileupload - the file is added to the repo and given
    // a unique filename with the same extension as the uploaded file. 
    [HttpPost]
    [Route("add")]
    public IActionResult Add(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var url = mFileRep.Add(file);
        return Ok(new { url });
    }
    
    
    // provide download of a specific file in the repo - it will
    // return a stream and a type of content
    [HttpGet("download/{filename}")]
    public IActionResult GetByName(string filename)
    {
        var result = mFileRep.GetStream(filename);

        if (result is null)
            return NotFound();

        var (stream, contentType) = result.Value;

        // File(...) will take care of streaming the response
        return File(stream, contentType);
    }
    

    // Return a list of names for all files in the repo. 
    [HttpGet]
    [Route("getall")]
    public List<string> GetAll()
    {
        var res = mFileRep.GetAll();
        return res;
    }
    
    [HttpDelete("delete/{fileName}")]
    public IActionResult Delete(string fileName)
    {
        var deleted = mFileRep.Delete(fileName);

        if (!deleted)
            return NotFound(new { message = $"The file {fileName} not found." });

        return Ok(new { message = "File deleted successfully." });
    }
}