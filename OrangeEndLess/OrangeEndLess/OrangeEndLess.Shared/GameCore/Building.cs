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

        Func<Core,bool> FuncDark;

        Func<Core,bool> FuncShow;

        Core GameCore;

        public Status Status
        {
            get
            {
                if ( FuncShow ( GameCore ) )
                {
                    return Status . Show;
                }
                if ( FuncDark ( GameCore ) )
                {
                    return Status . Dark;
                }
                return Status . Hide;
            }
        }

        public string Title { get; set; }

        public string Label { get; set; }

        decimal PriceBase { get; set; }

        decimal StartCPS { get; set; }

        public void Clean ( )
        {
            GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Label ] = GameData . Values [ "NumberOf" + Label ] = GameData . Values [ "LevelOf" + Label ] = 0;
        }

        public decimal NumberOfOrangeHaveMade
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Label ] );
            }
            set
            {
                GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Label ] = value . ToString ( );
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
                return Convert . ToDecimal ( GameData . Values [ "NumberOf" + Label ] );
            }
            set
            {
                GameData . Values [ "NumberOf" + Label ] = value . ToString ( );
            }
        }

        public decimal Level
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "LevelOf" + Label ] ) + 1;
            }
            set
            {
                GameData . Values [ "LevelOf" + Label ] = ( value - 1 ) . ToString ( );
            }
        }

        public decimal Price
        {
            get
            {
                return PriceBase * Convert . ToDecimal ( Math . Pow ( 1.015 , ( Convert . ToDouble ( Number ) ) ) );
            }
        }

        public void Buy ( decimal number , out decimal havebuy , out decimal havecost )
        {
            decimal _havebuy = 0;
            decimal _havecost = 0;
            while ( GameCore . NumberOfMoney >= Price )
            {
                _havecost += Price;
                _havebuy++;
            }
            GameCore . NumberOfMoney -= _havecost;
            Number += _havebuy;
            havebuy = _havebuy;
            havecost = _havecost;
            GameCore . UpdateBuildingsFromBuilding ( this );
        }


        public void Sell ( decimal number , out decimal havesell , out decimal haveget )
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
            GameCore . NumberOfMoney += _haveget;
            Number -= _havesell;
            havesell = _havesell;
            haveget = _haveget;
            GameCore . UpdateBuildingsFromBuilding ( this );
        }

        public Building ( string name , decimal startprice , decimal startcps , Core gamecore , Func<Core , bool> funcshow , Func<Core , bool> funcdark )
        {
            Label = name;
            Title = ( string ) App . Current . Resources [ ( "TitleOf" + name ) ];
            PriceBase = startprice;
            StartCPS = startcps;
            GameCore = gamecore;
            FuncShow = funcshow;
            FuncDark = funcdark;
            if ( GameData . Values [ "LevelOf" + Label ] == null )
            {
                GameData . Values [ "LevelOf" + Label ] = 0;
            }
            if ( GameData . Values [ "NumberOf" + Label ] == null )
            {
                GameData . Values [ "NumberOf" + Label ] = 0;
            }

        }
    }


}
