using Helper;
using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using System.Data;

namespace Medicontrol
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                Response.Redirect("Index.aspx");
            }
           
        }

        protected void inciar_Click(object sender, EventArgs e)
        {
            string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
            SqlConnection conexion = new SqlConnection(ruta);
            password.Text = HashHelper.MD5(password.Text);//PASAMOS LA CONTRASEÑA DIGITADA A MD5
            SqlDataAdapter adaptador = new SqlDataAdapter("select * from Usuarios where (CodUsuario='" + this.username.Text + "' and Contrasena='" + password.Text + "' and Estado='Activo')", conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            if (dt.Rows.Count.ToString() == "1")
            {
                HttpCookie cookie = new HttpCookie("Login");
                cookie["name"] = dt.Rows[0]["Nombre"].ToString();
                cookie["ID"] = dt.Rows[0]["CodUsuario"].ToString();
                cookie["tipousuario"] = dt.Rows[0]["Cargo"].ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

                Response.Redirect("Index.aspx");
            }
            else
            {
                lbl_resultado.Visible = true;
                lbl_resultado.Text = "El usuario ingresado no Existe";
            }
        }

       
    }
}