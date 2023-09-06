using System;
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
    public partial class UserEdit_ : DictEditForm
    {
        User _user;
        public UserEdit_(User user)
        {
            InitializeComponent();
            _user = user;
        }

        protected override bool Save()
        {
            _user.Login = edLogin.Text;
            return true;
        }

        protected override void Populate()
        {
            edLogin.Text = _user.Login;
        }
    }
}
