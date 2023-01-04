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
    public class ItemVendaDAO
    {
        private MySqlConnection conexao;

        public ItemVendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastraItem
        public void CadastraItem(ItemVenda obj)
        {
            try
            {
                //comando sql
                string strCmd = @"insert into tb_itensvendas (venda_id, produto_id, qtd, subtotal)
                                   values (@venda_id, @produto_id, @qtd, @subtotal)";

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@venda_id", obj.venda_id);
                executacmd.Parameters.AddWithValue("@produto_id", obj.produto_id);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtd);
                executacmd.Parameters.AddWithValue("@subtotal", obj.subtotal);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //MessageBox.Show("Venda cadastrada com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: " + erro);
                conexao.Close();
            }

        }
        #endregion

        #region ListarItensVenda
        public DataTable ListarItensVenda(int vendaId)
        {
            try
            {
                //criar o comando SQL
                DataTable tabDetalhes = new DataTable();
                string strCmd = @"select i.id as 'Código',
                                         p.descricao as 'Descrição',
                                         i.qtd as 'Quantidade',
                                         p.preco as 'Preço',
                                         i.subtotal as 'Subtotal'
                                  from tb_itensvendas as i join tb_produtos as p on (i.produto_id = p.id)
                                  where venda_id = @venda_id";


                //organizar e executar o comando sql
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@venda_id", vendaId);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //criar o mysqldataadapter para preencher os dados do datatable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabDetalhes);

                conexao.Close();
                return tabDetalhes;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                conexao.Close();
                return null;
            }
        }
        #endregion
    }
}
