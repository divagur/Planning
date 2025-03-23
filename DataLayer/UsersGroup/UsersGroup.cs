using System;
using Planning.Kernel;


namespace Planning.DataLayer
{
    public class UsersGroup : BaseDataItem
    {
        string _name = String.Empty;
        byte? _access;
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
        public byte? Access
        {
            get => _access;
            set
            {
                if (!_access.Equals(value))
                {
                    _access = value;
                    Edit();

                }
            }
        }

    }
}
