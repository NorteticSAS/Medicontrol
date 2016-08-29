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
    public partial class Formulario_web117 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string cadena = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
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
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbl_resultado.Text = string.Empty;

                txt_codigo.Text = leer["Codigo"].ToString();
                txt_razonsocial.Text = leer["NombreEntidad"].ToString();
                txt_nit.Text = leer["NIT"].ToString();
                txt_reprelegal.Text = leer["RepresentanteLegal"].ToString();
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                txt_ciudad.Text = leer["Ciudad"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No existe una entidad con ese código";
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_razonsocial.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Razón Social no puede estar vacio";
                return;
            }

            if (txt_nit.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo NIT no puede estar vacio";
                return;
            }

            if (txt_reprelegal.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Representante Legal no puede estar vacio";
                return;
            }

            if (txt_direccion.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Dirección no puede estar vacio";
                return;
            }

            if (txt_telefono.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Teléfono no puede estar vacio";
                return;
            }

            if (txt_ciudad.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Ciudad no puede estar vacio";
                return;
            }

            if (ddl_estado.SelectedItem.ToString() == "Seleccione Un Estado")
            {
                lbl_resultado.Text = "Debe selecionar un estado";
                return;
            }

            string sql = "UPDATE Entidad SET NombreEntidad='" + this.txt_razonsocial.Text + "', NIT='" + this.txt_nit.Text + "', RepresentanteLegal='" + this.txt_reprelegal.Text + "', Direccion='" + this.txt_direccion.Text + "', Telefono='" + this.txt_telefono.Text + "', Ciudad='" + this.txt_ciudad.Text + "', Estado='" + this.ddl_estado.SelectedItem + "' WHERE Codigo='" + this.txt_codigo.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                Response.Redirect("BuscarEntidad.aspx");
            }
        }
    }
}