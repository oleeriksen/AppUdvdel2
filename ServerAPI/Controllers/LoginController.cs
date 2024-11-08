using Core;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private ILoginRepository mRepo;
    public LoginController(ILoginRepository repo)
    {
        mRepo = repo;
    }

    [HttpPost]
    [Route("validate")]
    public bool IsValidLogin(User user)
    {
        return mRepo.IsValid(user);
    }

}