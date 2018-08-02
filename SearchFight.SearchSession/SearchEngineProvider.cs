using SearchFight.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SearchSession
{
    public class SearchEngineProvider
    {
        [ImportMany]
        private IEnumerable<Lazy<ISearchEngine>> _searchEngines;

        private readonly String PluginsFolder = "Plugins";

        public SearchEngineProvider()
        {
            Initialize();
        }

        private bool Initialize()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            String searchEngineFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), PluginsFolder);
            catalog.Catalogs.Add(new DirectoryCatalog(searchEngineFolder));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            return catalog.Catalogs.Count > 0;
        }

        public IEnumerable<Lazy<ISearchEngine>> SearchEngines => _searchEngines;


    }
}
