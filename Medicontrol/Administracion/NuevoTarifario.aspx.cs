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
    public partial class Formulario_web112 : System.Web.UI.Page
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
                lbl_resultado.Text = "El campo Código Tarifario no puede estar vacio";
                return;
            }

            if (VerificarEntidad(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe un tarifario con este código";
                return;
            }

            if (txt_descripciontarifario.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Descripción Tarifario no puede estar vacio";
                return;
            }

            string sql = "INSERT INTO Tarifarios(CodTarifarios, DescTarifarios) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_descripciontarifario.Text + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                Response.Redirect("BuscarTarifarios.aspx");
            }
        }

        public bool VerificarEntidad(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Tarifarios WHERE CodTarifarios='" + this.txt_codigo.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("CodTarifarios", codigo);
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