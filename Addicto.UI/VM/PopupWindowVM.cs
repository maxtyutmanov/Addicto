using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Addicto.UI.VM
{
    public class PopupWindowVM : BaseVM
    {
        private bool _visible;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        private string _foundText;
        public string FoundText
        {
            get
            {
                return _foundText;
            }
            set
            {
                _foundText = value;

                Visible = !String.IsNullOrEmpty(_foundText);

                OnPropertyChanged();
            }
        }
    }
}
