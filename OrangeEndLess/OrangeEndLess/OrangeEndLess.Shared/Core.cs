using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MVVMSidekick.ViewModels;

namespace OrangeEndLess
{




    class Building
    {

        Random Randoms = new Random();

        ApplicationDataContainer localSettings = ApplicationData.Current.RoamingSettings;

        DispatcherTimer EventTimer = new DispatcherTimer();

        //        public delegate void EventHandler(object sender, EventArgs e);


        public string Title { get; set; }
        decimal PriceBase { get; set; }
        decimal StartCPS { get; set; }

        public decimal CPS
        {
            get
            {
                return Number * StartCPS * (Level);
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
                return Convert.ToDecimal(localSettings.Values["LevelOf" + Title]) + 1;
            }
            set
            {
                localSettings.Values["LevelOf" + Title] = value - 1;
            }
        }

        public decimal Price
        {
            get
            {
                return PriceBase * Convert.ToDecimal(Math.Pow(1.015, (Convert.ToDouble(Number))));
            }
        }

        public decimal Buy(decimal number, ref decimal numberofmoney)
        {
            decimal havebuy = 0;
            while (numberofmoney >= Price)
            {
                numberofmoney -= Price;
                Number++;
                havebuy++;
            }
            return havebuy;
        }



        public decimal Sell(decimal number, ref decimal numberofmoney)
        {
            decimal havesell = 0;
            while (Number >= 1)
            {
                numberofmoney += decimal.Ceiling((Price) * Randoms.Next(500, 900) / 1000);
                Number--;
                havesell++;
            }
            return havesell;
        }

        public Building(string name, decimal startprice, decimal startcps)
        {
            Title = (string)App.Current.Resources["TitleOf" + name];
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

        Random Randoms = new Random();

        ApplicationDataContainer localSettings = ApplicationData.Current.RoamingSettings;

        #region Buildings

        public Dictionary<string, Building> Buildings = new Dictionary<string, Building>();

        void addtodictonary()
        {
            Buildings.Add("Cursor", new Building("Cursor", 15m, 0.1m));
            Buildings.Add("Primary", new Building("Primary", 100m, 0.5m));
            Building Farm = new Building("Farm", 500m, 4m);
            Building Factory = new Building("Factory", 3000m, 10m);
            Building Mine = new Building("Mine", 10000m, 40m);
            Building Shipment = new Building("Shipment", 40000m, 100m);
            Building Lab = new Building("Lab", 200000m, 400m);
            Building Portal = new Building("Portal", 1666666m, 6666m);
            Building TimeMachine = new Building("TimeMachine", 123456789m, 98765m);
            Building DreamRecorder = new Building("DreamRecorder", 3999999999m, 999999m);
            Building Prism = new Building("Prism", 75000000000m, 10000000m);
        }
        #endregion

        public decimal LevelOfRush
        {
            get
            {
                return Convert.ToDecimal(localSettings.Values["LevelOfRush"]) + 1;
            }
            set
            {
                localSettings.Values["LevelOfRush"] = value - 1;
            }
        }

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

        public decimal SpeedOfOrangeRise
        {
            get
            {
                return Cursor.CPS + Primary.CPS + Farm.CPS + Factory.CPS + Mine.CPS + Shipment.CPS + Lab.CPS + Portal.CPS + TimeMachine.CPS + DreamRecorder.CPS + Prism.CPS;
            }
        }

        public void Rush()
        {
            NumberOfOrange += (LevelOfRush);
        }



        public decimal NumberOfMoney
        {
            get
            {
                return (decimal)localSettings.Values["Money"];
            }

            set
            {
                localSettings.Values["Money"] = value;
            }
        }

        public decimal PriceOfMoney
        {
            get
            {
                return decimal.Ceiling((NumberOfMoney * NumberOfMoney + 10) * Randoms.Next(800, 1200) / 1000);
            }
        }

        DispatcherTimer Timers = new DispatcherTimer();


        void Timers_Tick(object sender, object e)
        {
            NumberOfOrange += (decimal)(SpeedOfOrangeRise * (decimal)(Timers.Interval.TotalMilliseconds / 1000));
        }


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


    }
}
