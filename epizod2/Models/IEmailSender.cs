using System;

namespace epizod2.Models
{
    public interface IEmailSender
    {
         void SendMessage(string reciver, string title, string message);
    }
    public class EmailSender : IEmailSender
    {
        public void SendMessage(string reciver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDataBase {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();

    }
    public class Database : IDataBase
    {
        public bool IsConnected => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    public interface IOrderProcessor {
        void ProcessOrder(string email, int orderId);
    }
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDataBase _database;
        private readonly IEmailSender _emailSender;

        public OrderProcessor(IDataBase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }
        public void ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            Order order = _database.GetOrder(orderId);
            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Wysyłka zamówienia", "Zamówienie zostało wysłane");
        }
    }

    public class FakeEmailSender : IEmailSender
    {
        public void SendMessage(string reciver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeDataBase : IDataBase
    {
        public bool IsConnected => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public class Shop {
        public void CompleteOrder() {
            IDataBase dataBase = new Database();
            IEmailSender emailSender = new EmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(dataBase, emailSender);
        }

        public void CompletFakeOrder() {
            IDataBase dataBase = new FakeDataBase();
            IEmailSender emailSender = new FakeEmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(dataBase, emailSender);
        }
    }
}