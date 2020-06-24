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
    public partial class SettingsWizard : Form
    {
        public SettingsWizard()
        {
            InitializeComponent();
        }

        private void tvStep_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pgStepView.SelectTab(e.Node.Index);
        }
    }
}
