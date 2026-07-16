using System;
using System.Threading;

namespace ProcessSimulator;
public delegate void ProgressReporter(string stepName, int percent);

internal class Program
{
    private static void Main()
    {

        string[] steps =
        {
            "Downloading data",
            "Validating input",
            "Processing records",
            "Generating report",
            "Publishing results",
            "Cleaning up"
        };

        RunSimulation(steps, DrawProgressBar);
    }

    private static void RunSimulation( string[] steps, ProgressReporter progress)
    {
        Console.CursorVisible = false;
        Console.WriteLine("=== Process Simulator ===");
        Console.WriteLine();

        foreach (string step in steps)
        {
            Console.WriteLine($"Starting: {step}");

            for (int percent = 0; percent <= 100; percent += 5)
            {
                progress(step,percent);
                Thread.Sleep(80);
            }

            Console.WriteLine($"Completed: {step}");
            Console.WriteLine();
        } 

        Console.WriteLine("All process steps completed.");
        Console.CursorVisible = true;
    }

   

    private static void DrawProgressBar(string stepName, int percent)
    {
        const int width = 30;
        const char filledChar = '█';
        const char emptyChar = '░';
        const char barStartChar = '⟦';
        const char barEndChar = '⟧';

        int filled = percent * width / 100;

        string bar = new string(filledChar, filled) + new string(emptyChar, width - filled);
        Console.Write($"\r{stepName,-22} {barStartChar}{bar}{barEndChar} {percent,3}%");

        if (percent == 50)
        {
            Console.WriteLine($"  Warning: {stepName} is only halfway done.");
        }

        if (percent == 100)
        {
            Console.WriteLine();
        }
    }
}
