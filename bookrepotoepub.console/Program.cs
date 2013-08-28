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
            var allArchives = Indexer.GetAllArchives();

            var extracter = new Extracter();
            foreach (var archive in allArchives)
            {
                extracter.ExtractArchiveToLocalPath(archive);
            }
        }
    }
}
