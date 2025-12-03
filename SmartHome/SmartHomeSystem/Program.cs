using System;
using System.Text;

namespace SmartHomeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.UTF8;

           
            var controller = new SmartHomeController();

           
            var light = new Light { Name = "Лампа у вітальні" };
            var ac = new AirConditioner { Name = "Кондиціонер у спальні" };
            var coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };
            var sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            
            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.AddDevice(coffee);
            controller.AddDevice(sensor);

           
            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(coffee);

        

           
            controller.TurnAllOn();
            Console.WriteLine(); 

           
            light.PrintStatus();
            ac.PrintStatus();
            coffee.PrintStatus();
            sensor.PrintStatus();
            Console.WriteLine();

           
            controller.ShowEnergyReport(5);
            Console.WriteLine();

          
            controller.TurnAllOff();

           
            Console.ReadKey();
        }
    }
}