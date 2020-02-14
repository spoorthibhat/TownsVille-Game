using Game.Models;
using Game.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Game.Helpers
{
    /// <summary>
    /// This converter is used by the Pickers, to change from the picker value to the integer value 
    /// from string or vice versa. This allows the convert in the picker to be data bound back and forth the model
    /// the picker requires this because the picker must be a string, but the enum is a value...
    /// </summary>
    class ItemModelGuidConvertor : IValueConverter
    {
        /// <summary>
        /// Parses the string to integer.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            return ItemIndexViewModel.Instance.Dataset.Where(a =>
                        a.Id == ((ItemModel)value).Id)
                        .FirstOrDefault(); 
        }


        /// <summary>
        /// Converts the integer value to string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((ItemModel)value).Id;
            return null;
        }
    }
}
