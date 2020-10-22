using System.Diagnostics;
using System.IO;
using System.Text;

namespace Generator
{
    public class GeneratedFile
    {

        private readonly string fullPath;
        private readonly StringBuilder builder;

        public GeneratedFile(string fullPath)
        {
            this.fullPath = fullPath;
            builder = new StringBuilder();
        }

        public void Append(string line)
        {
            builder.Append(line);
        }

        public void AppendLine(string line)
        {
            builder.AppendLine(line);
        }

        public void WriteToDisk()
        {
            Debug.WriteLine("Write To Disk");
            Debug.WriteLine(fullPath);
            File.WriteAllText(fullPath, builder.ToString());
        }

        #region Properties
        public string FullPath { get => fullPath; }
        #endregion (Properties)

    }
}