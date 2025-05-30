using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Data.Common;

namespace Planning.DataLayer
{
    public class ShipmentLogViewRepository : BaseRepository<ShipmentLogView, ShipmentLogViewDataAdapter>
    {
        public ShipmentLogViewRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public ShipmentLogViewRepository()
            :base()
        {

        }
        public Shipment GetByLvOrderCode(string LvOrderCode)
        {
            ShipmentDataAdapter shipmentDataAdapter = new ShipmentDataAdapter();
            string sql = dataAdapter.GetSelectItemSql() + $@"join shipment_orders so on so.shipment_id = {shipmentDataAdapter.Table}.id
                    where so.lv_order_code = @lvOrderCode";
            Shipment item = null;
            var queryResult = dbConnection.Query<Shipment>(sql, new { lvOrderCode = LvOrderCode});

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
        public List<ShipmentLogView> GetByParams(int? ShpID, DateTime? From, DateTime? Till,int? ShpType, string UserId)
        {
            List<ShipmentLogView> result = new List<ShipmentLogView>();
            string sql = dataAdapter.GetSelectItemSql();
            object shpType = null;
            if (ShpType >= 0)
                shpType = ShpType;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ShpId", ShpID);
            parameters.Add("@From", From);
            parameters.Add("@Till", Till);
            parameters.Add("@In", shpType);            
            parameters.Add("@UserId", UserId);
            
            //var transaction = dbConnection.BeginTransaction();
            var queryResult = dbConnection.Query<ShipmentLogView>(sql, parameters, commandType: CommandType.StoredProcedure);
            //transaction.Commit();
            if (queryResult != null)
            {
                result = queryResult.ToList();

            }
            return result;
        }
       
    }
}
