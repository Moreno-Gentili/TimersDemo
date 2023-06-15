using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace TimersDemo
{
    internal class Program
    {
        private static Stopwatch stopwatch;
        private static int counter = 0;
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 250
            };

            timer.Elapsed += OnElapsed;
            stopwatch = Stopwatch.StartNew();
            timer.Enabled = true;
            Console.ReadLine();
        }

        private static void OnElapsed(object sender, ElapsedEventArgs e)
        {
            counter++;
            var currentCounter = counter;
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            if (counter % 5 == 0)
            {
                // simulo un'operazione più lenta delle altre
                Thread.Sleep(300);
            }

            Console.WriteLine($"Esecuzione {currentCounter}: sono trascorsi {elapsedMilliseconds}ms dalla precedente esecuzione");
            stopwatch.Restart();
        }
    }
}
