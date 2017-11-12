using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Model
{
    class MinerDownloader
    {
        private string m_url;
        public MinerDownloader(string url)
        {
            m_url = url;
        }
        public void DownLoad()
        {
            //Todo: Use a threadpool to download the miners
        }
    }
}
