using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanningTasks.Common;

namespace PlanningTasks
{
    public class CurrentTaskRepository
    {
        public List<CurrentTask> GetList(DateTime DateFrom, DateTime? DateTill)
        {
            List<CurrentTask> listCurrentTask = new List<CurrentTask>();
            SqlHandle sql = new SqlHandle(Config.ConnectionString);
            sql.SqlStatement = "SP_PL_CurrentTaskQuery";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;

            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Filter", Value = Config.InOutFilter });
            try
            {
                sql.Execute();
            }
            catch (Exception)
            {
                Log.AddErrorEvent(sql.LastError);
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (sql.HasRows())
            {

                foreach (DataRow row in sql.DataSet.Tables[0].Rows)
                {
                    CurrentTask currentTask = new CurrentTask();
                    
                    currentTask.ShpDate = row["s_date"].ToString() != "Null" && row["s_date"].ToString() != "" ? (DateTime?)DateTime.Parse(row["s_date"].ToString().Substring(0, 10)) : null;
                    currentTask.SlotTime = row["slot_time"].ToString() != "Null" && row["slot_time"].ToString() != "" ? (TimeSpan?)TimeSpan.Parse(row["slot_time"].ToString().Substring(0, 8)) : null;
                    currentTask.InOut = row["InOut"].ToString();
                    currentTask.LvOrderId = Int32.Parse(row["lv_order_id"].ToString());
                    currentTask.LvOrderCode = row["lv_order_code"].ToString();
                    currentTask.KlientName = row["cmp_ShortName"].ToString();
                    currentTask.PrcReady = row["Done"].ToString();
                    currentTask.DoneShare = !String.IsNullOrEmpty(row["DoneShare"].ToString()) ? (decimal?)decimal.Parse(row["DoneShare"].ToString()) : null;
                    currentTask.GateName = row["gate_name"].ToString();
                    currentTask.ShippingPlacesNumber = !String.IsNullOrEmpty(row["shipping_places_number"].ToString()) ? (int?)int.Parse(row["shipping_places_number"].ToString()) : null;
                    currentTask.DepositCount = !String.IsNullOrEmpty(row["deposit_count"].ToString()) ? (int?)int.Parse(row["deposit_count"].ToString()) : null;
                    currentTask.AssemblyPicking = !String.IsNullOrEmpty(row["assembly_picking"].ToString()) ? (int?)int.Parse(row["assembly_picking"].ToString()) : null;
                    currentTask.AssemblyPallet= !String.IsNullOrEmpty(row["assembly_pallet"].ToString()) ? (int?)int.Parse(row["assembly_pallet"].ToString()) : null;
                    currentTask.AssemblyMezzanine = !String.IsNullOrEmpty(row["assembly_mezzanine"].ToString()) ? (int?)int.Parse(row["assembly_mezzanine"].ToString()) : null;
                    RuleRowColor rule = GetValidRule(currentTask.ShpDate, currentTask.SlotTime);
                    currentTask.FontColorRGB = Color.Black;
                    currentTask.BackgroundColorRGB = Color.White;
                    if (rule != null )
                    {
                        currentTask.FontColorRGB = rule.FontColorRGB;
                        currentTask.BackgroundColorRGB = rule.BackgroundColorRGB;
                    }
                    currentTask.FontColor = Int32.Parse(row["FontColor"].ToString());
                    listCurrentTask.Add(currentTask);
                }
                
            }

            return listCurrentTask;


        }

        public async Task<List<CurrentTask>> GetListAsync()
        {
            return  await Task<List<CurrentTask>>.Run(() => GetList(DateTime.Now, null));
        }
        private RuleRowColor GetValidRule(DateTime? ShpDate, TimeSpan? TimeSlot)
        {
            RuleRowColor rule = null;

            if (ShpDate == null || TimeSlot == null)
                return null;

            DateTime date1 = (DateTime)ShpDate;
            date1 = date1.Add((TimeSpan)TimeSlot);

            TimeSpan timeSubtract = date1.Subtract(DateTime.Now);
            //int timeSubtractMinutes = Math.Abs((int)timeSubtract.TotalMinutes);
            int timeSubtractMinutes = (int)timeSubtract.TotalMinutes;
            bool isValid;
            foreach (var ruleItem in Config.RulesRowColor)
            {
                switch (ruleItem.Operation)
                {
                    // bt - между
                    case "bt":
                        isValid = timeSubtractMinutes > ruleItem.Param1 && timeSubtractMinutes < ruleItem.Param2;
                        break;
                    //lt <
                    case "lt":
                        isValid = timeSubtractMinutes < ruleItem.Param1;
                        break;
                    //le <=
                    case "le":
                        isValid = timeSubtractMinutes <= ruleItem.Param1;
                        break;
                    //gt >
                    case "gt":
                        isValid = timeSubtractMinutes > ruleItem.Param1;
                        break;
                    //ge >=
                    case "ge":
                        isValid = timeSubtractMinutes >= ruleItem.Param1;
                        break;
                    //eq =
                    case "eq":
                        isValid = timeSubtractMinutes == ruleItem.Param1;
                        break;
                    default:
                        isValid = false;
                        break;
                }

                if (isValid)
                {
                    rule = ruleItem;
                    break;
                }
            }
            return rule;
        }

        private Color GetColorByCondition(DateTime? ShpDate, TimeSpan? TimeSlot)
        {
           if (ShpDate == null || TimeSlot == null)
            return Color.White;

            DateTime date1 = (DateTime)ShpDate;
            date1 = date1.Add((TimeSpan)TimeSlot);

            TimeSpan timeSubtract =  date1.Subtract(DateTime.Now);

            int timeSubtractMinutes = (int)timeSubtract.TotalMinutes;
            int color = 0;
            Color colorRgb = Color.White;
            RuleRowColor findRule;
            foreach (var rule in Config.RulesRowColor)
            {
                switch (rule.Operation)
                {
                    // bt - между
                    case "bt":
                        if (timeSubtractMinutes > rule.Param1 && timeSubtractMinutes < rule.Param2)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    //lt <
                    case "lt":
                        if (timeSubtractMinutes < rule.Param1)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    //le <=
                    case "le":
                        if (timeSubtractMinutes <= rule.Param1)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    //gt >
                    case "gt":
                        if (timeSubtractMinutes > rule.Param1)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    //ge >=
                    case "ge":
                        if (timeSubtractMinutes >= rule.Param1)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    //eq =
                    case "eq":
                        if (timeSubtractMinutes == rule.Param1)
                        {
                            color = rule.Color;
                            colorRgb = rule.BackgroundColorRGB;
                        }
                        break;
                    default:
                        color =  0;
                        break;
                }
            }

           return colorRgb;
        }
    }
}
