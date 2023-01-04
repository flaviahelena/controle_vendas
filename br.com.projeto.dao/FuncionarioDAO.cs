using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.br.com.projeto.conexao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using Projeto_Controle_Vendas.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.dao
{
    public class FuncionarioDAO
    {
        private MySqlConnection conexao;
        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarFuncionario
        //Metodo para cadastrar cliente
        public void cadastrarFuncionario(Funcionario obj)
        {
            try
            {
                //definir o cmd SQL - insert
                string strCmd = @"insert into tb_funcionarios (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado,senha,nivel_acesso,cargo)
                            values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado, @senha, @nivel_acesso, @cargo)";

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
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario cadastrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ExcluirFuncionario
        //Metodo para excluir cliente
        public void ExcluirFuncionario(Funcionario obj)
        {
            try
            {
                //definir o cmd SQL - insert
                string strCmd = @"delete from tb_funcionarios where id=@id";

                //organizar o cmd SQL
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario excluído com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region EditarFuncionario
        //Metodo para alterar cliente
        public void EditarFuncionario(Funcionario obj)
        {
            try
            {
                //definir o cmd SQL - update

                string strCmd = @"update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,
                                celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,
                                bairro=@bairro,cidade=@cidade,estado=@estado,senha=@senha,nivel_acesso=@nivel_acesso,cargo=@cargo
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
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario aletrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ListarFuncionarios
        //Metodo para listar clientes
        public DataTable ListarFuncionarios()
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFuncionario = new DataTable();
                string strCmd = "select * from tb_funcionarios";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                conexao.Close();
                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }


        #endregion

        #region BuscarFuncionarioPeloNome
        //Metodo para listar clientes
        public DataTable BuscarFuncionarioPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFuncionario = new DataTable();
                string strCmd = "select * from tb_funcionarios where nome=@nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                conexao.Close();
                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ListarFuncionarioPeloNome
        //Metodo para listar clientes
        public DataTable ListarFuncionarioPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaFuncionario = new DataTable();
                string strCmd = "select * from tb_funcionarios where nome like @nome";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                conexao.Close();
                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region EfetuarLogin
        public Boolean EfetuarLogin(string email, string senha)
        {
            try
            {
                //comando SQL
                string strCmd = "select * from tb_funcionarios " +
                                "where email = @email and senha = @senha";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("email", email);
                executacmd.Parameters.AddWithValue("senha", senha);

                conexao.Open();
                MySqlDataReader rd = executacmd.ExecuteReader();

                if(rd.Read())
                {
                    //login realizado com sucesso
                    string nivel = rd.GetString("nivel_acesso");
                    string nome = rd.GetString("nome");

                    MessageBox.Show("Login realizado com sucesso!");
                    frmMenu telaMenu = new frmMenu();

                    telaMenu.txtUsuario.Text = nome;

                    if (nivel.Equals("Administrador"))
                    {
                        telaMenu.Show();
                    }
                    else if (nivel.Equals("Vendedor"))
                    {   

                        
                        //telaMenu.menuProdutos.Enabled= false;
                        telaMenu.Show();
                    }
                    
                    conexao.Close();
                    return true;
                }
                else
                {
                    //dados de entrada inválido
                    MessageBox.Show("Email ou senha incorretos!");
                    return false;
                }


                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu um erro: " + erro);
                return false;
            }
        }
        #endregion
    }
}
