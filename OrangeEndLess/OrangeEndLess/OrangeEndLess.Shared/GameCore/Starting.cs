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
            //LoadTechnologys ( );
            LoadBuildings ( );
            LoadAchievements ( );
            LoadRandomEvents ( );
            LoadTimer ( );
        }

        void Setup ( )
        {
            GameData . Values [ "LevelOfRush" ] = 0;
            GameData . Values [ "BestAPM" ] = 0L;
            GameData . Values [ "NumberOfOrange" ] = 0m . ToString ( );
            GameData . Values [ "Money" ] = 0m . ToString ( );
            GameData . Values [ "LevelOfRush" ] = 0;
            GameData . Values [ "ButtonRushTip" ] = 0;
            GameData . Values [ "NumberOfMoneyHaveGet" ] = 0;
            GameData . Values [ "NumberOfOrangeHaveGet" ] = 0;
            GameData . Values [ "NumberOfUpdateHavePromote" ] = 0;
            GameData . Values [ "TimeToUpdateNumberOfOrange" ] = 20;
            GameData . Values [ "TimeToUpdateAchevement" ] = 5000;
            GameData . Values [ "TimeToUpdateBuilding" ] = 10000;
            GameData . Values [ "LastShutdown" ] = Convert . ToString ( DateTime . Now );


            foreach ( var item in Buildings )
            {
                item . Value . Clean ( );
            }
            foreach ( var item in Achievements )
            {
                item . Clean ( );
            }
			//foreach ( var item in RandomEvents )
			//{
			//	item . Value . Clean ( );
			//}
            GameData . Values [ "GameIsStartV2" ] = true;
        }
    }
}
