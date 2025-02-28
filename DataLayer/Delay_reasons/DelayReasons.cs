using System;
using Planning.Kernel;


namespace Planning.DataLayer
{
    public class DelayReasons:BaseDataItem
    {
        string _name = String.Empty;
        public string Name 
            { 
                get =>_name; 
                set 
                    {
                        if (!_name.Equals(value))
                        { 
                            _name = value;
                            Edit();
                            
                        }
                    } 
            }
        
    }
}
