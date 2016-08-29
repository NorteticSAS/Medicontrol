using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;

        protected void ValidateDate(object sender, ServerValidateEventArgs e)
        {
            if (Regex.IsMatch(txt_fechanaci.Text, "(((0|1)[1-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
            {
                DateTime dt;
                e.IsValid = DateTime.TryParseExact(e.Value, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                if (e.IsValid)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valid Date.');", true);
                }
            }
            else
            {
                e.IsValid = false;
                lbl_resultado.Text = "La fecha es invalida verifique";
                return;
            }
        }

        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            
            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios > 0)
            {
                str = anios.ToString();
                umEdad.Text = "años";
            }
            if (anios <= 0 && meses > 0)
            {
                str = meses.ToString();
                umEdad.Text = "meses";
            }
            if (anios <= 0 && meses <= 0)
            {
                str = dias.ToString();
                umEdad.Text = "dias";
            }
            //if (anios < 0)
            //{
            //    return "Fecha Invalida";
            //}
            //if (anios > 0)
            //    str = str + anios.ToString() + " años ";
            //if (meses > 0)
            //    str = str + meses.ToString() + " meses ";
            //if (dias > 0)
            //    str = str + dias.ToString() + " dias ";

            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            lbl_resultado.Text = string.Empty;
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento");
                this.ddl_tipodoc.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc.DataTextField = "NomDocumento";
                this.ddl_tipodoc.DataValueField = "CodDocumento";
                this.ddl_tipodoc.DataBind();
                ddl_tipodoc.Items.Insert(0, new ListItem("Seleccione Tipo de Documento"));

                Datos.consultar("SELECT * FROM TipoUsuario ORDER BY Tipo", "TipoUsuario");
                this.ddl_tipousuario.DataSource = Datos.ds.Tables["TipoUsuario"];
                this.ddl_tipousuario.DataTextField = "Tipo";
                this.ddl_tipousuario.DataValueField = "Id";
                this.ddl_tipousuario.DataBind();
                ddl_tipousuario.Items.Insert(0, new ListItem("Seleccione Tipo de Usuario"));

                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento.DataTextField = "Departamento";
                this.ddl_departamento.DataValueField = "CodDpto";
                this.ddl_departamento.DataBind();
                ddl_departamento.Items.Insert(0, new ListItem("Seleccione Departamento"));

                Datos.consultar("SELECT * FROM Estratos ORDER BY Descripcion", "Estratos");
                this.ddl_estrato.DataSource = Datos.ds.Tables["Estratos"];
                this.ddl_estrato.DataTextField = "Descripcion";
                this.ddl_estrato.DataValueField = "Id";
                this.ddl_estrato.DataBind();
                ddl_estrato.Items.Insert(0, new ListItem("Seleccione Estrato"));

                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidad.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidad.DataTextField = "NombreEntidad";
                this.ddl_entidad.DataValueField = "Codigo";
                this.ddl_entidad.DataBind();
                ddl_entidad.Items.Insert(0, new ListItem("Seleccione Entidad"));
            }
        }

        protected void ddl_tipousuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datos.consultar("SELECT * FROM TipoAfiliado ORDER BY Descripcion", "TipoAfiliado");
            this.ddl_tipoafiliado.DataSource = Datos.ds.Tables["TipoAfiliado"];
            this.ddl_tipoafiliado.DataTextField = "Descripcion";
            this.ddl_tipoafiliado.DataValueField = "Id";
            this.ddl_tipoafiliado.DataBind();
            ddl_tipoafiliado.Items.Insert(0, new ListItem("","0"));

            if (ddl_tipousuario.SelectedItem.ToString() == "Contributivo")
            {
                ddl_tipoafiliado.Enabled = true;
            }
            else
            {
                ddl_tipoafiliado.ClearSelection();
                ddl_tipoafiliado.Enabled = false;
            }
        }

        protected void ddl_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio.DataTextField = "Municipio";
            this.ddl_municipio.DataValueField = "CodMncpio";
            this.ddl_municipio.DataBind();
            ddl_municipio.Items.Insert(0, new ListItem("Seleccione Municipio"));
        }

        protected void ddl_entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='" + this.ddl_entidad.SelectedValue + "' ORDER BY Descripcion", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));

            

        }

        protected void gridPacienteContrato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPacienteContrato, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridPacienteContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridPacienteContrato.Rows)
            {
                if (row.RowIndex == gridPacienteContrato.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            if(txt_documento.Text==string.Empty)
            {
                lbl_mensajecontrato.Text = "Debe digitar un documento";
            }
            if (ddl_entidad.SelectedItem.ToString() == "Seleccione Entidad")
            {
                lbl_mensajecontrato.Text = "Seleccione la entidad";
                return;
            }

            if (ddl_contrato.SelectedItem.ToString() == "Seleccione Contrato")
            {
                lbl_mensajecontrato.Text = "Seleccione el contrato";
                return;
            }
            String sql = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + this.ddl_entidad.SelectedValue + "','" + this.ddl_entidad.SelectedItem + "', '" + this.ddl_contrato.SelectedValue + "', '" + this.ddl_contrato.SelectedItem + "', '" + this.txt_documento.Text + "')";
            if (Datos.insertar(sql))
            {
                lbl_mensajecontrato.Text = "Error al asignar contrato al paciente, Verifique";
            }
            else
            {
                gridPacienteContrato.Visible = true;
                fillgrilla();
                ddl_entidad.ClearSelection();
                ddl_contrato.ClearSelection();
            }
        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

        }

        protected void btn_eliminarcontrato_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM PacientesEntidadContrato WHERE CodEntidad='" + this.gridPacienteContrato.SelectedRow.Cells[1].Text + "' AND CodContrato='" + this.gridPacienteContrato.SelectedRow.Cells[3].Text + "' AND Documento='" + this.txt_documento.Text + "' AND Id='" + this.gridPacienteContrato.SelectedRow.Cells[0].Text + "'";

            if (Datos.insertar(sql))
            {
                lbl_mensajecontrato.Text = "Error al eliminar contrato al paciente, Verifique";
            }
            else
            {
                //gridPacienteContrato.Visible = true;
                fillgrilla();
                //ddl_eapb.ClearSelection();
                //ddl_contrato.ClearSelection();
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            
            if (txt_documento.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo documento se encuentra vacío";
                return;
            }

            if(VerificarPaciente(txt_documento.Text))
            {
                lbl_resultado.Text = "Ya existe un paciente con ese documento";
                return;
            }

            if (ddl_tipodoc.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione un tipo de documento";
                return;
            }

            if (txt_numhistoria.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo número de historia se encuentra vacío";
                return;
            }

            //if (txt_numcarnet.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo número de carnet se encuentra vacío";
            //    return;
            //}

            if (txt_nombre1.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo primer nombre se encuentra vacío";
                return;
            }

            //if (txt_nombre2.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo segundo nombre se encuentra vacío";
            //    return;
            //}

            if (txt_apellido1.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo primer apellido se encuentra vacío";
                return;
            }

            //if (txt_apellido2.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo segundo apellido se encuentra vacío";
            //    return;
            //}

            if (ddl_tipousuario.SelectedItem.ToString() == "Seleccione Tipo de Usuario")
            {
                lbl_resultado.Text = "Seleccione un el tipo de usuario";
                return;
            }

            if (ddl_tipousuario.SelectedItem.ToString() == "Contributivo" && ddl_tipoafiliado.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un tipo de afiliado si el tipo de usuario es Contributivo";
                return;
            }

            if (ddl_sexo.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione el sexo";
                return;
            }

            if (txt_fechanaci.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo fecha de nacimiento se encuentra vacío";
                return;
            }

            DateTime Test;
            if (DateTime.TryParseExact(txt_fechanaci.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) == true)
            {
                //Response.Write("Date OK");
            }
            else
            {
                lbl_resultado.Text = "Formato de fecha invalido. El formato de fecha es dia/mes/año";
                return;
            }

            DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechanaci.Text));
            if (ddl_departamento.SelectedItem.ToString() == "Seleccione Departamento")
            {
                lbl_resultado.Text = "Seleccione el departamento";
                return;
            }

            if (ddl_municipio.SelectedItem.ToString() == "Seleccione Municipio")
            {
                lbl_resultado.Text = "Seleccione el municipio";
                return;
            }

            if (ddl_zona.SelectedItem.ToString() == "Seleccione Zona")
            {
                lbl_resultado.Text = "Seleccione la zona residencial";
                return;
            }

            if (ddl_estrato.SelectedItem.ToString() == "Seleccione Estrato")
            {
                lbl_resultado.Text = "Seleccione el estrato";
                return;
            }

            if (txt_direccion.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo direccion se encuentra vacío";
                return;
            }

            if (txt_telefono.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo teléfono se encuentra vacío";
                return;
            }

            if (ddl_estado.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione el estado";
                return;
            }

            if (!VerificarPlanes(txt_documento.Text))
            {
                lbl_resultado.Text = "El Paciente no tiene asignado un contrato";
                return;
            }

            txt_edad.Text = DiferenciaFechas(DateTime.Now, fecha);
            string sql = "INSERT INTO Pacientes(Documento, TipoDocumento, NumHistoria, NumCarnet, Nombre1, Nombre2, Apellido1, Apellido2, TipoUsuario, TipoAfiliado, FechaNacimiento, Sexo, Departamento, Municipio, Zona, Estrato, Direccion, Telefono, Estado, Edad, umEdad) VALUES('" + this.txt_documento.Text + "', '" + this.ddl_tipodoc.SelectedValue.ToString() + "', '" + this.txt_numhistoria.Text + "', '" + this.txt_numcarnet.Text + "', '" + this.txt_nombre1.Text + "', '" + this.txt_nombre2.Text + "', '" + this.txt_apellido1.Text + "', '" + this.txt_apellido2.Text + "', '" + this.ddl_tipousuario.SelectedItem.ToString() + "', '" + this.ddl_tipoafiliado.SelectedItem + "', '" + fecha + "', '" + this.ddl_sexo.SelectedItem.ToString() + "', '" + this.ddl_departamento.SelectedValue.ToString() + "', '" + this.ddl_municipio.SelectedValue.ToString() + "', '" + this.ddl_zona.SelectedItem.ToString() + "', '" + this.ddl_estrato.SelectedItem.ToString() + "', '" + this.txt_direccion.Text + "', '" + this.txt_telefono.Text + "', '" + this.ddl_estado.SelectedItem.ToString() + "', '"+this.txt_edad.Text+"', '"+this.umEdad.Text+"')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                String sql2 = "DELETE FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'";
                if (Datos.insertar(sql2))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    foreach (GridViewRow row in gridPacienteContrato.Rows)
                    {
                        string cEntidad = row.Cells[1].Text;
                        string nEntidad = row.Cells[2].Text;
                        string cContrato = row.Cells[3].Text;
                        string nContrato = row.Cells[4].Text;
                        string documento = row.Cells[5].Text;
                        string sql5 = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + cEntidad + "', '"+ nEntidad  +"', '"+cContrato+"', '"+nContrato+"', '"+documento+"')";
                        if (Datos.insertar(sql5))
                        {
                            lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                        }
                        
                    }
                    //Response.Redirect("ConsultarPaciente.aspx");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupOpcionPacientes();", true);
                    this.lbl_mensajeopcion.Text = "Por favor seleccione una opción para continuar";
                }
            }
        }

        public bool VerificarPlanes(string Documento)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + Documento + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Documento", Documento);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        public bool VerificarPaciente(string Documento)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Pacientes WHERE Documento='" + Documento + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Documento", Documento);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void ddl_tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_numhistoria.Text = txt_documento.Text;
        }

        protected void btn_Admisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admisiones.aspx");
        }

        protected void btn_Factura_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaFactura.aspx");
        }

        protected void btn_citas_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Citas/AsignarCitas.aspx");
        }

       
    }
}