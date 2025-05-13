using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGrpPrvlg:BaseDataItem
    {
        int? _grpId;
        int? _funcId;
        bool? _isView;
        bool? _isAppend;
        bool? _isEdit;
        bool? _isDelete;

        public int? GrpId
        {
            get => _grpId;
            set
            {
                if (!_grpId.Equals(value))
                {
                    _grpId = value;
                    Edit();
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
                    Edit();
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
                    Edit();
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
                    Edit();
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
                    Edit();
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
                    Edit();
                }
            }
        }
    }
}
