using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Reflection;
using System . Runtime . CompilerServices;
using System . Runtime . InteropServices;
using System . Timers;
using System . IO;

namespace OrangeEndlessCore
{
    class ModLoader
    {
        public static List<Mod> Load ( DirectoryInfo rootdirectory )
        {
            List<Mod> ListOfMod=new List<Mod> ( );

            var directorys= rootdirectory . GetDirectories ( );

            var files=rootdirectory . GetFiles ( @"*.dll" );
            foreach ( var fil in files )
            {
                var types= ( Assembly . LoadFile ( fil . FullName ) ) . GetTypes ( );
                foreach ( var typ in types )
                {
                    ListOfMod . Add ( new Mod
                    {
                        Start = ( ) => { typ . InvokeMember ( "Start" , BindingFlags . Static , Type . DefaultBinder , Core . Current , new object [ ] { Core . Current } ); } ,
                        Stop = ( ) => { typ . InvokeMember ( "Stop" , BindingFlags . Static , Type . DefaultBinder , Core . Current , new object [ ] { } ); } ,
                        Name = ( string ) typ . InvokeMember ( "Name" , BindingFlags . Static , Type . DefaultBinder , Core . Current , new object [ ] { } ) ,
                        Author = ( string ) typ . InvokeMember ( "Author" , BindingFlags . Static , Type . DefaultBinder , Core . Current , new object [ ] { } ) ,
                        Introduction = ( string ) typ . InvokeMember ( "Intruduction" , BindingFlags . Static , Type . DefaultBinder , Core . Current , new object [ ] { } )
                    } );

                }
            }
            return ListOfMod;
        }
    }
}
