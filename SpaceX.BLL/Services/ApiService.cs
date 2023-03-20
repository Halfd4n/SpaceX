using SpaceX.API.Api;
using SpaceX.BLL.Managers;
using SpaceX.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceX.DTO.ApiModels.ApiModel;

namespace SpaceX.BLL.Services;
public class ApiService : IApiService
{
    private readonly IApiDataProvider _data;
    private readonly ViewModelManager _viewModelManager;

    public ApiService(IApiDataProvider data, ViewModelManager viewModelManager)
    {
        _data = data;
        _viewModelManager = viewModelManager;
    }

    public async Task<List<LaunchViewModel>>? GetLaunches(string endpoint)
    {
        List<Root> rootApiModels = await _data.CallApi(endpoint);

        if (rootApiModels != null)
        {
            return _viewModelManager.ConvertApiModelsToLaunchViewModels(rootApiModels);
        }

        return null;
    }

    public async Task<List<RocketViewModel>>? GetRockets(string endpoint)
    {
        List<Root> rootApiModels = await _data.CallApi(endpoint);

        if(rootApiModels != null)
        {
            return _viewModelManager.ConvertApiModelsToRocketViewModels(rootApiModels);
        }

        return null;
    }
}
