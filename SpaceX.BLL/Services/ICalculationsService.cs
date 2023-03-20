using SpaceX.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.BLL.Services;
public interface ICalculationsService
{
    public long CalculateTotalCosts(List<RocketViewModel> rockets, List<LaunchViewModel> launches);

    public long CalculateAverageCosts(long totalcosts, List<LaunchViewModel> launches);
}
