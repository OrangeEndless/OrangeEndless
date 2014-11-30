using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;

namespace OrangeEndLess
{
    public class GameObject
    {
        public string Title { get; set; }

        public string Label { get; set; }

        public string Key { get; set; }

        /// <summary>
        /// Return if this object can be bought now
        /// </summary>
        public Func<bool> FuncShow { get; set; }

        /// <summary>
        /// Return if this object is available now
        /// </summary>
        public Func<bool> FuncDark { get; set; }

        /// <summary>
        /// Return if this object is not available now
        /// </summary>
        public Func<bool> FuncBlack { get; set; }

        public Action DoWhenTick { get; set; }

        public Status Status
        {
            get
            {
                if ( FuncBlack ( ) )
                {
                    if ( FuncDark ( ) )
                    {
                        if ( FuncShow ( ) )
                        {
                            return Status . Active;
                        }
                        return Status . Dark;
                    }
                    return Status . Black;
                }
                return Status . Hide;
            }
        }

        protected ApplicationDataContainer GameData = ApplicationData . Current . RoamingSettings;

        public virtual void Stop ( )
        {

        }

    }
}
