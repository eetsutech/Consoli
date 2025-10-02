using System;
namespace Consoli;
public static class Variables
{
    public static string Username = System.Environment.UserName;
    public static string PcName = System.Environment.MachineName;
    public static string Workgroup = System.Environment.UserDomainName;
    public static string Os = System.Environment.OSVersion.ToString();
    public static bool Is64Bit = System.Environment.Is64BitOperatingSystem;
    public static string Version = "1.0.1";
    public static string Author = "Eetsu";
    
}