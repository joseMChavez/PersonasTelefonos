Skip to content
This repository
Search
Pull requests
Issues
Gist
 @joseMChavez
 Watch 13
  Star 0
  Fork 0 enelramon/FinanzasPersonalesWeb2016
 Code  Issues 0  Pull requests 0  Projects 0  Wiki Pulse  Graphs
Branch: master Find file Copy pathFinanzasPersonalesWeb2016/BLL/PersonasTelefonos.cs
49e59ce on 24 Feb
Enel Almonte Ejemplo de Detalle
0 contributors
RawBlameHistory
38 lines(29 sloc)  777 Bytes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.ComponentModel;
namespace BLL
{

    public class PersonasTelefonos
    {
        ConexionDb Conexion = new ConexionDb();

        public string TipoTelefono { get; set; }



        public string Tipo
        {
            get { return this.TipoTelefono.ToString(); }
        }


        public string Telefono { get; set; }

        public PersonasTelefonos()
        {
            this.TipoTelefono = "Casa";
            this.Telefono = "";
        }
        public PersonasTelefonos(string tipo, string telefono)
        {
            this.TipoTelefono = tipo;
            this.Telefono = telefono;
        }
    }
}
