using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace OrangeEndlessCore
{
	public class ModBase
	{
		public static void Start ( Core current ) { }

		public static void Stop ( ) { }

		public static string Name ( )
		{

			return string . Empty;

		}

		public static string Author ( )
		{


			return string . Empty;

		}

		public static string Introduction ( )
		{

			return string . Empty;

		}
	}

	public class Mod
	{
		public Action Start;

		public Action Stop;

		public string Name;

		public string Author;

		public string Introduction;

		public bool Available;
	}
}

