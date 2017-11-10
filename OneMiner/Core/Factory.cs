using OneMiner.Core.Interfaces;
using OneMiner.View;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core
{
    class Factory
    {
        public static Factory s_obj=null;
        private List<IHashAlgorithm> m_algorithms = new List<IHashAlgorithm>();
        private Factory ()
	    {
            m_algorithms.Add(new EthHash.EthHash());
	    }
        public static Factory Instance
        {
            get
            {
                if (s_obj == null)
                    s_obj = new Factory();
                return s_obj;
            }
        }
        public IView ViewObject
        {
            get
            {
                return new V1View();
            }
        }
        public List<IHashAlgorithm> Algorithms
        {
            get
            {
                return m_algorithms;
            }
        }

    }
}
