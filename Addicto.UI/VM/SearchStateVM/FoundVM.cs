using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.VM.SearchStateVM
{
    public class FoundVM : BaseVM
    {
        private string _foundText;
        public string FoundText
        {
            get { return _foundText; }
            set
            {
                _foundText = value;
                OnPropertyChanged();
            }
        }
    }
}
