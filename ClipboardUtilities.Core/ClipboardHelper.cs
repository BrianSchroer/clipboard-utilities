using System;
using System.Runtime.InteropServices;

namespace ClipboardUtilities.Core
{
    public static class ClipboardHelper
    {
        public static void CopyToClipboard(string value)
        {
            string result = null;
            OSPlatform platform = OSPlatformHelper.OSPlatform;

            if (platform == OSPlatform.Windows)
            {
                result = OSPlatformHelper.Bat($"echo {value} | clip");
            }
            else
            {
                result = OSPlatformHelper.Bash($"echo \"{value}\" | pbcopy");
            }
        }
    }
}