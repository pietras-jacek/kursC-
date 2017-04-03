using System;
using System.Collections.Generic;

namespace epizod2.Models
{
    public class User
    {
        private ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool isActive { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Orders { get { return _orders; } }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }
        public void SetEmail(string email ) {
            if (string.IsNullOrWhiteSpace(email)) {
                throw new Exception("Email jest nieprawidłowy");
            }
            if (Email == email) {
                return;
            }
            Email = email;
            Update();
        }

        public void SetPassword(string password) {
            if (string.IsNullOrWhiteSpace(password)) {
                throw new Exception("Hasło jest niepoprawne");
            }
            if (Password == password) {
                return;
            }
            Password = password;
            Update();
        }

        public void SetAte(int age) {
            if (age < 13) {
                throw new Exception("Wiek musi być większy lub równy 13 lat");
            }
            if (Age == age) {
                return;
            }
            Age = age;
            Update();
        }

        public void Activate() {
            if (isActive) {
                return;
            }
            isActive = true;
            Update();
        }

        public void Deactivate() {
            if (!isActive) {
                return;
            }
            isActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds) {
            if (funds < 0) {
                throw new Exception("Kwota funduszy musi być większa niż 0");
            }
            Funds = funds;
            Update();
        }

        public void PurchaseOrder(Order order) {
            if (!isActive) {
                throw new Exception("Tylko aktywni użytkownicy mogą dokonywać zamówień");
            }
            decimal orderPrice = order.TotalPrice;
            
            if (Funds - order.Price < 0) {
                throw new Exception("Brakuje ci wystarczającej kwoty do dokonania zakupu");
            }
            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();        
        }

        private void Update() {
            UpdateAt = DateTime.UtcNow;
        }   
    }
}