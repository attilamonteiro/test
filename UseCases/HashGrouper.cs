using System;
using System.Collections.Generic;
using LogAnalyzer.Entities;

namespace LogAnalyzer.UseCases
{
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
                    if (line.Contains("item.RealmInicial:"))
                    {
                        realm = line.Split(new[] { "item.RealmInicial:" }, StringSplitOptions.None)[1].Trim();
                        break; // Exit inner loop if realm is found first
                    }
                    else if (line.Contains("item.MensagemHash:"))
                    {
                        var hash = line.Split(new[] { "item.MensagemHash:" }, StringSplitOptions.None)[1].Trim();
                        hashes.Add(hash);
                    }
                }

                if (!string.IsNullOrEmpty(realm) && hashes.Count > 0)
                {
                    if (!groupedHashes.ContainsKey(realm))
                    {
                        groupedHashes[realm] = new List<string>();
                    }

                    groupedHashes[realm].AddRange(hashes);
                }
            }

            return groupedHashes;
        }
    }
}
