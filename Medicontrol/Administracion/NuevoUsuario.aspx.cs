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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CheckClave.Checked == false)
            {
                txt_clave.TextMode = TextBoxMode.Password;
            }
        }

        public bool VerificarCodigoUsuario(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE CodUsuario='" + this.txt_codigo.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("CodUsuario", codigo);
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
            string password = HashHelper.MD5(txt_clave.Text);
            if (VerificarCodigoUsuario(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe un Usuario con ese Codigo";
                return;
            }

            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un código de profesional";
                return;
            }
            if (txt_nombre.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Nombre";
                return;
            }
            if (txt_clave.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese una clave";
                return;
            }
            if (password.Length < 8)
            {
                lbl_resultado.Text = "La clave debe ser mayor a ocho caracteres";
                return;
            }
            if (txt_direccion.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese una dirección";
                return;
            }
            if (txt_telefono.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Telefono";
                return;
            }
            if (txt_correo.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Correo Electronico";
            }
            
            if (ddl_estado.SelectedValue == "0")
            {
                lbl_resultado.Text = "Por favor seleccione un Estado";
                return;
            }
            try
            {
                string sql = "INSERT INTO Usuarios(CodUsuario, Nombre, Cargo, Contrasena, Direccion, Telefono, Celular, Email, Estado) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_nombre.Text + "', '" + this.txt_cargo.Text + "', '" + password + "', '" + this.txt_direccion.Text + "', '" + this.txt_telefono.Text + "', '" + this.txt_celular.Text + "', '"+this.txt_correo.Text+"', '"+this.ddl_estado.SelectedItem+"')";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    lbl_resultado.Text = "La Informacion ha sido almacenada correctamente";
                    txt_codigo.Text = string.Empty;
                    txt_nombre.Text = string.Empty;
                    txt_cargo.Text = string.Empty;
                    txt_clave.Text = string.Empty;
                    txt_direccion.Text = string.Empty;
                    txt_telefono.Text = string.Empty;
                    txt_celular.Text = string.Empty;
                    txt_correo.Text = string.Empty;
                    ddl_estado.ClearSelection();
                    btn_Actualizar.Enabled = false;
                    btn_Eliminar.Enabled = false;
                    CheckClave.Checked = false;
                }
            }
            catch
            {
                lbl_resultado.Text = "Ocurrio un Error inesperado, Consulte con el administrador";
            }
        }

        protected void CheckClave_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckClave.Checked == true)
            {
                txt_clave.TextMode = TextBoxMode.SingleLine;
            }
            else
            {                
                txt_clave.TextMode = TextBoxMode.Password;
            }
        }
    }
}