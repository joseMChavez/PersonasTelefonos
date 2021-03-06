﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Persona : ClaseMaestra
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public List<PersonaTelefono> TelefonoLista { get; set; }

       
        public Persona()
        {
            this.PersonaId = 0;
            this.Nombre = "";
            this.Sexo = "";
            TelefonoLista = new List<PersonaTelefono>();
        }

        public void AgregarTelefono(string tipo, string telefono)
        {
            TelefonoLista.Add(new PersonaTelefono(tipo, telefono));

        }

        public override bool Insertar()
        {
            int retorno = 0;
            ConexionDb conexion = new ConexionDb();
            try
            {
                //obtengo el identity insertado en la tabla personas
                retorno = Convert.ToInt32(conexion.ObtenerValor(string.Format("Insert Into Persona(Nombre,Sexo) values('{0}','{1}'); SELECT SCOPE_IDENTITY()" , this.Nombre, this.Sexo)));

                //  this.PersonaId = retorno;
                if (retorno > 0)
                {
                    foreach (PersonaTelefono item in this.TelefonoLista)
                    {
                        conexion.Ejecutar(string.Format("Insert into PersonaTelefono(PersonaId,TipoTelefono,Telefono) Values ({0},'{1}','{2}')",
                            retorno, item.TipoTelefono, item.Telefono));
                    }
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }
        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Update Persona set Nombre= '{0}', Sexo= '{1}' where PersonaId={2}", this.Nombre, this.Sexo,this.PersonaId));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("Delete from PersonaTelefono Where PersonaId={0}", this.PersonaId));
                    foreach (PersonaTelefono numero in this.TelefonoLista)
                    {
                        conexion.Ejecutar(string.Format("Insert into PersonaTelefono(PersonaId,TipoTelefono,Telefono) Values ({0},'{1}','{2}')",this.PersonaId, numero.TipoTelefono, numero.Telefono));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;

        }
        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from PersonaTelefono where PersonaId={0};"+"delete from Persona Where PersonaId= {0}", this.PersonaId));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dataTable = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Persona where PersonaId= {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Sexo = dt.Rows[0]["Sexo"].ToString();

                    dataTable = conexion.ObtenerDatos(string.Format("select * from PersonaTelefono where PersonaId='{0}'", this.PersonaId));
                    foreach (DataRow Fila in dataTable.Rows)
                    {
                        AgregarTelefono(Fila["TipoTelefono"].ToString(), Fila["Telefono"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Order by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Persona as P inner join PersonaTelefono as PT on P.PersonaId=PT.PersonaId Where " + Condicion + Orden);
        }
    }
}