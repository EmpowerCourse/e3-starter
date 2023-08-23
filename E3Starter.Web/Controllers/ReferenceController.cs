using AutoMapper;
using E3Starter.Configuration;
using E3Starter.Contracts.Services;
using E3Starter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ControllerBase = E3Starter.Web.Controllers.Base.ControllerBase;

namespace E3Starter.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReferenceController : ControllerBase
{
    public ReferenceController(IOptions<AppSettings> options, IMapper mapper, IUserService userService) : base(options, mapper, userService)
    { 
    }

    public IActionResult Index()
    {
        return Ok();
    }
}
