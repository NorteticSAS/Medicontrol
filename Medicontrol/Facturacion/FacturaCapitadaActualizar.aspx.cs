using Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad WHERE Estado='Activo' ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidad.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidad.DataTextField = "NombreEntidad";
                this.ddl_entidad.DataValueField = "Codigo";
                this.ddl_entidad.DataBind();
                ddl_entidad.Items.Insert(0, new ListItem("Seleccione Entidad", "0"));

                Datos.consultar("SELECT * FROM IPS ORDER BY Nombre", "IPS");
                this.ddl_ips.DataSource = Datos.ds.Tables["IPS"];
                this.ddl_ips.DataTextField = "Nombre";
                this.ddl_ips.DataValueField = "Id";
                this.ddl_ips.DataBind();
                ddl_ips.Items.Insert(0, new ListItem("Seleccione IPS", "0"));
            }
        }

        protected void ddl_entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='" + this.ddl_entidad.SelectedValue + "' AND Estado='Activo' AND TipoContrato='2' ORDER BY Descripcion", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato", "0"));
        }

        protected void ddl_contrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT PrefijoFactura, Numfactura, CodIPS, FechaExpedicion, MesServicio, YearServicio, FechaInicial, FechaFinal, NumAfiliados, PorcentajeCap, Valor, Municipio FROM FacturaCapitada WHERE CodEntidad='" + this.ddl_entidad.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
            fillgrilla(sql);
        }

        private void fillgrilla(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            gridFacCap.DataSource = dt;

            gridFacCap.DataBind();

        }

        protected void gridFacCap_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridFacCap, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridFacCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridFacCap.Rows)
            {
                if (row.RowIndex == gridFacCap.SelectedIndex)
                {
                    lbl_resultado.Text = string.Empty;
                    Esta.Text = "0";
                    string sql = "SELECT * FROM FacturaCapitada WHERE CodEntidad='" + this.ddl_entidad.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "' AND Numfactura='" + HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[1].Text) + "'";
                    SqlConnection ConexionCONT = new SqlConnection(ruta);
                    SqlCommand comando6 = new SqlCommand(sql, ConexionCONT);
                    ConexionCONT.Open();
                    SqlDataReader leer6 = comando6.ExecuteReader();
                    if (leer6.Read() == true)
                    {
                        txt_numContrato.Text = leer6["CodContrato1"].ToString();
                    }
                    ConexionCONT.Close();
                    DateTime fechafac = Convert.ToDateTime(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[3].Text));
                    DateTime fechaIni = Convert.ToDateTime(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[6].Text));
                    DateTime fechaFin = Convert.ToDateTime(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[7].Text));
                    txt_facturaNum.Text = HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[1].Text);
                    txt_fechafac.Text = fechafac.ToString("dd/MM/yyyy");
                    txt_numafiliados.Text = HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[8].Text);

                    txt_fechaIni.Text = fechaIni.ToString("dd/MM/yyyy");
                    txt_fechaFin.Text = fechaFin.ToString("dd/MM/yyyy");
                    txt_porcapita.Text = HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[9].Text);
                    txt_valorNormal.Text = HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[10].Text);
                    txt_valor.Text = (Convert.ToDouble(txt_valorNormal.Text)).ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    //ddl_servicio.ClearSelection();
                    //ddl_servicio.Items.FindByValue(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[1].Text)).Selected = true;
                    txt_municipio.Text = HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[11].Text);

                    ddl_mes.ClearSelection();
                    ddl_mes.Items.FindByValue(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[4].Text)).Selected = true;
                    ddl_año.ClearSelection();
                    ddl_año.Items.FindByText(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[5].Text)).Selected = true;
                    ddl_ips.ClearSelection();
                    ddl_ips.Items.FindByValue(HttpUtility.HtmlDecode(gridFacCap.SelectedRow.Cells[2].Text)).Selected = true;
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

        protected void btn_umafil_Click(object sender, EventArgs e)
        {
            if (ddl_año.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar el año para calcular";
                return;
            }
            string sqlUPC = "SELECT * FROM UPC WHERE Year1='" + ddl_año.SelectedItem + "'";
            SqlConnection ConexionUPC = new SqlConnection(ruta);
            SqlCommand comando7 = new SqlCommand(sqlUPC, ConexionUPC);
            ConexionUPC.Open();
            SqlDataReader leer7 = comando7.ExecuteReader();
            if (leer7.Read() == true)
            {
                txt_upc2.Text = leer7["ValorUPCmes"].ToString();
                ValorUPCmes1.Text = leer7["ValorUPCmes"].ToString();
            }
            ConexionUPC.Close();

            double valorUPC = Convert.ToDouble(txt_upc2.Text);
            double NumAfil = Convert.ToDouble(txt_numafiliados.Text);
            double capita = Convert.ToDouble(txt_porcapita.Text);
            double totalMes = (NumAfil * (capita * valorUPC));
            txt_valorNormal.Text = totalMes.ToString();
            txt_valor.Text = totalMes.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
        }

       

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_fechafac.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe seleccionar una fecha de factura";
                return;
            }
            if (txt_numafiliados.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un numero de afiliados";
                return;
            }
            if (ddl_servicio.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un servicio";
                return;
            }
            if (txt_municipio.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe suministrar un Municipio";
                return;
            }
            if (ddl_mes.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un mes";
                return;
            }
            if (ddl_año.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un año";
                return;
            }
            DateTime FechaExp = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafac.Text));
            //DateTime FechaIni = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text));
            //DateTime FechaFin = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text));
            NumLetra nl = new NumLetra();
            string ValorEnLetras = nl.Convertir(txt_valorNormal.Text, true);
            string sql = "UPDATE FacturaCapitada SET FechaExpedicion='" + FechaExp + "', MesServicio='" + this.ddl_mes.SelectedValue + "', YearServicio='" + this.ddl_año.SelectedItem + "', Valor='" + this.txt_valorNormal.Text + "', ValorEnLetras='" + ValorEnLetras + "', NumAfiliados='" + this.txt_numafiliados.Text + "', Municipio='" + this.txt_municipio.Text.ToUpper() + "', Servicios='" + this.ddl_servicio.SelectedItem.Text.ToUpper() + "' WHERE Numfactura='" + this.txt_facturaNum.Text + "' AND CodEntidad='" + this.ddl_entidad.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
            try
            {
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error al eliminar, Verifique";
                }
                else
                {
                    lbl_resultado.Text = "Factura Actualizada con exito";
                    string sql2 = "SELECT PrefijoFactura, Numfactura, CodIPS, FechaExpedicion, MesServicio, YearServicio, FechaInicial, FechaFinal, NumAfiliados, PorcentajeCap, Valor, Municipio FROM FacturaCapitada WHERE CodEntidad='" + this.ddl_entidad.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
                    fillgrilla(sql2);
                    
                }
            }
            catch (Exception ex)
            {
                lbl_resultado.Text = "Se ha presentado el siguiente error: " + ex.ToString();
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT FacturaCapitada.NumFactura, FacturaCapitada.PrefijoFactura, FacturaCapitada.FechaExpedicion, FacturaCapitada.CodEntidad, Entidad.NombreEntidad, FacturaCapitada.Valor, FacturaCapitada.ValorEnLetras, FacturaCapitada.MesServicio, FacturaCapitada.YearServicio, FacturaCapitada.FechaInicial, FacturaCapitada.FechaFinal, Entidad.NIT, Entidad.Direccion, Entidad.Telefono, Entidad.Ciudad, IPS.Nombre, IPS.ResDIAN, FacturaCapitada.Codcontrato, FacturaCapitada.NumAfiliados, FacturaCapitada.PorcentajeCap, FacturaCapitada.Municipio, FacturaCapitada.Servicios, FacturaCapitada.CodContrato1 FROM IPS INNER JOIN (Entidad INNER JOIN FacturaCapitada ON Entidad.Codigo = FacturaCapitada.CodEntidad) ON IPS.Id = FacturaCapitada.CodIPS WHERE FacturaCapitada.NumFactura='" + this.txt_facturaNum.Text + "'";
            ImprimirFactura(consulta);
        }

        private void ImprimirFactura(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "FacturaCapitada.rdlc");
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

            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
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
            Response.AddHeader("content-disposition", "attachment; filename= FacturaCapitada" + gridFacCap.SelectedRow.Cells[1].Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

       
    }
}