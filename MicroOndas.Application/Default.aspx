<%@ Page EnableViewState="true" Title="MicroOndas" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MicroOndas.Application.Default" %>

<!DOCTYPE html>
<head runat="server">
    <title>Micro Ondas</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Default.js"></script>
</head>
<body>
    <form id="MICROONDAS" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    Tempo:
                    <asp:TextBox ID="Tempo" runat="server" Width="65px"></asp:TextBox> 
                    <br /><br />

                    Potência:
                    <asp:TextBox ID="Potencia" value="10" runat="server" Width="50px"></asp:TextBox>
                    <br /><br />

                    Tempo:
                    <asp:Label ID="labelOut" runat="server"></asp:Label> <br /><br />
                    <div style="display: flex;">
                    <asp:Button ID="btnAquecimento" runat="server" Text="Aquecimento" OnClick="Aquecimento" style="margin-right: 21px;"/>
                    <asp:Button ID="btnPausarCancelar" runat="server" Text="Pausar/Cancelar" OnClick="PausarCancelar" />
                    </div>                    
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="false"></asp:Timer>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>

</html>
