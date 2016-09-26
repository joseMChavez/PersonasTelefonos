<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="rPersonas.aspx.cs" Inherits="Person.Registros.rPersonas" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
        <div class="panel-heading">Registro de Personas</div>
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">

                <%--PersonaId--%>
                <div class="form-group">
                    <label for="PersonaIdTextBox" class="col-md-3 col-md-3 control-label input-sm">Persona Id: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox ID="PersonaIdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
                    </div>
                    
                        <div class="col-md-2 col-xs-8">
                            <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="ButtonBuscar" runat="server" ><span class="glyphicon glyphicon-search"></span> </asp:LinkButton>
                        </div>
                    
                   
                </div>

                <%--Nombre--%>
                <div class="form-group">
                    <label for="NombreTextBox" class="col-md-3 col-md-3 control-label input-sm">Nombre</label>
                    <div class="col-md-5 col-md-4">
                        <asp:TextBox ID="NombreTextBox" runat="server" placeholder="Escriba su nombre" Class="form-control input-sm"></asp:TextBox>
                    </div>
                     <%-- Sexo --%>
                     <label for="MRadio" class="col-md-2 col-md-1 control-label input-sm">Sexo</label>
                    <div class="col-md-2 col-md-2">
                         <asp:RadioButton CssClass="radio-inline" runat="server" Id="MRadio" value="M" GroupName="Persona" text="M"></asp:RadioButton>
                         <asp:RadioButton CssClass="radio-inline " runat="server" Id="FRadio" Value="F" GroupName="Persona" text="F"></asp:RadioButton>
                      
                    </div>
                </div>
     
                <%--Tipo telefono--%>
                <div class="form-group">
                    <label for="TipoTelefonoDropDownLkist" class=" col-md-3 col-md-3 col-xs-2 control-label input-sm">Tipo Telefono</label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="TipoTelefonoDropDownList" runat="server" Class="form-control input-sm">
                            <asp:ListItem value="Casa">Casa</asp:ListItem>
                            <asp:ListItem value="Mobil">Mobil</asp:ListItem>
                            <asp:ListItem value="Trabajo">Trabajo</asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                     <%--Telefono--%>
                     <label for="TelefonoTexBox" class="col-md-1 control-label input-sm">Telefono</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TelefonoTexBox" runat="server" placeholder="Telefono" Class="form-control input-sm"></asp:TextBox>
                        
                    </div>
                    <asp:Button ID="AgregarButton" CssClass="btn btn-primary glyphicon glyphicon-phone" runat="server" Text="Agregar" OnClick="AgregarButton_Click"  />
                </div>
                
            
            <%--GridView--%>
            <div class="form-group">
                <div class=" col-md-8 col-md-3">
                    <asp:GridView class="table table-bordered table-hover table-hover" ID="TelefonosGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TelefonosGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="True" />
                            <asp:BoundField DataField="Numero" HeaderText="Numero" ReadOnly="True" />
                        </Columns>
                </asp:GridView>

                </div>
                
            </div>
            </div>


        </div>
    </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">

                <asp:Button Text="Nuevo" class="btn btn-success btn-sm" runat="server" ID="NuevoButton" />
                <asp:Button Text="Guardar" class="btn btn-info btn-sm" runat="server" ID="GuadarButton"/>
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" />

            </div>
        </div>

    </div>
   
</asp:content>
