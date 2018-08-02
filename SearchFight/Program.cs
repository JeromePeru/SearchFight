using SearchFight.SearchSession;
using SearchFight.SearchSessionLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args?.Length == 0)
            {
                Console.WriteLine("Usage: SearchFight.exe <query1> <query2> ...");
                return;
            }

            try
            {
                
                SearchEngineProvider searchEngineProvider = new SearchEngineProvider();

                SearchSessionLib.SearchSession searchSession = new SearchSessionLib.SearchSession(searchEngineProvider.SearchEngines);
                var searchResaults = searchSession.Execute(args);
                Analyze(searchResaults);
            }

            catch (Exception e)
            {
                Console.WriteLine("The session finished with an unexpected error: ", e);
            }

            Console.ReadLine();
        }


        private static void Analyze(SearchResults searchResults)
        {
            Dictionary<String, List<QueryResult>> searchResultsByQuery = searchResults.SearchResultsByQuery;
            foreach (KeyValuePair<String, List<QueryResult>> queryResults in searchResultsByQuery)
            {
                Console.Write(queryResults.Key + ": ");
                Console.Write(String.Join(" ", queryResults.Value));
                Console.Write(Environment.NewLine);
            }

            Dictionary<String, List<QueryResult>> searchResultsByEngine = searchResults.SearchResultsByEngine;

            foreach (KeyValuePair<String, List<QueryResult>> engineResults in searchResultsByEngine)
            {
                if (engineResults.Value.Count > 0)
                {
                    Console.Write(engineResults.Key + " winner: ");
                    Console.Write(engineResults.Value.First().Query);
                    Console.Write(Environment.NewLine);
                }
            }

            Console.WriteLine("Total winner: " + searchResults.Max.Query);


        }

    }



}
