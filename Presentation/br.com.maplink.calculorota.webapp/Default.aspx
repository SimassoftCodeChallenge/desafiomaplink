<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="br.com.maplink.calculorota.webapp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">

        function buscarDadosViaRest() {

            var dadosOrigem = '29122100,ES,Vila Velha,Mestre Gomes,613';
            var dadosDestino = '04052030,SP,Sao Paulo,Orissanga,14';

            $.ajax({
                type: 'get',
                url: 'http://localhost:2986/CalculoRotaRest.svc/RotaMaisCurta/?dadosOrigem=' + dadosOrigem + '&dadosDestino=' + dadosDestino,
                async: false,
                success: function (e) { alert('Success' + e.toString() + JSON.stringify(e)); },
                error: function (e) { alert('Error ' + JSON.stringify(e)); }
            });

        }

        $.ready = function () {

            // implement JSON.stringify serialization
            JSON.stringify = JSON.stringify || function (obj) {
                var t = typeof (obj);
                if (t != "object" || obj === null) {
                    // simple data type
                    if (t == "string") obj = '"' + obj + '"';
                    return String(obj);
                }
                else {
                    // recurse array or object
                    var n, v, json = [], arr = (obj && obj.constructor == Array);
                    for (n in obj) {
                        v = obj[n]; t = typeof (v);
                        if (t == "string") v = '"' + v + '"';
                        else if (t == "object" && v !== null) v = JSON.stringify(v);
                        json.push((arr ? "" : '"' + n + '":') + String(v));
                    }
                    return (arr ? "[" : "{") + String(json) + (arr ? "]" : "}");
                }
            };

        };

    </script>
    <h2>
        Calculo de Rota
    </h2>
    <p>
        Calcular a rota desejada:
    </p>
    <div style="width: 100%; float: left;">
        <div style="width: 48%; float: left; border: solid 1px;">
            <fieldset>
                <h3>
                    Origem</h3>
                <table style="width: 100%;">
                    <tr>
                        <td class="style1">
                            Estado:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrigemEstado" runat="server" Height="16px" Width="116px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOrigemEstado"
                                ErrorMessage="Estado é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Cidade:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigemCidade" runat="server">Vila Velha</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrigemCidade"
                                ErrorMessage="Cidade é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Bairro:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigemBairro" runat="server">Gloria</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOrigemBairro"
                                ErrorMessage="Bairro é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Rua:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigemRua" runat="server">Mestre Gomes</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDestinoRua"
                                ErrorMessage="Rua é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Numero:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigemNumero" runat="server">613</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOrigemNumero"
                                ErrorMessage="Número é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Cep:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigemCep" runat="server">29122100</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOrigemCep"
                                ErrorMessage="Cep é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <!-- DESTINO -->
        <div style="width: 48%; float: left; border: solid 1px;">
            <fieldset>
                <h3>
                    Destino:
                </h3>
                <table style="width: 100%;">
                    <tr>
                        <td class="style1">
                            Estado:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDestinoEstado" runat="server" Height="16px" Width="116px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDestinoEstado"
                                ErrorMessage="Estado é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Cidade:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDestinoCidade" runat="server">São Paulo</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDestinoCidade"
                                ErrorMessage="Cidade é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Bairro:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDestinoBairro" runat="server">Mirandopolis</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDestinoBairro"
                                ErrorMessage="Bairro é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Rua:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDestinoRua" runat="server">Orissanga</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDestinoRua"
                                ErrorMessage="Rua é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Numero:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDestinoNumero" runat="server">14</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDestinoNumero"
                                ErrorMessage="Número é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Cep:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDestinoCep" runat="server">04052030</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDestinoCep"
                                ErrorMessage="Cep é obrigatório!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <br />
        <div style="width: 100%; text-align: center;">
            <asp:DropDownList ID="ddlTipoCalculo" runat="server" Height="16px" Width="116px">
                <asp:ListItem Value="0">Rota Mais Curta</asp:ListItem>
                <asp:ListItem Value="1">Rota Evitando Trânsito</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar Dados via WS" OnClick="btnConsultar_Click" />
            &nbsp;&nbsp;
            <button type="button" onclick="buscarDadosViaRest();" value="Consultar via Rest">
                Consultar via Rest</button>
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                <fieldset>
                    <h3>
                        Resultado:
                    </h3>
                    <table>
                        <tr>
                            <td>
                                Tempo Total da Rota:
                            </td>
                            <td>
                                <asp:Label ID="lblTempoTotalRota" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Distância Total:
                            </td>
                            <td>
                                <asp:Label ID="lblDistanciaTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Custo Total com Combustível:
                            </td>
                            <td>
                                <asp:Label ID="lblCustoTotalCombustivel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Custo Total com Pedágio:
                            </td>
                            <td>
                                <asp:Label ID="lblCustoTotalPedagio" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <div id="resultadoRest">
            </div>
        </div>
    </div>
</asp:Content>
