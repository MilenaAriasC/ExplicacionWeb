using ExplicacionWeb.DataLayer;
using ExplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.BussisnesLayer
{
    public class AprendizBL
    {
        public AprendizDl aprendizDl = new AprendizDl();
        public List<Aprendiz> listar()
        {
            return aprendizDl.Listar();
        }//FIN LISTAR aprendizdl

        public void guardar(Aprendiz aprendiz)
        {
            aprendizDl.Guardar(aprendiz);
        }//fin guardar 
        public void actualizar(Aprendiz aprendiz)
        {
            aprendizDl.Actualizar(aprendiz);
        }//fin actualizar
        public void eliminar (int id)
        {
            aprendizDl.Eliminar(id);
        }//fin actualizar
        public Aprendiz buscar(int id)
        {
            return aprendizDl.Buscar(id);
        }//fin buscar 

        internal void guardar(object aprendiz)
        {
            throw new NotImplementedException();
        }
    }//fin de la clase 
}