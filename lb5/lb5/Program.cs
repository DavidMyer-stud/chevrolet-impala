using System;
using System.Text;

namespace RestaurantSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування для коректного відображення кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Restaurant restaurant = new Restaurant();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- УПРАВЛІННЯ РЕСТОРАНОМ ---");
                Console.WriteLine("1. Переглянути меню");
                Console.WriteLine("2. Створити нове замовлення");
                Console.WriteLine("3. Додати позицію в замовлення");
                Console.WriteLine("4. Переглянути список замовлень");
                Console.WriteLine("5. Деталі замовлення (Чек) та Зміна статусу");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        restaurant.ShowMenu();
                        break;

                    case "2":
                        Console.Write("Введіть номер столика: ");
                        if (int.TryParse(Console.ReadLine(), out int tableNum))
                        {
                            restaurant.CreateOrder(tableNum);
                        }
                        else Console.WriteLine("Некоректний номер.");
                        break;

                    case "3":
                        AddToOrderUI(restaurant);
                        break;

                    case "4":
                        restaurant.ShowAllOrders();
                        break;

                    case "5":
                        ManageOrderUI(restaurant);
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невідома команда.");
                        break;
                }
            }
        }

        // Допоміжний метод для додавання страв
        static void AddToOrderUI(Restaurant r)
        {
            Console.Write("Введіть ID замовлення: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId)) return;

            var order = r.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдено.");
                return;
            }

            Console.Write("Введіть назву страви/напою (або частину назви): ");
            string searchName = Console.ReadLine();
            var item = r.FindItemByName(searchName);

            if (item != null)
            {
                order.AddItem(item);
            }
            else
            {
                Console.WriteLine("Такої позиції в меню не знайдено.");
            }
        }

        // Допоміжний метод для керування статусом та перегляду чеку
        static void ManageOrderUI(Restaurant r)
        {
            Console.Write("Введіть ID замовлення: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId)) return;

            var order = r.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдено.");
                return;
            }

            order.PrintReceipt();

            Console.WriteLine("Змінити статус? (1 - Готується, 2 - Готове, 3 - Оплачено, Enter - пропустити)");
            string statusInput = Console.ReadLine();

            if (statusInput == "1") order.ChangeStatus(OrderStatus.InProgress);
            else if (statusInput == "2") order.ChangeStatus(OrderStatus.Ready);
            else if (statusInput == "3") order.ChangeStatus(OrderStatus.Paid);

            if (statusInput == "1" || statusInput == "2" || statusInput == "3")
                Console.WriteLine("Статус оновлено.");
        }
    }
}