﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace twotier
{
    public partial class UserProfile : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select Name,Age,Address,Photo from twot where Id=" + Session["userid"] + "";
            SqlDataReader dr = obj.Fn_DataReader(sel);////dr[name,age,address,photo,us,ps]
            
            while (dr.Read())  
            {
                Label1.Text = dr["Name"].ToString();
                Label2.Text = dr["Age"].ToString();
                Label3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["photo"].ToString();
            }
            
            DataSet ds = obj.Fn_DataSet(sel);/// dot - ds-tab  
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = obj.Fn_DataTable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();







        }
    }
}