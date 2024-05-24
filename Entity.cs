/*
    Title: LogBlock
    Description: This class represents a block of log lines.
*/

using System.Collections.Generic; // Importing the namespace for List<T>

namespace LogAnalyzer.Entities
{
    /*
        Class: LogBlock
        Description: This class represents a block of log lines.
    */
    public class LogBlock
    {
        /*
            Property: Lines
            Description: Gets or sets the list of lines in the log block.
        */
        public List<string> Lines { get; set; } = new List<string>();
    }
}
