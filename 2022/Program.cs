using System.IO;
using System.Linq;
using System.Reflection;

namespace _2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Task1\input.txt");
            List<string> text = File.ReadAllLines(path).ToList();

            List<int> elfInvIndexes = new List<int>();

            List<int> elfCalTotals = new List<int>();

            for (int i = 0; i < text.Count; i++)
            {
                if (text[i] == "")
                {
                    elfInvIndexes.Add(i);
                }
            }

            for (int i = 0; i < elfInvIndexes.Count; i += 2)
            {
                int startIndex = elfInvIndexes[i];
                List<string> elfSnackCalories;

                if (i != 252)
                {
                    int endIndex = elfInvIndexes[i + 1];
                    elfSnackCalories = text.GetRange(startIndex, text.Count - startIndex);
                    int removalIndex = endIndex - startIndex;
                    elfSnackCalories.RemoveRange(removalIndex, elfSnackCalories.Count - removalIndex);
                }
                else
                {
                    elfSnackCalories = text.GetRange(startIndex, text.Count - startIndex);
                }


                int elfTotalCalories = 0;

                foreach (var snack in elfSnackCalories)
                {
                    if (snack != "")
                    {
                        elfTotalCalories += int.Parse(snack);
                    }
                }

                elfCalTotals.Add(elfTotalCalories);

            }

            var answerPartOne = elfCalTotals.Max();

            var answerPartTwo = elfCalTotals.OrderByDescending(c => c).ToList().GetRange(0, 3).Sum();

            // Spent an hour trying to work it out this way. Kept this to shame myself

            //foreach (string line in text)
            //{
            //    var currentIndex = text.IndexOf(line) + 1;
            //    var linesToSearch = text.Count - currentIndex;
            //    if ((elfIndexes.Contains(currentIndex - 1) || currentIndex == 1) && currentIndex < text.Count)
            //    {
            //        var egg = text.FindIndex(currentIndex, linesToSearch, t => t == "");
            //        elfIndexes.Add(egg);
            //        //if (egg == 2)
            //        //{
            //        //    elfIndexes.Add(egg);
            //        //}
            //    }

            //}


            Console.WriteLine(answerPartOne);
            Console.WriteLine(answerPartTwo);
        }
    }
}