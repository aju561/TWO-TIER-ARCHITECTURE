﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace twotier
{
    public partial class register : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {   
            string p = "~/phs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into twot values('" + TextBox1.Text + "',"+ TextBox2.Text +",'" + TextBox3.Text + "','" + p + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int i = obj.Fn_Nonquery(str);
            if(i!=0)
                Label1.Text = "inserted";
            }
        }
    }
