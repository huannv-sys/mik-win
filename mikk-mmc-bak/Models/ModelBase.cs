using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Base class for all models
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the property value and raises the PropertyChanged event if the value has changed
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="storage">The backing field reference</param>
        /// <param name="value">The new value</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>True if the value was changed, false otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Sets the property value and raises the PropertyChanged event if the value has changed, and executes the action
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="storage">The backing field reference</param>
        /// <param name="value">The new value</param>
        /// <param name="action">The action to execute</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>True if the value was changed, false otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, Action action, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            action?.Invoke();

            return true;
        }

        /// <summary>
        /// Sets the property value and raises the PropertyChanged event if the value has changed, and executes the function
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="storage">The backing field reference</param>
        /// <param name="value">The new value</param>
        /// <param name="function">The function to execute</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>True if the value was changed, false otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, Func<bool> function, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return function != null && function();
        }

        /// <summary>
        /// Sets the property values and raises the PropertyChanged events for multiple properties
        /// </summary>
        /// <param name="propertyNames">The names of the properties that changed</param>
        protected void OnPropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event for all properties
        /// </summary>
        protected void RefreshAllProperties()
        {
            OnPropertyChanged(string.Empty);
        }
    }
}