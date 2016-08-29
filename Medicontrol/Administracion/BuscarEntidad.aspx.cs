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
    public partial class Formulario_web116 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        public string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarEnt_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar un código para realizar la búsqueda";
                return;
            }

            string sql = "SELECT * FROM Entidad WHERE Codigo='" + this.txt_buscar.Text + "'";
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
                lbl_razonsocial.Visible = true;
                txt_razonsocial.Visible = true;
                lbl_nit.Visible = true;
                txt_nit.Visible = true;
                lbl_reprelegal.Visible = true;
                txt_reprelegal.Visible = true;
                lbl_direccion.Visible = true;
                txt_direccion.Visible = true;
                lbl_telefono.Visible = true;
                txt_telefono.Visible = true;
                lbl_ciudad.Visible = true;
                txt_ciudad.Visible = true;
                lbl_estado.Visible = true;
                txt_tempEstado.Visible = true;

                txt_codigo.Text = leer["Codigo"].ToString();
                txt_razonsocial.Text = leer["NombreEntidad"].ToString();
                txt_nit.Text = leer["NIT"].ToString();
                txt_reprelegal.Text = leer["RepresentanteLegal"].ToString();
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                txt_ciudad.Text = leer["Ciudad"].ToString();
                txt_tempEstado.Text = leer["Estado"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No existe una entidad con ese código";
            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string sql4 = "DELETE FROM Entidad WHERE Codigo='" + this.txt_codigo.Text + "'";

            if (Datos.insertar(sql4))
            {
                lbl_resultado.Text = "Error de conexión, no se pudo Eliminar la información";
            }
            else
            {
                lbl_resultado.Text = "La Entidad ha sido eliminada exitosamente";
                Response.Redirect("BuscarEntidad.aspx");
            }
        }
    }
}