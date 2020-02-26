using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using AppTools;

namespace myConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            MailMessage mail = new MailMessage();
            Console.WriteLine("Email Address?");
            string userEmail = Console.ReadLine();
            mail.From = new System.Net.Mail.MailAddress(userEmail);

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            Console.WriteLine("Password?");
            string passWord = Console.ReadLine();
            smtp.Credentials = new NetworkCredential(userEmail, passWord);
            smtp.Host = "smtp.gmail.com";

            //recipient address
            mail.To.Add(new MailAddress(userEmail));

            Console.WriteLine("Message?");
            string userMessage = Console.ReadLine();

            //Formatted mail body
            mail.IsBodyHtml = true;
            string st = userMessage;

            mail.Body = st;
            smtp.Send(mail);
        }

    }
}
