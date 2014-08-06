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

        void TimersUpdateNumberOfOrange_Tick ( object sender , object e )
        {
            NumberOfOrange += ( decimal ) ( SpeedOfOrangeRise * ( decimal ) ( TimersUpdateNumberOfOrange . Interval . TotalMilliseconds / 1000 ) );
        }

        void TimersRandom_Tick ( object sender , object e )
        {
            int Ran=Randoms . Next ( 0 , 100000 );
            int _Loop=0;
            foreach ( var item in RandomEvents )
            {
                if ( Ran >= _Loop && Ran < _Loop + item . Value . Probability )
                {
                    item . Value . Event ( this );
                    RandomEvent ( this , new RandomArgs ( item . Value . Title , item . Value . Text ) );
                    return;
                }
            }
        }

        void TimersUpdateAchevement_Tick ( object sender , object e )
        {
            foreach ( var item in Achievements )
            {
                item . Check ( );
            }
            UpdateAchevements ( this , new EventArgs ( ) );
        }

        void TimersUpdateBuilding_Tick ( object sender , object e )
        {
            UpdateBuildings ( this , new EventArgs ( ) );
        }

        void TimersAPM_Tick ( object sender , object e )
        {
            TimersRandom . Interval = new TimeSpan ( 0 , 0 , 0 , 0 , Convert . ToInt32 ( 60 / ( ( _APM * 1000 ) + 1 ) ) );
            GameData . Values [ "BestAPM" ] = Math . Max ( ( ( long ) GameData . Values [ "BestAPM" ] ) , _APM );
            _APM = 0;
        }

    }
}
