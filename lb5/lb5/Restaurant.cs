using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem
{
    public class Restaurant : IMenuManager
    {
        // Список доступних страв
        private List<MenuItem> _menu;
        // Список активних замовлень (Композиція)
        private List<Order> _orders;

        public Restaurant()
        {
            _menu = new List<MenuItem>();
            _orders = new List<Order>();
            SeedMenu(); // Заповнюємо меню тестовими даними
        }

        private void SeedMenu()
        {
            _menu.Add(new Dish("Борщ", 120, "Перше", 350));
            _menu.Add(new Dish("Карбонара", 210, "Основне", 300));
            _menu.Add(new Dish("Медовик", 90, "Десерт", 150));
            _menu.Add(new Drink("Кава", 50, "Напої", 200, false));
            _menu.Add(new Drink("Пиво", 80, "Алкоголь", 500, true));
            _menu.Add(new Drink("Сок", 40, "Напої", 250, false));
        }

        // --- Реалізація методів інтерфейсу IMenuManager ---
        public void ShowMenu()
        {
            Console.WriteLine("\n=== МЕНЮ РЕСТОРАНУ ===");
            var grouped = _menu.GroupBy(x => x.Category);
            foreach (var group in grouped)
            {
                Console.WriteLine($"--- {group.Key} ---");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.GetDescription()} - {item.Price} грн");
                }
            }
            Console.WriteLine("======================");
        }

        public MenuItem FindItemByName(string name)
        {
            return _menu.FirstOrDefault(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<MenuItem> FindItemsByCategory(string category)
        {
            return _menu.Where(m => m.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // --------------------------------------------------

        public Order CreateOrder(int tableNumber)
        {
            var newOrder = new Order(tableNumber);
            _orders.Add(newOrder);
            Console.WriteLine($"Створено замовлення #{newOrder.OrderId} для столу {tableNumber}.");
            return newOrder;
        }

        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void ShowAllOrders()
        {
            Console.WriteLine("\n=== АКТИВНІ ЗАМОВЛЕННЯ ===");
            if (_orders.Count == 0) Console.WriteLine("Немає активних замовлень.");

            foreach (var order in _orders)
            {
                Console.WriteLine($"ID: {order.OrderId} | Стіл: {order.TableNumber} | Сума: {order.CalculateTotal()} | Статус: {order.Status}");
            }
        }
    }
}