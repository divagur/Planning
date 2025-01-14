using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningServiceTest
{
    public class Settings
    {
        public string InputFileDirPath { get; set; }
        public string SuccessFileDirPath { get; set; }
        public string ErrorFileDirPath { get; set; }
        public string FileType { get; set; } = "*.xml";
        public string LogDirPath { get; set; }
        public string FileInvoiceCustomMask { get; set; }
        public string FileInvoiceProductionMask { get; set; }
        public int RecalcCount { get; set; }
        public string ServerName { get; set; }
        public string PlanningBaseName { get; set; }
        public string PlanningBaseLogin { get; set; }
        public string PlanningBasePwd { get; set; }

    }
}
