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
    public partial class WebForm6 : System.Web.UI.Page
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
                Datos.consultar("SELECT * FROM CausaExterna ORDER BY Descripcion", "CausaExterna");
                this.ddl_causas.DataSource = Datos.ds.Tables["CausaExterna"];
                this.ddl_causas.DataTextField = "Descripcion";
                this.ddl_causas.DataValueField = "Id";
                this.ddl_causas.DataBind();
                ddl_causas.Items.Insert(0, new ListItem("Seleccione causa externa", "0"));

                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento");
                this.ddl_tipodoc.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc.DataTextField = "NomDocumento";
                this.ddl_tipodoc.DataValueField = "CodDocumento";
                this.ddl_tipodoc.DataBind();
                ddl_tipodoc.Items.Insert(0, new ListItem("Seleccione Documento", "0"));
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

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
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

            if(ddl_cobertura.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar una opción de cobertura";
                return;
            }
            if(ddl_cobertura.SelectedValue.ToString()=="1")
            {
                coberturaContributivo.Text = "X";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";
               
            }
            if (ddl_cobertura.SelectedValue.ToString() == "2")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "X";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "3")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "X";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "4")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "X";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "5")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "X";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "6")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "6";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "7")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "7";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "8")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "X";

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
            string query = "INSERT INTO Res3047_AT2_AIU(NumInforme, documento, fechainforme, TDI_RC, TDI_TI, TDI_CC, TDI_CE, TDI_PA, TDI_AS, TDI_MS, CS_RC, CS_RST, CS_RSP, CS_CONSISBEN, CS_SINSISBEN, CS_DESPLAZADO, CS_PAS, CS_OTRO, OA_ENFERMEDADGRAL, CodEntidad, CodUsuario) VALUES('"+this.txt_numInforme.Text+ "', '" + this.txt_cedula.Text + "', '" + fecha + "', '" + this.txt_tipodocvictimarc.Text + "', '" + this.txt_tipodocvictimati.Text + "', '" + this.txt_tipodocvictimacc.Text + "', '" + this.txt_tipodocvictimace.Text + "', '" + this.txt_tipodocvictimapa.Text + "', '" + this.txt_tipodocvictimaas.Text + "', '" + this.txt_tipodocvictimams.Text + "', '" + this.coberturaContributivo.Text + "', '" + this.coberturasubsidiototal.Text + "', '" + this.coberturasubsidioparcial.Text + "', '" + this.coberturapobreconsisben.Text + "', '" + this.coberturapobresinsisben.Text + "', '" + this.coberturadesplazados.Text + "', '" + this.coberturaplanadicional.Text + "', '" + this.coberturaotro.Text + "', 'X', '"+this.CodEntidad.Text + "', '"+this.CodigoSesion.Text+"')";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
                return;
            }
            else
            {
                
                lbl_resultado.Text = "Infome de AIU guardado";
                txt_buscar.Text = string.Empty;
                txt_cedula.Text= string.Empty;
                txt_nombre.Text= string.Empty;
                txt_fecha.Text=string.Empty;
                txt_hora.Text= string.Empty;
                ddl_causas.ClearSelection();
                ddl_cobertura.ClearSelection();
                ddl_tipodoc.ClearSelection();
                ddl_triage.ClearSelection();
                txt_entidad.Text= string.Empty;
                txt_contrato.Text= string.Empty;
                txt_estrato.Text= string.Empty;
                txt_edad.Text= string.Empty;
                txt_sexo.Text= string.Empty;

            }
        }
    }
}