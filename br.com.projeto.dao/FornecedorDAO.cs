using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.br.com.projeto.conexao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.dao
{
    public class FornecedorDAO
    {
        private MySqlConnection conexao;
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarFornecedor
        //Metodo para cadastrar cliente
        public void CadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                //definir o cmd SQL - insert

                string strCmd = @"insert into tb_fornecedores (nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                            values(@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.uf);

                //abrir conexao e executar o cmd

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ExcluirFornecedor
        //Metodo para excluir fornecedor
        public void ExcluirFornecedor(Fornecedor obj)
        {
            try
            {
                //definir o cmd SQL - insert

                string strCmd = @"delete from tb_fornecedores where id=@id";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluído com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region EditarFornecedor
        //Metodo para alterar fornecedor
        public void EditarFornecedor(Fornecedor obj)
        {
            try
            {
                //definir o cmd SQL - update

                string strCmd = @"update tb_fornecedores set nome=@nome,cnpj=@cnpj,email=@email,telefone=@telefone,
                                celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,
                                bairro=@bairro,cidade=@cidade,estado=@estado
                                where id=@id";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.uf);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor aletrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ListarFornecedor
        //Metodo para listar clientes
        public DataTable ListarFornecedor()
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFornecedor = new DataTable();
                string strCmd = "select * from tb_fornecedores";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                conexao.Close();
                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }


        #endregion

        #region BuscarFornecedorPeloNome
        //Metodo para listar clientes
        public DataTable BuscarFornecedorPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFornecedor = new DataTable();
                string strCmd = "select * from tb_fornecedores where nome=@nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                conexao.Close();
                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ListarFornecedorPeloNome
        //Metodo para listar clientes
        public DataTable ListarFornecedorPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFornecedor = new DataTable();
                string strCmd = "select * from tb_fornecedores where nome like @nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                conexao.Close();
                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion
    }
}
