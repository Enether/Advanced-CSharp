using System;
using System.Text;


class CensorYourEmailAddress
{
    static void Main()
    {
        StringBuilder emailAddress = new StringBuilder();
        string uncensoredEmail = Console.ReadLine();
        emailAddress.Append(CensorEmail(uncensoredEmail));

        StringBuilder email = new StringBuilder();
        string emailT = Console.ReadLine();
        email.Append(emailT);

        email.Replace(uncensoredEmail, emailAddress.ToString());
        Console.WriteLine(email);
        
    }
    static string CensorEmail(string s)
    {
        string censoredEmail = new string('*', s.IndexOf('@')) + s.Substring(s.IndexOf('@'));
        return censoredEmail;
    }
}

