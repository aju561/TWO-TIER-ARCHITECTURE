using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace twotier
{
    public class ConnectionClass
    {
        SqlCommand cmd;
        SqlConnection con;

        
        public ConnectionClass()
        {
            con = new SqlConnection(@"server=PHONEMANIAC\SQLEXPRESS;database=ASPDB;Integrated security=true");
        }
        public int Fn_Nonquery(string sqlquery)
        { 
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();//insert,update,delete
            con.Close();
            return i;
         
        }

        public string Fn_Scalar(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();// 
            con.Close();
            return s;
        }

        public SqlDataReader Fn_DataReader(string sqlquery)//age,name
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); 
            return dr;
        }

        public DataSet Fn_DataSet(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
           
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            
            da.Fill(ds);////name,age,address,photo,us,ps 
            return ds;
        }


        public DataTable Fn_DataTable(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}