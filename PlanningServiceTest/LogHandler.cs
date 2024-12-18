using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace PlanningServiceTest
{
    public class LogHandler
    {
        XmlDocument _xmlLog = new XmlDocument();
        string _logPath;
        int _rowCount = 0;
        List<LogRow> _logRows = new List<LogRow>();
        string _logName = "FileProcessLog.xml";
        public LogHandler(string LogPath, bool IsLoad = false)
        {
            _logPath = LogPath;
            if (IsLoad)
                Load();
        }

        public void Load()
        {
            if (String.IsNullOrEmpty(_logPath) || !Directory.Exists(_logPath))
                return;
            string logFileName = Path.Combine(_logPath, _logName);
            if (!File.Exists(logFileName))
            {
                File.WriteAllLines(logFileName,new string[] { @"<?xml version=""1.0"" encoding=""UTF - 8""?>", @"<FilesProcessLog RowCount = ""0""/>" });                
            }
            XmlDocument xmlLog = new XmlDocument();
            try
            {
                xmlLog.Load(logFileName);
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }

            //_rowCount = Int32.Parse(xmlLog.DocumentElement.Attributes["RowCount"].Value);
            int rowIdx = 1;
            foreach (XmlNode item in xmlLog.DocumentElement.ChildNodes)
            {
                /*
                LogRow logRow = new LogRow();
                logRow.RowIndex = rowIdx++;
                logRow.FileName = item.Attributes["FileName"].Value;
                logRow.ProcessDate = DateTime.Parse(item.Attributes["ProcessDate"].Value);
                logRow.Status = item.Attributes["Status"].Value;
                logRow.Error = item.Attributes["Error"].Value;
                logRow.FilePath = item.Attributes["FilePath"].Value;
                _logRows.Add(logRow);*/
                AddRow(
                    item.Attributes["FileName"].Value, DateTime.Parse(item.Attributes["ProcessDate"].Value),
                    item.Attributes["Status"].Value, item.Attributes["Error"].Value, item.Attributes["FilePath"].Value, false
                    );
            }
        }

        public void AddRow(string FileName,DateTime ProcessDate, string Status, string Error, string FilePath, bool isSave)
        {
            LogRow logRow = new LogRow();
            logRow.RowIndex = _logRows.Count()+1;
            logRow.FileName = FileName;
            logRow.ProcessDate = ProcessDate;
            logRow.Status = Status;
            logRow.Error = Error;
            logRow.FilePath = FilePath;
            _logRows.Add(logRow);

            if (isSave)
            {
                Save();
            }
        }
        public void Save()
        {

        }

        public List<LogRow> Rows { get => _logRows; }
    }
}
