using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business
{
    public class IdBasedQueryRouter : IQueryRouter
    {
        private object _initLockObj = new object();

        public delegate DataSource DataSourceCreator(ArticleQuery query);

        private IDictionary<int, DataSourceCreator> _routingTable;

        public IdBasedQueryRouter()
        {
            _routingTable = new Dictionary<int, DataSourceCreator>();
        }

        public DataSource RouteQuery(Model.ArticleQuery query)
        {
            int targetDsId = query.DataSourceId;
            DataSourceCreator dsCreator = null;
             
            if (_routingTable.TryGetValue(targetDsId, out dsCreator))
            {
                DataSource createdDs = dsCreator(query);
                return createdDs;
            }
            else
            {
                string errorMsg = String.Format("Error when trying to route the request: System cannot find the data source with ID = {0}", targetDsId);
                throw new InvalidOperationException(errorMsg);
            }
        }

        public void RegisterRoute(int dataSourceId, DataSourceCreator creator)
        {
            lock (_initLockObj)
            {
                bool alreadyExists = _routingTable.ContainsKey(dataSourceId);

                if (alreadyExists)
                {
                    string errorMsg = String.Format("Route for the data source with ID = {0} is already registered", dataSourceId);
                    throw new InvalidOperationException(errorMsg);
                }

                _routingTable.Add(dataSourceId, creator);
            }
        }
    }
}
