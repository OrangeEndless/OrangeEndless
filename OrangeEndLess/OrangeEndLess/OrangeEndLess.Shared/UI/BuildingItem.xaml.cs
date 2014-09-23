using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace OrangeEndLess
{
    public sealed partial class BuildingItem : UserControl
    {
        public BuildingItem()
        {
            this.InitializeComponent();
        }

        Building BuildingSource;

        public string Key { get; set; }

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
                if (IsChecked)
                {
                    VisualStateManager.GoToState(this, "Checked", false);
                //    if (TheControls != null)
                //    {
                //        foreach (var item in TheControls)
                //        {
                //            item.Visibility = Visibility.Visible;
                //        }
                //    }
                //    ImageLL.Source = ImageBlack;
                //}
                //else
                //{
                //    VisualStateManager.GoToState(this, "Unchecked", false);
                //    if (TheControls != null)
                //    {
                //        foreach (var item in TheControls)
                //        {
                //            item.Visibility = Visibility.Collapsed;
                //        }
                //    }
                //    ImageLL.Source = ImageWhite;
                }
            }
        }

        private void UserControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!IsChecked)
            {
                IsChecked = true;
            }
        }
    }
}
