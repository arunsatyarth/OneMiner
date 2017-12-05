using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace OneMiner
{
    static public class WinApi
    {

        [DllImportAttribute("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern bool SendMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

    }
    static class Program
    {

        static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string filename = @"c:\pics\a.txt";
                Stream stream = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(stream);
                string s = sr.ReadToEnd();
                sr.Close();

                filename = @"c:\pics\b.txt";
                Stream stream2 = new FileStream(filename, FileMode.Open);
                StreamReader sr2 = new StreamReader(stream2);
                string s2 = sr2.ReadToEnd();
                sr2.Close(); 
                
                
                filename = @"c:\pics\c.txt";
                Stream stream3 = new FileStream(filename, FileMode.Open);
                StreamReader sr3 = new StreamReader(stream3);
                string s3 = sr3.ReadToEnd();
                sr3.Close();


                MinerDataResult minerResult = (MinerDataResult)new JavaScriptSerializer().Deserialize(s, typeof(MinerDataResult));
                if (minerResult.Parse(new OneMiner.Coins.Equihash.ClaymoreMinerZcash.ClayMoreZcashReader.ZcashClaymoreResultParser(s2, true)))
                {
                }


                OneMiner.Coins.Equihash.EWBFMiner.EWBFData r = (OneMiner.Coins.Equihash.EWBFMiner.EWBFData)new JavaScriptSerializer()
                    .Deserialize(s3, typeof(OneMiner.Coins.Equihash.EWBFMiner.EWBFData));

                OneMiner.Coins.Equihash.EWBFMiner.EWBFData ewbfData = r;
                if (ewbfData.Parse(new OneMiner.Coins.Equihash.EWBFMiner.EWBFReader.EWBFReaderResultParser("", true)))
                {
                }



                //Bring only a single instance
                bool onlyInstance = false;
                mutex = new Mutex(true, "UniqueApplicationName", out onlyInstance);
                if (!onlyInstance)
                {
                    IntPtr handle = WinApi.FindWindow(null, "OneMiner - 1 Click Miner for Ethereum, ZCash");
                    if (handle != IntPtr.Zero)
                        WinApi.PostMessage(handle, 3000, IntPtr.Zero, IntPtr.Zero);
                    return;
                }
            }
            catch (Exception e)
            {
            }
            
            IView view = Factory.Instance.ViewObject;
            view.InitializeView();

            Factory.Instance.CoreObject.LoadDBData();
            view.StartView();
            
        }
    }
}
