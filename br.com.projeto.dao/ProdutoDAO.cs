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
    public class ProdutoDAO
    {
        private MySqlConnection conexao;
        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarProduto
        //Metodo para cadastrar produto
        public void CadastrarProduto(Produto obj)
        {
            try
            {
                //definir o cmd SQL - insert
                string strCmd = @"insert into tb_produtos (descricao,preco,qtd_estoque,for_id)
                            values(@descricao, @preco, @qtd_estoque,@for_id)";

                //organizar o cmd SQL
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd_estoque", obj.quantidade);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);


                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ExcluirProduto
        //Metodo para excluir produto
        public void ExcluirProduto(Produto obj)
        {
            try
            {
                //definir o cmd SQL - delete

                string strCmd = @"delete from tb_produtos where id=@id";

                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto excluído com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region EditarProduto
        //Metodo para alterar fornecedor
        public void EditarProduto(Produto obj)
        {
            try
            {
                //definir o cmd SQL - update

                string strCmd = @"update tb_produtos set descricao=@descricao,preco=@preco,qtd_estoque=@qtd_estoque,
                                for_id=@for_id where id=@id";


                //organizar o cmd SQL

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd_estoque", obj.quantidade);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto aletrado com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
            }
        }
        #endregion

        #region ListarProduto
        //Metodo para listar clientes
        public DataTable ListarProduto()
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaProduto = new DataTable();
                string strCmd = @"select 
                                  tb_produtos.id as 'Código',
                                  tb_produtos.descricao as 'Descrição',
                                  tb_produtos.preco as 'Preço',
                                  tb_produtos.qtd_estoque as 'Qtd. Estoque',
                                  tb_fornecedores.nome as 'Fornecedor'
                                  from tb_produtos join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id);";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                conexao.Close();
                return tabelaProduto;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }


        #endregion

        #region BuscarProdutoPeloNome
        //Metodo para listar clientes
        public DataTable BuscarProdutoPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaProduto = new DataTable();
                string strCmd = @"select 
                                  tb_produtos.id as 'Código',
                                  tb_produtos.descricao as 'Descrição',
                                  tb_produtos.preco as 'Preço',
                                  tb_produtos.qtd_estoque as 'Qtd. Estoque',
                                  tb_fornecedores.nome as 'Fornecedor'
                                  from tb_produtos join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id)
                                  where tb_produtos.descricao = @nome;";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                conexao.Close();
                return tabelaProduto;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ListarProdutoPeloNome
        //Metodo para listar clientes
        public DataTable ListarProdutoPeloNome(string nome)
        {
            try
            {

                // Criar DataTable e o cmd
                DataTable tabelaProduto = new DataTable();
                string strCmd = @"select 
                                  tb_produtos.id as 'Código',
                                  tb_produtos.descricao as 'Descrição',
                                  tb_produtos.preco as 'Preço',
                                  tb_produtos.qtd_estoque as 'Qtd. Estoque',
                                  tb_fornecedores.nome as 'Fornecedor'
                                  from tb_produtos join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id)
                                  where tb_produtos.descricao like @nome;";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MySqlDataApter para preecher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                conexao.Close();
                return tabelaProduto;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando de busca: " + erro);
                return null;
            }
        }
        #endregion

        #region ProdutoPeloId
        public Produto ProdutoPeloId(int id)
        {
            try
            {
                //comando SQL e o objeto Produto
                Produto obj = new Produto();
                string strCmd = @"select * from tb_produtos where id=@id";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.codigo = rs.GetInt32("id");
                    obj.descricao = rs.GetString("descricao");
                    obj.preco = rs.GetDecimal("preco");

                    conexao.Close();
                    return obj;

                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
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

        #region BaixaEstoque
        public void BaixaEstoque(int idProduto, int qtd_estoque)
        {
            try
            {
                //comando SQL e o objeto Produto
                string strCmd = @"update tb_produtos set qtd_estoque=@qtd_estoque where id=@id";

                //Organizar comando e executar
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@qtd_estoque", qtd_estoque);
                executacmd.Parameters.AddWithValue("@id", idProduto);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                conexao.Close();
            }
        }
        #endregion

        #region EstoqueAtual
        public int EstoqueAtual(int idProduto)
        {
            try
            {
                int vQtd = 0;
                string strCmd = @"select qtd_estoque from tb_produtos where id=@id";

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@id", idProduto);
                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    vQtd = rs.GetInt32("qtd_estoque");
                    conexao.Close();
                }

                return vQtd;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                conexao.Close();
                return 0;
            }
        }
        #endregion
    }
}
