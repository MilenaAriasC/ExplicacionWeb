using ExplicacionWeb.DataLayer;
using ExplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.BussisnesLayer
{
    public class ProgramaBL
    {
        public ProgramaDL programaDL = new ProgramaDL();// hay asociacion....donde no necesita inscribirse en el constructor para no dejar de ser nula 
        public List<Programa>listar()
        {
            return programaDL.Listar();
        } //metodo listar 


      






    }//fin clase 
}//fin namespace