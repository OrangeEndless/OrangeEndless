//using System;
//using System . Collections . Generic;
//using System . Text;
//using System . Threading;
//using System . Threading . Tasks;
//using Windows . Storage;
//using Windows . UI . Xaml;
//using Windows . UI . Xaml . Controls;
//using Windows . UI . Xaml . Input;
//using MVVMSidekick . ViewModels;

//namespace OrangeEndLess
//{
//    public class Technology
//    {
//        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

//        Action<Core> ActionBeforePromote;

//        Action<Core> ActionAfterPromote;

//        Func<Core,bool> CanPromote;

//        Func<Core,bool> FuncBlack;

//        Func<Core,bool> FuncShow;

//        public TimeSpan TimeToResearch;

//        DispatcherTimer TimerResearch;

//        public string Title;

//        public string Lebel;

//        public string Text;

//        public Status Status
//        {
//            get
//            {
//                if ( FuncShow ( GameCore ) && FuncBlack ( GameCore ) && CanPromote ( GameCore ) )
//                {
//                    return Status . Active;
//                }
//                if ( FuncShow ( GameCore ) && FuncBlack ( GameCore ) && ( CanPromote ( GameCore ) == false ) )
//                {
//                    return Status . Dark;
//                }
//                if ( FuncBlack ( GameCore ) && ( FuncShow ( GameCore ) == false ) )
//                {
//                    return Status . Black;
//                }
//                return Status . Hide;
//            }
//        }

//        public bool IsPromoted
//        {
//            get
//            {
//                return ( bool ) GameData . Values [ Lebel + "IsPromoted" ];
//            }
//            set
//            {
//                GameData . Values [ Lebel + "IsPromoted" ] = value;
//            }
//        }

//        public void Promote ( )
//        {
//            if ( CanPromote ( GameCore ) )
//            {
//                ActionBeforePromote ( GameCore );
//                TimerResearch . Start ( );
//                ActionAfterPromote ( GameCore );
//            }
//        }

//        public Technology ( )
//        {
//            if ( GameData . Values [ Lebel + "IsPromoted" ] == null )
//            {
//                GameData . Values [ Lebel + "IsPromoted" ] = false;
//            }
//            TimerResearch . Interval = TimeToResearch;
//            TimerResearch . Tick += TimerResearch_Tick;
//        }

//        void TimerResearch_Tick ( object sender , object e )
//        {
//            IsPromoted = true;
//            TimerResearch . Stop ( );
//        }
//    }
//}
