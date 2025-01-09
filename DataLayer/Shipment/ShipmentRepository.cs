﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class ShipmentRepository:BaseRepository<Shipment,ShipmentDataAdapter>
    {
        public ShipmentRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }

        public Shipment GetByLvCode(string LvCode)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where lv_code = @lvCode";
            Shipment item = null;
            var queryResult = dbConnection.Query<Shipment>(sql, new { lvCode = LvCode });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
