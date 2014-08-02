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
    public partial class Core
    {

        DispatcherTimer TimersUpdateNumberOfOrange = new DispatcherTimer ( );

        DispatcherTimer TimersRandom = new DispatcherTimer ( );

        DispatcherTimer TimersAPM=new DispatcherTimer ( );


        void LoadTimer ( )
        {
            TimersUpdateNumberOfOrange . Interval = new TimeSpan ( 0 , 0 , 0 , 0 , Convert . ToInt32 ( GameData . Values [ "TimeToUpdateNumberOfOrange" ] ) );
            TimersUpdateNumberOfOrange . Tick += TimersUpdateNumberOfOrange_Tick;

            TimersRandom . Interval = new TimeSpan ( 0 , 0 , 0 , 1 );
            TimersRandom . Tick += TimersRandom_Tick;

            TimersAPM . Interval = new TimeSpan ( 0 , 0 , 30 );
            TimersAPM . Tick += TimersAPM_Tick;

            TimersUpdateNumberOfOrange . Start ( );
            TimersRandom . Start ( );
            TimersAPM . Start ( );
        }

    }
}
