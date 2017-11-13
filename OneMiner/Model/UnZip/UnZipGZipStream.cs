using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace OneMiner.Model.UnZip
{
    class UnZipGZipStream : IUnzip
    {
        public string ZipFileName { get; set; }
        public string OutputFolderName { get; set; }
        private FileInfo m_zipfileInfo = null;
        public IUnzip m_NextActor = null;
        public UnZipGZipStream()
        {

        }
        void Init(string zipfile, string outputfile)
        {
            ZipFileName = zipfile;
            OutputFolderName = outputfile;
            m_zipfileInfo = new FileInfo(zipfile);
        }
        public void SetNExtChain(IUnzip unzip)
        {
            m_NextActor = unzip;
        }

        public bool UnzipUtil()
        {
            try
            {
                using (FileStream inFile = m_zipfileInfo.OpenRead())
                {
                    string curFile = m_zipfileInfo.FullName;
                    string origName = curFile.Remove(curFile.Length -
                            m_zipfileInfo.Extension.Length);

                    using (FileStream outFile = File.Create(origName))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile,
                                CompressionMode.Decompress))
                        {
                            Decompress.CopyTo(outFile);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
            }
            return false;


        }
        public bool Unzip()
        {
            bool success = UnzipUtil();
            if (success)
                return success;
            else
            {
                //Call the next item in chain of responsibility
                if (m_NextActor == null)
                    return false;
                m_NextActor.Init(ZipFileName, OutputFolderName);
                return m_NextActor.Unzip();
            }

        }

    }
}
