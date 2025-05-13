using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGroupLnk:BaseDataItem
    {
        int? _userId;
        int? _groupId;

        public int? UserId
        {
            get => _userId;
            set
            {
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    Edit();
                }
            }
        }
        public int? GroupId
        {
            get => _groupId;
            set
            {
                if (!_groupId.Equals(value))
                {
                    _groupId = value;
                    Edit();
                }
            }
        }
    }
}
