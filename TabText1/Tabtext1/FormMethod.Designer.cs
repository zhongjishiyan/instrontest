namespace AppleLabApplication
{
    partial class FormMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMethod));
            this.wizardControl1 = new WizardBase.WizardControl();
            this.startStep1 = new WizardBase.StartStep();
            this.intermediateStep1 = new WizardBase.IntermediateStep();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btndel = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.listBox2 = new AppleLabApplication.ListExt(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.listBox1 = new AppleLabApplication.ListExt(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbokind = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.txtexplain = new System.Windows.Forms.TextBox();
            this.txtauthor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtinterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboitem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnpath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.intermediateStep2 = new WizardBase.IntermediateStep();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.cboshape = new System.Windows.Forms.ComboBox();
            this.listEditor1 = new SampleProject.Extensions.ListEditor();
            this.intermediateStep5 = new WizardBase.IntermediateStep();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.uListEditor1 = new AppleLabApplication.Extensions.UListEditor();
            this.listEditor4 = new SampleProject.Extensions.ListEditorText();
            this.listEditor5 = new SampleProject.Extensions.ListEditorText();
            this.intermediateStep3 = new WizardBase.IntermediateStep();
            this.button1 = new System.Windows.Forms.Button();
            this.listEditor2 = new SampleProject.Extensions.ListEditor();
            this.intermediateStep4 = new WizardBase.IntermediateStep();
            this.listEditor3 = new SampleProject.Extensions.ListEditorEx();
            this.finishStep1 = new WizardBase.FinishStep();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.intermediateStep1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.intermediateStep2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.intermediateStep5.SuspendLayout();
            this.intermediateStep3.SuspendLayout();
            this.intermediateStep4.SuspendLayout();
            this.finishStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackButtonEnabled = true;
            this.wizardControl1.BackButtonText = "< 上一步";
            this.wizardControl1.BackButtonVisible = true;
            this.wizardControl1.CancelButtonEnabled = true;
            this.wizardControl1.CancelButtonText = "取消";
            this.wizardControl1.CancelButtonVisible = true;
            this.wizardControl1.FinishButtonText = "完成";
            this.wizardControl1.HelpButtonEnabled = true;
            this.wizardControl1.HelpButtonText = "帮助";
            this.wizardControl1.HelpButtonVisible = true;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextButtonEnabled = true;
            this.wizardControl1.NextButtonText = "下一步 >";
            this.wizardControl1.NextButtonVisible = true;
            this.wizardControl1.Size = new System.Drawing.Size(671, 496);
            this.wizardControl1.WizardSteps.Add(this.startStep1);
            this.wizardControl1.WizardSteps.Add(this.intermediateStep1);
            this.wizardControl1.WizardSteps.Add(this.intermediateStep2);
            this.wizardControl1.WizardSteps.Add(this.intermediateStep5);
            this.wizardControl1.WizardSteps.Add(this.intermediateStep3);
            this.wizardControl1.WizardSteps.Add(this.intermediateStep4);
            this.wizardControl1.WizardSteps.Add(this.finishStep1);
            this.wizardControl1.CancelButtonClick += new System.EventHandler(this.wizardControl1_CancelButtonClick);
            this.wizardControl1.FinishButtonClick += new System.EventHandler(this.wizardControl1_FinishButtonClick);
            this.wizardControl1.HelpButtonClick += new System.EventHandler(this.wizardControl1_HelpButtonClick);
            this.wizardControl1.NextButtonClick += new WizardBase.WizardNextButtonClickEventHandler(this.wizardControl1_NextButtonClick);
            this.wizardControl1.Click += new System.EventHandler(this.wizardControl1_Click);
            // 
            // startStep1
            // 
            this.startStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("startStep1.BindingImage")));
            this.startStep1.Icon = ((System.Drawing.Image)(resources.GetObject("startStep1.Icon")));
            this.startStep1.Name = "startStep1";
            this.startStep1.Subtitle = "本软件通过指定格式的试验数据，编写试验计算项目，公式并绘制曲线。单击下一步继续...";
            this.startStep1.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.startStep1.Title = "欢迎使用试验方法编辑";
            this.startStep1.TitleFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            // 
            // intermediateStep1
            // 
            this.intermediateStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep1.BindingImage")));
            this.intermediateStep1.Controls.Add(this.panel2);
            this.intermediateStep1.Controls.Add(this.tableLayoutPanel2);
            this.intermediateStep1.Controls.Add(this.txtpath);
            this.intermediateStep1.Controls.Add(this.txtexplain);
            this.intermediateStep1.Controls.Add(this.txtauthor);
            this.intermediateStep1.Controls.Add(this.label10);
            this.intermediateStep1.Controls.Add(this.label7);
            this.intermediateStep1.Controls.Add(this.label6);
            this.intermediateStep1.Controls.Add(this.txtinterval);
            this.intermediateStep1.Controls.Add(this.label5);
            this.intermediateStep1.Controls.Add(this.cboitem);
            this.intermediateStep1.Controls.Add(this.label4);
            this.intermediateStep1.Controls.Add(this.txtName);
            this.intermediateStep1.Controls.Add(this.label3);
            this.intermediateStep1.Controls.Add(this.btnpath);
            this.intermediateStep1.Controls.Add(this.label2);
            this.intermediateStep1.Name = "intermediateStep1";
            this.intermediateStep1.Subtitle = "指定样本文件和位置";
            this.intermediateStep1.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep1.Title = "第一步";
            this.intermediateStep1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btndel);
            this.panel2.Controls.Add(this.btnadd);
            this.panel2.Controls.Add(this.listBox2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(399, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 259);
            this.panel2.TabIndex = 21;
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(140, 128);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(22, 38);
            this.btndel.TabIndex = 4;
            this.btndel.Text = "删除";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(84, 127);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(23, 38);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "添加";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(1, 168);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(260, 86);
            this.listBox2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(262, 19);
            this.label12.TabIndex = 1;
            this.label12.Text = "形状选择：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(1, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 98);
            this.listBox1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.cbokind, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(399, 121);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(269, 61);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // cbokind
            // 
            this.cbokind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbokind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbokind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbokind.FormattingEnabled = true;
            this.cbokind.Location = new System.Drawing.Point(4, 36);
            this.cbokind.Name = "cbokind";
            this.cbokind.Size = new System.Drawing.Size(261, 20);
            this.cbokind.TabIndex = 3;
            this.cbokind.SelectionChangeCommitted += new System.EventHandler(this.cbokind_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 31);
            this.label11.TabIndex = 1;
            this.label11.Text = "方法类型选择：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(8, 337);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(279, 21);
            this.txtpath.TabIndex = 1;
            this.txtpath.Visible = false;
            // 
            // txtexplain
            // 
            this.txtexplain.Location = new System.Drawing.Point(142, 235);
            this.txtexplain.Multiline = true;
            this.txtexplain.Name = "txtexplain";
            this.txtexplain.Size = new System.Drawing.Size(236, 218);
            this.txtexplain.TabIndex = 19;
            // 
            // txtauthor
            // 
            this.txtauthor.Location = new System.Drawing.Point(141, 197);
            this.txtauthor.Name = "txtauthor";
            this.txtauthor.Size = new System.Drawing.Size(237, 21);
            this.txtauthor.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(70, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "方法作者：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "文件类型：";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "方法说明：";
            // 
            // txtinterval
            // 
            this.txtinterval.Location = new System.Drawing.Point(141, 161);
            this.txtinterval.Name = "txtinterval";
            this.txtinterval.Size = new System.Drawing.Size(237, 21);
            this.txtinterval.TabIndex = 9;
            this.txtinterval.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "样本读取间隔：";
            // 
            // cboitem
            // 
            this.cboitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboitem.FormattingEnabled = true;
            this.cboitem.Location = new System.Drawing.Point(141, 121);
            this.cboitem.Name = "cboitem";
            this.cboitem.Size = new System.Drawing.Size(237, 20);
            this.cboitem.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "样本通道名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(141, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(527, 21);
            this.txtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "试验方法名称：";
            // 
            // btnpath
            // 
            this.btnpath.Location = new System.Drawing.Point(580, 133);
            this.btnpath.Name = "btnpath";
            this.btnpath.Size = new System.Drawing.Size(130, 21);
            this.btnpath.TabIndex = 2;
            this.btnpath.Text = "浏览";
            this.btnpath.UseVisualStyleBackColor = true;
            this.btnpath.Visible = false;
            this.btnpath.Click += new System.EventHandler(this.btnpath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据文件路径：";
            this.label2.Visible = false;
            // 
            // intermediateStep2
            // 
            this.intermediateStep2.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep2.BindingImage")));
            this.intermediateStep2.Controls.Add(this.label9);
            this.intermediateStep2.Controls.Add(this.panel1);
            this.intermediateStep2.Controls.Add(this.listEditor1);
            this.intermediateStep2.Name = "intermediateStep2";
            this.intermediateStep2.Subtitle = "自定义输入";
            this.intermediateStep2.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep2.Title = "第二步";
            this.intermediateStep2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.intermediateStep2.Click += new System.EventHandler(this.intermediateStep2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "自定义输入变量：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(25, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 186);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(605, 159);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "单位";
            this.Column5.Items.AddRange(new object[] {
            "asdf",
            "asdf",
            "werewfasdf"});
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.17219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82781F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboshape, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(4, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "形状选择：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboshape
            // 
            this.cboshape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboshape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboshape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboshape.FormattingEnabled = true;
            this.cboshape.Location = new System.Drawing.Point(150, 4);
            this.cboshape.Name = "cboshape";
            this.cboshape.Size = new System.Drawing.Size(451, 20);
            this.cboshape.TabIndex = 1;
            this.cboshape.SelectionChangeCommitted += new System.EventHandler(this.cboshape_SelectionChangeCommitted);
            // 
            // listEditor1
            // 
            this.listEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listEditor1.Editors = null;
            this.listEditor1.ItemType = null;
            this.listEditor1.List = null;
            this.listEditor1.Location = new System.Drawing.Point(25, 261);
            this.listEditor1.Name = "listEditor1";
            this.listEditor1.Properties = null;
            this.listEditor1.Size = new System.Drawing.Size(604, 169);
            this.listEditor1.TabIndex = 0;
            this.listEditor1.ListChanged += new SampleProject.Extensions.ListEditor.ListEventHandler(this.listEditor1_ListChanged);
            // 
            // intermediateStep5
            // 
            this.intermediateStep5.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep5.BindingImage")));
            this.intermediateStep5.Controls.Add(this.label14);
            this.intermediateStep5.Controls.Add(this.label13);
            this.intermediateStep5.Controls.Add(this.button2);
            this.intermediateStep5.Controls.Add(this.uListEditor1);
            this.intermediateStep5.Controls.Add(this.listEditor4);
            this.intermediateStep5.Controls.Add(this.listEditor5);
            this.intermediateStep5.Name = "intermediateStep5";
            this.intermediateStep5.Subtitle = "自定义输入";
            this.intermediateStep5.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep5.Title = "第三步";
            this.intermediateStep5.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "自定义选项";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "自定义文本";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "编辑自定义通道内容";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uListEditor1
            // 
            this.uListEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uListEditor1.Location = new System.Drawing.Point(12, 315);
            this.uListEditor1.Name = "uListEditor1";
            this.uListEditor1.Size = new System.Drawing.Size(656, 136);
            this.uListEditor1.TabIndex = 4;
            this.uListEditor1.addevent += new AppleLabApplication.Extensions.UListEditor.AddEventHandler(this.uListEditor1_addevent);
            this.uListEditor1.removeevent += new AppleLabApplication.Extensions.UListEditor.RemoveEventHandler(this.uListEditor1_removeevent);
            this.uListEditor1.cboevent += new AppleLabApplication.Extensions.UListEditor.CboEventHandler(this.uListEditor1_cboevent);
            // 
            // listEditor4
            // 
            this.listEditor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listEditor4.Editors = null;
            this.listEditor4.ItemType = null;
            this.listEditor4.List = null;
            this.listEditor4.Location = new System.Drawing.Point(12, 67);
            this.listEditor4.Name = "listEditor4";
            this.listEditor4.Properties = null;
            this.listEditor4.Size = new System.Drawing.Size(657, 110);
            this.listEditor4.TabIndex = 9;
            // 
            // listEditor5
            // 
            this.listEditor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listEditor5.Editors = null;
            this.listEditor5.ItemType = null;
            this.listEditor5.List = null;
            this.listEditor5.Location = new System.Drawing.Point(12, 183);
            this.listEditor5.Name = "listEditor5";
            this.listEditor5.Properties = null;
            this.listEditor5.Size = new System.Drawing.Size(657, 126);
            this.listEditor5.TabIndex = 10;
            // 
            // intermediateStep3
            // 
            this.intermediateStep3.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep3.BindingImage")));
            this.intermediateStep3.Controls.Add(this.button1);
            this.intermediateStep3.Controls.Add(this.listEditor2);
            this.intermediateStep3.Name = "intermediateStep3";
            this.intermediateStep3.Subtitle = "设置计算项目";
            this.intermediateStep3.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep3.Title = "第四步";
            this.intermediateStep3.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "编辑公式内容";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listEditor2
            // 
            this.listEditor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listEditor2.Editors = null;
            this.listEditor2.ItemType = null;
            this.listEditor2.List = null;
            this.listEditor2.Location = new System.Drawing.Point(41, 84);
            this.listEditor2.Name = "listEditor2";
            this.listEditor2.Properties = null;
            this.listEditor2.Size = new System.Drawing.Size(596, 337);
            this.listEditor2.TabIndex = 1;
            this.listEditor2.ListChanged += new SampleProject.Extensions.ListEditor.ListEventHandler(this.listEditor2_ListChanged);
            this.listEditor2.Click += new System.EventHandler(this.listEditor2_Click);
            this.listEditor2.DoubleClick += new System.EventHandler(this.listEditor2_DoubleClick);
            this.listEditor2.Enter += new System.EventHandler(this.listEditor2_Enter);
            this.listEditor2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listEditor2_MouseDoubleClick);
            // 
            // intermediateStep4
            // 
            this.intermediateStep4.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep4.BindingImage")));
            this.intermediateStep4.Controls.Add(this.listEditor3);
            this.intermediateStep4.Name = "intermediateStep4";
            this.intermediateStep4.Subtitle = "计算结果编辑表格";
            this.intermediateStep4.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep4.Title = "第五步";
            this.intermediateStep4.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // listEditor3
            // 
            this.listEditor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listEditor3.Editors = null;
            this.listEditor3.ItemType = null;
            this.listEditor3.List = null;
            this.listEditor3.Location = new System.Drawing.Point(12, 89);
            this.listEditor3.Name = "listEditor3";
            this.listEditor3.Properties = null;
            this.listEditor3.Size = new System.Drawing.Size(656, 336);
            this.listEditor3.TabIndex = 0;
            this.listEditor3.Load += new System.EventHandler(this.listEditor3_Load);
            // 
            // finishStep1
            // 
            this.finishStep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.finishStep1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("finishStep1.BackgroundImage")));
            this.finishStep1.Controls.Add(this.label1);
            this.finishStep1.Name = "finishStep1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单击完成按钮，试验方法将保存到数据库中";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 498);
            this.Controls.Add(this.wizardControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试验方法编辑";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.intermediateStep1.ResumeLayout(false);
            this.intermediateStep1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.intermediateStep2.ResumeLayout(false);
            this.intermediateStep2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.intermediateStep5.ResumeLayout(false);
            this.intermediateStep5.PerformLayout();
            this.intermediateStep3.ResumeLayout(false);
            this.intermediateStep4.ResumeLayout(false);
            this.finishStep1.ResumeLayout(false);
            this.finishStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardBase.WizardControl wizardControl1;
        private WizardBase.StartStep startStep1;
        private WizardBase.IntermediateStep intermediateStep1;
        private WizardBase.FinishStep finishStep1;
        private WizardBase.IntermediateStep intermediateStep2;
        private WizardBase.IntermediateStep intermediateStep3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnpath;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        
        private SampleProject.Extensions.ListEditor listEditor1;
        private SampleProject.Extensions.ListEditor listEditor2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboitem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private WizardBase.IntermediateStep intermediateStep4;
        public SampleProject.Extensions.ListEditorEx listEditor3;
        private WizardBase.IntermediateStep intermediateStep5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtinterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboshape;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtexplain;
        private System.Windows.Forms.TextBox txtauthor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbokind;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private ListExt  listBox1;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnadd;
        private ListExt  listBox2;
        private System.Windows.Forms.Label label12;
        private AppleLabApplication.Extensions.UListEditor uListEditor1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private SampleProject.Extensions.ListEditorText listEditor4;
        private SampleProject.Extensions.ListEditorText listEditor5;

    }
}