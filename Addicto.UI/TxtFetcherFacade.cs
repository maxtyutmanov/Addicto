using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI
{
    public static class TxtFetcherFacade
    {
        [DllImport("Addicto.TxtFetcher.dll")]
        [return:MarshalAs(UnmanagedType.LPWStr)]
        public static extern string FetchSelectedText();
    }
}