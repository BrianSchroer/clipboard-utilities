using System;
using System.Runtime.InteropServices;

namespace ClipboardUtilities.Core
{
    public static class ClipboardHelper
    {
        public static string CopyStringToClipboard(string value)
        {
            string result = null;

            OSPlatform platform = OSPlatformHelper.OSPlatform;

            if (platform == OSPlatform.Windows)
            {
                result = OSPlatformHelper.Bat($"echo {value} | clip");
            }
            else
            {
                string escaped = value.Replace("\"", "\\\"");
                result = OSPlatformHelper.Bash($"echo \"{escaped}\" | pbcopy");
            }

            return result;
        }

        public static string CopyFileContentsToClipboard(string path)
        {
            string result = null;
            OSPlatform platform = OSPlatformHelper.OSPlatform;

            if (platform == OSPlatform.Windows)
            {
                result = OSPlatformHelper.Bat($"type \"{path}\" | clip");
            }
            else
            {
                result = OSPlatformHelper.Bash($"pbcopy < \"{path}\"");
            }

            return result;
        }
    }
}