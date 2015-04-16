using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Addicto.UI.VM
{
    public class PopupWindowVM : DependencyObject
    {
        public bool Visible
        {
            get { return (bool)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool), typeof(PopupWindowVM), new PropertyMetadata(false));

        public string FoundText
        {
            get { return (string)GetValue(FoundTextProperty); }
            set { SetValue(FoundTextProperty, value); }
        }

        public static readonly DependencyProperty FoundTextProperty =
            DependencyProperty.Register("FoundText", typeof(string), typeof(PopupWindowVM), new PropertyMetadata(String.Empty));
    }
}
