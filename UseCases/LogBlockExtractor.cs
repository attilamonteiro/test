/*
    Title: LogBlockExtractor
    Description: This class provides functionality to extract log blocks from an array of log lines.
*/

using System.Collections.Generic; // Importing the namespace for List<T>
using LogAnalyzer.Entities; // Importing the namespace for LogBlock

namespace LogAnalyzer.UseCases
{
    /*
        Class: LogBlockExtractor
        Description: This class is responsible for extracting log blocks from an array of log lines.
    */
    public class LogBlockExtractor
    {
        /*
            Method: ExtractBlocks
            Description: Extracts log blocks from an array of log lines.
            Parameters:
                - logLines: An array of strings representing log lines.
            Returns:
                A list of LogBlocks extracted from the log lines.
        */
        public List<LogBlock> ExtractBlocks(string[] logLines)
        {
            // Initialize a list to store extracted log blocks
            List<LogBlock> blocks = new List<LogBlock>();
            // Initialize a variable to track the current log block being processed
            LogBlock? currentBlock = null;

            // Iterate through each log line in the provided array
            foreach (var line in logLines)
            {
                // Check if the line marks the start of a new log block
                if (line.Contains("Iniciando interpretação da mensagem..."))
                {
                    // Create a new log block and set it as the current block
                    currentBlock = new LogBlock();
                    // Add the new log block to the list of blocks
                    blocks.Add(currentBlock);
                }

                // Check if there is a current log block being processed
                if (currentBlock != null)
                {
                    // Add the current line to the lines of the current log block
                    currentBlock.Lines.Add(line);
                }
            }

            // Return the list of extracted log blocks
            return blocks;
        }
    }
}
