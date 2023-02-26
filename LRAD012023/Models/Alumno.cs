using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace LRAD012023.Models
{
    public class Alumno
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string nombres { get; set; }

        [MaxLength(100)]
        public string apellidos { get; set;}
        public string sexo { get; set; }

        [MaxLength(300)]
        public string direccion { get; set;}
        public Byte[] foto { get; set; }
    }
}
