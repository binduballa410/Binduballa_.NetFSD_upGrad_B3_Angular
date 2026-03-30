using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    public interface INotification
    {
        void Send(string message);
    }
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email Notification: " + message);
        }
    }
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS Notification: " + message);
        }
    }
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Pudh Notification: " + message);
        }
    }
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            if (type.ToLower() == "email")
            {
                return new EmailNotification();
            }
            else if (type.ToLower() == "sms")
            {
                return new SMSNotification();
            }
            else if (type.ToLower() == "push")
            {
                return new PushNotification();
            }
            else
            {
                throw new ArgumentException("Invalid notification type");         
            }
        }
    }
    class Program
    {
        static void Main(string[] args) 
        {
            NotificationFactory factory = new NotificationFactory();

            INotification notification1 = factory.CreateNotification("email");
            notification1.Send("Welcome to our service!");

            INotification notification2 = factory.CreateNotification("sms");
            notification2.Send("Your OTP is 1234");

            INotification notification3 = factory.CreateNotification("push");
            notification3.Send("You have a new message");

            Console.ReadLine();
          
        }
     
      
    }
}




