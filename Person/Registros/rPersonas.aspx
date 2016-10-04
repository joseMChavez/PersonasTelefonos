<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="rPersonas.aspx.cs" Inherits="Person.Registros.rPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Personas</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">

                    <%--PersonaId--%>
                    <div class="form-group">
                        <label for="PersonaIdTextBox" class="col-md-3 col-md-3 control-label input-sm">Persona Id: </label>
                        <div class="col-md-1 col-sm-2 col-xs-4">
                            <asp:TextBox ID="PersonaIdTextBox" runat="server" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                        <div class="col-md-2 col-xs-8">
                            <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click"><span class="glyphicon glyphicon-search"></span> </asp:LinkButton>
                        </div>


                    </div>

                    <%--Nombre--%>
                    <div class="form-group">
                        <label for="NombreTextBox" class="col-md-3 col-md-3 control-label input-sm">Nombre</label>
                        <div class="col-md-5 col-md-4">
                            <asp:TextBox ID="NombreTextBox" runat="server" placeholder="Escriba su nombre" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <%-- Sexo --%>
                        <label for="MRadio" class="col-md-2 col-md-1 control-label input-sm">Sexo</label>
                        <div class="col-md-2 col-md-2">
                            <asp:RadioButton CssClass="radio-inline" runat="server" ID="MRadio" GroupName="Persona" Text="M"></asp:RadioButton>
                            <asp:RadioButton CssClass="radio-inline " runat="server" ID="FRadio" GroupName="Persona" Text="F"></asp:RadioButton>

                        </div>
                    </div>

                    <%--Tipo telefono--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                    <div class="form-group">
                        <label for="TipoTelefonoDropDownLkist" class=" col-md-3 col-md-3 col-xs-2 control-label input-sm">Tipo Telefono</label>
                        <div class="col-md-2">
                            <asp:DropDownList ID="TipoTelefonoDropDownList" runat="server" Class="form-control input-sm">
                                <asp:ListItem Value="Casa">Casa</asp:ListItem>
                                <asp:ListItem Value="Mobil">Mobil</asp:ListItem>
                                <asp:ListItem Value="Trabajo">Trabajo</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <%--Telefono--%>

                        <label for="TelefonoTexBox" class="col-md-1 control-label input-sm">Telefono</label>
                        <div class="col-md-3">
                            
                                    <asp:TextBox ID="TelefonoTexBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ValidationGroup="Agregarbtn" ControlToValidate="TelefonoTexBox" ForeColor="Red" ErrorMessage="Introduz ca un telefono!"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ValidationGroup="Agregarbtn" ErrorMessage="Introduzca un numero valido" ControlToValidate="TelefonoTexBox" BorderStyle="Groove" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                                    </div>
                    <asp:Button ID="AgregarButton" CssClass="btn btn-primary glyphicon glyphicon-phone" runat="server" Text="Agregar" ValidationGroup="Agregarbtn" OnClick="AgregarButton_Click" />
    </div>


    <%--GridView--%>
    <div class="form-group">
        <div class=" col-md-3 col-md-3"></div>
        <div class=" col-md-3 col-md-3">

            <asp:GridView class="table table-bordered table-hover table-condensed" ID="TelefonosGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TelefonosGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="True" />
                    <asp:BoundField DataField="Numero" HeaderText="Numero" ReadOnly="True" />
                </Columns>
            </asp:GridView>

        </div>

    </div>
    
            </div>
    </ContentTemplate>
                </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Agregarbtn" />
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" CssClass="btn btn-success btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" CssClass="btn btn-info btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>
</asp:Content>
