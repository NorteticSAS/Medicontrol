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
    public partial class Formulario_web114 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string cadena = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarTari_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar un código";
                return;
            }

            string sql = "SELECT * FROM Tarifarios WHERE CodTarifarios='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbl_resultado.Text = string.Empty;
                btn_registrar.Visible = true;
                txt_codigo.Text = leer["CodTarifarios"].ToString();
                txt_descripciontarifario.Text = leer["DescTarifarios"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No existe una tarifario con ese código";
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_descripciontarifario.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Descripción Tarifario no puede estar vacio";
                return;
            }

            string sql = "UPDATE Tarifarios SET DescTarifarios='" + this.txt_descripciontarifario.Text + "' WHERE CodTarifarios='" + this.txt_codigo.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                Response.Redirect("BuscarTarifarios.aspx");
            }
        }
    }
}