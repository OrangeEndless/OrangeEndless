using System . Reactive;
using System . Reactive . Linq;
using MVVMSidekick . ViewModels;
using MVVMSidekick . Views;
using MVVMSidekick . Reactive;
using MVVMSidekick . Services;
using MVVMSidekick . Commands;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Collections . ObjectModel;
using System . Runtime . Serialization;
using Windows . Storage;
using MVVMSidekick . Utilities;
using Windows . UI . Xaml;
using OrangeEndLess;


namespace OrangeEndLess . ViewModels
{

    [DataContract]
    public class MainPage_Model : ViewModelBase<MainPage_Model>
    {
        public Core GameCore = new Core ( );

        ApplicationDataContainer localSettings = ApplicationData . Current . RoamingSettings;


        public MainPage_Model ( )
        {
            GameCore . RandomEvent += GameCore_RandomEvent;
            GameCore . UpdateAchevements += GameCore_UpdateAchevements;
            GameCore . UpdateBuildings += GameCore_UpdateBuildings;
            GameCore . UpdateNumberOfMoney += GameCore_UpdateNumberOfMoney;
            GameCore . UpdateNumberOfOrange += GameCore_UpdateNumberOfOrange;
        }

        void GameCore_UpdateNumberOfOrange ( object sender , EventArgs e )
        {
            NumberOfOrange = decimal . Floor ( GameCore . NumberOfOrange ) . ToString ( );
            NumberOfOrangeHaveGet = string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );

            NumberOfOrangeHaveMadeFromRush = decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( );
        }

        void GameCore_UpdateNumberOfMoney ( object sender , EventArgs e )
        {

        }

        void GameCore_UpdateBuildings ( object sender , EventArgs e )
        {

        }

        void GameCore_UpdateAchevements ( object sender , EventArgs e )
        {

        }

        void GameCore_RandomEvent ( object sender , RandomArgs e )
        {

        }

        public CommandModel<ReactiveCommand , String> CommandRush
        {
            get { return _CommandRushLocator ( this ) . Value; }
            set { _CommandRushLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandRush Setup
        protected Property<CommandModel<ReactiveCommand, String>> _CommandRush = new Property<CommandModel<ReactiveCommand , String>> { LocatorFunc = _CommandRushLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandRushLocator = RegisterContainerLocator<CommandModel<ReactiveCommand , String>> ( "CommandRush" , model => model . Initialize ( "CommandRush" , ref model . _CommandRush , ref _CommandRushLocator , _CommandRushDefaultValueFactory ) );
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandRushDefaultValueFactory =
            model =>
            {
                var resource = "Rush";           // Commands resource  
                var commandId = "Rush";
                var vm = CastToCurrentType ( model );
                var cmd = new ReactiveCommand ( canExecute: true ) { ViewModel = model }; //New Commands Core
                cmd
                    . DoExecuteUIBusyTask (
                        vm ,
                        async e =>
                        {
                            //Todo: Add Rush logic here, or
                            vm . GameCore . Rush ( );
                            await MVVMSidekick . Utilities . TaskExHelper . Yield ( );
                        }
                    )
                    . DoNotifyDefaultEventRouter ( vm , commandId )
                    . Subscribe ( )
                    . DisposeWith ( vm );

                var cmdmdl = cmd . CreateCommandModel ( resource );
                cmdmdl . ListenToIsUIBusy ( model: vm , canExecuteWhenBusy: false );
                return cmdmdl;
            };
        #endregion



        public string CPSOfOrange
        {
            get { return _CPSOfOrangeLocator ( this ) . Value; }
            set { _CPSOfOrangeLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string CPSOfOrange Setup
        protected Property<string> _CPSOfOrange = new Property<string> { LocatorFunc = _CPSOfOrangeLocator };
        static Func<BindableBase, ValueContainer<string>> _CPSOfOrangeLocator = RegisterContainerLocator<string> ( "CPSOfOrange" , model => model . Initialize ( "CPSOfOrange" , ref model . _CPSOfOrange , ref _CPSOfOrangeLocator , _CPSOfOrangeDefaultValueFactory ) );
        static Func<BindableBase, string> _CPSOfOrangeDefaultValueFactory =
            model =>
            {
                var vm = CastToCurrentType ( model );
                return App . Current . Resources [ "CPS" ] + vm . GameCore . SpeedOfOrangeRise . ToString ( ) + App . Current . Resources [ "/s" ];
            };
        #endregion


        public string NumberOfOrange
        {
            get { return _NumberOfOrangeLocator ( this ) . Value; }
            set { _NumberOfOrangeLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string NumberOfOrange Setup
        protected Property<string> _NumberOfOrange = new Property<string> { LocatorFunc = _NumberOfOrangeLocator };
        static Func<BindableBase, ValueContainer<string>> _NumberOfOrangeLocator = RegisterContainerLocator<string> ( "NumberOfOrange" , model => model . Initialize ( "NumberOfOrange" , ref model . _NumberOfOrange , ref _NumberOfOrangeLocator , _NumberOfOrangeDefaultValueFactory ) );
        static Func<BindableBase, string> _NumberOfOrangeDefaultValueFactory =
            model =>
            {
                var vm = CastToCurrentType ( model );
                return decimal . Floor ( vm . GameCore . NumberOfOrange ) . ToString ( );
            };
        #endregion



        public string NumberOfOrangeHaveGet
        {
            get { return _NumberOfOrangeHaveGetLocator ( this ) . Value; }
            set { _NumberOfOrangeHaveGetLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string NumberOfOrangeHaveGet Setup
        protected Property<string> _NumberOfOrangeHaveGet = new Property<string> { LocatorFunc = _NumberOfOrangeHaveGetLocator };
        static Func<BindableBase,ValueContainer<string>> _NumberOfOrangeHaveGetLocator= RegisterContainerLocator<string> ( "NumberOfOrangeHaveGet" , model => model . Initialize ( "NumberOfOrangeHaveGet" , ref model . _NumberOfOrangeHaveGet , ref _NumberOfOrangeHaveGetLocator , _NumberOfOrangeHaveGetDefaultValueFactory ) );
        static Func<BindableBase,string> _NumberOfOrangeHaveGetDefaultValueFactory = 
            model =>
            {
                var vm = CastToCurrentType ( model );
                return string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( vm . GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );S
            };
        #endregion


        public string NumberOfOrangeHaveMadeFromRush
        {
            get { return _NumberOfOrangeHaveMadeFromRushLocator ( this ) . Value; }
            set { _NumberOfOrangeHaveMadeFromRushLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string NumberOfOrangeHaveMadeFromRush Setup
        protected Property<string> _NumberOfOrangeHaveMadeFromRush = new Property<string> { LocatorFunc = _NumberOfOrangeHaveMadeFromRushLocator };
        static Func<BindableBase,ValueContainer<string>> _NumberOfOrangeHaveMadeFromRushLocator= RegisterContainerLocator<string> ( "NumberOfOrangeHaveMadeFromRush" , model => model . Initialize ( "NumberOfOrangeHaveMadeFromRush" , ref model . _NumberOfOrangeHaveMadeFromRush , ref _NumberOfOrangeHaveMadeFromRushLocator , _NumberOfOrangeHaveMadeFromRushDefaultValueFactory ) );
        static Func<BindableBase,string> _NumberOfOrangeHaveMadeFromRushDefaultValueFactory = 
            model =>
            {
                var vm = CastToCurrentType ( model );
                return decimal . Floor ( vm . GameCore . NumberOfOrangeHaveMadeFromRush ) . ToString ( );
            };
        #endregion


    }

}

