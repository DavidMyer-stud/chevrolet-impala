using System;
using System.Linq;

namespace Task4
{
    public class Program
    {
 
        private const double Epsilon = 0.0001;

  
        public static bool IsValidTriangle(double a, double b, double c)
        {

            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }

            bool condition1 = a + b > c;
            bool condition2 = a + c > b;
            bool condition3 = b + c > a;

            return condition1 && condition2 && condition3;
        }


        public static double GetPerimeter(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {

                throw new ArgumentException("Сторони не можуть утворити трикутник.");
            }


            return a + b + c;
        }


        public static double GetArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
 
                throw new ArgumentException("Сторони не можуть утворити трикутник.");
            }

            double s = GetPerimeter(a, b, c) / 2.0;


            double areaSquared = s * (s - a) * (s - b) * (s - c);


            if (areaSquared < 0) return 0.0;

            return Math.Sqrt(areaSquared);
        }


        public static string GetTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {

                throw new ArgumentException("Сторони не можуть утворити трикутник.");
            }

            if (Math.Abs(a - b) < Epsilon && Math.Abs(b - c) < Epsilon)
            {
                return "рівносторонній";
            }


            double[] sides = { a, b, c };
            Array.Sort(sides);
            double side1 = sides[0];
            double side2 = sides[1];
            double hypotenuse = sides[2];


            double sumOfSquares = Math.Pow(side1, 2) + Math.Pow(side2, 2);
            double hypotenuseSquared = Math.Pow(hypotenuse, 2);

            if (Math.Abs(sumOfSquares - hypotenuseSquared) < Epsilon)
            {

                return "прямокутний";
            }


            if (Math.Abs(a - b) < Epsilon || Math.Abs(a - c) < Epsilon || Math.Abs(b - c) < Epsilon)
            {

                return "рівнобедрений";
            }


            return "довільний";
        }



        public static void Main(string[] args)
        {

            double a = 3, b = 4, c = 5;

            Console.WriteLine($"📏 Сторони: a={a}, b={b}, c={c}");
            Console.WriteLine(new string('-', 30));

            if (IsValidTriangle(a, b, c))
            {
                try
                {
                    double perimeter = GetPerimeter(a, b, c);
                    double area = GetArea(a, b, c);
                    string type = GetTriangleType(a, b, c);

                    Console.WriteLine($"✅ Трикутник існує.");
                    Console.WriteLine($"✨ Периметр (P): {perimeter:F2}");
                    Console.WriteLine($"✨ Площа (S):    {area:F2}");
                    Console.WriteLine($"✨ Тип:          {type}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"❌ Помилка обчислення: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"❌ Трикутник НЕ існує (порушена нерівність або сторони не додатні).");
            }
        }
    }
}