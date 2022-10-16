using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pAplicacionesWEB.Modelos
{
    public class Libros
    {
        public int CodigoEstudiante { get; set; }
        public string  Nombre { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Error { get; set; }
        public string Comando { get; set; }

    }
}