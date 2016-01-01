using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Server
{
    public interface IModuleSelector
    {
        IModule SelectModule(string moduleKey);
    }
}
