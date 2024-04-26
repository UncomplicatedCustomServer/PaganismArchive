using PaganismArchive.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganismArchive.Elements
{
    internal class Archive : IArchive
    {
        /// <summary>
        /// The name of the archive
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A full list of <see cref="IFile"/> istances
        /// </summary>
        public List<IFile> Files { get; }

        /// <summary>
        /// The main file
        /// </summary>
        public IFile Pub { get; internal set; }

        /// <summary>
        /// The version of the archive
        /// </summary>
        public Version Version { get; } = new(1, 0, 0);

        /// <summary>
        /// If true every file will be included
        /// </summary>
        public bool ExecuteAll { get; set; } = false;

        /// <summary>
        /// Create an empty archive with a name
        /// </summary>
        /// <param name="name"></param>
        public Archive(string name)
        {
            Name = name;
            Files = new();
            Pub = null;
        }

        /// <summary>
        /// Create an archive with existing files
        /// </summary>
        /// <param name="name"></param>
        /// <param name="files"></param>
        /// <param name="pub"></param>
        public Archive(string name, List<IFile> files, IFile pub)
        {
            Name = name;
            Files = files;
            Pub = pub;
        }

        /// <summary>
        /// Append a file to the archive
        /// </summary>
        /// <param name="file"></param>
        public void AddFile(IFile file)
        {
            Files.Add(file);
        }

        /// <summary>
        /// Append a file to the archive
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public void AddFile(string name, string content)
        {
            Files.Add(new File(name, content));
        }

        /// <summary>
        /// Remove a file from the archive
        /// </summary>
        /// <param name="file"></param>
        public void RemoveFile(IFile file)
        {
            if (Files.Contains(file))
            {
                Files.Remove(file);
            }
        }

        /// <summary>
        /// Set the main file
        /// </summary>
        /// <param name="file"></param>
        public void SetPub(IFile file)
        {
            if (Files.Contains(file))
            {
                Pub = file;
            }
        }

        public string Encode()
        {
            if (Pub is null)
            {
                return "";
            }

            string Data = string.Empty;
            Data += $"PGMACR\u0004{Convert.ToBase64String(Encoding.UTF8.GetBytes(Version.ToString()))}\u0004{Convert.ToBase64String(Encoding.UTF8.GetBytes(Name))}\u0004{Convert.ToBase64String(Encoding.UTF8.GetBytes(Pub.Name))}";
            foreach (IFile File in Files)
            {
                Data += $"¶¶¶\u0004\u0004\u0004¶¶{File.Name}¶{Convert.ToBase64String(Encoding.UTF8.GetBytes(File.Content))}";
            }
            return Data;
        }
    }
}
