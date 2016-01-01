using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Addicto.Core.Server
{
    public interface IModule
    {
        XmlDocument Get(string query);
        void Post(string query, XmlDocument articlePayload);
    }
}
