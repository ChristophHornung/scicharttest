using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.RenderableSeries;
using SciChartTest.Annotations;

namespace SciChartTest
{
	public class ChartViewModel : INotifyPropertyChanged
	{
		private static Random random = new Random();
		private bool up = true;

		public ChartViewModel()
		{
			this.up = true;
			this.RefreshData();
			this.Palette = new GradientColorPalette()
			{
				ContourColor = Colors.Black,
				ContourStrokeThickness = 2,
			};
			this.Palette.GradientStops.Add(new GradientStop(Colors.Red, 1));
			this.Palette.GradientStops.Add(new GradientStop(Colors.Green, 0));
		}

		private UniformGridDataSeries3D<double> exampleDataSeries;
		private GradientColorPalette palette;

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

		public GradientColorPalette Palette
		{
			get { return this.palette; }
			set
			{
				if (Equals(value, this.palette)) return;
				this.palette = value;
				this.OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void RefreshData()
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
				if (this.up)
				{
					meshDataSeries[z, x] = x > xSize / 2 ? 1 : 0.5;
				}
				else
				{
					meshDataSeries[z, x] = x > xSize / 2 ? 0.5 : 1;
				}
			}

			this.ExampleDataSeries = meshDataSeries;
		}

		public void SwitchChart()
		{
			this.up = !this.up;
			this.RefreshData();
		}

		public void SetSeriesNull()
		{
			this.ExampleDataSeries = null;
		}

		public void SetPaletteNull()
		{
			this.Palette = null;
		}
	}
}