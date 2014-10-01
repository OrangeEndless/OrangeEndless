using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;

namespace OrangeEndLess
{
    public partial class Core
    {
        public List<Achievement>Achievements=new List<Achievement> ( );

        void LoadAchievements ( )
        {
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 10000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 100000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 10000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 100000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 100000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 1000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveGet >= 10000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 10 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 10000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 1000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 100000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . SpeedOfOrangeRise >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 1000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 100000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 10000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 1000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 100000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfOrangeHaveMadeFromRush >= 1000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 2 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 300 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . Number >= 400 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Cursor" ] . NumberOfOrangeHaveMade >= 1000000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . Number >= 250 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Primary" ] . NumberOfOrangeHaveMade >= 1000000000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Farm" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Factory" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Mine" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Shipment" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Lab" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Portal" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "TimeMachine" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "DreamReCore.Currentder" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . Number >= 1 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . Number >= 50 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . Number >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . Number >= 150 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . Number >= 200 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . Buildings [ "Prism" ] . NumberOfOrangeHaveMade >= 10000000000000 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfBuilding >= 100 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfBuilding >= 400 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfBuilding >= 800 ) );
            Achievements . Add ( new Achievement ( Achievements . Count + 1 , ( ) => Core . Current . NumberOfBuilding >= 1500 ) );
            //Achievements . Add ( new Achievement ( Achievements . Count + 1  , (  ) => Core.Current . NumberOfUpdateHavePromote >= 1 ) );
            //Achievements . Add ( new Achievement ( Achievements . Count + 1  , (  ) => Core.Current . NumberOfUpdateHavePromote >= 20 ) );
            //Achievements . Add ( new Achievement ( Achievements . Count + 1  , (  ) => Core.Current . NumberOfUpdateHavePromote >= 50 ) );
            //Achievements . Add ( new Achievement ( Achievements . Count + 1  , (  ) => Core.Current . NumberOfUpdateHavePromote >= 100 ) );
            //Achievements . Add ( new Achievement ( Achievements . Count + 1  , (  ) => Core.Current . NumberOfUpdateHavePromote >= 150 ) );





        }


    }
}
