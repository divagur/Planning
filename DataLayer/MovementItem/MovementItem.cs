using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class MovementItem: BaseDataItem
    {
        int? _movementId;
        int? _depositorId;
        int? _tklLVID;

        public int? MovementId
        {
            get => _movementId;
            set
            {

                if (_movementId == null || !_movementId.Equals(value))
                {
                    _movementId = value;
                    Edit();

                }
            }
        }
        public int? DepositorId
        {
            get => _depositorId;
            set
            {

                if (_depositorId == null || !_depositorId.Equals(value))
                {
                    _depositorId = value;
                    Edit();

                }
            }
        }
        public int? TklLVID
        {
            get => _tklLVID;
            set
            {

                if (_tklLVID == null || !_tklLVID.Equals(value))
                {
                    _tklLVID = value;
                    Edit();

                }
            }
        }
    }
}
