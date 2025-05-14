using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataLayer;
namespace Planning
{
    public class UserGrpPrvlgView
    {
        int? _Id;
        int? _grpId;
        int? _funcId;
        bool? _isView;
        bool? _isAppend;
        bool? _isEdit;
        bool? _isDelete;
        string _funcName;

        public int? Id
        {
            get => _Id;
            set
            {
                if (!_Id.Equals(value))
                {
                    _Id = value;
                }
            }
        }
        public int? GrpId
        {
            get => _grpId;
            set
            {
                if (!_grpId.Equals(value))
                {
                    _grpId = value;                    
                }
            }
        }
        public int? FuncId
        {
            get => _funcId;
            set
            {
                if (!_funcId.Equals(value))
                {
                    _funcId = value;
                }
            }
        }
        public bool? IsView
        {
            get => _isView;
            set
            {
                if (!_isView.Equals(value))
                {
                    _isView = value;
                }
            }
        }
        public bool? IsAppend
        {
            get => _isAppend;
            set
            {
                if (!_isAppend.Equals(value))
                {
                    _isAppend = value;
                }
            }
        }
        public bool? IsEdit
        {
            get => _isEdit;
            set
            {
                if (!_isEdit.Equals(value))
                {
                    _isEdit = value;
                }
            }
        }
        public bool? IsDelete
        {
            get => _isDelete;
            set
            {
                if (!_isDelete.Equals(value))
                {
                    _isDelete = value;
                }
            }
        }
        public string FuncName
        {
            get => _funcName;
            set
            {
                if (_funcName == null || !_funcName.Equals(value))
                {
                    _funcName = value;
                }
            }
        }
    }
}
