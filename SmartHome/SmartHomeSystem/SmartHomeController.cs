using System;
using System.Collections.Generic;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> _switchableDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> _energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            _switchableDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            _energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in _switchableDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in _switchableDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            double totalEnergy = 0;

     
            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            foreach (var device in _energyDevices)
            {
                double usage = device.GetEnergyUsage(hours);
                totalEnergy += usage;
              
                Console.WriteLine($"{device.DeviceName}: {usage:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }

            double cost = totalEnergy * 4;

            
            Console.WriteLine($"Загальне споживання: {totalEnergy:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {cost:F2} грн");
        }
    }
}