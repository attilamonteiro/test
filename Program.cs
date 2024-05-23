using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string logFilePath = "processamento.log";
        string resultFilePath = "result.txt";

        var logLines = File.ReadAllLines(logFilePath);
        var blocks = ExtractBlocks(logLines);
        var errorBlocks = FindErrorBlocks(blocks);
        var groupedHashes = GroupHashesByRealm(errorBlocks);

        WriteResults(resultFilePath, groupedHashes);
    }

    static List<List<string>> ExtractBlocks(string[] logLines)
    {
        List<List<string>> blocks = new List<List<string>>();
        List<string>? currentBlock = null;

        foreach (var line in logLines)
        {
            if (line.Contains("Iniciando interpretação da mensagem..."))
            {
                currentBlock = new List<string>();
                blocks.Add(currentBlock);
            }

            if (currentBlock != null)
            {
                currentBlock.Add(line);
            }

            if (line.Contains("Trabalho com pedidos foi finalizado.") && currentBlock != null)
            {
                currentBlock = null;
            }
        }

        Console.WriteLine($"Total blocks extracted: {blocks.Count}");
        return blocks;
    }

    static List<List<string>> FindErrorBlocks(List<List<string>> blocks)
    {
        List<List<string>> errorBlocks = new List<List<string>>();

        foreach (var block in blocks)
        {
            if (block.Any(line => line.Contains("System.ArgumentException: Parameter 'P_ID_TIPO_RESIDENCIA' not found in the collection.")))
            {
                errorBlocks.Add(block);
            }
        }

        Console.WriteLine($"Total error blocks found: {errorBlocks.Count}");
        return errorBlocks;
    }

    static Dictionary<string, List<string>> GroupHashesByRealm(List<List<string>> errorBlocks)
    {
        Dictionary<string, List<string>> groupedHashes = new Dictionary<string, List<string>>();

        foreach (var block in errorBlocks)
        {
            List<string> hashes = new List<string>();
            string? realm = null;

            foreach (var line in block)
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

    static void WriteResults(string filePath, Dictionary<string, List<string>> groupedHashes)
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
