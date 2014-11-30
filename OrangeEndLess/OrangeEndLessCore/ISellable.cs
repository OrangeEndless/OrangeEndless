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
   public interface ISellable : GameObject
    {
       Func<bool> CanSell { get; set; }

       TimeSpan TimeToSell { get; set; }

        /// <summary>
        /// The affect 
        /// </summary>
       Action AffectToSell { get; set; }

        /// <summary>
        /// Buy this object now
        /// </summary>
        /// <param name="number"></param>
        /// <param name="havesell"></param>
       void Sell ( );
        //{
            //DispatcherTimer Timer=new DispatcherTimer ( );
            //Timer . Interval = TimeToSell;
            //Timer . Tick += ( sender , e ) => { AffectToSell ( ); Timer . Stop ( ); };
            //Timer . Start ( );
        //}

    }
}
