using System;
using epizod1.Models;

namespace epizod1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Order order1 = new Order(1, 100);
            User user = new User("jan@wp.pl", "15");
            Console.WriteLine(user.Email);
        }
    }
}
