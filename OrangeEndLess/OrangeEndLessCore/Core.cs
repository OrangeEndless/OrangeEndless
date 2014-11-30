using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;

namespace OrangeEndLess
{
    public partial class Core
    {

        public static Core Current;

        Random Randoms = new Random ( );

        ApplicationDataContainer LocalData = ApplicationData . Current . LocalSettings;

        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        //public event RandomEventHandler ( object sender , RandomArgs e );

        //public event RandomEventHandler RandomEvent;

        public event EventHandler UpdateNumberOfOrange;

        public event EventHandler UpdateBuildings;

        public event EventHandler UpdateAchevements;

        public event EventHandler UpdateNumberOfMoney;

        public event EventHandler CheatChanged;

        int _APM = 0;

        public void Cheat ( )
        {
            Cheated = true;
        }

        public bool Cheated { get; private set; }

        public void PlusAPM ( )
        {
            APM++;
        }

        public long APM { get; set; }

        public decimal MyProperty { get; set; }

        public decimal NumberOfOrangeHaveGet { get; set; }

        public decimal NumberOfMoneyHaveGet { get; set; }

        public decimal NumberOfOrangeHaveMadeFromRush { get; set; }

        public decimal LevelOfRush { get; set; }

        public decimal NumberOfBuilding
        {
            get
            {
                decimal temp = 0;
                foreach ( var item in Buildings )
                {
                    temp += item . Value . Number;
                }
                return temp;
            }
        }

        decimal _NumberOfOrange;

        public decimal NumberOfOrange
        {
            get
            {
                return _NumberOfOrange;
            }
            set
            {
                if ( NumberOfOrange < value )
                {
                    NumberOfOrangeHaveGet += value - NumberOfOrange;
                }
                _NumberOfOrange = value;
            }
        }

        public decimal SpeedOfOrangeRise
        {
            get
            {
                decimal temp = 0;
                foreach ( var item in Buildings )
                {
                    temp += item . Value . AllCPS;
                }
                return temp;
            }
        }

        public void Rush ( )
        {
            NumberOfOrange += ( LevelOfRush );
            NumberOfOrangeHaveMadeFromRush += LevelOfRush;
        }

        public decimal NumberOfMoney
        {
            get
            {
                return Convert . ToDecimal ( ( string ) GameData . Values [ "Money" ] );
            }

            set
            {
                if ( NumberOfMoney < value )
                {
                    NumberOfMoneyHaveGet += value - NumberOfMoney;
                }
                GameData . Values [ "Money" ] = value . ToString ( );
                UpdateNumberOfMoney ( this , new EventArgs ( ) );
            }
        }

        public decimal PriceOfMoney
        {
            get
            {
                return decimal . Ceiling ( ( NumberOfMoney * NumberOfMoney + 10 ) * Randoms . Next ( 800 , 1200 ) / 1000 );
            }
        }

        /// <summary>
        /// 销售橘子
        /// </summary>
        /// <param name="NumberOfMoneytToBuy">希望获得的钱</param>
        /// <param name="MoneyHaveBuy">获得的钱</param>
        /// <param name="OrangeHaveSell">销售的橘子</param>
        public void SellOrange ( decimal NumberOfMoneytToBuy , out decimal MoneyHaveBuy , out decimal OrangeHaveSell )
        {
            decimal _MoneyHaveBuy = 0;
            decimal _OrangeHaveSell = 0;
            while ( NumberOfOrange >= PriceOfMoney && _MoneyHaveBuy < NumberOfMoneytToBuy )
            {
                NumberOfOrange -= PriceOfMoney;
                _OrangeHaveSell += PriceOfMoney;
                NumberOfMoney++;
                _MoneyHaveBuy++;
            }
            MoneyHaveBuy = _MoneyHaveBuy;
            OrangeHaveSell = _OrangeHaveSell;
        }

        public Core ( )
        {
            Current = this;
#if DEBUG
            GameData . Values [ "GameIsStartV2" ] = null;
#endif
            if ( GameData . Values [ "GameIsStartV2" ] == null )
            {
                ApplicationData . Current . ClearAsync ( ) . GetResults ( );
                Setup ( );
            }
            else
            {
                if ( DateTime . Now > Convert . ToDateTime ( GameData . Values [ "LastShutdown" ] ) )
                {
                    NumberOfOrange += Convert . ToDecimal ( GameData . Values [ "SpeedOfOrangeRise" ] ) * Convert . ToDecimal ( ( DateTime . Now - Convert . ToDateTime ( GameData . Values [ "LastShutdown" ] ) ) . TotalSeconds );
                }
                else
                {
                    Setup ( );
                }
            }
        }
    }


}