using System;

namespace OSPlatform{
    public static class OSPlatformCheck{
        public static bool IsWindows(){
            return Environment.OSVersion.Platform == PlatformID.Win32NT ||
                Environment.OSVersion.Platform == PlatformID.Win32S ||
                Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                Environment.OSVersion.Platform == PlatformID.WinCE;
        }
        
        public static bool IsUnix(){
            return Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX;
        }
    }
}