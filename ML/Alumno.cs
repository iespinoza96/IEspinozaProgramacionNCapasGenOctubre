﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public ML.Semestre Semestre { get; set; } //propiedad de navegacion
        public List<object> Alumnos { get; set; }

        //public byte IdSemestre { get; set; }
    }
}
