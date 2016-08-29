using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool VerificarCodigoProfesional(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Profesionales WHERE CodProfesional='"+this.txt_codigo.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("CodProfesional", codigo);
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
            if (VerificarCodigoProfesional(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe un Profesional con ese Codigo";
                return;
            }
            
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un código de profesional";
                return;
            }
            if (txt_primernombre.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Nombre";
                return;
            }
            if (txt_primerapellido.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Apellido";
                return;
            }
            if (ddl_tipopersona.SelectedValue == "0")
            {
                lbl_resultado.Text = "Por favor seleccione un tipo de persona";
                return;
            }
            //if (ddl_estado.SelectedValue == "0")
            //{
            //    lbl_resultado.Text = "Por favor seleccione un Estado";
            //    return;
            //}
            try
            {
                string nombre = txt_primernombre.Text + " " + txt_primerapellido.Text;
                string sql = "INSERT INTO Profesionales(CodProfesional, NomProfesional, NomProfesional2, ApeProfesional, ApeProfesional2, TipoPersonal, Estado, NombreCompleto) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_primernombre.Text + "', '" + this.txt_segundonombre.Text + "', '" + this.txt_primerapellido.Text + "', '" + this.txt_segundoapellido.Text + "', '" + this.ddl_tipopersona.SelectedValue + "', '" + this.ddl_estado.SelectedValue + "', '"+nombre+"')";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    lbl_resultado.Text = "La Informacion ha sido almacenada correctamente";
                    txt_codigo.Text = string.Empty;
                    txt_primerapellido.Text = string.Empty;
                    txt_primernombre.Text = string.Empty;
                    txt_segundoapellido.Text = string.Empty;
                    txt_segundonombre.Text = string.Empty;
                    ddl_estado.ClearSelection();
                    ddl_tipopersona.ClearSelection();
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