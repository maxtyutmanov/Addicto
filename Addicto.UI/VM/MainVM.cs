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
        private PopupWindowVM _popupWindowVM;

        public PopupWindowVM PopupVM
        {
            get
            {
                return _popupWindowVM;
            }
            set
            {
                _popupWindowVM = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
            : this(new KeyboardListener(), new TextFetcher(), new DataServiceFacade()) //poor man's injection
        {
            this._popupWindowVM = new PopupWindowVM();
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
            string foundTxt = await _dataServiceFacade.FindArticleAsync(selectedTxt);

            _popupWindowVM.FoundText = foundTxt;
        }
    }
}
