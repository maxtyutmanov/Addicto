using Addicto.Core.Server.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Addicto.Core.Server
{
    public class RoutingService : IRoutingService
    {
        private readonly IModuleSelector _moduleSelector;

        public RoutingService(IModuleSelector moduleSelector)
        {
            Contract.Requires(moduleSelector != null);

            this._moduleSelector = moduleSelector;
        }

        public XmlDocument Get(string query, string moduleKey)
        {
            IModule module = _moduleSelector.SelectModule(moduleKey);
            
            if (module != null)
            {
                return module.Get(query);
            }
            else
            {
                throw new ModuleNotRegisteredException(moduleKey);
            }
        }

        public void Post(string query, XmlDocument articlePayload, string moduleKey)
        {
            IModule module = _moduleSelector.SelectModule(moduleKey);

            if (module != null)
            {
                module.Post(query, articlePayload);
            }
            else
            {
                throw new ModuleNotRegisteredException(moduleKey);
            }
        }
    }
}
