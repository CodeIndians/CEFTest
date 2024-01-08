
using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string url = "https://www.google.com";
            StartChromeProcess(url + " --hide-scrollbar --disable-pinch --disable-gesture-requirement-for-presentation --window-size=800,600 --disable-extensions");

            // Wait for the Chrome process to exit
            Console.WriteLine("Waiting for Chrome process to exit...");
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");
            foreach (Process chromeProcess in chromeProcesses)
            {
                chromeProcess.WaitForExit();
            }

            // Delay for 3 seconds
            Console.WriteLine("Waiting for 3 seconds before launching another Chrome process...");
            Thread.Sleep(3000);
        }
    }

    static void StartChromeProcess(string url)
    {
        // Start Chrome process with the provided URL
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start chrome {url}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        Console.WriteLine($"Starting Chrome with URL: {url}");

        using (Process process = new Process { StartInfo = startInfo })
        {
            process.Start();
            process.WaitForExit();
        }
    }
}
