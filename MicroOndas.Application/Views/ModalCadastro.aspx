<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModalCadastro.aspx.cs" Inherits="MicroOndas.Application.Views.ModalCadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Cadastro de Pre Aquecimento </title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="ModalCadastro.js" type="text/javascript"></script>
</head>
<body>
    <form id="modalCadastro" runat="server">
        <div>
            <div id="modalAquecimento" class="">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="modal-dialog">
                    <div class="modal-content">
                        <h4 class="modal-title">Cadastro de Pre Aquecimento</h4>
                        Nome *:
                        <br />
                        <asp:TextBox ID="NomeDTO" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="NomeDTO" ErrorMessage="O nome é obrigatório!" runat="server" />
                        <br />
                        <br />
                        Alimento *:
                        <br />
                        <asp:TextBox ID="AlimentoDTO" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="AlimentoDTO" ErrorMessage="O Alimento é obrigatório!" runat="server" />
                        <br />
                        <br />
                        Tempo *:
                        <br />
                        <asp:TextBox ID="TempoDTO" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="TempoDTO" ErrorMessage="O tempo é obrigatório!" runat="server" />
                        <br />
                        <br />
                        Potencia *:
                        <br />
                        <asp:TextBox ID="PotenciaDTO" value="10" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="PotenciaDTO" ErrorMessage="A potencia é obrigatório!" runat="server" />
                        <br />
                        <br />
                        Instrução:
                        <br />
                        <asp:TextBox ID="InstrucaoDTO" runat="server" Width="150px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnAdicionarPreAquecimento" runat="server" Text="Adicionar" OnClick="AdicionarNovoItemPreAquecimento" />
                        <asp:Button ID="btnFecharModalCadastroPreAquecimento" runat="server" Text="Fechar" OnClick="RetonarAquecimento" CausesValidation="false" />

                    </div>
                </div>
            </div>
    </form>
</body>
</html>
