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
	public class Building
	{
		Random Randoms = new Random ( );

		ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

		Func<Core,bool> FuncBlack;

		Func<Core,bool> FuncShow;

		public string Title;

		public string Key;

		decimal PriceBase;

		decimal StartCPS;

		public string Label;

		public Status Status
		{
			get
			{
				if ( FuncShow ( Core . Current ) && FuncBlack ( Core . Current ) && Core . Current . NumberOfMoney >= Price )
				{
					return Status . Active;
				}
				if ( FuncShow ( Core . Current ) && FuncBlack ( Core . Current ) && Core . Current . NumberOfMoney < Price )
				{
					return Status . Dark;
				}
				if ( FuncBlack ( Core . Current ) && ( FuncShow ( Core . Current ) == false ) )
				{
					return Status . Black;
				}
				return Status . Hide;
			}
		}

		public void Clean ( )
		{
			GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Key ] = GameData . Values [ "NumberOf" + Key ] = GameData . Values [ "LevelOf" + Key ] = 0;
		}

		public decimal NumberOfOrangeHaveMade
		{
			get
			{
				return Convert . ToDecimal ( GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Key ] );
			}
			set
			{
				GameData . Values [ "NumberOfOrangeHaveMadeFrom" + Key ] = value . ToString ( );
			}
		}

		public decimal AllCPS
		{
			get
			{
				return Number * StartCPS;
			}
		}

		public decimal CPS
		{
			get
			{
				return StartCPS;
			}
		}

		public decimal Number
		{
			get
			{
				return Convert . ToDecimal ( GameData . Values [ "NumberOf" + Key ] );
			}
			set
			{
				GameData . Values [ "NumberOf" + Key ] = value . ToString ( );
			}
		}

		//public decimal Level
		//{
		//	get
		//	{
		//		return Convert . ToDecimal ( GameData . Values [ "LevelOf" + Key ] ) + 1;
		//	}
		//	set
		//	{
		//		GameData . Values [ "LevelOf" + Key ] = ( value - 1 ) . ToString ( );
		//	}
		//}

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
			while ( Core . Current . NumberOfMoney >= Price )
			{
				_havecost += Price;
				_havebuy++;
			}
			Core . Current . NumberOfMoney -= _havecost;
			Number += _havebuy;
			havebuy = _havebuy;
			havecost = _havecost;
			Core . Current . UpdateBuildingsFromBuilding ( this );
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
			Core . Current . NumberOfMoney += _haveget;
			Number -= _havesell;
			havesell = _havesell;
			haveget = _haveget;
			Core . Current . UpdateBuildingsFromBuilding ( this );
		}


		/// <summary>
		/// 创建一个建筑
		/// </summary>
		/// <param name="key">建筑的标识</param>
		/// <param name="startprice">价格的初始值</param>
		/// <param name="startcps"></param>
		/// <param name="funcshow">判断建筑是否显示详细信息</param>
		/// <param name="funcdark">判断建筑是否显示轮廓</param>
		public Building ( string key , decimal startprice , decimal startcps , Func<Core , bool> funcshow , Func<Core , bool> funcdark )
		{
			Key = key;
			ResourceLoader  Resources= ResourceLoader . GetForCurrentView ( "BuildingsResources" );
			Title = Resources . GetString ( "TitleOf" + Key );
			Label = Resources . GetString ( "LabelOf" + Key );
			PriceBase = startprice;
			StartCPS = startcps;
			FuncShow = funcshow;
			FuncBlack = funcdark;
			if ( GameData . Values [ "LevelOf" + Key ] == null )
			{
				GameData . Values [ "LevelOf" + Key ] = 0;
			}
			if ( GameData . Values [ "NumberOf" + Key ] == null )
			{
				GameData . Values [ "NumberOf" + Key ] = 0;
			}
		}
	}


}
