using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace bookrepotoepub.console
{
    internal static class Indexer
    {
        internal static IEnumerable<string> GetAllArchives()
        {
            var bookRepositoryLocation = ConfigurationManager.AppSettings["BookRepositoryLocation"];
            if (!string.IsNullOrWhiteSpace(bookRepositoryLocation))
            {
                return Directory.EnumerateFiles(bookRepositoryLocation, "*.rar", SearchOption.AllDirectories);
            }
            return null;
        }
    }
}
