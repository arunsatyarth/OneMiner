using OneMiner.Coins.EthHash;
using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
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
            m_CoinsHash[EthHashCoins.Ethereum] = new Ethereum(this);
            m_CoinsHash[EthHashCoins.EtherClassic] = new EtherClassic(this);

            m_CoinsHash[EthHashDualCoins.Decred] = new Decred(this);

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

        public ICoin DefaultDualCoin
        {
            get
            {
                return m_CoinsHash[EthHashDualCoins.Decred] as ICoin;
            }

        }
        string GenerateUniqueID()
        {
            string id=Factory.Instance.Model.GenerateUniqueID();
            return id;
        }
        public IMiner CreateMiner(ICoin mainCoin,bool dualMining,ICoin dualCoin , string minerName)
        {

            IMiner miner = new EthereumData(GenerateUniqueID(), mainCoin,  dualMining,  dualCoin,    minerName);
            return miner;
        }

    }
}
