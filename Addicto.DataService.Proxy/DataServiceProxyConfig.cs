using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Addicto.DataService.Client
{
    public static class DataServiceProxyConfig
    {
        private static string _rootUrl;
        public static string RootUrl
        {
            get
            {
                if (_rootUrl == null)
                {
                    string urlFromConfig = ConfigurationManager.AppSettings["DataSvcRoot"];
                    if (String.IsNullOrEmpty(urlFromConfig))
                    {
                        throw new ConfigurationErrorsException("DataSvcRoot element is not defined");
                    }

                    _rootUrl = urlFromConfig;
                }

                return _rootUrl;
            }
        }
    }
}
