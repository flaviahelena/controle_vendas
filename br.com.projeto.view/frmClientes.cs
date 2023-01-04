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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Cliente
            Cliente obj = new Cliente();
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

            //cria um objeto da classe ClienteDAO e chama o metodo EditarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.EditarCliente(obj);
            tbgCliente.DataSource = dao.listarClientes();

            new Helpers().LimparTela(this);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            tbgCliente.DefaultCellStyle.ForeColor = Color.Black;

            ClienteDAO dao = new ClienteDAO();
            tbgCliente.DataSource = dao.listarClientes();

        }

        private void tbgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtCodigo.Text = tbgCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tbgCliente.CurrentRow.Cells[1].Value.ToString();
            mskRG.Text = tbgCliente.CurrentRow.Cells[2].Value.ToString();
            mskCpf.Text = tbgCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tbgCliente.CurrentRow.Cells[4].Value.ToString();
            mskTelefone.Text = tbgCliente.CurrentRow.Cells[5].Value.ToString();
            mskCelular.Text = tbgCliente.CurrentRow.Cells[6].Value.ToString();
            mskCep.Text = tbgCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tbgCliente.CurrentRow.Cells[8].Value.ToString();
            txtNum.Text = tbgCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tbgCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tbgCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tbgCliente.CurrentRow.Cells[12].Value.ToString();
            cbUf.Text = tbgCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a guia de Dados Pessoais
            tabClientes.SelectedTab = pageDados;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeConsulta.Text;
            ClienteDAO dao = new ClienteDAO();
            tbgCliente.DataSource = dao.BuscarClienteNome(nome);

            if(tbgCliente.Rows.Count == 0)
            {
                tbgCliente.DataSource = dao.listarClientes();
            }

        }

        private void txtNomeConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtNomeConsulta.Text + "%";

            ClienteDAO dao = new ClienteDAO();
            tbgCliente.DataSource = dao.ListarClientePeloNome(nome);


        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            //Botao consultar CEP
            try
            {
                string cep = mskCep.Text;
                DataSet dados = new DataSet();
                string xml = "http://viacep.com.br/ws/" +cep+ "/xml/";

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Cliente obj = new Cliente();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.ExcluirCliente(obj);
            tbgCliente.DataSource = dao.listarClientes();

            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            //recebe os dados dentro do objeto Cliente
            Cliente obj = new Cliente();
            obj.nome = txtNome.Text;
            obj.bairro = txtBairro.Text;
            obj.celular = mskCelular.Text;
            obj.cep = mskCep.Text;
            obj.cidade = txtCidade.Text;
            //obj.codigo = int.Parse(txtCodigo.Text);
            obj.complemento = txtComplemento.Text;
            obj.cpf = mskCpf.Text;
            obj.email = txtEmail.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNum.Text);
            obj.rg = mskRG.Text;
            obj.telefone = mskTelefone.Text;
            obj.uf = cbUf.Text;

            //cria um objeto da classe ClienteDAO e chama o metodo cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
            tbgCliente.DataSource = dao.listarClientes();

            new Helpers().LimparTela(this);
        }
    }
}
