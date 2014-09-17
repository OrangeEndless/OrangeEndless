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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace OrangeEndLess
{
	/// <summary>
	/// 初始动画
	/// </summary>
	public sealed partial class StartPage : Page
	{
		public StartPage ( )
		{
			this . InitializeComponent ( );
		}

		private void AnimationGrid_Loaded ( object sender , RoutedEventArgs e )
		{
			ScaleTransform Transforms= new ScaleTransform ( );
			DispatcherTimer TimerChange=new DispatcherTimer ( );
			TimerChange . Interval = new TimeSpan ( 0 , 0 , 30 );
			TimerChange . Tick += TimerChange_Tick;
			Transforms . ScaleX = Transforms . ScaleY = Math . Min ( MainGrid . ActualHeight / AnimationGrid . ActualHeight , MainGrid . ActualWidth / AnimationGrid . ActualWidth );
			Transforms . CenterX = Transforms . CenterY = 0.5;
			AnimationGrid . RenderTransform = Transforms;
			AnimationGrid . Margin = new Thickness ( ( MainGrid . ActualWidth - ( AnimationGrid . ActualWidth * Transforms . ScaleX ) ) / 2 , ( MainGrid . ActualHeight - ( AnimationGrid . ActualHeight * Transforms . ScaleY ) ) / 2 , ( MainGrid . ActualWidth - ( AnimationGrid . ActualWidth * Transforms . ScaleX ) ) / 2 , ( MainGrid . ActualHeight - ( AnimationGrid . ActualHeight * Transforms . ScaleY ) ) / 2 );
			VisualStateManager . GoToState ( this , "Starting" , false );
			TimerChange . Start ( );
		}

		void TimerChange_Tick ( object sender , object e )
		{
			this . Frame . Navigate ( typeof ( MainPage ) );
		}


	}
}
