using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Kernel
{
    public class PlanningConfigHandle : SettingsHandle
    {
        string _fileName;
        PlanningConfig _planningConfig;
        StringCryptor _stringCryptor = new StringCryptor();
        public PlanningConfigHandle(string FileName, PlanningConfig PlanningConfig) : base(FileName)
        {
            _fileName = FileName;
            _planningConfig = PlanningConfig;
        }

        public override void Load()
        {
            _planningConfig.ServerName = GetParamStringValue("Connection\\ServerName");
            _planningConfig.BaseName = GetParamStringValue("Connection\\BaseName");
            _planningConfig.UserName = GetParamStringValue("Connection\\UserName");
            _planningConfig.Password = _stringCryptor.Decode(GetParamStringValue("Connection\\Password"));
        }

        public override void Save()
        {
            SetParamValue("Connection\\ServerName", _planningConfig.ServerName);
            SetParamValue("Connection\\UserName", _planningConfig.UserName);
            SetParamValue("Connection\\BaseName", _planningConfig.BaseName);
            SetParamValue("Connection\\Password", _stringCryptor.Encode(_planningConfig.Password));
        }
    }
}
