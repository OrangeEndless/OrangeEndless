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
    public partial class Core
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


        public decimal NumberOfUpdateHavePromote
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfUpdateHavePromote" ] );
            }
            set
            {
                GameData . Values [ "NumberOfUpdateHavePromote" ] = value;
            }
        }

        public decimal NumberOfOrangeHaveGet
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveGet" ] );
            }
            set
            {
                GameData . Values [ "NumberOfOrangeHaveGet" ] = value;
            }
        }

        public decimal NumberOfMoneyHaveGet
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfMoneyHaveGet" ] );
            }
            set
            {
                GameData . Values [ "NumberOfMoneyHaveGet" ] = value;
            }
        }

        public decimal NumberOfOrangeHaveMadeFromRush
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveMadeFromRush" ] );
            }
            set
            {
                GameData . Values [ "NumberOfOrangeHaveMadeFromRush" ] = value;
            }
        }

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

        public decimal NumberOfBuilding
        {
            get
            {
                decimal temp=0;
                foreach ( var item in Buildings )
                {
                    temp += item . Value . Number;
                }
                return temp;
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
                if ( NumberOfOrange < value )
                {
                    NumberOfOrangeHaveGet += value - NumberOfOrange;
                }
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
            NumberOfOrangeHaveMadeFromRush += LevelOfRush;
            UpdateData . Invoke ( this , new EventArgs ( ) );
        }

        public decimal NumberOfMoney
        {
            get
            {
                return ( decimal ) GameData . Values [ "Money" ];
            }

            set
            {
                if ( NumberOfMoney < value )
                {
                    NumberOfMoneyHaveGet += value - NumberOfMoney;
                }
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
            decimal time=( decimal ) ( TimersUpdateData . Interval . TotalMilliseconds / 1000 );
            NumberOfOrange += ( decimal ) ( SpeedOfOrangeRise * time );
            foreach ( var item in Buildings )
            {
                item . Value . NumberOfOrangeHaveMade += item . Value . CPS * time;
            }
            foreach ( var item in Achievements )
            {
                item . Check ( this );
            }
            UpdateData . Invoke ( this , new EventArgs ( ) );
        }

        void TimersRandom_Tick ( object sender , object e )
        {
            int Ran=Randoms . Next ( 0 , 100000 );
            foreach ( var item in RandomEvents )
            {
                item.Value.
            }
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

            LoadBuildings ( );
            LoadAchievements ( );
            LoadRandomEvents ( );

            TimersUpdateData . Start ( );
            TimersRandom . Start ( );
            TimersAPM . Start ( );
        }
    }

}