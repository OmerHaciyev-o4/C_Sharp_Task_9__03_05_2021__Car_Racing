using System;
using System.Collections.Generic;
using System.Threading;

namespace Car_Racing
{
    class Program
    {
        static void Main(string[] args)
        {            
            Car car = new Car("Opel", "Omer");
            
            Racing_Car racingCar = new Racing_Car("Mercedes-Benz", "Asif");
            
            Truck truck = new Truck("Scania", "Nicat");
            
            Bus bus = new Bus("Bus", "Shamil");
            
            List<CarInfo> cars = new List<CarInfo>();
            cars.Add(car);                
            cars.Add(racingCar);
            
            List<CarInfo> bigCars = new List<CarInfo>();
            bigCars.Add(truck);
            bigCars.Add(bus);
            
            Racing racing = new Racing(cars, bigCars);
            racing.RacePreparationMessage();
            racing.StartRacing();
        }
    }
}
