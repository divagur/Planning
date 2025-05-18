using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public class WaitHandler : IWait
    {
        private Form _form;

        public WaitHandler(Form form)
        {
            _form = form;
        }

        public void WaitBegin()
        {
            _form.Cursor = Cursors.AppStarting;
        }

        public void WaitEnd()
        {
            _form.Cursor = Cursors.Default;
        }
    }
}
