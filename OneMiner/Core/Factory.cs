using OneMiner.Core.Interfaces;
using OneMiner.View;
using OneMiner.View.v1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core
{
    class Factory
    {
        enum AlgoEnums
        {
            EthHash = 0,
            Equihash,
            Cryptonyte,
            End
        }
        private static Factory s_obj=null;
        private List<IHashAlgorithm> m_algorithms = new List<IHashAlgorithm>();
        Hashtable m_algoHash = new Hashtable();

        private IView s_view = null;
        private Factory ()
	    {
            m_algoHash[AlgoEnums.EthHash] = new EthHash.EthHash();
            m_algorithms.Add(m_algoHash[AlgoEnums.EthHash] as IHashAlgorithm);
            s_view = new V1View();
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
                return s_view;
            }
        }
        public List<IHashAlgorithm> Algorithms
        {
            get
            {
                return m_algorithms;
            }
        }
        /// <summary>
        /// This will be the algo that will be given precendence if we hav to display anywhere
        /// </summary>
        public IHashAlgorithm DefaultAlgorithm
        {
            get
            {
                return m_algoHash[AlgoEnums.EthHash] as IHashAlgorithm;
            }
        }

    }
}
