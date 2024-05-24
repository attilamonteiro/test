using System;
using LogAnalyzer.UseCases;
using LogAnalyzer.Interfaces;
using LogAnalyzer.LogIO;

namespace LogAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "processamento.log";
            string resultFilePath = "result.txt";

            ILoggerRepository loggerRepository = new FileLoggerRepository();
            string[] logLines = loggerRepository.ReadAllLines(logFilePath);

            LogProcessor logProcessor = new LogProcessor();
            var blocks = logProcessor.ExtractBlocks(logLines);
            var errorBlocks = logProcessor.FindErrorBlocks(blocks);
            var groupedHashes = logProcessor.GroupHashesByRealm(errorBlocks);

            loggerRepository.WriteResults(resultFilePath, groupedHashes);
        }
    }
}
