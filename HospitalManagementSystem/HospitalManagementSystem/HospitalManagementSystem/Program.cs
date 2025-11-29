using System;
using System.Text;
namespace HospitalManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            HospitalDemo demo = new HospitalDemo();
            demo.Run();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}