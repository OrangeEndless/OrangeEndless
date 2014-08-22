using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Windows.Storage;
using MVVMSidekick.Utilities;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
using OrangeEndLess;


namespace OrangeEndLess.ViewModels
{

	[DataContract]
	public class MainPage_Model : ViewModelBase<MainPage_Model>
	{
		public Core GameCore = new Core(DateTime.Now);

		ApplicationDataContainer localSettings = ApplicationData.Current.RoamingSettings;


		public MainPage_Model()
		{
			GameCore.RandomEvent += GameCore_RandomEvent;
			GameCore.UpdateAchevements += GameCore_UpdateAchevements;
			GameCore.UpdateBuildings += GameCore_UpdateBuildings;
			GameCore.UpdateNumberOfMoney += GameCore_UpdateNumberOfMoney;
			GameCore.UpdateNumberOfOrange += GameCore_UpdateNumberOfOrange;
		}

		void GameCore_UpdateNumberOfOrange(object sender, EventArgs e)
		{
			NumberOfOrange = decimal.Floor(GameCore.NumberOfOrange).ToString();
			TextBlockNumberOfOrangeOutTip = string.Format("你制造的橘子总数：{0}", decimal.Floor(GameCore.NumberOfOrangeHaveGet).ToString());
			ButtonRushTip = decimal.Floor(GameCore.NumberOfOrangeHaveGet).ToString();
			ProgressBarValue = Convert.ToDouble(GameCore.NumberOfOrangeHaveGet);
			ProgressBarBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, Convert.ToByte(((decimal.MaxValue - GameCore.NumberOfOrangeHaveGet) / decimal.MaxValue) * 255), Convert.ToByte(((GameCore.NumberOfOrangeHaveGet) / decimal.MaxValue) * 255), 0));
			TextBlockNumberOfOrangeSmallOut = GameCore.NumberOfOrange.ToString();

		}

		void GameCore_UpdateNumberOfMoney(object sender, EventArgs e)
		{
			TextBlockNumberOfMoneySmallOut = GameCore.NumberOfMoney.ToString();
		}

		void GameCore_UpdateBuildings(object sender, EventArgs e)
		{
			CPSOfOrange = string.Format("橘子的增速：{0}/s", GameCore.SpeedOfOrangeRise.ToString());
			string Temp = string.Empty;
			foreach (var item in GameCore.Buildings)
			{
				if (item.Value.Status == Status.Active || item.Value.Status == Status.Dark)
				{
					Temp += string.Format("{0}:{1}/s" + System.Environment.NewLine, item.Value.Title, item.Value.CPS);
				}
			}
			Temp = Temp.Trim();
			Temp += string.Format(System.Environment.NewLine + "总和:{0}/s", GameCore.SpeedOfOrangeRise);
			TextBlockCPSOfOrangeOutTip = Temp.Trim();
		}

		void GameCore_UpdateAchevements(object sender, EventArgs e)
		{

		}

		void GameCore_RandomEvent(object sender, RandomArgs e)
		{

		}

		public CommandModel<ReactiveCommand, String> CommandRush
		{
			get { return _CommandRushLocator(this).Value; }
			set { _CommandRushLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property CommandModel<ReactiveCommand, String> CommandRush Setup
		protected Property<CommandModel<ReactiveCommand, String>> _CommandRush = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandRushLocator };
		static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandRushLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandRush", model => model.Initialize("CommandRush", ref model._CommandRush, ref _CommandRushLocator, _CommandRushDefaultValueFactory));
		static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandRushDefaultValueFactory =
			model =>
			{
				var resource = "Rush";           // Commands resource  
				var commandId = "Rush";
				var vm = CastToCurrentType(model);
				var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Commands Core
				cmd
					.DoExecuteUIBusyTask(
						vm,
						async e =>
						{
							//Todo: Add Rush logic here, or
							vm.GameCore.Rush();
							await MVVMSidekick.Utilities.TaskExHelper.Yield();
						}
					)
					.DoNotifyDefaultEventRouter(vm, commandId)
					.Subscribe()
					.DisposeWith(vm);

				var cmdmdl = cmd.CreateCommandModel(resource);
				cmdmdl.ListenToIsUIBusy(model: vm, canExecuteWhenBusy: false);
				return cmdmdl;
			};
		#endregion

		public string CPSOfOrange
		{
			get { return _CPSOfOrangeLocator(this).Value; }
			set { _CPSOfOrangeLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string CPSOfOrange Setup
		protected Property<string> _CPSOfOrange = new Property<string> { LocatorFunc = _CPSOfOrangeLocator };
		static Func<BindableBase, ValueContainer<string>> _CPSOfOrangeLocator = RegisterContainerLocator<string>("CPSOfOrange", model => model.Initialize("CPSOfOrange", ref model._CPSOfOrange, ref _CPSOfOrangeLocator, _CPSOfOrangeDefaultValueFactory));
		static Func<BindableBase, string> _CPSOfOrangeDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return string.Format("橘子的增速：{0}/s", vm.GameCore.SpeedOfOrangeRise.ToString());
			};
		#endregion

		public string NumberOfOrange
		{
			get { return _NumberOfOrangeLocator(this).Value; }
			set { _NumberOfOrangeLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string NumberOfOrange Setup
		protected Property<string> _NumberOfOrange = new Property<string> { LocatorFunc = _NumberOfOrangeLocator };
		static Func<BindableBase, ValueContainer<string>> _NumberOfOrangeLocator = RegisterContainerLocator<string>("NumberOfOrange", model => model.Initialize("NumberOfOrange", ref model._NumberOfOrange, ref _NumberOfOrangeLocator, _NumberOfOrangeDefaultValueFactory));
		static Func<BindableBase, string> _NumberOfOrangeDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return decimal.Floor(vm.GameCore.NumberOfOrange).ToString();
			};
		#endregion

		public string TextBlockNumberOfOrangeOutTip
		{
			get { return _TextBlockNumberOfOrangeOutTipLocator(this).Value; }
			set { _TextBlockNumberOfOrangeOutTipLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string TextBlockNumberOfOrangeOutTip Setup
		protected Property<string> _TextBlockNumberOfOrangeOutTip = new Property<string> { LocatorFunc = _TextBlockNumberOfOrangeOutTipLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockNumberOfOrangeOutTipLocator = RegisterContainerLocator<string>("TextBlockNumberOfOrangeOutTip", model => model.Initialize("TextBlockNumberOfOrangeOutTip", ref model._TextBlockNumberOfOrangeOutTip, ref _TextBlockNumberOfOrangeOutTipLocator, _TextBlockNumberOfOrangeOutTipDefaultValueFactory));
		static Func<BindableBase, string> _TextBlockNumberOfOrangeOutTipDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return string.Format("你制造的橘子总数：{0}", decimal.Floor(vm.GameCore.NumberOfOrangeHaveGet).ToString());
			};
		#endregion

		public string ButtonRushTip
		{
			get { return _ButtonRushTipLocator(this).Value; }
			set { _ButtonRushTipLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string ButtonRushTip Setup
		protected Property<string> _ButtonRushTip = new Property<string> { LocatorFunc = _ButtonRushTipLocator };
		static Func<BindableBase, ValueContainer<string>> _ButtonRushTipLocator = RegisterContainerLocator<string>("ButtonRushTip", model => model.Initialize("ButtonRushTip", ref model._ButtonRushTip, ref _ButtonRushTipLocator, _ButtonRushTipDefaultValueFactory));
		static Func<BindableBase, string> _ButtonRushTipDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return decimal.Floor(vm.GameCore.NumberOfOrangeHaveGet).ToString();
			};
		#endregion

		public string TextBlockCPSOfOrangeOutTip
		{
			get { return _TextBlockCPSOfOrangeOutTipLocator(this).Value; }
			set { _TextBlockCPSOfOrangeOutTipLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string TextBlockCPSOfOrangeOutTip Setup
		protected Property<string> _TextBlockCPSOfOrangeOutTip = new Property<string> { LocatorFunc = _TextBlockCPSOfOrangeOutTipLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockCPSOfOrangeOutTipLocator = RegisterContainerLocator<string>("TextBlockCPSOfOrangeOutTip", model => model.Initialize("TextBlockCPSOfOrangeOutTip", ref model._TextBlockCPSOfOrangeOutTip, ref _TextBlockCPSOfOrangeOutTipLocator, _TextBlockCPSOfOrangeOutTipDefaultValueFactory));
		static Func<BindableBase, string> _TextBlockCPSOfOrangeOutTipDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				string Temp = string.Empty;
				foreach (var item in vm.GameCore.Buildings)
				{
					if (item.Value.Status == Status.Active || item.Value.Status == Status.Dark)
					{
						Temp += string.Format("{0}:{1}/s" + System.Environment.NewLine, item.Value.Title, item.Value.CPS);
					}
				}
				Temp = Temp.Trim();
				Temp += string.Format(System.Environment.NewLine + "总和:{0}/s", vm.GameCore.SpeedOfOrangeRise);
				return Temp.Trim();
			};
		#endregion

		public double ProgressBarMaximum
		{
			get { return _ProgressBarMaximumLocator(this).Value; }
			set { _ProgressBarMaximumLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property double ProgressBarMaximum Setup
		protected Property<double> _ProgressBarMaximum = new Property<double> { LocatorFunc = _ProgressBarMaximumLocator };
		static Func<BindableBase, ValueContainer<double>> _ProgressBarMaximumLocator = RegisterContainerLocator<double>("ProgressBarMaximum", model => model.Initialize("ProgressBarMaximum", ref model._ProgressBarMaximum, ref _ProgressBarMaximumLocator, _ProgressBarMaximumDefaultValueFactory));
		static Func<BindableBase, double> _ProgressBarMaximumDefaultValueFactory =
			model =>
			{
				return Convert.ToDouble(decimal.MaxValue);
			};
		#endregion

		public Brush ProgressBarBrush
		{
			get { return _ProgressBarBrushLocator(this).Value; }
			set { _ProgressBarBrushLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property Brush ProgressBarBrush Setup
		protected Property<Brush> _ProgressBarBrush = new Property<Brush> { LocatorFunc = _ProgressBarBrushLocator };
		static Func<BindableBase, ValueContainer<Brush>> _ProgressBarBrushLocator = RegisterContainerLocator<Brush>("ProgressBarBrush", model => model.Initialize("ProgressBarBrush", ref model._ProgressBarBrush, ref _ProgressBarBrushLocator, _ProgressBarBrushDefaultValueFactory));
		static Func<BindableBase, Brush> _ProgressBarBrushDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return new SolidColorBrush(Color.FromArgb(byte.MaxValue, Convert.ToByte(((decimal.MaxValue - vm.GameCore.NumberOfOrangeHaveGet) / decimal.MaxValue) * 255), Convert.ToByte(((vm.GameCore.NumberOfOrangeHaveGet) / decimal.MaxValue) * 255), 0)); ;
			};
		#endregion

		public double ProgressBarValue
		{
			get { return _ProgressBarValueLocator(this).Value; }
			set { _ProgressBarValueLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property double ProgressBarValue Setup
		protected Property<double> _ProgressBarValue = new Property<double> { LocatorFunc = _ProgressBarValueLocator };
		static Func<BindableBase, ValueContainer<double>> _ProgressBarValueLocator = RegisterContainerLocator<double>("ProgressBarValue", model => model.Initialize("ProgressBarValue", ref model._ProgressBarValue, ref _ProgressBarValueLocator, _ProgressBarValueDefaultValueFactory));
		static Func<BindableBase, double> _ProgressBarValueDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return Convert.ToDouble(vm.GameCore.NumberOfOrangeHaveGet);
			};
		#endregion


		public string TextBlockNumberOfOrangeSmallOut
		{
			get { return _TextBlockNumberOfOrangeSmallOutLocator(this).Value; }
			set { _TextBlockNumberOfOrangeSmallOutLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string TextBlockNumberOfOrangeSmallOut Setup
		protected Property<string> _TextBlockNumberOfOrangeSmallOut = new Property<string> { LocatorFunc = _TextBlockNumberOfOrangeSmallOutLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockNumberOfOrangeSmallOutLocator = RegisterContainerLocator<string>("TextBlockNumberOfOrangeSmallOut", model => model.Initialize("TextBlockNumberOfOrangeSmallOut", ref model._TextBlockNumberOfOrangeSmallOut, ref _TextBlockNumberOfOrangeSmallOutLocator, _TextBlockNumberOfOrangeSmallOutDefaultValueFactory));
		static Func<BindableBase, string> _TextBlockNumberOfOrangeSmallOutDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return vm.GameCore.NumberOfOrange.ToString();
			};
		#endregion


		public string TextBlockNumberOfMoneySmallOut
		{
			get { return _TextBlockNumberOfMoneySmallOutLocator(this).Value; }
			set { _TextBlockNumberOfMoneySmallOutLocator(this).SetValueAndTryNotify(value); }
		}
		#region Property string TextBlockNumberOfMoneySmallOut Setup
		protected Property<string> _TextBlockNumberOfMoneySmallOut = new Property<string> { LocatorFunc = _TextBlockNumberOfMoneySmallOutLocator };
		static Func<BindableBase, ValueContainer<string>> _TextBlockNumberOfMoneySmallOutLocator = RegisterContainerLocator<string>("TextBlockNumberOfMoneySmallOut", model => model.Initialize("TextBlockNumberOfMoneySmallOut", ref model._TextBlockNumberOfMoneySmallOut, ref _TextBlockNumberOfMoneySmallOutLocator, _TextBlockNumberOfMoneySmallOutDefaultValueFactory));
		static Func<BindableBase, string> _TextBlockNumberOfMoneySmallOutDefaultValueFactory =
			model =>
			{
				var vm = CastToCurrentType(model);
				return vm.GameCore.NumberOfMoney.ToString();
			};
		#endregion


	}

}

