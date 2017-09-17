using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Cells = SourceGrid2.Cells.Real;

namespace SampleProject.Extensions
{
	/// <summary>
	/// Summary description for ListEditor.
	/// </summary>
	public class ListEditorEx : System.Windows.Forms.UserControl
    {
        private IContainer components;
        private Button btrRefreshList;
        private Button btAdd;
        private Button btRemove;
        private Button btUp;
        private Button btDown;
        private Button btnaddcol;
        private Button btnremovecol;
        public ListViewEx.ListViewEx listViewEx1;
        private TextBox textBoxComment;
        public ComboBox cboitem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem pmenu1;
        private ToolStripMenuItem pmenu2;

        public int row = 0;

        public void  setcellvalue(int row,int col,string v)
        {
           
        }

		public ListEditorEx()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            listViewEx1.FullRowSelect = true ;
            listViewEx1.DoubleClickActivation = true;

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListEditorEx));
            this.btrRefreshList = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btnaddcol = new System.Windows.Forms.Button();
            this.btnremovecol = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.cboitem = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmenu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pmenu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewEx1 = new ListViewEx.ListViewEx();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btrRefreshList
            // 
            this.btrRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btrRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("btrRefreshList.Image")));
            this.btrRefreshList.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btrRefreshList.Location = new System.Drawing.Point(248, 5);
            this.btrRefreshList.Name = "btrRefreshList";
            this.btrRefreshList.Size = new System.Drawing.Size(24, 23);
            this.btrRefreshList.TabIndex = 14;
            this.btrRefreshList.Visible = false;
            this.btrRefreshList.Click += new System.EventHandler(this.btrRefreshList_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btAdd.Location = new System.Drawing.Point(188, 5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 23);
            this.btAdd.TabIndex = 13;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btRemove.Location = new System.Drawing.Point(216, 5);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(24, 23);
            this.btRemove.TabIndex = 12;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btUp
            // 
            this.btUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUp.Enabled = false;
            this.btUp.Image = ((System.Drawing.Image)(resources.GetObject("btUp.Image")));
            this.btUp.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btUp.Location = new System.Drawing.Point(280, 5);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(24, 23);
            this.btUp.TabIndex = 11;
            this.btUp.Visible = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.Enabled = false;
            this.btDown.Image = ((System.Drawing.Image)(resources.GetObject("btDown.Image")));
            this.btDown.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btDown.Location = new System.Drawing.Point(308, 5);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(24, 23);
            this.btDown.TabIndex = 10;
            this.btDown.Visible = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btnaddcol
            // 
            this.btnaddcol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddcol.Image = ((System.Drawing.Image)(resources.GetObject("btnaddcol.Image")));
            this.btnaddcol.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnaddcol.Location = new System.Drawing.Point(96, 5);
            this.btnaddcol.Name = "btnaddcol";
            this.btnaddcol.Size = new System.Drawing.Size(24, 23);
            this.btnaddcol.TabIndex = 15;
            this.btnaddcol.Click += new System.EventHandler(this.btnaddcol_Click);
            // 
            // btnremovecol
            // 
            this.btnremovecol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnremovecol.Image = ((System.Drawing.Image)(resources.GetObject("btnremovecol.Image")));
            this.btnremovecol.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnremovecol.Location = new System.Drawing.Point(126, 5);
            this.btnremovecol.Name = "btnremovecol";
            this.btnremovecol.Size = new System.Drawing.Size(24, 23);
            this.btnremovecol.TabIndex = 16;
            this.btnremovecol.Click += new System.EventHandler(this.btnremovecol_Click);
            // 
            // textBoxComment
            // 
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxComment.Location = new System.Drawing.Point(122, 131);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(96, 17);
            this.textBoxComment.TabIndex = 19;
            this.textBoxComment.Visible = false;
            // 
            // cboitem
            // 
            this.cboitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboitem.IntegralHeight = false;
            this.cboitem.ItemHeight = 12;
            this.cboitem.Location = new System.Drawing.Point(122, 105);
            this.cboitem.Name = "cboitem";
            this.cboitem.Size = new System.Drawing.Size(96, 20);
            this.cboitem.TabIndex = 18;
            this.cboitem.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmenu1,
            this.pmenu2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // pmenu1
            // 
            this.pmenu1.Checked = true;
            this.pmenu1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pmenu1.Name = "pmenu1";
            this.pmenu1.Size = new System.Drawing.Size(130, 22);
            this.pmenu1.Text = "文本输入";
            this.pmenu1.Click += new System.EventHandler(this.pmenu1_Click);
            // 
            // pmenu2
            // 
            this.pmenu2.Name = "pmenu2";
            this.pmenu2.Size = new System.Drawing.Size(130, 22);
            this.pmenu2.Text = "组合框输入";
            this.pmenu2.Click += new System.EventHandler(this.pmenu2_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.AllowColumnReorder = true;
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listViewEx1.DoubleClickActivation = false;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.Location = new System.Drawing.Point(0, 34);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.ShowGroups = false;
            this.listViewEx1.Size = new System.Drawing.Size(340, 218);
            this.listViewEx1.TabIndex = 17;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            this.listViewEx1.SubItemClicked += new ListViewEx.SubItemEventHandler(this.listViewEx1_SubItemClicked);
            this.listViewEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewEx1_MouseUp);
            this.listViewEx1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewEx1_ColumnClick);
            // 
            // ListEditorEx
            // 
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.cboitem);
            this.Controls.Add(this.listViewEx1);
            this.Controls.Add(this.btnremovecol);
            this.Controls.Add(this.btnaddcol);
            this.Controls.Add(this.btrRefreshList);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.btDown);
            this.Name = "ListEditorEx";
            this.Size = new System.Drawing.Size(340, 252);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private ArrayList m_List;

		public ArrayList List
		{
			get{return m_List;}
			set{m_List = value;}
		}

		private Type m_ItemType;

		public Type ItemType
		{
			get{return m_ItemType;}
			set{m_ItemType = value;LoadEditors();}
		}

		private SourceGrid2.DataModels.IDataModel[] m_Editors;

		[Browsable(false)]
		public SourceGrid2.DataModels.IDataModel[] Editors
		{
			get{return m_Editors;}
			set{m_Editors = value;}
		}

		private System.Reflection.PropertyInfo[] m_Properties;

		[Browsable(false)]
		public System.Reflection.PropertyInfo[] Properties
		{
			get{return m_Properties;}
			set{m_Properties = value;}
		}

		private void LoadEditors()
		{
			
		}

		public void LoadList()
		{
			
		}

		private void PopulateRow(int p_GridRow, object p_Object)
		{
			
		}

		private void PopulateCell(int p_GridRow, int p_GridCol, System.Reflection.PropertyInfo p_PropInfo, SourceGrid2.DataModels.IDataModel p_DataModel, object p_Object)
		{
			
		}

		private void btAdd_Click(object sender, System.EventArgs e)
		{
            int i;
            ListViewItem  lvi;

           
            lvi = new  ListViewItem();

            lvi.Text = "";
           
            lvi.BackColor = Color.White;

            lvi.Checked = true;
            

            for (i = 0; i < listViewEx1.Columns.Count; i++)
            {
                lvi.SubItems.Add("");
            }
            this.listViewEx1.Items.Add(lvi);
		}

		public event EventHandler ListChanged;

		protected virtual void OnListChanged(EventArgs e)
		{
			if (ListChanged!=null)
				ListChanged(this, e);
		}

		private void Grid_ValueChanged(object sender, SourceGrid2.PositionEventArgs e)
		{
			OnListChanged(EventArgs.Empty);
		}

		private void btRemove_Click(object sender, System.EventArgs e)
		{
            if (listViewEx1.Items.Count > 0)
            {
                listViewEx1.Items.RemoveAt(listViewEx1.Items.Count - 1);
            }
		}

		private void btrRefreshList_Click(object sender, System.EventArgs e)
		{
			
		}

		private void btUp_Click(object sender, System.EventArgs e)
		{
			
		}

		private void btDown_Click(object sender, System.EventArgs e)
		{
			
		}

		private void grid_CellGotFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
		{
            
		}

		private void grid_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
		{
          
        }

        private void btnaddcol_Click(object sender, EventArgs e)
        {
            ColumnHeader gc=new ColumnHeader();
            gc.Text = "";
            gc.Width = 80;
            gc.TextAlign = HorizontalAlignment.Center;  

            listViewEx1.Columns.Add(gc);
        }

        private void listViewEx1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
           
        }

        private void listViewEx1_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {

            if (pmenu1.Checked == true)
            {
                listViewEx1.StartEditing(textBoxComment, e.Item, e.SubItem);
            }
            else
            {
                listViewEx1.StartEditing(cboitem, e.Item, e.SubItem);  
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listViewEx1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listViewEx1, e.X, e.Y);

            }
        }

        private void pmenu1_Click(object sender, EventArgs e)
        {
            pmenu1.Checked = true;
            pmenu2.Checked = false; 

        }

        private void pmenu2_Click(object sender, EventArgs e)
        {
            pmenu1.Checked = false;
            pmenu2.Checked = true;
        }

        private void btnremovecol_Click(object sender, EventArgs e)
        {
            if (listViewEx1.Columns.Count > 0)
            {
                listViewEx1.Columns.RemoveAt(listViewEx1.Columns.Count - 1);
            }
        }
	}
}
