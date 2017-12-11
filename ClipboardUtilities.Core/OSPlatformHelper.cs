using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClipboardUtilities.Core
{
    public static class OSPlatformHelper
    {
        public static OSPlatform OSPlatform
        {
            get
            {
                foreach (OSPlatform platform in new[]
                {
                  OSPlatform.Windows,
                  OSPlatform.Linux,
                  OSPlatform.OSX
                })
                {
                    if (RuntimeInformation.IsOSPlatform(platform))
                    {
                        return platform;
                    }
                }

                throw new InvalidOperationException(
                  "Unable to determine operating system.");
            }
        }

        public static string Bash(string command)
        {
            string escaped = command.Replace("\"", "\\\"");
            return Run("/bin/bash", $"-c \"{escaped}\"");
        }

        public static string Bat(string command)
        {
            string escaped = command.Replace("\"", "\\\"");
            return Run("cmd.exe", $"/c \"{escaped}\"");
        }

        private static string Run(string fileName, string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}