using System;
using System.Linq;
using System.Windows;
using SciChart.Charting.Visuals;

namespace SciChartTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			SciChartSurface.SetRuntimeLicenseKey(
				"KEY");
			this.InitializeComponent();
			this.DataContext = new MainWindowViewModel();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			((MainWindowViewModel)DataContext).SetSeries();
		}

		private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
		{
			((MainWindowViewModel)DataContext).SetPaletteNull();
		}

		private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
		{
			((MainWindowViewModel)DataContext).SetDataContextNull();
		}
	}
}