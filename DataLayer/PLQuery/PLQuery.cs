using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class PLQuery: BaseDataItem
    {
        int? _qryId;
        string _qryFirst;
        string _qryRepeating;
        string _qryLast;
        string _qryComment;

        public int? qryId
        {
            get => _qryId;
            set
            {
                if (!_qryId.Equals(value))
                {
                    _qryId = value;
                    Id = value;
                    Edit();

                }
            }
        }
        public string qryFirst
        {
            get => _qryFirst;
            set 
            {
                if (_qryFirst == null || !_qryFirst.Equals(value))
                {
                    _qryFirst = value;
                    Edit();

                }
            }
        }

        public string qryRepeating
        {
            get => _qryRepeating;
            set
            {
                if (_qryRepeating == null || !_qryRepeating.Equals(value))
                {
                    _qryRepeating = value;
                    Edit();

                }
            }
        }
        public string qryLast
        {
            get => _qryLast;
            set
            {
                if (!_qryLast.Equals(value))
                {
                    _qryLast = value;
                    Edit();

                }
            }
        }
        public string qryComment
        {
            get => _qryComment;
            set
            {
                if (_qryComment == null || !_qryComment.Equals(value))
                {
                    _qryComment = value;
                    Edit();

                }
            }
        }
    }
}
