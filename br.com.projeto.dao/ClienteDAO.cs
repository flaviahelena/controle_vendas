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
    public class ClienteDAO
    {
        private MySqlConnection conexao;
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarCliente
        //Metodo para cadastrar cliente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                //definir o cmd SQL - insert
   
                string strCmd = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                            values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente cadastrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ExcluirCliente
        //Metodo para excluir cliente
        public void ExcluirCliente(Cliente obj)
        {
            try
            {
                //definir o cmd SQL - delete

                string strCmd = @"delete from tb_clientes where id=@id";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
              
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region EditarCliente
        //Metodo para alterar cliente
        public void EditarCliente(Cliente obj)
        {
            try
            {
                //definir o cmd SQL - update

                string strCmd = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,
                                celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,
                                bairro=@bairro,cidade=@cidade,estado=@estado
                                where id=@id";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente aletrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ListarClientes
        //Metodo para listar clientes
        public DataTable listarClientes()
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaCliente = new DataTable();
                string strCmd = "select * from tb_clientes";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                conexao.Close();
                return tabelaCliente;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }


        #endregion

        #region BuscarClientePeloNome
        //Metodo para listar clientes
        public DataTable BuscarClienteNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaCliente = new DataTable();
                string strCmd = "select * from tb_clientes where nome=@nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                conexao.Close();
                return tabelaCliente;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ListarClientePeloNome
        //Metodo para listar clientes
        public DataTable ListarClientePeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaCliente = new DataTable();
                string strCmd = "select * from tb_clientes where nome like @nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                conexao.Close();
                return tabelaCliente;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ClientePeloCPF
        public Cliente ClientePeloCpf(string cpf)
        {
            try
            {
                //comando SQL e o objeto Cliente
                Cliente obj = new Cliente();
                string strCmd = @"select * from tb_clientes where cpf=@cpf";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@cpf", cpf);

                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if(rs.Read())
                {
                    obj.codigo = rs.GetInt32("id");
                    obj.nome = rs.GetString("nome");

                    conexao.Close();
                    return obj;

                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!");
                    conexao.Close();
                    return null;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }

        }
        #endregion
    }
}
