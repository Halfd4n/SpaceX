using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceX.DTO.ApiModels.ApiModel;

namespace SpaceX.API.Api;
public interface IApiDataProvider
{
    public Task<List<Root>> CallApi(string endpoint);
}
