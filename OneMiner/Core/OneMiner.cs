using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core
{
    class OneMiner
    {
        public List<IMiner> Miners = null;
        public IMiner ActiveMiner = null;

    }
}
