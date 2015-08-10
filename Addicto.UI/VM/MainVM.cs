using Addicto.UI.Utils;
using Addicto.UI.VM.SearchStateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.VM
{
    public class MainVM : BaseVM
    {
        private readonly IKeyboardListener _kbListener;
        private readonly ITextFetcher _textFetcher;
        private readonly IDataServiceFacade _dataServiceFacade;

        public event EventHandler VisibleChanged;

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
                OnVisibleChanged();
            }
        }

        private object _searchStateVM;
        public object SearchStateVM
        {
            get
            {
                return _searchStateVM;
            }
            set
            {
                _searchStateVM = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
            : this(new KeyboardListener(), new TextFetcher(), new DataServiceFacade()) //poor man's injection
        {
        }

        public MainVM(IKeyboardListener kbListener, ITextFetcher textFetcher, IDataServiceFacade dataServiceFacade)
        {
            _kbListener = kbListener;
            _textFetcher = textFetcher;
            _dataServiceFacade = dataServiceFacade;

            _kbListener.MagicCombinationPressed += _kbListener_MagicCombinationPressed;
        }

        private async void _kbListener_MagicCombinationPressed(object sender, EventArgs e)
        {
            string selectedTxt = _textFetcher.FetchSelectedText();
            OnSearchStarted();
            string foundTxt = await _dataServiceFacade.FindArticleAsync(selectedTxt);
            OnSearchComplete(foundTxt);
        }

        private void OnSearchStarted()
        {
            this.SearchStateVM = new InProgressVM();
            this.Visible = true;
        }

        private void OnSearchComplete(string foundTxt)
        {
            if (String.IsNullOrEmpty(foundTxt))
            {
                this.SearchStateVM = new NothingFoundVM();
            }
            else
            {
                this.SearchStateVM = new FoundVM()
                {
                    FoundText = foundTxt
                };
            }
        }

        protected void OnVisibleChanged()
        {
            var handler = this.VisibleChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
