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
    class Update
    {
        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        Core GameCore;

        Action<Core> Do;

        Action<Core> a;

        Func<Core,bool> CanPromote;

        Func<Core,bool> FuncDark;

        Func<Core,bool> FuncShow;

        public string Title;

        public string Lebel;

        public string Text;

        public Status Status
        {
            get
            {
                if ( FuncShow ( GameCore ) )
                {
                    return Status . Show;
                }
                if ( FuncDark ( GameCore ) )
                {
                    return Status . Dark;
                }
                return Status . Hide;
            }
        }

        public bool IsPromoted
        {
            get
            {
                return ( bool ) GameData . Values [ Lebel + "IsPromoted" ];
            }
            set
            {
                GameData . Values [ Lebel + "IsPromoted" ] = value;
            }
        }

        public void Promote()
        {
            
        }

    }
}
