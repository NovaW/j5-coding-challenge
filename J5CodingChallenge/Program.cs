using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace J5CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFileName = args[0];
            var outputFileName = args[1];
            var inputLines = File.ReadAllLines(inputFileName);
            
            var maxScorers = GetMaxScorers(inputLines);

            var linesWithSpaces = maxScorers.Select(x => x.FirstName + " " + x.LastName + " " + x.Score.ToString());

            File.Delete(outputFileName);
            File.WriteAllLines(outputFileName, linesWithSpaces);
        }

        private static List<StudentScore> GetMaxScorers(string[] inputLines){
            var maxScorers = new List<StudentScore>();
            int maxScore = 0;

            foreach(var line in inputLines){
                var splitLine = line.Split(",");
                var studentScore = new StudentScore{
                    FirstName = splitLine[0],
                    LastName = splitLine[1],
                    Score = int.Parse(splitLine[2])
                };

                if(studentScore.Score == maxScore){
                    maxScorers.Add(studentScore);
                }
                else if(studentScore.Score > maxScore){
                    maxScore = studentScore.Score;
                    maxScorers.Clear();
                    maxScorers.Add(studentScore);
                }
            }
            return maxScorers;
        }
    }

    class StudentScore
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}
