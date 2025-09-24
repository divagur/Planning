using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;

namespace PlanningTest
{
    class Program
    {
        //[Table("test")]
        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }


        }

        public class TestRepository
        {
            public static List<Test> GetList(string ConnectionString)
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }
                    var predicate = Predicates.Field<Test>(f => f.Name, Operator.Contains,"('name 1')");
                    /*
                    string sQuery = $"SELECT id as {nameof(Depositor.Id)}, " +
                        $"name as {nameof(Depositor.Name)}, lv_base as {nameof(Depositor.LvBase)}, lv_id as {nameof(Depositor.LvId)} FROM depositors";

                    var result = db.Query<Depositor>($"SELECT id as {nameof(Depositor.Id)}, " +
                        $"name as {nameof(Depositor.Name)}, lv_base as {nameof(Depositor.LvBase)}, lv_id as {nameof(Depositor.LvId)} FROM depositors", predicate).ToList();
                    //db.Close();
                    */
                    return db.GetList<Test>(predicate).ToList(); ;
                    // 
                }
            }
        }
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DZHURAVLEV;Initial Catalog=Planning;User ID=sysadm; Password = sysadm";
            Depositor depositor = new Depositor();
            depositor.Id = 2;
            depositor.Name = "Depositor2";
            depositor.LvBase = "LVision";

            // DepositorRepository depositorRepository = new DepositorRepository(connectionString);
            //var depList = depositorRepository.GetList();
            /*
                         sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = shpType });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = ShpId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = OrdId }); 
             
            using (var connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader("SP_PL_MainQueryP @From = @from, @Till = @till," +
                    "@In = @in, @ShpId = @shpId, @OrdID = @ordID", new { From = DateTime.Now, Till = DateTime.Now,  });

                DataTable table = new DataTable();
                table.Load(reader);

               // FiddleHelper.WriteTable(table);
            }
 */
            List<Test> tests = TestRepository.GetList(connectionString);
            Console.WriteLine("Done");
        }
    }
}
