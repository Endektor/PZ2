using System;
using System.Data;
using System.Data.SqlClient;
using IWorker;

namespace Worker
{
    public class DBWorker: MarshalByRefObject, IDBWorker
    {
        private DataTable GetDataFromDB(string command)
        {
            var sqlconn = new SqlConnection();
            sqlconn.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=SomeDB;Trusted_Connection=True;";
            sqlconn.Open();

            var adapter = new SqlDataAdapter(command, sqlconn);
            var ds = new DataSet();
            adapter.Fill(ds);
            var dataTable = ds.Tables[0];

            sqlconn.Close();

            return dataTable;
        }

        public DataTable GetAllProducts()
        {
            Console.WriteLine("Обработка нового запроса");
            return GetDataFromDB("select * from Products");
        }
    }
}
