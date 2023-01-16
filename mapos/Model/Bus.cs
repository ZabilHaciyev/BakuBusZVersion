using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapos.Model
{

    public enum BusType
    {
        CREAlIS,
        URBANWAY
    }
    public class Bus
    {
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public Location Location { get; set; }
        public string RouteName { get; set; }
        public string RouteCode { get; set; }
        public BusType BusType { get; set; }
        private string _currentStop;
        public string CurrentStop { get=>" Cari : "+_currentStop; set=>_currentStop=value; }

        private string _nextStop;
        public string NextStop { get=>"Növbəti :"+_nextStop; set=>_nextStop=value; }
    }
}
