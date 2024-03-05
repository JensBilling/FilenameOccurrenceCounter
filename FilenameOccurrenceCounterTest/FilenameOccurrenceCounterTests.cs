using FilenameOccurrenceCounter;
using Xunit;

namespace FilenameOccurrenceCounterTest;

public class FilenameOccurrenceCounterTests
{
    [Fact]
    private void ValidateArgs_FileExists_ReturnsTrue()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "fileThatExists.txt");
        using (FileStream fileStream = File.Create(path)) { }
        var args = new[] { path };

        var result = Program.ValidateArgs(args);

        Assert.True(result);
        File.Delete(path);
    }

    [Fact]
    private void ValidateArgs_FileDoesNotExist_ReturnsFalse()
    {
        var args = new[]
            { @"C:\Users\UserDoesNotExist\DirectoryDoesNotExist\FileDoesNotExist.exe" };

        var result = Program.ValidateArgs(args);

        Assert.False(result);
    }

    [Fact]
    private void ValidateArgs_NoArguments_ReturnsFalse()
    {
        string[] args = Array.Empty<string>();

        var result = Program.ValidateArgs(args);

        Assert.False(result);
    }

    [Fact]
    private void ValidateArgs_TooManyArguments_ReturnsFalse()
    {
        var args = new[]
            { "arg1", "arg2", "arg3" };

        var result = Program.ValidateArgs(args);

        Assert.False(result);
    }

    [Fact]
    private void CountOccurrencesInFileStream_CountFilenameOccurrences_ReturnsCorrectCount()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "test.txt");
        string data = "This is a test of counting occurrences of the word test. testest test. Test";
        int expected = 5;
        File.WriteAllText(path, data);
        var filenameCounter = new FilenameCounter();
        using var fileStream = File.Open(path, FileMode.Open);
        var filename = Path.GetFileNameWithoutExtension(path);

        int result = filenameCounter.CountOccurrencesInFileStream(fileStream, filename);

        Assert.Equal(expected, result);
        File.Delete(path);
    }
}