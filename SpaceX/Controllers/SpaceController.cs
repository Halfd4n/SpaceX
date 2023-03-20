using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceX.BLL.Services;
using SpaceX.DTO.Models;

namespace SpaceX.UI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpaceController : ControllerBase
{
    private readonly IApiService _service;

    public SpaceController(IApiService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<LaunchViewModel>>? Launches()
    {

        List<LaunchViewModel>? launches = await _service.GetLaunches("launches");

        if(launches != null)
        {
            return launches;
        }

        return null;
    }

    [HttpGet]
    public async Task<List<RocketViewModel>>? Rockets()
    {
        List<RocketViewModel>? rockets = await _service.GetRockets("rockets");

        if (rockets != null)
        {
            return rockets;
        }

        return null;
    }
}
