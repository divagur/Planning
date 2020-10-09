using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public class AdvancedCursors
    {
        //Функция LoadCursorFromFile создает курсор, основанный на данных,
        //содержащихся в файле. Файл определен его именем
        //или идентификатором  системного курсора.
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern IntPtr LoadCursorFromFile(String str);

        public static Cursor Create(string filename)
        {
            IntPtr hCursor = LoadCursorFromFile(filename);
            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                throw new ApplicationException("Ошибка загрузки курсора: " + filename);
            }
        }
    }
}
