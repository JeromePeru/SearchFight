
using SearchFight.Shared;

namespace SearchFight.Contract
{
    public interface ISearchEngine
    {
        string Name { get; }
        long GetQueryResult(string query);
    }
}
