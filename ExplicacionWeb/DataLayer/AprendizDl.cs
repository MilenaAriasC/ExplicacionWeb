using ExplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.DataLayer
{
    public class AprendizDl
    {
        public ConexionBD Bd { get; set; }
        public SqlCommand cmd { get; set; }

        public AprendizDl()
        {
            Bd = new ConexionBD();
        }
        public List<Aprendiz> Listar()
        {
            Bd.Cnx.Open();
            List<Aprendiz> lAprendiz = new List<Aprendiz>();
            cmd = new SqlCommand("Select ap.*,p.nombre From [Aprendiz] as ap,[programa] as p where ap.IdPrograma=p.IdPrograma", Bd.Cnx);
            //String sql = "faltaa comando ";
            //cmd = new SqlCommand("", Bd.Cnx);
            SqlDataReader rs;
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Aprendiz ap = new Aprendiz();
                ap.Id = Convert.ToInt32(rs["Id"]);
                ap.Nombres = rs["Nombres"].ToString();
                ap.Apellido= rs["Apellido"].ToString();
                 ap.documento= rs["documento"].ToString();
                ap.programa.IdPrograma = Convert.ToInt32(rs["IdPrograma"]);
                ap.programa.Nombre = rs["nombre"].ToString();
                ap.IdPrograma = Convert.ToInt32(rs["IdPrograma"]);
                lAprendiz.Add(ap);

            }//cierre while
            Bd.Cnx.Close();
            return lAprendiz;
        }//fin de listar
        public Aprendiz Buscar (int id)
        {
            Bd.Cnx.Open();
            cmd = new SqlCommand("Select ap.id,ap.nombres,ap.apellido,ap.documento,p.nombre,p.IdPrograma From [Aprendiz] as ap,[programa] as p where ap.IdPrograma=p.IdPrograma and ap.id="+id, Bd.Cnx);
            SqlDataReader rs;
            rs = cmd.ExecuteReader();
            Aprendiz ap = new Aprendiz();
            while (rs.Read()){
                ap.Id = Convert.ToInt32(rs["Id"]);
                ap.Nombres = rs["nombres"].ToString();
                ap.Apellido = rs["apellido"].ToString();
                ap.documento = rs["documento"].ToString();
                ap.programa.IdPrograma = Convert.ToInt32(rs["IdPrograma"]);
                ap.programa.Nombre = rs["nombre"].ToString();
                ap.IdPrograma = Convert.ToInt32(rs["IdPrograma"]);
                
            }//FIN WHILE
            Bd.Cnx.Close();
            return ap;    
        }//fin buscar 
        public bool Guardar(Aprendiz aprendiz) {
            bool respuesta = false;
            Bd.Cnx.Open();
            cmd = new SqlCommand("insert into Aprendiz(Nombres,Apellido, Documento, IdPrograma)values (@Nom,@ap,@numDoc,@IdProg)",Bd.Cnx );
            cmd.Parameters.AddWithValue("@Nom", aprendiz.Nombres);
            cmd.Parameters.AddWithValue("@ap", aprendiz.Apellido);
            cmd.Parameters.AddWithValue("@numDoc", aprendiz.documento);
            cmd.Parameters.AddWithValue("@idProg", aprendiz.IdPrograma);
            cmd.ExecuteNonQuery();
            Bd.Cnx.Close();
            respuesta = true;
            return respuesta;
        }//fin guardar
        public bool Actualizar(Aprendiz aprendiz)
        {
            bool respuesta = false;
            Bd.Cnx.Open();
            cmd = new SqlCommand("Update Aprendiz Set nombres=@Nom,apellido=@ap,documento=@numDoc,IdPrograma=@idProg where Id="+aprendiz.Id,Bd.Cnx); 

            cmd.Parameters.AddWithValue("@Nom", aprendiz.Nombres);
            cmd.Parameters.AddWithValue("@ap", aprendiz.Apellido);
            cmd.Parameters.AddWithValue("@numDoc", aprendiz.documento);
            cmd.Parameters.AddWithValue("@idProg", aprendiz.IdPrograma);
            cmd.ExecuteNonQuery();
            Bd.Cnx.Close();
            respuesta = true;
            return respuesta;
        }//fin actualizar

        public bool Eliminar (int id)
        {
            bool respuesta = false;
            Bd.Cnx.Open();
            cmd = new SqlCommand("Delete From Aprendiz Where Id=@Id", Bd.Cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Bd.Cnx.Close();
            respuesta = true;
            return respuesta;


        }//eliminar
    }//fin clase

}//fin Namespace