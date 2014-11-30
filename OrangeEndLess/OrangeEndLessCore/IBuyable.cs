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
    public interface IBuyable : GameObject
    {
        Func<bool> CanBuy { get; set; }

        TimeSpan TimeToBuy { get; set; }

        /// <summary>
        /// The affect 
        /// </summary>
        Action AffectToBuy { get; set; }

        /// <summary>
        /// Buy this object now
        /// </summary>
        void Buy ( );
       // {
            //DispatcherTimer Timer=new DispatcherTimer ( );
            //Timer . Interval = TimeToBuy;
            //Timer . Tick += ( sender , e ) => { AffectToBuy ( ); Timer . Stop ( ); };
            //Timer . Start ( );
        //}
    }


}
