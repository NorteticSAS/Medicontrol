using Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm8 : System.Web.UI.Page
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
                this.ddl_tipodoc.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc.DataTextField = "NomDocumento";
                this.ddl_tipodoc.DataValueField = "CodDocumento";
                this.ddl_tipodoc.DataBind();
                ddl_tipodoc.Items.Insert(0, new ListItem("Seleccione Documento", "0"));

                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento");
                this.ddl_tipodoc2.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc2.DataTextField = "NomDocumento";
                this.ddl_tipodoc2.DataValueField = "CodDocumento";
                this.ddl_tipodoc2.DataBind();
                ddl_tipodoc2.Items.Insert(0, new ListItem("Seleccione Documento", "0"));
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

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un documento de paciente";
                return;

            }

            string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sqlPaciente, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_cedula.Text = leer["Documento"].ToString();
                txt_nombre.Text = leer["Nombre1"].ToString() + " " + leer["Nombre2"].ToString() + " " + leer["Apellido1"].ToString() + " " + leer["Apellido2"].ToString();
                txt_sexo.Text = leer["Sexo"].ToString();
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
                    lbl_resultado.Text = "El usuario no tiene entidad ni contrato asignados";
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";
            }
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

        protected void btn_crearSi_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoPaciente.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if(ddl_inconsistencia.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un tipo de inconsistencia";
                return;
            }
            if(ddl_inconsistencia.SelectedValue.ToString()=="1")
            {
                noexiste.Text = "X";
                nocorresponde.Text = "";
            }
            if (ddl_inconsistencia.SelectedValue.ToString() == "2")
            {
                noexiste.Text = "";
                nocorresponde.Text = "X";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un documento de identidad";
                return;
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "CC")
            {
                txt_tipodocvictimacc.Text = "X";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "CE")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "X";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "PA")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "X";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "TI")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "X";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "RC")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "X";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "AS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "X";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc.SelectedValue.ToString() == "MS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "X";
            }

            if(chk_primerNombre.Checked==true)
            {
                primernombre.Text = "X";
            }
            else
            {
                primernombre.Text = "";
            }
            if(chk_segundoNombre.Checked==true)
            {
                segundonombre.Text = "X";
            }
            else
            {
                segundonombre.Text = "";
            }
            if(chk_primerApellido.Checked==true)
            {
                primerapellido.Text = "X";
            }
            else
            {
                primerapellido.Text = "";
            }
            if(chk_segundoApellido.Checked==true)
            {
                segundoapellido.Text = "X";
            }
            else
            {
                segundoapellido.Text = "";
            }
            if(chk_Tipodocumento.Checked==true)
            {
                tipodocumento.Text = "X";
            }
            else
            {
                tipodocumento.Text = "";
            }
            if(chk_numDocumento.Checked==true)
            {
                numdocumento.Text = "X";
            }
            else
            {
                numdocumento.Text = "";
            }
            if(chk_fechaNacimiento.Checked==true)
            {
                fechaNacim.Text = "X";
            }
            else
            {
                fechaNacim.Text = "";
            }
            
            string consecutivo = "SELECT * FROM Consecutivos WHERE TipoCont='21'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(consecutivo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                int numfac = Convert.ToInt32(leer6["NumActual"].ToString());
                numfac = numfac + 1;
                txt_numInforme.Text = numfac.ToString();
            }
            ConexionConsec.Close();
            DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
            DateTime fechanaci;
            if(txt_fechaNacimiento.Text!=string.Empty)
            {
                fechanaci = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaNacimiento.Text));
            }
            
            string query = "INSERT INTO InconsistenciasBD(NumInforme, documento, fechainforme, TipoIncon1, TipoIncon2, TDI_RC, TDI_TI, TDI_CC, TDI_CE, TDI_PA, TDI_AS, TDI_MS, CS_RC, CS_RST, CS_RSP, CS_CONSISBEN, CS_SINSISBEN, CS_DESPLAZADO, CS_PAS, CS_OTRO, VI_APELLIDO1, VI_APELLIDO2, VI_NOMBRE1, VI_NOMBRE2, VI_TIPODOC, VI_NUMDOC, VI_FECHANAC, APELLIDO1, APELLIDO2, NOMBRE1, NOMBRE2, TIPODOC, NUMDOC, FECHANAC, Observaciones, CodEntidad, CodUsuario, Estado) VALUES('"+this.txt_numInforme.Text+ "', '"+this.txt_cedula.Text+ "', '"+this.txt_fecha.Text+ "', '"+this.noexiste.Text+ "', '"+this.nocorresponde.Text+ "', '"+this.txt_tipodocvictimarc.Text+ "', '"+this.txt_tipodocvictimati.Text+ "', '"+this.txt_tipodocvictimacc.Text+ "', '"+this.txt_tipodocvictimace.Text+ "', '"+this.txt_tipodocvictimapa.Text+ "', '"+this.txt_tipodocvictimaas.Text+ "', '"+this.txt_tipodocvictimams.Text+ "', '"+this.coberturaContributivo.Text+ "', '"+this.coberturasubsidiototal.Text+ "', '"+this.coberturasubsidioparcial.Text+ "', '"+this.coberturapobreconsisben.Text+ "', '"+this.coberturapobresinsisben.Text+ "', '"+this.coberturadesplazados.Text+ "', '"+this.coberturaplanadicional.Text+ "', '"+this.coberturaotro.Text+ "', '"+this.primerapellido.Text+ "', '"+this.segundoapellido.Text+ "', '"+this.primernombre.Text+ "', '"+this.segundonombre.Text+ "', '"+this.tipodocumento.Text+ "', '"+this.numdocumento.Text+ "', '"+this.fechaNacim.Text+ "', '"+this.txt_primerApellido.Text+ "', '"+this.txt_segundoApellido.Text+ "', '"+this.txt_primerNombre.Text+ "', '"+this.txt_segundoNombre.Text+ "', '"+this.ddl_tipodoc2.SelectedItem+ "', '"+this.txt_numDocumento.Text+ "', '"+this.txt_fechaNacimiento.Text+"', '"+this.txt_observaciones.Text+"', '"+this.CodEntidad.Text+ "', '"+this.CodigoSesion.Text+"', '0')";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
                return;
            }
            else
            {
                lbl_resultado.Text = "Inconsistencia Guardada";
                lbl_resultado.Text = "Informe actualizado correctamente";
                txt_cedula.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_entidad.Text = string.Empty;
                txt_contrato.Text = string.Empty;
                txt_estrato.Text = string.Empty;
                txt_edad.Text = string.Empty;
                txt_sexo.Text = string.Empty;
                ddl_tipodoc.ClearSelection();
                ddl_tipodoc2.ClearSelection();
                ddl_cobertura.ClearSelection();
                ddl_inconsistencia.ClearSelection();
                chk_fechaNacimiento.Checked = false;
                chk_numDocumento.Checked = false;
                chk_primerApellido.Checked = false;
                chk_primerNombre.Checked = false;
                chk_segundoApellido.Checked = false;
                chk_segundoNombre.Checked = false;
                chk_Tipodocumento.Checked = false;
                txt_primerApellido.Text = string.Empty;
                txt_segundoApellido.Text = string.Empty;
                txt_primerNombre.Text = string.Empty;
                txt_segundoNombre.Text = string.Empty;
                txt_numDocumento.Text = string.Empty;
                txt_fechaNacimiento.Text = string.Empty;
                txt_observaciones.Text = string.Empty;

            }
        }

        private void ImprimirReporte(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "Res3047_AT1.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                lbl_resultado.Text = "No se encontraron reportes por favor verifique con el administrador";
                return;
            }

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);

                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);

            }

            ReportDataSource rd = new ReportDataSource("DataSet2", dt);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.19685in</MarginTop>" +
            "  <MarginLeft>0.19685in</MarginLeft>" +
            "  <MarginRight>0.19685in</MarginRight>" +
            "  <MarginBottom>0.19685in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            Response.Clear(); // we're going to override the default page response
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= Inconsistencia" + txt_cedula.Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            string ConsultarInconsistencia = "SELECT TipoIncon1 FROM InconsistenciasBD WHERE NumInforme='" + txt_numInforme.Text + "'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(ConsultarInconsistencia, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                if(leer6["TipoIncon1"].ToString()=="X")
                {
                    string print1 = "SELECT Entidad.NombreEntidad, Pacientes.TipoDocumento, Pacientes.FechaNacimiento, Pacientes.Sexo, Pacientes.umEdad, Pacientes.Departamento, Pacientes.Municipio, Pacientes.Zona, Usuarios.Nombre, InconsistenciasBD.fechaInforme, InconsistenciasBD.TipoIncon1, InconsistenciasBD.TipoIncon2, InconsistenciasBD.TDI_RC, InconsistenciasBD.TDI_TI, InconsistenciasBD.TDI_CC, InconsistenciasBD.TDI_CE, InconsistenciasBD.TDI_PA, InconsistenciasBD.TDI_AS, " +
                                   "InconsistenciasBD.TDI_MS , InconsistenciasBD.CS_RC, InconsistenciasBD.CS_RST, InconsistenciasBD.CS_RSP, InconsistenciasBD.CS_CONSISBEN, InconsistenciasBD.CS_SINSISBEN, InconsistenciasBD.CS_DESPLAZADO, InconsistenciasBD.CS_PAS, InconsistenciasBD.CS_OTRO, InconsistenciasBD.VI_APELLIDO1, InconsistenciasBD.VI_APELLIDO2, InconsistenciasBD.VI_NOMBRE1, InconsistenciasBD.VI_NOMBRE2, InconsistenciasBD.VI_TIPODOC, InconsistenciasBD.VI_NUMDOC, InconsistenciasBD.VI_FECHANAC, InconsistenciasBD.APELLIDO1, " +
                                   "InconsistenciasBD.APELLIDO2, InconsistenciasBD.NOMBRE1, InconsistenciasBD.NOMBRE2, InconsistenciasBD.TIPODOC, InconsistenciasBD.NUMDOC, InconsistenciasBD.FECHANAC, InconsistenciasBD.NumInforme, InconsistenciasBD.Observaciones, Entidad.Codigo " +
                                   "FROM Pacientes INNER JOIN (Usuarios INNER JOIN (Entidad INNER JOIN InconsistenciasBD ON Entidad.Codigo = InconsistenciasBD.CodEntidad) ON Usuarios.CodUsuario = InconsistenciasBD.CodUsuario) ON Pacientes.Documento = InconsistenciasBD.documento " +
                                   "WHERE InconsistenciasBD.NumInforme='" + txt_numInforme.Text + "'";
                    ImprimirReporte(print1);
                }
                else
                {
                    string print2 = "SELECT Entidad.NombreEntidad, Pacientes.TipoDocumento, Pacientes.Apellido1, Pacientes.Apellido2, Pacientes.Nombre1, Pacientes.Nombre2, Pacientes.FechaNacimiento, Pacientes.Sexo, Pacientes.umEdad, Pacientes.Departamento, Pacientes.Municipio, Pacientes.Zona, Usuarios.Nombre, InconsistenciasBD.fechaInforme, InconsistenciasBD.TipoIncon1, InconsistenciasBD.TipoIncon2, InconsistenciasBD.TDI_RC, InconsistenciasBD.TDI_TI, InconsistenciasBD.TDI_CC, InconsistenciasBD.TDI_CE, InconsistenciasBD.TDI_PA, InconsistenciasBD.TDI_AS, " +
                                    "InconsistenciasBD.TDI_MS , InconsistenciasBD.CS_RC, InconsistenciasBD.CS_RST, InconsistenciasBD.CS_RSP, InconsistenciasBD.CS_CONSISBEN, InconsistenciasBD.CS_SINSISBEN, InconsistenciasBD.CS_DESPLAZADO, InconsistenciasBD.CS_PAS, InconsistenciasBD.CS_OTRO, InconsistenciasBD.VI_APELLIDO1, InconsistenciasBD.VI_APELLIDO2, InconsistenciasBD.VI_NOMBRE1, InconsistenciasBD.VI_NOMBRE2, InconsistenciasBD.VI_TIPODOC, InconsistenciasBD.VI_NUMDOC, InconsistenciasBD.VI_FECHANAC, InconsistenciasBD.APELLIDO1, " +
                                    "InconsistenciasBD.APELLIDO2, InconsistenciasBD.NOMBRE1, InconsistenciasBD.NOMBRE2, InconsistenciasBD.TIPODOC, InconsistenciasBD.NUMDOC, InconsistenciasBD.FECHANAC, InconsistenciasBD.NumInforme, InconsistenciasBD.Observaciones, Entidad.Codigo, InconsistenciasBD.documento " +
                                    "FROM Pacientes INNER JOIN (Usuarios INNER JOIN (Entidad INNER JOIN InconsistenciasBD ON Entidad.Codigo = InconsistenciasBD.CodEntidad) ON Usuarios.CodUsuario = InconsistenciasBD.CodUsuario) ON Pacientes.Documento = InconsistenciasBD.documento " +
                                    "WHERE InconsistenciasBD.NumInforme= '" + txt_numInforme.Text + "'";
                    ImprimirReporte(print2);
                }
            }
            ConexionConsec.Close();
        }
    }
}