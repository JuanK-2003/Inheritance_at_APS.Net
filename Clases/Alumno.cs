using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise_of_inheritance.Clases
{
    public class Alumno : Datos
    {
        public string ID { get; set; }
        public int notas { get; set; }
        public string curso { get; set; }

        public Alumno()
        {
        }

        public Alumno(string nombre, string apellido, string direccion, DateTime fechaNacimiento, string ID, string curso, int notas )
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.ID = ID;
            this.curso = curso;
            this.notas = notas;
        }
    }
}