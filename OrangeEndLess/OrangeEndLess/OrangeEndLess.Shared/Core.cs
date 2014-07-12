using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace OrangeEndLess
{

    class Building
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.RoamingSettings;
        public string Title { get; set; }
        decimal PriceBase { get; set; }
        decimal StartCPS { get; set; }

        public decimal CPS
        {
            get
            {
                return Number * StartCPS * (Level + 1);
            }
        }

        public decimal Number
        {
            get
            {
                return Convert.ToDecimal(localSettings.Values["NumberOf" + Title]);
            }
            set
            {
                localSettings.Values["NumberOf" + Title] = value;
            }
        }

        public decimal Level
        {
            get
            {
                return Convert.ToDecimal(localSettings.Values["LevelOf" + Title]);
            }
            set
            {
                localSettings.Values["LevelOf" + Title] = value;
            }
        }

        public decimal Price
        {
            get
            {
                return PriceBase * Convert.ToDecimal(Math.Pow(1.015, (Convert.ToDouble(Number))));
            }
        }

        public decimal Buy(decimal number, ref decimal numberoforange)
        {
            decimal havebuy = 0;
            while (numberoforange >= Price)
            {
                numberoforange -= Price;
                Number++;
                havebuy++;
            }
            return havebuy;
        }



        public decimal Sell(decimal number, ref decimal numberoforange)
        {
            decimal havesell = 0;
            while (Number >= 1)
            {
                numberoforange += Price;
                Number--;
                havesell++;
            }
            return havesell;
        }

        public Building(object name, decimal startprice, decimal startcps)
        {
            Title = (string)name;
            PriceBase = startprice;
            StartCPS = startcps;
            if (localSettings.Values["LevelOf" + Title] == null)
            {
                localSettings.Values["LevelOf" + Title] = 0;
            }
            if (localSettings.Values["NumberOf" + Title] == null)
            {
                localSettings.Values["NumberOf" + Title] = 0;
            }
        }
    }

    class Core
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.RoamingSettings;
        #region Buildings

        Building Cursor = new Building(App.Current.Resources["TitleOfCursor"], 15m, 0.1m);
        Building Primary = new Building(App.Current.Resources["TitleOfPrimary"], 100m, 0.5m);
        Building Farm = new Building(App.Current.Resources["TitleOfFarm"], 500m, 4m);
        Building Factory = new Building(App.Current.Resources["TitleOfFactory"], 3000m, 10m);
        Building Mine = new Building(App.Current.Resources["TitleOfMine"], 10000m, 40m);
        Building Shipment = new Building(App.Current.Resources["TitleOfShipment"], 40000m, 100m);
        Building Lab = new Building(App.Current.Resources["TitleOfLab"], 200000m, 400m);
        Building Portal = new Building(App.Current.Resources["TitleOfPortal"], 1666666m, 6666m);
        Building TimeMachine = new Building(App.Current.Resources["TitleOfTimeMachine"], 123456789m, 98765m);
        Building DreamRecorder = new Building(App.Current.Resources["TitleOfDreamRecorder"], 3999999999m, 999999m);
        Building Prism = new Building(App.Current.Resources["TitleOfPrism"], 75000000000m, 10000000m);

        public decimal NumberOfOrange
        {
            get
            {
                return Convert.ToDecimal(localSettings.Values["NumberOfOrange"]);
            }
            set
            {
                localSettings.Values["NumberOfOrange"] = value.ToString();
            }
        }

        decimal SpeedOfOrangeRise
        {
            get
            {
                return Cursor.CPS + Primary.CPS + Farm.CPS + Factory.CPS + Mine.CPS + Shipment.CPS + Lab.CPS + Portal.CPS + TimeMachine.CPS + DreamRecorder.CPS + Prism.CPS;
            }
        }



        #endregion
        public Core()
        {
            if (localSettings.Values["GameIsStartV2"] == null)
            {
                ApplicationData.Current.ClearAsync();
                localSettings.Values["GameIsStartV2"] = true;
                localSettings.Values["NumberOfOrange"] = 0;
                localSettings.Values["TimeToUpdate"] = 200;
            }
            else
            {

            }
            Timers.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(localSettings.Values["TimeToUpdate"]));
            Timers.Tick += Timers_Tick;
        }

        void Timers_Tick(object sender, object e)
        {
            NumberOfOrange += (decimal)(SpeedOfOrangeRise * (decimal)(Timers.Interval.TotalMilliseconds / 1000));
        }

        DispatcherTimer Timers = new DispatcherTimer();

    }
}
