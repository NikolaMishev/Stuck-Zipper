using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var idealNumberOfDigits = CalculateIdealNumberOfDigits(firstList, secondList);

            RemoveElementsWithNonIdealNumberOfDigitsFromList(firstList, idealNumberOfDigits);
            RemoveElementsWithNonIdealNumberOfDigitsFromList(secondList, idealNumberOfDigits);

            var insertionIndex = 1;

            for (int i = 0; i < firstList.Count; i++)
            {
                var currentElement = firstList[i];
                secondList.Insert(Math.Min(insertionIndex, secondList.Count), currentElement);
                insertionIndex += 2;
            }

            Console.WriteLine(string.Join(" ", secondList));

        }

        static void RemoveElementsWithNonIdealNumberOfDigitsFromList(List<int> list, int idealNumberOfDigits)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var currentElement = list[i];
                var currentNumberOfDigits = CalculateNumberOfDigits(currentElement);
                if (currentNumberOfDigits > idealNumberOfDigits)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static int CalculateIdealNumberOfDigits(List<int> firstList, List<int> secondList)
        {
            var idealNumberOfDigits = int.MaxValue;

            foreach (var item in firstList)
            {
                var numberOfDigits = CalculateNumberOfDigits(item);

                if (numberOfDigits < idealNumberOfDigits)
                {
                    idealNumberOfDigits = numberOfDigits;
                }
            }

            foreach (var item in secondList)
            {
                var numberOfDigits = CalculateNumberOfDigits(item);

                if (numberOfDigits < idealNumberOfDigits)
                {
                    idealNumberOfDigits = numberOfDigits;
                }
            }
            return idealNumberOfDigits;
        }

        static int CalculateNumberOfDigits(int number)
        {
            number = Math.Abs(number);

            var numberOfDigits = 0;

            while (number > 0)
            {
                numberOfDigits++;
                number /= 10;
            }
            return numberOfDigits;
        }
    }
}
