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
    public class VendaDAO
    {
        private MySqlConnection conexao;

        public VendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastraVenda
        public void CadastraVenda(Vendas obj)
        {
            try
            {
                //comando sql
                string strCmd = @"insert into tb_vendas (cliente_id, data_venda, total_venda, observacoes)
                                   values (@cliente_id, @data_venda, @total_venda,@obs)";

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@cliente_id", obj.cliente_id);
                executacmd.Parameters.AddWithValue("@data_venda", obj.data_venda);
                executacmd.Parameters.AddWithValue("@total_venda", obj.total_venda);
                executacmd.Parameters.AddWithValue("@obs", obj.obs);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //MessageBox.Show("Venda cadastrada com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro:" + erro);
            }
        }
        #endregion

        #region RetornaUltimoIdVenda
        public int RetornaUltimoIdVenda()
        {
            try
            {
                int idVenda = 0;
                string strCmd = "select max(id) id from tb_vendas";

                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    idVenda = rs.GetInt32("id");  
                }

                conexao.Close();
                return idVenda;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Ocorreu um erro: "+ erro);
                conexao.Close();
                return 0;
            }
        }

        #endregion

        #region ListarVendasPeriodo
        public DataTable ListarVendasPeriodo(DateTime datainicio, DateTime datafim)
        {
            try
            {
                //criar o datatable e o comando SQL
                DataTable tabHistorico = new DataTable();
                string strCmd = @"select v.id as 'Código',
                                       v.data_venda as 'Data da Venda',
                                       c.nome as 'Cliente',
                                       v.total_venda as 'Total',
                                       v.observacoes as 'Observações'
                                   from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)
                                   where v.data_venda between @datainicio and @datafim";

                //organizar e executar o comando sql
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);
                executacmd.Parameters.AddWithValue("@datainicio", datainicio);
                executacmd.Parameters.AddWithValue("@datafim", datafim);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //criar o mysqldataadapter para preencher os dados do datatable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabHistorico);

                conexao.Close();
                return tabHistorico;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                conexao.Close();
                return null;
            }
        }
        #endregion

        #region ListarVendas
        public DataTable ListarVendas()
        {
            try
            {
                //criar o datatable e o comando SQL
                DataTable tabHistorico = new DataTable();
                string strCmd = @"select v.id as 'Código',
                                       v.data_venda as 'Data da Venda',
                                       c.nome as 'Cliente',
                                       v.total_venda as 'Total',
                                       v.observacoes as 'Observações'
                                   from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)";

                //organizar e executar o comando sql
                MySqlCommand executacmd = new MySqlCommand(strCmd, conexao);

                //abrir conexao e executar o cmd
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //criar o mysqldataadapter para preencher os dados do datatable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabHistorico);

                conexao.Close();
                return tabHistorico;

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
