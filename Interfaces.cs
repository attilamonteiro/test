using System.Collections.Generic;

namespace LogAnalyzer.Interfaces
{
    public interface ILoggerRepository
    {
        string[] ReadAllLines(string logFilePath);
        void WriteResults(string filePath, Dictionary<string, List<string>> groupedHashes);
    }
}
