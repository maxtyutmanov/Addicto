using Addicto.UI.Utils;
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

        private string _displayText;
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;

                OnPropertyChanged();
            }
        }

        private bool _searchInProgress;
        public bool SearchInProgress
        {
            get
            {
                return _searchInProgress;
            }
            private set
            {
                _searchInProgress = value;

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
            this.DisplayText = "";
            this.SearchInProgress = true;
            this.Visible = true;
        }

        private void OnSearchComplete(string foundTxt)
        {
            if (String.IsNullOrEmpty(foundTxt))
            {
                this.DisplayText = "Ничего не найдено";
            }
            else
            {
                this.DisplayText = foundTxt;
            }
            this.SearchInProgress = false;
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
