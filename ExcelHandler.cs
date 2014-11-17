using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataLoader
{
    class ExcelHandler
    {
        public string FileName;
        public DBHandler dbhandler;

        private DateTime GetDateFromFileName(out int CL)
        {
            DateTime FDate = DateTime.Now;
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            CL = 0;
            if (fileName.IndexOf("_", 0) > 0)
            {
                fileName = fileName.Substring(fileName.IndexOf("_", 0) + 1);
                if (fileName.Length == 4)
                {
                    CL = 1;
                    int year = DateTime.Now.Year;
                    FDate = DateTime.Parse("01.01." + year);
                }
                if (fileName.Length == 6)
                {
                    CL = 3;
                }
            }
            return FDate;
        }
        
        private string GetOKATOFromFileName() 
        {
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            fileName = fileName.Substring(1, fileName.Length - 1);
            if (fileName.IndexOf("_", 0) > 0)
            {
                fileName = fileName.Substring(0, fileName.IndexOf("_", 0));
            }
            return fileName;
        }

        private void LoadDataFromSheet(Excel.Worksheet excelWorksheet, int SubjectId, int CL, DateTime FDate)
        {

        }
        
        public void LoadData()
        {
            LogHandler logHandler = new LogHandler(Path.GetDirectoryName(FileName) + "\\logfile.log");
            string OKATO = GetOKATOFromFileName();
            int SubjectId;
            if (!int.TryParse(OKATO, out SubjectId))
            {
                logHandler.WriteLogStr("Ошибка определения ОКАТО из имени файла (" + FileName  + ")");
                return;
            }
            int CL;
            DateTime FDate = GetDateFromFileName(out CL);
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(FileName,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
            try
            {
                Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                Excel.Worksheet excelWorksheet;
                for (int i = 1; i <= excelSheets.Count; i++)
                {
                    excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(i);
                    LoadDataFromSheet(excelWorksheet, SubjectId, CL, FDate);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheets);
            }
            catch (Exception le)
            {
                logHandler.WriteLogStr(le.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                excelWorkbook.Close(0);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            
        }

    }
}
