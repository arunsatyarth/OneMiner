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
        private string m_zipFilename;
        private string m_verifyName;
        private IFileIO m_fileio = null;

        public MinerDownloader(string url,string verifyName)
        {
            m_url = url;
            m_verifyName = verifyName;
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
        /// <summary>
        /// doenloads the zip file uncompresses it and returns the foldername
        /// </summary>
        /// <returns></returns>
        public string DownloadFile()
        {
            try
            {
                m_fileio = GetFileIOObject();
                m_zipFilename = GetFileName();
                using (var client = new WebClient())
                {
                    client.DownloadFile(m_url, m_zipFilename);

                }
                //unzip
                return Decompress();

            }
            catch (Exception e)
            {
            }
            return "";

        }
        /// <summary>
        /// decompresses the file
        /// </summary>
        public  string Decompress()
        {
            FileInfo fileInfo = new FileInfo(m_zipFilename);
            string curFile = fileInfo.FullName;
            string folder = curFile.Remove(curFile.Length -fileInfo.Extension.Length);
            UnzipManager unzip = new UnzipManager(m_zipFilename, m_verifyName, folder);
            if (unzip.Unzip())
                return folder;
            return "";

        }
       
        /// <summary>
        /// gets filename from the url of the miner. will be the name of the folder when decompressed
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            string filename = "";
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
                return "miner1_" + randomNumber;
            }
            catch (Exception ex)
            {

            }
            return "miner1";

        }
    }
}
