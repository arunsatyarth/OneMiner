using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Model.FileIO
{
    interface IFileIO
    {
        string FileName { get; set; }
        string FolderName { get; set; }
        Boolean Verify();
    }
}
