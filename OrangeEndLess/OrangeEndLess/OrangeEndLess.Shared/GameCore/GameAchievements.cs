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
            Achievements . Add ( new Achievement ( "" , "" , ( Core cor ) => cor . NumberOfOrangeHaveGet >= 1 ) );

        }


    }
}
