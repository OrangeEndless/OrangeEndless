using System;
using System . Collections . Generic;
using System . Text;

namespace OrangeEndLess
{
    class RandomArgs : EventArgs
    {
        public string Title;
        public string Text;

        public RandomArgs ( string _Title , string _Text )
        {
            Title = _Title;
            Text = _Text;
        }

    }
}
