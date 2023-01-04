using Projeto_Controle_Vendas.br.com.projeto.dao;
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
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime datainicio, datafim;

            datainicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy-MM-dd"));
            datafim = Convert.ToDateTime(dtFim.Value.ToString("yyyy-MM-dd"));

            VendaDAO vdao = new VendaDAO();
            tbgHistorico.DataSource = vdao.ListarVendasPeriodo(datainicio, datafim);
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            VendaDAO vdao = new VendaDAO();
            tbgHistorico.DataSource = vdao.ListarVendas();
            //tbgHistorico.AutoGenerateColumns = false;
            tbgHistorico.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void tbgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //abrir o outro formulário
            int idVenda = int.Parse(tbgHistorico.CurrentRow.Cells[0].Value.ToString());
            frmDetalhes detalhes = new frmDetalhes(idVenda);

            DateTime dataVenda = Convert.ToDateTime(tbgHistorico.CurrentRow.Cells[1].Value.ToString());

            detalhes.txtCliente.Text = tbgHistorico.CurrentRow.Cells[2].Value.ToString();
            detalhes.txtData.Text = dataVenda.ToString("dd/MM/yyyy");
            detalhes.txtTotal.Text = tbgHistorico.CurrentRow.Cells[3].Value.ToString();
            detalhes.txtObs.Text = tbgHistorico.CurrentRow.Cells[4].Value.ToString();
            detalhes.ShowDialog();

        }
    }
}
