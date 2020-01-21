using System.Windows;
using System.Windows.Controls;

namespace SciChartTest
{
	public class ChartTemplateSelector : DataTemplateSelector
	{
		public DataTemplate ChartTemplate { get; set; }
		public DataTemplate OtherTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is ChartViewModel)
				return this.ChartTemplate;
			return this.OtherTemplate;
		}
	}
}