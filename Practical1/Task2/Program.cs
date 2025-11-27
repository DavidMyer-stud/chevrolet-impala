using System;
using System.Linq; 

namespace Task2
{
    public class Program
    {

        private static readonly Random random = new Random();


        public static int[] GenerateRandomArray(int size, int min, int max)
        {

            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(min, max + 1);
            }
            return numbers;
        }


        public static int GetSum(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;

        }

        public static double GetAverage(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0.0;


            return (double)GetSum(numbers) / numbers.Length;

        }


        public static int GetMin(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            int min = numbers[0]; 
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;


        }

 
        public static int GetMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            int max = numbers[0]; 
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;

          
        }

        public static void Main(string[] args)
        {
            int arraySize = 10;
            int minRange = 1;
            int maxRange = 100;

            int[] array = GenerateRandomArray(arraySize, minRange, maxRange);

            Console.WriteLine($"✅ Згенерований масив ({arraySize} чисел від {minRange} до {maxRange}):");
            Console.WriteLine($"[{string.Join(", ", array)}]");
            Console.WriteLine(new string('-', 30));

            int sum = GetSum(array);
            double average = GetAverage(array);
            int min = GetMin(array);
            int max = GetMax(array);

            Console.WriteLine($"✨ Сума:      {sum}");

            Console.WriteLine($"✨ Середнє:   {average:F2}");
            Console.WriteLine($"✨ Мінімум:   {min}");
            Console.WriteLine($"✨ Максимум:  {max}");
        }
    }
}