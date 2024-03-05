namespace FilenameOccurrenceCounter;

public static class Program
{
    private static void Main(string[] args)
    {
        if (ValidateArgs(args))
        {
            string path = args[0];

            try
            {
                FilenameCounter filenameCounter = new FilenameCounter();
                using var fileStream = File.Open(path, FileMode.Open);
                var filename = Path.GetFileNameWithoutExtension(path);

                int noOccurrences = filenameCounter.CountOccurrencesInFileStream(fileStream, filename);
                Console.WriteLine($"Found {noOccurrences} occurrence(s) of \"{filename}\".");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Exception occurred:\n" + e);
            }
        }

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }

    public static bool ValidateArgs(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("None or more than one argument(s) provided.");
            return false;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine($"File \"{args[0]}\" does not exist.");
            return false;
        }

        return true;
    }
}