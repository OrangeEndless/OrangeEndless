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

		public MainPage_Model ( )
		{
			//GameCore . RandomEvent += GameCore_RandomEvent;
			GameCore . UpdateAchevements += GameCore_UpdateAchevements;
			GameCore . UpdateBuildings += GameCore_UpdateBuildings;
			GameCore . UpdateNumberOfMoney += GameCore_UpdateNumberOfMoney;
			GameCore . UpdateNumberOfOrange += GameCore_UpdateNumberOfOrange;
			GameCore . UpdateConsole += Consoles_UpdateConsole;
			
		}

		void Consoles_UpdateConsole ( object sender , EventArgs e )
		{
			ConsoleText = GameCore . ConsoleTextOut;
		}

		void GameCore_UpdateNumberOfOrange ( object sender , EventArgs e )
		{
			NOO = string . Format ( "橘子的个数：{0}" , decimal . Floor ( GameCore . NumberOfOrange ) . ToString ( ) );
			NOOHG = string . Format ( "你制造的橘子总数：{0}" , decimal . Floor ( GameCore . NumberOfOrangeHaveGet ) . ToString ( ) );
			NOONO = GameCore . NumberOfOrange . ToString ( );
		}

		void GameCore_UpdateNumberOfMoney ( object sender , EventArgs e )
		{
			NOM = string . Format ( "钱的个数：{0}" , decimal . Floor ( GameCore . NumberOfMoney ) . ToString ( ) );
			NOMHG = string . Format ( "你制造的钱总数：{0}" , decimal . Floor ( GameCore . NumberOfMoneyHaveGet ) . ToString ( ) );
			NOMNO = GameCore . NumberOfMoney . ToString ( );
		}

		void GameCore_UpdateBuildings ( object sender , EventArgs e )
		{
			CPSOO = string . Format ( "橘子的增速：{0}/s" , GameCore . SpeedOfOrangeRise . ToString ( ) );

			string _CPSOOD = string . Empty;

			decimal _NOB=0;
			decimal _NOBK=0;
			string _NOBD=string . Empty;

			#region LoadCPSOOD
			foreach ( var item in GameCore . Buildings )
			{
				if ( item . Value . Status == Status . Active || item . Value . Status == Status . Dark )
				{
					_CPSOOD += string . Format ( "{0}:{1}/s" + System . Environment . NewLine , item . Value . Title , item . Value . CPS );

				}
				if ( item . Value . Status == Status . Active )
				{
					_NOBK++;
					_NOBD += string . Format ( "{0}:{1}" + System . Environment . NewLine , item . Value . Title , item . Value . Number );
				}
			}
			#endregion
			#region LoadNOBD
			_NOBD = _NOBD . Trim ( );
			_NOBD += string . Format ( System . Environment . NewLine + "总和:{0}/s" , GameCore . NumberOfBuilding );
			NOBD = _NOBD . Trim ( );
			#endregion
			#region LoadCPSOOD
			_CPSOOD = _CPSOOD . Trim ( );
			_CPSOOD += string . Format ( System . Environment . NewLine + "总和:{0}/s" , GameCore . SpeedOfOrangeRise );
			CPSOOD = _CPSOOD . Trim ( );
			#endregion

			_NOB = GameCore . NumberOfBuilding;

		}

		void GameCore_UpdateAchevements ( object sender , EventArgs e )
		{

		}

		//void GameCore_RandomEvent ( object sender , RandomArgs e )
		//{

		//}

		/// <summary>
		/// Number Of Money
		/// </summary>
		public string NOM
		{
			get { return _NOMLocator ( this ) . Value; }
			set { _NOMLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOM Setup
		protected Property<string> _NOM = new Property<string> { LocatorFunc = _NOMLocator };
		static Func<BindableBase,ValueContainer<string>> _NOMLocator= RegisterContainerLocator<string> ( "NOM" , model => model . Initialize ( "NOM" , ref model . _NOM , ref _NOMLocator , _NOMDefaultValueFactory ) );
		static Func<BindableBase,string> _NOMDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return string . Format ( "钱的个数：{0}" , decimal . Floor ( vm . GameCore . NumberOfMoney ) . ToString ( ) );
			};
		#endregion

		/// <summary>
		/// Number Of Money Have Get
		/// </summary>
		public string NOMHG
		{
			get { return _NOMHGLocator ( this ) . Value; }
			set { _NOMHGLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOMHG Setup
		protected Property<string> _NOMHG = new Property<string> { LocatorFunc = _NOMHGLocator };
		static Func<BindableBase,ValueContainer<string>> _NOMHGLocator= RegisterContainerLocator<string> ( "NOMHG" , model => model . Initialize ( "NOMHG" , ref model . _NOMHG , ref _NOMHGLocator , _NOMHGDefaultValueFactory ) );
		static Func<BindableBase,string> _NOMHGDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				return string . Format ( "你制造的钱总数：{0}" , decimal . Floor ( vm . GameCore . NumberOfMoneyHaveGet ) . ToString ( ) );
			};
		#endregion

		/// <summary>
		/// Number Of Orange
		/// </summary>
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

		/// <summary>
		/// Number Of Orange Have Get
		/// </summary>
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

		/// <summary>
		/// CPS Of Orange
		/// </summary>
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

		/// <summary>
		/// CPS Of Orange Detail
		/// </summary>
		public string CPSOOD
		{
			get { return _CPSOODLocator ( this ) . Value; }
			set { _CPSOODLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string CPSOOD Setup
		protected Property<string> _CPSOOD = new Property<string> { LocatorFunc = _CPSOODLocator };
		static Func<BindableBase,ValueContainer<string>> _CPSOODLocator= RegisterContainerLocator<string> ( "CPSOOD" , model => model . Initialize ( "CPSOOD" , ref model . _CPSOOD , ref _CPSOODLocator , _CPSOODDefaultValueFactory ) );
		static Func<BindableBase,string> _CPSOODDefaultValueFactory = 
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

		/// <summary>
		/// Number Of Building
		/// </summary>
		public string NOB
		{
			get { return _NOBLocator ( this ) . Value; }
			set { _NOBLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOB Setup
		protected Property<string > _NOB = new Property<string> { LocatorFunc = _NOBLocator };
		static Func<BindableBase,ValueContainer<string >> _NOBLocator= RegisterContainerLocator<string> ( "NOB" , model => model . Initialize ( "NOB" , ref model . _NOB , ref _NOBLocator , _NOBDefaultValueFactory ) );
		static Func<BindableBase,string > _NOBDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// Number Of Building Detail
		/// </summary>
		public string NOBD
		{
			get { return _NOBDLocator ( this ) . Value; }
			set { _NOBDLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOBD Setup
		protected Property<string> _NOBD = new Property<string> { LocatorFunc = _NOBDLocator };
		static Func<BindableBase,ValueContainer<string>> _NOBDLocator= RegisterContainerLocator<string> ( "NOBD" , model => model . Initialize ( "NOBD" , ref model . _NOBD , ref _NOBDLocator , _NOBDDefaultValueFactory ) );
		static Func<BindableBase,string> _NOBDDefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion


		
		public List<Building> BL
		{
			get { return _BLLocator ( this ) . Value; }
			set { _BLLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property List<Building> BL Setup
		protected Property<List<Building>> _BL = new Property<List<Building>> { LocatorFunc = _BLLocator };
		static Func<BindableBase,ValueContainer<List<Building>>> _BLLocator= RegisterContainerLocator<List<Building>> ( "BL" , model => model . Initialize ( "BL" , ref model . _BL , ref _BLLocator , _BLDefaultValueFactory ) );
		static Func<BindableBase,List<Building>> _BLDefaultValueFactory = 
            model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( List<Building> );
			};
		#endregion


		#region Number Only

		/// <summary>
		/// Number Of Orange Number Only
		/// </summary>
		public string NOONO
		{
			get { return _NOONOLocator ( this ) . Value; }
			set { _NOONOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOONO Setup
		protected Property<string> _NOONO = new Property<string> { LocatorFunc = _NOONOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOONOLocator= RegisterContainerLocator<string> ( "NOONO" , model => model . Initialize ( "NOONO" , ref model . _NOONO , ref _NOONOLocator , _NOONODefaultValueFactory ) );
		static Func<BindableBase,string> _NOONODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// Number Of Money Number Only
		/// </summary>
		public string NOMNO
		{
			get { return _NOMNOLocator ( this ) . Value; }
			set { _NOMNOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOMNO Setup
		protected Property<string> _NOMNO = new Property<string> { LocatorFunc = _NOMNOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOMNOLocator= RegisterContainerLocator<string> ( "NOMNO" , model => model . Initialize ( "NOMNO" , ref model . _NOMNO , ref _NOMNOLocator , _NOMNODefaultValueFactory ) );
		static Func<BindableBase,string> _NOMNODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// Number Of Orange Have Get Number Only
		/// </summary>
		public string NOOHGNO
		{
			get { return _NOOHGNOLocator ( this ) . Value; }
			set { _NOOHGNOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOOHGNO Setup
		protected Property<string> _NOOHGNO = new Property<string> { LocatorFunc = _NOOHGNOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOOHGNOLocator= RegisterContainerLocator<string> ( "NOOHGNO" , model => model . Initialize ( "NOOHGNO" , ref model . _NOOHGNO , ref _NOOHGNOLocator , _NOOHGNODefaultValueFactory ) );
		static Func<BindableBase,string> _NOOHGNODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// Number Of Building Number Only
		/// </summary>
		public string NOBNO
		{
			get { return _NOBNOLocator ( this ) . Value; }
			set { _NOBNOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOBNO Setup
		protected Property<string> _NOBNO = new Property<string> { LocatorFunc = _NOBNOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOBNOLocator= RegisterContainerLocator<string> ( "NOBNO" , model => model . Initialize ( "NOBNO" , ref model . _NOBNO , ref _NOBNOLocator , _NOBNODefaultValueFactory ) );
		static Func<BindableBase,string> _NOBNODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// Number Of Building Kind Number Only
		/// </summary>
		public string NOBKNO
		{
			get { return _NOBKNOLocator ( this ) . Value; }
			set { _NOBKNOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string NOBKNO Setup
		protected Property<string> _NOBKNO = new Property<string> { LocatorFunc = _NOBKNOLocator };
		static Func<BindableBase,ValueContainer<string>> _NOBKNOLocator= RegisterContainerLocator<string> ( "NOBKNO" , model => model . Initialize ( "NOBKNO" , ref model . _NOBKNO , ref _NOBKNOLocator , _NOBKNODefaultValueFactory ) );
		static Func<BindableBase,string> _NOBKNODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion

		/// <summary>
		/// CPS Of Orange Number Only
		/// </summary>
		public string CPSOONO
		{
			get { return _CPSOONOLocator ( this ) . Value; }
			set { _CPSOONOLocator ( this ) . SetValueAndTryNotify ( value ); }
		}
		#region Property string CPSOONO Setup
		protected Property<string> _CPSOONO = new Property<string> { LocatorFunc = _CPSOONOLocator };
		static Func<BindableBase,ValueContainer<string>> _CPSOONOLocator= RegisterContainerLocator<string> ( "CPSOONO" , model => model . Initialize ( "CPSOONO" , ref model . _CPSOONO , ref _CPSOONOLocator , _CPSOONODefaultValueFactory ) );
		static Func<BindableBase,string> _CPSOONODefaultValueFactory = 
			model =>
			{
				var vm = CastToCurrentType ( model );
				//TODO: Add the logic that produce default value from vm current status.
				return default ( string );
			};
		#endregion


		#endregion

		#region Console

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
				return vm . GameCore . ConsoleTextOut;
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
							vm . GameCore . Commands ( vm . TextConsoleCommand . TrimStart ( '>' ) );
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

