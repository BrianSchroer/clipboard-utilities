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
                      Console.WriteLine($"Reading {path}...");
                      using (var sr = new StreamReader(path))
                      {
                          contents = sr.ReadToEnd();
                      }
                      Console.WriteLine("File contents:");
                      Console.WriteLine(contents);
                      ClipboardHelper.CopyToClipboard(contents);
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
