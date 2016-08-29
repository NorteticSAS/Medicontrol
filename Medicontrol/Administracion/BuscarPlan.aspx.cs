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
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarPlan_Click(object sender, EventArgs e)
        {
             if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Planes WHERE CodPlan ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                btn_Eliminar.Enabled = true;
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                txt_codigo.ReadOnly = true;
                lbl_descripcion.Visible = true;
                txt_descripcion.Visible = true;
                txt_descripcion.ReadOnly = true;
                txt_codigo.Text = leer["CodPlan"].ToString();
                txt_descripcion.Text = leer["Descripcion"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No se Encontro Plan";
                lbl_codigo.Visible = false;
                txt_codigo.Visible = false;
                lbl_descripcion.Visible = false;
                txt_descripcion.Visible = false;
            }
            conexion2.Close();
        }

        protected void btn_Eliminar_Click1(object sender, EventArgs e)
        {
            string sql4 = "DELETE FROM Planes WHERE CodPlan='" + this.txt_codigo.Text + "'";

            if (Datos.insertar(sql4))
            {
                lbl_resultado.Text = "Error de conexión, no se pudo Eliminar la información";
            }
            else
            {
                lbl_resultado.Text = "El Plan ha sido eliminado correctamente";
                Response.Redirect("BuscarPlan.aspx");
            }
        }
    }
}