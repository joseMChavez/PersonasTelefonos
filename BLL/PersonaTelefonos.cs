using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.ComponentModel;
namespace BLL
{

    public class PersonaTelefono
    {
        ConexionDb Conexion = new ConexionDb();

        public string TipoTelefono { get; set; }



        public string Tipo
        {
            get { return this.TipoTelefono.ToString(); }
        }


        public string Telefono { get; set; }

        public PersonaTelefono()
        {
            this.TipoTelefono = "Casa";
            this.Telefono = "";
        }
        public PersonaTelefono(string tipo, string telefono)
        {
            this.TipoTelefono = tipo;
            this.Telefono = telefono;
        }
    }
}
