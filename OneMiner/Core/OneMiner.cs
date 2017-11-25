using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OneMiner.Core
{
    class OneMiner
    {
        public List<IMiner> Miners = new List<IMiner>();
        public IMiner ActiveMiner = null;//the current mining miner, if no miners are mining activeminer wud be null
        public IMiner SelectedMiner = null;//the one who is selected. if no miners are mining selectedminer cud be still not null

        //expose them with funs
        public Queue<IMinerProgram> MiningQueue { get; set; }
        public Queue<IMinerProgram> DownloadingQueue { get; set; }
        public volatile bool m_keepMining = true;
        public volatile bool m_keepRunning = true;
        Thread m_minerThread;
        Thread m_downloadingThread;
        private object m_locker = new object();
        private int m_ThreadCount = 0;
        public int IncrThreadCount()
        {
            lock (m_locker)
            {
                m_ThreadCount++;
                return m_ThreadCount;
            }
        }
        public int DecrThreadCount()
        {
            lock (m_locker)
            {
                m_ThreadCount--;
                return m_ThreadCount;

            }
        }
        public int GetThreadCount()
        {
            lock (m_locker)
            {
                return m_ThreadCount;
            }
        }
        public OneMiner()
        {
            MiningQueue = new Queue<IMinerProgram>();
            DownloadingQueue = new Queue<IMinerProgram>();

            m_minerThread = new Thread(new ParameterizedThreadStart(MiningThread));
            m_downloadingThread = new Thread(new ParameterizedThreadStart(DownLoadingThread));

        }
        public void AddMiner(IMiner miner, bool makeSelected)
        {
            Miners.Add(miner);
            Factory.Instance.Model.AddMiner(miner);
            if (makeSelected)
            {
                SelectMiner(miner);
            }
            Factory.Instance.ViewObject.UpdateMinerList();
        }
        public void SelectMiner(IMiner miner)
        {
            SelectedMiner = miner;
            Factory.Instance.Model.MakeSelectedMiner(miner);
            Factory.Instance.ViewObject.UpdateMinerList();
        }

        void MiningThread(object obj)
        {
            IncrThreadCount();
            List<IMinerProgram> runningMiners = new List<IMinerProgram>();
            while (m_keepRunning)//thread runs as long as app is on
            {
                if (MiningQueue.Count == 0 || m_keepMining==false)
                    Thread.Sleep(2000);
                else
                {
                    IMinerProgram miner = MiningQueue.Dequeue();
                    if (miner.ReadyForMining())
                    {
                        miner.StartMining();
                        runningMiners.Add(miner);
                    }
                    else
                        DownloadingQueue.Enqueue(miner);
                }
                if(m_keepMining)
                {
                    //Ensure all started miners are still running
                    foreach (IMinerProgram item in runningMiners)
                    {
                        if(!item.Running())
                        {
                            //just to be sure. we never want to start miner twice
                            item.KillMiner();
                            //Dont directly start mining. push it to queue and let the workflow start
                            MiningQueue.Enqueue(item);
                        }
                    }
                }
                else
                {
                    //Kill all running  miners and go to sleep for some time
                    foreach (IMinerProgram item in runningMiners)
                    {
                        item.KillMiner();
                    }

                }
            }
            DecrThreadCount();

        }
        void DownLoadingThread(object obj)
        {
            IncrThreadCount();
            while (m_keepRunning)
            {
                if (DownloadingQueue.Count == 0 || m_keepMining == false)
                    Thread.Sleep(2000);
                else
                {
                    IMinerProgram miner = DownloadingQueue.Dequeue();
                    miner.DownloadProgram();
                    if (miner.ReadyForMining())
                        MiningQueue.Enqueue(miner);

                }
            }
            DecrThreadCount();

        }
        void InitiateThreads()
        {
            m_minerThread.Start();
            m_downloadingThread.Start();
        }
        public void StartMining()
        {
            //check if current mining threads have exited properly
            while (GetThreadCount() > 0)
            {
                Thread.Sleep(2000);
            }
            m_keepMining = true;
            ActiveMiner = SelectedMiner;
            SelectedMiner.StartMining();
            InitiateThreads();
        }
        public void StartMining(IMiner miner)
        {
            StopMining();
            SelectedMiner = miner;
            StartMining();
        }
        public void StopMining()
        {
            m_keepMining = false;
            SelectedMiner.StopMining();
            ActiveMiner = null;
        }
        public void LoadDBData()
        {
            //Todo:loda core from the db
            DB db = Factory.Instance.Model.Data;
            //1. Load mineralgos and miner programs
            if (db.Miners.Count == 0)
            {
                //load default ether miner
                IHashAlgorithm algo = Factory.Instance.DefaultAlgorithm;
                IMiner miner = algo.DefaultMiner();
                if (miner != null)
                    Miners.Add(miner);
                SelectedMiner = miner;



            }
            else
            {
                IMiner miner =null;
                foreach (IMinerData item in db.Miners)
                {
                    IHashAlgorithm algo = Factory.Instance.CreateAlgoObject(item.Algorithm);
                    miner = algo.RegenerateMiner(item);
                    if (miner != null)
                    {
                        Miners.Add(miner);
                        if (miner.Id == db.CurrentMinerId)
                            SelectedMiner = miner;
                    }
                }
                if (SelectedMiner == null)
                    SelectedMiner = miner;
            }
            //2. load configured miners
        }

        public void CloseApp()
        {
            m_keepRunning = false;
            Environment.Exit(0);
            
        }


    }
}
