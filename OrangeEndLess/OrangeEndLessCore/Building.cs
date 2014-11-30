using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;
using Windows . ApplicationModel . Resources;

namespace OrangeEndLess
{
    public class Building : BuyAndSellable
    {
        public decimal PriceBase { get; set; }

        public decimal StartCPS { get; set; }

        public void Clean ( )
        {

        }

        public decimal NumberOfOrangeHaveMade
        {
            get;
            //{
            //    return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Key ] );
            //}
            set;
            //{
            //    GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Key ] = value . ToString ( );
            //}
        }

        public decimal AllCPS { get; set; }

        public decimal CPS { get; set; }

        public decimal Number
        {
            get;
            //{
            //    return Convert . ToDecimal ( GameData . Values [ "NumberOf" + Key ] );
            //}
            set;
            //{
            //    GameData . Values [ "NumberOf" + Key ] = value . ToString ( );
            //}
        }

        public decimal Level
        {
            get;
            //{
            //    return Convert . ToDecimal ( GameData . Values [ "LevelOf" + Key ] ) + 1;
            //}
            set;
            //{
            //    GameData . Values [ "LevelOf" + Key ] = ( value - 1 ) . ToString ( );
            //}
        }



    }

}
