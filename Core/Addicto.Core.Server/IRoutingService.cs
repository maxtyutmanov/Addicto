using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Addicto.Core.Server
{
    [ServiceContract]
    public interface IRoutingService
    {
        [OperationContract]
        XmlDocument Get(string query, string moduleKey);

        [OperationContract]
        void Post(string query, XmlDocument articlePayload, string moduleKey);
    }
}
