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
    public partial class Formulario_web115 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Código no puede estar vacio";
                return;
            }

            if (VerificarEntidad(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe una entidad con este código";
                return;
            }

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

            string sql = "INSERT INTO Entidad(Codigo, NombreEntidad, NIT, RepresentanteLegal, Direccion, Telefono, Ciudad, Estado) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_razonsocial.Text + "', '" + this.txt_nit.Text + "', '" + this.txt_reprelegal.Text + "', '" + this.txt_direccion.Text + "', '" + this.txt_telefono.Text + "', '" + this.txt_ciudad.Text + "', '" + this.ddl_estado.SelectedItem + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                Response.Redirect("BuscarEntidad.aspx");
            }

        }

        public bool VerificarEntidad(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Entidad WHERE Codigo='" + this.txt_codigo.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }
    }
}