using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Planning
{
    class SettingsHandle
    {


        private XmlDocument _xDoc = new XmlDocument();
        string _settingPath;
        public SettingsHandle(string FileName)
        {
            _settingPath = FileName;
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

        public void SetParamValue(string Name, DateTime Value)
        {
            SetParamValue(Name, Convert.ToString(Value));
        }


        public string GetParamStringValue(string Name)
        {
            XmlElement elem = GetNodeByPath(Name);
            return elem.InnerText;
        }

        public int GetParamIntValue(string Name)
        {
            XmlElement elem = GetNodeByPath(Name);
            int result;
            if (!int.TryParse(elem.InnerText, out result))
                result = -1;
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

    }
}
