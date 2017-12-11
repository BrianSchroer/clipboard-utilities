using System;
using System.IO;
using ClipboardUtilities.Core;

namespace ClipboardUtilities.CopyFileContents
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
                        string contents = string.Empty;
                        ClipboardHelper.CopyFileContentsToClipboard(path);
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
