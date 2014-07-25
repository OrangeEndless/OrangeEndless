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
    class RandomEvent
    {
        public  Action<Core> Event;

        public long Posibleiaty;

        public string Title;

        public string Text;

        public RandomEvent ( int key , Action<Core> func )
        {
            Event = func;

        }

    }
}
