using System;
using System.Linq; 

namespace Task5
{
   
    public class Program
    {
        
        public static double GetAverage(int[] marks)
        {
            if (marks == null || marks.Length == 0) return 0.0;

            long sum = 0; 
            foreach (int mark in marks)
            {
                sum += mark;
            }

        
            return (double)sum / marks.Length;

           
        }

       
        public static int GetMin(int[] marks)
        {
            if (marks == null || marks.Length == 0)
            {
     
                return 0;
            }

            int min = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] < min)
                {
                    min = marks[i];
                }
            }
            return min;

        }


        public static int GetMax(int[] marks)
        {
            if (marks == null || marks.Length == 0)
            {

                return 0;
            }

            int max = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] > max)
                {
                    max = marks[i];
                }
            }
            return max;


        }


        public static void PrintGroupStatistics(int[][] groups)
        {
            if (groups == null || groups.Length == 0)
            {
                Console.WriteLine("Немає даних для аналізу.");
                return;
            }

            Console.WriteLine("📊 Результати аналізу груп студентів:");
            Console.WriteLine(new string('=', 40));

            for (int i = 0; i < groups.Length; i++)
            {
                int[] currentGroupMarks = groups[i];
                int groupNumber = i + 1;

                if (currentGroupMarks == null || currentGroupMarks.Length == 0)
                {
                    Console.WriteLine($"Група {groupNumber}: Дані відсутні.");
                    continue;
                }

 
                double average = GetAverage(currentGroupMarks);
                int min = GetMin(currentGroupMarks);
                int max = GetMax(currentGroupMarks);


                Console.WriteLine(
                    $"Група {groupNumber}: Середній = {average:F0}, " +
                    $"Мінімальний = {min}, " +
                    $"Максимальний = {max}"
                );
            }
            Console.WriteLine(new string('=', 40));
        }


        public static void Main(string[] args)
        {

            int[][] studentGroups = new int[][]
            {
                GenerateRandomMarks(15, 60, 100), 
                GenerateRandomMarks(20, 50, 95),  
                GenerateRandomMarks(10, 90, 100)  
            };

            PrintGroupStatistics(studentGroups);
        }


        private static int[] GenerateRandomMarks(int size, int min, int max)
        {
            Random rand = new Random();
            int[] marks = new int[size];
            for (int i = 0; i < size; i++)
            {

                marks[i] = rand.Next(min, max + 1);
            }
            return marks;
        }
    }
}