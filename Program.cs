/*
    Title: Program
    Description: This program reads log data from a file, processes it to find error blocks and group hashes by realm, and writes the results to an output file.
*/

using System; // Importing the namespace for System class
using LogAnalyzer.UseCases; // Importing the namespace for LogProcessor class
using LogAnalyzer.Interfaces; // Importing the namespace for ILoggerRepository interface
using LogAnalyzer.LogIO; // Importing the namespace for FileLoggerRepository class

namespace LogAnalyzer
{
    /*
        Class: Program
        Description: The main entry point for the LogAnalyzer application.
    */
    class Program
    {
        /*
            Method: Main
            Description: The main method of the application, which orchestrates the log analysis process.
            Parameters:
                - args: An array of command-line arguments.
        */
        static void Main(string[] args)
        {
            // Define the paths for the input log file and the output result file
            string logFilePath = "processamento.log";
            string resultFilePath = "result.txt";

            // Create an instance of FileLoggerRepository to handle file I/O operations
            ILoggerRepository loggerRepository = new FileLoggerRepository();
            // Read all lines from the log file
            string[] logLines = loggerRepository.ReadAllLines(logFilePath);

            // Create an instance of LogProcessor to process the log data
            LogProcessor logProcessor = new LogProcessor();
            // Extract log blocks from the read log lines
            var blocks = logProcessor.ExtractBlocks(logLines);
            // Identify error blocks from the extracted log blocks
            var errorBlocks = logProcessor.FindErrorBlocks(blocks);
            // Group hashes by realm from the identified error blocks
            var groupedHashes = logProcessor.GroupHashesByRealm(errorBlocks);

            // Write the grouped hashes results to the output file
            loggerRepository.WriteResults(resultFilePath, groupedHashes);
        }
    }
}
