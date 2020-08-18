﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class FormLogin : Form
    {
        Settings _setting;
        public FormLogin(Settings setting)
        {
            InitializeComponent();
            _setting = setting;
        }

        private void OkClick()
        {
            _setting.UserName = edUserName.Text;
            _setting.Password = edPassword.Text;
            if (DataService.TryDBConnect(DataService.setting.ServerName, DataService.setting.BaseName, DataService.setting.Password, DataService.setting.Password, false))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OkClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            edUserName.Text = _setting.UserName;
        }

        private void edUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                OkClick();
            }
        }
    }
}