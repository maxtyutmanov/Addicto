using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.Core.Client.Adapter
{
    public interface IDataAdapter
    {
        Task<object> GetAsync(string query);
        Task PostAsync(string query, object article);
    }
}
