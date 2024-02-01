namespace ListDir
{
    internal class Program
    {
        static void Main()
        {
            var path = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(path);
            var directories = Directory.GetDirectories(path);

            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
            }

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}