using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.DataLayer
{
    public class ConexionBD
    {
        public SqlConnection Cnx { get; set; }
        public ConexionBD()
        {

         Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CSExplicacion"].ToString());//Instaciar atributo de conexion y que string de  conexion vamos a usar 
        }//cambiar cssexplicacion 

    }
}