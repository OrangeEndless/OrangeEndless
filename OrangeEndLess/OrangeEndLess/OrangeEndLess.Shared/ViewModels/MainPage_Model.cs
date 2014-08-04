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
            TextBlockNumberOfOrangeOutTip = string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );
            ButtonRushTip = decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( );
        }

        void GameCore_UpdateNumberOfMoney ( object sender , EventArgs e )
        {

        }

        void GameCore_UpdateBuildings ( object sender , EventArgs e )
        {
            CPSOfOrange = string . Format ( "橘子的增速：{0}/s" , GameCore . SpeedOfOrangeRise . ToString ( ) );
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
        static Func<BindableBase,ValueContainer<string>> _CPSOfOrangeLocator= RegisterContainerLocator<string> ( "CPSOfOrange" , model => model . Initialize ( "CPSOfOrange" , ref model . _CPSOfOrange , ref _CPSOfOrangeLocator , _CPSOfOrangeDefaultValueFactory ) );
        static Func<string> _CPSOfOrangeDefaultValueFactory = ( ) => { return default ( string ); };
        #endregion

        public string NumberOfOrange
        {
            get { return _NumberOfOrangeLocator ( this ) . Value; }
            set { _NumberOfOrangeLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string NumberOfOrange Setup
        protected Property<string> _NumberOfOrange = new Property<string> { LocatorFunc = _NumberOfOrangeLocator };
        static Func<BindableBase,ValueContainer<string>> _NumberOfOrangeLocator= RegisterContainerLocator<string> ( "NumberOfOrange" , model => model . Initialize ( "NumberOfOrange" , ref model . _NumberOfOrange , ref _NumberOfOrangeLocator , _NumberOfOrangeDefaultValueFactory ) );
        static Func<string> _NumberOfOrangeDefaultValueFactory = ( ) => { return default ( string ); };
        #endregion

        public string TextBlockNumberOfOrangeOutTip
        {
            get { return _TextBlockNumberOfOrangeOutTipLocator ( this ) . Value; }
            set { _TextBlockNumberOfOrangeOutTipLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string TextBlockNumberOfOrangeOutTip Setup
        protected Property<string> _TextBlockNumberOfOrangeOutTip = new Property<string> { LocatorFunc = _TextBlockNumberOfOrangeOutTipLocator };
        static Func<BindableBase,ValueContainer<string>> _TextBlockNumberOfOrangeOutTipLocator= RegisterContainerLocator<string> ( "TextBlockNumberOfOrangeOutTip" , model => model . Initialize ( "TextBlockNumberOfOrangeOutTip" , ref model . _TextBlockNumberOfOrangeOutTip , ref _TextBlockNumberOfOrangeOutTipLocator , _TextBlockNumberOfOrangeOutTipDefaultValueFactory ) );
        static Func<string> _TextBlockNumberOfOrangeOutTipDefaultValueFactory = ( ) => { return default ( string ); };
        #endregion

        public string ButtonRushTip
        {
            get { return _ButtonRushTipLocator ( this ) . Value; }
            set { _ButtonRushTipLocator ( this ) . SetValueAndTryNotify ( value ); }
        }
        #region Property string ButtonRushTip Setup
        protected Property<string> _ButtonRushTip = new Property<string> { LocatorFunc = _ButtonRushTipLocator };
        static Func<BindableBase,ValueContainer<string>> _ButtonRushTipLocator= RegisterContainerLocator<string> ( "ButtonRushTip" , model => model . Initialize ( "ButtonRushTip" , ref model . _ButtonRushTip , ref _ButtonRushTipLocator , _ButtonRushTipDefaultValueFactory ) );
        static Func<string> _ButtonRushTipDefaultValueFactory = ( ) => { return default ( string ); };
        #endregion


    }

}

