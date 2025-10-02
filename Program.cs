using System;
using System.Net.Security;
namespace Consoli;
public class Program
{
    public static void Main()
    {
        var color = "Magneta";
        Console.Title = "Consoli v" + Variables.Version + " | By " + Variables.Author;
        Console.ForegroundColor = ConsoleColor.Magenta;

        while (true)
        {
            Console.WriteLine(Variables.Username + "@" + Variables.PcName);
            var command = Console.ReadLine();
            if (command == "sysinfo")
            {
                Console.WriteLine("Workgroup: " + Variables.Workgroup);
                Console.WriteLine("OS: " + Variables.Os);
                Console.WriteLine("64-Bit: " + Variables.Is64Bit);
                Console.WriteLine("Version: " + Variables.Version);
            }
            if (command == "exit")
            {
                Environment.Exit(0);
            }
            if (command == "clear")
            {
                Console.Clear();
            }
            if (command == "help")
            {
                // all commands rn.
                Console.WriteLine("Available commands:");
                Console.WriteLine("sysinfo - Displays system information");
                Console.WriteLine("clear - Clears the console");
                Console.WriteLine("exit - Exits the application");
                Console.WriteLine("help - Displays this help message");
                Console.WriteLine("whoami - Displays the current username and PC name");
                Console.WriteLine("version - Displays the application version");
                Console.WriteLine("color - Changes the console text color");
                Console.WriteLine("cls - Clears the console (same as clear)");
                Console.WriteLine("date - Displays the current date and time");
                Console.WriteLine("time - Displays the current time");
                Console.WriteLine("start - Starts a specified application");
                Console.WriteLine("echo - Echoes the input text");
                Console.WriteLine("randnum - Generates a random number");
                Console.WriteLine("calc - Performs a simple arithmetic calculation");
                Console.WriteLine("tasklist - Displays a list of running processes");
                Console.WriteLine("admin - Checks if the application is running with administrator privileges");
                Console.WriteLine("sslcheck - Checks the SSL certificate of a specified domain");
                Console.WriteLine("ping - Pings a specified domain or IP address");
                Console.WriteLine("ipconfig - Displays the IP address of the machine");
                Console.WriteLine("support - Displays support information");
                Console.WriteLine("shutdown - Shuts down the computer");
                Console.WriteLine("restart - Restarts the computer");
                Console.WriteLine("logoff - Logs off the current user");
                Console.WriteLine("settitle - Sets the console title");
                

            }
            if (command == "whoami")
                {
                Console.WriteLine("Username: " + Variables.Username);
                Console.WriteLine("PC Name: " + Variables.PcName);
            }
            if (command == "version")
            {
                Console.WriteLine("Version: " + Variables.Version);
            }
            if (command == "color")
                {
                Console.WriteLine("Available colors: Black, Blue, Cyan, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, DarkYellow, Gray, Green, Magenta, Red, White, Yellow");
                Console.Write("Enter a color: ");
                color = Console.ReadLine();
                try
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                }
                catch
                {
                    Console.WriteLine("Invalid color");
                }
            }
            if (command == "cls")
                {
                Console.Clear();
            }
            if (command == "date")
                {
                Console.WriteLine("Current date and time: " + DateTime.Now);
            }
            if (command == "time")
                {
                Console.WriteLine("Current time: " + DateTime.Now.ToString("HH:mm:ss"));
            }
            if (command == "start")
                {
                Console.Write("Enter the name of the application to start (e.g., notepad, calc): ");
                var app = Console.ReadLine();
                try
                {
                    System.Diagnostics.Process.Start(app);
                }
                catch
                {
                    Console.WriteLine("Failed to start application. Make sure the name is correct.");
                }
            }
            if (command == "echo")
                {
                Console.Write("Enter text to echo: ");
                var text = Console.ReadLine();
                Console.WriteLine(text);
            }
            if (command == "randnum")
                {
                var rand = new Random();
                Console.WriteLine("Random number: " + rand.Next());
            }
            if (command == "calc")
                {
                Console.Write("Enter a simple arithmetic expression (e.g., 2 + 2): ");
                var expression = Console.ReadLine();
                try
                {
                    var result = new System.Data.DataTable().Compute(expression, null);
                    Console.WriteLine("Result: " + result);
                }
                catch
                {
                    Console.WriteLine("Invalid expression");
                }
            }
            if (command == "tasklist")
                {
                try
                {
                    var processes = System.Diagnostics.Process.GetProcesses();
                    foreach (var process in processes)
                    {
                        Console.WriteLine(process.ProcessName);
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to retrieve task list.");
                }
            }
            if (command == "admin")
                try 
                {
                    bool isAdmin = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent())
                        .IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
                    Console.WriteLine("Running as administrator: " + isAdmin);
                }
                catch
                {
                    Console.WriteLine("Failed to determine administrator status.");
                }
            if (command == "sslcheck")
            {
                Console.Write("Enter a domain (e.g., example.com): ");
                var domain = Console.ReadLine();
                try
                {
                    using (var client = new System.Net.Sockets.TcpClient(domain, 443))
                    using (var sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, sslPolicyErrors) => true))
                    {
                        sslStream.AuthenticateAsClient(domain);
                        var cert = sslStream.RemoteCertificate;
                        var validFrom = DateTime.Parse(cert.GetEffectiveDateString());
                        var validTo = DateTime.Parse(cert.GetExpirationDateString());
                        Console.WriteLine($"Certificate for {domain} is valid from {validFrom} to {validTo}");
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to retrieve SSL certificate. Make sure the domain is correct.");
                }
            }
            if (command == "ping")
            {
                Console.Write("Enter a domain or IP address to ping: ");
                var target = Console.ReadLine();
                try
                {
                    var ping = new System.Net.NetworkInformation.Ping();
                    var reply = ping.Send(target);
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        Console.WriteLine($"Ping to {target} successful. Time: {reply.RoundtripTime}ms");
                    }
                    else
                    {
                        Console.WriteLine($"Ping to {target} failed. Status: {reply.Status}");
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to ping the target. Make sure the domain or IP address is correct.");
                }
            }
            if (command == "ipconfig")
            {
                try
                {
                    var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine("IP Address: " + ip.ToString());
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to retrieve IP configuration.");
                }
            }
            if (command == "support")
                try 
                {
                    Console.WriteLine("Support in Discord: eetuuuuu!");
                }
                catch
                {
                    Console.WriteLine("Failed to display support information.");
                }
            if (command == "shutdown")
                {
                Console.Write("Are you sure you want to shut down the computer? (yes/no): ");
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "yes")
                {
                    try
                    {
                        System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                    }
                    catch
                    {
                        Console.WriteLine("Failed to initiate shutdown. Make sure you have the necessary permissions.");
                    }
                }
                else
                {
                    Console.WriteLine("Shutdown cancelled.");
                }
            }

            if (command == "restart")
                {
                Console.Write("Are you sure you want to restart the computer? (yes/no): ");
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "yes")
                {
                    try
                    {
                        System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                    }
                    catch
                    {
                        Console.WriteLine("Failed to initiate restart. Make sure you have the necessary permissions.");
                    }
                }
                else
                {
                    Console.WriteLine("Restart cancelled.");
                }
            }

            if (command == "logoff")
                {
                Console.Write("Are you sure you want to log off? (yes/no): ");
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "yes")
                {
                    try
                    {
                        System.Diagnostics.Process.Start("shutdown", "/l");
                    }
                    catch
                    {
                        Console.WriteLine("Failed to log off. Make sure you have the necessary permissions.");
                    }
                }
                else
                {
                    Console.WriteLine("Log off cancelled.");
                }
            }

            if (command == "settitle")
                {
                Console.Write("Enter the new console title: ");
                var title = Console.ReadLine();
                Console.Title = title;
            }

            else
            {
                Console.WriteLine("");
            }
        }
    }
}