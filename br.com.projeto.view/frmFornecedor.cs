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
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Funcionario
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.bairro = txtBairro.Text;
            obj.celular = mskCelular.Text;
            obj.cep = mskCep.Text;
            obj.cidade = txtCidade.Text;
            obj.complemento = txtComplemento.Text;
            obj.cnpj = mskCnpj.Text;
            obj.email = txtEmail.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNum.Text);
            obj.telefone = mskTelefone.Text;
            obj.uf = cbUf.Text;


            //cria um objeto da classe FuncionarioDAO e chama o metodo cadastrarFuncionario
            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(obj);
            tbgFornecedor.DataSource = dao.ListarFornecedor();

            new Helpers().LimparTela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Fornecedor obj = new Fornecedor();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();
            dao.ExcluirFornecedor(obj);
            tbgFornecedor.DataSource = dao.ListarFornecedor();

            new Helpers().LimparTela(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Funcionario
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.bairro = txtBairro.Text;
            obj.celular = mskCelular.Text;
            obj.cep = mskCep.Text;
            obj.cidade = txtCidade.Text;
            obj.codigo = int.Parse(txtCodigo.Text);
            obj.complemento = txtComplemento.Text;
            obj.cnpj = mskCnpj.Text;
            obj.email = txtEmail.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNum.Text);
            obj.telefone = mskTelefone.Text;
            obj.uf = cbUf.Text;


            //cria um objeto da classe FuncionarioDAO e chama o metodo EditarFuncionario
            FornecedorDAO dao = new FornecedorDAO();
            dao.EditarFornecedor(obj);
            tbgFornecedor.DataSource = dao.ListarFornecedor();

            new Helpers().LimparTela(this);
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            tbgFornecedor.DefaultCellStyle.ForeColor = Color.Black;

            FornecedorDAO dao = new FornecedorDAO();
            tbgFornecedor.DataSource = dao.ListarFornecedor();
        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            //Botao consultar CEP
            try
            {
                string cep = mskCep.Text;
                DataSet dados = new DataSet();
                string xml = "http://viacep.com.br/ws/" + cep + "/xml/";

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbUf.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Cep não encontrado! Digite manualmente");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeConsulta.Text;
            FornecedorDAO dao = new FornecedorDAO();
            tbgFornecedor.DataSource = dao.BuscarFornecedorPeloNome(nome);

            if (tbgFornecedor.Rows.Count == 0)
            {
                tbgFornecedor.DataSource = dao.ListarFornecedor();
            }
        }

        private void txtNomeConsulta_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtNomeConsulta.Text + "%";

            FornecedorDAO dao = new FornecedorDAO();
            tbgFornecedor.DataSource = dao.ListarFornecedorPeloNome(nome);
        }

        private void tbgFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtCodigo.Text = tbgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tbgFornecedor.CurrentRow.Cells[1].Value.ToString();
            mskCnpj.Text = tbgFornecedor.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tbgFornecedor.CurrentRow.Cells[3].Value.ToString();
            mskTelefone.Text = tbgFornecedor.CurrentRow.Cells[4].Value.ToString();
            mskCelular.Text = tbgFornecedor.CurrentRow.Cells[5].Value.ToString();
            mskCep.Text = tbgFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tbgFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNum.Text = tbgFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tbgFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tbgFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tbgFornecedor.CurrentRow.Cells[11].Value.ToString();
            cbUf.Text = tbgFornecedor.CurrentRow.Cells[12].Value.ToString();

            //Alterar para a guia de Dados Pessoais
            tabFornecedor.SelectedTab = pageDados;
        }
    }
}
