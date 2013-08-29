using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrepotoepub.console
{
    internal static class PathHelper
    {
        internal static string GenerateOutputDirectory(string path)
        {
            var currentDirectory = Path.GetDirectoryName(path);
            var currentFilename = Path.GetFileNameWithoutExtension(path);
            return String.Format("{0}\\{1}\\", currentDirectory, currentFilename);
        }
    }
}
