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

        void LoadBuildings ( )
        {
            Buildings . Add ( "Cursor" , new Building ( "Cursor" , 1m , 0.1m ) );
            Buildings . Add ( "Primary" , new Building ( "Primary" , 10m , 0.5m ) );
            Buildings . Add ( "Farm" , new Building ( "Farm" , 100m , 4m ) );
            Buildings . Add ( "Factory" , new Building ( "Factory" , 300m , 10m ) );
            Buildings . Add ( "Mine" , new Building ( "Mine" , 1400m , 40m ) );
            Buildings . Add ( "Shipment" , new Building ( "Shipment" , 4000m , 100m ) );
            Buildings . Add ( "Lab" , new Building ( "Lab" , 20000m , 400m ) );
            Buildings . Add ( "Portal" , new Building ( "Portal" , 480000m , 6000m ) );
            Buildings . Add ( "TimeMachine" , new Building ( "TimeMachine" , 12000000m , 100000m ) );
            Buildings . Add ( "DreamRecorder" , new Building ( "DreamRecorder" , 180000000m , 1000000m ) );
            Buildings . Add ( "Prism" , new Building ( "Prism" , 20000000000m , 100000000m ) );
        }
    }
}
