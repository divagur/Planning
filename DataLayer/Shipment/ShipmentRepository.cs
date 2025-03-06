using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;
using System.Data.SqlClient;

namespace Planning.DataLayer
{
    public class ShipmentRepository:BaseRepository<Shipment,ShipmentDataAdapter>
    {
        public ShipmentRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public ShipmentRepository()
            :base()
        {

        }
        /*
        public ShipmentRepository()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = ConnectionParams.ServerName;
            sqlConnectionString.InitialCatalog = ConnectionParams.BaseName;
            sqlConnectionString.UserID = ConnectionParams.UserName;
            sqlConnectionString.Password = ConnectionParams.Pwd;
            InitConnection(sqlConnectionString.ToString());
        }
        */
    }
}
