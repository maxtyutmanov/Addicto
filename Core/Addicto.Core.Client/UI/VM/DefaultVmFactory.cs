using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client.UI.VM
{
    public class DefaultVmFactory : IVmFactory
    {
        public Shared.WaitForReplyVm CreateWaitForReply(SearchContext ctx)
        {
            return new Shared.WaitForReplyVm();
        }

        public Shared.SearchFinishedVm CreateSearchFinished(SearchContext ctx)
        {
            return new Shared.SearchFinishedVm();
        }

        public Shared.PostNewEntryVm CreatePostNewEntry(SearchContext ctx)
        {
            return new Shared.PostNewEntryVm();
        }
    }
}
