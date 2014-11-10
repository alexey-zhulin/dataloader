using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLoader
{
    class ExcelHandler
    {
        public string FileName;
        public DBHandler dbhandler;

        private string GetOKATOFromFileName() 
        {
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            fileName = fileName.Substring(1, fileName.Length - 1);
            if (fileName.IndexOf("_", 0) > 0)
            {
                fileName = fileName.Substring(0, fileName.Length - fileName.IndexOf("_", 0));
            }
            return fileName;
        }
        
        public void LoadData()
        {
            string OKATO = GetOKATOFromFileName();
            int SubjectId;
            if (!int.TryParse(OKATO, out SubjectId))
            {
                return;
            }
        }

    }
}
