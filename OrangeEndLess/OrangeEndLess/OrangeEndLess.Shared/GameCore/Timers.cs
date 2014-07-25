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
    class Core
    {
        public  Dictionary <string,DispatcherTimer> Timers;

        void LoadTimer ( )
        {
            DispatcherTimer TimersUpdateData = new DispatcherTimer ( );

            DispatcherTimer TimersRandom = new DispatcherTimer ( );

            DispatcherTimer TimersAPM=new DispatcherTimer ( );

            TimersUpdateData . Interval = new TimeSpan ( 0 , 0 , 0 , 0 , Convert . ToInt32 ( GameData . Values [ "TimeToUpdate" ] ) );
            TimersUpdateData . Tick += TimersUpdateData_Tick;

            TimersRandom . Interval = new TimeSpan ( 0 , 0 , 0 , 1 );
            TimersRandom . Tick += TimersRandom_Tick;

            TimersAPM . Interval = new TimeSpan ( 0 , 0 , 30 );
            TimersAPM . Tick += TimersAPM_Tick;

            TimersUpdateData . Start ( );
            TimersRandom . Start ( );
            TimersAPM . Start ( );


            Timers . Add ( "UpdateData" , TimersUpdateData );
            Timers . Add ( "Random" , TimersRandom );
            Timers . Add ( "APM" , TimersAPM );
        }
    }
}
