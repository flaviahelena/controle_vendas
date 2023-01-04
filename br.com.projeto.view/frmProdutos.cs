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
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();

            cbFornecedor.DataSource = f_dao.ListarFornecedor();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";

            ProdutoDAO p_dao = new ProdutoDAO();
            tbgProduto.DataSource = p_dao.ListarProduto();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Produto
            Produto obj = new Produto();
            obj.descricao = txtDesc.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.quantidade = int.Parse(txtQtd.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());

            //cria um objeto da classe FuncionarioDAO e chama o metodo CadastrarProduto
            ProdutoDAO dao = new ProdutoDAO();
            dao.CadastrarProduto(obj);
            tbgProduto.DataSource = dao.ListarProduto();

            new Helpers().LimparTela(this);
        }

        private void pageDados_Click(object sender, EventArgs e)
        {

        }

        private void tbgProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtCodigo.Text = tbgProduto.CurrentRow.Cells[0].Value.ToString();
            txtDesc.Text = tbgProduto.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = tbgProduto.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = tbgProduto.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = tbgProduto.CurrentRow.Cells[4].Value.ToString();

            //Alterar para a guia de Dados Pessoais
            tabProduto.SelectedTab = pageDados;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Cliente
            Produto obj = new Produto();
            obj.descricao = txtDesc.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.quantidade = int.Parse(txtQtd.Text);
            obj.codigo = int.Parse(txtCodigo.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());

            //cria um objeto da classe ClienteDAO e chama o metodo EditarCliente
            ProdutoDAO dao = new ProdutoDAO();
            dao.EditarProduto(obj);
            tbgProduto.DataSource = dao.ListarProduto();

            new Helpers().LimparTela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Produto obj = new Produto();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.ExcluirProduto(obj);
            tbgProduto.DataSource = dao.ListarProduto();

            new Helpers().LimparTela(this);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtDescricaoConsulta.Text;
            ProdutoDAO dao = new ProdutoDAO();
            tbgProduto.DataSource = dao.BuscarProdutoPeloNome(nome);

            if (tbgProduto.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado com esse nome!");
                tbgProduto.DataSource = dao.ListarProduto();
            }
        }

        private void txtDescricaoConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtDescricaoConsulta.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();
            tbgProduto.DataSource = dao.ListarProdutoPeloNome(nome);
        }
    }
}
