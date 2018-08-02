using SearchFight.Contract;
using SearchFight.SearchSession;
using System;
using System.Collections.Generic;

namespace SearchFight.SearchSessionLib
{
    public class SearchSession
    {
        private readonly IEnumerable<Lazy<ISearchEngine>> _searchEngines;

        public SearchSession(IEnumerable<Lazy<ISearchEngine>> searchEngines)
        {
            _searchEngines = searchEngines;
        }

        public SearchResults Execute(params string[] queries)
        {
            SearchResults _searchResults = new SearchResults();

            foreach (string query in queries)
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

            return _searchResults;
        }
    }
}
