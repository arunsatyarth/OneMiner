using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core.Interfaces
{
    public interface  IOutputReader
    {
        //Todo:Assign callback which will call ui maybe whenever we get new data
        //or kep everything in queue here and push pul l wen needed
        void AlarmRaised();
        string LastLog { get; set; }
    }
}
