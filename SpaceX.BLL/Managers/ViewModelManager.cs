using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SpaceX.DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SpaceX.DTO.ApiModels.ApiModel;

namespace SpaceX.BLL.Managers;
public class ViewModelManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private string _launchKey;

    public ViewModelManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public List<LaunchViewModel> ConvertApiModelsToLaunchViewModels(List<Root> r_Launches)
    {
        List<LaunchViewModel> vm_launches = new();

        foreach (Root apiModel in r_Launches)
        {
            LaunchViewModel launchViewModel = new()
            {
                FlightNumber = apiModel.flight_number,
                MissionName = apiModel.mission_name,
                LaunchDate = apiModel.launch_date_local,
                Details = apiModel.details,
                Rocket = new RocketViewModel()
                {
                    RocketName = apiModel.rocket.rocket_name,
                    RocketId = apiModel.rocket.rocket_id,
                    RocketType = apiModel.rocket.rocket_type
                },
                LaunchSite = new LaunchSiteViewModel()
                {
                    SiteId = apiModel.launch_site.site_id,
                    SiteNameAbbreviation = apiModel.launch_site.site_name,
                    SiteNameLong = apiModel.launch_site.site_name_long
                }
            };

            vm_launches.Add(launchViewModel);
        }

        return vm_launches;
    }

    public List<RocketViewModel> ConvertApiModelsToRocketViewModels(List<Root> r_Rockets)
    {
        List<RocketViewModel> vm_Rockets = new();

        foreach(Root apiModel in r_Rockets)
        {
            RocketViewModel rocketViewModel = new()
            {
                RocketId = apiModel.rocket_id,
                RocketName = apiModel.rocket_name,
                RocketType = apiModel.rocket_type,
                CostPerLaunch = apiModel.cost_per_launch,
                Description = apiModel.description
            };

            vm_Rockets.Add(rocketViewModel);
        }

        return vm_Rockets;
    }

    public bool FindFavoriteLaunch(int flightNumber, List<LaunchViewModel> allLaunches)
    {
        LaunchViewModel? favouriteLaunch = allLaunches.FirstOrDefault(l => l.FlightNumber.Equals(flightNumber));

        if (favouriteLaunch != null)
        {
            _launchKey = SetLaunchKey(favouriteLaunch.FlightNumber);

            var favoriteLaunchCookie = _httpContextAccessor.HttpContext.Session.GetString(_launchKey);

            if (string.IsNullOrEmpty(favoriteLaunchCookie))
            {
                return false;
            }

        }

        return true;
    }

    public void RemoveFavoriteLaunch(int flightNumber, List<LaunchViewModel> allLaunches)
    {
        LaunchViewModel? favouriteLaunch = allLaunches.FirstOrDefault(l => l.FlightNumber.Equals(flightNumber));

        _launchKey = SetLaunchKey(favouriteLaunch.FlightNumber);

        _httpContextAccessor.HttpContext.Session.Remove(_launchKey);
    }

    public void SaveFavoriteLaunch(int flightNumber, List<LaunchViewModel> allLaunches)
    {
        LaunchViewModel? favouriteLaunch = allLaunches.FirstOrDefault(l => l.FlightNumber.Equals(flightNumber));

        string jsonLaunch = JsonConvert.SerializeObject(favouriteLaunch);

        _launchKey = SetLaunchKey(favouriteLaunch.FlightNumber);

        _httpContextAccessor.HttpContext.Session.SetString(_launchKey, jsonLaunch);
    }

    public List<LaunchViewModel> SetViewModelToFavorite(List<LaunchViewModel> allLaunches)
    {
        foreach(LaunchViewModel launch in allLaunches)
        {
            bool isFavoriteLaunch = FindFavoriteLaunch(launch.FlightNumber, allLaunches);

            if (isFavoriteLaunch)
            {
                launch.IsFavourite = true;
            }
        }

        return allLaunches;
    }

    private string SetLaunchKey(int launchFlightNumber)
    {
        return $"launch_{launchFlightNumber}";
    }
}
