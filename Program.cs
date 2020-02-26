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

            // The important part -- configuring the SMTP client
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            Console.WriteLine("Password?");
            string passWord = Console.ReadLine();
            smtp.Credentials = new NetworkCredential(userEmail, passWord);  // [4] Added this. Note, first parameter is NOT string.
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
