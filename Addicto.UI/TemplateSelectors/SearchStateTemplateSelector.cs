using Addicto.UI.VM.SearchStateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Addicto.UI.TemplateSelectors
{
    public class SearchStateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InProgressTemplate { get; set; }
        public DataTemplate NothingFoundTemplate { get; set; }
        public DataTemplate FoundTemplate { get; set; }

        private Dictionary<Type, Func<DataTemplate>> _map;

        public SearchStateTemplateSelector()
        {
            _map = new Dictionary<Type, Func<DataTemplate>>()
            {
                { typeof(InProgressVM), () => InProgressTemplate },
                { typeof(NothingFoundVM), () => NothingFoundTemplate },
                { typeof(FoundVM), () => FoundTemplate }
            };
        }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            CheckIfInitialized();

            Func<DataTemplate> templateRetriever = null;
            
            if (item != null && _map.TryGetValue(item.GetType(), out templateRetriever))
            {
                return templateRetriever.Invoke();
            }

            return NothingFoundTemplate;
        }

        private void CheckIfInitialized()
        {
            if (InProgressTemplate == null || NothingFoundTemplate == null || FoundTemplate == null)
            {
                throw new InvalidOperationException(String.Format("One or more templates are not initialized in {0} object", this.GetType().Name));
            }
        }
    }
}
