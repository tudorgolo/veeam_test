using System.Diagnostics;

namespace Monitor
{
    class ProcessChecker
    {
        protected string processName;
        protected int maxAge;
        public ProcessChecker(string pName, int mAge)
        {
            processName = pName;
            maxAge = mAge;
        }

        public void CheckProcess()
        {
            var allProcesses = Process.GetProcessesByName(processName);

            if (allProcesses.Length == 0)
            {
                Console.WriteLine("No process found that matches search criteria");
                return;
            }

            Console.WriteLine($"Found {allProcesses.Length} processes matching the search criteria.");

            foreach (var process in allProcesses)
            {
                if (process.StartTime.AddSeconds(maxAge) < DateTime.Now)
                {
                    Console.WriteLine($"{process.ProcessName}-{process.Id} will be killed");
                    process.Kill();
                }
            }
        }
    }
}