using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLoader
{
    class LogHandler
    {
        string FileName;
        public string fileName { get { return FileName; } }
        public LogHandler(string fileName)
        {
            FileName = fileName;
        }

        public void WriteLogStr(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(new FileStream(FileName, FileMode.Append)))
            {
                streamWriter.WriteLine("{0} {1}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), message);
            }
        }

        public void WriteMessage(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(new FileStream(FileName, FileMode.Append)))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
