using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1
{
    public partial class AddMinerContainer : Form
    {
        private int m_currentState = 0;
        AddMiner m_addMiner = null;
        AddDualMiner m_addDualMiner = null;
        ConfigureMiner m_configureMiner = null;
        private ICoin m_selected_coin = null;
        public AddMinerContainer()
        {
            m_addMiner = new AddMiner(this);
            m_addDualMiner = new AddDualMiner(this);
            InitializeComponent();
        }
        public void EnableNextButton()
        {
            btnNext.Enabled = true;
        }
        public void EnablePreviousButton()
        {
            btnPrevious.Enabled = true;
        }
        public void DisableNextButton()
        {
            btnNext.Enabled = false;
        }
        public void DisablePreviousButton()
        {
            btnPrevious.Enabled = false;
        }

        public void SelectedCoin(ICoin coin)
        {
            m_selected_coin = coin;
        }

        public void NextStage()
        {
            m_currentState++;
            ShowStage();
            EnablePreviousButton();

        }
        public void PreviousStage()
        {
            if (m_currentState > 0)
            {
                m_currentState--;
                ShowStage();
                if (m_currentState == 0)
                    DisablePreviousButton();
            }
        }
        public void ShowStage()
        {
            Form objForm = null;
            switch (m_currentState)
            {
                case 0:
                    objForm = m_addMiner;
                    break;
                case 1:
                    //objForm = m_configureMiner;

                    if (m_selected_coin != null)
                    {
                        ICoinConfigurer form = m_selected_coin.SettingsScreen;
                        form.AssignParent(this);
                        objForm = form as Form;
                    }
                    break;
                case 2:
                    objForm = m_addMiner;
                    break;


            }
            if (objForm != null)
            {
                objForm.TopLevel = false;
                pnlForm.Controls.Clear();
                pnlForm.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextStage();
        }

        private void AddMinerContainer_Load(object sender, EventArgs e)
        {
            ShowStage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousStage();
        }
    }
}
