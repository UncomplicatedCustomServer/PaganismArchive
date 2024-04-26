using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganismArchive.Interfaces
{
    internal interface IArchive
    {
        public abstract string Name { get; }

        public abstract List<IFile> Files { get; }

        public abstract IFile Pub { get; }

        public abstract Version Version { get; }

        public abstract bool ExecuteAll { get; }
    }
}
