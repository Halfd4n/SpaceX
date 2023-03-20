using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SpaceX.BLL.Managers;
using SpaceX.BLL.Services;
using SpaceX.DTO.Models;
using SpaceX.UI;
using SpaceX.UI.Controllers;
using System.Numerics;

namespace SpaceX.Pages;
public class IndexModel : PageModel
{
    private readonly SpaceController _controller;
    private readonly ICalculationsService _service;
    private readonly ViewModelManager _manager;

    public List<LaunchViewModel>? allLaunches { get; set; } = new();
    public List<RocketViewModel>? allRockets { get; set; } = new();
    public long TotalCosts { get; set; }
    public long AverageCost { get; set; }

    public IndexModel(SpaceController controller, ICalculationsService service, ViewModelManager manager)
    {
        _controller = controller;
        _service = service;
        _manager = manager;
    }
    public async Task OnGet()
    {
        allLaunches = await _controller.Launches();

        allLaunches = _manager.SetViewModelToFavorite(allLaunches);

        allRockets = await _controller.Rockets();

        TotalCosts = _service.CalculateTotalCosts(allRockets, allLaunches);

        AverageCost = _service.CalculateAverageCosts(TotalCosts, allLaunches);
    }

    public async Task<IActionResult> OnPostCreateFavoriteLaunch(int flightNumber)
    {
        allLaunches = await _controller.Launches();

        bool isFavoriteLaunch = _manager.FindFavoriteLaunch(flightNumber, allLaunches);

        if (isFavoriteLaunch)
        {
            _manager.RemoveFavoriteLaunch(flightNumber, allLaunches);
        }
        else
        {
            _manager.SaveFavoriteLaunch(flightNumber, allLaunches);
        }


        allLaunches = _manager.SetViewModelToFavorite(allLaunches);

        allRockets = await _controller.Rockets();

        TotalCosts = _service.CalculateTotalCosts(allRockets, allLaunches);

        AverageCost = _service.CalculateAverageCosts(TotalCosts, allLaunches);

        return Page();
    }
}
