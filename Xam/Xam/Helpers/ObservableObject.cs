using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xam.Helpers
{
    /// <summary>
    /// Observable object with INotifyPropertyChanged implemented
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Get property value
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            if (properties.TryGetValue(propertyName, out object value))
            {
                return (T)value;
            }

            return default(T);
        }

        /// <summary>
        /// Set property value
        /// </summary>
        /// <typeparam name="T">Propery type</typeparam>
        /// <param name="value">New property value</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Result of operation</returns>
        protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            if (EqualityComparer<T>.Default.Equals(value, GetProperty<T>(propertyName))) return false;

            properties[propertyName] = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}