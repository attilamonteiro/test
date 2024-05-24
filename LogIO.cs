using System;
using System.Collections.Generic;
using System.IO;
using LogAnalyzer.Interfaces;

namespace LogAnalyzer.LogIO
{
    public class FileLoggerRepository : ILoggerRepository
    {
        public string[] ReadAllLines(string logFilePath)
        {
            return File.ReadAllLines(logFilePath);
        }

        public void WriteResults(string filePath, Dictionary<string, List<string>> groupedHashes)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var realm in groupedHashes.Keys)
                {
                    writer.WriteLine(realm);
                    foreach (var hash in groupedHashes[realm])
                    {
                        writer.WriteLine($"\"{hash}\",");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
