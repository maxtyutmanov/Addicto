using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Server.ErrorHandling
{
    public class ModuleNotRegisteredException : Exception
    {
        public ModuleNotRegisteredException(string moduleKey)
            : base(String.Format("Module with key {0} is not registered on the server", moduleKey))
        {

        }
    }
}
