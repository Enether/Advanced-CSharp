using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        using(FileStream readImage = new FileStream(@"..\..\PandaBear.jpg", FileMode.Open, FileAccess.Read, FileShare.None, 4096))
        {
            using(FileStream CreateImage = new FileStream(@"..\..\panda.jpg", FileMode.Create, FileAccess.Write, FileShare.None, 4096))
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = readImage.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                        break;

                    CreateImage.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}

