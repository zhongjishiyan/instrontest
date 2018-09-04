namespace AppleLabApplication.Extensions
{
    partial class UListEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UListEditor));
            this.btrRefreshListU = new System.Windows.Forms.Button();
            this.btAddU = new System.Windows.Forms.Button();
            this.btRemoveU = new System.Windows.Forms.Button();
            this.panelU1 = new System.Windows.Forms.Panel();
            this.dataGridViewU1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btUpU = new System.Windows.Forms.Button();
            this.btDownU = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelU1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewU1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btrRefreshListU
            // 
            resources.ApplyResources(this.btrRefreshListU, "btrRefreshListU");
            this.btrRefreshListU.Name = "btrRefreshListU";
            // 
            // btAddU
            // 
            resources.ApplyResources(this.btAddU, "btAddU");
            this.btAddU.Name = "btAddU";
            this.btAddU.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemoveU
            // 
            resources.ApplyResources(this.btRemoveU, "btRemoveU");
            this.btRemoveU.Name = "btRemoveU";
            this.btRemoveU.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // panelU1
            // 
            this.panelU1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panelU1, "panelU1");
            this.panelU1.Name = "panelU1";
            // 
            // dataGridViewU1
            // 
            this.dataGridViewU1.AllowUserToAddRows = false;
            this.dataGridViewU1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewU1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            resources.ApplyResources(this.dataGridViewU1, "dataGridViewU1");
            this.dataGridViewU1.Name = "dataGridViewU1";
            this.dataGridViewU1.RowHeadersVisible = false;
            this.dataGridViewU1.RowTemplate.Height = 23;
            this.dataGridViewU1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btUpU
            // 
            resources.ApplyResources(this.btUpU, "btUpU");
            this.btUpU.Name = "btUpU";
            this.btUpU.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDownU
            // 
            resources.ApplyResources(this.btDownU, "btDownU");
            this.btDownU.Name = "btDownU";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btAddU, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btDownU, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btRemoveU, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btrRefreshListU, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btUpU, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // UListEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewU1);
            this.Controls.Add(this.panelU1);
            this.Name = "UListEditor";
            this.Resize += new System.EventHandler(this.UListEditor_Resize);
            this.panelU1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewU1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btrRefreshListU;
        private System.Windows.Forms.Button btAddU;
        private System.Windows.Forms.Button btRemoveU;
        private System.Windows.Forms.Panel panelU1;
        public System.Windows.Forms.DataGridView dataGridViewU1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.Button btDownU;
        private System.Windows.Forms.Button btUpU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
