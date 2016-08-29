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
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarPlan_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Planes WHERE CodPlan ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                btn_registrar.Visible = true;
                btn_Eliminar.Enabled = true;
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                txt_codigo.ReadOnly = true;
                lbl_descripcion.Visible = true;
                txt_descripcion.Visible = true;
                txt_codigo.Text = leer["CodPlan"].ToString();
                txt_descripcion.Text = leer["Descripcion"].ToString();
            }
            else
            {
                lbl_resultado.Text = "No se Encontro Plan";
                lbl_codigo.Visible = false;
                txt_codigo.Visible = false;
                lbl_descripcion.Visible = false;
                txt_descripcion.Visible = false;
            }
            conexion2.Close();
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Nombre";
                return;
            }
            try
            {
                string sql = "UPDATE Planes SET Descripcion='"+this.txt_descripcion.Text+"' WHERE CodPlan='"+this.txt_codigo.Text+"'";
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