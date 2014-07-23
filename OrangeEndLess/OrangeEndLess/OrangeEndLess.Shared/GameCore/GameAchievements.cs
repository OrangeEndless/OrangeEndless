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
        public List<Achievement>Achievements=new List<Achievement> ( );

        void AddAchievements ( )
        {
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 10000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 100000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 10000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 100000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 100000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 10000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 10 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 10000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 1000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 100000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . SpeedOfOrangeRise >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings[ ) );




        }


    }
}
