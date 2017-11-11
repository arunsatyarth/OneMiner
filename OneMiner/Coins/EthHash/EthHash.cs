using OneMiner.Coins.EthHash;
using OneMiner.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    class EthHash : IHashAlgorithm
    {
        enum EthHashCoins{
            Ethereum=0,
            EtherClassic,
            Ubiq,
            Expanse,
            End
        }
        enum EthHashDualCoins
        {
            Siacoin=0,
            Decred,
            End
        }
        List<ICoin> m_SupportedDualCoins = new List<ICoin>();
        List<ICoin> m_SupportedCoins = new List<ICoin>();
        Hashtable m_CoinsHash = new Hashtable();

        public EthHash()
        {
            m_CoinsHash[EthHashCoins.Ethereum] = new Ethereum();
            m_CoinsHash[EthHashCoins.EtherClassic] = new EtherClassic();

            m_CoinsHash[EthHashDualCoins.Decred] = new Decred();

            //Now add it to the lists
            m_SupportedCoins.Add(m_CoinsHash[EthHashCoins.EtherClassic] as ICoin);
            m_SupportedCoins.Add(m_CoinsHash[EthHashCoins.Ethereum] as ICoin);


            m_SupportedDualCoins.Add(m_CoinsHash[EthHashDualCoins.Decred] as ICoin);

        }
        public string Name
        {
            get
            {
                return "Ethhash";
            }
           
        }
        public List<ICoin> SupportedCoins 
        { 
            get 
            {
                return m_SupportedCoins;
            } 
        }

        public bool SupportsDualMining
        {
            get { return true; }
        }

        public List<ICoin> SupportedDualCoins
        {
            get
            {
                return m_SupportedDualCoins;
            }

        }
        public ICoin DefaultCoin
        {
            get
            {
                return m_CoinsHash[EthHashCoins.Ethereum] as ICoin;
            }

        }
    }
}
