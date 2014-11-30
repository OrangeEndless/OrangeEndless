using MVVMSidekick . Views;
using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;
using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;
using OrangeEndLess;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OEL
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : MVVMPage
	{
		List<string> ComList=new List<string> ( );

		int Key=0;

		public MainPage ( )
		{

			this . InitializeComponent ( );
			new Core ( );
			Core . Current . CheatChanged += Current_CheatChanged;
			Core . Current . UpdateAchevements += Current_UpdateAchevements;
			Core . Current . UpdateBuildings += Current_UpdateBuildings;
			Core . Current . UpdateConsole += Current_UpdateConsole;
			Core . Current . UpdateNumberOfMoney += Current_UpdateNumberOfMoney;
			Core . Current . UpdateNumberOfOrange += Current_UpdateNumberOfOrange;
			Core . Current . Starting ( );
		}

		void Current_UpdateNumberOfOrange ( object sender , EventArgs e )
		{

		}

		void Current_UpdateNumberOfMoney ( object sender , EventArgs e )
		{

		}

		void Current_UpdateConsole ( object sender , EventArgs e )
		{
			CTC . Text = Core . Current . ConsoleTextOut;
		}

		void Current_UpdateBuildings ( object sender , EventArgs e )
		{

		}

		void Current_UpdateAchevements ( object sender , EventArgs e )
		{

		}

		void Current_CheatChanged ( object sender , EventArgs e )
		{
		}

		private void TextBox_KeyUp ( object sender , KeyRoutedEventArgs e )
		{
			if ( e . Key == Windows . System . VirtualKey . Enter )
			{
				Core . Current . Commands ( CommandTB . Text );
				ComList [ Key ] = CommandTB . Text;
				Key++;
				CommandTB . Text = "";
			}
			if ( e . Key == Windows . System . VirtualKey . Up )
			{
				if ( Key != 0 )
				{
					Key--;
					CommandTB . Text = ComList [ Key ];
				}
			}
			if ( e . Key == Windows . System . VirtualKey . Down )
			{
				Key++;
				CommandTB . Text = ComList [ Key ];

			}
		}

		private void CommandTB_TextChanged ( object sender , TextChangedEventArgs e )
		{
			ComList [ Key ] = CommandTB . Text;
		}
	}
}
