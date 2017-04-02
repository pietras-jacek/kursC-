using System;

namespace epizod1.Models
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool isActive { get; private set; }

        public DateTime UpdateAt { get; private set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
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

        private void Update() {
            UpdateAt = DateTime.UtcNow;
        }   
    }
}