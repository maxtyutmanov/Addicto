using Addicto.Core.Client.UI.VM;
using Addicto.Core.Client.UI.VM.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public class GlobalContext : IGlobalContext
    {
        #region Properties and Fields

        private readonly object _searchCtxLock = new object();

        private List<IModuleDescriptor> _moduleCtxs;
        public IEnumerable<IModuleDescriptor> ModuleCtxs
        {
            get
            {
                return _moduleCtxs;
            }
        }

        private IModuleDescriptor _currentModule;
        public IModuleDescriptor CurrentModule
        {
            get
            {
                Contract.Requires<InvalidOperationException>(ModuleCtxs != null && ModuleCtxs.Any(), "No modules are defined");

                if (_currentModule == null)
                {
                    _currentModule = ModuleCtxs.First();
                }

                return _currentModule;
            }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null, "Current module context cannot be null");
                Contract.Requires<ArgumentException>(ModuleCtxs.Contains(value), "Current module must be in the list of registered modules");

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

        private SearchContext _currentSearch;
        public SearchContext CurrentSearch
        {
            get
            {
                return _currentSearch;
            }
            private set
            {
                _currentSearch = value;
            }
        }

        public void ClearSearchContext()
        {
            lock (_searchCtxLock)
            {
                if (CurrentSearch != null && CurrentSearch.IsFinished)
                {
                    this.CurrentSearch = null;
                }
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


        public bool InitSearchContext(string query)
        {
            lock (_searchCtxLock)
            {
                if (this.CurrentSearch == null)
                {
                    this.CurrentSearch = new SearchContext()
                    {
                        Query = query
                    };

                    return true;
                }

                return false;
            }
        }
    }
}
