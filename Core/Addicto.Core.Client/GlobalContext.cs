using Addicto.Core.Client.UI.VM;
using Addicto.Core.Client.UI.VM.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public class GlobalContext : IGlobalContext
    {
        #region Properties and Fields

        private List<IModuleDescriptor> _moduleCtxs;

        private IModuleDescriptor _currentModule;
        public IModuleDescriptor CurrentModule
        {
            get
            {
                Contract.Requires<InvalidOperationException>(_moduleCtxs != null && _moduleCtxs.Any(), "No modules are defined");

                if (_currentModule == null)
                {
                    _currentModule = _moduleCtxs.First();
                }

                return _currentModule;
            }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null, "Current module context cannot be null");
                Contract.Requires<ArgumentException>(_moduleCtxs.Contains(value), "Current module must be in the list of registered modules");

                _currentModule = value;
            }
        }

        private BaseVm _currentVm;
        public BaseVm CurrentVm
        {
            get
            {
                return _currentVm;
            }
            set
            {
                _currentVm = value;
            }
        }

        #endregion

        #region .ctor

        public GlobalContext()
        {
            _moduleCtxs = new List<IModuleDescriptor>();
        }

        #endregion

        #region Public methods

        public void RegisterModule(IModuleDescriptor moduleCtx)
        {
            Contract.Requires(moduleCtx != null);
            _moduleCtxs.Add(moduleCtx);
        }

        #endregion

        private SearchContext _currentSearch;
        public SearchContext CurrentSearch
        {
            get
            {
                return _currentSearch;
            }
            set
            {
                _currentSearch = value;
            }
        }
    }
}
