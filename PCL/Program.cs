using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App;

namespace PCL;

[StandardModule]
internal sealed class Program
{
	[STAThread]
	public static void Main()
	{
		Console.WriteLine("Welcome to PCL Pro-N!");
		ApplicationService.Loading = [SpecialName] () =>
		{
			Application application = new Application();
			application.InitializeComponent();
			return (Application)(object)application;
		};
		MainWindowService.Loading = [SpecialName] () =>
		{
			FormMain formMain = new FormMain();
			formMain.InitializeComponent();
			return (Window)(object)formMain;
		};
		_ = Tablet.TabletDevices;
		Lifecycle.OnInitialize();
	}
}
