namespace Task1
{
  
    public class Program
    {

        private const string EvenMessage = "Двері відкриваються!";
        private const string OddMessage = "Двері зачинені...";

        public static bool IsEven(int number)
        {
            
            return number % 2 == 0;
        }

        
        public static string GetMessage(int number)
        {
            
            if (IsEven(number))
            {
                return EvenMessage; 
            }
            else
            {
                return OddMessage; 
            }

            
        }

       
        public static void Main(string[] args)
        {
            Console.Write("Введіть ціле число: ");
            if (int.TryParse(Console.ReadLine(), out int inputNumber))
            {
                string message = GetMessage(inputNumber);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Некоректний ввід.");
            }
        }
    }
}