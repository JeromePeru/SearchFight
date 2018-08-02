using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SearchSessionLib
{ 
    public class QueryResult
    {
        public string SearchEngineName { get; set; }
        public string Query { get; set; }
        public long ResultCount { get; set; }


        public override string ToString()
        {
            return String.Format("{0}:{1}", SearchEngineName, ResultCount);
        }
    }
}
