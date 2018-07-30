using SearchFight.Contract;
using SearchFight.SearchSession;
using SearchFight.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SearchFight.SearchSessionLib
{
    public class SearchSession
    {
        private readonly String PluginsFolder = "Plugins";

        [ImportMany]
        private IEnumerable<Lazy<ISearchEngine>> _searchEngines;

        SearchResults _searchResults;

        public SearchSession()
        {
            _searchResults = new SearchResults();
        }

        public bool Initialize()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            String searchEngineFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), PluginsFolder);
            catalog.Catalogs.Add( new DirectoryCatalog(searchEngineFolder));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            return catalog.Catalogs.Count > 0;
        }

        public void Execute(params string[] queries)
        {
            foreach(string query in queries)
            {
                foreach (Lazy<ISearchEngine> searchEngine in _searchEngines)
                {
                    QueryResult queryResult = new QueryResult
                    {
                        Query = query,
                        SearchEngineName = searchEngine.Value.Name,
                        ResultCount = searchEngine.Value.GetQueryResult(query)
                    };

                    _searchResults.Add(queryResult);
                }
            }
        }

        public void Analyze()
        {
            Dictionary<String, List<QueryResult>> searchResultsByQuery = _searchResults.SearchResultsByQuery;
            foreach(KeyValuePair<String, List<QueryResult>> queryResults in searchResultsByQuery)
            {
                Console.Write(queryResults.Key + ": ");
                Console.Write(String.Join(" ", queryResults.Value));
                Console.Write(Environment.NewLine);
            }

            Dictionary<String, List<QueryResult>> searchResultsByEngine = _searchResults.SearchResultsByEngine;

            foreach (KeyValuePair<String, List<QueryResult>> engineResults in searchResultsByEngine)
            {
                if (engineResults.Value.Count > 0)
                {
                    Console.Write(engineResults.Key + " winner: ");
                    Console.Write(engineResults.Value.First().Query);
                    Console.Write(Environment.NewLine);
                }
            }

            Console.WriteLine("Total winner: " + _searchResults.Max.Query);


        }


    }
}
