﻿using System;
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

        public delegate void RandomEventHandler ( object sender , RandomArgs e );

        public event RandomEventHandler RandomEvent;

        public event EventHandler UpdateNumberOfOrange;

        public event EventHandler UpdateBuildings;

        public event EventHandler UpdateAchevements;

        public event EventHandler UpdateNumberOfMoney;

        public long _APM  =0;

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
                GameData . Values [ "NumberOfOrangeHaveGet" ] = value . ToString ( );
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
                GameData . Values [ "NumberOfMoneyHaveGet" ] = value . ToString ( );
            }
        }

        public decimal NumberOfOrangeHaveMadeFromRush
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "ButtonRushTip" ] );
            }
            set
            {
                GameData . Values [ "ButtonRushTip" ] = value . ToString ( );
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
                GameData . Values [ "LevelOfRush" ] = ( value - 1 ) . ToString ( );
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
                UpdateNumberOfOrange ( this , new EventArgs ( ) );
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

        public Core ( )
        {
            Setup ( );
            if ( GameData . Values [ "GameIsStartV2" ] == null )
            {
                ApplicationData . Current . ClearAsync ( );
                Setup ( );
                GameData . Values [ "GameIsStartV2" ] = true;
            }
            Starting ( );
        }
    }

}