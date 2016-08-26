using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class DirectoryTraversal
{
    static void Main()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();

           string dir = Console.ReadLine();
        DirectoryInfo directory = new DirectoryInfo(dir);
        foreach (FileInfo item in directory.GetFiles().OrderBy(f => f.Length))
        {
            if (dict.ContainsKey(item.Extension))
            {
                dict[item.Extension] += "|" + "--" + item.Name + " - " + item.Length + "kb";
            }
            else
            {
                dict[item.Extension] = "--" + item.Name + " - " + item.Length + "kb";
            }               
        }

        foreach (var item in dict)
        {
            using (FileStream report = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\\results.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(report))
                {
                    sw.WriteLine(item.Key);

                    MatchCollection matches = Regex.Matches(item.Value, @"(?<fileName>.+?)(?:\||$)");
                    foreach (Match match in matches)
                    {
                        sw.WriteLine(match.Groups["fileName"]);
                    }
                }
            }
        }
    }
}

