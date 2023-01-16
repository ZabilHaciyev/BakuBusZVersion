using mapos.Model;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mapos.Services
{
    public class BakuBusService
    {
        public List<Bus> AllBuses { get; set; }=new List<Bus>();
        public List<Bus> BusesForRouteCode { get; set; } = new List<Bus>();

        public IEnumerable<Bus> GetAllBuses()
        {
   
            HttpClient client = new HttpClient();
            var link = "https://www.bakubus.az/az/ajax/apiNew1";

            dynamic busses = JsonConvert.DeserializeObject(client.GetAsync(link).Result.Content.ReadAsStringAsync().Result);


            foreach (var item in busses.BUS)
            {
                dynamic bus = item["@attributes"];

                string _lat = bus["LATITUDE"];
                string _long = bus["LONGITUDE"];
                Location location = new Location(double.Parse(_lat.Replace(",", ".")), double.Parse(_long.Replace(",", ".")));

                if (bus["BUS_MODEL"] != "CREALIS" && bus["BUS_MODEL"]!="URBANWAY")
                {
                    bus["BUS_MODEL"] = "URBANWAY";
                }
                var b = new Bus() {

                    DriverName = bus["DRIVER_NAME"],
                    BusType = bus["BUS_MODEL"],
                    CurrentStop = bus["PREV_STOP"],
                    NextStop = bus["CURRENT_STOP"],
                    RouteName = bus["ROUTE_NAME"],
                    Plate = bus["PLATE"],
                    RouteCode = bus["DISPLAY_ROUTE_CODE"],
                    Location = location
                };
                AllBuses.Add(b);
            }

            return AllBuses;
        }


       



        public IEnumerable<Bus> GetAllBusesByRouteCode(string routCode )
        {
            BusesForRouteCode.Clear();

            if (routCode=="ümumi siyahı") return AllBuses;
            else{
            foreach (var item in AllBuses)
            {
                if (item.RouteCode==routCode)
                {
                    BusesForRouteCode.Add(item);
                }
            }
            return BusesForRouteCode;
            }
        }
    }
}
