namespace App {
    public class Monitor
    {
        static void Main() {
            var processChecker = new ProcessChecker();

            Timer timer = new(processChecker.CheckProcess, processChecker, 0, 10000);
        }
    }

    class ProcessChecker {
        public void CheckProcess(Object? autoEvent) {
            // var names = new[] { "Ana", "Felipe", "Emillia" };
            // foreach(var name in names) 
            // {
            //     Console.WriteLine($"Hello {name}");
            // }
            Console.WriteLine("Hello World");

        }
    }
}
