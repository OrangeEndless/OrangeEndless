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
	public class Achievement
	{
		ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

		//		Func<Core,bool> FuncDark;

		public string Title;

		public string Label;

		public int Key;

		Func<bool> FuncIsGet;

		public void Clean ( )
		{
			IsGet = false;
		}

		public Status Status
		{
			get
			{
				if ( IsGet )
				{
					return Status . Active;
				}
				else
				{
					return Status . Dark;
				}
			}
		}


		public bool IsGet
		{
			get
			{
				if ( ( bool ) GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] )
				{
					return true;
				}
				else
				{
					if ( IsGet = FuncIsGet ( ) )
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			set
			{
				GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] = value;
			}
		}

		public void Check ( )
		{
			if ( !IsGet )
			{
				IsGet = FuncIsGet ( );

			}
		}

		public Achievement ( int key , Func<bool> func )
		{
			Key = key;
			ResourceLoader  Resources= ResourceLoader . GetForCurrentView ( "AchievementsResource" );
			Title = Resources . GetString ( "Achevement" + key . ToString ( ) + "Title" );
			Label = Resources . GetString ( "Achevement" + key . ToString ( ) + "Label" );
			FuncIsGet = func;
			if ( GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] == null )
			{
				GameData . Values [ "Achevement" + Key . ToString ( ) + "IsGet" ] = false;
			}
		}
	}
}
