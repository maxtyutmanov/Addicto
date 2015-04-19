using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.Utils
{
    public class TextFetcher : ITextFetcher
    {
        [DllImport("Addicto.TxtFetcher.dll", EntryPoint = "FetchSelectedText")]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        private static extern string FetchSelectedTextUnmanaged();

        public string FetchSelectedText()
        {
            return TextFetcher.FetchSelectedTextUnmanaged();
        }
    }
}
