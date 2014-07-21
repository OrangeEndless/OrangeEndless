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
    public class Building
    {

        Random Randoms = new Random ( );

        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        DispatcherTimer EventTimer = new DispatcherTimer ( );

        //        public delegate void EventHandler(object sender, EventArgs e);

        public string[] Keys;


        public string Title { get; set; }
        decimal PriceBase { get; set; }
        decimal StartCPS { get; set; }

        public decimal CPS
        {
            get
            {
                return Number * StartCPS * ( Level );
            }
        }

        public decimal Number
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOf" + Title ] );
            }
            set
            {
                GameData . Values [ "NumberOf" + Title ] = value;
            }
        }

        public decimal Level
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "LevelOf" + Title ] ) + 1;
            }
            set
            {
                GameData . Values [ "LevelOf" + Title ] = value - 1;
            }
        }

        public decimal Price
        {
            get
            {
                return PriceBase * Convert . ToDecimal ( Math . Pow ( 1.015 , ( Convert . ToDouble ( Number ) ) ) );
            }
        }

        public void Buy ( decimal number , object numberofmoney , out decimal havebuy , out decimal havecost )
        {
            decimal _havebuy = 0;
            decimal _havecost = 0;
            while ( ( decimal ) numberofmoney >= Price )
            {
                numberofmoney = ( decimal ) numberofmoney - Price;
                _havecost += Price;
                Number++;
                _havebuy++;

            }
            havebuy = _havebuy;
            havecost = _havecost;
        }



        public void Sell ( decimal number , object numberofmoney , out decimal havesell , out decimal haveget )
        {
            decimal _havesell = 0;
            decimal _haveget = 0;
            decimal _priceran;
            while ( Number >= 1 )
            {
                _priceran = decimal . Ceiling ( ( Price ) * Randoms . Next ( 500 , 900 ) / 1000 );
                numberofmoney = _priceran + ( decimal ) numberofmoney;
                _haveget += _priceran;
                Number--;
                _havesell++;
            }
            havesell = _havesell;
            haveget = _haveget;
        }

        public Building ( string name , decimal startprice , decimal startcps , string [ ] keys )
        {
            Title = ( string ) App . Current . Resources [ "TitleOf" + name ];
            PriceBase = startprice;
            StartCPS = startcps;
            Keys = keys;
            if ( GameData . Values [ "LevelOf" + Title ] == null )
            {
                GameData . Values [ "LevelOf" + Title ] = 0;
            }
            if ( GameData . Values [ "NumberOf" + Title ] == null )
            {
                GameData . Values [ "NumberOf" + Title ] = 0;
            }

        }
    }


}
