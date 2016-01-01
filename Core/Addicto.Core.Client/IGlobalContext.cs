using Addicto.Core.Client.UI.VM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public interface IGlobalContext
    {
        SearchContext CurrentSearch { get; }
        IModuleDescriptor CurrentModule { get; set; }
        BaseVm CurrentVm { get; set; }

        bool InitSearchContext(string query);
        void ClearSearchContext();
    }
}