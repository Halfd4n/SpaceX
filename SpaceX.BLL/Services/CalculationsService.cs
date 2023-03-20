using SpaceX.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.BLL.Services;
public class CalculationsService : ICalculationsService
{
    public long CalculateTotalCosts(List<RocketViewModel> rockets, List<LaunchViewModel> launches)
    {
        long totalCosts = 0;

        foreach (RocketViewModel rocket in rockets)
        {
            var matchingLaunches = launches.Where(l => l.Rocket.RocketId.Equals(rocket.RocketId));

            long rocketLaunchCosts = matchingLaunches.Sum(launch => (long)rocket.CostPerLaunch);

            totalCosts += rocketLaunchCosts;
        }

        return totalCosts;
    }

    public long CalculateAverageCosts(long totalCosts, List<LaunchViewModel> launches)
    {
        return totalCosts / launches.Count();
    }
}
