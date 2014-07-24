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
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 100000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfOrangeHaveMadeFromRush >= 1000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 2 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 300 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . Number >= 400 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Cursor" ] . NumberOfOrangeHaveMade >= 1000000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 2 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . Number >= 250 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Primary" ] . NumberOfOrangeHaveMade >= 1000000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Farm" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Factory" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Mine" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Shipment" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Lab" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Portal" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "TimeMachine" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "DreamRecorder" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . Buildings [ "Prism" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfBuilding >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfBuilding >= 400 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfBuilding >= 800 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( Core cor ) => cor . NumberOfBuilding >= 1500 ) );





        }


    }
}
