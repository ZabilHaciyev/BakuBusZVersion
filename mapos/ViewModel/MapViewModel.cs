using mapos.Command;
using mapos.Model;
using mapos.Services;
using Microsoft.Maps.MapControl.WPF;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace mapos.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MapViewModel
    {

        public const string ApiKey = "raNHZk14lZCfGGoR96xF~qL1vKk-qEboD8AfbukE3aA~AnUdvw2tGztwBxwndtUFVTN6WaGKMxX072J4Kcxz-Iqq7borzdciKw8SSNJF2WAk";
        public ApplicationIdCredentialsProvider Provider { get; set; }

        private BakuBusService _busService;
        public ObservableCollection<Bus> Buses { get; set; } 
        public List<string> BusesRouteCodes { get; set; }
        public ICommand SearchButton { get; set; }

        public MapViewModel()
        {
           _busService = new BakuBusService();
            Buses = new ObservableCollection<Bus>(_busService.GetAllBuses());
            List<string> buses = new List<string>();
            buses.Add("ümumi siyahı");
            foreach (var item in Buses)
            {
                buses.Add(item.RouteCode);
            }
            BusesRouteCodes = buses.Distinct().ToList();
            Provider = new ApplicationIdCredentialsProvider(ApiKey);
            SearchButton = new RelayCommand(SearchButtonExecute);

            DispatcherTimer timer = new DispatcherTimer();
          timer.Interval = TimeSpan.FromSeconds(10);
          timer.Tick += new EventHandler(Timer_Tick);
          timer.Start();


        }

        private void SearchButtonExecute(object obj)
        {
            var str = obj as string;
            Buses = new ObservableCollection<Bus>(_busService.GetAllBusesByRouteCode(str));
        }
         private void Timer_Tick(object sender, EventArgs e)
         {
             Provider = new ApplicationIdCredentialsProvider(ApiKey);
             _busService = new BakuBusService();
             Buses = new ObservableCollection<Bus>(_busService.GetAllBuses());
         }

    }
}
