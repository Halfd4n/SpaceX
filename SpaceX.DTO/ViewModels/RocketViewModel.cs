using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.DTO.Models;
public class RocketViewModel
{
    public string? RocketId { get; set; }
    public string? RocketName { get; set; }
    public string? RocketType { get; set; }
    public int CostPerLaunch { get; set; }
    public string Description { get; set; }
}
