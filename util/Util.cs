using System;
using System.Text;

namespace util
{
  public static class Util
  {
    public static string SecretInput()
    {
      var passwordBuilder = new StringBuilder();
      var continueReading = true;

      const char newLineChar = '\r';
      
      while (continueReading)
      {
        var consoleKeyInfo = Console.ReadKey(true);
        var passwordChar = consoleKeyInfo.KeyChar;

        if (passwordChar == newLineChar)
        {
          continueReading = false;
        }
        else
        {
          passwordBuilder.Append(passwordChar.ToString());
        }
      }

      return passwordBuilder.ToString();
    }
  }
}