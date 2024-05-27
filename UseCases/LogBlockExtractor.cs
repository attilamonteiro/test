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
            var blocks = new List<LogBlock>();
            LogBlock? currentBlock = null;

            foreach (var line in logLines)
            {
                if (line.Contains("Iniciando interpretação da mensagem..."))
                {
                    currentBlock = new LogBlock();
                    blocks.Add(currentBlock);
                }

                currentBlock?.Lines.Add(line);
            }

            return blocks;
        }
    }
}
