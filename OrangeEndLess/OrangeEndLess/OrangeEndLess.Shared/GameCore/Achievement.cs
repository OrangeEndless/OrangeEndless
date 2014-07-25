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

        Func<Core,bool> _Check;

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

        public void Check ( Core cor )
        {
            if ( IsGet != true )
            {
                IsGet = _Check . Invoke ( cor );
            }
        }

        public Achievement ( int key , Func<Core , bool> func )
        {
            //Title = title;
            _Check = func;
            if ( GameData . Values [ Title + "IsGet" ] == null )
            {
                GameData . Values [ Title + "IsGet" ] = false;
            }
        }
    }
}
