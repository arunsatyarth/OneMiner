using OneMiner.Coins;
using OneMiner.Coins.EthHash;
using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace OneMiner.Coins.Equihash
{
    public class ZCashMiner : MinerBase
    {
        public ZCashMiner(string id, ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName, IMinerData minerData) :
            base(id, mainCoin, dualMining, dualCoin, minerName, minerData)
        {

        }

        public override void SetupMiner()
        {
            IMinerProgram prog = new ClaymoreMinerZcash(MainCoin, DualMining, DualCoin, Name, this);
            MinerPrograms.Add(prog);
            IMinerProgram prog2 = new EWBFMiner(MainCoin, DualMining, DualCoin, Name, this);
            MinerPrograms.Add(prog2);

            m_MinerProgsHash.Add(CardMake.Amd, prog);
            m_MinerProgsHash.Add(CardMake.Nvidia, prog2);

            if (MinerGpuType == 0 || MinerGpuType == 3)
            {
                foreach (IMinerProgram item in MinerPrograms)
                {
                    ActualMinerPrograms.Add(item);
                }
            }
            else if (MinerGpuType == 1)
            {
                IMinerProgram program = m_MinerProgsHash[CardMake.Nvidia] as IMinerProgram;
                if (prog != null)
                    ActualMinerPrograms.Add(program);
            }
            else if (MinerGpuType == 2)
            {
                IMinerProgram program = m_MinerProgsHash[CardMake.Amd] as IMinerProgram;
                if (prog != null)
                    ActualMinerPrograms.Add(program);
            }
        }

    }
}
