/*
    Title: LogProcessor
    Description: This class provides high-level functionality to process log data, including extraction of log blocks, identification of error blocks, and grouping of hashes by realm.
*/

using System; // Importing the namespace for System class
using System.Collections.Generic; // Importing the namespace for List<T>
using LogAnalyzer.Entities; // Importing the namespace for LogBlock
using LogAnalyzer.UseCases; // Importing the namespaces for LogBlockExtractor, ErrorBlockFinder, and HashGrouper classes

namespace LogAnalyzer.UseCases
{
    public class LogProcessor
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
            // Create an instance of LogBlockExtractor to extract log blocks
            var blockExtractor = new LogBlockExtractor();
            // Call the ExtractBlocks method of the blockExtractor instance and return the result
            return blockExtractor.ExtractBlocks(logLines);
        }

        /*
            Method: FindErrorBlocks
            Description: Identifies error blocks within a list of LogBlocks.
            Parameters:
                - blocks: A list of LogBlocks to search for errors.
            Returns:
                A list of LogBlocks containing error messages.
        */
        public List<LogBlock> FindErrorBlocks(List<LogBlock> blocks)
        {
            // Create an instance of ErrorBlockFinder to find error blocks
            var errorBlockFinder = new ErrorBlockFinder();
            // Call the FindErrorBlocks method of the errorBlockFinder instance and return the result
            return errorBlockFinder.FindErrorBlocks(blocks);
        }

        /*
            Method: GroupHashesByRealm
            Description: Groups hashes by realm within a list of error blocks.
            Parameters:
                - errorBlocks: A list of LogBlocks containing error information.
            Returns:
                A dictionary where keys are realms and values are lists of hashes associated with each realm.
        */
        public Dictionary<string, List<string>> GroupHashesByRealm(List<LogBlock> errorBlocks)
        {
            // Create an instance of HashGrouper to group hashes by realm
            var hashGrouper = new HashGrouper();
            // Call the GroupHashesByRealm method of the hashGrouper instance and return the result
            return hashGrouper.GroupHashesByRealm(errorBlocks);
        }
    }
}
