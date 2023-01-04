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
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Funcionario
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.bairro = txtBairro.Text;
            obj.celular = mskCelular.Text;
            obj.cep = mskCep.Text;
            obj.cidade = txtCidade.Text;
            obj.nivel_acesso = cbNivel.Text;
            obj.complemento = txtComplemento.Text;
            obj.cpf = mskCpf.Text;
            obj.email = txtEmail.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNum.Text);
            obj.rg = mskRG.Text;
            obj.telefone = mskTelefone.Text;
            obj.uf = cbUf.Text;
            obj.senha = txtSenha.Text;
            obj.cargo = cbCargo.Text;

            //cria um objeto da classe FuncionarioDAO e chama o metodo cadastrarFuncionario
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(obj);
            tbgFuncionario.DataSource = dao.ListarFuncionarios();

            new Helpers().LimparTela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Funcionario obj = new Funcionario();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.ExcluirFuncionario(obj);
            tbgFuncionario.DataSource = dao.ListarFuncionarios();

            new Helpers().LimparTela(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Funcionario
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.bairro = txtBairro.Text;
            obj.celular = mskCelular.Text;
            obj.cep = mskCep.Text;
            obj.cidade = txtCidade.Text;
            obj.codigo = int.Parse(txtCodigo.Text);
            obj.complemento = txtComplemento.Text;
            obj.cpf = mskCpf.Text;
            obj.email = txtEmail.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNum.Text);
            obj.rg = mskRG.Text;
            obj.telefone = mskTelefone.Text;
            obj.uf = cbUf.Text;
            obj.senha = txtSenha.Text;
            obj.nivel_acesso = cbNivel.Text;
            obj.cargo = cbCargo.Text;

            //cria um objeto da classe FuncionarioDAO e chama o metodo EditarFuncionario
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.EditarFuncionario(obj);
            tbgFuncionario.DataSource = dao.ListarFuncionarios();

            new Helpers().LimparTela(this);
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            tbgFuncionario.DefaultCellStyle.ForeColor = Color.Black;

            FuncionarioDAO dao = new FuncionarioDAO();
            tbgFuncionario.DataSource = dao.ListarFuncionarios();
        }

        private void tbgFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtCodigo.Text = tbgFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tbgFuncionario.CurrentRow.Cells[1].Value.ToString();
            mskRG.Text = tbgFuncionario.CurrentRow.Cells[2].Value.ToString();
            mskCpf.Text = tbgFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tbgFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tbgFuncionario.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = tbgFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbNivel.Text = tbgFuncionario.CurrentRow.Cells[7].Value.ToString();
            mskTelefone.Text = tbgFuncionario.CurrentRow.Cells[8].Value.ToString();
            mskCelular.Text = tbgFuncionario.CurrentRow.Cells[9].Value.ToString();
            mskCep.Text = tbgFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tbgFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtNum.Text = tbgFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tbgFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tbgFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tbgFuncionario.CurrentRow.Cells[15].Value.ToString();
            cbUf.Text = tbgFuncionario.CurrentRow.Cells[16].Value.ToString();

            //Alterar para a guia de Dados Pessoais
            tabFuncionarios.SelectedTab = pageDados;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeConsulta.Text;
            FuncionarioDAO dao = new FuncionarioDAO();
            tbgFuncionario.DataSource = dao.BuscarFuncionarioPeloNome(nome);

            if (tbgFuncionario.Rows.Count == 0)
            {
                tbgFuncionario.DataSource = dao.ListarFuncionarios();
            }
        }

        private void txtNomeConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtNomeConsulta.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            tbgFuncionario.DataSource = dao.ListarFuncionarioPeloNome(nome);
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
    }
}
