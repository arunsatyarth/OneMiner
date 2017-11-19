using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
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

        public OneMiner CoreObject { get; set; }
        public Config Model { get; set; }



        private IView s_view = null;
        private Factory ()
	    {

            s_view = new V1View();
            Model = new Config();
            CoreObject = new OneMiner(Model);
            m_algoHash[AlgoEnums.EthHash] = new EthHash.EthHash();
            m_algorithms.Add(m_algoHash[AlgoEnums.EthHash] as IHashAlgorithm);
	    }
        private void Init()
        {

            Model.AddAlgorithms(m_algorithms);
        }
        public static Factory Instance
        {
            get
            {
                if (s_obj == null)
                {
                    s_obj = new Factory();
                    s_obj.Init();
                }
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
        //Todo: maybe this shud be created w=everytime addminer is clicked. that way we wont be reusing ojects
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
                //Todo: maybe this shud be created w=everytime addminer is clicked. that way we wont be reusing ojects
                return m_algoHash[AlgoEnums.EthHash] as IHashAlgorithm;
            }
        }

    }
}
