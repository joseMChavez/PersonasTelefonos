using System;
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
            //ActivarBotones(false);
            TelefonoTexBox.MaxLength = 15;
            DataTable dt = new DataTable();
            if (!IsPostBack)
            {

                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Tipo"), new DataColumn("Numero") });
                ViewState["Persona"] = dt;
            }
        }
        public bool Validar()
        {
            bool retorno = false;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) && (MRadio.Checked || FRadio.Checked) && TelefonosGridView.Rows.Count > 1)
            {
                retorno = true;
            }
            return retorno;
        }
        public void ActivarBotones(bool ok)
        {
            GuadarButton.Enabled = ok;
            EliminarButton.Enabled = ok;
            AgregarButton.Enabled = ok;
        }
        public void CargarDatos(Persona persona)
        {
            persona.Nombre = NombreTextBox.Text;
            if (MRadio.Checked)
            {
                persona.Sexo = "M";
            }
            else
            {
                persona.Sexo = "F";
            }
            foreach (GridViewRow row in TelefonosGridView.Rows)
            {
                persona.AgregarTelefono(row.Cells[0].Text, row.Cells[1].Text);
            }
        }
        public void DevolverDatos(Persona persona)
        {
            NombreTextBox.Text = persona.Nombre;
            if (persona.Sexo.Equals("M"))
            {
                MRadio.Checked=true;
            }
            else
            {
                FRadio.Checked = true;
            }
            foreach (var item in persona.TelefonoLista)
            {
                DataTable dt = (DataTable)ViewState["Persona"];
                dt.Rows.Add(item.TipoTelefono, item.Telefono);
                ViewState["Persona"] = dt;
                CargarGrid();
            }
        }
        public void CargarGrid()
        {
            TelefonosGridView.DataSource = (DataTable)ViewState["Persona"];
            TelefonosGridView.DataBind();
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
                
                dt.Rows.Add(fila);
                ViewState["Persona"] = dt;
                CargarGrid();
                TelefonoTexBox.Text = string.Empty;
                ActivarBotones(true);
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
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Tipo"), new DataColumn("Numero") });
            ViewState["Persona"] = dt;
            CargarGrid();
        }
        protected void TelefonosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            ActivarBotones(true);
            NombreTextBox.Focus();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            try
            {
               
                    CargarDatos(persona);
                    if (persona.Insertar())
                    {
                       Utils.MensajeToastr(this, "Se Guado con exito", "Exito", "success");
                        Limpiar();
                        NombreTextBox.Focus();

                    }
                    else
                    {
                        Utils.MensajeToastr(this, "Error en guardar", "Error", "Error");
                    }
               
            }catch(Exception ex)
            {
                 Utils.MensajeToastr(this, ex.Message, "Error", "Error");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            
            try
            {
                if (!string.IsNullOrWhiteSpace(PersonaIdTextBox.Text) && Validar().Equals(false))
                {
                    if (persona.Eliminar())
                    {
                        Utils.MensajeToastr(this, "Se Elimino con exito", "Exito", "success");
                        Limpiar();
                        NombreTextBox.Focus();
                    }
                    else
                    {
                        Utils.MensajeToastr(this, "Error en eliminar", "Error", "Error");
                    }
                }
            }
            catch (Exception ex)
            {

                Utils.MensajeToastr(this, ex.Message, "Error", "Error");
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPersonas.aspx");
        }
    }
}