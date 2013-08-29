using System;
using System.Linq;

namespace bookrepotoepub.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("** Start search & extract **");
            Console.WriteLine("****************************");
            var allArchives = Indexer.GetAllArchives().ToList();
            Console.WriteLine("Found " + allArchives.Count + " archives");

            var extracter = new Extracter();
            foreach (var archive in allArchives)
            {
                Console.WriteLine("Extracting: " + archive);
                extracter.ExtractArchiveToLocalPath(archive);
                Console.WriteLine("Extracted: " + archive);
#if DEBUG
                //break;
#endif
            }
            Console.WriteLine("**********************");
            Console.WriteLine("** Start converting **");
            Console.WriteLine("**********************");
            var officeWorker = new OfficeWorker();
            var allRichTextDocuments = Indexer.GetAllRichTextFiles();
            foreach (var richTextDocument in allRichTextDocuments)
            {
                Console.WriteLine("Converting: " + richTextDocument);
                officeWorker.ConvertToWordDocument(richTextDocument);
                Console.WriteLine("Converted: " + richTextDocument);
            }
        }
    }
}
