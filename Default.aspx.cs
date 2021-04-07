using Exercise_of_inheritance.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise_of_inheritance
{
    public partial class _Default : Page
    {
        List<Alumno> alumnos = new List<Alumno>();
        List<Profesor> profesor = new List<Profesor>();
        Datos datos = new Datos();

        string AlumnosFiles = "";
        string ProfesorFiles = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if( RadioButton1.Checked)
            {
                TextCarnet.Enabled = false;
                DropDownList1.Enabled = false;
                TextNota.Enabled = false;
                ButtonAlumno.Enabled = false;
            }

            if ( RadioButton2.Checked)
            {
                TextTitulo.Enabled = false;
                ButtonDocente.Enabled = false;
            }

            AlumnosFiles = Server.MapPath("Alumnos.txt");
            ProfesorFiles = Server.MapPath("Profesores.txt");
            
            if( validarArchivos() )
            {
                using( StreamReader rd = new StreamReader(AlumnosFiles) )
                {
                    alumnos = JsonConvert.DeserializeObject<List<Alumno>>(rd.ReadToEnd());
                }
                using( StreamReader rd = new StreamReader(ProfesorFiles) )
                {
                    profesor = JsonConvert.DeserializeObject<List<Profesor>>(rd.ReadToEnd());
                }
                
                if( alumnos == null )
                {
                    alumnos = new List<Alumno>();
                }

                if( profesor == null )
                {
                    profesor = new List<Profesor>();
                }
            }

            else
            {
                File.Create(AlumnosFiles);
                File.Create(ProfesorFiles);
            }

            Label5.Text = datos.calcEdad().ToString();
        }

        protected bool validarArchivos()
        {
            return File.Exists(AlumnosFiles)
                &&
                File.Exists(ProfesorFiles);
        }

        protected void guardarTodo()
        {
            using( StreamWriter sr = new StreamWriter(AlumnosFiles) )
            {
                sr.Write(JsonConvert.SerializeObject(alumnos));
            }
            using( StreamWriter sr = new StreamWriter(ProfesorFiles) )
            {
                sr.Write(JsonConvert.SerializeObject(profesor));
            }
        }

        protected void crearAlumno( string nombre, string apellido, string direccion, DateTime fechaNacimiento, string ID, string curso, int nota )
        {
            this.alumnos.Add(
                new Alumno(
                    nombre,
                    apellido,
                    direccion,
                    fechaNacimiento,
                    ID,
                    curso,
                    nota
                    ));
            this.guardarTodo();
        }

        protected void crearProfesor( string nombre, string apellido, string direccion, DateTime fechaNacimiento, string titulo )
        {
            this.profesor.Add(
                new Profesor(
                    nombre,
                    apellido,
                    direccion,
                    fechaNacimiento,
                    titulo
                    ));
            this.guardarTodo();
        }


        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                TextTitulo.Enabled = true;
                ButtonDocente.Enabled = true;
            }
        }

        protected void RadioButton2_CheckedChanged1(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                TextCarnet.Enabled = true;
                DropDownList1.Enabled = true;
                TextNota.Enabled = true;
                ButtonAlumno.Enabled = true;
            }
        }

        protected void ButtonAlumno_Click(object sender, EventArgs e)
        {
            this.crearAlumno(
                TextName.Text,
                TextLastName.Text,
                TextAddress.Text,
                Calendar1.SelectedDate.Date,
                TextCarnet.Text,
                DropDownList1.SelectedValue,
                int.Parse(TextNota.Text)
                );
            TextName.Text = "";
            TextLastName.Text = "";
            TextAddress.Text = "";
            Calendar1.SelectedDate = DateTime.UtcNow;
            TextCarnet.Text = "";
            TextNota.Text = "";
        }

        protected void ButtonDocente_Click(object sender, EventArgs e)
        {
                this.crearProfesor(
                TextName.Text,
                TextLastName.Text,
                TextAddress.Text,
                Calendar1.SelectedDate.Date,
                TextTitulo.Text
                );
                TextName.Text = "";
                TextLastName.Text = "";
                TextAddress.Text = "";
                Calendar1.SelectedDate = DateTime.UtcNow;
                TextTitulo.Text = "";
        }
    }
}