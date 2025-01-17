using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Planning.Service
{
    public class LogHandler
    {
        XmlDocument _xmlLog = new XmlDocument();
        string _logPath;
        int _rowCount = 0;
        List<LogRow> _logRows = new List<LogRow>();
        string _logName = "FileProcessLog.xml";
        
        bool _isLoaded = false;
        bool _isOpened = false;
        public LogHandler(string LogPath, bool IsLoad = false)
        {
            _logPath = LogPath;
            if (IsLoad)
                Load();
        }
        public void Open()
        {
            string logPath = Path.GetDirectoryName(_logPath);
            if (String.IsNullOrEmpty(logPath) || !Directory.Exists(logPath))
                return;
            //string logFileName = Path.Combine(_logPath, _logName);
            if (!File.Exists(_logPath))
            {
                File.WriteAllLines(_logPath, new string[] { @"<?xml version=""1.0"" encoding=""UTF - 8""?>", @"<FilesProcessLog/>" });
            }

            _xmlLog = new XmlDocument();
            try
            {
                StreamReader streamReader = new StreamReader(_logPath, Encoding.UTF8);
                _xmlLog.Load(streamReader);
                _isOpened = true;
            }
            catch (Exception ex)
            {
                Common.AddEventToLog("ERROR", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public void Load()
        {




            if (!_isOpened)
                return;
            //_rowCount = Int32.Parse(xmlLog.DocumentElement.Attributes["RowCount"].Value);
            int rowIdx = 1;
            foreach (XmlNode item in _xmlLog.DocumentElement.ChildNodes)
            {
                AddRowToList(
                    item.Attributes["FileName"].Value, DateTime.Parse(item.Attributes["ProcessDate"].Value),
                    item.Attributes["Status"].Value, item.Attributes["Error"].Value, item.Attributes["FilePath"].Value
                    );
            }
            _isLoaded = true;
        }

        public void AddRow(string FileName,DateTime ProcessDate, string Status, string Error, string FilePath, bool isSave)
        {
            if (!_isOpened)
                return;
            if (_isLoaded)
                AddRowToList(FileName, ProcessDate, Status, Error, FilePath);
            else
                AddRowToFile(FileName, ProcessDate, Status, Error, FilePath);

            if (isSave)
            {
                Save();
            }
        }

        private void AddRowToList(string FileName, DateTime ProcessDate, string Status, string Error, string FilePath)
        {
            LogRow logRow = new LogRow();
            logRow.RowIndex = _logRows.Count() + 1;
            logRow.FileName = FileName;
            logRow.ProcessDate = ProcessDate;
            logRow.Status = Status;
            logRow.Error = Error;
            logRow.FilePath = FilePath;
            _logRows.Add(logRow);
        }

        private void AddRowToFile(string FileName, DateTime ProcessDate, string Status, string Error, string FilePath)
        {

            XmlElement rowNode = _xmlLog.CreateElement("File");
            rowNode.SetAttribute("RowIndex", (_xmlLog.DocumentElement.ChildNodes.Count+1).ToString());
            rowNode.SetAttribute("FileName", FileName);
            rowNode.SetAttribute("ProcessDate", ProcessDate.ToString("G"));
            rowNode.SetAttribute("Status", Status);
            rowNode.SetAttribute("Error", Error);
            rowNode.SetAttribute("FilePath", FilePath);

            _xmlLog.DocumentElement.AppendChild(rowNode);
        }
        public void Save()
        {
            if (!_isOpened)
                return;

            if (_isLoaded)
            {
                _xmlLog.CreateXmlDeclaration("1.0", "UTF-8", "");
                XmlElement root = _xmlLog.CreateElement("FilesProcessLog");
                int idx = 1;
                foreach (LogRow logRow in _logRows)
                {
                    AddRowToFile(logRow.FileName, logRow.ProcessDate, logRow.Status, logRow.Error, logRow.FilePath);
                }                
            }
            try
            {
                using (TextWriter sw = new StreamWriter(_logPath, false, Encoding.UTF8)) //Set encoding
                {
                    _xmlLog.Save(sw);
                }
            }
            catch (Exception ex)
            {

                Common.AddEventToLog("ERROR", ex.Message);
            }
        }

        public List<LogRow> Rows { get => _logRows; }
    }
}
