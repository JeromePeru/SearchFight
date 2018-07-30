using System;

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
                SearchSessionLib.SearchSession searchSession = new SearchSessionLib.SearchSession();
                searchSession.Initialize();
                searchSession.Execute(args);
                searchSession.Analyze();
            }

            catch (Exception e)
            {
                Console.WriteLine("The session finished with an unexpected error: ", e);
            }

            Console.ReadLine();
        }
    }
}
