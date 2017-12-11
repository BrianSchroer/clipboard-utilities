using System;
using System.IO;
using ClipboardUtilities.Core;

namespace ClipboardUtilities.CopyFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    string path = args[0];

                    if (File.Exists(path))
                    {
                        ClipboardHelper.CopyStringToClipboard(path);
                    }
                    else
                    {
                        Console.WriteLine($"File not found: \"{path}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
