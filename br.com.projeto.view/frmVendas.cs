using Projeto_Controle_Vendas.br.com.projeto.dao;
using Projeto_Controle_Vendas.br.com.projeto.model;
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
    public partial class frmVendas : Form
    {   
        //Objetos cliente e clienteDAO
        Cliente cliente = new Cliente();
        ClienteDAO clienteDao = new ClienteDAO();

        //Objetos produto e produtoDAO
        Produto produto = new Produto();
        ProdutoDAO produtoDAO = new ProdutoDAO();

        //variaveis
        int qtd;
        decimal preco;
        decimal subtotal, total;

        //carrinho
        DataTable carrinho = new DataTable();

        public frmVendas()
        {
            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Quantidade", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tbgProdutos.DataSource = carrinho;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                qtd = int.Parse(txtQtd.Text);
                preco = decimal.Parse(txtPreco.Text);

                subtotal = qtd * preco;
                total += subtotal;

                //adiciona ao carrinho
                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDesc.Text, qtd, preco, subtotal);

                txtTotal.Text = total.ToString();

                //limpar campos
                txtCodigo.Clear();
                txtDesc.Clear();
                txtQtd.Clear();
                txtPreco.Clear();

                txtCodigo.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Digite o código do produto!");
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            decimal subproduto = decimal.Parse(tbgProdutos.CurrentRow.Cells[4].Value.ToString());
            int indice = tbgProdutos.CurrentRow.Index;

            DataRow linha = carrinho.Rows[indice];
            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= subproduto;
            txtTotal.Text = total.ToString();

            MessageBox.Show("Item removido do carrinho!");
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cliente = clienteDao.ClientePeloCpf(mskCpf.Text);

                if (cliente != null)
                {
                    txtNome.Text = cliente.nome;
                }
                else
                {
                    mskCpf.Clear();
                    mskCpf.Focus();
                }
                
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                produto = produtoDAO.ProdutoPeloId(int.Parse(txtCodigo.Text));
                if(produto!=null)
                {
                    txtDesc.Text = produto.descricao;
                    txtPreco.Text = produto.preco.ToString();
                }
                else
                {
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
            }
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            //botao pagamento
            DateTime dataatual = DateTime.Parse(txtData.Text);
            frmPagamentos tela = new frmPagamentos(cliente, carrinho, dataatual);

            //passando o total para a tela de pagamentos
            tela.txtTotal.Text = total.ToString();
            tela.ShowDialog();

        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            //pegando a data atual
            txtData.Text = DateTime.Now.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
