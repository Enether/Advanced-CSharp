using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

// this way is much slower because we constantly have to re-open the stream but at least gives us the ability to have flexible parts
// I've commented out the faster way with 5 parts only

class SlicingFile
{
    static void Main()
    {
        string sourceFile = @"..\..\Video.mp4";
        string destinationDirectory = @"..\..\";
        int parts = 5;
        Slice(sourceFile, destinationDirectory, parts);

        List<string> files = new List<string>();
        for (int i = 0; i < parts; i++)
        {
            files.Add("Video-" + i + @".mp4");
        }
        List<string> gzFiles = new List<string>();
        for (int i = 0; i < parts; i++)
        {
            gzFiles.Add("Video-" + i + @".gz");
        }
        Compress(files, gzFiles, destinationDirectory);

        Console.WriteLine("\n\nThe parts are split and compressed.\nPress any key to assemble them\n");
        Console.ReadKey();

        Decompress(gzFiles, files, destinationDirectory);
        Assemble(files, destinationDirectory);
    }
    static void Assemble(List<string> files, string destinationDirectory)
    {
        Console.WriteLine("Assembling parts...");
        using(FileStream writeFile = new FileStream(@"..\..\assembled.mp4", FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[4096];
            int iterator = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<int> progress = new List<int>();
            for (int i = 0; i < files.Count(); i++)
            {
                progress.Add(0);
            }

            while (true)
            {
                if (iterator == files.Count())
                    iterator = 0;

                FileStream readFile = new FileStream(destinationDirectory + files[iterator], FileMode.Open, FileAccess.Read);

                try
                {
                    readFile.Seek(progress[iterator], SeekOrigin.Current); // Because it resets, we need to start from the point we left off
                    
                    int readBytes = readFile.Read(buffer, 0, buffer.Length);
                    progress[iterator] += buffer.Length; // saves the point we left off from in each file
                    if (readBytes == 0)
                        break;

                    
                    writeFile.Write(buffer, 0, readBytes);
                }
                finally
                {
                    readFile.Close();
                }
                iterator++;
            }
            Console.WriteLine("Parts are assembled!\nTime Elapsed: {0}\n", sw.Elapsed);
            sw.Stop();
        }
        foreach (var file in files) // deletes files
        {
            File.Delete(destinationDirectory + file);
        }
    }
    static void Decompress(List<string> gzipFiles, List<string> files, string destinationDirectory)
    {
        Console.WriteLine("Decompressing parts...");
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < files.Count; i++)
        {
            using(FileStream originalFileStream = new FileStream(destinationDirectory + gzipFiles[i], FileMode.Open))
            {
                using(FileStream decompressedFileStream = new FileStream(destinationDirectory + files[i], FileMode.OpenOrCreate))
                {
                    using(GZipStream decompressionStream = new GZipStream(decompressedFileStream, CompressionMode.Decompress))
                    {
                        originalFileStream.CopyTo(decompressedFileStream); // decompresses the file
                    }
                }
            }
            File.Delete(destinationDirectory + gzipFiles[i]);
        }
        sw.Stop();
        Console.WriteLine("Parts are decompressed!\nTime Elapsed: {0}\n", sw.Elapsed);
    }
    static void Compress(List<string> files, List<string> gzipFiles, string destinationDirectory)
    {
        Console.WriteLine("Compressing parts...");
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < files.Count; i++)
        {
            using (FileStream originalFileStream = new FileStream(destinationDirectory + files[i], FileMode.Open))
            {
                using (FileStream compressedFileStream = new FileStream(destinationDirectory + gzipFiles[i], FileMode.OpenOrCreate))
                {
                    using(GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream); // compresses the file
                    }
                }
            }
            File.Delete(destinationDirectory + files[i]);
        }
        sw.Stop();
        Console.WriteLine("Parts are compressed!\nTime Elapsed: {0}\n", sw.Elapsed);
    }
    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        Console.WriteLine("Slicing parts...");
        using(FileStream readFile = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4096];
            int iterator = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (iterator == parts)
                    iterator = 0;
                FileStream writeFile = new FileStream(destinationDirectory + @"Video-" + iterator + @".mp4", FileMode.OpenOrCreate, FileAccess.Write);
                
                try
                {                  
                    int readBytes = readFile.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                        break;
                    writeFile.Seek(0, SeekOrigin.End);
                    writeFile.Write(buffer, 0, readBytes);
                }
                finally
                {
                    writeFile.Close();
                }

                iterator++;
            }
            Console.WriteLine("Parts are split!\nTime Elapsed: {0}\n", sw.Elapsed);
            sw.Stop();
            //using(FileStream writeFirstFile = new FileStream(destinationDirectory + @"Video-0.mp4", FileMode.Create, FileAccess.Write))
            //{
            //    using (FileStream writeSecondFile = new FileStream(destinationDirectory + @"Video-1.mp4", FileMode.Create, FileAccess.Write))
            //    {
            //        using (FileStream writeThirdFile = new FileStream(destinationDirectory + @"Video-2.mp4", FileMode.Create, FileAccess.Write))
            //        {
            //            using (FileStream writeFourthFile = new FileStream(destinationDirectory + @"Video-3.mp4", FileMode.Create, FileAccess.Write))
            //            {
            //                using (FileStream writeFifthFile = new FileStream(destinationDirectory + @"Video-4.mp4", FileMode.Create, FileAccess.Write))
            //                {
            //                    byte[] buffer = new byte[4096];
            //                    int iterator = 0;
            //                    while (true)
            //                    {
            //                        int readBytes = readFile.Read(buffer, 0, buffer.Length);

            //                        if (readBytes == 0)
            //                            break;

            //                        switch (iterator)
            //                        {
            //                            case 0:
            //                                writeFirstFile.Write(buffer, 0, readBytes);
            //                                iterator++;
            //                                break;
            //                            case 1:
            //                                writeSecondFile.Write(buffer, 0, readBytes);
            //                                iterator++;
            //                                break;
            //                            case 2:
            //                                writeThirdFile.Write(buffer, 0, readBytes);
            //                                iterator++;
            //                                break;
            //                            case 3:
            //                                writeFourthFile.Write(buffer, 0, readBytes);
            //                                iterator++;
            //                                break;
            //                            case 4:
            //                                writeFifthFile.Write(buffer, 0, readBytes);
            //                                iterator = 0;
            //                                break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}

