/*
    Title: ErrorBlockFinder
    Description: This class provides functionality to find error blocks within a list of LogBlocks.
*/

using System.Collections.Generic; // Importing the namespace for List<T>
using System.Linq; // Importing the namespace for LINQ
using LogAnalyzer.Entities; // Importing the namespace for LogBlock

namespace LogAnalyzer.UseCases
{
    /*
        Class: ErrorBlockFinder
        Description: This class is responsible for finding error blocks within a list of LogBlocks.
    */
    public class ErrorBlockFinder
    {
        /*
            Method: FindErrorBlocks
            Description: Finds error blocks within a list of LogBlocks based on a specific error message.
            Parameters:
                - blocks: A list of LogBlocks to search for errors.
            Returns:
                A list of LogBlocks containing error messages.
        */
        public List<LogBlock> FindErrorBlocks(List<LogBlock> blocks)
        {
            // Use LINQ to filter blocks that contain the specified error message
            return blocks
                .Where(block => block.Lines.Any(line => line.Contains("System.ArgumentException: Parameter 'P_ID_TIPO_RESIDENCIA' not found in the collection.")))
                .ToList();
        }
    }
}
