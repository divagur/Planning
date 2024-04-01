using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks
{
    [Serializable]
    public class CurrentTaskColumn
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }


        public CurrentTaskColumn()
        {

        }
        public CurrentTaskColumn(string id, string title, bool isVisible, int width)
        {
            Id = id;
            Title = title;
            Visible = isVisible;
            Width = width;
        }

    }
}
