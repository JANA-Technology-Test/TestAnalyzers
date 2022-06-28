using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnalyzers
{
    public class RSPEC2930Noncompliant
    {
        private FileStream fs; // Noncompliant; Dispose or Close are never called

        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open);
        }

        public void WriteToFile(string path, string text)
        {
            var fs = new FileStream(path, FileMode.Open); // Noncompliant
            var bytes = Encoding.UTF8.GetBytes(text);
            fs.Write(bytes, 0, bytes.Length);
        }
    }
}
