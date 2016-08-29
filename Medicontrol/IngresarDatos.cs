using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medicontrol
{
    public class IngresarDatos
    {
        private string cadena = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        public SqlConnection cn;
        private SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        public void conectar()
        {
            cn = new SqlConnection(cadena);
        }
        public IngresarDatos()
        {
            conectar();
        }
        //CONSULTAR BASE DE DATOS
        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, cn);
            cmb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }
        //ELIMINAR BASE DE DATOS
        public bool eliminar(string tabla, string condicion)
        {
            cn.Open();
            string sql = "delete from" + tabla + "where" + condicion;
            comando = new SqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //ACTUALIZAR BASE DE DATOS
        public bool actualizar(string tabla, string campos, string condicion)
        {
            cn.Open();
            string sql = "update" + tabla + "set" + campos + "where" + condicion;
            comando = new SqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable consultar2(string tabla)
        {
            string sql = "select * from" + tabla;
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        //INSERTAR BASE DE DATOS
        public bool insertar(string sql)
        {

            cn.Open();
            comando = new SqlCommand(sql, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            cn.Close();
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }

        public bool insertarCap(string sql)
        {

            cn.Open();
            comando = new SqlCommand(sql, cn);
            comando.CommandTimeout = 1800; // 20 min...
            int i = Convert.ToInt32(comando.ExecuteScalar());
            cn.Close();
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }

        public bool insertarcobro(string sql)
        {

            //cn.Open();
            comando = new SqlCommand(sql, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            cn.Close();
        }

        public bool actualizoprofesional(string sql)
        {

            cn.Open();
            comando = new SqlCommand(sql, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }
        public bool insertarempresa(string sql)
        {

            cn.Open();
            comando = new SqlCommand(sql, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            cn.Close();
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            
        }


        public bool insertar3(string sql2)
        {

            //cn.Open();
            comando = new SqlCommand(sql2, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }
        public bool insertar300(string sql27)
        {

            //cn.Open();
            comando = new SqlCommand(sql27, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }
        public bool verificar(string sql3)
        {

            cn.Open();
            comando = new SqlCommand(sql3, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            cn.Close();
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            
        }

        public bool verificarcita(string sql3)
        {

            cn.Open();
            comando = new SqlCommand(sql3, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            cn.Close();
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }

        public bool verificar2(string sql4)
        {

            cn.Open();
            comando = new SqlCommand(sql4, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }


        public bool insertar2(string sql2)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            comando = new SqlCommand(sql2, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;
            }
            //cn.Close();
        }
         public bool verificardato1(string sqlc)
        {

            //cn.Open();
            comando = new SqlCommand(sqlc, cn);
            int i = Convert.ToInt32(comando.ExecuteScalar());
            if (i == 0)
            {
                return false;

            }
            else
            {
                return true;

            }
            //cn.Close();
        }
         public bool verificardato2(string sqlc1)
         {

             //cn.Open();
             comando = new SqlCommand(sqlc1, cn);
             int i = Convert.ToInt32(comando.ExecuteScalar());
             if (i == 0)
             {
                 return false;

             }
             else
             {
                 return true;

             }
             //cn.Close();
         }

        }
    }
