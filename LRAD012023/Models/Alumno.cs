using System;
using System.Collections.Generic;
using System.Text;

namespace LRAD012023.Models
{
    public class Alumno
    {
        int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set;}
        public string sexo { get; set; }
        public string direccion { get; set;}
        public Byte[] foto { get; set; }
    }
}
