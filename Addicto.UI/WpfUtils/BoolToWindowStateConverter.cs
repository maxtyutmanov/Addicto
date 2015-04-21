using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Addicto.UI.WpfUtils
{
    public class BoolToWindowStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? WindowState.Normal : WindowState.Minimized;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var windowState = (WindowState)value;

            if (windowState == WindowState.Normal || windowState == WindowState.Maximized)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
