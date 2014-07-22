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

namespace OrangeEndLess
{
    public class Achievement
    {
        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        public string Title;
        public string Text;

        Action<Core>  CheckFunc;

        public bool IsGet
        {
            get
            {
                return ( bool ) GameData . Values [ Title + "IsGet" ];
            }
            set
            {
                GameData . Values [ Title + "IsGet" ] = value;
            }
        }

        public void Get ( )
        {
            IsGet = true;
        }

        public Achievement ( string title , string text , Action<Core> func )
        {
            Title = title;
            Text = text;
            CheckFunc = func;
        }
    }
}
