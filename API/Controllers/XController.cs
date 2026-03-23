using API.Model;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("x")]
public class XController : ControllerBase
{

    private XRepository mRepo;

    public XController(XRepository repo)
    {
        mRepo = repo;
    }

    [HttpGet]
    public List<X> Get()
    {
        return mRepo.GetAll();
    }
}