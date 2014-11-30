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
    public class Buyable : GameObject
    {
        public Func<bool> CanBuy { get; set; }

        public TimeSpan TimeToBuy { get; set; }

        /// <summary>
        /// The affect 
        /// </summary>
        public Action AffectToBuy { get; set; }

        /// <summary>
        /// Buy this object now
        /// </summary>
        public void Buy ( )
        {
            DispatcherTimer Timer=new DispatcherTimer ( );
            Timer . Interval = TimeToBuy;
            Timer . Tick += ( sender , e ) => { AffectToBuy ( ); Timer . Stop ( ); };
            Timer . Start ( );
        }
    }


}
