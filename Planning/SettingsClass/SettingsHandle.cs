using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Planning
{

    public class SettingsHandle
    {

        private Settings _settings;
        private XmlDocument _xDoc = new XmlDocument();
        string _settingPath;
        public SettingsHandle(string FileName, Settings settings)
        {
            _settingPath = FileName;
            _settings = settings;
            if (!File.Exists(FileName))
            {
                //MessageBox.Show($"Файл {FileName} не найдет","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                _xDoc.AppendChild(_xDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
                _xDoc.AppendChild(_xDoc.CreateElement("Settings"));
                _xDoc.Save(_settingPath);
            }
            else
            {
                _xDoc.Load(_settingPath);
            }

        }

        private XmlElement FindNodeByName(XmlElement Node, string Name)
        {
            if (!Node.HasChildNodes)
            {
                return null;
            }
            foreach (XmlElement child in Node.ChildNodes)
            {
                if (child.Name == Name)
                {
                    return child;
                }
            }
            return null;
        }
        private XmlElement GetNodeByPath(string Name)
        {
            string[] path = Name.Split(new char[] { '\\' });
            XmlElement CurrNode = _xDoc.DocumentElement;
            foreach (string pathElem in path)
            {
                XmlElement ChildNode = FindNodeByName(CurrNode, pathElem);
                if (ChildNode == null)
                {
                    ChildNode = _xDoc.CreateElement(pathElem);
                    CurrNode.AppendChild(ChildNode);

                }
                CurrNode = ChildNode;
            }

            return CurrNode;
        }
        private XmlElement AddNode(XmlElement Node, string Name, string Value)
        {
            XmlElement ChildNode = _xDoc.CreateElement(Name);
            ChildNode.InnerText = Value;
            Node.AppendChild(ChildNode);
            return ChildNode;
        }

        public void SetParamValue(string Name, string Value)
        {
            XmlElement elem = GetNodeByPath(Name);
            elem.InnerText = Value;
            _xDoc.Save(_settingPath);
        }

        public void SetParamValue(string Name, int Value)
        {
            SetParamValue(Name, Convert.ToString(Value));
        }
        public void SetParamValue(string Name, bool Value)
        {
            SetParamValue(Name, Convert.ToString(Value));
        }
        public void SetParamValue(string Name, DateTime Value)
        {
            SetParamValue(Name, Convert.ToString(Value));
        }


        public string GetParamStringValue(string Name)
        {
            XmlElement elem = GetNodeByPath(Name);
            return elem.InnerText;
        }

        public bool GetParamBoolValue(string Name, bool DefaultValue)
        {
            XmlElement elem = GetNodeByPath(Name);
            bool result;
            if (!Boolean.TryParse(elem.InnerText, out result))
                result = DefaultValue;
            return result;
        }
        public int GetParamIntValue(string Name, int Default = -1)
        {
            XmlElement elem = GetNodeByPath(Name);
            int result;
            if (!int.TryParse(elem.InnerText, out result))
                result = Default;
            return result;

        }
        public decimal GetParamDecimalValue(string Name)
        {
            XmlElement elem = GetNodeByPath(Name);
            decimal result;
            if (!decimal.TryParse(elem.InnerText, out result))
                result = -1;
            return result;

        }

        public decimal GetParamDecimalCheckValue(string Name, decimal CheckValue, decimal DefaultValue)
        {
            decimal result = GetParamDecimalValue(Name);
            if (result < CheckValue)
                result = DefaultValue;

            return result;
        }

        public DateTime GetParamDateValue(string Name)
        {
            XmlElement elem = GetNodeByPath(Name);
            DateTime result;
            if (!DateTime.TryParse(elem.InnerText, out result))
                result = DateTime.MinValue;
            return result;
        }

        public List<T> GetParamList<T>(string Name)
            where T : class, new()
        {
            XmlElement elem = GetNodeByPath(Name);

            Type elemType = typeof(T);
            PropertyInfo[] elemTypeProps = elemType.GetProperties();
            
            List<T> list = new List<T>();

            foreach (XmlNode column in elem.ChildNodes)
            {
                T listItem = new T();
                foreach (XmlNode nodeItemProp in column.ChildNodes)
                {
                    int itemPropIdx = Array.FindIndex(elemTypeProps,i => i.Name == nodeItemProp.Name);


                    if (itemPropIdx < 0)
                        continue;
                    elemTypeProps[itemPropIdx].SetValue(listItem, Convert.ChangeType(nodeItemProp.InnerText, elemTypeProps[itemPropIdx].PropertyType));
                }

                list.Add(listItem);


            }
            return list;
        }
        public void SetParamList<T>(string SectionName,string ItemName, List<T> Values)
        {
            XmlElement elem = GetNodeByPath(SectionName);
            Type elemType = typeof(T);
            PropertyInfo[] elemTypeProps = elemType.GetProperties();
            elem.RemoveAll();
            foreach (T item in Values)
            {
                XmlElement ChildNode = _xDoc.CreateElement(ItemName);
                elem.AppendChild(ChildNode);
                foreach (var itemProp in elemTypeProps)
                {
                    AddNode(ChildNode, itemProp.Name, itemProp.GetValue(item).ToString());
                }
            }

            _xDoc.Save(_settingPath);
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

        public void Save()
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
        }

        public void Load()
        {
            _settings.ServerName = GetParamStringValue("Connection\\ServerName");
            _settings.BaseName = GetParamStringValue("Connection\\BaseName");
            _settings.UserName = GetParamStringValue("Connection\\UserName");
            string hash = GetParamStringValue("Connection\\Password");
            _settings.Password = Decode(GetParamStringValue("Connection\\Password"));
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
        }

    }
}
