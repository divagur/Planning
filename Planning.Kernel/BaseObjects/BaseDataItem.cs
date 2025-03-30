
using System;

namespace Planning.Kernel
{
    [Serializable]
    public class BaseDataItem
    {
        public int? Id {  get; set; }
        protected EditState State { get; set; }

        public BaseDataItem()
        {
            Id = 0;
            State = EditState.New; 
        }

        public void Delete()
        {
            State = EditState.Delete;
        }
        protected void Edit()
        {
            if(Id >0 && State != EditState.Delete)
            {
                State = EditState.Edit;
            }
        }

        public EditState GetState()=> State;

    }
}
