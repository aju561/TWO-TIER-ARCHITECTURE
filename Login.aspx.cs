using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace twotier
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string uid = "";
            string sel = "select count(Id) from twot where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string cid = obj.Fn_Scalar(sel);


            if (cid == "1")
            {

                string selid = "select Id from twot where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlDataReader dr = obj.Fn_DataReader(selid);
                while(dr.Read())
                {
                    uid = dr["Id"].ToString(); 
                  
                }
                
                Session["userid"] = uid;
                Response.Redirect("UserProfile.aspx");
                
               
             

            }
            else
            {
                Label1.Text = "Invalid Username And Password";
            }
        }
    }
}