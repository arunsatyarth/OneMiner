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
        public List<IMiner> Miners = null;
        public IMiner ActiveMiner = null;

        //expose them with funs
        public Queue<IMiner> MiningQueue { get; set; }
        public Queue<IMiner> DownloadingQueue { get; set; }
        public volatile bool m_keepMining=true;
        Thread m_minerThread;
        Thread m_downloadingThread;
        public OneMiner()
        {
            MiningQueue = new Queue<IMiner>();
            DownloadingQueue = new Queue<IMiner>();

            m_minerThread = new Thread(new ParameterizedThreadStart(MiningThread));
            m_downloadingThread = new Thread(new ParameterizedThreadStart(DownLoadingThread));

        }
        void MiningThread(object obj)
        {
            while (m_keepMining)
            {
                if (MiningQueue.Count == 0)
                    Thread.Sleep(4000);
                else
                {
                    IMiner miner = MiningQueue.Dequeue();
                    if (miner.ProgramPresent())
                    {
                        miner.StartMining();
                    }
                    else
                        DownloadingQueue.Enqueue(miner);
                }
            }
        
        }
        void DownLoadingThread(object obj)
        {
            while (m_keepMining)
            {
                if (DownloadingQueue.Count == 0)
                    Thread.Sleep(4000);
                else
                {
                    IMiner miner = DownloadingQueue.Dequeue();
                    miner.DownloadProgram();
                    if (miner.ProgramPresent())
                        MiningQueue.Enqueue(miner);

                }
            }
        }
        void InitiateThreads()
        {
            m_minerThread.Start();
            m_downloadingThread.Start();
        }
        void StartMining()
        {
            m_keepMining = true;

            ActiveMiner.StartMining();
            InitiateThreads();
        }
        void StopMining()
        {
            m_keepMining=false;
        }

    }
}
