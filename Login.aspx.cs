﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComeYA
{
    public partial class Contact : Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string connStr = ConfigurationManager.ConnectionStrings["usuarioConnectionString"].ConnectionString;
        SqlParameter param;

        protected void Page_Load(object sender, EventArgs e)
        {
            divControl.Visible = false;
            con.ConnectionString = connStr;
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            param =cmd.Parameters.Add("@responseMessage",SqlDbType.NVarChar);
            param.Size = 32;
            param.Direction = ParameterDirection.Output;
            cmd.CommandText = "EXEC dbo.uspLogin @pLoginName = N'" + TextBox1.Text + "', @pPassword = N'" + TextBox2.Text + "', @responseMessage = @responseMessage OUTPUT"; /*"select * from usuario where nombUs='" +TextBox1.Text+"' AND passw='"+TextBox2.Text+ "' COLLATE SQL_Latin1_General_CP1_CS_AS AND Passw='"+TextBox2.Text+"'";*/
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label1.Text=cmd.Parameters["@responseMessage"].Value.ToString();

            /*sda.SelectCommand = cmd;
            sda.Fill(ds, "usuario");
            if(cmd.out [0].Rows.Count > 0)
            {
                Label1.Text = "El usuario existe";
            } else
            {
                Label1.Text = "El usuario no existe o la contraseña esta mal";
            }*/

            divControl.Visible = true;
        }
        
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}