using Addicto.Core.Client.UI.VM.Shared;
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
        private static readonly object _lockObj = new object();

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
            OnMagicCombinationInternal();
        }

        private void OnMagicCombinationInternal()
        {
            //fetch currently selected text, set up search context
            string selectedTxt = _textFetcher.FetchSelectedText();
            if (String.IsNullOrEmpty(selectedTxt))
            {
                //nothing to search
                return;
            }

            if (_globalCtx.TryStartSearch(selectedTxt))
            {
                var searchCtx = _globalCtx.CurrentSearch;

                IModuleDescriptor currentModule = _globalCtx.CurrentModule;

                //asynchronously run the searching process using currently selected module
                Task<object> responseTask = currentModule.DataAdapter.GetAsync(searchCtx);

                //meanwhile, update the UI: ask user to wait for search results
                WaitForReplyVm waitVm = currentModule.VmFactory.CreateWaitForReply(searchCtx);
                _globalCtx.CurrentVm = waitVm;

                //wait for the task to finish, get its result
                object result = responseTask.Result;
                searchCtx.Response = result;

                //update the UI accordingly: show the result to user
                SearchFinishedVm finishedVm = currentModule.VmFactory.CreateSearchFinished(searchCtx);
                _globalCtx.CurrentVm = finishedVm;
            }
        }

        public void ChangeCurrentModule(IModuleDescriptor module)
        {
            //cancel current search operation if any

            //change currently selected module in global context
        }
    }
}
