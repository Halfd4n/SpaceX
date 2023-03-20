using SpaceX.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.BLL.Services;
public interface IApiService
{
    public Task<List<LaunchViewModel>> GetLaunches(string endpoint);
    public Task<List<RocketViewModel>> GetRockets(string endpoint);
}
