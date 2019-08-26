<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoWebCarDealer.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--  --%>
    <div class="content">
    <div id ="Datos">

        <p style="color:#ffd800;text-align:center; font-size:larger">REGISTRO DE USUARIOS</p>

 <asp:Label ID="Label2" runat="server" Text="ID"></asp:Label>
                <asp:TextBox class="form-control" ID="IdNumericUpDown" runat="server" type="number" min="0" onkeypress="return isNumberKey(event)"></asp:TextBox>

<asp:Button ID="buscarButton" runat="server" Text="BUSCAR" class="btn btn-dark btn-lg text-center my-3"  style="text-align: right;width:345px" OnClick="buscarButton_Click1"/>

<asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox class="form-control" ID="NombresTextBox" runat="server" onkeypress="return isLetterKey(event)" ></asp:TextBox>

<asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="EmailTextBox"  pattern="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{1,5})$" runat="server"> </asp:TextBox>

<asp:Label ID="Label5" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox class="form-control" ID="usuario" runat="server" onkeypress="if (event.keyCode == 32) event.returnValue = false"> </asp:TextBox>

<asp:Label ID="Label6" runat="server" Text="Clave"></asp:Label>
                <asp:TextBox class="form-control" ID="ClaveTextBox" runat="server" type="password"> </asp:TextBox>

<asp:Label ID="Label7" runat="server" Text="Confirmar Clave"></asp:Label>
                <asp:TextBox class="form-control" ID="ConfirmarClaveTextBox" runat="server"  type="password"> </asp:TextBox>

 <asp:Label ID="Label8" runat="server" Text="Fecha Registro"></asp:Label>
                <asp:TextBox class="form-control" ID="FechaRegistros" type="date" runat="server" ></asp:TextBox>

                          <div style="text-align: right;width:340px"> 
<asp:Button ID="nuevoButton" runat="server" Text="NUEVO" class="btn btn-primary btn-lg text-center my-3" OnClick="nuevoButton_Click"/>         
 <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-lg text-center my-3" OnClick="GuardarButton_Click1"/>
 <asp:Button ID="Eliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-lg text-center my-3" OnClick="Eliminar_Click"/>

</div>
</div>
</div>
</asp:Content>
