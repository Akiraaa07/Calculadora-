using System;
using System.Windows.Forms;

namespace Cp01___Calculadora
{
    public partial class Form1 : Form
    {
        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }

        private Operacao OperacaoSelecionada { get; set; }

        private enum Operacao
        {
            Nenhuma,
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao
        }

        public Form1()
        {
            InitializeComponent();
            OperacaoSelecionada = Operacao.Nenhuma;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Adicao;
            Valor = Convert.ToDecimal(txtResultado.Text);
            txtResultado.Text = "";
            label1.Text = "+";
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Subtracao;
            Valor = Convert.ToDecimal(txtResultado.Text);
            txtResultado.Text = "";
            label1.Text = "-";
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Multiplicacao;
            Valor = Convert.ToDecimal(txtResultado.Text);
            txtResultado.Text = "";
            label1.Text = "X";
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Divisao;
            Valor = Convert.ToDecimal(txtResultado.Text);
            txtResultado.Text = "";
            label1.Text = "/";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valorAtual = Convert.ToDecimal(txtResultado.Text);

                switch (OperacaoSelecionada)
                {
                    case Operacao.Adicao:
                        Resultado = Valor + valorAtual;
                        break;

                    case Operacao.Subtracao:
                        Resultado = Valor - valorAtual;
                        break;

                    case Operacao.Divisao:
                        if (valorAtual == 0)
                        {
                            MessageBox.Show("Erro: Divisão por zero não é permitida.");
                            return;
                        }
                        Resultado = Valor / valorAtual;
                        break;

                    case Operacao.Multiplicacao:
                        Resultado = Valor * valorAtual;
                        break;

                    case Operacao.Nenhuma:
                        MessageBox.Show("Nenhuma operação foi selecionada.");
                        return;
                }

                txtResultado.Text = Resultado.ToString();
                label1.Text = "=";
            }
            catch (FormatException)
            {
                MessageBox.Show("Entrada inválida. Por favor, insira um número válido.");
            }
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (!txtResultado.Text.Contains(separator))
                txtResultado.Text += separator;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            label1.Text = "";
            Valor = 0;
            Resultado = 0;
            OperacaoSelecionada = Operacao.Nenhuma;
        }
    }
}
