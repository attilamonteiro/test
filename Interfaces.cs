/*
    Title: ILoggerRepository
    Description: This interface defines methods for reading log files and writing results to a file.
*/

using System.Collections.Generic; // Importing the namespace for Dictionary<TKey, TValue>

namespace LogAnalyzer.Interfaces
{
    /*
        Interface: ILoggerRepository
        Description: This interface defines methods for reading log files and writing results to a file.
    */
    public interface ILoggerRepository
    {
        /*
            Method: ReadAllLines
            Description: Reads all lines from a log file.
            Parameters:
                - logFilePath: The path to the log file.
            Returns:
                An array of strings containing all lines read from the log file.
        */
        string[] ReadAllLines(string logFilePath);

        /*
            Method: WriteResults
            Description: Writes results to a file.
            Parameters:
                - filePath: The path to the file where results will be written.
                - groupedHashes: A dictionary where keys are realms and values are lists of hashes associated with each realm.
        */
        void WriteResults(string filePath, Dictionary<string, List<string>> groupedHashes);
    }
}
