using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.DTO.ApiModels;
public class ApiModel
{
    public class CompositeFairing
    {
        public Height height { get; set; }
        public Diameter diameter { get; set; }
    }

    public class Diameter
    {
        public double? meters { get; set; }
        public double? feet { get; set; }
    }

    public class Engines
    {
        public int number { get; set; }
        public string type { get; set; }
        public string version { get; set; }
        public string layout { get; set; }
        public Isp isp { get; set; }
        public int? engine_loss_max { get; set; }
        public string propellant_1 { get; set; }
        public string propellant_2 { get; set; }
        public ThrustSeaLevel thrust_sea_level { get; set; }
        public ThrustVacuum thrust_vacuum { get; set; }
        public double? thrust_to_weight { get; set; }
    }

    public class FirstStage
    {
        public bool reusable { get; set; }
        public int engines { get; set; }
        public double? fuel_amount_tons { get; set; }
        public int? burn_time_sec { get; set; }
        public ThrustSeaLevel thrust_sea_level { get; set; }
        public ThrustVacuum thrust_vacuum { get; set; }
    }

    public class Height
    {
        public double? meters { get; set; }
        public double? feet { get; set; }
    }

    public class Isp
    {
        public int sea_level { get; set; }
        public int vacuum { get; set; }
    }

    public class LandingLegs
    {
        public int number { get; set; }
        public string material { get; set; }
    }

    public class Mass
    {
        public int kg { get; set; }
        public int lb { get; set; }
    }

    public class PayloadWeight
    {
        public string id { get; set; }
        public string name { get; set; }
        public int kg { get; set; }
        public int lb { get; set; }
    }

    public class SecondStage
    {
        public bool reusable { get; set; }
        public int engines { get; set; }
        public double? fuel_amount_tons { get; set; }
        public int? burn_time_sec { get; set; }
        public Thrust thrust { get; set; }
    }

    public class Thrust
    {
        public int kN { get; set; }
        public int lbf { get; set; }
    }

    public class ThrustSeaLevel
    {
        public int kN { get; set; }
        public int lbf { get; set; }
    }

    public class ThrustVacuum
    {
        public int kN { get; set; }
        public int lbf { get; set; }
    }
    public class Core
    {
        public string? core_serial { get; set; }
        public int? flight { get; set; }
        public int? block { get; set; }
        public bool? gridfins { get; set; }
        public bool? legs { get; set; }
        public bool? reused { get; set; }
        public bool? land_success { get; set; }
        public bool? landing_intent { get; set; }
        public string? landing_type { get; set; }
        public string? landing_vehicle { get; set; }
    }

    public class Fairings
    {
        public bool? reused { get; set; }
        public bool? recovery_attempt { get; set; }
        public bool? recovered { get; set; }
        public string? ship { get; set; }
    }


    public class LaunchFailureDetails
    {
        public int time { get; set; }
        public int? altitude { get; set; }
        public string? reason { get; set; }
    }

    public class LaunchSite
    {
        public string site_id { get; set; }
        public string site_name { get; set; }
        public string site_name_long { get; set; }
    }

    public class OrbitParams
    {
        public string reference_system { get; set; }
        public string regime { get; set; }
        public double? longitude { get; set; }
        public double? semi_major_axis_km { get; set; }
        public double? eccentricity { get; set; }
        public double? periapsis_km { get; set; }
        public double? apoapsis_km { get; set; }
        public double? inclination_deg { get; set; }
        public double? period_min { get; set; }
        public double? lifespan_years { get; set; }
        public DateTime? epoch { get; set; }
        public double? mean_motion { get; set; }
        public double? raan { get; set; }
        public double? arg_of_pericenter { get; set; }
        public double? mean_anomaly { get; set; }
    }

    public class Payload
    {
        public string payload_id { get; set; }
        public List<int> norad_id { get; set; }
        public bool reused { get; set; }
        public List<string> customers { get; set; }
        public string nationality { get; set; }
        public string manufacturer { get; set; }
        public string payload_type { get; set; }
        public double? payload_mass_kg { get; set; }
        public double? payload_mass_lbs { get; set; }
        public string orbit { get; set; }
        public OrbitParams orbit_params { get; set; }
        public string cap_serial { get; set; }
        public double? mass_returned_kg { get; set; }
        public double? mass_returned_lbs { get; set; }
        public int? flight_time_sec { get; set; }
        public string cargo_manifest { get; set; }
        public string uid { get; set; }
    }

    public class Rocket
    {
        public string? rocket_id { get; set; }
        public string? rocket_name { get; set; }
        public string? rocket_type { get; set; }
        public FirstStage first_stage { get; set; }
        public SecondStage second_stage { get; set; }
        public Fairings? fairings { get; set; }
    }

    public class Root
    {
        // Launch root:
        public int flight_number { get; set; }
        public string? mission_name { get; set; }
        public List<string>? mission_id { get; set; }
        public bool upcoming { get; set; }
        public string? launch_year { get; set; }
        public int launch_date_unix { get; set; }
        public DateTime launch_date_utc { get; set; }
        public DateTime launch_date_local { get; set; }
        public bool is_tentative { get; set; }
        public string? tentative_max_precision { get; set; }
        public bool tbd { get; set; }
        public int? launch_window { get; set; }
        public Rocket? rocket { get; set; }
        public List<string>? ships { get; set; }
        public Telemetry? telemetry { get; set; }
        public LaunchSite? launch_site { get; set; }
        public bool? launch_success { get; set; }
        public LaunchFailureDetails? launch_failure_details { get; set; }
        public string? details { get; set; }
        public DateTime? static_fire_date_utc { get; set; }
        public int? static_fire_date_unix { get; set; }
        public Timeline? timeline { get; set; }
        public List<object>? crew { get; set; }
        public DateTime? last_date_update { get; set; }
        public DateTime? last_ll_launch_date { get; set; }
        public DateTime? last_ll_update { get; set; }
        public DateTime? last_wiki_launch_date { get; set; }
        public string? last_wiki_revision { get; set; }
        public DateTime? last_wiki_update { get; set; }
        public string? launch_date_source { get; set; }

        // Rocket root:
        public int id { get; set; }
        public bool active { get; set; }
        public int stages { get; set; }
        public int boosters { get; set; }
        public int cost_per_launch { get; set; }
        public int success_rate_pct { get; set; }
        public string first_flight { get; set; }
        public string country { get; set; }
        public string company { get; set; }
        public Height height { get; set; }
        public Diameter diameter { get; set; }
        public Mass mass { get; set; }
        public List<PayloadWeight> payload_weights { get; set; }
        public FirstStage first_stage { get; set; }
        public SecondStage second_stage { get; set; }
        public Engines engines { get; set; }
        public LandingLegs landing_legs { get; set; }
        public List<string> flickr_images { get; set; }
        public string wikipedia { get; set; }
        public string description { get; set; }
        public string rocket_id { get; set; }
        public string rocket_name { get; set; }
        public string rocket_type { get; set; }

    }

    public class Telemetry
    {
        public string? flight_club { get; set; }
    }

    public class Timeline
    {
        public int? webcast_liftoff { get; set; }
        public int? go_for_prop_loading { get; set; }
        public int? rp1_loading { get; set; }
        public int? stage1_lox_loading { get; set; }
        public int? stage2_lox_loading { get; set; }
        public int? engine_chill { get; set; }
        public int? prelaunch_checks { get; set; }
        public int? propellant_pressurization { get; set; }
        public int? go_for_launch { get; set; }
        public int? ignition { get; set; }
        public int? liftoff { get; set; }
        public int? maxq { get; set; }
        public int? meco { get; set; }
        public int? stage_sep { get; set; }
        public int? second_stage_ignition { get; set; }
    }

}
