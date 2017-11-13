using Microsoft.Win32;
using OneMiner.Model.UnZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Model.FileIO
{
    class Unzipper
    {
        public string ZipFileName { get; set; }
        public string OutputFolderName { get; set; }

        private string LookForInstalledWinrar()
        {
            string objRarPath="";
            try
            {
                RegistryKey objRegKey;
                objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\\Shell\\Open\\Command");

                Object obj = objRegKey.GetValue("");

                objRarPath = obj.ToString();
                objRarPath = objRarPath.Substring(1, objRarPath.Length - 7);

                objRegKey.Close();
                FileInfo winrar = new FileInfo(objRarPath);
                if (!winrar.Exists)
                    throw new Exception ("File not found");
            }
            catch (Exception e)
            {
                return "";
            }
            return objRarPath;
        }
        private string LookForLocalWinrar()
        {
            string objRarPath = "";
            try
            {
                string currentFolder = Environment.CurrentDirectory;


                objRarPath = currentFolder + @"\WinRAR\WinRAR.exe";

                FileInfo winrar = new FileInfo(objRarPath);
                if (!winrar.Exists)
                    throw new Exception("File not found");
            }
            catch (Exception e)
            {
                return "";
            }
            return objRarPath;
        }
        public void Unzip()
        {
            try
            {
                IUnzip unzip1 = new UnZipGZipStream();
                IUnzip unzip2 = new UnZipRarLocal();
                IUnzip unzip3 = new UnZipRarSystem();

                unzip1.SetNExtChain(unzip2);
                unzip2.SetNExtChain(unzip3);

                bool success=unzip1.Unzip();
                
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
}
