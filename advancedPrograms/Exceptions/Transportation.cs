using System;
using System.Collections.Generic;

namespace Exceptions
{
    internal class UnacceptablePriceException : Exception
    {
        public UnacceptablePriceException(string message = null) : base(message) {}
    }
    
    internal class Vehicle
    {
        public string Name { get; }
        public string Time { get; }
        public double ServicePrice { get; }

        public Vehicle(string name, string time, double servicePrice)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(time))
                throw new ArgumentNullException("Exception in Vehicle constructor.");

            try
            {
                if (servicePrice > ShipmentService.MaxShipmentPrice)
                    throw new UnacceptablePriceException();

                Name = name;
            }
            catch (UnacceptablePriceException)
            {
                Name = string.Concat(name, " (Expensive shipment)");
            }
            finally
            {
                Time = time;
                ServicePrice = servicePrice;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name}:");
            Console.WriteLine($"Time: {Time}; Price: {ServicePrice}");
        }
    }

    internal class ShipmentService
    {
        public const double MaxShipmentPrice = 20000;

        private readonly List<Vehicle> _vehiclesList;

        public ShipmentService()
        {
            _vehiclesList = new List<Vehicle>
            {
                new Vehicle("KAMAZ", "12:30", 19750),
                new Vehicle("Gazel", "7:45", 21350),
                new Vehicle("Mann", "14:00", 16000),
                new Vehicle("Ural", "15:10", 22780)
            };
        }

        public void DisplayVehicles()
        {
            foreach (var vehicle in _vehiclesList)
            {
                Console.WriteLine(new string('-', 64));
                vehicle.DisplayInfo();
            }
            Console.WriteLine(new string('-', 64));
        }
    }
    
    internal class Transportation : Program
    {
        private const string ProgramName = "Cargo Transportations";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        protected internal override void Execute()
        {
            try
            {
                var service = new ShipmentService();
                service.DisplayVehicles();
                
                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}