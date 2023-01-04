namespace Projeto_Controle_Vendas.br.com.projeto.view
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroForn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaForn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroProd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaProd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrocaUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClientes,
            this.menuFuncionarios,
            this.menuFornecedores,
            this.menuProdutos,
            this.menuVendas,
            this.menuConfig});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 56);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuClientes
            // 
            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroCliente,
            this.menuConsultaCliente});
            this.menuClientes.Image = global::Projeto_Controle_Vendas.Properties.Resources.cliente;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(93, 52);
            this.menuClientes.Text = "Clientes";
            // 
            // menuCadastroCliente
            // 
            this.menuCadastroCliente.Name = "menuCadastroCliente";
            this.menuCadastroCliente.Size = new System.Drawing.Size(180, 22);
            this.menuCadastroCliente.Text = "Cadastro de Cliente";
            this.menuCadastroCliente.Click += new System.EventHandler(this.menuCadastroCliente_Click);
            // 
            // menuConsultaCliente
            // 
            this.menuConsultaCliente.Name = "menuConsultaCliente";
            this.menuConsultaCliente.Size = new System.Drawing.Size(180, 22);
            this.menuConsultaCliente.Text = "Consulta de Cliente";
            this.menuConsultaCliente.Click += new System.EventHandler(this.menuConsultaCliente_Click);
            // 
            // menuFuncionarios
            // 
            this.menuFuncionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFunc,
            this.menuConsultaFunc});
            this.menuFuncionarios.Image = global::Projeto_Controle_Vendas.Properties.Resources.funcionario;
            this.menuFuncionarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFuncionarios.Name = "menuFuncionarios";
            this.menuFuncionarios.Size = new System.Drawing.Size(135, 52);
            this.menuFuncionarios.Text = "Funcionários";
            this.menuFuncionarios.Click += new System.EventHandler(this.menuFuncionarios_Click);
            // 
            // menuCadastroFunc
            // 
            this.menuCadastroFunc.Name = "menuCadastroFunc";
            this.menuCadastroFunc.Size = new System.Drawing.Size(208, 22);
            this.menuCadastroFunc.Text = "Cadastro de Funcionários";
            this.menuCadastroFunc.Click += new System.EventHandler(this.menuCadastroFunc_Click);
            // 
            // menuConsultaFunc
            // 
            this.menuConsultaFunc.Name = "menuConsultaFunc";
            this.menuConsultaFunc.Size = new System.Drawing.Size(208, 22);
            this.menuConsultaFunc.Text = "Consulta de Funcionários";
            this.menuConsultaFunc.Click += new System.EventHandler(this.menuConsultaFunc_Click);
            // 
            // menuFornecedores
            // 
            this.menuFornecedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroForn,
            this.menuConsultaForn});
            this.menuFornecedores.Image = global::Projeto_Controle_Vendas.Properties.Resources.fornecedor;
            this.menuFornecedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFornecedores.Name = "menuFornecedores";
            this.menuFornecedores.Size = new System.Drawing.Size(138, 52);
            this.menuFornecedores.Text = "Fornecedores";
            // 
            // menuCadastroForn
            // 
            this.menuCadastroForn.Name = "menuCadastroForn";
            this.menuCadastroForn.Size = new System.Drawing.Size(211, 22);
            this.menuCadastroForn.Text = "Cadastro de Fornecedores";
            this.menuCadastroForn.Click += new System.EventHandler(this.menuCadastroForn_Click);
            // 
            // menuConsultaForn
            // 
            this.menuConsultaForn.Name = "menuConsultaForn";
            this.menuConsultaForn.Size = new System.Drawing.Size(211, 22);
            this.menuConsultaForn.Text = "Consulta de Fornecedores";
            this.menuConsultaForn.Click += new System.EventHandler(this.menuConsultaForn_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroProd,
            this.menuConsultaProd});
            this.menuProdutos.Image = global::Projeto_Controle_Vendas.Properties.Resources.produto;
            this.menuProdutos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(115, 52);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuCadastroProd
            // 
            this.menuCadastroProd.Name = "menuCadastroProd";
            this.menuCadastroProd.Size = new System.Drawing.Size(188, 22);
            this.menuCadastroProd.Text = "Cadastro de Produtos";
            this.menuCadastroProd.Click += new System.EventHandler(this.menuCadastroProd_Click);
            // 
            // menuConsultaProd
            // 
            this.menuConsultaProd.Name = "menuConsultaProd";
            this.menuConsultaProd.Size = new System.Drawing.Size(188, 22);
            this.menuConsultaProd.Text = "Consulta de Produtos";
            this.menuConsultaProd.Click += new System.EventHandler(this.menuConsultaProd_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistVendas});
            this.menuVendas.Image = global::Projeto_Controle_Vendas.Properties.Resources.venda;
            this.menuVendas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(104, 52);
            this.menuVendas.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(180, 22);
            this.menuNovaVenda.Text = "Nova Venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistVendas
            // 
            this.menuHistVendas.Name = "menuHistVendas";
            this.menuHistVendas.Size = new System.Drawing.Size(180, 22);
            this.menuHistVendas.Text = "Histórico de Vendas";
            this.menuHistVendas.Click += new System.EventHandler(this.menuHistVendas_Click);
            // 
            // menuConfig
            // 
            this.menuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrocaUsuario,
            this.menuSair});
            this.menuConfig.Image = global::Projeto_Controle_Vendas.Properties.Resources.configuracoes;
            this.menuConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(128, 52);
            this.menuConfig.Text = "Configurações";
            // 
            // menuTrocaUsuario
            // 
            this.menuTrocaUsuario.Name = "menuTrocaUsuario";
            this.menuTrocaUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuTrocaUsuario.Text = "Trocar de Usuário";
            this.menuTrocaUsuario.Click += new System.EventHandler(this.menuTrocaUsuario_Click);
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(180, 22);
            this.menuSair.Text = "Sair do Sistema";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtData,
            this.toolStripStatusLabel6,
            this.txtHora,
            this.toolStripStatusLabel4,
            this.txtUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel1.Text = "Data atual:";
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(73, 17);
            this.txtData.Text = "17/08/2022";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel6.Text = "Hora atual:";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(38, 17);
            this.txtHora.Text = "10:30";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel4.Text = "Usuário logado:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(60, 17);
            this.txtUsuario.Text = "Usuário X";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaCliente;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFunc;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFunc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroForn;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaForn;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroProd;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaProd;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuHistVendas;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.ToolStripMenuItem menuTrocaUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        public System.Windows.Forms.ToolStripMenuItem menuProdutos;
        public System.Windows.Forms.ToolStripStatusLabel txtData;
        public System.Windows.Forms.ToolStripStatusLabel txtHora;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
        private System.Windows.Forms.Timer timer1;
    }
}