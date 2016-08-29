using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_buscarUsuario_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Usuarios WHERE CodUsuario ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                txt_codigo.ReadOnly = true;
                lbl_nombre.Visible = true;
                txt_nombre.Visible = true;
                txt_nombre.ReadOnly = true;
                lbl_cargo.Visible = true;
                txt_cargo.Visible = true;
                txt_cargo.ReadOnly = true;
               
                lbl_direccion.Visible = true;
                txt_direccion.Visible = true;
                txt_direccion.ReadOnly = true;
                lbl_telefono.Visible = true;
                txt_telefono.Visible = true;
                txt_telefono.ReadOnly = true;
                lbl_celular.Visible = true;
                txt_celular.Visible = true;
                txt_celular.ReadOnly = true;
                lbl_correo.Visible = true;
                txt_correo.Visible = true;
                txt_correo.ReadOnly = true;
                lbl_estado.Visible = true;
                txt_tempestado.Visible = true;
                txt_tempestado.ReadOnly = true;
                txt_codigo.Text = leer["CodUsuario"].ToString();
                txt_nombre.Text = leer["Nombre"].ToString();
                txt_cargo.Text = leer["Cargo"].ToString();
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                txt_celular.Text = leer["Celular"].ToString();
                txt_correo.Text = leer["Email"].ToString();
                txt_tempestado.Text = leer["Estado"].ToString();
                btn_Eliminar.Enabled = true;
            }
            else
            {
                lbl_resultado.Text = "No se Encontro Usuario";
            }
            conexion2.Close();
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string sql4 = "DELETE FROM Usuarios WHERE CodUsuario='" + this.txt_codigo.Text + "'";

            if (Datos.insertar(sql4))
            {
                lbl_resultado.Text = "Error de conexión, no se pudo Eliminar la información";
            }
            else
            {
                lbl_resultado.Text = "El Usuario ha sido eliminado correctamente";
                Response.Redirect("BuscarUsuario.aspx");
            }
        }
    }
}