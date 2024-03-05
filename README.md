The program is written in C#/.NET 7, testing is done with xUnit.

The definition of an occurrence of the filename was never defined in the specification, therefore I made the assumption that it does not matter if the word is written alone or is in the middle of another word, as long as the word in itself is complete.
I also decided that if the word shares common characters in the beginning and the end that are concatenated together, they would still count as two unique occurences (ex. "testest" would be counted as two occurrences of the word "test") and capitalization does matter, so test.txt would not count "Test" as an occurance.

To run the program, simply build it and run the executable with the file's path as an argument separated by a space:
"FilenameOccurrenceCounter.exe exampleFilePath.txt"
