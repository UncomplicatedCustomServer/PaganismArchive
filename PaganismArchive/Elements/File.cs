using PaganismArchive.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganismArchive.Elements
{
    internal class File : IFile
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The content of the file as a single string
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Create a <see cref="File"/> istance from a name and a string content
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public File(string name, string content)
        {
            Name = name;
            Content = content;
        }

        /// <summary>
        /// Create a <see cref="File"/> istance from an existing one
        /// </summary>
        /// <param name="fileName"></param>
        public File(string fileName)
        {
            Name = fileName;
            Content = System.IO.File.ReadAllText(fileName);
        }

        public void Save()
        {
            System.IO.File.WriteAllText(Name, Content);
        }
    }
}
