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
        public  Action<Core> Event;

        public int Probability;

        public string Title;

        public string Text;

        public RandomEvent ( int key , Action<Core> func )
        {
            Event = func;

        }

    }
}
