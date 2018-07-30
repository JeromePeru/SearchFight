using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Shared
{
    [Serializable()]
    public class SearchEngineException : Exception
    {
        public SearchEngineException() : base() { }
        public SearchEngineException(string message) : base(message) { }
        public SearchEngineException(string message, Exception inner) : base(message, inner) { }

        protected SearchEngineException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
