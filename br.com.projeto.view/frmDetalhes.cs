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
    public partial class frmDetalhes : Form
    {
        int vendaId;
        public frmDetalhes(int venda_id)
        {
            vendaId = venda_id;
            InitializeComponent();
        }

        private void frmDetalhes_Load(object sender, EventArgs e)
        {
            //careega dataGridView
            ItemVendaDAO dao = new ItemVendaDAO();
            tbgDetalhes.DataSource = dao.ListarItensVenda(vendaId);
        }
    }
}
