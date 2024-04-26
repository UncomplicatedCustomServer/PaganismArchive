using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganismArchive.Interfaces
{
    internal interface IFile
    {
        public abstract string Name { get; }

        public abstract string Content { get; }
    }
}
