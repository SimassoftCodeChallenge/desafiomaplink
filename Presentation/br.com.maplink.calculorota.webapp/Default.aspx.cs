using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using br.com.maplink.calculorota.common.integration;
using br.com.maplink.calculorota.common.integration.CalculoRota;

namespace br.com.maplink.calculorota.webapp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularDados();
            }
        }

        private void PopularDados()
        {
            string[] ufs =
                {
                    "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
                    "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
                };

            foreach (var s in ufs)
            {
                ddlOrigemEstado.Items.Add(s);
                ddlDestinoEstado.Items.Add(s);
            }

            //Só pra testes...
            ddlOrigemEstado.SelectedValue = "ES";
            ddlDestinoEstado.SelectedValue = "SP";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                CalculoRotaWrapper cw = new CalculoRotaWrapper();

                var l = new List<DadosEntrada>();
                l.Add(new DadosEntrada { Cep = txtOrigemCep.Text, Cidade = txtOrigemCidade.Text, Estado = ddlOrigemEstado.Text, Numero = txtOrigemNumero.Text, Rua = txtOrigemRua.Text });
                l.Add(new DadosEntrada { Cep = txtDestinoCep.Text, Cidade = txtDestinoCidade.Text, Estado = ddlDestinoEstado.Text, Numero = txtDestinoNumero.Text, Rua = txtDestinoRua.Text });

                ResultadoCalculo r = ddlTipoCalculo.SelectedValue == "0" ? cw.CalcularRotaMaisRapida(l) : cw.CalcularRotaEvitandoTransito(l);

                pnlResultado.Visible = true;
                lblCustoTotalCombustivel.Text = r.CustoTotalCombustivel.ToString(CultureInfo.InvariantCulture);
                lblCustoTotalPedagio.Text = r.CustoTotalPedagio.ToString(CultureInfo.InvariantCulture);
                lblDistanciaTotal.Text = r.DistanciaTotalRota.ToString(CultureInfo.InvariantCulture);
                lblTempoTotalRota.Text = r.TempoTotalRota.ToString();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}
