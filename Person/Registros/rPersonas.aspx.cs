﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Person.Registros
{
    public partial class rPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TelefonoTexBox.MaxLength = 15;
            DataTable dt = new DataTable();
            if (!IsPostBack)
            {
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Tipo"), new DataColumn("Numero") });
                ViewState["Persona"] = dt;
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {

            
            try
            {
                DataTable dt = (DataTable)ViewState["Persona"];
                DataRow fila;
                fila = dt.NewRow();
                fila["Tipo"] = TipoTelefonoDropDownList.SelectedValue;
                fila["Numero"] = TelefonoTexBox.Text;
                //dt.Rows.Add(TipoTelefonoDropDownList.SelectedValue, TelefonoTexBox.Text);
                dt.Rows.Add(fila);
                ViewState["Persona"] = dt;
                TelefonosGridView.DataSource = (DataTable)ViewState["Persona"];
                TelefonosGridView.DataBind();
                
                TelefonoTexBox.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void Limpiar()
        {
            NombreTextBox.Text = string.Empty;
            MRadio.Checked = false;
            FRadio.Checked = false;
            TipoTelefonoDropDownList.SelectedIndex = 0;
            TelefonoTexBox.Text = string.Empty;
        }
        protected void TelefonosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}