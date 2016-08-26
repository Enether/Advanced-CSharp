using System;
using System.IO;


class LineNumbers
{
    static void Main()
    {
        using(StreamReader sr = new StreamReader(@"..\..\ReadThis.txt"))
        {
            using (FileStream fs = new FileStream(@"..\..\This.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string line = sr.ReadLine();
                    int lineNumber = 1;
                    while(line != null)
                    {
                        sw.WriteLine("{0}.\t{1}", lineNumber, line);

                        line = sr.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
        Console.WriteLine("Done :s");
    }
}

