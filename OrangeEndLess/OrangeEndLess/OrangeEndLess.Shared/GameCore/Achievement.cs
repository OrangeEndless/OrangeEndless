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
using Windows . ApplicationModel . Resources;

namespace OrangeEndLess
{
	public class Achievement
	{
		ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

		public string Title;

		public string Label;

		public int Key;

		Core GameCore;

		Func<Core,bool> FuncIsGet;

		public void Clean ( )
		{
			IsGet = false;
		}

		public bool IsGet
		{
			get
			{
				return ( bool ) GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ];
			}
			set
			{
				GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] = value;
			}
		}

		public void Check ( )
		{
			if ( IsGet != true )
			{
				IsGet = FuncIsGet . Invoke ( GameCore );
			}
		}

		public Achievement ( int key , Core gamecore , Func<Core , bool> func )
		{
			Key = key;
			ResourceLoader  Resources= ResourceLoader . GetForCurrentView ( "Resource" );
			Title = Resources . GetString ( "Achevement" + key . ToString ( ) + "Title" );
			Label = Resources . GetString ( "Achevement" + key . ToString ( ) + "Label" );
			GameCore = gamecore;
			FuncIsGet = func;
			if ( GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] == null )
			{
				GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] = false;
			}
		}
	}
}
