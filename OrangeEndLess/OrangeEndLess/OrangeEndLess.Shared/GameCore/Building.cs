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

        public string Title { get; set; }
        decimal PriceBase { get; set; }
        decimal StartCPS { get; set; }

        public decimal NumberOfOrangeHaveMade
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Title ] );
            }
            set
            {
                GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Title ] = value . ToString ( );
            }
        }

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
                GameData . Values [ "NumberOf" + Title ] = value.ToString();
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
                GameData . Values [ "LevelOf" + Title ] = ( value - 1 ) . ToString ( );
            }
        }

        public decimal Price
        {
            get
            {
                return PriceBase * Convert . ToDecimal ( Math . Pow ( 1.015 , ( Convert . ToDouble ( Number ) ) ) );
            }
        }

        public void Buy ( decimal number , Core cor , out decimal havebuy , out decimal havecost )
        {
            decimal _havebuy = 0;
            decimal _havecost = 0;
            while ( cor . NumberOfMoney >= Price )
            {
                _havecost += Price;
                _havebuy++;
            }
            cor . NumberOfMoney -= _havecost;
            Number += _havebuy;
            havebuy = _havebuy;
            havecost = _havecost;
        }


        public void Sell ( decimal number , Core cor , out decimal havesell , out decimal haveget )
        {
            decimal _havesell = 0;
            decimal _haveget = 0;
            decimal _priceran;
            while ( Number >= 1 )
            {
                _priceran = decimal . Ceiling ( ( Price ) * Randoms . Next ( 500 , 900 ) / 1000 );
                _haveget += _priceran;
                _havesell++;
            }
            cor . NumberOfMoney += _haveget;
            Number -= _havesell;
            havesell = _havesell;
            haveget = _haveget;
        }

        public Building ( string name , decimal startprice , decimal startcps )
        {
            Title = ( string ) App . Current . Resources [ ( "TitleOf" + name ) ];
            PriceBase = startprice;
            StartCPS = startcps;
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
