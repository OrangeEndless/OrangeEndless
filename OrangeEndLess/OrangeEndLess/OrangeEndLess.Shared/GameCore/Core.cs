using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;
using MVVMSidekick . ViewModels;

namespace OrangeEndLess
{
    class Core
    {

        Random Randoms = new Random ( );

        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        DispatcherTimer TimersUpdateData = new DispatcherTimer ( );

        DispatcherTimer TimersRandom = new DispatcherTimer ( );

        DispatcherTimer TimersAPM=new DispatcherTimer ( );

        public delegate void RandomEventHandler ( object sender , RandomArgs e );

        public event RandomEventHandler RandomEvent;

        public event EventHandler UpdateData;


        public long APM  =0;


        #region Buildings

        public Dictionary<string, Building> Buildings = new Dictionary<string , Building> ( );

        void adddictonary ( )
        {

            #region Cursor
            Buildings . Add ( "Cursor" , new Building ( "Cursor" , 1m , 0.1m , new string [ ]
        {
            "c",
            "cur",
            "cursor",
            "zhizhen",
            "zhi",
            "z"
        } ) );
            #endregion

            #region Primary
            Buildings . Add ( "Primary" , new Building ( "Primary" , 10m , 0.5m , new string [ ]
        {
            "prim",
            "primary",
            "xiaoxuesheng",
            "xiao",
            "xuesheng"
        } ) );
            #endregion

            #region Farm
            Buildings . Add ( "Farm" , new Building ( "Farm" , 100m , 4m , new string [ ]
        {
            "far",
            "farm",
            "n",
            "xiao",
            "xuesheng"
        } ) );
            #endregion

            //Buildings . Add ( "Factory" , new Building ( "Factory" , 300m , 10m ) );
            //Buildings . Add ( "Mine" , new Building ( "Mine" , 1400m , 40m ) );
            //Buildings . Add ( "Shipment" , new Building ( "Shipment" , 4000m , 100m ) );
            //Buildings . Add ( "Lab" , new Building ( "Lab" , 20000m , 400m ) );
            //Buildings . Add ( "Portal" , new Building ( "Portal" , 480000m , 6000m ) );
            //Buildings . Add ( "TimeMachine" , new Building ( "TimeMachine" , 12000000m , 100000m ) );
            //Buildings . Add ( "DreamRecorder" , new Building ( "DreamRecorder" , 180000000m , 1000000m ) );
            //Buildings . Add ( "Prism" , new Building ( "Prism" , 20000000000m , 100000000m ) );
        }

        #endregion

        public decimal LevelOfRush
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "LevelOfRush" ] ) + 1;
            }
            set
            {
                GameData . Values [ "LevelOfRush" ] = value - 1;
            }
        }

        public decimal NumberOfOrange
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfOrange" ] );
            }
            set
            {
                GameData . Values [ "NumberOfOrange" ] = value . ToString ( );
            }
        }

        public decimal SpeedOfOrangeRise
        {
            get
            {
                decimal TEMP = 0;
                foreach ( var item in Buildings )
                {
                    TEMP += item . Value . CPS;
                }
                return TEMP;
            }
        }

        public void Rush ( )
        {
            NumberOfOrange += ( LevelOfRush );
        }

        public decimal NumberOfMoney
        {
            get
            {
                return ( decimal ) GameData . Values [ "Money" ];
            }

            set
            {
                GameData . Values [ "Money" ] = value;
            }
        }

        public decimal PriceOfMoney
        {
            get
            {
                return decimal . Ceiling ( ( NumberOfMoney * NumberOfMoney + 10 ) * Randoms . Next ( 800 , 1200 ) / 1000 );
            }
        }

        public void SellOrange ( decimal NumberOfMoneytToBuy , out decimal MoneyHaveBuy , out decimal OrangeHaveSell )
        {
            decimal _MoneyHaveBuy=0;
            decimal _OrangeHaveSell=0;
            while ( NumberOfOrange >= PriceOfMoney && _MoneyHaveBuy <= NumberOfMoneytToBuy )
            {
                NumberOfOrange -= PriceOfMoney;
                _OrangeHaveSell += PriceOfMoney;
                NumberOfMoney++;
                _MoneyHaveBuy++;
            }
            MoneyHaveBuy = _MoneyHaveBuy;
            OrangeHaveSell = _OrangeHaveSell;
        }

        void TimersUpdateData_Tick ( object sender , object e )
        {
            NumberOfOrange += ( decimal ) ( SpeedOfOrangeRise * ( decimal ) ( TimersUpdateData . Interval . TotalMilliseconds / 1000 ) );
            UpdateData . Invoke ( this , new EventArgs ( ) );
        }

        void TimersRandom_Tick ( object sender , object e )
        {
            int Ran=Randoms . Next ( 0 , 100000 );
            string Title=null;
            string Text=null;
            if ( Ran == 1 )
            {

            }
            if ( Title != null && Text != null )
            {
                RandomEvent . Invoke ( this , new RandomArgs ( Title , Text ) );
            }
        }

        void TimersAPM_Tick ( object sender , object e )
        {
            TimersRandom . Interval = new TimeSpan ( 0 , 0 , 0 , 0 , Convert . ToInt32 ( 60 / APM * 1000 ) );
            GameData . Values [ "BestAPM" ] = Math . Max ( ( ( long ) GameData . Values [ "BestAPM" ] ) , APM );
            APM = 0;

        }

        public Core ( )
        {
            if ( GameData . Values [ "GameIsStartV2" ] == null )
            {
                ApplicationData . Current . ClearAsync ( );
                GameData . Values [ "GameIsStartV2" ] = true;
                GameData . Values [ "NumberOfOrange" ] = 0;
                GameData . Values [ "TimeToUpdate" ] = 200;
            }
            if ( GameData . Values [ "TimeToUpdate" ] == null )
            {
                GameData . Values [ "TimeToUpdate" ] = 200;
            }

            TimersUpdateData . Interval = new TimeSpan ( 0 , 0 , 0 , 0 , Convert . ToInt32 ( GameData . Values [ "TimeToUpdate" ] ) );
            TimersUpdateData . Tick += TimersUpdateData_Tick;

            TimersRandom . Interval = new TimeSpan ( 0 , 0 , 0 , 1 );
            TimersRandom . Tick += TimersRandom_Tick;

            TimersAPM . Interval = new TimeSpan ( 0 , 0 , 30 );
            TimersAPM . Tick += TimersAPM_Tick;

            adddictonary ( );
            TimersUpdateData . Start ( );
            TimersRandom . Start ( );
        }
    }

}