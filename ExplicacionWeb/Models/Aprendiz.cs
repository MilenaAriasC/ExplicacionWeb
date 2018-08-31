using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExplicacionWeb.Models
{
    public class Aprendiz
    {
        public int Id { get; set; }
        public String Nombres { get; set; }
        public String Apellido { get; set; }
        public String documento { get; set; }
        public Programa programa { get; set; }
        public int IdPrograma { get; set; }
        public Aprendiz() {
            programa = new Programa(); //SI NO SE INSTANCIA EL VALOR SERA NULO
        }
    }

}