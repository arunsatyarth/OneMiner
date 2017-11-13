using Microsoft.Win32;
using OneMiner.Model.UnZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Model.FileIO
{
    class UnzipManager
    {
        public string ZipFileName { get; set; }
        public string OutputFolderName { get; set; }
        public string VerifyName { get; set; }//will check to see if this file is there for verify  to succeed

        public UnzipManager(string filename, string verifyName, string outputFolder)
        {
            ZipFileName = filename;
            OutputFolderName = outputFolder;
            VerifyName = verifyName;
        }

        public bool Unzip()
        {
            try
            {
                //Uses Chain of Responsibility pattern to unzip the file using different methods
                IUnzip unzip1 = new UnZipGZipStream(new UnZipRarLocal(new UnZipRarSystem(null)));
                unzip1.Init(ZipFileName, OutputFolderName, VerifyName);
                return unzip1.Unzip();
                
            }
            catch (Exception )
            {
            }
            return false;
        }
    }
}
