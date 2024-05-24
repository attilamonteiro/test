using System;
using System.Collections.Generic;
using System.Linq;
using LogAnalyzer.Entities;

namespace LogAnalyzer.UseCases
{
    public class LogProcessor
    {
        public List<LogBlock> ExtractBlocks(string[] logLines)
        {
            var blockExtractor = new LogBlockExtractor();
            return blockExtractor.ExtractBlocks(logLines);
        }

        public List<LogBlock> FindErrorBlocks(List<LogBlock> blocks)
        {
            var errorBlockFinder = new ErrorBlockFinder();
            return errorBlockFinder.FindErrorBlocks(blocks);
        }

        public Dictionary<string, List<string>> GroupHashesByRealm(List<LogBlock> errorBlocks)
        {
            var hashGrouper = new HashGrouper();
            return hashGrouper.GroupHashesByRealm(errorBlocks);
        }
    }

    public class LogBlockExtractor
    {
        public List<LogBlock> ExtractBlocks(string[] logLines)
        {
            List<LogBlock> blocks = new List<LogBlock>();
            LogBlock? currentBlock = null;

            foreach (var line in logLines)
            {
                if (line.Contains("Iniciando interpretação da mensagem..."))
                {
                    currentBlock = new LogBlock();
                    blocks.Add(currentBlock);
                }

                if (currentBlock != null)
                {
                    currentBlock.Lines.Add(line);
                }

                if (line.Contains("Trabalho com pedidos foi finalizado.") && currentBlock != null)
                {
                    currentBlock = null;
                }
            }

            Console.WriteLine($"Total blocks extracted: {blocks.Count}");
            return blocks;
        }
    }

    public class ErrorBlockFinder
    {
        public List<LogBlock> FindErrorBlocks(List<LogBlock> blocks)
        {
            List<LogBlock> errorBlocks = new List<LogBlock>();

            foreach (var block in blocks)
            {
                if (block.Lines.Any(line => line.Contains("System.ArgumentException: Parameter 'P_ID_TIPO_RESIDENCIA' not found in the collection.")))
                {
                    errorBlocks.Add(block);
                }
            }

            Console.WriteLine($"Total error blocks found: {errorBlocks.Count}");
            return errorBlocks;
        }
    }

    public class HashGrouper
    {
        public Dictionary<string, List<string>> GroupHashesByRealm(List<LogBlock> errorBlocks)
        {
            Dictionary<string, List<string>> groupedHashes = new Dictionary<string, List<string>>();

            foreach (var block in errorBlocks)
            {
                List<string> hashes = new List<string>();
                string? realm = null;

                foreach (var line in block.Lines)
                {
                    if (line.Contains("item.MensagemHash:"))
                    {
                        var hash = line.Split(new[] { "item.MensagemHash:" }, StringSplitOptions.None)[1].Trim();
                        hashes.Add(hash);
                        Console.WriteLine($"Found hash: {hash}");
                    }
                    else if (line.Contains("item.RealmInicial:"))
                    {
                        var realmLine = line;
                        realm = realmLine.Split(new[] { "item.RealmInicial:" }, StringSplitOptions.None)[1].Trim();
                        Console.WriteLine($"Found realm: {realm}");
                    }
                }

                if (!string.IsNullOrEmpty(realm) && hashes.Count > 0)
                {
                    if (!groupedHashes.ContainsKey(realm))
                    {
                        groupedHashes[realm] = new List<string>();
                    }

                    foreach (var hash in hashes)
                    {
                        groupedHashes[realm].Add(hash);
                    }
                }
            }

            return groupedHashes;
        }
    }
}
