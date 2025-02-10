using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalMS.Models
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand Cmd;
        private DataTable dt;
        private string ConStr;
        private SqlDataAdapter sda;


        public Functions()
        {
            ConStr = @"Data Source=OMARATTA\SQLEXPRESS;Initial Catalog=ClinicDataBase;Integrated Security=True;Encrypt=False";
            con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = con;
        }
        public int SetData(string sql)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            Cmd.CommandText = sql;
            cnt = Cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }

        public DataTable GetDatas(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, con);
            sda.Fill(dt);
            return dt;
        }
    }
}