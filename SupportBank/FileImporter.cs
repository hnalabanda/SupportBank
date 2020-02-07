using System;
using System.IO;
namespace SupportBank
{
    public class FileImporter
    {
        private string inputFile { get; set; }

        public string GetImportFile()
        {
             inputFile = Console.ReadLine();
             var fileInfo=new FileInfo(inputFile);
             return fileInfo.Extension;

        }
        
        public 
       
    }
}