﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Personas : ClaseMaestra
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }

        public List<PersonasTelefonos> Telefonos { get; set; }

        ConexionDb conexion = new ConexionDb();
        public Personas()
        {
            this.PersonaId = 0;
            this.Nombre = "";
            Telefonos = new List<PersonasTelefonos>();
        }

        public void AgregarTelefono(string tipo, string telefono)
        {
            Telefonos.Add(new PersonasTelefonos(tipo, telefono));

        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {
                //obtengo el identity insertado en la tabla personas
                identity = conexion.ObtenerValor(
                    string.Format("Insert Into Persona(Nombre) values('{0}') select @@Identity"
                    , this.Nombre));

                //intento convertirlo a entero
                int.TryParse(identity.ToString(), out retorno);

                this.PersonaId = retorno;
                foreach (PersonasTelefonos item in this.Telefonos)
                {
                    conexion.Ejecutar(string.Format("Insert into PersonaTelefono(PersonaId,TipoTelefono,Telefono) Values ({0},'{1}','{2}')",
                        retorno, item.TipoTelefono, item.Telefono));
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
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Update Persona set Nombre= '{0}' where PersonaId=", this.Nombre, this.PersonaId));
                if (retorno)
                {
                    conexion.Ejecutar("Delete from PersonaTelefono Where PersonaId=" + this.PersonaId.ToString());
                    foreach (PersonasTelefonos numero in this.Telefonos)
                    {
                        conexion.Ejecutar(string.Format("Insert into PersonaTelefono(PersonaId,TipoTelefono,Telefono) Values ({0},'{1}','{2}')", retorno, numero.TipoTelefono, numero.Telefono));
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
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from Persona where PersonaId=", this.PersonaId));

                if (retorno)
                    conexion.Ejecutar("Delete from PersonaTelefono Where PersonaId=" + this.PersonaId.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {

            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Personas where PersonaId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
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
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Personas Where " + Condicion + Orden);
        }
    }
}