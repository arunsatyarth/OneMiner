using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Model.UnZip
{
    class UnZipRarLocal : IUnzip
    {
        public bool Unzip()
        {
            throw new NotImplementedException();
        }

        public void Init(string zipfile, string outputfile)
        {
            throw new NotImplementedException();
        }
        public void SetNExtChain(IUnzip unzip)
        {
            m_NextActor = unzip;
        }
    }
}
