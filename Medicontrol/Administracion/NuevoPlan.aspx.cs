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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool VerificarPlan(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Planes WHERE CodPlan='" + this.txt_codigo.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("CodPlan", codigo);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (VerificarPlan(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe un Plan con ese Codigo";
                return;
            }

            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un código de plan";
                return;
            }
            if (txt_descripcion.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Nombre de Plan";
                return;
            }
            try
            {
                string sql = "INSERT INTO Planes(CodPlan, Descripcion) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_descripcion.Text + "')";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    lbl_resultado.Text = "La Informacion ha sido almacenada correctamente";
                    txt_codigo.Text = string.Empty;
                    txt_descripcion.Text = string.Empty;
                    btn_Actualizar.Enabled = false;
                    btn_Eliminar.Enabled = false;
                }
            }
            catch
            {
                lbl_resultado.Text = "Ocurrio un Error inesperado, Consulte con el administrador";
            }
        }
    }
}