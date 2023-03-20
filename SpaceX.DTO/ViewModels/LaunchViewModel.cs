using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.DTO.Models;
public class LaunchViewModel
{
    public int FlightNumber { get; set; }
    public string? MissionName { get; set; }
    public DateTime LaunchDate { get; set; }
    public RocketViewModel? Rocket { get; set; }
    public LaunchSiteViewModel? LaunchSite { get; set; }
    public string? Details { get; set; }
    public bool IsFavourite { get; set; }
}
