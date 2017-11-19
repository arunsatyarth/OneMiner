using OneMiner.Core;
using OneMiner.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OneMiner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IView view = Factory.Instance.ViewObject;
            view.InitializeView();

            Factory.Instance.CoreObject.LoadDBData();
            view.StartView();
        }
    }
}
