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
	public class Command
	{
		public string Name;

		public string[] Keys;

		public Action< string[]> Doing;

		/// <summary>
		/// 初始化 OrangeEndLess.Command 类的新实例，该实例拥有
		/// </summary>
		/// <param name="name">命令的名称</param>
		/// <param name="Key">命令的唯一调用标识符</param>
		/// <param name="Do">命令的执行内容</param>
		public Command ( string name , string [ ] Key , Action<string [ ]> Do )
		{
			Name = name;
			Keys = Key;
			Doing = Do;
		}
	}

	public partial class Core
	{

		#region StartMessage
		static string StartMessage = string . Format ( "OrangeEndLess [Verson 2.0.0.0]" + Environment . NewLine + "<c> 2014 OrangeEndLess Team" + Environment . NewLine );
		#endregion

		#region About
		static string AboutMessage = "About" + Environment . NewLine + "OrangeEndLess" + Environment . NewLine + "2.0.0.0 Beta";
		#endregion

		List<Command> CommandList=new List<Command> ( );

		public event EventHandler UpdateConsole;


		private string ConsoleText="";



		public string ConsoleTextOut
		{
			get { return ConsoleText; }
			set { ConsoleText = value; UpdateConsole ( this , new EventArgs ( ) ); }
		}

		void WriteLine ( string str )
		{
			ConsoleTextOut += str + Environment . NewLine;
			if ( ConsoleTextOut . Length > 10000000 )
			{
				ConsoleTextOut = ConsoleTextOut . Remove ( 0 , ConsoleTextOut . Length - 10000000 );
			}
		}

		public void Commands ( string strings )
		{
			#region 命令行准备
			WriteLine ( strings );
			string[] strs = ( ( strings . Trim ( ) ) . ToLower ( ) ) . Split ( " " . ToCharArray ( ) );
			string command = strs [ 0 ];  //命令的名字
			#endregion

			foreach ( var item in CommandList )
			{
				foreach ( var args in item . Keys )
				{
					if ( command == args )
					{
						try
						{
							item . Doing ( strs );
						}
						catch ( Exception E )
						{
							WriteLine ( string . Format ( "命令	{0}	触发了未经处理的异常" , item . Name ) );
							WriteLine ( E . Message );
							WriteLine("在");
							WriteLine(E.StackTrace);
						}
						return;
					}
				}
			}
			WrongCommand ( );

			//#region Commands About
			//if ( command == "about" )
			//{
			//	WriteLine ( AboutMessage );
			//	return;
			//}
			//#endregion

			//#region Commands Rush
			//if ( command == "rush" )
			//{
			//	GameCore . Rush ( );
			//	WriteLine ( AboutMessage );
			//	return;
			//}
			//#endregion

			//#region Commands NumberOfOrange
			//if ( command == "noo" || command == "numberoforange" || command == "numberoforanges" )
			//{

			//	WriteLine ( string . Format ( "The number of ORANGE is {0}" , GameCore . NumberOfOrange . ToString ( ) ) );
			//	return;
			//}
			//#endregion

			//#region Commands NumberOfBuliding
			//if ( command == "nob" || command == "numberofbuilding" || command == "numberofbuildings" )
			//{
			//	foreach ( var item in GameCore . Buildings )
			//	{
			//		if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
			//		{
			//			WriteLine ( string . Format ( "The number of {0} is {1}" , item . Value . Title . ToUpper ( ) , item . Value . Number . ToString ( ) ) );
			//			return;
			//		}
			//	}

			//}
			//#endregion

			//#region Commands NumberOfMoney
			//if ( command == "nom" || command == "numberofmoney" || command == "numberofcoin" || command == "numberofcoins" )
			//{

			//	WriteLine ( string . Format ( "The number of MONEY is {0}" , GameCore . NumberOfMoney . ToString ( ) ) );
			//	return;
			//}
			//#endregion

			//#region Commands SpeedOfOrangeRise
			//if ( ( command == "speed" || command == "speedoforangerise" || command == "speedoforange" || command == "soo" || command == "soor" ) && strs . Length == 1 )
			//{
			//	WriteLine ( string . Format ( "The speed of ORANGE rise is {0}/s" , GameCore . SpeedOfOrangeRise . ToString ( ) ) );
			//}
			//#endregion

			//#region Commands SellOrange
			//if ( command == "sell" || command == "sellorange" || command == "selloranges" || command == "so" )
			//{
			//	if ( strs . Length == 2 )
			//	{
			//		decimal _MoneyHaveBuy = 0;
			//		decimal _OrangeHaveSell = 0;
			//		GameCore . SellOrange ( Convert . ToDecimal ( strs [ 1 ] ) , out  _MoneyHaveBuy , out _OrangeHaveSell );
			//		WriteLine ( string . Format ( "Have sell {0} Oranges and get ${1}" , _OrangeHaveSell . ToString ( ) , _MoneyHaveBuy . ToString ( ) ) );
			//		return;
			//	}
			//	else
			//	{

			//	}
			//}
			//#endregion

			//#region Commands BuyBuildings
			//if ( command == "buy" )
			//{
			//	if ( strs . Length == 3 )
			//	{
			//		foreach ( var item in GameCore . Buildings )
			//		{
			//			if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
			//			{
			//				decimal _havebuy, _havecost;
			//				item . Value . Buy ( Convert . ToDecimal ( strs [ 2 ] ) , out _havebuy , out _havecost );
			//				WriteLine ( string . Format ( "Have bought {0} {1} and cost {2}" , _havebuy . ToString ( ) , item . Value . Title . ToUpper ( ) , _havecost . ToString ( ) ) );
			//				return;
			//			}

			//		}
			//	}
			//	else
			//	{
			//		WrongCommand ( );
			//	}

			//}
			//#endregion

			//#region Commands SellBuildings
			//if ( command == "sell" )
			//{
			//	if ( strs . Length == 3 )
			//	{
			//		foreach ( var item in GameCore . Buildings )
			//		{
			//			if ( item . Value . Title . StartsWith ( strs [ 1 ] ) )
			//			{
			//				decimal _havesell, _haveget;
			//				item . Value . Sell ( Convert . ToDecimal ( strs [ 2 ] ) , out _havesell , out _haveget );
			//				WriteLine ( "Have sell " + _havesell . ToString ( ) + item . Value . Title . ToUpper ( ) + " and get " + _haveget . ToString ( ) );
			//				return;
			//			}
			//		}
			//	}
			//	else
			//	{
			//		WrongCommand ( );
			//	}

			//}
			//#endregion
		}

		void WrongCommand ( )
		{
			WriteLine ( "Command Line Wrong" );
		}

		//void GameCore_RandomEvent(object sender, RandomArgs e)
		//{
		//	WriteLine("EVENT");
		//	WriteLine(e.Title);
		//	WriteLine(e.Text);
		//}

		void LoadConsole ( )
		{
            ////GameCore.RandomEvent += GameCore_RandomEvent;
            //ConsoleText = StartMessage;
            //CommandList . Add ( new Command ( "About" , new string [ ] { "about" } , ( list ) => { WriteLine ( AboutMessage ); } ) );
            //CommandList . Add ( new Command ( "Rush" , new string [ ] { "rush" } , ( list ) =>
            //{
            //    Rush ( );
            //}
            //    ) );
            //CommandList . Add ( new Command ( "Cheat" , new string [ ] { "cheat" } , ( list ) =>
            //{
            //    Cheat ( );
            //} ) );
            //CommandList . Add ( new Command ( "NumberOfOrange" , new string [ ] { "noo" , "numberoforange" } , ( list ) =>
            //{
            //    WriteLine ( NumberOfOrange . ToString ( ) );
            //} ) );
            //CommandList . Add ( new Command ( "NumberOfMoney" , new string [ ] { "nom" , "numberofmoney" } , ( list ) =>
            //{
            //    WriteLine ( NumberOfMoney . ToString ( ) );
            //} ) );
            //CommandList . Add ( new Command ( "BuildingList" , new string [ ] { "bl" , "buildinglist" } , ( list ) =>
            //{
            //    foreach ( var building in Buildings )
            //    {
            //        if ( building . Value . Status == Status . Active || building . Value . Status == Status . Dark )
            //        {
            //            WriteLine ( string . Format ( "{0}	Number:{1}	CPS:{2}		Price:{3}	Key:{4}" , building . Value . Title , building . Value . Number , building . Value . CPS , building . Value . Price ) );
            //        }
            //        if ( building . Value . Status == Status . Black )
            //        {
            //            WriteLine ( "Unknow" );
            //        }
            //    }
            //} ) );
            //CommandList . Add ( new Command ( "AchievementList" , new string [ ] { "al" , "achievementlist" } , ( list ) =>
            //{
            //    foreach ( var achevement in Achievements )
            //    {
            //        WriteLine ( string . Format ( "{0}	How To Get:{1}	Is Get:{2}" , achevement . Title , achevement . Label , achevement . IsGet ) );
            //    }
            //} ) );

            //CommandList . Add ( new Command ( "SellOrange" , new string [ ] { "so" , "sellorange" } , ( list ) =>
            //{
            //    decimal MHB,OHS;
            //    SellOrange ( Convert . ToDecimal ( list [ 1 ] ) , out MHB , out OHS );
            //    WriteLine ( string . Format ( "Have Selled {0} Orange And Get {1}" , OHS , MHB ) );
            //} ) );
            //CommandList . Add ( new Command ( "BuyBuilding" , new string [ ] { "bb" , "buybuilding" } , ( list ) =>
            //{
            //    decimal HB,HC;
            //    Buildings [ list [ 1 ] ] . Buy ( Convert . ToDecimal ( list [ 2 ] ) , out HB , out HC );
            //    WriteLine ( string . Format ( "Have Cost {0} Orange And Buy {1} {2}" , HB , HC , Buildings [ list [ 1 ] ] . Title ) );
            //} ) );
            //CommandList . Add ( new Command ( "Building" , new string [ ] { "bb" , "buybuilding" } , ( list ) =>
            //{
            //    decimal HB,HC;
            //    Buildings [ list [ 1 ] ] . Buy ( Convert . ToDecimal ( list [ 2 ] ) , out HB , out HC );
            //    WriteLine ( string . Format ( "Have Cost {0} Orange And Buy {1} {2}" , HB , HC , Buildings [ list [ 1 ] ] . Title ) );
            //} ) );
            //CommandList . Add ( new Command ( "Clear" , new string [ ] { "clr" } , ( list ) => { ConsoleTextOut = ""; } ) );
            //CommandList . Add ( new Command ( "Help" , new string [ ] { "help" } , ( list ) =>
            //{
            //    foreach ( var item in CommandList )
            //    {
            //        string temp=string . Empty;
            //        foreach ( var key in item . Keys )
            //        {
            //            temp += string . Format ( "{0}," , key );
            //        }
            //        WriteLine ( string . Format ( "{0}	Key:{1}" , item . Name , temp . TrimEnd ( ',' ) ) );
            //    }
            //} ) );
		}


	}
}
