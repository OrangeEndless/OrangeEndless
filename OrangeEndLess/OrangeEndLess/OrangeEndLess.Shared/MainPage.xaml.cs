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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OrangeEndLess
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : MVVMPage
	{
		public MainPage ( )
		{
			this . InitializeComponent ( );
#if DEBUG
#endif
		}

		private void ListItem_Tapped ( object sender , TappedRoutedEventArgs e )
		{
			foreach ( ListItem item in List . Items )
			{
				item . IsChecked = false;
			}
			( ( ListItem ) sender ) . IsChecked = true;
		}

		private void MainGird_Loaded ( object sender , RoutedEventArgs e )
		{
			LIOverView . TheControls . Add ( GridOverView );
			LIOverView . TheControls . Add ( SPOverView );

			LIProduce . TheControls . Add ( GridProduce );
			LIStore . TheControls . Add ( GridStore );
			LIAchievement . TheControls . Add ( GridAchievement );
			LIConsole . TheControls . Add ( GridConsole );
			LISetting . TheControls . Add ( GridSetting );
		}

		private void TBCommand_KeyUp ( object sender , KeyRoutedEventArgs e )
		{
		}
	}
}
