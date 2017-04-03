using System;
using epizod2.Models;

namespace epizod2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Car car = new Car();

            // Console.WriteLine("Grzejesz: " + car.Speed);
            // car.Start();
            // car.Accelerate();
            
            Race race = new Race();
            race.Begin();
        }
    }
}
