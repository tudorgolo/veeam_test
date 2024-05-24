namespace Monitor
{
    public class ProcessMonitor
    {
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(KeyPressedMonitor);

            try
            {
                ValidateParameters(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var processName = args[1];
            var maxProcessDuration = int.Parse(args[2]);
            var pollingInterval = int.Parse(args[3]);
            var processChecker = new ProcessChecker(processName, maxProcessDuration);

            while (true)
            {
                Console.WriteLine($"Checking for processes:");
                processChecker.CheckProcess();
                Thread.Sleep(pollingInterval * 1000);
                Console.WriteLine($"Sleeping for {pollingInterval} minutes.");
            }
        }

        static void KeyPressedMonitor()
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

        static void ValidateParameters(string[] args)
        {
            if (args.Length < 4) throw new ArgumentException("Too few parameters!!!");
            if (args[1].Length < 4) throw new ArgumentException("Process name cannot have less than 4 characters!!!");
            if (int.Parse(args[2]) <= 0) throw new ArgumentException("Process max age cannot <= 0!!!");
            if (int.Parse(args[3]) <= 0) throw new ArgumentException("Polling interval cannot be <=0!!!");
        }
    }
}