using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                CodigoSesion.Text = Request.Cookies["Login"]["ID"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
            DateTime Hoy = DateTime.Now;
            txt_hora.Text = Hoy.AddHours(+2).ToShortTimeString();
            txt_fecha.Text = Hoy.ToString("dd/MM/yyyy");
            //txt_hora.Text = currentTime.ToLongTimeString();

            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento");
                this.ddl_respTipoDocumento.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_respTipoDocumento.DataTextField = "NomDocumento";
                this.ddl_respTipoDocumento.DataValueField = "CodDocumento";
                this.ddl_respTipoDocumento.DataBind();
                ddl_respTipoDocumento.Items.Insert(0, new ListItem("Seleccione Documento", "0"));

                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento.DataTextField = "Departamento";
                this.ddl_departamento.DataValueField = "CodDpto";
                this.ddl_departamento.DataBind();
                ddl_departamento.Items.Insert(0, new ListItem("Seleccione Departamento", "0"));

                Datos.consultar("SELECT * FROM Profesionales WHERE Estado='0' ORDER BY NombreCompleto", "Profesionales");
                this.ddl_profesionales.DataSource = Datos.ds.Tables["Profesionales"];
                this.ddl_profesionales.DataTextField = "NombreCompleto";
                this.ddl_profesionales.DataValueField = "CodProfesional";
                this.ddl_profesionales.DataBind();
                ddl_profesionales.Items.Insert(0, new ListItem("Seleccione profesional", "0"));
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

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un documento de paciente";
                return;

            }
            string query = "SELECT Pacientes.TipoDocumento AS TipoDocumento, Pacientes.Documento AS Documento, Pacientes.TipoUsuario, Pacientes.TipoAfiliado, Pacientes.Apellido1 AS Apellido1, Pacientes.Apellido2 AS Apellido2, Pacientes.Nombre1 AS Nombre1, Pacientes.Nombre2 AS Nombre2, Pacientes.FechaNacimiento AS FechaNacimiento, Pacientes.umEdad, Pacientes.Sexo AS Sexo, Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision, Admisiones.FechaAdmision, Admisiones.HoraAdmision, Admisiones.Estado, Pacientes.Zona, Pacientes.Estrato AS Estrato " +
                           "FROM Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Pacientes.Documento = '" + this.txt_buscar.Text + "' AND Admisiones.Estado <=1";

            //string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_numInforme.Text = leer["NumAdmision"].ToString();
                txt_tipodoc.Text = leer["TipoDocumento"].ToString();
                txt_cedula.Text = leer["Documento"].ToString();
                txt_nombre.Text = leer["Nombre1"].ToString() + " " + leer["Nombre2"].ToString() + " " + leer["Apellido1"].ToString() + " " + leer["Apellido2"].ToString();
                txt_sexo.Text = leer["Sexo"].ToString();
                fechanacimiento.Text = leer["FechaNacimiento"].ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                txt_sexo.Text = leer["Sexo"].ToString();
                txt_estrato.Text = leer["Estrato"].ToString();
                FechaNacimientoPac.Text = fechaNacimiento.ToString("dd/MM/yyyy");
                DateTime fechanaci = Convert.ToDateTime(ViewHelper.ConvertToDate(FechaNacimientoPac.Text));
                txt_edad.Text = DiferenciaFechas(DateTime.Now, fechanaci);
                conexion.Close();


                //PARA BUSCAR LA EMPRESA Y CONTRATO DEL PACIENTE

                //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado='Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";


                //***************************
                //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                SqlCommand comando2 = new SqlCommand(sql2, conexion);
                conexion.Open();
                int count = Convert.ToInt32(comando2.ExecuteScalar());
                conexion.Close();

                if (count > 1)
                {
                    fillgrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                    this.lbl_contratos.Text = "Seleccione Contrato";
                }

                if (count == 1)
                {
                    string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                    SqlCommand comando5 = new SqlCommand(sql5, conexion);
                    conexion.Open();
                    SqlDataReader leer2 = comando5.ExecuteReader();
                    if (leer2.Read() == true)
                    {
                        CodEntidad.Text = leer2["CodigoEntidad"].ToString();
                        txt_entidad.Text = leer2["NombreEntidad"].ToString();
                        CodContrato.Text = leer2["ContratoNumero"].ToString();
                        txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                        CodTipoContrato.Text = leer2["ContratoTipo"].ToString();
                    }
                }
                if (count == 0)
                {
                    lbl_resultado.Text = "El paciente no tiene empresa ni contrato asignado";
                    return;
                }
            }
        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT Entidad.Codigo AS EntidadCodigo, Entidad.NombreEntidad AS EntidadNombre, Contratos.Codigo AS ContratoCodigo, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_tipodoc.Text == "CC")
            {
                txt_tipodocvictimacc.Text = "X";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "CE")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "X";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "PA")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "X";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "TI")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "X";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "RC")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "X";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "AS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "X";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "MS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "X";
            }

            if (ddl_respTipoDocumento.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar el tipo de documento del responsable del paciente";
                return;
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "AS")
            {
                docuas.Text = "X";
                docucc.Text = "";
                docuce.Text = "";
                docums.Text = "";
                docupa.Text = "";
                docurc.Text = "";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "CC")
            {
                docuas.Text = "";
                docucc.Text = "X";
                docuce.Text = "";
                docums.Text = "";
                docupa.Text = "";
                docurc.Text = "";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "CE")
            {
                docuas.Text = "";
                docucc.Text = "";
                docuce.Text = "X";
                docums.Text = "";
                docupa.Text = "";
                docurc.Text = "";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "MS")
            {
                docuas.Text = "";
                docucc.Text = "";
                docuce.Text = "";
                docums.Text = "X";
                docupa.Text = "";
                docurc.Text = "";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "PA")
            {
                docuas.Text = "";
                docucc.Text = "";
                docuce.Text = "";
                docums.Text = "";
                docupa.Text = "X";
                docurc.Text = "";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "RC")
            {
                docuas.Text = "";
                docucc.Text = "";
                docuce.Text = "";
                docums.Text = "";
                docupa.Text = "";
                docurc.Text = "X";
                docuti.Text = "";
            }
            if (ddl_respTipoDocumento.SelectedValue.ToString() == "TI")
            {
                docuas.Text = "";
                docucc.Text = "";
                docuce.Text = "";
                docums.Text = "";
                docupa.Text = "";
                docurc.Text = "";
                docuti.Text = "X";
            }

            //TRAIGO EL NUMERO DE INFORME
            DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
            string query = "INSERT INTO Res4331_AT10_CONTRAREF(NumInforme, documento, fechainforme, TDI_RC, TDI_TI, TDI_CC, TDI_CE, TDI_PA, TDI_AS, TDI_MS, A_DOCUMENTO, NOMBRE1, NOMBRE2, APELLIDO1, APELLIDO2, TDIRC, TDITI, TDICC, TDICE, TDIPA, TDIAS, TDIMS, A_TIPODOC, DIRECCION, TELEFONO, DEPARTAMENTO, MUNICIPIO, CODPROFSOLICITA, SERVICIOCONTRARREFIERE, INFOCLINICA, CodEntidad, CodUsuario) VALUES('" + this.txt_numInforme.Text + "', '" + this.txt_cedula.Text + "', '" + fecha + "', '" + txt_tipodocvictimarc.Text + "', '" + txt_tipodocvictimati.Text + "', '" + txt_tipodocvictimacc.Text + "', '" + txt_tipodocvictimace.Text + "', '" + txt_tipodocvictimapa.Text + "', '" + txt_tipodocvictimaas.Text + "', '" + txt_tipodocvictimams.Text + "', '" + txt_respDocumento.Text + "', '" + txt_respNombre1.Text + "', '" + txt_respNombre2.Text + "', '" + txt_respApellido1.Text + "', '" + txt_respApellido2.Text + "', '" + docurc.Text + "', '" + docuti.Text + "', '" + docucc.Text + "', '" + docuce.Text + "', '" + docupa.Text + "', '" + docuas.Text + "', '" + docums + "', '" + ddl_respTipoDocumento.SelectedItem + "', '" + txt_direccion.Text + "', '" + txt_respTelefono.Text + "', '" + ddl_departamento.SelectedValue + "','" + ddl_municipio.SelectedValue + "', '" + ddl_profesionales.SelectedValue + "', '" + txt_serviciocontra.Text + "', '" + txt_infoclinica.Text + "', '" + CodEntidad.Text + "', '" + CodigoSesion.Text + "')";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
                return;
            }
            else
            {
                lbl_resultado.Text = "Infome de referencia guardado";
                txt_cedula.Text = string.Empty;
                txt_tipodoc.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_entidad.Text = string.Empty;
                txt_contrato.Text = string.Empty;
                txt_estrato.Text = string.Empty;
                txt_edad.Text = string.Empty;
                txt_sexo.Text = string.Empty;
                ddl_respTipoDocumento.ClearSelection();
                txt_respDocumento.Text = string.Empty;
                txt_respApellido1.Text = string.Empty;
                txt_respApellido2.Text = string.Empty;
                txt_respNombre1.Text = string.Empty;
                txt_respNombre2.Text = string.Empty;
                txt_respTelefono.Text = string.Empty;
                ddl_departamento.ClearSelection();
                ddl_municipio.ClearSelection();
                ddl_profesionales.ClearSelection();
                txt_serviciocontra.Text = string.Empty;                
                txt_infoclinica.Text = string.Empty;
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {

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
                    SqlConnection conexion = new SqlConnection(ruta);
                    txt_entidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[1].Text);
                    txt_contrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[3].Text);
                    CodContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[2].Text);
                    CodEntidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[0].Text);
                    CodTipoContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[4].Text);

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

        protected void ddl_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio.DataTextField = "Municipio";
            this.ddl_municipio.DataValueField = "CodMncpio";
            this.ddl_municipio.DataBind();
            ddl_municipio.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
    }
}