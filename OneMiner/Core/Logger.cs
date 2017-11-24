using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core
{
    /// <summary>
    /// Thread safe logger
    /// </summary>
    public class Logger : ILogger
    {
        private static ILogger s_obj = null;
        private static object s_singletonsynch = new object();
        private static object s_accesssynch = new object();
        public void LogInfo(string error)
        {
            lock (s_accesssynch)
            {
                //logging code
            }
        }

        public void LogError(string error)
        {
            lock (s_accesssynch)
            {
                //logging code

            }
        }

        private Logger()
        {
        }

        public static ILogger Instance
        {
            get
            {
                if (s_obj != null)
                    return s_obj;
                else
                {
                    lock (s_singletonsynch)//Locking singleton
                    {
                        if (s_obj == null)
                            s_obj = new Logger();
                        return s_obj;
                    }

                }
            }
        }
    }
}
