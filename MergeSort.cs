using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortApp
{
    internal class MergeSort
    {
        private static int mergeCount; // Переменная для подсчета количества совершенных пересылок

        public static void SortFile(string inputFilePath, string outputFilePath)
        {
            List<int> numbers = ReadNumbersFromFile(inputFilePath);
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<int> sortedNumbers = PairwiseMergeSortAlgorithm(numbers);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            MessageBox.Show($"Время сортировки: {elapsedTime.TotalMilliseconds} мс\nКоличество сляиний: {mergeCount}");
            WriteNumbersToFile(sortedNumbers, outputFilePath);
        }

        private static List<int> PairwiseMergeSortAlgorithm(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            int middle = numbers.Count / 2;
            List<int> left = new List<int>(numbers.GetRange(0, middle));
            List<int> right = new List<int>(numbers.GetRange(middle, numbers.Count - middle));

            left = PairwiseMergeSortAlgorithm(left);
            right = PairwiseMergeSortAlgorithm(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> mergedList = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    mergedList.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    mergedList.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                mergedList.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                mergedList.Add(right[rightIndex]);
                rightIndex++;
            }
            mergeCount++;
            return mergedList;
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
