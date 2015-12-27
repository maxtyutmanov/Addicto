using Addicto.Core.Client.Adapter;
using Addicto.Core.Client.UI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public interface IModuleDescriptor
    {
        IVmFactory VmFactory { get; }
        IDataAdapter DataAdapter { get; }
    }
}
