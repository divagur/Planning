using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataLayer;
namespace Planning
{
    public static class UserGrpPrvlgViewRepository
    {

        public static List<UserGrpPrvlgView> GetAll(int? GrpId)
        {
            List<UserGrpPrvlgView> result = new List<UserGrpPrvlgView>();
            
            FunctionRepository functionRepository = new FunctionRepository();
            List<DataLayer.Function>  functions = functionRepository.GetAll();

            UserGrpPrvlgRepository userGrpPrvlgRepository = new UserGrpPrvlgRepository();

            List<DataLayer.UserGrpPrvlg> userGrpPrvlgs = userGrpPrvlgRepository.GetByGrpId(GrpId);

            foreach (var item in functions)
            {
                UserGrpPrvlgView userGrpPrvlgView = new UserGrpPrvlgView();
                userGrpPrvlgView.FuncName = item.Name;
                userGrpPrvlgView.FuncId = item.Id;
                userGrpPrvlgView.GrpId = GrpId;

                DataLayer.UserGrpPrvlg userGrpPrvlg = userGrpPrvlgs.FirstOrDefault(g => g.FuncId == item.Id);
                if (userGrpPrvlg != null)
                {
                    userGrpPrvlgView.Id = userGrpPrvlg.Id;
                    userGrpPrvlgView.IsAppend = userGrpPrvlg.IsAppend;
                    userGrpPrvlgView.IsDelete = userGrpPrvlg.IsDelete;
                    userGrpPrvlgView.IsEdit = userGrpPrvlg.IsEdit;
                    userGrpPrvlgView.IsView = userGrpPrvlg.IsView;
                }


                result.Add(userGrpPrvlgView);
            }
            return result;
        }

        public static bool Save(int? GrpId, List<UserGrpPrvlgView> userGrpPrvlgViews)
        {
            UserGrpPrvlgRepository userGrpPrvlgRepository = new UserGrpPrvlgRepository();
            List<DataLayer.UserGrpPrvlg> userGrpPrvlgs = userGrpPrvlgRepository.GetByGrpId(GrpId);

            foreach (var item in userGrpPrvlgViews)
            {
                DataLayer.UserGrpPrvlg userGrpPrvlg = userGrpPrvlgs.FirstOrDefault(g => g.GrpId == item.GrpId && g.FuncId == item.FuncId);
                if (userGrpPrvlg == null)
                {
                    userGrpPrvlg = new DataLayer.UserGrpPrvlg();
                    userGrpPrvlg.FuncId = item.FuncId;
                    userGrpPrvlg.GrpId = item.GrpId;
                }

                userGrpPrvlg.IsAppend = item.IsAppend;
                userGrpPrvlg.IsDelete = item.IsDelete;
                userGrpPrvlg.IsEdit = item.IsEdit;
                userGrpPrvlg.IsView = item.IsView;

               if ( !userGrpPrvlgRepository.Save(userGrpPrvlg))
                {
                    throw new Exception(userGrpPrvlgRepository.LastError);
                }
            }

            return true;
        }
    }
}
