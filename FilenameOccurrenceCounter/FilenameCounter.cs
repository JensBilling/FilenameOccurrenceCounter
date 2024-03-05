namespace FilenameOccurrenceCounter;

public class FilenameCounter
{
    public int CountOccurrencesInFileStream(FileStream fileStream, string filename)
    {
        using var streamReader = new StreamReader(fileStream);

        int counter = 0;
        while (true)
        {
            string? line = streamReader.ReadLine();
            if (line == null)
            {
                return counter;
            }
            
            counter += CountOccurrences(line, filename);
        }
    }

    private int CountOccurrences(string line, string filename)
    {
        int counter = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line.Substring(i).StartsWith(filename))
            {
                counter++;
            }
        }

        return counter;
    }
}