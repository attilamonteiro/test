/*
    Title: FileLoggerRepository
    Description: This class provides functionality for reading log files and writing results to a file.
*/

using System; // Importing the namespace for System class
using System.Collections.Generic; // Importing the namespace for Dictionary<TKey, TValue>
using System.IO; // Importing the namespace for File and StreamWriter classes
using LogAnalyzer.Interfaces; // Importing the namespace for ILoggerRepository interface

namespace LogAnalyzer.LogIO
{
    /*
        Class: FileLoggerRepository
        Description: This class implements the ILoggerRepository interface to read log files and write results to a file.
    */
    public class FileLoggerRepository : ILoggerRepository
    {
        /*
            Method: ReadAllLines
            Description: Reads all lines from a log file.
            Parameters:
                - logFilePath: The path to the log file.
            Returns:
                An array of strings containing all lines read from the log file.
        */
        public string[] ReadAllLines(string logFilePath)
        {
            // Read all lines from the log file and return them
            return File.ReadAllLines(logFilePath);
        }

        /*
            Method: WriteResults
            Description: Writes results to a file.
            Parameters:
                - filePath: The path to the file where results will be written.
                - groupedHashes: A dictionary where keys are realms and values are lists of hashes associated with each realm.
        */
        public void WriteResults(string filePath, Dictionary<string, List<string>> groupedHashes)
        {
            // Open a StreamWriter to write to the specified file
            using (var writer = new StreamWriter(filePath))
            {
                // Iterate through each realm in the dictionary
                foreach (var kvp in groupedHashes)
                {
                    // Write the realm to the file
                    writer.WriteLine(kvp.Key);

                    // Write each hash associated with the current realm
                    foreach (var hash in kvp.Value)
                    {
                        writer.WriteLine($"\"{hash}\"");
                    }

                    // Write an empty line to separate realms
                    writer.WriteLine();
                }
            }
        }
    }
}
