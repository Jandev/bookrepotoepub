using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrepotoepub.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var allArchives = Indexer.GetAllArchives().ToList();
            Console.WriteLine("Found " + allArchives.Count + " archives");

            var extracter = new Extracter();
            foreach (var archive in allArchives)
            {
                Console.WriteLine("Extracting: " + archive);
                extracter.ExtractArchiveToLocalPath(archive);
                Console.WriteLine("Extracted: " + archive);
#if DEBUG
                break;
#endif
            }
        }
    }
}
