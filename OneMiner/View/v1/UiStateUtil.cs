using OneMiner.Core;
using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1
{
    class UiStateUtil
    {
        public static  void MiningStartAction(IMiner miner)
        {
            switch (miner.MinerState)
            {
                case MinerProgramState.Starting:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.PartiallyRunning:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Downloading:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Running:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Stopping:
                    Factory.Instance.CoreObject.StartMining(miner);
                    break;
                case MinerProgramState.Stopped:
                    Factory.Instance.CoreObject.StartMining(miner);
                    break;
                default:
                    break;
            }
        }
        public static void UpdateState(IMiner Miner, Label lblMinerState, Button btnStartMining, ContextMenuStrip optionsMenu)
        {
            string labelName = "";
            string buttontext = "";

            switch (Miner.MinerState)
            {
                case MinerProgramState.Starting:
                    lblMinerState.ForeColor = SystemColors.HotTrack;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.PartiallyRunning:
                    lblMinerState.ForeColor = SystemColors.HotTrack;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.Downloading:
                    lblMinerState.ForeColor = SystemColors.HotTrack;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.Running:
                    lblMinerState.ForeColor = Color.MediumSeaGreen;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";

                    break;
                case MinerProgramState.Stopping:
                    lblMinerState.ForeColor = Color.Tomato;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Start";
                    break;
                case MinerProgramState.Stopped:
                    lblMinerState.ForeColor = Color.Tomato;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Start";
                    break;
                default:
                    lblMinerState.ForeColor = SystemColors.HotTrack;
                    labelName = "unknown state";
                    buttontext = "unknown";
                    break;

            }
            lblMinerState.Text = labelName;
            btnStartMining.Text = buttontext;
            if(optionsMenu!=null)
                optionsMenu.Items[1].Text = buttontext;

        }
    }
}
