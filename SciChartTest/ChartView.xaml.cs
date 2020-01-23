using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using SciChart.Charting3D.Model;
using SciChartTest.Annotations;

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
	}

	public class ChartViewModel : INotifyPropertyChanged
	{
		private static Random random = new Random();

		public ChartViewModel()
		{
			int xSize = 512;
			int zSize = 512;

			var meshDataSeries = new UniformGridDataSeries3D<double>(xSize, zSize)
			{
				SeriesName = "3D Test",
			};

			for (int x = 0; x < xSize; x++)
			for (int z = 0; z < zSize; z++)
			{
				meshDataSeries[z, x] = 0.5;
			}

			this.ExampleDataSeries = meshDataSeries;
		}

		private UniformGridDataSeries3D<double> exampleDataSeries;

		public UniformGridDataSeries3D<double> ExampleDataSeries
		{
			get { return this.exampleDataSeries; }
			set
			{
				if (Equals(value, this.exampleDataSeries)) return;
				this.exampleDataSeries = value;
				this.OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}