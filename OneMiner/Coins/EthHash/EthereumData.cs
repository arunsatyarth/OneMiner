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
    public class EthereumData : MinerData, IMiner
    {
        public List<IMinerProgram> MinerPrograms { get; set; }
        Hashtable m_MinerProgsHash = new Hashtable();
        HashSet<string> m_MinerRunningHash =new  HashSet<string>();

        public ICoin MainCoin { get; set; }
        public ICoin DualCoin { get; set; }
        private IMinerData MinerData { get; set; }

        public bool DualMining { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }//not sure if needed
        public MinerProgramState MinerState { get; set; }


        public EthereumData(string id, ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName, IMinerData minerData)
        {
            MinerState = MinerProgramState.Stopped;
            Id = id;
            MainCoin = mainCoin;
            DualCoin = dualCoin;
            DualMining = dualMining;
            Name = minerName;
            MinerData = minerData;
            MinerPrograms = new List<IMinerProgram>();
            SetupMiner();
        }
        public void InitializePrograms()
        {
            try
            {
                DB db = Factory.Instance.Model.Data;
                MinerAlgo algo = null;
                foreach (MinerAlgo item in db.MinerAlgos)
                {
                    if (item.Name == MainCoin.Algorithm.Name)
                    {
                        //found the algo. check to see alredy configured miners
                        algo = item;
                        break;
                    }
                }
                if (algo != null)
                {
                    List<MinerProgram> programs = algo.MinerPrograms;
                    //if (programs != null && programs.Count > 0)
                    //{
                        //at least 1 program is there
                        Hashtable progs = new Hashtable();
                        Hashtable scripts = new Hashtable();
                        foreach (MinerProgram item in programs)
                        {
                            progs.Add(item.ProgramType, item);
                        }
                        foreach (MinerScript item in MinerData.MinerScripts)
                        {
                            scripts.Add(item.ProgramType, item);
                        }
                        foreach (IMinerProgram item in MinerPrograms)
                        {
                            MinerProgram p = progs[item.Type] as MinerProgram;
                            MinerScript scr = scripts[item.Type] as MinerScript;
                            if (p != null)
                            {
                                item.MinerEXE = p.Exepath;
                                item.MinerFolder = p.ExeFolder;
                            }
                            if (scr != null)
                            {
                                item.BATFILE = scr.BATfile;
                                item.BATCopied = scr.BATCopied;
                                item.AutomaticScriptGeneration = scr.AutomaticScriptGeneration;
                                item.LoadScript();

                            }
                        }
                    //}

                }
            }
            catch (Exception)
            {
            }
        }
        public void SetRunningState(IMinerProgram program, MinerProgramState state)
        {
            int count = MinerPrograms.Count;
            if(state!=MinerProgramState.Running)
            {
                m_MinerRunningHash.Remove(program.Type);
            }
            else
            {
                m_MinerRunningHash.Add(program.Type);
            }
            if (m_MinerRunningHash.Count == 0)
                MinerState = MinerProgramState.Stopped;
            else if (m_MinerRunningHash.Count < MinerPrograms.Count)
                MinerState = MinerProgramState.PartiallyRunning;
            else if (m_MinerRunningHash.Count == MinerPrograms.Count)
                MinerState = MinerProgramState.Running;
            else
                MinerState = MinerProgramState.Stopping;//ideally it shudnt com here
            Factory.Instance.ViewObject.UpDateMinerState();

        }
        public void SetupMiner()
        {
            IMinerProgram prog=new ClaymoreMiner(MainCoin, DualMining, DualCoin, Name,this);
            MinerPrograms.Add(prog);
            m_MinerProgsHash.Add(prog.Type, prog);
        }
        public void StartMining()
        {
            MinerState = MinerProgramState.Starting;

            foreach (IMinerProgram item in MinerPrograms)
            {
                //push miners into mining queue wher they wud be picked up by threads and executed
                Factory.Instance.CoreObject.MiningQueue.Enqueue(item);
            }
            Factory.Instance.ViewObject.UpDateMinerState();
        }
        public void StopMining()
        {
            MinerState = MinerProgramState.Stopping;
            m_MinerRunningHash.Clear();

            foreach (IMinerProgram item in MinerPrograms)
            {
                //push miners into mining queue wher they wud be picked up by threads and executed
                item.KillMiner();
            }
            MinerState = MinerProgramState.Stopped;
            Factory.Instance.ViewObject.UpDateMinerState();


        }



    }
}
