using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise_of_inheritance.Clases
{
    public class Datos
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Datos()
        {
        }

        public Datos(string nombre, string apellido, string direccion, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
        }

        public int calcEdad()
        {
            int age = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            return age;
        }
    }
}