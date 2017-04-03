using System;

namespace epizod2.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice { get { return (1 + TaxRate) * Price; } }
        public bool isPurchased { get; private set; }

        public Order(int id, decimal price)
        {
            Id = id;
            
            if (price <= 0) {
                throw new Exception("Cena musi być większa niż 0");
            }
            
            Price = price;
        }
        public void Purchase () {
            if (isPurchased) {
                throw new Exception("Zamówienie już zostało złożone"); 
            }
            isPurchased = true;
        }
    }
}