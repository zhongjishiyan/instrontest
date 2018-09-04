using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Cells = SourceGrid2.Cells.Real;

using AppleLabApplication;

namespace SampleProject.Extensions
{
	/// <summary>
	/// Summary description for ListEditor.
	/// </summary>
	public class ListEditor : UserBase 
    {
		private System.Windows.Forms.Button btDown;
		private System.Windows.Forms.Button btUp;
		private System.Windows.Forms.Button btRemove;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.Button btrRefreshList;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        private Panel panel1;
        public SourceGrid2.Grid grid;
        public int row = 0;

        public void setEditStyle(bool b)
        {
            if (b == false)
            {
                btAdd.Visible = false;
                btRemove.Visible = false;
                btrRefreshList.Visible = false;
                btUp.Visible = false;
                btDown.Visible = false;

                grid.Top = 32;
                grid.Dock = DockStyle.None; 
            }
            else
            {
                btAdd.Visible = true ;
                btRemove.Visible = true ;
                btrRefreshList.Visible = true ;
                btUp.Visible = true ;
                btDown.Visible = true ;
                grid.Top = 0;
                grid.Dock = DockStyle.Fill; 
            }
        }

        public void  setcellvalue(int row,int col,string v)
        {
           
        }

		public ListEditor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
            
           
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListEditor));
            this.btDown = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btrRefreshList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid = new SourceGrid2.Grid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.Enabled = false;
            this.btDown.Image = ((System.Drawing.Image)(resources.GetObject("btDown.Image")));
            this.btDown.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btDown.Location = new System.Drawing.Point(924, 4);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(24, 23);
            this.btDown.TabIndex = 1;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btUp
            // 
            this.btUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUp.Enabled = false;
            this.btUp.Image = ((System.Drawing.Image)(resources.GetObject("btUp.Image")));
            this.btUp.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btUp.Location = new System.Drawing.Point(892, 4);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(24, 23);
            this.btUp.TabIndex = 2;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Enabled = false;
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btRemove.Location = new System.Drawing.Point(828, 4);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(24, 23);
            this.btRemove.TabIndex = 3;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btAdd.Location = new System.Drawing.Point(796, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 23);
            this.btAdd.TabIndex = 4;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btrRefreshList
            // 
            this.btrRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btrRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("btrRefreshList.Image")));
            this.btrRefreshList.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btrRefreshList.Location = new System.Drawing.Point(860, 4);
            this.btrRefreshList.Name = "btrRefreshList";
            this.btrRefreshList.Size = new System.Drawing.Size(24, 23);
            this.btrRefreshList.TabIndex = 5;
            this.btrRefreshList.Click += new System.EventHandler(this.btrRefreshList_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Controls.Add(this.btRemove);
            this.panel1.Controls.Add(this.btDown);
            this.panel1.Controls.Add(this.btUp);
            this.panel1.Controls.Add(this.btrRefreshList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 36);
            this.panel1.TabIndex = 12;
            // 
            // grid
            // 
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.CustomSort = false;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point(0, 36);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(953, 216);
            this.grid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape)));
            this.grid.TabIndex = 13;
            this.grid.CellGotFocus += new SourceGrid2.PositionCancelEventHandler(this.grid_CellGotFocus);
            this.grid.CellLostFocus += new SourceGrid2.PositionCancelEventHandler(this.grid_CellLostFocus);
            // 
            // ListEditor
            // 
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "ListEditor";
            this.Size = new System.Drawing.Size(953, 252);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
			if (m_ItemType != null)
			{
				m_Properties = m_ItemType.GetProperties();
				m_Editors = new SourceGrid2.DataModels.IDataModel[m_Properties.Length];

				for (int i = 0; i < m_Properties.Length; i++)
				{
                    if (i ==m_Properties.Length -1)
                    {
                        

                        m_Editors[i] = new SourceGrid2.DataModels.EditorComboBox(typeof(string),ClsStaticStation.m_Global.mycls.SignalsNames  , false);

                        m_Editors[i].EnableEdit = m_Properties[i].CanWrite;

                    }
                    else
                    {
                        m_Editors[i] = SourceGrid2.Utility.CreateDataModel(m_Properties[i].PropertyType);

                        m_Editors[i].EnableEdit = m_Properties[i].CanWrite;

                    }

                   
					
				}
			}
			else
				m_Editors = null;
		}

		public void LoadList()
		{
			if (m_ItemType == null)
				throw new ApplicationException("ItemType is null");
			if (m_List == null)
				m_List = new ArrayList();

			if (m_Properties.Length != m_Editors.Length)
				throw new ApplicationException("Properteis.Length != Editors.Length");

			grid.FixedRows = 1;
			grid.FixedColumns = 0;
			grid.Redim(m_List.Count+grid.FixedRows, m_Properties.Length+grid.FixedColumns);

			//HeaderCell
			//grid[0,0] = new Cells.Header();
			for (int i = 0; i < m_Properties.Length; i++)
			{
                Cells.ColumnHeader l_Header;

                if (ItemType.Name == "ChartBar")
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        string[] na = { "名称", "值", "单位", "量纲" };
                        l_Header = new Cells.ColumnHeader(na[i]);
                    }
                    else
                    {
                        string[] na = { "Name", "Value", "Unit", "Dimension" };
                        l_Header = new Cells.ColumnHeader(na[i]);
                    }

                }
                else if(ItemType.Name == "ChartBarDefine")
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        string[] na = { "公式名称", "公式内容", "公式单位", "是否计算", "公式说明", "曲线显示", "量纲" };
                        l_Header = new Cells.ColumnHeader(na[i]);
                    }
                    else
                    {
                        string[] na = { "Formula name", "Formula content", "Formula unit", "Calculation", "Formula description", "Display on curves", "Dimension" };
                        l_Header = new Cells.ColumnHeader(na[i]);
                    }
                }
                else
                {
                    l_Header = new Cells.ColumnHeader(m_Properties[i].Name);
                }
				grid[0, i+grid.FixedColumns] = l_Header;

				l_Header.EnableSort = false;
//				//If the column type support the IComparable then I can use the value to sort the column, otherwise I use the string representation for sort.
//				if (typeof(IComparable).IsAssignableFrom(m_Properties[i].PropertyType))
//					l_Header.Comparer = new SourceGrid2.ValueCellComparer();
//				else
//					l_Header.Comparer = new SourceGrid2.DisplayStringCellComparer();
			}

			for (int r = 0; r < m_List.Count; r++)
			{
				PopulateRow(r+grid.FixedRows, m_List[r]);
			}
            grid.AutoStretchRowsToFitHeight = false;
          
			grid.AutoStretchColumnsToFitWidth = true  ;
            

            grid.AutoSizeAll(20, 20);
		}

		private void PopulateRow(int p_GridRow, object p_Object)
		{
			for (int c = 0; c < m_Properties.Length; c++)
			{
				PopulateCell(p_GridRow, c+grid.FixedColumns, m_Properties[c], m_Editors[c], p_Object);
			}
			grid.Rows[p_GridRow].Tag = p_Object;
		}

		private void PopulateCell(int p_GridRow, int p_GridCol, System.Reflection.PropertyInfo p_PropInfo, SourceGrid2.DataModels.IDataModel p_DataModel, object p_Object)
		{
           
                if ((grid.ColumnsCount > 0) && (p_GridCol == grid.ColumnsCount - 1))
                {
               
                  if (Convert.ToInt16(p_PropInfo.GetValue(p_Object, null))>=0 && Convert.ToInt16(p_PropInfo.GetValue(p_Object, null))< ClsStaticStation.m_Global.mycls.SignalsNames.Length)
                {
                    grid[p_GridRow, p_GridCol] = new Cells.Cell(ClsStaticStation.m_Global.mycls.SignalsNames[Convert.ToInt16(p_PropInfo.GetValue(p_Object, null))], p_DataModel);


                }
                else
                {
                    grid[p_GridRow, p_GridCol] = new Cells.Cell(ClsStaticStation.m_Global.mycls.SignalsNames[0], p_DataModel);

                }

                SourceGrid2.BehaviorModels.CustomEvents l_CustomEvents = new SourceGrid2.BehaviorModels.CustomEvents();
                    l_CustomEvents.ValueChanged += new SourceGrid2.PositionEventHandler(Grid_ValueChanged);
                    grid[p_GridRow, p_GridCol].Behaviors.Add(l_CustomEvents);


                }
                else
                {
                    grid[p_GridRow, p_GridCol] = new Cells.Cell(p_PropInfo.GetValue(p_Object, null), p_DataModel);
                    SourceGrid2.BehaviorModels.BindProperty l_Bind = new SourceGrid2.BehaviorModels.BindProperty(p_PropInfo, p_Object);
                    grid[p_GridRow, p_GridCol].Behaviors.Add(l_Bind);
                    SourceGrid2.BehaviorModels.CustomEvents l_CustomEvents = new SourceGrid2.BehaviorModels.CustomEvents();
                    l_CustomEvents.ValueChanged += new SourceGrid2.PositionEventHandler(Grid_ValueChanged);
                    grid[p_GridRow, p_GridCol].Behaviors.Add(l_CustomEvents);
                }
            
		}

		private void btAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				int l_Row = grid.RowsCount;
				grid.Rows.Insert(l_Row);
				object l_Obj = Activator.CreateInstance(m_ItemType);
				m_List.Add(l_Obj);
				PopulateRow(l_Row, l_Obj);

				OnListChanged(null, null );
			}
			catch(Exception err)
			{
				SourceLibrary.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}

        public delegate void ListEventHandler(object sender, SourceGrid2.PositionEventArgs e);
        public event ListEventHandler ListChanged;

		

		protected virtual void OnListChanged(object sender, SourceGrid2.PositionEventArgs e)
		{
			if (ListChanged!=null)
				ListChanged(this, e);
		}

		private void Grid_ValueChanged(object sender, SourceGrid2.PositionEventArgs e)
		{
            
			OnListChanged(e.Cell,  e );
            
            
            
		}

		private void btRemove_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (grid.FocusRow != null &&
					grid.FocusRow.Index >= grid.FixedRows)
				{
					m_List.Remove(grid.FocusRow.Tag);
					grid.Rows.Remove(grid.FocusRow.Index);

					OnListChanged(null, null);
				}
			}
			catch(Exception err)
			{
				SourceLibrary.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}

		private void btrRefreshList_Click(object sender, System.EventArgs e)
		{
			try
			{
				LoadList();
			}
			catch(Exception err)
			{
				SourceLibrary.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}

		private void btUp_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (grid.FocusRow != null &&
					grid.FocusRow.Index > grid.FixedRows)
				{
					object tag = grid.FocusRow.Tag;
					int l_GridIndex = grid.FocusRow.Index;
					int l_ListIndex = m_List.IndexOf(tag);
					m_List.Remove(tag);
					m_List.Insert(l_ListIndex-1, tag);
					grid.Rows.Move(l_GridIndex, l_GridIndex-1);
					grid.Rows[l_GridIndex-1].Focus();

					OnListChanged(null, null);
				}

			}
			catch(Exception err)
			{
				SourceLibrary.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}

		private void btDown_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (grid.FocusRow != null &&
					grid.FocusRow.Index >= grid.FixedRows &&
					grid.FocusRow.Index < grid.RowsCount-1)
				{
					object tag = grid.FocusRow.Tag;
					int l_GridIndex = grid.FocusRow.Index;
					int l_ListIndex = m_List.IndexOf(tag);
					m_List.Remove(tag);
					m_List.Insert(l_ListIndex+1, tag);
					grid.Rows.Move(l_GridIndex, l_GridIndex+1);
					grid.Rows[l_GridIndex+1].Focus();

					OnListChanged(null, null);
				}
			}
			catch(Exception err)
			{
				SourceLibrary.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}

		private void grid_CellGotFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
		{
            row = e.Position.Row; 
			btDown.Enabled = true;
			btUp.Enabled = true;
			btRemove.Enabled = true;

            
		}

		private void grid_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
		{
            row = e.Position.Row;

			btDown.Enabled = false;
			btUp.Enabled = false;
			btRemove.Enabled = false;

       
        }



	}
}
