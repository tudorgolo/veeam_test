using System.Diagnostics;

namespace App
{
    class ProcessChecker
    {
        private int maxAge;
        public ProcessChecker(int mAge)
        {
            if (mAge <= 0)
            {
                throw new ArgumentOutOfRangeException("Age needs to be > 0");
            }
            maxAge = mAge;
        }

        public void CheckProcess()
        {
            var allProcesses = Process.GetProcessesByName("ping");

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