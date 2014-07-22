using System;
using System . Collections . Generic;
using System . Text;
using Windows . UI . Xaml . Controls;

namespace OrangeEndLess
{
    public class GameConsole
    {

        #region StartMessage
        static string StartMessage="OrangeEndLess"

#if WINDOWS_PHONE_APP
 + " For Windows Phone "
#endif

#if WINDOWS_APP
 + " For Windows "
#endif

 + "Console [Verson 1.2.0.0]" + Environment . NewLine + "<c> 2014 OrangeEndLess Team" + Environment . NewLine;

        #endregion

        #region About
        static  string AboutMessage="About" + Environment . NewLine + "MainPage:";
        #endregion

        Core GameCore=new Core ( );

        TextBox TBOut;



        
        void WriteLine ( string str )
        {
            TBOut . Text += str + Environment . NewLine;
            if ( TBOut . Text . Length > 100000 )
            {
                TBOut . Text = TBOut . Text . Remove ( 0 , TBOut . Text . Length - 100000 );
            }
        }

        void Commands ( string strings )
        {
            #region 命令行准备
            WriteLine ( strings );
            string[] strs=( ( strings . Trim ( ) ) . ToLower ( ) ) . Split ( " " . ToCharArray ( ) );
            string command=strs [ 0 ];  //命令的名字
            int length= strs . Length;    //命令参数的个数
            #endregion

            #region Commands About
            if ( command == "about" )
            {
                WriteLine ( AboutMessage );
                return;
            }
            #endregion

            #region Commands NumberOfOrange
            if ( command == "noo" || command == "numberoforange" || command == "numberoforanges" )
            {
                WriteLine ( "The number of ORANGE is " + GameCore . NumberOfOrange . ToString ( ) );
                return;
            }
            #endregion

            #region Commands NumberOfBuliding
            if ( command == "nob" || command == "numberofbuilding" || command == "numberofbuildings" )
            {
                foreach ( var item in GameCore . Buildings )
                {
                    if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
                    {
                        WriteLine ( "The number of " + item . Value . Title . ToUpper ( ) + " is" + item . Value . Number . ToString ( ) );
                        return;

                    }
                }

            }
            #endregion

            #region Commands NumberOfMoney
            if ( command == "nom" || command == "numberofmoney" || command == "numberofcoin" || command == "numberofcoins" )
            {

                WriteLine ( "The number of MONEY is " + GameCore . NumberOfMoney . ToString ( ) );
                return;
            }
            #endregion

            #region Commands SpeedOfOrangeRise
            if ( ( command == "speed" || command == "speedoforangerise" || command == "speedoforange" || command == "soo" || command == "soor" ) && strs . Length == 1 )
            {
                WriteLine ( "The speed of ORANGE rise is " + GameCore . SpeedOfOrangeRise . ToString ( ) + "/s" );
            }
            #endregion

            #region Commands SellOrange
            if ( command == "sell" || command == "sellorange" || command == "selloranges" || command == "so" )
            {
                if ( strs . Length == 2 )
                {
                    decimal _MoneyHaveBuy=0;
                    decimal _OrangeHaveSell=0;
                    GameCore . SellOrange ( Convert . ToDecimal ( strs [ 1 ] ) , out  _MoneyHaveBuy , out _OrangeHaveSell );
                    WriteLine ( "Have sell " + _OrangeHaveSell . ToString ( ) + " Oranges and get " + _MoneyHaveBuy . ToString ( ) );
                    return;
                }
                else
                {

                }
            }
            #endregion

            #region Commands BuyBuildings
            if ( command == "buy" )
            {
                if ( strs . Length == 3 )
                {
                    foreach ( var item in GameCore . Buildings )
                    {
                        if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
                        {
                            decimal _havebuy,_havecost;
                            item . Value . Buy ( Convert . ToDecimal ( strs [ 2 ] ) , GameCore . NumberOfMoney , out _havebuy , out _havecost );
                            WriteLine ( "Have bought " + _havebuy . ToString ( ) + item . Value . Title . ToUpper ( ) + " and cost " + _havecost . ToString ( ) );
                            return;
                        }

                    }
                }
                else
                {
                    WrongCommand ( );
                }

            }
            #endregion

            #region Commands SellBuildings
            if ( command == "sell" )
            {
                if ( strs . Length == 3 )
                {
                    foreach ( var item in GameCore . Buildings )
                    {
                        if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
                        {
                            decimal _havesell,_haveget;
                            item . Value . Sell ( Convert . ToDecimal ( strs [ 2 ] ) , GameCore . NumberOfMoney , out _havesell , out _haveget );
                            WriteLine ( "Have sell " + _havesell . ToString ( ) + item . Value . Title . ToUpper ( ) + " and get " + _haveget . ToString ( ) );
                            return;
                        }
                    }
                }
                else
                {
                    WrongCommand ( );
                }

            }
            #endregion
        }

        void WrongCommand ( )
        {
            WriteLine ( "Command Line Wrong" );
        }

        void GameCore_RandomEvent ( object sender , RandomArgs e )
        {
            WriteLine ( "EVENT" );
            WriteLine ( e . Title );
            WriteLine ( e . Text );
        }

        public GameConsole ( TextBox tbout )
        {
            TBOut = tbout;
            GameCore . RandomEvent += GameCore_RandomEvent;
            WriteLine ( StartMessage );
        }


    }
}
