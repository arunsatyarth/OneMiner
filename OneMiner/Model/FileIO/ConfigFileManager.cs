using OneMiner.Model.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Model
{
    class ConfigFileManager
    {
        string m_filepath = "";
        private IFileIO m_fileio = null;
        //private string m_data = "";
        public string Data { get; set; }
        private IFileIO GetFileIOObject()
        {
            IFileIO fileio = null;
        
            fileio = new AppData("OneMiner", "config.json");
            if (fileio.Verify())
                return fileio;
            fileio = new LocalFolder();
            if (fileio.Verify())
                return fileio;
         
            throw new Exception("Couldnt create file");
        }
        public ConfigFileManager()
        {
            try
            {
                m_fileio = GetFileIOObject();
                LoadData();
            }
            catch (Exception e)
            {

            }
            

        }
        private string GetFileName()
        {
            return m_fileio.FileName;

        }
        private void LoadData()
        {
            try
            {
                string filename = GetFileName();
                Stream stream = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(stream);
                Data = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception e)
            {

            }
        }
        public void WriteData()
        {
            try
            {
                string filename = GetFileName();
                Stream stream = new FileStream(filename, FileMode.Create);
                StreamWriter sr = new StreamWriter(stream);
                sr.Write(Data);
                sr.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
