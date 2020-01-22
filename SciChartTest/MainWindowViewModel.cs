using System.ComponentModel;
using System.Runtime.CompilerServices;
using SciChartTest.Annotations;

namespace SciChartTest
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private object chart;

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindowViewModel()
		{
			this.Chart = new ChartViewModel();
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public object Chart
		{
			get { return this.chart; }
			set
			{
				if (Equals(value, this.chart)) return;
				this.chart = value;
				this.OnPropertyChanged();
			}
		}

		public void SetSeries()
		{
			if (this.Chart is ChartViewModel chartViewModel)
			{
				chartViewModel.SetSeriesNull();
			}
		}

		public void SetPaletteNull()
		{
			if (this.Chart is ChartViewModel chartViewModel)
			{
				chartViewModel.SetPaletteNull();
			}
		}

		public void SetDataContextNull()
		{
			this.Chart = null;
		}
	}
}