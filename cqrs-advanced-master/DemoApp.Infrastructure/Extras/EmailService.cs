using System;
using DemoApp.Infrastructure.Extras.Backend;

namespace DemoApp.Infrastructure.Extras
{
    public class EmailService
    {
        public static void Send(string address, string message)
        {
            using (var db = new DemoAppExtras())
            {
                var email = new SentEmail {Address = address, Body = message, Sent = DateTime.Now};
                db.SentEmails.Add(email);
                db.SaveChanges();
            }
        }
    }
}