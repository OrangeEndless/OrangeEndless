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
        public Dictionary<string, Building> Buildings = new Dictionary<string , Building> ( );

        public void UpdateBuildingsFromBuilding ( object Obj )
        {
            UpdateBuildings ( Obj , new EventArgs ( ) );
        }

        /// <summary>
        /// 加载建筑们
        /// </summary>
        void LoadBuildings ( )
        {
            Buildings . Add ( "Cursor" , new Building ( "Cursor" , 1m , 0.1m , this , ( Core cor ) => { return true;/*return cor . NumberOfOrangeHaveGet >= 1 && cor . Technologys [ "Store" ] . IsPromoted;*/ } , ( Core cor ) => { return true;/*return cor . NumberOfMoneyHaveGet >= 1; */} ) );
            Buildings . Add ( "Primary" , new Building ( "Primary" , 10m , 0.5m , this , ( Core cor ) => { return true;/*return cor . Technologys [ "Primary" ] . IsPromoted;*/ } , ( Core cor ) => { return true; /*return cor . Buildings [ "Cursor" ] . NumberOfOrangeHaveMade >= 1; */} ) );
            Buildings . Add ( "Farm" , new Building ( "Farm" , 100m , 4m , this , ( Core cor ) => { return true; /*return cor . Technologys [ "Farm" ] . IsPromoted; */} , ( Core cor ) => { return true; /*return cor . Buildings [ "Primary" ] . NumberOfOrangeHaveMade >= 1;*/ } ) );
            Buildings . Add ( "Factory" , new Building ( "Factory" , 300m , 10m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "Mine" , new Building ( "Mine" , 1400m , 40m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "Shipment" , new Building ( "Shipment" , 4000m , 100m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "Lab" , new Building ( "Lab" , 20000m , 400m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "Portal" , new Building ( "Portal" , 480000m , 6000m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "TimeMachine" , new Building ( "TimeMachine" , 12000000m , 100000m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "DreamRecorder" , new Building ( "DreamRecorder" , 180000000m , 1000000m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
            Buildings . Add ( "Prism" , new Building ( "Prism" , 20000000000m , 100000000m , this , ( Core cor ) => { return true; } , ( Core cor ) => { return true; } ) );
        }
    }
}
