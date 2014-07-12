using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using OrangeEndLess;
using OrangeEndLess.ViewModels;
using System;
using System.Net;
using System.Windows;


namespace MVVMSidekick.Startups
{
    public static partial class StartupFunctions
    {
        static Action AboutConfig =
            CreateAndAddToAllConfig(ConfigAbout);

        public static void ConfigAbout()
        {
            ViewModelLocator<About_Model>
                .Instance
                .Register(context =>
                    new About_Model())
                .GetViewMapper()
                .MapToDefault<About>();

        }
    }
}
