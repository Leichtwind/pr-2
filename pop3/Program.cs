using System;
using OpenPop.Pop3;
using util;

namespace pop3
{
  internal static class Program
  {
    private static void Main()
    {
      var username = Console.ReadLine();
      var password = Util.SecretInput();

      using (var client = new Pop3Client())
      {
        client.Connect("pop.gmail.com", 995, true);

        client.Authenticate(username, password);

        var messageCount = client.GetMessageCount();

        if (messageCount <= 0) return;
        
        var message = client.GetMessage(messageCount);

        Console.WriteLine(System.Text.Encoding.UTF8.GetString(message.RawMessage));
      }
    }
  }
}