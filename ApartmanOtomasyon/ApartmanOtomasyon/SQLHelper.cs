using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanOtomasyon
{
    class SQLHelper
    {
        private string ConnectionString { get; set; }
        private SqlConnection Connection { get; set; }

        public SQLHelper()
        {
            ConnectionString = @"Server=Wissen\SQLEXPRESS;
                                Database=Apartman;
                                User ID = Section1;
                                Trusted_Connection=true;";
            Connection = new SqlConnection(ConnectionString);
        }

      

        public void ExecuteProc(string procName, params SqlParameter[] ps)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddRange(ps);
            command.Connection = Connection;
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
        }

        public DataTable GetTable(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
