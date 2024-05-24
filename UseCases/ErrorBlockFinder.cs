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
            // Initialize a list to store error blocks
            List<LogBlock> errorBlocks = new List<LogBlock>();

            // Iterate through each block in the provided list of LogBlocks
            foreach (var block in blocks)
            {
                // Check if any line within the block contains the specified error message
                if (block.Lines.Any(line => line.Contains("System.ArgumentException: Parameter 'P_ID_TIPO_RESIDENCIA' not found in the collection.")))
                {
                    // If the error message is found, add the block to the list of error blocks
                    errorBlocks.Add(block);
                }
            }

            // Return the list of error blocks
            return errorBlocks;
        }
    }
}
