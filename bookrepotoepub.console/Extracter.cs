using System.Configuration;
using System.Diagnostics;

namespace bookrepotoepub.console
{
    internal class Extracter
    {
        internal void ExtractArchiveToLocalPath(string archive)
        {
            var sevenZip = ConfigurationManager.AppSettings["7zipExecutableLocation"];
            var outputDirectory = PathHelper.GenerateOutputDirectory(archive);

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = sevenZip;
            processStartInfo.Arguments = string.Format("e \"{0}\" -o\"{1}\"", archive, outputDirectory);
            processStartInfo.WindowStyle = ProcessWindowStyle.Normal;

            
            var process = Process.Start(processStartInfo);
            process.WaitForExit();
        }
    }
}
