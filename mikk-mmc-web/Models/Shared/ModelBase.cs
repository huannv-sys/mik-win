using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Base class for models that support property change notification
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set property value and raise property changed event if changed
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="storage">Reference to backing field</param>
        /// <param name="value">New value</param>
        /// <param name="propertyName">Name of property</param>
        /// <returns>True if property was changed</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Raise property changed event
        /// </summary>
        /// <param name="propertyName">Name of property</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
