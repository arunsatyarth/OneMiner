using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Model.FileIO
{
    class LocalFolder:IFileIO
    {


        public string FileName
        {
            get
            {
                if (!m_success)
                    throw new Exception("Couldnt create folder");
                return m_filename;
            }

        }

        public string FolderName
        {
            get
            {
                if (!m_success)
                    throw new Exception("Couldnt create file");
                return m_filename;
            }

        }
        private Boolean m_success = false;
        private string m_filename = "";
        private string m_foldername = "";

        public LocalFolder()
        {
            GetFolderName();
            GetFileName();
            Verify();

        }
        public void GetFileName()
        {
            m_filename = FolderName + @"\config.json";
        }

        public void GetFolderName()
        {
            string appdata_path = Environment.CurrentDirectory;
            try
            {
                m_foldername = appdata_path + @"\OneMiner\";
                DirectoryInfo folder = new DirectoryInfo(m_foldername);
                if (!folder.Exists)
                {
                    folder.Create();
                }
            }
            catch (Exception)
            {
                m_foldername = "";
            }
            
        }
        public Boolean Verify()
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(m_foldername);
                FileInfo file = new FileInfo(m_filename);
                if (folder.Exists)// && file.Exists) //file will be created later
                    m_success = true;
                else
                    m_success = false;
            }
            catch (Exception)
            {
                m_success = false;
            }
            return m_success;
        }
    }
}
