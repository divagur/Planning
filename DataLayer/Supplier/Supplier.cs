using System;
using Planning.Kernel;


namespace Planning.DataLayer
{
    public class Supplier: BaseDataItem
    {
        string _name = String.Empty;
        bool? _isActive = false;
        public string Name 
            { 
                get =>_name; 
                set 
                    {
                        if (_name == null || !_name.Equals(value))
                        { 
                            _name = value;
                            Edit();
                            
                        }
                    } 
            }
        public bool? IsActive
        {
            get => _isActive;
            set
            {
                if (!_isActive.Equals(value))
                {
                    _isActive = value;
                    Edit();

                }
            }
        }
    }
}
