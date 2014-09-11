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
using Windows . UI . Xaml . Media;
using Windows . UI;
using OrangeEndLess;


namespace OrangeEndLess . ViewModels
{

	[DataContract]
	public class MainPage_Model : ViewModelBase<MainPage_Model>
	{
		public Core GameCore = new Core ( );

		ApplicationDataContainer localSettings = ApplicationData . Current . RoamingSettings;

		public GameConsole Consoles;

		public MainPage_Model ( )
		{
			Consoles = new GameConsole ( GameCore );

			//GameCore . RandomEvent += GameCore_RandomEvent;
			GameCore . UpdateAchevements += GameCore_UpdateAchevements;
			GameCore . UpdateBuildings += GameCore_UpdateBuildings;
			GameCore . UpdateNumberOfMoney += GameCore_UpdateNumberOfMoney;
			GameCore . UpdateNumberOfOrange += GameCore_UpdateNumberOfOrange;
			Consoles . UpdateConsole += Consoles_UpdateConsole;

		}

		void Consoles_UpdateConsole ( object sender , EventArgs e )
		{
			ConsoleText = Consoles . TextOut;
		}

		void GameCore_UpdateNumberOfOrange ( object sender , EventArgs e )
		{
			NOO = string . Format ( "橘子的个数：{0}" , decimal . Floor ( GameCore . NumberOfOrange ) . ToString ( ) );
			NOOHG = string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );
			ButtonRushTip = decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( );
			TextBlockNumberOfOrangeSmallOut = GameCore . NumberOfOrange . ToString ( );
		}

		void GameCore_UpdateNumberOfMoney ( object sender , EventArgs e )
		{
			TextBlockNumberOfMoneySmallOut = GameCore . NumberOfMoney . ToString ( );
		}

		void GameCore_UpdateBuildings ( object sender , EventArgs e )
		{
			CPSOO = string . Format ( "橘子的增速：{0}/s" , GameCore . SpeedOfOrangeRise . ToString ( ) );
			string Temp = string . Empty;
			foreach ( var item in GameCore . Buildings )
			{
				if ( item . Value . Status == Status . Active || item . Value . Status == Status . Dark )
				{
					Temp += string . Format ( "{0}:{1}/s" + System . Environment . NewLine , item . Value . Title , item . Value . CPS );
				}
			}
			Temp = Temp . Trim ( );
			Temp += string . Format ( System . Environment . NewLine + "总和:{0}/s" , GameCore . SpeedOfOrangeRise );
			TextBlockCPSOfOrangeOutTip = Temp . Trim ( );
		}

		void GameCore_UpdateAchevements ( object sender , EventArgs e )
		{

		}

		//void GameCore_RandomEvent ( object sender , RandomArgs e )
		//{

		//}



		public string CPSOO
		{
			get { return _CPSOOLocator ( this ) . Value; }
			set { _CPSOOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string CPSOO Setup
		protected Property<string> _CPSOO = new Property<string> { LocatorFunc = _CPSOOLocator };
		static Func<BindableBase,ValueContainer<string>> _CPSOOLocator= RegisterContainerLocator<string> ( "CPSOO" , model => model . Initialize ( "CPSOO" , ref model . _CPSOO , ref _CPSOOLocator , _CPSOODefaultValueFactory ) );
		static Func<BindableBase,string> _CPSOODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return string . Format ( "橘子的增速：{0}/s" , vm . GameCore . SpeedOfOrangeRise . ToString ( ) );
			};
		#endregion


		public string NOO
		{
			get { return _NOOLocator ( this ) . Value; }
			set { _NOOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOO Setup
		protected Property<string> _NOO = new Property<string> { LocatorFunc = _NOOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOOLocator= RegisterContainerLocator<string> ( "NOO" , model => model . Initialize ( "NOO" , ref model . _NOO , ref _NOOLocator , _NOODefaultValueFactory ) );
		static Func<BindableBase,string> _NOODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				return string . Format ( "橘子的个数：{0}" , decimal . Floor ( vm . GameCore . NumberOfOrange ) . ToString ( ) );
			};
		#endregion


		public string NOOHG
		{
			get { return _NOOHGLocator ( this ) . Value; }
			set { _NOOHGLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOOHG Setup
		protected Property<string> _NOOHG = new Property<string> { LocatorFunc = _NOOHGLocator };
		static Func<BindableBase, ValueContainer<string>> _NOOHGLocator = RegisterContainerLocator<string> ( "NOOHG" , model => model . Initialize ( "NOOHG" , ref model . _NOOHG , ref _NOOHGLocator , _NOOHGDefaultValueFactory ) );
		static Func<BindableBase, string> _NOOHGDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType ( model );
				return string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( vm . GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );
			};
		#endregion

		public string ButtonRushTip
		{
			get { return _ButtonRushTipLocator ( this ) . Value; }
			set { _ButtonRushTipLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string ButtonRushTip Setup
		protected Property<string> _ButtonRushTip = new Property<string> { LocatorFunc = _ButtonRushTipLocator };
		static Func<BindableBase, ValueContainer<string>> _ButtonRushTipLocator = RegisterContainerLocator<string> ( "ButtonRushTip" , model => model . Initialize ( "ButtonRushTip" , ref model . _ButtonRushTip , ref _ButtonRushTipLocator , _ButtonRushTipDefaultValueFactory ) );
		static Func<BindableBase, string> _ButtonRushTipDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType ( model );
				return decimal . Floor ( vm . GameCore . NumberOfOrangeHaveGet ) . ToString ( );
			};
		#endregion

		public string TextBlockCPSOfOrangeOutTip
		{
			get { return _TextBlockCPSOfOrangeOutTipLocator ( this ) . Value; }
			set { _TextBlockCPSOfOrangeOutTipLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string TextBlockCPSOfOrangeOutTip Setup
		protected Property<string> _TextBlockCPSOfOrangeOutTip = new Property<string> { LocatorFunc = _TextBlockCPSOfOrangeOutTipLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockCPSOfOrangeOutTipLocator = RegisterContainerLocator<string> ( "TextBlockCPSOfOrangeOutTip" , model => model . Initialize ( "TextBlockCPSOfOrangeOutTip" , ref model . _TextBlockCPSOfOrangeOutTip , ref _TextBlockCPSOfOrangeOutTipLocator , _TextBlockCPSOfOrangeOutTipDefaultValueFactory ) );
		static Func<BindableBase, string> _TextBlockCPSOfOrangeOutTipDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType ( model );
				string Temp = string . Empty;
				foreach ( var item in vm . GameCore . Buildings )
				{
					if ( item . Value . Status == Status . Active || item . Value . Status == Status . Dark )
					{
						Temp += string . Format ( "{0}:{1}/s" + System . Environment . NewLine , item . Value . Title , item . Value . CPS );
					}
				}
				Temp = Temp . Trim ( );
				Temp += string . Format ( System . Environment . NewLine + "总和:{0}/s" , vm . GameCore . SpeedOfOrangeRise );
				return Temp . Trim ( );
			};
		#endregion

		public string TextBlockNumberOfOrangeSmallOut
		{
			get { return _TextBlockNumberOfOrangeSmallOutLocator ( this ) . Value; }
			set { _TextBlockNumberOfOrangeSmallOutLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string TextBlockNumberOfOrangeSmallOut Setup
		protected Property<string> _TextBlockNumberOfOrangeSmallOut = new Property<string> { LocatorFunc = _TextBlockNumberOfOrangeSmallOutLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockNumberOfOrangeSmallOutLocator = RegisterContainerLocator<string> ( "TextBlockNumberOfOrangeSmallOut" , model => model . Initialize ( "TextBlockNumberOfOrangeSmallOut" , ref model . _TextBlockNumberOfOrangeSmallOut , ref _TextBlockNumberOfOrangeSmallOutLocator , _TextBlockNumberOfOrangeSmallOutDefaultValueFactory ) );
		static Func<BindableBase, string> _TextBlockNumberOfOrangeSmallOutDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType ( model );
				return vm . GameCore . NumberOfOrange . ToString ( );
			};
		#endregion


		public string TextBlockNumberOfMoneySmallOut
		{
			get { return _TextBlockNumberOfMoneySmallOutLocator ( this ) . Value; }
			set { _TextBlockNumberOfMoneySmallOutLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string TextBlockNumberOfMoneySmallOut Setup
		protected Property<string> _TextBlockNumberOfMoneySmallOut = new Property<string> { LocatorFunc = _TextBlockNumberOfMoneySmallOutLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockNumberOfMoneySmallOutLocator = RegisterContainerLocator<string> ( "TextBlockNumberOfMoneySmallOut" , model => model . Initialize ( "TextBlockNumberOfMoneySmallOut" , ref model . _TextBlockNumberOfMoneySmallOut , ref _TextBlockNumberOfMoneySmallOutLocator , _TextBlockNumberOfMoneySmallOutDefaultValueFactory ) );
		static Func<BindableBase, string> _TextBlockNumberOfMoneySmallOutDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType ( model );
				return vm . GameCore . NumberOfMoney . ToString ( );
			};
		#endregion


		public string ConsoleText
		{
			get { return _ConsoleTextLocator ( this ) . Value; }
			set { _ConsoleTextLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string ConsoleText Setup
		protected Property<string> _ConsoleText = new Property<string> { LocatorFunc = _ConsoleTextLocator };
		static Func<BindableBase,ValueContainer<string>> _ConsoleTextLocator= RegisterContainerLocator<string> ( "ConsoleText" , model => model . Initialize ( "ConsoleText" , ref model . _ConsoleText , ref _ConsoleTextLocator , _ConsoleTextDefaultValueFactory ) );
		static Func<BindableBase,string> _ConsoleTextDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				return vm . Consoles . TextOut;
			};
		#endregion


		public CommandModel<ReactiveCommand , String> CommandConsoleCommand
		{
			get { return _CommandConsoleCommandLocator ( this ) . Value; }
			set { _CommandConsoleCommandLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property CommandModel<ReactiveCommand, String> CommandConsoleCommand Setup
		protected Property<CommandModel<ReactiveCommand, String>> _CommandConsoleCommand = new Property<CommandModel<ReactiveCommand , String>> { LocatorFunc = _CommandConsoleCommandLocator };
		static Func<BindableBase,ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandConsoleCommandLocator= RegisterContainerLocator<CommandModel<ReactiveCommand , String>> ( "CommandConsoleCommand" , model => model . Initialize ( "CommandConsoleCommand" , ref model . _CommandConsoleCommand , ref _CommandConsoleCommandLocator , _CommandConsoleCommandDefaultValueFactory ) );
		static Func<BindableBase,CommandModel<ReactiveCommand, String>> _CommandConsoleCommandDefaultValueFactory =
			model =>
			{
				var resource = "ConsoleCommand";           // Command resource  
				var commandId = "ConsoleCommand";
				var vm = CastToCurrentType ( model );
				var cmd = new ReactiveCommand ( canExecute: true ) { ViewModel = model }; //New Command Core
				cmd
					. DoExecuteUIBusyTask (
						vm ,
						async e =>
						{
							vm . Consoles . Commands ( vm . TextConsoleCommand . TrimStart ( '>' ) );
							vm . TextConsoleCommand = ">";
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


		public string TextConsoleCommand
		{
			get { return _TextConsoleCommandLocator ( this ) . Value; }
			set { _TextConsoleCommandLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string TextConsoleCommand Setup
		protected Property<string> _TextConsoleCommand = new Property<string> { LocatorFunc = _TextConsoleCommandLocator };
		static Func<BindableBase,ValueContainer<string>> _TextConsoleCommandLocator= RegisterContainerLocator<string> ( "TextConsoleCommand" , model => model . Initialize ( "TextConsoleCommand" , ref model . _TextConsoleCommand , ref _TextConsoleCommandLocator , _TextConsoleCommandDefaultValueFactory ) );
		static Func<BindableBase,string> _TextConsoleCommandDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return ">";
			};
		#endregion


		public CommandModel<ReactiveCommand , String> CommandRush
		{
			get { return _CommandRushLocator ( this ) . Value; }
			set { _CommandRushLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property CommandModel<ReactiveCommand, String> CommandRush Setup
		protected Property<CommandModel<ReactiveCommand, String>> _CommandRush = new Property<CommandModel<ReactiveCommand , String>> { LocatorFunc = _CommandRushLocator };
		static Func<BindableBase,ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandRushLocator= RegisterContainerLocator<CommandModel<ReactiveCommand , String>> ( "CommandRush" , model => model . Initialize ( "CommandRush" , ref model . _CommandRush , ref _CommandRushLocator , _CommandRushDefaultValueFactory ) );
		static Func<BindableBase,CommandModel<ReactiveCommand, String>> _CommandRushDefaultValueFactory =
			model =>
			{
				var resource = "Rush";           // Command resource  
				var commandId = "Rush";
				var vm = CastToCurrentType ( model );
				var cmd = new ReactiveCommand ( canExecute: true ) { ViewModel = model }; //New Command Core
				cmd
					. DoExecuteUIBusyTask (
						vm ,
						async e =>
						{
							vm . GameCore . Rush ( );
							vm . GameCore . PlusAPM ( );
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

	}

}

