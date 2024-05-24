/*
    Title: HashGrouper
    Description: This class provides functionality to group hashes by realm within a list of error blocks.
*/

using System; // Importing the namespace for System class
using System.Collections.Generic; // Importing the namespace for Dictionary<TKey, TValue> and List<T>
using LogAnalyzer.Entities; // Importing the namespace for LogBlock

namespace LogAnalyzer.UseCases
{
    /*
        Class: HashGrouper
        Description: This class is responsible for grouping hashes by realm within a list of error blocks.
    */
    public class HashGrouper
    {
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
            // Initialize a dictionary to store grouped hashes
            Dictionary<string, List<string>> groupedHashes = new Dictionary<string, List<string>>();

            // Iterate through each error block in the provided list
            foreach (var block in errorBlocks)
            {
                // Initialize a list to store hashes and a variable to store realm
                List<string> hashes = new List<string>();
                string? realm = null;

                // Iterate through each line in the error block
                foreach (var line in block.Lines)
                {
                    // Check if the line contains information about hash
                    if (line.Contains("item.MensagemHash:"))
                    {
                        // Extract the hash and add it to the list of hashes
                        var hash = line.Split(new[] { "item.MensagemHash:" }, StringSplitOptions.None)[1].Trim();
                        hashes.Add(hash);
                    }
                    // Check if the line contains information about realm
                    else if (line.Contains("item.RealmInicial:"))
                    {
                        // Extract the realm information
                        var realmLine = line;
                        realm = realmLine.Split(new[] { "item.RealmInicial:" }, StringSplitOptions.None)[1].Trim();
                    }
                }

                // Check if realm and hashes are both available
                if (!string.IsNullOrEmpty(realm) && hashes.Count > 0)
                {
                    // If the realm is not already in the dictionary, add it
                    if (!groupedHashes.ContainsKey(realm))
                    {
                        groupedHashes[realm] = new List<string>();
                    }

                    // Add hashes associated with the realm to the dictionary
                    foreach (var hash in hashes)
                    {
                        groupedHashes[realm].Add(hash);
                    }
                }
            }

            // Return the dictionary containing grouped hashes
            return groupedHashes;
        }
    }
}
