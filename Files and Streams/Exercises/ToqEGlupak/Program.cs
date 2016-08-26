using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToqEGlupak
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "In-memory text.";
            byte[] bytes = Encoding.ASCII.GetBytes(text);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                memoryStream.WriteByte(65);
                memoryStream.Flush(); // misleh che shte zapishe byte-a shtom go flushna :)
                while (true)
                {
                    int readByte = memoryStream.ReadByte();
                    if (readByte == -1)
                        break;

                    Console.WriteLine((byte)readByte);
                }
            }
        }
        // I guess he's not
    
    }
}
