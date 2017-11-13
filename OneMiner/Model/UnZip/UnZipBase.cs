using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Model.UnZip
{
    class UnZipBase : IUnzip
    {
        public string ZipFileName { get; set; }
        public string OutputFolderName { get; set; }
        public string VerifyName { get; set; }//will check to see if this file is there for verify  to succeed

        protected FileInfo m_zipfileInfo = null;
        public IUnzip m_NextActor = null;
        public UnZipBase(IUnzip next)
        {
            m_NextActor = next;
        }
        public virtual bool UnzipUtil()
        {
            return false;
        }
        public bool Verify()
        {
            DirectoryInfo folder = new DirectoryInfo(OutputFolderName);
            string miner=folder.FullName+@"\"+VerifyName;
            FileInfo minerFile=new FileInfo(miner);
            if (folder.Exists && minerFile.Exists)
                return true;
            return false;
        }
        public bool Unzip()
        {
            bool success = UnzipUtil();
            if (success && Verify())
                return true;
            else
            {
                //Call the next item in chain of responsibility
                if (m_NextActor == null)
                    return false;
                m_NextActor.Init(ZipFileName, OutputFolderName,VerifyName);
                return m_NextActor.Unzip();
            }

        }
        public void Init(string zipfile, string outputfile, string verifyName)
        {
            ZipFileName = zipfile;
            OutputFolderName = outputfile;
            VerifyName = verifyName;
            m_zipfileInfo = new FileInfo(zipfile);
        }
        /// <summary>
        /// used to change any actors in the chain of responsibility later
        /// </summary>
        /// <param name="unzip"></param>
        public void SetNExtChain(IUnzip unzip)
        {
            m_NextActor = unzip;
        }
    }
}
