using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SciChartTest
{
	/// <summary>
	/// Interaction logic for ChartView.xaml
	/// </summary>
	public partial class ChartView : UserControl
	{
		public ChartView()
		{
			InitializeComponent();
		}

		private void RemoveDataContext(object sender, RoutedEventArgs e)
		{
			this.DataContext = null;
		}

		private void SwitchData(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is ChartViewModel model)
			{
				model.SwitchChart();
			}
		}
	}
}