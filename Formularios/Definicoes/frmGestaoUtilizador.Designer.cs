namespace Facturix_Salários.Formularios.Definicoes
{
    partial class frmGestaoUtilizador
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
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Funcionários");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Categorias");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Centros de custo");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Estabelecimentos");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Profissões");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Sindicatos");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Habilitações");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Cadastros", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestaoUtilizador));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataUtilizadores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegisto = new System.Windows.Forms.TextBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtNascimento = new System.Windows.Forms.DateTimePicker();
            this.cbNivel = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txtNomeUtilizador = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataUtilizadores)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(735, 15);
            this.treeView1.Name = "treeView1";
            treeNode25.Checked = true;
            treeNode25.Name = "funcionarios";
            treeNode25.Text = "Funcionários";
            treeNode26.Name = "categorias";
            treeNode26.Text = "Categorias";
            treeNode27.Name = "centrosDeCusto";
            treeNode27.Text = "Centros de custo";
            treeNode28.Name = "estabelecimentos";
            treeNode28.Text = "Estabelecimentos";
            treeNode29.Name = "profissoes";
            treeNode29.Text = "Profissões";
            treeNode30.Name = "sindicatos";
            treeNode30.Text = "Sindicatos";
            treeNode31.Name = "habilitacoes";
            treeNode31.Text = "Habilitações";
            treeNode32.Name = "nodeCadastros";
            treeNode32.Text = "Cadastros";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode32});
            this.treeView1.Size = new System.Drawing.Size(264, 597);
            this.treeView1.TabIndex = 251;
            // 
            // dataUtilizadores
            // 
            this.dataUtilizadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataUtilizadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUtilizadores.Location = new System.Drawing.Point(44, 262);
            this.dataUtilizadores.Name = "dataUtilizadores";
            this.dataUtilizadores.RowHeadersVisible = false;
            this.dataUtilizadores.Size = new System.Drawing.Size(634, 244);
            this.dataUtilizadores.TabIndex = 249;
            this.dataUtilizadores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUtilizadores_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Location = new System.Drawing.Point(16, 539);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 74);
            this.panel1.TabIndex = 248;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Location = new System.Drawing.Point(119, 6);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(69, 60);
            this.btnConsultar.TabIndex = 3007;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegressar.BackgroundImage")));
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.Location = new System.Drawing.Point(592, 6);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 3002;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.BackgroundImage")));
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Location = new System.Drawing.Point(405, 6);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 3001;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(308, 6);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 60);
            this.btnCancelar.TabIndex = 3005;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.BackgroundImage")));
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Location = new System.Drawing.Point(213, 6);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(69, 60);
            this.btnAtualizar.TabIndex = 3004;
            this.btnAtualizar.Text = "Modificar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Location = new System.Drawing.Point(498, 6);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 60);
            this.btnEliminar.TabIndex = 3003;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.BackgroundImage")));
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.Location = new System.Drawing.Point(26, 6);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(69, 60);
            this.btnAdicionar.TabIndex = 3006;
            this.btnAdicionar.Text = "\r\nAdicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 275);
            this.panel2.TabIndex = 250;
            // 
            // txtApelido
            // 
            this.txtApelido.Location = new System.Drawing.Point(138, 64);
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(214, 20);
            this.txtApelido.TabIndex = 245;
            this.txtApelido.TextChanged += new System.EventHandler(this.txtApelido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 242;
            this.label3.Text = "Apelido:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(489, 99);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(204, 20);
            this.txtContacto.TabIndex = 247;
            this.txtContacto.TextChanged += new System.EventHandler(this.txtContacto_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(138, 139);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(214, 20);
            this.txtPass.TabIndex = 246;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 234;
            this.label4.Text = "Palavra Passe:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(263, 28);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(430, 20);
            this.txtNome.TabIndex = 244;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 238;
            this.label2.Text = "Nome:";
            // 
            // txtRegisto
            // 
            this.txtRegisto.Enabled = false;
            this.txtRegisto.Location = new System.Drawing.Point(138, 28);
            this.txtRegisto.Name = "txtRegisto";
            this.txtRegisto.ReadOnly = true;
            this.txtRegisto.Size = new System.Drawing.Size(55, 20);
            this.txtRegisto.TabIndex = 243;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl5.Location = new System.Drawing.Point(368, 105);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(13, 13);
            this.lbl5.TabIndex = 237;
            this.lbl5.Text = "5";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl6.Location = new System.Drawing.Point(41, 142);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(13, 13);
            this.lbl6.TabIndex = 236;
            this.lbl6.Text = "6";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl3.Location = new System.Drawing.Point(368, 67);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(13, 13);
            this.lbl3.TabIndex = 235;
            this.lbl3.Text = "3";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl2.Location = new System.Drawing.Point(41, 67);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 13);
            this.lbl2.TabIndex = 240;
            this.lbl2.Text = "2";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl1.Location = new System.Drawing.Point(200, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 13);
            this.lbl1.TabIndex = 241;
            this.lbl1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 239;
            this.label1.Text = "Registo n°:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtNascimento);
            this.panel3.Controls.Add(this.cbNivel);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.lbl9);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lbl4);
            this.panel3.Controls.Add(this.txtNomeUtilizador);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.lbl7);
            this.panel3.Controls.Add(this.lbl8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(16, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(691, 210);
            this.panel3.TabIndex = 252;
            // 
            // dtNascimento
            // 
            this.dtNascimento.CustomFormat = "dd-MM-yyyy";
            this.dtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNascimento.Location = new System.Drawing.Point(472, 162);
            this.dtNascimento.Name = "dtNascimento";
            this.dtNascimento.Size = new System.Drawing.Size(204, 20);
            this.dtNascimento.TabIndex = 7;
            this.dtNascimento.ValueChanged += new System.EventHandler(this.dtNascimento_ValueChanged);
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Items.AddRange(new object[] {
            "Admin",
            "Normal"});
            this.cbNivel.Location = new System.Drawing.Point(121, 162);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(214, 21);
            this.cbNivel.TabIndex = 6;
            this.cbNivel.SelectedIndexChanged += new System.EventHandler(this.cbNivel_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(366, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Data Nascimento:";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl9.Location = new System.Drawing.Point(350, 164);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(13, 13);
            this.lbl9.TabIndex = 0;
            this.lbl9.Text = "9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nível:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(121, 83);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Contacto:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl4.Location = new System.Drawing.Point(23, 86);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(13, 13);
            this.lbl4.TabIndex = 0;
            this.lbl4.Text = "4";
            // 
            // txtNomeUtilizador
            // 
            this.txtNomeUtilizador.Location = new System.Drawing.Point(472, 48);
            this.txtNomeUtilizador.Name = "txtNomeUtilizador";
            this.txtNomeUtilizador.Size = new System.Drawing.Size(204, 20);
            this.txtNomeUtilizador.TabIndex = 3;
            this.txtNomeUtilizador.TextChanged += new System.EventHandler(this.txtNomeUtilizador_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(366, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nome de Utilizador:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(472, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(204, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl7.Location = new System.Drawing.Point(352, 124);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(13, 13);
            this.lbl7.TabIndex = 0;
            this.lbl7.Text = "7";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl8.Location = new System.Drawing.Point(24, 165);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(13, 13);
            this.lbl8.TabIndex = 236;
            this.lbl8.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Confirmar Palavra P.:";
            // 
            // frmGestaoUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1015, 629);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataUtilizadores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtApelido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegisto);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmGestaoUtilizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestaoã de Utilizadores";
            this.Load += new System.EventHandler(this.frmGestaoUtilizador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGestaoUtilizador_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataUtilizadores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataUtilizadores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtApelido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegisto;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbNivel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox txtNomeUtilizador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl8;
        public System.Windows.Forms.DateTimePicker dtNascimento;
    }
}