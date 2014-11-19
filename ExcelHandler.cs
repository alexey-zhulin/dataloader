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

        private bool GetDateFromFileName(out int CL, out DateTime FDate)
        {
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            CL = 0;
            FDate = DateTime.Now;
            if (fileName.IndexOf("_", 0) > 0)
            {
                fileName = fileName.Substring(fileName.IndexOf("_", 0) + 1);
                if (fileName.Length == 4)
                {
                    CL = 1;
                    int year;
                    if (!int.TryParse(fileName, out year)) 
                    {
                        return false;
                    }
                    FDate = DateTime.Parse("01.01." + year);
                    return true;
                }
                if (fileName.Length == 6)
                {
                    CL = 3;
                    int year;
                    if (!int.TryParse(fileName.Substring(2, 4), out year))
                    {
                        return false;
                    }
                    string quaterStr = fileName.Substring(0, 2);
                    if (quaterStr == "01")
                    {
                        FDate = DateTime.Parse("01.01." + year);
                    }
                    else if (quaterStr == "02")
                    {
                        FDate = DateTime.Parse("01.04." + year);
                    }
                    else if (quaterStr == "03")
                    {
                        FDate = DateTime.Parse("01.07." + year);
                    }
                    else if (quaterStr == "04")
                    {
                        FDate = DateTime.Parse("01.10." + year);
                    }
                    return true;
                }
            }
            return false;
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
            const int MaxRowCount = 1000000;
            const int MaxEmptyStr = 5;
            LogHandler logHandler = new LogHandler(Path.GetDirectoryName(FileName) + "\\logfile.log");
            Excel.Range range = excelWorksheet.get_Range("A1", "F1");
            int countColumt = 0;
            // Вначале проверим на корректность первой строки (должо быть 5 или 6 непустых ячеек)
            for (int i = 1; i <= range.Count; i++)
            {
                var cellValue = (string)(excelWorksheet.Cells[1, i] as Excel.Range).Value;
                if (cellValue != null)
                {
                    countColumt = countColumt + 1;
                }
            }
            if (!(countColumt == 5 || countColumt == 6))
            {
                logHandler.WriteLogStr("Количество колонок (" + countColumt + ") отличается от ожидаемого (5 или 6)");
                return;
            }
            // Выполним саму загрузку данных (со второй строки - первая заголовок)
            int countEmpty = 0;
            DBRecord dbrecord = new DBRecord();
            for (int i = 2; i <= MaxRowCount; i++)
            {
                // Идентифицировать пустую запись будем идентифицировать по пустому значению второй колонки (param) текущей строки
                var cellValue = (excelWorksheet.Cells[i, 1] as Excel.Range).Value;
                if (cellValue == null)
                {
                    countEmpty = countEmpty + 1;
                }
                else
                {
                    countEmpty = 0; // Сбросим счетчик пустых значений
                    object param = (excelWorksheet.Cells[i, 1] as Excel.Range).Value;
                    object paramCode = (excelWorksheet.Cells[i, 2] as Excel.Range).Value;
                    object aValue1 = (excelWorksheet.Cells[i, 3] as Excel.Range).Value;
                    object aValue2 = (excelWorksheet.Cells[i, 4] as Excel.Range).Value;
                    object aValue3;
                    object paramCode2;
                    if (countColumt == 5)
                    {
                        aValue3 = null;
                        paramCode2 = (excelWorksheet.Cells[i, 5] as Excel.Range).Value;
                    }
                    else
                    {
                        aValue3 = (excelWorksheet.Cells[i, 5] as Excel.Range).Value;
                        paramCode2 = (excelWorksheet.Cells[i, 6] as Excel.Range).Value;
                    }
                    // Проверим полученные значения
                    if (!(aValue1 is double))
                    {
                        aValue1 = null;
                    }
                    if (!(aValue2 is double))
                    {
                        aValue2 = null;
                    }
                    if (!(aValue3 is double))
                    {
                        aValue3 = null;
                    }
                    dbrecord.ParamCode = paramCode;
                    dbrecord.AValue1 = aValue1;
                    dbrecord.AValue2 = aValue2;
                    dbrecord.AValue3 = aValue3;
                    dbrecord.ParamCode2 = paramCode2;
                    dbrecord.SubjectId = SubjectId;
                    dbrecord.CL = CL;
                    dbrecord.FDate = FDate;
                    dbrecord.Param = param;
                    dbhandler.InsertRecord(dbrecord);
                }
                // Если количество пустых строк превысило максимально допустимое - значит данные закончились. Выходим.
                if (countEmpty >= MaxEmptyStr)
                {
                    break;
                }
            }
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
            DateTime FDate;
            if (!GetDateFromFileName(out CL, out FDate))
            {
                logHandler.WriteLogStr("Ошибка определения даты из имени файла (" + FileName  + ")");
                return;
            }
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(FileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            int curStr = 0;
            try
            {
                for (int i = 1; i <= excelSheets.Count; i++)
                {
                    curStr = curStr + 1;
                    Excel.Worksheet excelWorksheet = excelSheets.get_Item(i);
                    LoadDataFromSheet(excelWorksheet, SubjectId, CL, FDate);
                }
            }
            catch (Exception e)
            {
                logHandler.WriteLogStr(e.Message);
            }
            finally
            {

            }
            excelWorkbook.Close(0);
            excelApp.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
}
