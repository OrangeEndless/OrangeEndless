using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using Windows . Storage;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Input;

namespace OrangeEndLess
{
    public class Technology : Buyable
    {
        public bool IsPromoted { get; set; }

        public Technology ( )
        {
            if ( GameData . Values [ Label + "IsPromoted" ] == null )
            {
                GameData . Values [ Label + "IsPromoted" ] = false;
            }
            IsPromoted = ( bool ) GameData . Values [ Label + "IsPromoted" ];
        }

        public void Stop ( )
        {
            GameData . Values [ Label + "IsPromoted" ] = IsPromoted;
        }
    }
}
