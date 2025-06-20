using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class User: BaseDataItem
    {
        string _login;
        string _password;
        string _firstName;
        string _secondName;
        string _lastName;
        bool? _isReg;
        int? _regType;
        string _domainUserName;
        bool? _isWinAuth;
        bool? _isSystemUser;
        public string Login 
        { get => _login; 
          set
            {
                if (_login == null || !_login.Equals(value))
                {
                    _login = value;
                    Edit();

                }
            }
        }
        public string Password 
        { 
            get => _password; 
            set
            {
                if (_password == null || !_password.Equals(value))
                {
                    _password = value;
                    Edit();

                }
            }   
        }
        public string FirstName 
        { 
            get=>_firstName; 
            set
            {
                if (_firstName == null || !_firstName.Equals(value))
                {
                    _firstName = value;
                    Edit();

                }
            } 
        }
        public string SecondName
        {
            get => _secondName;
            set
            {
                if (_secondName == null || !_secondName.Equals(value))
                {
                    _secondName = value;
                    Edit();

                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == null || !_lastName.Equals(value))
                {
                    _lastName = value;
                    Edit();

                }
            }
        }
        public bool? IsReg 
        { 
            get =>_isReg; 
            set
            {
                if (!_isReg.Equals(value))
                {
                    _isReg = value;
                    Edit();
                }
            }
        }
        public string DomainUserName
        {
            get => _domainUserName;
            set
            {
                if (_domainUserName == null || !_domainUserName.Equals(value))
                {
                    _domainUserName = value;
                    Edit();

                }
            }
        }
        public bool? IsWinAuth
        {
            get => _isWinAuth;
            set
            {
                if (!_isWinAuth.Equals(value))
                {
                    _isWinAuth = value;
                    Edit();
                }
            }
        }
        public bool? IsSystemUser
        {
            get => _isSystemUser;
            set
            {
                if (!_isSystemUser.Equals(value))
                {
                    _isSystemUser = value;
                    Edit();
                }
            }
        }
        public int? RegType 
        { 
            get => _regType; 
            set
            {
                if (!_regType.Equals(value))
                {
                    _regType = value;
                    Edit();
                }
            }
        }
    }
}
