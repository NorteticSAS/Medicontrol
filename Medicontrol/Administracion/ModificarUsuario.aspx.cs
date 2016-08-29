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
    public partial class Formulario_web15 : System.Web.UI.Page
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

        protected void btn_buscarUsuario_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Usuarios WHERE CodUsuario ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                txt_codigo.ReadOnly = true;
                lbl_nombre.Visible = true;
                txt_nombre.Visible = true;
                lbl_cargo.Visible = true;
                txt_cargo.Visible = true;
                lbl_clave.Visible = true;
                txt_clave.Visible = true;
                lbl_direccion.Visible = true;
                txt_direccion.Visible = true;
                lbl_telefono.Visible = true;
                txt_telefono.Visible = true;
                lbl_celular.Visible = true;
                txt_celular.Visible = true;
                lbl_correo.Visible = true;
                txt_correo.Visible = true;
                lbl_estado.Visible = true;
                ddl_estado.Visible = true;
                ddl_estado.Enabled = true;
                txt_codigo.Text = leer["CodUsuario"].ToString();
                txt_nombre.Text = leer["Nombre"].ToString();
                txt_cargo.Text = leer["Cargo"].ToString();
                txt_clave.Text = leer["Contrasena"].ToString();
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                txt_celular.Text = leer["Celular"].ToString();
                txt_correo.Text = leer["Email"].ToString();
                btn_Eliminar.Enabled = true;
                btn_registrar.Visible = true;

            }
            else
            {
                lbl_resultado.Text = "No se Encontro Usuario";
            }
            conexion2.Close();
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            string password = HashHelper.MD5(txt_clave.Text);
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
                string sql = "UPDATE Usuarios SET Nombre='" + this.txt_nombre.Text + "', Cargo='" + this.txt_cargo.Text + "', Contrasena='" + password + "', Direccion='" + this.txt_direccion.Text + "', Telefono='" + this.txt_telefono.Text + "', Celular='"+this.txt_celular.Text+"', Email='"+this.txt_correo.Text+"', Estado='" + this.ddl_estado.SelectedItem + "' WHERE CodUsuario='" + this.txt_codigo.Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    lbl_resultado.Text = "La Informacion ha sido Modificada correctamente";
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