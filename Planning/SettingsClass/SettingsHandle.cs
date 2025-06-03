using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Planning.Kernel;
namespace Planning
{

    public class PlanningSettingsHandle:SettingsHandle
    {

        private Settings _settings;

        public PlanningSettingsHandle(string FileName, Settings settings)
            : base(FileName)
        {
            _settings = settings;
        }
        static public string Encode(string data)
        {
            string result = data;

            byte[] encData_byte = Encoding.UTF8.GetBytes(data);
            result = Convert.ToBase64String(encData_byte);

            return result;
        }

        static public string Decode(string data)
        {
            string result = data;
            string decode = string.Empty;

            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            result = new String(decoded_char);

            return result;
        }

        public override void Save()
        {
            SetParamValue("Connection\\ServerName", _settings.ServerName);
            SetParamValue("Connection\\UserName", _settings.UserName);
            SetParamValue("Connection\\BaseName", _settings.BaseName);
            SetParamValue("Connection\\Password", Encode(_settings.Password));
            SetParamValue("ReportTemplate\\ShipmentTemplate", _settings.ShipmentReport);
            SetParamValue("ReportTemplate\\ReceiptTemplate", _settings.ReceiptReport);
            SetParamValue("ReportTemplate\\PeriodTemplate", _settings.PeriodReport);
            SetParamValue("TaskUpdateInterval", _settings.TaskUpdateInterval.ToString());
            SetParamValue("TaskViewFonSize", _settings.TaskViewFonSize.ToString());
            SetParamValue("Connection\\LastLogin", _settings.LastLogin);
            SetParamList<CurrTaskColumn>("CurrentTaskColumns", "Column", _settings.CurrentTaskColumns);
            SetParamList<VolumeCalcConstant>("VolumeCalcTemplates", "Template", _settings.VolumeCalcTemplate);
            SetParamList<SettingReport>("Reports", "Report", _settings.Reports);
            SetParamValue("VolumeCalcParams\\ImportStartRow", _settings.volumeCalcParams.ImportStartRow);
            SetParamValue("VolumeCalcParams\\ImportColVendorCode", _settings.volumeCalcParams.ImportColVendorCode);
            SetParamValue("VolumeCalcParams\\ImportColName", _settings.volumeCalcParams.ImportColName);
            SetParamValue("VolumeCalcParams\\ImportColAmount", _settings.volumeCalcParams.ImportColAmount);
            SetParamValue("ShowOrderDetailColumn", _settings.ShowDetailOrderColumn);
            SetParamValue("DefaultWarehouseCode", _settings.DefaultWarehouseCode);
            SetParamValue("DefaultTransportViewCode", _settings.DefaultTransportViewName);
        }

        public override void Load()
        {
            _settings.ServerName = GetParamStringValue("Connection\\ServerName");
            _settings.BaseName = GetParamStringValue("Connection\\BaseName");
            _settings.UserName = GetParamStringValue("Connection\\UserName");
            string hash = GetParamStringValue("Connection\\Password");
            //_settings.Password = Decode(GetParamStringValue("Connection\\Password"));
            _settings.Password = GetParamStringValue("Connection\\Password");
            _settings.LastLogin = GetParamStringValue("Connection\\LastLogin");
            _settings.ShipmentReport = GetParamStringValue("ReportTemplate\\ShipmentTemplate");
            _settings.ReceiptReport = GetParamStringValue("ReportTemplate\\ReceiptTemplate");
            _settings.PeriodReport = GetParamStringValue("ReportTemplate\\PeriodTemplate");
            _settings.TaskUpdateInterval = GetParamDecimalCheckValue("TaskUpdateInterval", 0, 10);
            _settings.TaskViewFonSize = GetParamDecimalCheckValue("TaskViewFonSize", 0, 5);
            _settings.CurrentTaskColumns = GetParamList<CurrTaskColumn>("CurrentTaskColumns");
            _settings.VolumeCalcTemplate = GetParamList<VolumeCalcConstant>("VolumeCalcTemplates");
            _settings.Reports = GetParamList<SettingReport>("Reports");
            if (_settings.Reports.Count == 0)
            {
                _settings.Reports = new List<SettingReport>();
                _settings.Reports.Add(new SettingReport() { Id = "1", Name = "Лист отгрузки", TemplatePath = _settings.ShipmentReport });
                _settings.Reports.Add(new SettingReport() { Id = "2", Name = "Лист прихода", TemplatePath = _settings.ReceiptReport });
                _settings.Reports.Add(new SettingReport() { Id = "3", Name = "Отгрузки за период", TemplatePath = _settings.PeriodReport });
                _settings.Reports.Add(new SettingReport() { Id = "4", Name = "Статистика за период", TemplatePath = "" });
                _settings.Reports.Add(new SettingReport() { Id = "5", Name = "Отчет по ТС", TemplatePath = "" });
            }
            _settings.volumeCalcParams.ImportStartRow = GetParamIntValue("VolumeCalcParams\\ImportStartRow",2);
            _settings.volumeCalcParams.ImportColVendorCode = GetParamIntValue("VolumeCalcParams\\ImportColVendorCode",1);
            _settings.volumeCalcParams.ImportColName = GetParamIntValue("VolumeCalcParams\\ImportColName", 2);
            _settings.volumeCalcParams.ImportColAmount = GetParamIntValue("VolumeCalcParams\\ImportColAmount", 3);
            _settings.ShowDetailOrderColumn = GetParamBoolValue("ShowOrderDetailColumn", true);
            _settings.DefaultWarehouseCode = GetParamStringValue("DefaultWarehouseCode");
            _settings.DefaultTransportViewName = GetParamStringValue("DefaultTransportViewCode");
        }

    }
}
