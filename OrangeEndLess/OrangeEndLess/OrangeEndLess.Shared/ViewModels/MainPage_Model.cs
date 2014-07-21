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
            GameCore . UpdateData += GameCore_UpdateData;
            GameCore . RandomEvent += GameCore_RandomEvent;
        }

        void GameCore_RandomEvent ( object sender , RandomArgs e )
        {

        }

        void GameCore_UpdateData ( object sender , EventArgs e )
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
                return vm . GameCore . NumberOfOrange . ToString ( );
            };
        #endregion


        //#region Life Time Event Handling

        ///// <summary>
        ///// This will be invoked by view when this viewmodel instance is set to view's ViewModel property. 
        ///// </summary>
        ///// <param name="view">Set target</param>
        ///// <param name="oldValue">Value before set.</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedToView(MVVMSidekick.Views.IView view, IViewModel oldValue)
        //{
        //    return base.OnBindedToView(view, oldValue);
        //}

        ///// <summary>
        ///// This will be invoked by view when this instance of viewmodel in ViewModel property is overwritten.
        ///// </summary>
        ///// <param name="view">Overwrite target view.</param>
        ///// <param name="newValue">The value replacing </param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnUnbindedFromView(MVVMSidekick.Views.IView view, IViewModel newValue)
        //{
        //    return base.OnUnbindedFromView(view, newValue);
        //}

        ///// <summary>
        ///// This will be invoked by view when the view fires Load event and this viewmodel instance is already in view's ViewModel property
        ///// </summary>
        ///// <param name="view">View that firing Load event</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedViewLoad(MVVMSidekick.Views.IView view)
        //{
        //    return base.OnBindedViewLoad(view);
        //}

        ///// <summary>
        ///// This will be invoked by view when the view fires Unload event and this viewmodel instance is still in view's  ViewModel property
        ///// </summary>
        ///// <param name="view">View that firing Unload event</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedViewUnload(MVVMSidekick.Views.IView view)
        //{
        //    return base.OnBindedViewUnload(view);
        //}

        ///// <summary>
        ///// <para>If dispose actions got exceptions, will handled here. </para>
        ///// </summary>
        ///// <param name="exceptions">
        ///// <para>The exception and dispose infomation</para>
        ///// </param>
        //protected override async void OnDisposeExceptions(IList<DisposeInfo> exceptions)
        //{
        //    base.OnDisposeExceptions(exceptions);
        //    await TaskExHelper.Yield();
        //}

        //#endregion


    }

}

