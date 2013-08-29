using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace bookrepotoepub.console
{
    internal static class Indexer
    {
        internal static IEnumerable<string> GetAllArchives()
        {
            return GetAllFiles("*.rar");
        }

        internal static IEnumerable<string> GetAllRichTextFiles()
        {
            return GetAllFiles("*.rtf");
        }

        private static IEnumerable<string> GetAllFiles(string filter)
        {
            var bookRepositoryLocation = ConfigurationManager.AppSettings["BookRepositoryLocation"];
            if (!string.IsNullOrWhiteSpace(bookRepositoryLocation))
            {
                return Directory.EnumerateFiles(bookRepositoryLocation, filter, SearchOption.AllDirectories);
            }
            return null;
        }
    }
}
