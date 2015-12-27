using Addicto.Core.Client.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public class MainController
    {
        private readonly IGlobalContext _globalCtx;
        private readonly ITextFetcher _textFetcher;

        public MainController(IGlobalContext globalCtx, ITextFetcher textFetcher)
        {
            Contract.Requires(globalCtx != null);
            Contract.Requires(textFetcher != null);

            this._globalCtx = globalCtx;
            this._textFetcher = textFetcher;
        }

        public void OnMagicCombination()
        {
            //if there is a search operation in progress, ignore the magic combination. Don't proceed
            if (_globalCtx.CurrentSearch != null)
            {
                return;
            }

            //fetch currently selected text, set up search context
            string selectedTxt = _textFetcher.FetchSelectedText();

            if (!String.IsNullOrEmpty(selectedTxt))
            {
                _globalCtx.CurrentSearch = new SearchContext()
                {
                    Query = selectedTxt
                };
            }

            IModuleDescriptor currentModule = _globalCtx.CurrentModule;

            //run the searching process using currently selected module

            //update UI accordingly
        }

        public void ChangeCurrentModule(IModuleDescriptor module)
        {
            //cancel current search operation if any

            //change currently selected module in global context
        }
    }
}
