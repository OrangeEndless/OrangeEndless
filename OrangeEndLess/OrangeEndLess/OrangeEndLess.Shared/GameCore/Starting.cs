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
        void Starting ( )
        {
            LoadBuildings ( );
            LoadAchievements ( );
            LoadRandomEvents ( );
        }

        void Setup ( )
        {
            GameData . Values [ "TimeToUpdate" ] = 200;
            GameData . Values [ "LevelOfRush" ] = 0;
            GameData . Values [ "BestAPM" ] = 0;
            GameData . Values [ "Money" ] = 0;
            GameData . Values [ "NumberOfOrange" ] = 0;
            GameData . Values [ "LevelOfRush" ] = 0;
            GameData . Values [ "NumberOfOrangeHaveMadeFromRush" ] = 0;
            GameData . Values [ "NumberOfMoneyHaveGet" ] = 0;
            GameData . Values [ "NumberOfOrangeHaveGet" ] = 0;
            GameData . Values [ "NumberOfUpdateHavePromote" ] = 0;
            GameData . Values [ "GameIsStartV2" ] = true;
            foreach ( var item in Buildings )
            {
                item . Value . Clean ( );
            }
            foreach ( var item in Achievements )
            {
                item . Clean ( );
            }
            foreach ( var item in RandomEvents )
            {
                item . Value . Clean ( );
            }
        }

    }
}
