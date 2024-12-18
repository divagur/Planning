using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Service
{
    public class Settings
    {
        public string RootDirPath { get; set; }
        public string LogDirPath { get; set; }
        public string SubDirList { get; set; }
        public string FileType { get; set; } = "*";
        public int ActionType { get; set; } = 0;


        public string MailAddressFrom { get; set; }
        public string MailAddressTo { get; set; }

        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string MailHeader { get; set; }
        public string MailBodyTemplate { get; set; }
    }
}
