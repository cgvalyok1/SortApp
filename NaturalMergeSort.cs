using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SortApp
{
    internal class NaturalMergeSort
    {
        public static void SortFile(string inputFilePath, string outputFilePath)
        {
            List<int> numbers = ReadNumbersFromFile(inputFilePath);
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<int> sortedNumbers = NaturalMergeSortAlgorithm(numbers);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            MessageBox.Show($"Время сортировки: {elapsedTime.TotalMilliseconds} мс");
            WriteNumbersToFile(sortedNumbers, outputFilePath);
        }

        private static List<int> NaturalMergeSortAlgorithm(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            List<int> sortedNumbers = new List<int>(numbers);
            List<int> tempNumbers = new List<int>(numbers.Count);

            while (!IsSorted(sortedNumbers))
            {
                List<int> mergedNumbers = new List<int>(numbers.Count);
                List<int> currentSequence = new List<int>();
                int previousNumber = int.MinValue;
                int currentNumber;
                int i = 0;

                while (i < sortedNumbers.Count)
                {
                    currentNumber = sortedNumbers[i];

                    if (currentNumber < previousNumber)
                    {
                        mergedNumbers.AddRange(MergeSequences(currentSequence, tempNumbers));
                        currentSequence.Clear();
                    }

                    currentSequence.Add(currentNumber);
                    previousNumber = currentNumber;

                    if (i == sortedNumbers.Count - 1)
                    {
                        mergedNumbers.AddRange(MergeSequences(currentSequence, tempNumbers));
                        if (mergedNumbers.SequenceEqual(sortedNumbers))
                        {
                            break;
                        }
                    }

                    i++;
                }

                sortedNumbers.Clear();
                sortedNumbers.AddRange(mergedNumbers);
            }

            return sortedNumbers;
        }

        private static List<int> MergeSequences(List<int> sequence1, List<int> sequence2)
        {
            List<int> mergedSequence = new List<int>();
            int index1 = 0;
            int index2 = 0;

            while (index1 < sequence1.Count && index2 < sequence2.Count)
            {
                if (sequence1[index1] <= sequence2[index2])
                {
                    mergedSequence.Add(sequence1[index1]);
                    index1++;
                }
                else
                {
                    mergedSequence.Add(sequence2[index2]);
                    index2++;
                }
            }

            while (index1 < sequence1.Count)
            {
                mergedSequence.Add(sequence1[index1]);
                index1++;
            }

            while (index2 < sequence2.Count)
            {
                mergedSequence.Add(sequence2[index2]);
                index2++;
            }

            return mergedSequence;
        }

        private static bool IsSorted(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> ReadNumbersFromFile(string filePath)
        {
            string numbersString = File.ReadAllText(filePath);
            List<int> numbers = numbersString.Split(' ').Select(int.Parse).ToList();
            return numbers;
        }

        private static void WriteNumbersToFile(List<int> numbers, string filePath)
        {
            string numbersString = string.Join(" ", numbers);
            File.WriteAllText(filePath, numbersString);
        }
    }
}
