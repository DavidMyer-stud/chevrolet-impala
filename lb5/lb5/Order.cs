using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem
{
    public class Order
    {
        private static int _idCounter = 1000; 

        public int OrderId { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        
        private List<MenuItem> _items;

        public Order(int tableNumber)
        {
            OrderId = ++_idCounter;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
            _items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            if (Status == OrderStatus.Paid)
            {
                Console.WriteLine("Помилка: Замовлення вже оплачено і закрите.");
                return;
            }
            _items.Add(item);
            Console.WriteLine($"-> {item.Name} додано до замовлення #{OrderId}");
        }

        public void RemoveItem(string name)
        {
            if (Status == OrderStatus.Paid) return;

            var item = _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"-> {name} видалено із замовлення.");
            }
            else
            {
                Console.WriteLine("Позицію не знайдено в замовленні.");
            }
        }

        public decimal CalculateTotal()
        {
            return _items.Sum(x => x.Price);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"\n--- ЧЕК ЗАМОВЛЕННЯ #{OrderId} (Стіл {TableNumber}) ---");
            Console.WriteLine($"Статус: {Status}");

            foreach (var item in _items)
            {
                // Виклик поліморфного методу
                Console.Write($"{item.GetDescription()} ... {item.Price} грн");

                // DOWNCAST: Перевірка, чи це напій, щоб вивести попередження
                if (item is Drink drink)
                {
                    if (drink.IsAlcoholic) Console.Write(" [18+]");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"ВСЬОГО ДО СПЛАТИ: {CalculateTotal()} грн\n");
        }
    }
}