using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace NameDataGenerator
{
    class Program
    {
        private static string outputFileName = "StudentScores.txt";
        static void Main(string[] args)
        {
            var firstNames = File.ReadAllLines("FirstNames.txt");
            var lastNames = File.ReadAllLines("LastNames.txt");

            var firstNamesCount = firstNames.Count();
            var lastNamesCount = lastNames.Count();

            var random = new Random();

            File.Delete(outputFileName);
            var lines = new List<string>();
            for(int i = 0; i < 100; i++){
                var firstName = firstNames[random.Next(0, firstNamesCount)];
                var lastName = lastNames[random.Next(0, lastNamesCount)];
                var score = random.Next(0, 100);
                var line = firstName.Trim() +","+ lastName.Trim()+","+score;
                lines.Add(line);
            }
            File.WriteAllLines(outputFileName, lines);

        }
    }
}
