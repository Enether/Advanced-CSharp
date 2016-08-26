
using System.Text;
using System.Linq;

namespace _01.ExtendTheStringBuilderClass
{
    class ExtendTheStringBuilderClass
    {
        static void Main()
        {
            
            StringBuilder alphabet = new StringBuilder();

            for (int i = 'a'; i <= 'z'; i++)
            {
                alphabet.Append((char)i);
            }

            string firstTenLettersFromAlphabet = alphabet.Substring(0, 10);

            System.Console.WriteLine(firstTenLettersFromAlphabet);
        }
    }
}




