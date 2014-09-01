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
    public sealed partial class ListButton : Button
    {
        public ListButton ( )
        {
            this . InitializeComponent ( );
        }

        public ImageSource Image { get; set; }

        public string Text { get; set; }

        private void Grid_Loaded ( object sender , RoutedEventArgs e )
        {
            TextShow . Text = Text;
            ImageShow . Source = Image;
        }
    }
}
