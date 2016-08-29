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
    public partial class Formulario_web110 : System.Web.UI.Page
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
            string sql = "SELECT PrefijoFactura, Numfactura, CodIPS, FechaExpedicion, FechaInicial, FechaFinal, Valor, Municipio, Detalle FROM FacturaCapitada WHERE CodEntidad='" + this.ddl_entidad.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
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
                    string consulta = "SELECT FacturaCapitada.NumFactura, FacturaCapitada.PrefijoFactura, FacturaCapitada.FechaExpedicion, FacturaCapitada.CodEntidad, Entidad.NombreEntidad, FacturaCapitada.Valor, FacturaCapitada.ValorEnLetras, FacturaCapitada.FechaInicial, FacturaCapitada.FechaFinal, Entidad.NIT, Entidad.Direccion, Entidad.Telefono, Entidad.Ciudad, IPS.Nombre, IPS.ResDIAN, FacturaCapitada.Codcontrato, FacturaCapitada.Servicios, FacturaCapitada.CodContrato1, FacturaCapitada.Detalle FROM IPS INNER JOIN (Entidad INNER JOIN FacturaCapitada ON Entidad.Codigo = FacturaCapitada.CodEntidad) ON IPS.Id = FacturaCapitada.CodIPS WHERE FacturaCapitada.NumFactura='" + this.gridFacCap.SelectedRow.Cells[1].Text + "'";
                    ImprimirFactura(consulta);
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

        private void ImprimirFactura(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "OtraFacturas.rdlc");
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
            Response.AddHeader("content-disposition", "attachment; filename= Factura" + gridFacCap.SelectedRow.Cells[1].Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

    }
}