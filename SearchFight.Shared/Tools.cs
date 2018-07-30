using System.Web.Script.Serialization;

namespace SearchFight.Shared
{
    public static class Tools
    {
        public static T Deserialize<T>(string json)
        {
            return (new JavaScriptSerializer()).Deserialize<T>(json);
        }
    }
}
