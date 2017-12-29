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

namespace OneMiner.Coins.CryptoNote
{
    public class CryptoNoteMiner : MinerBase
    {
        public CryptoNoteMiner(string id, ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName, IMinerData minerData) :
            base(id, mainCoin, dualMining, dualCoin, minerName, minerData)
        {

        }

        public override void SetupMiner()
        {
            ActualMinerPrograms.Clear();
            MinerPrograms.Clear();
            m_MinerProgsHash.Clear();

            IMinerProgram prog = new ClaymoreCNAmd(MainCoin, DualMining, DualCoin, Name, this);
            MinerPrograms.Add(prog);
            IMinerProgram prog2 = new CCMiner(MainCoin, DualMining, DualCoin, Name, this);
            MinerPrograms.Add(prog2);
            IMinerProgram prog3 = new ClaymoreCNCpu(MainCoin, DualMining, DualCoin, Name, this);
            MinerPrograms.Add(prog3);

            m_MinerProgsHash.Add(prog.GPUType, prog);
            m_MinerProgsHash.Add(prog2.GPUType, prog2);
            m_MinerProgsHash.Add(CardMake.CPU, prog3);
            if ( MinerGpuType == 3)
            {
                foreach (IMinerProgram item in MinerPrograms)
                {
                    item.Enabled = true;
                    ActualMinerPrograms.Add(item);
                }
            }
            else if (MinerGpuType == 1)
            {
                IMinerProgram program = m_MinerProgsHash[CardMake.Nvidia] as IMinerProgram;
                if (prog != null)
                {
                    program.Enabled = true;
                    ActualMinerPrograms.Add(program);
                }
            }
            else if (MinerGpuType == 2)
            {
                IMinerProgram program = m_MinerProgsHash[CardMake.Amd] as IMinerProgram;
                if (prog != null)
                {
                    program.Enabled = true;
                    ActualMinerPrograms.Add(program);
                }
            }

            if (ActualMinerPrograms.Count==0)//if no gpu miners found, only then add a cpu miner by default
            {
                IMinerProgram program = m_MinerProgsHash[CardMake.CPU] as IMinerProgram;
                if (prog != null)
                {
                    program.Enabled = true;
                    ActualMinerPrograms.Add(program);
                }
            }
        }


    }
}
