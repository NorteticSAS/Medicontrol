using Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
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

                DateTime hoy = DateTime.Now;
                txt_fecha.Text = hoy.ToString("dd/MM/yyyy");
                int year = hoy.Year;

            }
        }

        protected void ddl_entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='" + ddl_entidad.SelectedValue + "' AND Estado='Activo' AND TipoContrato='2' ORDER BY Descripcion", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));
        }

        protected void ddl_contrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            int year = hoy.Year;

            string sqlUPC = "SELECT * FROM UPC WHERE Year1='" + year + "'";
            SqlConnection ConexionUPC = new SqlConnection(ruta);
            SqlCommand comando7 = new SqlCommand(sqlUPC, ConexionUPC);
            ConexionUPC.Open();
            SqlDataReader leer7 = comando7.ExecuteReader();
            if (leer7.Read() == true)
            {
                txt_upc2.Text = leer7["ValorUPCmes"].ToString();
                ValorUPCmes1.Text = leer7["ValorUPCmes"].ToString();
            }
            txt_fecha.Text = hoy.ToShortDateString();
            ConexionUPC.Close();

            string query = "SELECT * FROM Contratos WHERE Estado='Activo' AND Entidad='" + this.ddl_entidad.SelectedValue + "' AND Codigo='" + this.ddl_contrato.SelectedValue + "'";
            SqlConnection ConexionCONT = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(query, ConexionCONT);
            ConexionCONT.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                CodContratoo.Text = leer6["Codigo"].ToString();
                txt_numcontrato.Text = leer6["NumeroContrato"].ToString();
                ValorMesNormal.Text = leer6["ValorMes"].ToString();
                txt_vrmensual.Text = Convert.ToDouble(ValorMesNormal.Text).ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                DateTime fechaini = Convert.ToDateTime(leer6["FechaInicial"].ToString());
                DateTime fechafini = Convert.ToDateTime(leer6["FechaFinal"].ToString());
                txt_fechaini.Text = fechaini.ToString("dd/MM/yyyy");
                txt_fechafin.Text = fechafini.ToString("dd/MM/yyyy");
                txt_municipio.Text = leer6["Municipio"].ToString();
                //double valorUPC = Convert.ToDouble(txt_upc2.Text);
                //double NumAfil = Convert.ToDouble(txt_numafiliados.Text);
                //double capita = Convert.ToDouble(txt_capita.Text);
                //double totalMes = (NumAfil * ((capita * valorUPC) / 100));
                //ValorMesNormal.Text = totalMes.ToString();
                //txt_vrmensual.Text = totalMes.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
            }
            ConexionCONT.Close();
        }

        protected void chb_conse1_CheckedChanged(object sender, EventArgs e)
        {
            chb_conse2.Checked = false;
        }

        protected void chb_conse2_CheckedChanged(object sender, EventArgs e)
        {
            chb_conse1.Checked = false;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (chb_conse1.Checked == false && chb_conse2.Checked == false)
            {
                lbl_resultado.Text = "No ha seleccionado el consecutivo de factura a utilizar";
                return;
            }
            //TRAEMOS EL ULTIMO CONSECUTIVO
            string consecutivo = string.Empty;
            if (chb_conse1.Checked == true)
            {
                consecutivo = "SELECT * FROM Consecutivos WHERE TipoCont='1'";
                TipoDoc.Text = "1";
            }
            if (chb_conse2.Checked == true)
            {
                consecutivo = "SELECT * FROM Consecutivos WHERE TipoCont='6'";
                TipoDoc.Text = "6";
            }
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(consecutivo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                Prefijo.Text = leer6["Prefijo"].ToString();
                int numfac = Convert.ToInt32(leer6["NumActual"].ToString());
                numfac = numfac + 1;
                NumFactura.Text = numfac.ToString();
            }
            ConexionConsec.Close();

            DateTime FechaExp = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
            DateTime FechaIni = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text));
            DateTime FechaFin = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text));
            NumLetra nl = new NumLetra();
            string ValorEnLetras = nl.Convertir(ValorMesNormal.Text, true);
            //Guardamos en la base de datos
            string insertar = "INSERT INTO FacturaCapitada(NumFactura, PrefijoFactura, CodIPS, FechaExpedicion, CodEntidad, CodContrato, CodContrato1, FechaInicial, FechaFinal, Valor, ValorEnLetras, Municipio, Detalle, Estado) VALUES('" + this.NumFactura.Text + "', '" + this.Prefijo.Text + "', '" + this.ddl_ips.SelectedValue + "', '" + FechaExp + "', '" + this.ddl_entidad.SelectedValue + "', '" + this.ddl_contrato.SelectedValue + "', '" + this.txt_numcontrato.Text + "', '" + FechaIni + "', '" + FechaFin + "', '" + this.ValorMesNormal.Text + "', '" + ValorEnLetras + "', '" + this.txt_municipio.Text.ToUpper() + "', '" + this.txt_detalle.Text + "', '0')";
            try
            {
                if (Datos.insertar(insertar))
                {
                    lbl_resultado.Text = "Error al eliminar, Verifique";
                }
                else
                {
                    string act = "UPDATE Consecutivos SET NumActual='" + this.NumFactura.Text + "' WHERE TipoCont='" + this.TipoDoc.Text + "'";
                    if (Datos.insertar(act))
                    {
                        lbl_resultado.Text = "Error al eliminar, Verifique";
                    }
                    else
                    {
                        txt_numfactura.Text = NumFactura.Text;
                        ddl_contrato.ClearSelection();
                        txt_numcontrato.Text = string.Empty;
                        ValorUPCmes1.Text = string.Empty;
                        txt_fechaini.Text = string.Empty;
                        txt_fechafin.Text = string.Empty;
                        txt_vrmensual.Text = string.Empty;
                        ddl_ips.ClearSelection();
                        txt_municipio.Text = string.Empty;
                        lbl_resultado.Text = "Factura Guardada";
                    }
                }
            }
            catch (Exception ex)
            {
                string act = "DELETE FROM FacturaCapitada WHERE NumFactura='" + this.NumFactura.Text + "'";
                if (Datos.insertarcobro(act))
                {
                    lbl_resultado.Text = "Error al eliminar, Verifique";
                }
                else
                {
                    lbl_resultado.Text = "Se ha presentado un error: " + ex.ToString();
                }
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT FacturaCapitada.NumFactura, FacturaCapitada.PrefijoFactura, FacturaCapitada.FechaExpedicion, FacturaCapitada.CodEntidad, Entidad.NombreEntidad, FacturaCapitada.Valor, FacturaCapitada.ValorEnLetras, FacturaCapitada.FechaInicial, FacturaCapitada.FechaFinal, Entidad.NIT, Entidad.Direccion, Entidad.Telefono, Entidad.Ciudad, IPS.Nombre, IPS.ResDIAN, FacturaCapitada.Codcontrato, FacturaCapitada.Servicios, FacturaCapitada.CodContrato1, FacturaCapitada.Detalle FROM IPS INNER JOIN (Entidad INNER JOIN FacturaCapitada ON Entidad.Codigo = FacturaCapitada.CodEntidad) ON IPS.Id = FacturaCapitada.CodIPS WHERE FacturaCapitada.NumFactura='" + this.NumFactura.Text + "'";
            ImprimirFactura(consulta);
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
            Response.AddHeader("content-disposition", "attachment; filename= Factura" + NumFactura.Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
    }
}