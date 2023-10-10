<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Site.Pages.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro</title>
    <link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
</head>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="span10 offset1">
                <div class="row">
                    <h3 class="well">Cadastro de Cliente</h3>
                    <br />
                    Nome do Cliente: <br />
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome Completo" Width="45%" CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="requiredNome"
                        runat="server" 
                        ControlToValidate="txtNome" 
                        ErrorMessage="Por favor, digite seu nome." 
                        ForeColor="Red"/>
                        

                    <br /><br />

                    Endereco do Cliente: <br />
                    <asp:TextBox ID="txtEndereco" runat="server" placeholder="Endereco Residencial" Width="50%" CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredEndereco"
                        runat="server" 
                        ControlToValidate="txtEndereco" 
                        ErrorMessage="Por favor, digite seu endereco." 
                        ForeColor="Red"/>
                        
                    <br /><br />
                    Email do Cliente: <br />
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="45%" CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredEmail"
                        runat="server" 
                        ControlToValidate="txtEmail" 
                        ErrorMessage="Por favor, digite seu Email." 
                        ForeColor="Red"/>
                        
                    <br /><br />

                    <p>
                       <asp:label ID="lblMensagem" runat="server"/>
                    </p>

                    <asp:Button ID="btnCadastro" runat="server" Text="Cadastrar" class="btn btn-success btn-lg" OnClick="btnCadastrarCliente" />
                    <a href="/Default.aspx" class="btn btn-danger btn-lg">Voltar</a>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
