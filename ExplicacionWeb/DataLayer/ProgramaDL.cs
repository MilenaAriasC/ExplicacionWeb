using ExplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.DataLayer
{
    public class ProgramaDL
    {
        public ConexionBD Bd { get; set; }
        public SqlCommand cmd { get; set; }
        //CONSTRUCTOR
        public ProgramaDL()
        {
            Bd =  new ConexionBD();
    }//constructor
        public List<Programa> Listar()
        {//DEFINIR EL OBJETO PARA GUARDAR PROGRAMAS
            List<Programa> lPrograma = new List<Programa>();
            //ABRIR LA CONEXION A LA BD
            Bd.Cnx.Open();// atributo cnx es en la conexion bd
            //Instanciar el comando
            cmd = new SqlCommand("select * from programa", Bd.Cnx);
            //Definir el Datareader
            SqlDataReader rs;
            //ejecutamos la consulta y el resultado 
            //se guarda en rs
            rs = cmd.ExecuteReader();
            //recorremos rs
            while (rs.Read())
            {
                //asignar valor alos atributos
                //del objeto programa
                Programa pr = new Programa();
                pr.IdPrograma = Convert.ToInt32(rs["IdPrograma"]);
                pr.Nombre = rs["nombre"].ToString();
                //guardar el objeto pr en el contenedor
                lPrograma.Add(pr);
            }//while
            return lPrograma;
        }//    Listar
    

    }// clase
}//namespance

