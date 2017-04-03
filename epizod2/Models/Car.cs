using System;
using System.Collections.Generic;

namespace epizod2.Models
{
    public class Car
    {
        public double Speed { get; protected set; } = 100;
        public double Acceleration { get; protected set; } = 10;

        public void Start() {
            Console.WriteLine("Uruchamianie silnika");
            Console.WriteLine($"Predkosc wynosi: {Speed} km/h");
        }
        
        public void Stop() {
            Console.WriteLine("Auto zatrzymuje się");
        }

        public virtual void Accelerate() {
            Console.WriteLine("Przyspieszanie...");
            Speed += Acceleration;
            Console.WriteLine($"Predkosc wynosi: {Speed} km/h");
        }
    }

    public class Truck : Car {
        public override void Accelerate() {
            Console.WriteLine("Przyspieszanie...");
            Speed += Acceleration;
            Console.WriteLine($"Predkosc ciezarowki wynosi: {Speed+20} km/h");
        }
    }

    public class SportCar : Car {
        public override void Accelerate() {
            Console.WriteLine("Przyspieszanie...");
            Speed += Acceleration;
            Console.WriteLine($"Predkosc samochodu sportowego wynosi: {Speed+50} km/h");
        }
    }

    public class Race {
        public void Begin() {
            SportCar speedCar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car> {speedCar, truck};

            foreach(Car car in cars) {
                car.Start();
                car.Accelerate();
            }
        }
    }
}