using Planning.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Planning
{
    public partial class TransportCompanyKpiDelayFormEdit : DictEditForm
    {
        TransportCompanyKpiDelay _transportCompanyKpiDelay;
        public TransportCompanyKpiDelayFormEdit(TransportCompanyKpiDelay transportCompanyKpiDelay)
        {
            InitializeComponent();
            _transportCompanyKpiDelay = transportCompanyKpiDelay;
        }

        protected override void Populate()
        {
            txtTimeDelayMask.Text =  MinutesToTimeSpan((int)_transportCompanyKpiDelay.MinutesDelay);
            txtKPI.Text = _transportCompanyKpiDelay.Kpi.ToString();
           
        }

        protected override bool Save()
        {

            _transportCompanyKpiDelay.MinutesDelay = TimeSpanToMinutes(txtTimeDelayMask.Text);
            _transportCompanyKpiDelay.Kpi = (int)txtKPI.Value;

            if (!ValidateValues())
            {
                return false;
            }

            Common.ShowInformation($"Показатель {txtKPI.Value.ToString()}% для опоздания {txtTimeDelayMask.Text} успешно сохранён","Сохранение показателя");
            return true;
        }

        private string MinutesToTimeSpan(int minutes)
        {
            TimeSpan spWorkMin = TimeSpan.FromMinutes(minutes);
            return string.Format("{0}:{1}", (int)spWorkMin.TotalHours == 0 ? "00" : spWorkMin.TotalHours.ToString(), spWorkMin.Minutes == 0?"00":spWorkMin.Minutes.ToString());
        }

        private int TimeSpanToMinutes(string timeSpan)
        {
            if (!Regex.IsMatch(timeSpan, "^\\d{1,4}:\\d{1,2}"))
            {
                return 0;
            }

            string[] splitTime = timeSpan.Split(':');

            return int.Parse(splitTime[0]) * 60 + int.Parse(splitTime[1]);
        }

        private bool ValidateValues()
        {
            if (txtTimeDelayMask.Text == String.Empty || txtTimeDelayMask.Text == "  :")
            {
                Common.ShowError("Показатель [Время опоздания] не может быть пустым", "Ошибка сохранения");
                return false;
            }
            
            if (!Regex.IsMatch(txtTimeDelayMask.Text, "^\\d{1,4}:\\d{1,2}"))
            {
                Common.ShowError("Некорректный формат времени в показателе [Время опоздания]", "Ошибка сохранения");
                return false;
            }

            if (txtKPI.Text == String.Empty)
            {
                Common.ShowError("Показатель [KPI] не может быть пустым", "Ошибка сохранения");
                return false;
            }

            if (_transportCompanyKpiDelay.GetState() == Kernel.EditState.New) 
            {
                TransportCompanyKpiDelayRepository transportCompanyKpiDelayRepository = new TransportCompanyKpiDelayRepository();

                TransportCompanyKpiDelay transportCompanyKpi = transportCompanyKpiDelayRepository.GetByMinutesDelay(_transportCompanyKpiDelay.MinutesDelay);
                if (transportCompanyKpi != null)
                {
                    Common.ShowError($"Критерий со значениями Время опоздания = {_transportCompanyKpiDelay.MinutesDelay.ToString()} уже существует", "Ошибка сохранения"); 
                    return false;
                }

                transportCompanyKpi = transportCompanyKpiDelayRepository.GetByKpi(_transportCompanyKpiDelay.Kpi);
                if (transportCompanyKpi != null)
                {
                    Common.ShowError($"Критерий со значением Показатель KPI  = {_transportCompanyKpiDelay.Kpi.ToString()} уже существует", "Ошибка сохранения");
                    return false;
                }   
            }


            return true;
        }
    }
}
