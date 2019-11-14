using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Planning
{
    public partial class frmMain : Form
    {
        DataService dataService = new DataService();
        public frmMain()
        {
            InitializeComponent();
        }

        private void tblShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataService dataService = new DataService();
            tblShipments.AutoGenerateColumns = false;
            tblShipments.DataSource = dataService.GetAll();
        }

        private void miDictDelayReasons_Click(object sender, EventArgs e)
        {
            
            DictSimple dict = new DictSimple();
            dict.TableName = "delay_reasons";
            dict.Title = "Справочник: Причины задержки";

            dict.Columns.Add(new DictColumn {Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int});
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 254 });

            SimpleDict frmDelayReasons = new SimpleDict(dict);
            frmDelayReasons.Show();
        }

        private void miDictOpersType_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();
            dict.TableName = "opers_type";
            dict.Title = "Справочник: Типы операций";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 20 });

            SimpleDict frmOperType = new SimpleDict(dict);
            frmOperType.Show();
        }

        private void miDictGates_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();
            dict.TableName = "gateways";
            dict.Title = "Справочник: Ворота";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "GatewayNum", IsPK = false, IsVisible = true, Title = "Номер ворот", DataField = "gateway_num", Width = 254, DataType = SqlDbType.Int });

            SimpleDict frmOperType = new SimpleDict(dict);
            frmOperType.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Shipment shipment = new Shipment();
            shipmen_edit frmShipmentEdit = new shipmen_edit(shipment);
            frmShipmentEdit.ClearFields();
            if (frmShipmentEdit.ShowDialog()==DialogResult.OK)
            {
                dataService.Add(shipment);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tblShipments.DataSource = dataService.GetAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            Shipment shipment = DataService.Get((int)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            shipmen_edit frmShipmentEdit = new shipmen_edit(shipment);
            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            if (frmShipmentEdit.ShowDialog() == DialogResult.OK)
            {
                dataService.Update(shipment);
            }
        }
    }
}
