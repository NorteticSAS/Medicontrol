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
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btn_buscarPro_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Profesionales WHERE CodProfesional ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
               
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                lbl_primernombre.Visible = true;
                txt_primernombre.Visible = true;
                lbl_segundonombre.Visible = true;
                txt_segundonombre.Visible = true;
                lbl_primerapellido.Visible = true;
                txt_primerapellido.Visible = true;
                lbl_segundoapellido.Visible = true;
                txt_segundoapellido.Visible = true;
                lbl_tipopersona.Visible = true;
                ddl_tipopersona.Visible = true;
                ddl_tipopersona.Enabled = true;
                lbl_estado.Visible = true;
                ddl_estado.Visible = true;
                ddl_estado.Enabled = true;
                btn_modificar.Visible = true;
                btn_modificar.Enabled = true;
                txt_codigo.Text = leer["CodProfesional"].ToString();
                txt_primernombre.Text = leer["NomProfesional"].ToString();
                txt_segundonombre.Text = leer["NomProfesional2"].ToString();
                txt_primerapellido.Text = leer["ApeProfesional"].ToString();
                txt_segundoapellido.Text = leer["ApeProfesional2"].ToString();
                ddl_tipopersona.ClearSelection();
                ddl_tipopersona.Items.FindByValue(leer["TipoPersonal"].ToString()).Selected=true;
                ddl_estado.ClearSelection();
                ddl_estado.Items.FindByValue(leer["Estado"].ToString()).Selected=true;
                lbl_resultado.Text = string.Empty;

            }
            else
            {
                lbl_resultado.Text = "No se Encontro Profesional";
                lbl_codigo.Visible = false;
                txt_codigo.Visible = false;
                lbl_primernombre.Visible = false;
                txt_primernombre.Visible = false;
                lbl_segundonombre.Visible = false;
                txt_segundonombre.Visible = false;
                lbl_primerapellido.Visible = false;
                txt_primerapellido.Visible = false;
                lbl_segundoapellido.Visible = false;
                txt_segundoapellido.Visible = false;
                lbl_tipopersona.Visible = false;
                ddl_tipopersona.Visible = false;
                lbl_estado.Visible = false;
                ddl_estado.Visible = false;
                ddl_tipopersona.ClearSelection();
                ddl_estado.ClearSelection();
            }
            conexion2.Close();
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
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
                string sql = "UPDATE Profesionales SET NomProfesional='" + this.txt_primernombre.Text + "', NomProfesional2='" + this.txt_segundonombre.Text + "', ApeProfesional='" + this.txt_primerapellido.Text + "', ApeProfesional2='" + this.txt_segundoapellido.Text + "', TipoPersonal='" + this.ddl_tipopersona.SelectedValue + "', Estado='" + this.ddl_estado.SelectedValue + "' WHERE CodProfesional='" + this.txt_codigo.Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    Response.Redirect("BuscarProfesional.aspx");
                }
            }
            catch
            {
                lbl_resultado.Text = "Ocurrio un Error inesperado, Consulte con el administrador";
            }
        }
    }
}