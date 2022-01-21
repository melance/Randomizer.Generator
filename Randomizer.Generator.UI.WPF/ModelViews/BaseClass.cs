using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Randomizer.Generator.UI.WPF.ModelViews
{
	public class BaseClass : INotifyPropertyChanged
	{
		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Members
		private readonly Dictionary<String, Object> _propertyValues = new();
		#endregion

		#region Protected Methods
		/// <summary>
		/// Gets the value of a property
		/// </summary>
		protected virtual T GetProperty<T>(T defaultValue, [CallerMemberName] String propertyName = "")
		{
			if (!_propertyValues.ContainsKey(propertyName))
			{
				_propertyValues[propertyName] = defaultValue;
				return defaultValue;
			}
			return (T)_propertyValues[propertyName];
		}

		/// <summary>
		/// Sets the value of a property
		/// </summary>
		protected virtual void SetProperty<T>(T value, [CallerMemberName] String propertyName = "")
		{
			_propertyValues[propertyName] = value;
			OnPropertyChanged(propertyName);
		}

		/// <summary>
		/// Raises the property change event
		/// </summary>
		protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		} 
		#endregion
	}
}
