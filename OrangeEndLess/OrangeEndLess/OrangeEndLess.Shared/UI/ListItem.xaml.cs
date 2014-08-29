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

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace OrangeEndLess
{
	public sealed partial class ListItem : UserControl
	{

		public List<UIElement> TheControls =new List<UIElement> ( );

		public ListItem ( )
		{
			this . InitializeComponent ( );
		}

		public bool IsDefault { get; set; }

		bool _IsChecked;

		public bool IsChecked
		{
			get
			{
				return _IsChecked;
			}
			set
			{
				_IsChecked = value;
				if ( IsChecked )
				{
					VisualStateManager . GoToState ( this , "Checked" , false );
					if ( TheControls != null )
					{
						foreach ( var item in TheControls )
						{
							item . Visibility = Visibility . Visible;
						}
					}
					ImageLL . Source = ImageBlack;
				}
				else
				{
					VisualStateManager . GoToState ( this , "Unchecked" , false );
					if ( TheControls != null )
					{
						foreach ( var item in TheControls )
						{
							item . Visibility = Visibility . Collapsed;
						}
					}
					ImageLL . Source = ImageWhite;
				}
			}
		}

		private string _Text1;

		public string Text1
		{
			get { return _Text1; }
			set
			{
				_Text1 = value;
				TextBlock1 . Text = Text1;
			}
		}

		private string _Text2;

		public string Text2
		{
			get { return _Text2; }
			set
			{
				_Text2 = value;
				TextBlock2 . Text = Text2;
			}
		}

		public Windows . UI . Xaml . Media . ImageSource ImageBlack { get; set; }
		public Windows . UI . Xaml . Media . ImageSource ImageWhite { get; set; }

		private void UserControl_PointerEntered ( object sender , PointerRoutedEventArgs e )
		{
			if ( IsChecked )
			{
				VisualStateManager . GoToState ( this , "Checked" , false );
				ImageLL . Source = ImageBlack;
			}
			else
			{
				VisualStateManager . GoToState ( this , "UncheckedPointerOver" , false );
				ImageLL . Source = ImageWhite;
			}
		}

		private void UserControl_PointerExited ( object sender , PointerRoutedEventArgs e )
		{
			if ( IsChecked )
			{
				VisualStateManager . GoToState ( this , "Checked" , false );
				ImageLL . Source = ImageBlack;
			}
			else
			{
				VisualStateManager . GoToState ( this , "Unchecked" , false );
				ImageLL . Source = ImageWhite;
			}
		}

		private void UserControl_Tapped ( object sender , TappedRoutedEventArgs e )
		{
		}

		private void Grid_Loaded ( object sender , RoutedEventArgs e )
		{
			if ( IsChecked )
			{
				VisualStateManager . GoToState ( this , "Checked" , false );
				ImageLL . Source = ImageBlack;
			}
			else
			{
				VisualStateManager . GoToState ( this , "Unchecked" , false );
				ImageLL . Source = ImageWhite;
			}
		}


	}
}
