using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Reflection;
using System . Runtime . CompilerServices;
using System . Runtime . InteropServices;
using System . Timers;

namespace OrangeEndlessCore
{
	public class Core
	{
		public static  Core Current;

		public Timer Ticks=new Timer ( 1000 );

		public List<Mod> Mods;

		public Core ( )
		{
			//ModLoader.Load()
		}

		public void Start ( )
		{
			foreach ( var item in Mods )
			{
				item . Start ( );
			}
		}

		public void Stop ( )
		{


		}
	}
}
