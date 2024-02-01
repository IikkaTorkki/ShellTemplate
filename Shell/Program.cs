using System.Diagnostics;

namespace Shell
{
    internal class Program
    {
        static void Main()
        {
            Shell shell = new();
            shell.Run();
        }
    }

    public class Shell
    {
        private readonly Dictionary<string, string> Aliases = new()
        {
            { "ls", @".\ListDir.exe" },
            { "clear", @".\Clear.exe" },
        };

        public void Run()
        {
            while (true)
            {
                Console.Write("$ ");

                string input = Console.ReadLine()!;
                if (input == "exit")
                    break;

                Execute(input);
            }
        }

        private void Execute(string input)
        {
            if (Aliases.ContainsKey(input))
            {
                Process proc = new()
                {
                    StartInfo = new ProcessStartInfo(Aliases[input])
                    {
                        UseShellExecute = false,
                    }
                };

                proc.Start();
                proc.WaitForExit();
            }
            else
            {
                Console.WriteLine($"{input} not found");
            }
        }
    }

}