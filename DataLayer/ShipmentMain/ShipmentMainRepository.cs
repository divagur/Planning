using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentMainRepository : BaseRepository<ShipmentMain, ShipmentMainAdapter>
    {
        public ShipmentMainRepository(string ConnectionString)
      : base(ConnectionString)
        {

        }
        public ShipmentMainRepository()
            :base()
        {

        }
        /*
        public ShipmentMainRepository()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = ConnectionParams.ServerName;
            sqlConnectionString.InitialCatalog = ConnectionParams.BaseName;
            sqlConnectionString.UserID = ConnectionParams.UserName;
            sqlConnectionString.Password = ConnectionParams.Pwd;
            InitConnection(sqlConnectionString.ToString());
        }
        */
        public List<ShipmentMain> GetAll(DateTime DateFrom, DateTime? DateTill, string ShpId, string OrdId, int ShpType = -1, string AddCond = null)
        {
            string sql = dataAdapter.GetSelectItemSql();
            object shpType = null;
            if (ShpType >= 0)
                shpType = ShpType;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@From", DateFrom);
            parameters.Add("@Till", DateTill);
            parameters.Add("@In", shpType);
            parameters.Add("@ShpId", ShpId);
            parameters.Add("@OrdID", OrdId);
            parameters.Add("@AddCond", AddCond);
            List<ShipmentMain> shipments = new List<ShipmentMain>();
            //var transaction = dbConnection.BeginTransaction();
            try
            {
                
                var queryResult = dbConnection.Query<ShipmentMain>(sql, parameters, commandType: CommandType.StoredProcedure);
                if (queryResult != null)
                {
                    shipments = queryResult.ToList();


                }
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
            /*
            finally
            {
                transaction.Commit();
            }
            */

            return shipments;
        }
    }
}
