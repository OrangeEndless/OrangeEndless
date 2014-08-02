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
    public class RandomEvent
    {
        ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        public  Action<Core> Event;

        public int Probability;

        public void Clean ( )
        {
            TimesHaveCalled = 0;
        }

        public decimal TimesHaveCalled
        {
            get
            {
                return Convert . ToDecimal ( GameData . Values [ "TimesHaveCalled" + Title ] );
            }
            set
            {
                GameData . Values [ "TimesHaveCalled" + Title ] = value . ToString ( );
            }
        }

        public string Title;

        public string Text;

        public RandomEvent ( int key , Action<Core> func )
        {
            Event = func;
        }

    }
}
