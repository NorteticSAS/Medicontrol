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
    public partial class Formulario_web113 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        public string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarTari_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar un código de tarifario";
                return;
            }

            string sql = "SELECT * FROM Tarifarios WHERE CodTarifarios='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                btn_Eliminar.Enabled = true;
                lbl_resultado.Text = string.Empty;
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                lbl_descripciontarifario.Visible = true;
                txt_descripciontarifario.Visible = true;

                txt_codigo.Text = leer["CodTarifarios"].ToString();
                txt_descripciontarifario.Text = leer["DescTarifarios"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No existe un tarifario con ese código";
            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string sql4 = "DELETE FROM Tarifarios WHERE CodTarifarios='" + this.txt_codigo.Text + "'";

            if (Datos.insertar(sql4))
            {
                lbl_resultado.Text = "Error de conexión, no se pudo Eliminar la información";
            }
            else
            {
                lbl_resultado.Text = "El Tarifario ha sido eliminado exitosamente";
                Response.Redirect("BuscarTarifarios.aspx");
            }
        }
    }
}