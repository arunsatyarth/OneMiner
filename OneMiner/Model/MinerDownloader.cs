using Microsoft.Win32;
using OneMiner.Model.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace OneMiner.Model
{
    class MinerDownloader
    {
        private string m_url;
        private IFileIO m_fileio = null;

        public MinerDownloader(string url)
        {
            m_url = url;
        }
        private IFileIO GetFileIOObject()
        {
            IFileIO fileio = null;

            fileio = new AppData("OneMiner", "sample");
            if (fileio.Verify())
                return fileio;
            fileio = new LocalFolder();
            if (fileio.Verify())
                return fileio;

            throw new Exception("Couldnt create file");
        }
        public void DownloadFile()
        {
            try
            {
                m_fileio = GetFileIOObject();
                string filename=GetFileName();
                using (var client = new WebClient())
                {
                    client.DownloadFile(m_url, filename);

                }
                //unzip

            }
            catch (Exception e)
            {

            }

        }
        public static void Decompress(FileInfo fi)
        {
           
        }
        private static void UnRar(string WorkingDirectory, string filepath)
        {


            RegistryKey objRegKey;
            objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\\Shell\\Open\\Command");

            Object obj = objRegKey.GetValue("");

            string objRarPath = obj.ToString();
            objRarPath = objRarPath.Substring(1, objRarPath.Length - 7);

            objRegKey.Close();

            //Dim objArguments As String
            string objArguments;
            // in the following format
            // " X G:\Downloads\samplefile.rar G:\Downloads\sampleextractfolder\"
            objArguments = " X " + " " + filepath + " " + " " + WorkingDirectory;

            // Dim objStartInfo As New ProcessStartInfo()
            ProcessStartInfo objStartInfo = new ProcessStartInfo();

            // Set the UseShellExecute property of StartInfo object to FALSE
            //Otherwise the we can get the following error message
            //The Process object must have the UseShellExecute property set to false in order to use environment variables.
            objStartInfo.UseShellExecute = false;
            objStartInfo.FileName = objRarPath;
            objStartInfo.Arguments = objArguments;
            objStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            objStartInfo.WorkingDirectory = WorkingDirectory + "\\";

            //   Dim objProcess As New Process()
            Process objProcess = new Process();
            objProcess.StartInfo = objStartInfo;
            objProcess.Start();
            objProcess.WaitForExit();


            try
            {
                FileInfo file = new FileInfo(filepath);
                file.Delete();
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }



        }
        public string GetFileName()
        {
            string filename="";
            try
            {
                try
                {
                    Uri uri = new Uri(m_url);
                    if (uri.IsFile)
                    {
                        filename = System.IO.Path.GetFileName(uri.LocalPath);
                    }
                    return filename;
                }
                catch (Exception e)
                {
                }
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                return "miner1_"+randomNumber;
            }
            catch (Exception ex)
            {

            }
            return "miner1";

        }
    }
}
