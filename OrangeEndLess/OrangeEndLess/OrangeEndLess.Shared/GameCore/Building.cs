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

        Func<Core,bool> FuncBlack;

        Func<Core,bool> FuncShow;

        Core GameCore;

        public string Title;

        public string Label;

        decimal PriceBase;

        decimal StartCPS;

        public Status Status
        {
            get
            {
                if ( FuncShow ( GameCore ) && FuncBlack ( GameCore ) && GameCore . NumberOfMoney >= Price )
                {
                    return Status . Active;
                }
                if ( FuncShow ( GameCore ) && FuncBlack ( GameCore ) && GameCore . NumberOfMoney < Price )
                {
                    return Status . Dark;
                }
                if ( FuncBlack ( GameCore ) && ( FuncShow ( GameCore ) == false ) )
                {
                    return Status . Black;
                }
                if ( FuncBlack ( GameCore ) == false )
                {
                    return Status . Hide;
                }
                return Status . Hide;
            }
        }

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


        /// <summary>
        /// 创建一个建筑
        /// </summary>
        /// <param name="name">建筑的标识</param>
        /// <param name="startprice">价格的初始值</param>
        /// <param name="startcps"></param>
        /// <param name="gamecore">传入当前核心</param>
        /// <param name="funcshow">判断建筑是否显示详细信息</param>
        /// <param name="funcdark">判断建筑是否显示轮廓</param>
        public Building ( string name , decimal startprice , decimal startcps , Core gamecore , Func<Core , bool> funcshow , Func<Core , bool> funcdark )
        {
            Label = name;
            Title = ( string ) App . Current . Resources [ ( "TitleOf" + Level ) ];
            PriceBase = startprice;
            StartCPS = startcps;
            GameCore = gamecore;
            FuncShow = funcshow;
            FuncBlack = funcdark;
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
