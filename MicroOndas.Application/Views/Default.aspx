<%@ Page EnableViewState="true" Title="MicroOndas" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MicroOndas.Application.Default" %>

<!DOCTYPE html>
<head runat="server">
    <title>Micro Ondas</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Default.js"></script>
     <style src="Default.css"></style>
</head>
<body>
    <form id="MICROONDAS" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>          
            <div id="painelMicroOndas">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" class="">
                    <ContentTemplate>
                        Tempo:
                    <br />
                        <asp:TextBox ID="Tempo" runat="server" Width="75px"></asp:TextBox>
                        <br />
                        <br />

                        Potência:
                    <br />
                        <asp:TextBox ID="Potencia" value="10" runat="server" Width="75px"></asp:TextBox>
                        <br />
                        <br />

                        Pre-Aquecimento:
                    <br />
                        <asp:DropDownList ID="ProgramasPreAquecimento" CssClass="italic-text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PreAquecimentoChanged"></asp:DropDownList>
                        <asp:ListItem Text="Selecione uma opção" Value=""></asp:ListItem>
                        <br />
                        <br />

                        <asp:Label ID="labelTimer" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="labelOut" runat="server"></asp:Label>
                        <br />
                        <br />
                        <div style="display: flex;">
                            <asp:Button ID="btnAquecimento" runat="server" Text="Aquecimento" OnClick="Aquecimento" Style="margin-right: 21px;" />
                            <asp:Button ID="btnPausarCancelar" runat="server" Text="Pausar/Cancelar" OnClick="PausarCancelar" />
                            <asp:Button ID="btnAbrirModal" runat="server" Text="Adicionar Item de Pre aquecimento" OnClick="AbrirModal" />
                        </div>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="false"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </form>
</body>
</html>
