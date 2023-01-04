using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.view
{
    public partial class frmMenu : Form
    {
        //frmClientes telacliente = new frmClientes();
        public frmMenu()
        {
            InitializeComponent();
        }

        private void menuFuncionarios_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            string dataAtual = DateTime.Now.ToShortDateString();
            txtData.Text = dataAtual;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void menuCadastroCliente_Click(object sender, EventArgs e)
        {
            //abrir tela de cliente
            frmClientes telacliente = new frmClientes();
            telacliente.ShowDialog();

        }

        private void menuConsultaCliente_Click(object sender, EventArgs e)
        {
            frmClientes telacliente = new frmClientes();
            telacliente.tabClientes.SelectedTab = telacliente.pageConsulta;
            telacliente.ShowDialog();
        }

        private void menuCadastroFunc_Click(object sender, EventArgs e)
        {
            frmFuncionarios tela = new frmFuncionarios();
            tela.ShowDialog();
        }

        private void menuConsultaFunc_Click(object sender, EventArgs e)
        {
            frmFuncionarios tela = new frmFuncionarios();
            tela.tabFuncionarios.SelectedTab = tela.pageConsulta;
            tela.ShowDialog();
            
        }

        private void menuCadastroForn_Click(object sender, EventArgs e)
        {
            frmFornecedor tela = new frmFornecedor();
            tela.ShowDialog();
        }

        private void menuConsultaForn_Click(object sender, EventArgs e)
        {
            frmFornecedor tela = new frmFornecedor();
            tela.tabFornecedor.SelectedTab = tela.pageConsulta;
            tela.ShowDialog();
        }

        private void menuCadastroProd_Click(object sender, EventArgs e)
        {
            frmProdutos tela = new frmProdutos();
            tela.ShowDialog();
        }

        private void menuConsultaProd_Click(object sender, EventArgs e)
        {
            frmProdutos tela = new frmProdutos();
            tela.tabProduto.SelectedTab = tela.pageConsulta;
            tela.ShowDialog();
        }

        private void menuNovaVenda_Click(object sender, EventArgs e)
        {
            frmVendas tela = new frmVendas();
            tela.ShowDialog();
        }

        private void menuHistVendas_Click(object sender, EventArgs e)
        {
            frmHistorico tela = new frmHistorico();
            tela.ShowDialog();
        }

        private void menuTrocaUsuario_Click(object sender, EventArgs e)
        {   
            frmLogin tela = new frmLogin(); 
            tela.ShowDialog();
            this.Hide();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair do sistema?","ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
