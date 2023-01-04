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
    public partial class frmPagamentos : Form
    {
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dataatual;
        public frmPagamentos(Cliente cliente, DataTable carrinho, DateTime dataatual)
        {
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dataatual = dataatual;

            InitializeComponent();
        }

        private void frmPagamentos_Load(object sender, EventArgs e)
        {
            txtTroco.Text = "0,00";
            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";
        }

        private void btnFinalizaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                //botao finalizar venda
                decimal vDinheiro, vCartao, vTroco, vTotalPago, vTotal;
                int vQtdEstoque, vQtdComprada, vQtdAtualizada;

                ProdutoDAO pdao = new ProdutoDAO();

                vDinheiro = decimal.Parse(txtDinheiro.Text);
                vCartao = decimal.Parse(txtCartao.Text);
                vTotal = decimal.Parse(txtTotal.Text);

                //calcular total pago
                vTotalPago = vDinheiro + vCartao;

                if(vTotalPago < vTotal)
                {
                    MessageBox.Show("O total pago é menor que o valor total da venda!");
                }
                else
                {
                    //calcular troco
                    vTroco = vTotalPago - vTotal;

                    //cadastra venda
                    Vendas venda = new Vendas();
                    venda.cliente_id = cliente.codigo;
                    venda.data_venda = dataatual;
                    venda.total_venda = vTotal;
                    venda.obs = txtObs.Text;

                    VendaDAO vendaDAO = new VendaDAO();
                    txtTroco.Text = vTroco.ToString();
                    vendaDAO.CadastraVenda(venda);

                    //cadastra itens da venda
                    foreach(DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda();
                        item.venda_id = vendaDAO.RetornaUltimoIdVenda();
                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd = int.Parse(linha["Quantidade"].ToString());
                        item.subtotal = decimal.Parse(linha["Subtotal"].ToString());

                        //baixa no estoque
                        vQtdEstoque = pdao.EstoqueAtual(item.produto_id);
                        vQtdComprada = item.qtd;
                        vQtdAtualizada = vQtdEstoque - vQtdComprada;

                        pdao.BaixaEstoque(item.produto_id, vQtdAtualizada);

                        ItemVendaDAO itemdao = new ItemVendaDAO();
                        itemdao.CadastraItem(item);

                    }

                    MessageBox.Show("Venda finalizada com sucesso!");

                    this.Dispose();

                    /*for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
                    {
                        if (Application.OpenForms[intIndex] != this)
                            Application.OpenForms[intIndex].Close();
                    }*/

                    new frmVendas().ShowDialog();
                }  
            }
            catch (Exception)
            {

                throw;
            }

            

        }


    }
}
