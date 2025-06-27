using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning.Controls
{
    public partial class ButtonEdit : UserControl
    {
        #region PRIVATE

        private Boolean allowMultiline = false;
        private Boolean readOnly = true;
        private ActionType action = ActionType.SelectObject;
        private Form selectForm = null;
        private Object selectedObject = null;
        #endregion

        #region ENUMS

        public enum ActionType
        {
            SelectObject,
            OpenFile,
            SaveFile,
            SelectDirectory,
            OpenCalendar
        }

        #endregion

        #region CONSTRUCTORS

        public ButtonEdit()
        {
            InitializeComponent();
            ComponentLB.MouseDown += (object sender, MouseEventArgs e) => ComponentLB.BackColor = Color.LightSalmon;
            ComponentLB.MouseUp += (object sender, MouseEventArgs e) => ComponentLB.BackColor = Color.Snow;
            ComponentLB.Click += (sender, e) => this.Select();
            ReloadComponentTB();
        }
        #endregion

        #region METHODS

        public void ReloadComponentTB()
        {
            ComponentTB.Multiline = this.AllowMultiline;
            ComponentTB.ReadOnly = this.ReadOnly;
            ComponentTB.BackColor = Color.White; 
            if (this.SelectedObject != null)
            {
                ComponentTB.Text = this.SelectedObject.ToString();
            }
            else
            {
                ComponentTB.Text = String.Empty;
            }
        }


        private new void Select()
        {

            switch (this.Action)
            {
                case ActionType.SelectObject:
                    if (this.SelectForm != null)
                    {
                        this.SelectForm.FormClosing += (sender, e) => {
                            if (this.SelectForm.Tag != null)
                            {
                                this.SelectedObject = this.SelectForm.Tag;
                            }
                        };
                        this.SelectForm.ShowDialog();
                    }
                    break;
            }
        }

        #endregion

        #region PUBLIC

        [Description("Указывает, используется ли Multiline во встроенном TextBox"), Category("ButtonEditProperty")]
        public Boolean AllowMultiline
        {
            get
            {
                return allowMultiline;
            }
            set
            {
                allowMultiline = value;
            }
        }

        [Description("Указывает, разрешено ли редактировать встроенный TextBox"), Category("ButtonEditProperty")]
        public Boolean ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
            }
        }
        [Description("Указывает тип действия компонента"), Category("ButtonEditProperty")]
        public ActionType Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        public Form SelectForm
        {
            get
            {
                return selectForm;
            }
            set
            {
                selectForm = value;
            }
        }

        public Object SelectedObject
        {
            get
            {
                return selectedObject;
            }
            set
            {
                selectedObject = value;
                ReloadComponentTB();
            }
        }
        #endregion

    }
}
