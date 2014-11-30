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
        string Title { get; set; }

        string Label { get; set; }

        string Key { get; set; }

        decimal Number { get; set; }
        /// <summary>
        /// Return if this object can be bought now
        /// </summary>
        Func<bool> FuncShow { get; set; }

        /// <summary>
        /// Return if this object is available now
        /// </summary>
        Func<bool> FuncDark { get; set; }

        /// <summary>
        /// Return if this object is not available now
        /// </summary>
        Func<bool> FuncBlack { get; set; }

        Status Status
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

        void Stop ( )
        {

        }
    }
}
