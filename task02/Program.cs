using System.IO.Compression;
using System.Text;

namespace task02;

using System.IO;

static class Program
{
    static void Main()
    {
        Console.WriteLine("");
        const string fileToSearch = "YEEEEES.txt";
        var path = Directory.GetFiles("/Users/oldmash/RiderProjects", fileToSearch, SearchOption.AllDirectories);
        Console.WriteLine($"Путь к файлу: {path[0]}");
        using (FileStream fs = new FileStream(path[0], FileMode.Open))
        {
            byte[] b = new byte[fs.Length];
            UTF8Encoding temp = new UTF8Encoding(true);
            Console.WriteLine("Содержимое искомого файла:\n<");
            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }

            Console.WriteLine(">");
        }

        var zipPath = "/Users/oldmash/RiderProjects/labsC#/C-_lab08/task01/YEEEEES.zip";
        using (FileStream fs = new FileStream(path[0], FileMode.Open))
        {
            using FileStream targetStream = File.Create(zipPath);
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            fs.CopyTo(compressionStream);
            Console.WriteLine($"Файл сжат в {zipPath}!");
        }
    }
}