using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace bookrepotoepub.console
{
    internal class OfficeWorker
    {
        private readonly string _savePath;
        public OfficeWorker()
        {
            _savePath = ConfigurationManager.AppSettings["ConvertedWordDocumentLocation"];
        }
        internal void ConvertToWordDocument(string pathToRtfFile)
        {
            Document currentDoc = null;
            Application wordApp = null;
            try
            {
                var filename = string.Format("{0}.docx", Path.GetFileNameWithoutExtension(pathToRtfFile));
                var fullFilePath = string.Format("{0}\\{1}", _savePath, filename);

                wordApp = new Application();
                currentDoc = wordApp.Documents.Open(pathToRtfFile);
                
                Debug.WriteLine("Saving file: '{0}'", fullFilePath, null);
                currentDoc.SaveAs(fullFilePath, WdSaveFormat.wdFormatXMLDocument);
                Debug.WriteLine("Saved file: '{0}'", fullFilePath, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An exception occurred while saving a file: '{0}'", ex.Message, null);
            }
            finally
            {
                if (currentDoc != null)
                {
                    currentDoc.Close();
                }
                if (wordApp != null)
                {
                    wordApp.Quit();
                }
            }
        }
    }
}
