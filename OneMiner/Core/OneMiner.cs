using OneMiner.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            if (makeSelected)
                SelectedMiner = miner;

            Factory.Instance.ViewObject.UpdateMinerList();
        }
        void MiningThread(object obj)
        {
            IncrThreadCount();
            while (m_keepMining)
            {
                if (MiningQueue.Count == 0)
                    Thread.Sleep(4000);
                else
                {
                    IMinerProgram miner = MiningQueue.Dequeue();
                    if (miner.ProgramPresent())
                    {
                        miner.StartMining();
                    }
                    else
                        DownloadingQueue.Enqueue(miner);
                }
            }
            DecrThreadCount();

        }
        void DownLoadingThread(object obj)
        {
            IncrThreadCount();
            while (m_keepMining)
            {
                if (DownloadingQueue.Count == 0)
                    Thread.Sleep(4000);
                else
                {
                    IMinerProgram miner = DownloadingQueue.Dequeue();
                    miner.DownloadProgram();
                    if (miner.ProgramPresent())
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
            while (GetThreadCount()>0)
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

    }
}
