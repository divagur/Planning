using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    interface IWait
    {
        void WaitBegin();
        void WaitEnd();

    }

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

    public class Common
    {

        public static Settings setting = new Settings();
        public static SettingsHandle settingsHandle;

        public static void WaitBegin(ref object Param)
        {
            Cursor cur = (Cursor)Param;
            cur = Cursors.AppStarting;
        }

        public static void WaitEnd(ref object Param)
        {
            Cursor cur = (Cursor)Param;
            cur = Cursors.Default;
        }


    }
}
