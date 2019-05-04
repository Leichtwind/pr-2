using System;
using System.Net;
using System.Net.Mail;
using util;

namespace pr_2
{
  internal static class Program
  {
    private static void Main()
    {
      try
      {
        SendEmail();
        Console.WriteLine("Message sent.");
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
      }      
    }

    private static void SendEmail()
    {
      var username = Console.ReadLine();
      var password = Util.SecretInput();
      var destination = Console.ReadLine();

      var from = new MailAddress(username, "Solid Snake");
      var to = new MailAddress(destination);

      var mailMessage = new MailMessage(from, to)
      {
        Subject = "FOX",
        Body = "Kept you waiting, huh?"
      };

      var credential = new NetworkCredential(username, password);

      var smtp = new SmtpClient("smtp.gmail.com", 587)
      {
        Credentials = credential,
        EnableSsl = true
      };

      smtp.Send(mailMessage);   
    }
  }
}