using Randomizer.Generator.UI.WPF.ModelViews;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Randomizer.Generator.UI.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		internal MainWindowViewModel Model { get => (MainWindowViewModel)DataContext; }

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Refresh(Object sender, ExecutedRoutedEventArgs? e)
		{
			Model.RefreshGeneratorList();
		}

		private void btnTag_Clicked(Object sender, RoutedEventArgs e)
		{
			Refresh(sender, null);
			var tag = ((ToggleButton)sender).Content.ToString();
			var tags = Model.Tags.Where(t => t.Name.Equals(tag, StringComparison.CurrentCultureIgnoreCase));
			foreach (var selectedTag in tags)
				selectedTag.Selected = !selectedTag.Selected;
		}
	}
}
