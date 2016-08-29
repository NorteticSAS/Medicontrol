using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //CARGO LOS COMBOBOX DE FINALIDAD Y CAUSA EXTERNA PARA RIPS
         
        }
        //CONSULTAS
        protected void gridConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridConsultas.Rows)
            {

                if (row.RowIndex == gridConsultas.SelectedIndex)
                {
                    eliminarConsulta.Visible = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    //eliminarConsulta.Visible = false;
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gridConsultas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridConsultas, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }
        //FIN CONSULTAS
        //PROCEDIMIENTOS
        protected void gridProcedimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridProcedimientos.Rows)
            {

                if (row.RowIndex == gridProcedimientos.SelectedIndex)
                {
                    EliminarProcedimientos.Visible = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    //EliminarProcedimientos.Visible = false;
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gridProcedimientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridProcedimientos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }
        //FIN PROCEDIMIENTOS
        //MEDICAMENTOS
        protected void gridMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridMedicamentos.Rows)
            {

                if (row.RowIndex == gridMedicamentos.SelectedIndex)
                {
                    eliminarMedicamento.Visible = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    //eliminarMedicamento.Visible = false;
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gridMedicamentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridMedicamentos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }
        //FIN MEDICAMENTOS
        //OTROS SERVICIOS
        protected void gridOtrosservicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridOtrosservicios.Rows)
            {

                if (row.RowIndex == gridOtrosservicios.SelectedIndex)
                {
                    EliminarOtrosS.Visible = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    //EliminarOtrosS.Visible = false;
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gridOtrosservicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridOtrosservicios, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }
        //FIN OTROS SERVICIOS
        protected void btn_buscarAdmision_Click(object sender, EventArgs e)
        {
            if(txt_buscar.Text==string.Empty)
            {
                lbl_resultado.Text="Debe digitar un documento de paciente";
                return;
            }

            string queryVerificar = "SELECT Admisiones.NumeroAdmision, Admisiones.TipoAdmision, HistoricoPte.Hdocumento, Admisiones.DocumentoPaciente, Admisiones.Estado, HistoricoPte.Hentidad, HistoricoPte.Hcontrato, HistoricoPte.Htipocontrato, HistoricoPte.Hcodproced, HistoricoPte.Hfechaservicio, HistoricoPte.Hcantidad, HistoricoPte.Hcodprof, HistoricoPte.Hfinalidad, HistoricoPte.Hcausaexterna, HistoricoPte.Hdxppal, HistoricoPte.htdxppal, HistoricoPte.Hdr1, HistoricoPte.Hdr2, HistoricoPte.Hdr3, HistoricoPte.Hpatiende, HistoricoPte.CantidadOrden, HistoricoPte.CantidadDespachado, HistoricoPte.Hufuncional, HistoricoPte.Hcentrocostos, HistoricoPte.HconceptoRips FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.Htipoadmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE (((HistoricoPte.Hdocumento)= '" + txt_buscar.Text + "') AND ((Admisiones.Estado)=0 OR (Admisiones.Estado)=1))";
            SqlConnection conexionVerifica = new SqlConnection(ruta);
            SqlCommand comandoA = new SqlCommand(queryVerificar, conexionVerifica);
            conexionVerifica.Open();

            SqlDataReader leerA = comandoA.ExecuteReader();

            if (leerA.Read() == true)
            {
                string consulta = "SELECT Admisiones.NumeroAdmision AS NUMADMISION, Admisiones.TipoAdmision AS TIPOADMISION, HistoricoPte.Hdocumento AS DocumentoPaciente, Admisiones.DocumentoPaciente AS DOCUMENTOADMISION, Admisiones.Estado AS ESTADOADMISION, HistoricoPte.Hentidad AS CodigoEntidad, HistoricoPte.Hcontrato AS CodigoContrato, HistoricoPte.htipocontrato AS TIPOCONTRATO, HistoricoPte.Hcodproced AS CodigoProced, HistoricoPte.Hfechaservicio AS FECHASERVICIO, HistoricoPte.Hcantidad AS CantidadProced, HistoricoPte.Hcodprof AS PROFESIONAL, HistoricoPte.Hfinalidad AS FINALIDAD, HistoricoPte.Hcausaexterna AS CEXTERNA, HistoricoPte.Hdxppal AS DXP, HistoricoPte.Htdxppal AS TDXP, HistoricoPte.Hdr1 AS DXR1, HistoricoPte.Hdr2 AS DXR2, HistoricoPte.Hdr3 AS DXR3, HistoricoPte.Hpatiende AS PATIENDE, HistoricoPte.CantidadOrden AS CANTORDENADA, HistoricoPte.CantidadDespachado AS CANTDESPACHADO, HistoricoPte.Hufuncional AS UFUNCIONAL, HistoricoPte.Hcentrocostos AS CENTROC, HistoricoPte.HconceptoRips AS CONCEPTORIPS, HistoricoPte.cirujano AS CIRUJANO, HistoricoPte.aneste AS ANESTE, HistoricoPte.ayudantia AS AYUDANTE, HistoricoPte.DerSalacx AS SALACX, HistoricoPte.Materiales AS MATERIALES, HistoricoPte.materialesIncruento AS MATEINCRUENTO, HistoricoPte.FormaActoQx AS FORMAACTO, HistoricoPte.Incruento AS INCRUENTO, HistoricoPte.BilateralMultiple AS BILATERAL, HistoricoPte.GrupoQx AS GRUPOQ, HistoricoPte.Codpadre AS CODPADRE, HistoricoPte.Orden AS ORDEN, HistoricoPte.PorcLiquidacion AS PORCLIQUI FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.HtipoAdmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE HistoricoPte.Hdocumento= '" + this.txt_buscar.Text + "' AND Admisiones.Estado='0' ORDER BY HistoricoPte.Orden, HistoricoPte.Codpadre, HistoricoPte.GrupoQx DESC, HistoricoPte.HconceptoRIPS";
                SqlConnection conexionHistorico = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(consulta, conexionHistorico);
                conexionHistorico.Open();

                SqlDataReader leerHPT = comando.ExecuteReader();

                while (leerHPT.Read())
                {
                    CodigoContrato.Text = leerHPT["CodigoContrato"].ToString();
                    CodigoEntidad.Text = leerHPT["CodigoEntidad"].ToString();
                    txt_Codprocedimiento.Text = leerHPT["CodigoProced"].ToString();

                    string query = "SELECT Admisiones.DocumentoPaciente AS Documento, Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision AS TipoAdmision, Admisiones.FechaAdmision AS FechaAdmision, Admisiones.HoraAdmision AS HoraAdmision, Admisiones.Estado AS EstadoAdmision, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS Nombre, Admisiones.CodigoEntidad AS CodigoEnt, Admisiones.Codigocontrato AS CodContrato FROM Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Admisiones.DocumentoPaciente='" + this.txt_buscar.Text + "' AND Admisiones.Estado IN (0,1,5)";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comandoQ = new SqlCommand(query, conexion);
                    conexion.Open();

                    SqlDataReader leer = comandoQ.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        if (leer["EstadoAdmision"].ToString() == "0" || leer["EstadoAdmision"].ToString() == "1" || leer["EstadoAdmision"].ToString() == "5")
                        {
                            txt_nombre.Text = leer["Nombre"].ToString();
                            txt_numeroAdmision.Text = leer["NumAdmision"].ToString();
                            txt_cedula.Text = leer["Documento"].ToString();
                            TipoAdmision.Text = leer["TipoAdmision"].ToString();
                            if (TipoAdmision.Text == "0") txt_tipoAdmision.Text = "Ambulatoria";
                            if (TipoAdmision.Text == "1") txt_tipoAdmision.Text = "Hospitalizacion";
                            if (TipoAdmision.Text == "2") txt_tipoAdmision.Text = "Urgencias";
                            DateTime horaAdmision = Convert.ToDateTime(leer["FechaAdmision"].ToString());
                            txt_fechaHora.Text = horaAdmision.ToString("dd/MM/yyyy") + " " + leer["HoraAdmision"].ToString();
                            txt_fechaServicio.Text = DateTime.Now.AddHours(+2).ToString("dd/MM/yyyy HH:mm:ss");
                            ce.Text = leer["CodigoEnt"].ToString();
                            cc.Text = leer["CodContrato"].ToString();
                            //ME TRAIGO EL CONTRATO
                            conexion.Close();
                            string queryContratos = "SELECT Entidad.Codigo AS CodEntidad, Entidad.NombreEntidad AS NomEntidad, Contratos.Codigo AS CodContrato, Contratos.Descripcion AS DesContrato, Contratos.TipoContrato AS TipoContrato FROM Entidad INNER JOIN Contratos ON Entidad.Codigo = Contratos.Entidad WHERE Entidad.Codigo='" + this.ce.Text + "' AND Contratos.Codigo='" + this.cc.Text + "'";
                            SqlCommand comandoCont = new SqlCommand(queryContratos, conexion);
                            conexion.Open();

                            SqlDataReader leerC = comandoCont.ExecuteReader();

                            string borrarConsultas = "DELETE FROM RipsConsultaTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                            if (Datos.insertar(borrarConsultas))
                            {

                            }
                            string borrarProcedimientos = "DELETE FROM RipsProcedTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                            if (Datos.insertar(borrarProcedimientos))
                            {

                            }
                            string borrarMedicamento = "DELETE FROM MedicamentosTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                            if (Datos.insertar(borrarMedicamento))
                            {

                            }
                            string BorrarOtros = "DELETE FROM OtrosServiciosTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                            if (Datos.insertar(BorrarOtros))
                            {

                            }

                            if (leerC.Read() == true)
                            {
                                txt_entidad.Text = leerC["NomEntidad"].ToString();
                                txt_contrato.Text = leerC["DesContrato"].ToString();
                                CodigoEntidad.Text = leerC["CodEntidad"].ToString();
                                CodigoContrato.Text = leerC["CodContrato"].ToString();
                                TipoContrato.Text = leerC["TipoContrato"].ToString();
                            }
                            else
                            {
                                lbl_resultado.Text = "El paciente no tiene empresa y contato asignado";
                                return;
                            }
                            conexion.Close();
                        }
                        else
                        {
                            lbl_resultado.Text = "El paciente con admision anulada o no facturable";
                            return;
                        }
                    }
                    else
                    {
                        lbl_resultado.Text = "El paciente no tiene una admisión";
                        return;
                    }

                    //TRAIGO LOS PROCEDIMIENTOS QUE TIENE CARGADO EL PACIENTE AL MOMENTO


                }
            }
            else
            {

                string query = "SELECT Admisiones.DocumentoPaciente AS Documento, Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision AS TipoAdmision, Admisiones.FechaAdmision AS FechaAdmision, Admisiones.HoraAdmision AS HoraAdmision, Admisiones.Estado AS EstadoAdmision, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS Nombre, Admisiones.CodigoEntidad AS CodigoEnt, Admisiones.Codigocontrato AS CodContrato FROM Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Admisiones.DocumentoPaciente='" + this.txt_buscar.Text + "' AND Admisiones.Estado IN (0,1,5)";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    if (leer["EstadoAdmision"].ToString() == "0" || leer["EstadoAdmision"].ToString() == "1" || leer["EstadoAdmision"].ToString() == "5")
                    {
                        txt_nombre.Text = leer["Nombre"].ToString();
                        txt_numeroAdmision.Text = leer["NumAdmision"].ToString();
                        txt_cedula.Text = leer["Documento"].ToString();
                        TipoAdmision.Text = leer["TipoAdmision"].ToString();
                        if (TipoAdmision.Text == "0") txt_tipoAdmision.Text = "Ambulatoria";
                        if (TipoAdmision.Text == "1") txt_tipoAdmision.Text = "Hospitalizacion";
                        if (TipoAdmision.Text == "2") txt_tipoAdmision.Text = "Urgencias";
                        DateTime horaAdmision = Convert.ToDateTime(leer["FechaAdmision"].ToString());
                        txt_fechaHora.Text = horaAdmision.ToString("dd/MM/yyyy") + " " + leer["HoraAdmision"].ToString();
                        txt_fechaServicio.Text = DateTime.Now.AddHours(+2).ToString("dd/MM/yyyy HH:mm:ss");
                        ce.Text = leer["CodigoEnt"].ToString();
                        cc.Text = leer["CodContrato"].ToString();
                        //ME TRAIGO EL CONTRATO
                        conexion.Close();
                        string queryContratos = "SELECT Entidad.Codigo AS CodEntidad, Entidad.NombreEntidad AS NomEntidad, Contratos.Codigo AS CodContrato, Contratos.Descripcion AS DesContrato, Contratos.TipoContrato AS TipoContrato FROM Entidad INNER JOIN Contratos ON Entidad.Codigo = Contratos.Entidad WHERE Entidad.Codigo='" + this.ce.Text + "' AND Contratos.Codigo='" + this.cc.Text + "'";
                        SqlCommand comandoCont = new SqlCommand(queryContratos, conexion);
                        conexion.Open();

                        SqlDataReader leerC = comandoCont.ExecuteReader();

                        string borrarConsultas = "DELETE FROM RipsConsultaTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                        if (Datos.insertar(borrarConsultas))
                        {

                        }
                        string borrarProcedimientos = "DELETE FROM RipsProcedTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                        if (Datos.insertar(borrarProcedimientos))
                        {

                        }
                        string borrarMedicamento = "DELETE FROM MedicamentosTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                        if (Datos.insertar(borrarMedicamento))
                        {

                        }
                        string BorrarOtros = "DELETE FROM OtrosServiciosTablaH WHERE Documento='" + this.txt_cedula.Text + "'";
                        if (Datos.insertar(BorrarOtros))
                        {

                        }

                        if (leerC.Read() == true)
                        {
                            txt_entidad.Text = leerC["NomEntidad"].ToString();
                            txt_contrato.Text = leerC["DesContrato"].ToString();
                            CodigoEntidad.Text = leerC["CodEntidad"].ToString();
                            CodigoContrato.Text = leerC["CodContrato"].ToString();
                            TipoContrato.Text = leerC["TipoContrato"].ToString();
                        }
                        else
                        {
                            lbl_resultado.Text = "El paciente no tiene empresa y contato asignado";
                            return;
                        }
                        conexion.Close();
                    }
                    else
                    {
                        lbl_resultado.Text = "El paciente con admision anulada o no facturable";
                        return;
                    }
                }
                else
                {
                    lbl_resultado.Text = "El paciente no tiene una admisión";
                    return;
                }
            }
            conexionVerifica.Close();
        }

        protected void btn_BuscarCodigo_Click(object sender, EventArgs e)
        {
            if (txt_Codprocedimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un procedimiento";
                return;
            }
            string search = "SELECT * FROM Procedimientos WHERE CodProcedimiento='" + this.txt_Codprocedimiento.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                txt_CantidadProcedimiento.Text = string.Empty;
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Proedimiento no existe o se encuenta inactivo por favor verifique";
                txt_CantidadProcedimiento.Text = string.Empty;
                txt_Codprocedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
                return;
            }
        }

        protected void btn_buscarXnombre_Click(object sender, EventArgs e)
        {

            //CONSULTO EL CODIGO PROCEDIMIENTO A PARTIR DE LA DESCRIPCION
            string search = "SELECT * FROM Procedimientos WHERE DescProcedimiento='" + this.txt_procedimiento.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                txt_Codprocedimiento.Text = leers["CodProcedimiento"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                txt_CantidadProcedimiento.Text = string.Empty;
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Proedimiento no existe o se encuenta inactivo por favor verifique";
                txt_CantidadProcedimiento.Text = string.Empty;
                txt_Codprocedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
                return;
            }
            conexion.Close();
        }

        [WebMethod]
        public static string[] BuscarProcedimientos(string prefix)
        {
                    
            string sql = "select DescProcedimiento from Procedimientos where Estado='0' AND DescProcedimiento like '%'+@SearchText+'%'";
            
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}", sdr["DescProcedimiento"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        private void fillgrillaCentroCostos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT UnidadFuncional.CodUnidadF AS CodigoUnidad, UnidadFuncional.DescUnidadF AS DescUnidad, CentroCostos.CodCentroCostos AS CodigoCentroCostos, CentroCostos.DescCentroCosto AS DescCentroCostos, Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DesProced, Procedimientos.CodRips AS CodigoRips FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_Codprocedimiento.Text + "'";

                //string sql2 = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidades.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "' AND Contratos.Codigo= '" + CodigoContrato + "' AND Contratos.Entidad = '" + CodigoEntidad + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            GridCentroCostos.DataSource = dt;

            GridCentroCostos.DataBind();

        }

        protected void btn_cantidadProced_Click(object sender, EventArgs e)
        {
            Datos.consultar("SELECT * FROM TipoDX ORDER BY Descripcion", "TipoDX");
            this.Modal_ddlTipoDX.DataSource = Datos.ds.Tables["TipoDX"];
            this.Modal_ddlTipoDX.DataTextField = "Descripcion";
            this.Modal_ddlTipoDX.DataValueField = "Id";
            this.Modal_ddlTipoDX.DataBind();
            Modal_ddlTipoDX.Items.Insert(0, new ListItem("Seleccione tipo de Dx", "0"));

            Datos.consultar("SELECT * FROM AmbitoProced ORDER BY Descripcion", "AmbitoProced");
            this.ddl_ambito.DataSource = Datos.ds.Tables["AmbitoProced"];
            this.ddl_ambito.DataTextField = "Descripcion";
            this.ddl_ambito.DataValueField = "Codigo";
            this.ddl_ambito.DataBind();
            ddl_ambito.Items.Insert(0, new ListItem("Seleccione ambito", "0"));

            Datos.consultar("SELECT * FROM PersonalAtiende ORDER BY Descripcion", "PersonalAtiende");
            this.ddl_personal.DataSource = Datos.ds.Tables["PersonalAtiende"];
            this.ddl_personal.DataTextField = "Descripcion";
            this.ddl_personal.DataValueField = "Codigo";
            this.ddl_personal.DataBind();
            ddl_personal.Items.Insert(0, new ListItem("Seleccione personal", "0"));

            Datos.consultar("SELECT * FROM FinalidadConsulta ORDER BY DescFinalidadC", "FinalidadConsulta");
            this.Modal_ddlFinalidadConsulta.DataSource = Datos.ds.Tables["FinalidadConsulta"];
            this.Modal_ddlFinalidadConsulta.DataTextField = "DescFinalidadC";
            this.Modal_ddlFinalidadConsulta.DataValueField = "CodFinalidadC";
            this.Modal_ddlFinalidadConsulta.DataBind();
            Modal_ddlFinalidadConsulta.Items.Insert(0, new ListItem("Seleccione finalidad", "0"));

            Datos.consultar("SELECT * FROM CausaExterna ORDER BY Descripcion", "CausaExterna");
            this.Modal_ddlCausaEterna.DataSource = Datos.ds.Tables["CausaExterna"];
            this.Modal_ddlCausaEterna.DataTextField = "Descripcion";
            this.Modal_ddlCausaEterna.DataValueField = "Id";
            this.Modal_ddlCausaEterna.DataBind();
            Modal_ddlCausaEterna.Items.Insert(0, new ListItem("Seleccione Causa Externa", "0"));

            Datos.consultar("SELECT * FROM FinalidadProcedimiento ORDER BY DescFinalidadP", "FinalidadProcedimiento");
            this.RPFinalidad.DataSource = Datos.ds.Tables["FinalidadProcedimiento"];
            this.RPFinalidad.DataTextField = "DescFinalidadP";
            this.RPFinalidad.DataValueField = "CodFinalidadP";
            this.RPFinalidad.DataBind();
            RPFinalidad.Items.Insert(0, new ListItem("Seleccione finalidad", "0"));

            Datos.consultar("SELECT * FROM Profesionales WHERE Estado='0' ORDER BY NombreCompleto", "Profesionales");
            this.ddl_profesional.DataSource = Datos.ds.Tables["Profesionales"];
            this.ddl_profesional.DataTextField = "NombreCompleto";
            this.ddl_profesional.DataValueField = "CodProfesional";
            this.ddl_profesional.DataBind();
            ddl_profesional.Items.Insert(0, new ListItem("Seleccione profesional"));

            Datos.consultar("SELECT * FROM Profesionales WHERE Estado='0' ORDER BY NombreCompleto", "Profesionales");
            this.ddl_profesional2.DataSource = Datos.ds.Tables["Profesionales"];
            this.ddl_profesional2.DataTextField = "NombreCompleto";
            this.ddl_profesional2.DataValueField = "CodProfesional";
            this.ddl_profesional2.DataBind();
            ddl_profesional2.Items.Insert(0, new ListItem("Seleccione profesional"));

            SqlConnection conexion = new SqlConnection(ruta);
            //VALIDO QUE LA CANTIDAD SEA CORRECTA
            if (!Utilidades.isNumeric(txt_CantidadProcedimiento.Text))
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }
            if (Convert.ToDouble(txt_CantidadProcedimiento.Text) < 0)
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }

           

            string consulta = "SELECT COUNT(*) FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_Codprocedimiento.Text + "'";
            //string consulta = "SELECT COUNT(*) FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '"+this.txt_codProcedimiento.Text+"' AND Contratos.Codigo= '" + CodigoContrato + "' AND Contratos.Entidad = '" +CodigoEntidad+ "'";
            SqlCommand comando2 = new SqlCommand(consulta, conexion);
            conexion.Open();
            int count = Convert.ToInt32(comando2.ExecuteScalar());

            conexion.Close();

            if (count > 1)
            {
                lbl_resultado.Text = string.Empty;
                fillgrillaCentroCostos();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCentroCostos();", true);
                this.lbl_centroCostos.Text = "Seleccione un Centro de Costos";
            }
            if (count == 1)
            {
                lbl_resultado.Text = string.Empty;
                string sql5 = "SELECT UnidadFuncional.CodUnidadF AS CodigoUnidad, UnidadFuncional.DescUnidadF AS DescUnidad, CentroCostos.CodCentroCostos AS CodigoCentroCostos, CentroCostos.DescCentroCosto AS DescCentroCostos, Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DesProced, Procedimientos.CodRips AS CosigoRips FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_Codprocedimiento.Text + "'";
                SqlCommand comando5 = new SqlCommand(sql5, conexion);
                conexion.Open();
                SqlDataReader leer2 = comando5.ExecuteReader();
                if (leer2.Read() == true)
                {
                    CUF.Text = leer2["CodigoUnidad"].ToString();         //Codigo Unidad Funcional
                    CCC.Text = leer2["CodigoCentroCostos"].ToString();   //Codigo Centro de Costos
                    
                }
                conexion.Close();

                string sqlp = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidad.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.Estado='0' AND Procedimientos.CodProcedimiento= '" + this.txt_Codprocedimiento.Text + "' AND Contratos.Codigo= '" + this.CodigoContrato.Text + "' AND Contratos.Entidad = '" + this.CodigoEntidad.Text + "'";
                SqlCommand comando6 = new SqlCommand(sqlp, conexion);
                conexion.Open();
                SqlDataReader leerP = comando6.ExecuteReader();
                if (leerP.Read() == true)
                {

                    txt_codRips.Text = leerP["RipsProced"].ToString();
                    int codRips = Convert.ToInt32(txt_codRips.Text);
                    if (codRips == 1)
                    {
                        CodProcedimientoH.Text = leerP["CodProced"].ToString();
                        DesProcedimientoH.Text = leerP["DescProced"].ToString();
                        FechaServicioH.Text = txt_fechaServicio.Text;
                        CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                        CodigoRipsH.Text = txt_codRips.Text;
                        CodUfuncionalH.Text = CUF.Text;
                        CodCentrocH.Text = CCC.Text;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsConsulta();", true);
                        Modal_CodProced.Text = CodProcedimientoH.Text;

                    }
                    if (codRips > 1 && codRips <= 5)
                    {
                        CodProcedimientoH.Text = leerP["CodProced"].ToString();
                        DesProcedimientoH.Text = leerP["DescProced"].ToString();
                        FechaServicioH.Text = txt_fechaServicio.Text;
                        CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                        CodigoRipsH.Text = txt_codRips.Text;
                        CodUfuncionalH.Text = CUF.Text;
                        CodCentrocH.Text = CCC.Text;

                        ddl_ambito.ClearSelection();
                        ddl_ambito.Items.FindByValue("3").Selected = true;

                        ddl_personal.ClearSelection();
                        ddl_personal.Items.FindByValue("2").Selected = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsProced();", true);
                        RPCodProced.Text = CodProcedimientoH.Text;
                    }

                    if (codRips > 5 && codRips <= 11 || codRips == 14)
                    {
                        CodProcedimientoH.Text = leerP["CodProced"].ToString();
                        DesProcedimientoH.Text = leerP["DescProced"].ToString();
                        FechaServicioH.Text = txt_fechaServicio.Text;
                        CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                        CodigoRipsH.Text = txt_codRips.Text;
                        CodUfuncionalH.Text = CUF.Text;
                        CodCentrocH.Text = CCC.Text;
                        conexion.Close();
                        string sql = "INSERT INTO OtrosServiciosTablaH(Documento, Codigo, Descripcion, Fecha, Cantidad, UnidadF, CentroC, RIP) VALUES('" + this.txt_cedula.Text + "','" + CodProcedimientoH.Text + "', '" + this.DesProcedimientoH.Text + "', '" + this.FechaServicioH.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.CodUfuncionalH.Text + "', '" + this.CodCentrocH.Text + "', '" + this.CodigoRipsH.Text + "')";
                        if (Datos.insertar(sql))
                        {
                            lbl_resultado.Text = "No se modificó la información";
                        }
                        else
                        {
                            fillgrillaOtros();
                            txt_CantidadProcedimiento.Text = string.Empty;
                            txt_Codprocedimiento.Text = string.Empty;
                            txt_procedimiento.Text = string.Empty;
                        }
                    }

                    if (codRips > 11 && codRips <= 13)
                    {
                        CodProcedimientoH.Text = leerP["CodProced"].ToString();
                        DesProcedimientoH.Text = leerP["DescProced"].ToString();
                        FechaServicioH.Text = txt_fechaServicio.Text;

                        CodigoRipsH.Text = txt_codRips.Text;
                        CodUfuncionalH.Text = CUF.Text;
                        CodCentrocH.Text = CCC.Text;

                        //if (CantO.Text == string.Empty)
                        //{
                        //    lbl_resultado.Text = "Falta la cantidad ordenada";
                        //    return;
                        //}
                        //if (CantD.Text == string.Empty)
                        //{
                        //    lbl_resultado.Text = "Falta la cantidad despachada";
                        //    return;
                        //}
                        //if (CantA.Text == string.Empty)
                        //{
                        //    lbl_resultado.Text = "Falta la cantidad administrada";
                        //    return;
                        //}
                        //conexion.Close();

                        string sql = "INSERT INTO MedicamentosTablaH(Documento, Codigo, Descripcion, Fecha, CantO, CantD, CantA, UnidadF, CentroC, RIP) VALUES('" + this.txt_cedula.Text + "','" + CodProcedimientoH.Text + "', '" + this.DesProcedimientoH.Text + "', '" + this.FechaServicioH.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.CodUfuncionalH.Text + "', '" + this.CodCentrocH.Text + "', '" + this.CodigoRipsH.Text + "')";
                        if (Datos.insertar(sql))
                        {
                            lbl_resultado.Text = "No se modificó la información";
                        }
                        else
                        {
                            fillgrillaMedicamentos();
                            txt_CantidadProcedimiento.Text = string.Empty;
                            txt_Codprocedimiento.Text = string.Empty;
                            txt_procedimiento.Text = string.Empty;
                        }
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupMedicamentos();", true);

                    }
                    conexion.Close();

                }
                else
                {

                    lbl_resultado.Text = "Actividad primer nivel POS-S," + "" + "no cubre este Procedimiento por no estar contratado en el capitado actual, debe facturarlo por evento";
                    txt_CantidadProcedimiento.Text = string.Empty;
                    txt_Codprocedimiento.Text = string.Empty;
                    txt_procedimiento.Text = string.Empty;
                    return;
                }
            }
            if (count == 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene un centro de costo asociado";
                txt_CantidadProcedimiento.Text = string.Empty;
                txt_Codprocedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
                return;
            }

           

        }

        protected void GridCentroCostos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridCentroCostos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void GridCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridCentroCostos.Rows)
            {

                if (row.RowIndex == GridCentroCostos.SelectedIndex)
                {
                    CUF.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[0].Text);
                    CCC.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[2].Text);
                    SqlConnection conexion = new SqlConnection(ruta);
                    string sqlp = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidad.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + this.txt_Codprocedimiento.Text + "' AND Contratos.Codigo= '" + this.CodigoContrato.Text + "' AND Contratos.Entidad = '" + this.CodigoEntidad.Text + "'";
                    SqlCommand comando6 = new SqlCommand(sqlp, conexion);
                    conexion.Open();
                    SqlDataReader leerP = comando6.ExecuteReader();
                    if (leerP.Read() == true)
                    {

                        txt_codRips.Text = leerP["RipsProced"].ToString();
                        int codRips = Convert.ToInt32(txt_codRips.Text);
                        if (codRips == 1)
                        {
                            CodProcedimientoH.Text = leerP["CodProced"].ToString();
                            DesProcedimientoH.Text = leerP["DescProced"].ToString();
                            FechaServicioH.Text = txt_fechaServicio.Text;
                            CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                            CodigoRipsH.Text = txt_codRips.Text;
                            CodUfuncionalH.Text = CUF.Text;
                            CodCentrocH.Text = CCC.Text;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsConsulta();", true);
                            Modal_CodProced.Text = CodProcedimientoH.Text;

                        }
                        if (codRips > 1 && codRips <= 5)
                        {
                            CodProcedimientoH.Text = leerP["CodProced"].ToString();
                            DesProcedimientoH.Text = leerP["DescProced"].ToString();
                            FechaServicioH.Text = txt_fechaServicio.Text;
                            CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                            CodigoRipsH.Text = txt_codRips.Text;
                            CodUfuncionalH.Text = CUF.Text;
                            CodCentrocH.Text = CCC.Text;

                            ddl_ambito.ClearSelection();
                            ddl_ambito.Items.FindByValue("3").Selected = true;

                            ddl_personal.ClearSelection();
                            ddl_personal.Items.FindByValue("2").Selected = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsProced();", true);
                            RPCodProced.Text = CodProcedimientoH.Text;
                        }

                        if (codRips > 5 && codRips <= 11)
                        {
                            CodProcedimientoH.Text = leerP["CodProced"].ToString();
                            DesProcedimientoH.Text = leerP["DescProced"].ToString();
                            FechaServicioH.Text = txt_fechaServicio.Text;
                            CantidadProcedH.Text = txt_CantidadProcedimiento.Text;
                            CodigoRipsH.Text = txt_codRips.Text;
                            CodUfuncionalH.Text = CUF.Text;
                            CodCentrocH.Text = CCC.Text;
                            conexion.Close();
                            string sql = "INSERT INTO OtrosServiciosTablaH(Documento, Codigo, Descripcion, Fecha, Cantidad, UnidadF, CentroC, RIP) VALUES('" + this.txt_cedula.Text + "','" + CodProcedimientoH.Text + "', '" + this.DesProcedimientoH.Text + "', '" + this.FechaServicioH.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.CodUfuncionalH.Text + "', '" + this.CodCentrocH.Text + "', '" + this.CodigoRipsH.Text + "')";
                            if (Datos.insertar(sql))
                            {
                                lbl_resultado.Text = "No se modificó la información";
                            }
                            else
                            {
                                fillgrillaOtros();
                                txt_CantidadProcedimiento.Text = string.Empty;
                                txt_Codprocedimiento.Text = string.Empty;
                                txt_procedimiento.Text = string.Empty;
                            }
                        }

                        if (codRips > 11 && codRips <= 13)
                        {
                            CodProcedimientoH.Text = leerP["CodProced"].ToString();
                            DesProcedimientoH.Text = leerP["DescProced"].ToString();
                            FechaServicioH.Text = txt_fechaServicio.Text;

                            CodigoRipsH.Text = txt_codRips.Text;
                            CodUfuncionalH.Text = CUF.Text;
                            CodCentrocH.Text = CCC.Text;

                            //if (CantO.Text == string.Empty)
                            //{
                            //    lbl_resultado.Text = "Falta la cantidad ordenada";
                            //    return;
                            //}
                            //if (CantD.Text == string.Empty)
                            //{
                            //    lbl_resultado.Text = "Falta la cantidad despachada";
                            //    return;
                            //}
                            //if (CantA.Text == string.Empty)
                            //{
                            //    lbl_resultado.Text = "Falta la cantidad administrada";
                            //    return;
                            //}
                            //conexion.Close();

                            string sql = "INSERT INTO MedicamentosTablaH(Documento, Codigo, Descripcion, Fecha, CantO, CantD, CantA, UnidadF, CentroC, RIP) VALUES('" + this.txt_cedula.Text + "','" + CodProcedimientoH.Text + "', '" + this.DesProcedimientoH.Text + "', '" + this.FechaServicioH.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.txt_CantidadProcedimiento.Text + "', '" + this.CodUfuncionalH.Text + "', '" + this.CodCentrocH.Text + "', '" + this.CodigoRipsH.Text + "')";
                            if (Datos.insertar(sql))
                            {
                                lbl_resultado.Text = "No se modificó la información";
                            }
                            else
                            {
                                fillgrillaMedicamentos();
                                txt_CantidadProcedimiento.Text = string.Empty;
                                txt_Codprocedimiento.Text = string.Empty;
                                txt_procedimiento.Text = string.Empty;
                            }
                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupMedicamentos();", true);

                        }
                        conexion.Close();

                    }
                    else
                    {

                        lbl_resultado.Text = "Actividad primer nivel POS-S," + "" + "no cubre este Procedimiento por no estar contratado en el capitado actual, debe facturarlo por evento";
                        txt_CantidadProcedimiento.Text = string.Empty;
                        txt_Codprocedimiento.Text = string.Empty;
                        txt_procedimiento.Text = string.Empty;
                        return;
                    }

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

        protected void GuardarConsulta_Click(object sender, EventArgs e)
        {
            if (Modal_ddlFinalidadConsulta.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la finalidad de consulta en Rips Consulta";
                return;
            }
            if (Modal_ddlCausaEterna.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la causa externa en Rips Consulta";
                return;
            }

            if (Modal_DescDiagP.Text == string.Empty)
            {
                if (Modal_CodDiagP.Text == string.Empty)
                {
                    CODDP.Text = string.Empty;
                    lbl_resultado.Text = "falta el codigo de diagnostico principal";
                    return;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + Modal_CodDiagP.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CODDP.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico principal, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + Modal_DescDiagP.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODDP.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico principal, revisar";
                    return;
                }
                conexion.Close();
            }

            if (Modal_DescD1.Text == string.Empty)
            {
                if (Modal_CodD1.Text == string.Empty)
                {
                    CODD1.Text = string.Empty;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + Modal_CodD1.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CODD1.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico 2, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + Modal_DescD1.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD1.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico 2, revisar";
                    return;
                }
                conexion.Close();
            }

            if (Modal_DescD2.Text == string.Empty)
            {
                if (Modal_CodD2.Text == string.Empty)
                {
                    CODD2.Text = string.Empty;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + Modal_CodD2.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CODD2.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico 2, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + Modal_DescD2.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD2.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico 2, revisar";
                    return;
                }
                conexion.Close();
            }

            if (Modal_DescD3.Text == string.Empty)
            {
                if (Modal_CodD3.Text == string.Empty)
                {
                    CODD3.Text = string.Empty;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + Modal_CodD3.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CODD3.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico 3, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + Modal_DescD3.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD3.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico 3, revisar";
                    return;
                }
                conexion.Close();
            }
            if (Modal_ddlTipoDX.SelectedItem.ToString() == "Seleccione tipo de Dx")
            {
                lbl_resultado.Text = "Debe selecionar el tipo de diagnostico principal";
                    return;
            }
            string query = "INSERT INTO RipsConsultaTablaH(Documento, CodProcedimiento, DesProcedimiento, Finalidad, CausaEXT, DXPrincipal, TipoDXPrincipal, DX1, DX2, DX3, Fecha, Cantidad, Profesional, Ufuncional, CentroC, Rip) VALUES('" + this.txt_cedula.Text + "', '" + this.CodProcedimientoH.Text + "', '" + this.DesProcedimientoH.Text + "', '" + this.Modal_ddlFinalidadConsulta.SelectedValue + "', '" + this.Modal_ddlCausaEterna.SelectedValue + "', '" + this.CODDP.Text + "', '" + this.Modal_ddlTipoDX.SelectedValue + "', '" + this.CODD1.Text + "', '" + this.CODD2.Text + "', '" + this.CODD3.Text + "', '" + this.FechaServicioH.Text + "', '" + this.CantidadProcedH.Text + "', '" + ddl_profesional.SelectedValue + "', '" + this.CodUfuncionalH.Text + "', '" + this.CodCentrocH.Text + "', '" + this.CodigoRipsH.Text + "')";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "No se modificó la información";
            }
            else
            {
                fillgrillaRipsConsulta();
                txt_CantidadProcedimiento.Text = string.Empty;
                txt_Codprocedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
            }
        }

        private void fillgrillaRipsConsulta()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, CodProcedimiento, DesProcedimiento, Finalidad, CausaEXT, DXPrincipal, TipoDXPrincipal, DX1, DX2, DX3, Fecha, Cantidad, Profesional, Ufuncional, CentroC, Rip FROM RipsConsultaTablaH WHERE Documento='" + this.txt_cedula.Text + "'", cn);
                da.Fill(dt);
            }

            gridConsultas.DataSource = dt;

            gridConsultas.DataBind();

        }

        protected void GuardarRipsProced_Click(object sender, EventArgs e)
        {
            if (ddl_ambito.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "falta el ambito en RIPS Procedimientos";
                return;
            }
            if (RPFinalidad.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la finalidad en RIPS Procedimientos";
                return;
            }
            if (ddl_personal.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "falta el personal que atiende en RIPS Procedimientos";
                return;
            }
            if (RPDDiangP.Text == string.Empty)
            {
                if (RPCodDiagP.Text == string.Empty)
                {
                    CDPRP.Text = string.Empty;
                    //lbl_resultado.Text = "falta el codigo de diagnostico principal";
                    //return;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + RPCodDiagP.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CDPRP.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico principal, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE NOMBRE='" + RPDDiangP.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDPRP.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico principal, revisar";
                    return;
                }
                conexion.Close();
            }
            if (RPDDiagR.Text == string.Empty)
            {
                if (RPCodDiaGR.Text == string.Empty)
                {
                    CDRRP.Text = string.Empty;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + RPCodDiaGR.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CDRRP.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico relacionado, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + RPDDiagR.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDRRP.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico relacionado, revisar";
                    return;
                }
                conexion.Close();
            }
            if (RPDDiagC.Text == string.Empty)
            {
                if (RPCodDiagC.Text == string.Empty)
                {
                    CDCRP.Text = string.Empty;
                }
                else
                {
                    string sqlDP = "SELECT * FROM CIE10SEXO WHERE Codigo='" + RPCodDiagC.Text.ToUpper() + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sqlDP, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        CDCRP.Text = leer["Codigo"].ToString();
                    }
                    else
                    {
                        lbl_resultado.Text = "No se encontró un Diagnostico complementario, revisar";
                        return;
                    }
                    conexion.Close();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10SEXO WHERE Nombre='" + RPDDiagC.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDCRP.Text = leer["Codigo"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se encontró un Diagnostico complementario, revisar";
                    return;
                }
                conexion.Close();
            }

            string sql = "INSERT INTO RipsProcedTablaH(Documento, CodProcedimiento, Ambito, Finalidad, Personal, DPX, DCX, DRX, DesProcedimiento, Fecha, Cantidad, Profesional, UnidadF, CentroC, RIP) VALUES('" + this.txt_cedula.Text + "', '" + this.CodProcedimientoH.Text + "', '" + this.ddl_ambito.SelectedValue + "', '" + this.RPFinalidad.SelectedValue + "', '" + this.ddl_personal.SelectedValue + "', '" + CDPRP.Text + "', '" + CDCRP.Text + "', '" + CDRRP.Text + "', '"+this.DesProcedimientoH.Text+"','"+this.FechaServicioH.Text+"', '"+CantidadProcedH.Text+"', '"+this.ddl_profesional2.SelectedValue+"', '"+this.CodUfuncionalH.Text+"', '"+this.CodCentrocH.Text+"', '"+this.CodigoRipsH.Text+"')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se modificó la información";
            }
            else
            {
                fillgrillaRipsProcedimientos();
                txt_CantidadProcedimiento.Text = string.Empty;
                txt_Codprocedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
            }
        }

        private void fillgrillaRipsProcedimientos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, CodProcedimiento, Ambito, Finalidad, Personal, DPX, DRX, DCX, DesProcedimiento, Fecha, Cantidad, Profesional, UnidadF, CentroC, RIP FROM RipsProcedTablaH WHERE Documento='" + this.txt_cedula.Text + "'", cn);
                da.Fill(dt);
            }

            gridProcedimientos.DataSource = dt;

            gridProcedimientos.DataBind();

        }

        protected void GuardarMedicamentos_Click(object sender, EventArgs e)
        {
            //if (CantO.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "Falta la cantidad ordenada";
            //    return;
            //}
            //if (CantD.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "Falta la cantidad despachada";
            //    return;
            //}
            //if (CantA.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "Falta la cantidad administrada";
            //    return;
            //}

            //string sql = "INSERT INTO MedicamentosTablaH(Documento, Codigo, Descripcion, Fecha, CantO, CantD, CantA, UnidadF, CentroC, RIP) VALUES('"+this.txt_cedula.Text+"','"+CodProcedimientoH.Text+"', '"+this.DesProcedimientoH.Text+"', '"+this.FechaServicioH.Text+"', '"+this.CantO.Text+"', '"+this.CantD.Text+"', '"+this.CantA.Text+"', '"+this.CodUfuncionalH.Text+"', '"+this.CodCentrocH.Text+"', '"+this.CodigoRipsH.Text+"')";
            //if (Datos.insertar(sql))
            //{
            //    lbl_resultado.Text = "No se modificó la información";
            //}
            //else
            //{
            //    fillgrillaMedicamentos();
            //}

        }

        private void fillgrillaMedicamentos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Codigo, Descripcion, Fecha, CantO, CantD, CantA, UnidadF, CentroC, RIP FROM MedicamentosTablaH WHERE Documento='" + this.txt_cedula.Text + "'", cn);
                da.Fill(dt);
            }
            gridMedicamentos.DataSource = dt;

            gridMedicamentos.DataBind();

        }

        private void fillgrillaOtros()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Codigo, Descripcion, Fecha, Cantidad, UnidadF, CentroC, RIP FROM OtrosServiciosTablaH WHERE Documento='" + this.txt_cedula.Text + "'", cn);
                da.Fill(dt);
            }

            gridOtrosservicios.DataSource = dt;

            gridOtrosservicios.DataBind();

        }

        protected void btn_guardarTabla_Click(object sender, EventArgs e)
        {
            //GUARDAR CONSULTAS
            foreach (GridViewRow Rips in gridConsultas.Rows)
            {
                string cProced = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                string desproced = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                string fecha = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                string cantidad = HttpUtility.HtmlDecode(Rips.Cells[4].Text);
                string prof = HttpUtility.HtmlDecode(Rips.Cells[5].Text);
                string finalidad = HttpUtility.HtmlDecode(Rips.Cells[6].Text);
                string cext = HttpUtility.HtmlDecode(Rips.Cells[7].Text);
                string dxp;
                if (Rips.Cells[8].Text == "&nbsp;")
                {
                    dxp = string.Empty;
                }
                else
                {
                    dxp = HttpUtility.HtmlDecode(Rips.Cells[8].Text);
                }
                string tdx = HttpUtility.HtmlDecode(Rips.Cells[9].Text);
                string dx1;
                if (Rips.Cells[10].Text == "&nbsp;")
                {
                    dx1 = string.Empty;
                }
                else
                {
                    dx1 = HttpUtility.HtmlDecode(Rips.Cells[10].Text);
                }
                string dx2;
                if (Rips.Cells[11].Text == "&nbsp;")
                {
                    dx2 = string.Empty;
                }
                else
                {
                    dx2 = HttpUtility.HtmlDecode(Rips.Cells[11].Text);
                }
                string dx3;
                if (Rips.Cells[12].Text == "&nbsp;")
                {
                    dx3 = string.Empty;
                }
                else
                {
                    dx3 = HttpUtility.HtmlDecode(Rips.Cells[12].Text);
                }
                string uf = HttpUtility.HtmlDecode(Rips.Cells[13].Text);
                string cc = HttpUtility.HtmlDecode(Rips.Cells[14].Text);
                string rip = HttpUtility.HtmlDecode(Rips.Cells[15].Text);
                string actRipsC = "INSERT INTO HistoricoPte(HnumAdmision, Htipoadmision, Hdocumento, Hentidad, Hcontrato, Htipocontrato, Hcodproced, Hdesproced, Hfechaservicio, Hcantidad, Hcodprof, Hfinalidad, Hcausaexterna, Hdxppal, Htdxppal, Hdr1, Hdr2, Hdr3, Hufuncional, Hcentrocostos, HconceptoRips) VALUES('"+this.txt_numeroAdmision.Text+"', '"+this.TipoAdmision.Text+"', '"+this.txt_cedula.Text+"', '"+this.CodigoEntidad.Text+"', '"+this.CodigoContrato.Text+"', '"+this.TipoContrato.Text+"', '"+cProced+"', '"+desproced+"', '"+fecha+"', '"+cantidad+"', '"+prof+"', '"+finalidad+"', '"+cext+"', '"+dxp+"', '"+tdx+"', '"+dx1+"', '"+dx2+"', '"+dx3+"', '"+uf+"', '"+cc+"', '"+rip+"')";
                if (Datos.insertar(actRipsC))
                {
                    lbl_resultado.Text = "Error al almacenar la factura";
                }
                else
                {

                }
            }
            //GUARDAR PROCEDIMIENTOS
            foreach (GridViewRow Rips in gridProcedimientos.Rows)
            {
                string cProced = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                string desproced = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                string fecha = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                string cantidad = HttpUtility.HtmlDecode(Rips.Cells[4].Text);
                string prof = HttpUtility.HtmlDecode(Rips.Cells[5].Text);
                string finalidad = HttpUtility.HtmlDecode(Rips.Cells[6].Text);
                string patiende = HttpUtility.HtmlDecode(Rips.Cells[7].Text);
                string dxp;
                if (Rips.Cells[8].Text == "&nbsp;")
                {
                    dxp = string.Empty;
                }
                else
                {
                    dxp = HttpUtility.HtmlDecode(Rips.Cells[8].Text);
                }
                string dxr;
                if (Rips.Cells[9].Text == "&nbsp;")
                {
                    dxr = string.Empty;
                }
                else
                {
                    dxr = HttpUtility.HtmlDecode(Rips.Cells[9].Text);
                }
                string dxc;
                if (Rips.Cells[10].Text == "&nbsp;")
                {
                    dxc = string.Empty;
                }
                else
                {
                    dxc = HttpUtility.HtmlDecode(Rips.Cells[10].Text);
                }
                string uf = HttpUtility.HtmlDecode(Rips.Cells[11].Text);
                string cc = HttpUtility.HtmlDecode(Rips.Cells[12].Text);
                string rip = HttpUtility.HtmlDecode(Rips.Cells[13].Text);
                string actRipsP = "INSERT INTO HistoricoPte(HnumAdmision, Htipoadmision, Hdocumento, Hentidad, Hcontrato, Htipocontrato, Hcodproced, Hdesproced, Hfechaservicio, Hcantidad, Hcodprof, Hfinalidad, Hpatiende, Hdxppal, Hdr1, Hdr2, Hufuncional, Hcentrocostos, HconceptoRips) VALUES('" + this.txt_numeroAdmision.Text + "', '" + this.TipoAdmision.Text + "', '" + this.txt_cedula.Text + "', '" + this.CodigoEntidad.Text + "', '" + this.CodigoContrato.Text + "', '" + this.TipoContrato.Text + "', '" + cProced + "', '" + desproced + "', '" + fecha + "', '" + cantidad + "', '" + prof + "', '" + finalidad + "', '" + patiende + "', '" + dxp + "', '" + dxr + "', '" + dxc + "', '" + uf + "', '" + cc + "', '" + rip + "')";
                if (Datos.insertar(actRipsP))
                {
                    lbl_resultado.Text = "Error al almacenar la factura";
                }
                else
                {

                }
            }
            
            //GUARDAR MEDICAMENTOS
            foreach (GridViewRow Rips in gridMedicamentos.Rows)
            {
                string cProced = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                string desproced = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                string fecha = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                string canto = HttpUtility.HtmlDecode(Rips.Cells[4].Text);
                string cantd = HttpUtility.HtmlDecode(Rips.Cells[5].Text);
                string canta = HttpUtility.HtmlDecode(Rips.Cells[6].Text);
                string uf = HttpUtility.HtmlDecode(Rips.Cells[7].Text);
                string cc = HttpUtility.HtmlDecode(Rips.Cells[8].Text);
                string rip = HttpUtility.HtmlDecode(Rips.Cells[9].Text);
                string actRipsP = "INSERT INTO HistoricoPte(HnumAdmision, Htipoadmision, Hdocumento, Hentidad, Hcontrato, Htipocontrato, Hcodproced, Hdesproced, Hfechaservicio, CantidadOrden, CantidadDespachado, Hcantidad, Hufuncional, Hcentrocostos, HconceptoRips) VALUES('" + this.txt_numeroAdmision.Text + "', '" + this.TipoAdmision.Text + "', '" + this.txt_cedula.Text + "', '" + this.CodigoEntidad.Text + "', '" + this.CodigoContrato.Text + "', '" + this.TipoContrato.Text + "', '" + cProced + "', '" + desproced + "', '" + fecha + "', '" + canto + "', '" + cantd + "', '" + canta + "', '" + uf + "', '" + cc + "', '" + rip + "')";
                if (Datos.insertar(actRipsP))
                {
                    lbl_resultado.Text = "Error al almacenar la factura";
                }
                else
                {

                }
            }

            //GUARDAR OTROS SERVICIOS
            foreach (GridViewRow Rips in gridOtrosservicios.Rows)
            {
                string cProced = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                string desproced = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                string fecha = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                string cantidad = HttpUtility.HtmlDecode(Rips.Cells[4].Text);
                string uf = HttpUtility.HtmlDecode(Rips.Cells[5].Text);
                string cc = HttpUtility.HtmlDecode(Rips.Cells[6].Text);
                string rip = HttpUtility.HtmlDecode(Rips.Cells[7].Text);
                string actRipsP = "INSERT INTO HistoricoPte(HnumAdmision, Htipoadmision, Hdocumento, Hentidad, Hcontrato, Htipocontrato, Hcodproced, Hdesproced, Hfechaservicio, Hcantidad, Hufuncional, Hcentrocostos, HconceptoRips) VALUES('" + this.txt_numeroAdmision.Text + "', '" + this.TipoAdmision.Text + "', '" + this.txt_cedula.Text + "', '" + this.CodigoEntidad.Text + "', '" + this.CodigoContrato.Text + "', '" + this.TipoContrato.Text + "', '" + cProced + "', '" + desproced + "', '" + fecha + "', '" + cantidad + "', '" + uf + "', '" + cc + "', '" + rip + "')";
                if (Datos.insertar(actRipsP))
                {
                    lbl_resultado.Text = "Error al almacenar la factura";
                }
                else
                {

                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupOrdenSalida();", true);
            lbl_mensajeOrden.Text = "Procedimientos asignados Correctamente. Desea dar orden de salida?";
           
        }

        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }

        protected void eliminarConsulta_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM RipsConsultaTablaH WHERE CodProcedimiento='" + this.gridConsultas.SelectedRow.Cells[1].Text + "' AND Documento='" + this.txt_cedula.Text + "' AND ID='" + this.gridConsultas.SelectedRow.Cells[0].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaRipsConsulta();
                eliminarConsulta.Visible = false;
            }
        }

        protected void EliminarProcedimientos_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM RipsProcedTablaH WHERE CodProcedimiento='" + this.gridProcedimientos.SelectedRow.Cells[1].Text + "' AND Documento='" + this.txt_cedula.Text + "' AND ID='" + this.gridProcedimientos.SelectedRow.Cells[0].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaRipsProcedimientos();
                EliminarProcedimientos.Visible = false;
            }
        }

        protected void eliminarMedicamento_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM MedicamentosTablaH WHERE Codigo='" + this.gridMedicamentos.SelectedRow.Cells[1].Text + "' AND Documento='" + this.txt_cedula.Text + "' AND Id='" + this.gridMedicamentos.SelectedRow.Cells[0].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaMedicamentos();
                eliminarMedicamento.Visible = false;
            }
        }

        protected void EliminarOtrosS_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM OtrosServiciosTablaH WHERE Codigo='" + this.gridOtrosservicios.SelectedRow.Cells[1].Text + "' AND Documento='" + this.txt_cedula.Text + "' AND Id='" + this.gridOtrosservicios.SelectedRow.Cells[0].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaOtros();
                EliminarOtrosS.Visible = false;
            }
        }

        protected void btn_No_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            ddl_ambito.ClearSelection();
            ddl_personal.ClearSelection();
            ddl_profesional.ClearSelection();
            ddl_profesional2.ClearSelection();
            fillgrillaMedicamentos();
            fillgrillaOtros();
            fillgrillaRipsConsulta();
            fillgrillaRipsProcedimientos();
        }

        protected void btn_aCeptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdenSalida.aspx");
        }

    }
}