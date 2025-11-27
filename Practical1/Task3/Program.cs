namespace Task3
{
    public class Program
    {

        private const string Child = "Ви дитина";
        private const string Teenager = "Підліток";
        private const string Adult = "Дорослий";
        private const string Senior = "Пенсіонер";
        private const string Unreal = "Нереальний вік";


        public static string ClassifyAge(int age)
        {

            if (age < 0 || age > 120)
            {
                return Unreal;
            }


            if (age < 12)
            {
                return Child;
            }

            else if (age <= 17)
            {

                return Teenager;
            }

            else if (age <= 59)
            {

                return Adult;
            }
 
            else 
            {
                return Senior;
            }
        }


        public static void Main(string[] args)
        {
            Console.Write("Введіть свій вік: ");
            if (int.TryParse(Console.ReadLine(), out int inputAge))
            {
                string category = ClassifyAge(inputAge);
                Console.WriteLine($"🎉 Категорія вашого віку: {category}");
            }
            else
            {
                Console.WriteLine("❌ Некоректний ввід. Будь ласка, введіть ціле число.");
            }
        }
    }
}