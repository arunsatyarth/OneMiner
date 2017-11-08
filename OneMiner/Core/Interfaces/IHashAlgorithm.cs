using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core.Interfaces
{
    interface IHashAlgorithm
    {
        string Name { get; }
        List<ICoin> SupportedCoins { get; }


    }
}
