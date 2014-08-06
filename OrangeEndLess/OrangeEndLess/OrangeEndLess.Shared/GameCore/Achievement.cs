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

        public string Lebel;

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
                return ( bool ) GameData . Values [ Lebel + "IsGet" ];
            }
            set
            {
                GameData . Values [ Lebel + "IsGet" ] = value;
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
            //Title = title;
            GameCore = gamecore;
            FuncIsGet = func;
            if ( GameData . Values [ Lebel + "IsGet" ] == null )
            {
                GameData . Values [ Lebel + "IsGet" ] = false;
            }
        }
    }
}
