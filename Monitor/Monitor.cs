namespace App
{
    public class ProcessMonitor
    {
        static void Main()
        {
            Task task = Task.Factory.StartNew(KeyPressedMonitorWorker);

            int timeout = 5;

            var processChecker = new ProcessChecker(1);
            while (true)
            {
                processChecker.CheckProcess();
                Console.WriteLine($"Sleeping for {timeout} minutes.");
                Thread.Sleep(timeout * 10000);
            }
        }

        static void KeyPressedMonitorWorker()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Q)
                    {
                        Console.WriteLine("Received CLOSE command. Exiting...");
                        Environment.Exit(1);
                    }
                }
            }
        }
    }
}