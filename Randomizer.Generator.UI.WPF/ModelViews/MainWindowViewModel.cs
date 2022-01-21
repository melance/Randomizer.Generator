using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Input;
using System.Windows;

namespace Randomizer.Generator.UI.WPF.ModelViews
{
	class MainWindowViewModel : BaseClass
	{
		#region Static Methods
		public static String DefinitionPath
		{
			get
			{
				var value = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.DefinitionPath);
				if (!Path.IsPathRooted(value)) Path.Combine(Assembly.GetExecutingAssembly().Location, value);
				return value;
			}
		}
		#endregion

		#region Constructor
		public MainWindowViewModel()
		{
			DataAccess.DataAccess.Instance = new DataAccess.FileSystemDataAccess(DefinitionPath);
			RefreshGeneratorList();
		}
		#endregion

		#region Properties
		public BindingList<GeneratorListItemModelView> GeneratorList
		{
			get => GetProperty(new BindingList<GeneratorListItemModelView>());
			set => SetProperty(value);
		}

		public BindingList<Tag> Tags
		{
			get => GetProperty(new BindingList<Tag>());
			set => SetProperty(value);
		}

		public static RoutedCommand RefreshCommand { get; } = new();

		#endregion

		#region Public Methods
		public void RefreshGeneratorList()
		{
			GeneratorList = new();
			Tags = new();

			foreach (var definition in DataAccess.DataAccess.Instance.GetDefinitionList())
			{
				if (definition.ShowInList)
					GeneratorList.Add(new GeneratorListItemModelView(definition));
			}

			foreach (var tag in DataAccess.DataAccess.Instance.GetTagList())
			{
				Tags.Add(new Tag(tag, false));
			}

			OnPropertyChanged(nameof(GeneratorList));
		}
		#endregion

		#region Private Methods
		#endregion
	}
}
