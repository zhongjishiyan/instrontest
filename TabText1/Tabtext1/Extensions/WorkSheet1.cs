using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SampleProject.Extensions
{
	/// <summary>
	/// Summary description for WorkSheet.
	/// </summary>
	public class WorkSheet1 : System.Windows.Forms.UserControl
	{
        private SourceGrid2.GridVirtual grid;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WorkSheet1()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			grid.FixedRows = 1;
			grid.FixedColumns = 1;
			grid.Redim(10,5);
			m_Data = new string[10, 5];

           
			m_Cell = new WorkSheetCell(this);

           // (m_Cell.VisualModel as SourceGrid2.VisualModels.Common).BorderColor = Color.Red;
			m_Cell.BindToGrid(grid);
             
           
            
           // grid.ScrollablePanel.BackColor = Color.Transparent;
             
           
         //  grid.Columns[0].Width = 0;
        //   grid.Rows[0].Height = 0;

           
            
           
            grid.SizeChanged += new EventHandler(grid_SizeChanged);
           
			//m_Column = new WorkSheetColumn();
			//m_Column.BindToGrid(grid);
			//m_Row = new WorkSheetRow();
		//	m_Row.BindToGrid(grid);
		//	m_Header = new WorkSheetHeader();
		//	m_Header.BindToGrid(grid);
		}

        void grid_SizeChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 1; i < grid.ColumnsCount; i++)
            {
               grid.Columns[i].Width = (grid.Width-2)/ (grid.ColumnsCount-1); 
              
            }

            for (i = 1; i < grid.RowsCount; i++)
            {
                grid.Rows[i].Height  = (grid.Height - 2) / (grid.RowsCount-1);

            }

            
 
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            this.grid = new SourceGrid2.GridVirtual();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BackColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(384, 352);
            this.grid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V)
                        | SourceGrid2.GridSpecialKeys.Ctrl_X)
                        | SourceGrid2.GridSpecialKeys.Delete)
                        | SourceGrid2.GridSpecialKeys.Arrows)
                        | SourceGrid2.GridSpecialKeys.Tab)
                        | SourceGrid2.GridSpecialKeys.PageDownUp)
                        | SourceGrid2.GridSpecialKeys.Enter)
                        | SourceGrid2.GridSpecialKeys.Escape)));
            this.grid.TabIndex = 0;
            this.grid.Paint += new System.Windows.Forms.PaintEventHandler(this.grid_Paint);
            this.grid.GettingCell += new SourceGrid2.PositionEventHandler(this.grid_GettingCell);
            this.grid.SettingCell += new SourceGrid2.PositionEventHandler(this.grid_SettingCell);
            // 
            // WorkSheet1
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grid);
            this.Name = "WorkSheet1";
            this.Size = new System.Drawing.Size(384, 352);
            this.ResumeLayout(false);

		}
		#endregion

		public static string ConvertColumnIndexToCaption(int p_Col)
		{
			int l_NumLap = ((p_Col-1) / 26);
			int l_Remainder = (p_Col) - (l_NumLap * 26);
			string l_tmp = "";
			if (l_NumLap>0)
				l_tmp += ConvertColumnIndexToCaption(l_NumLap);

			l_tmp += new string((char)('A'+l_Remainder-1),1);
			return l_tmp;
		}

		private string[,] m_Data;
		private WorkSheetCell m_Cell;
		private WorkSheetColumn m_Column;
		private WorkSheetRow m_Row;
		private WorkSheetHeader m_Header;

		private void grid_GettingCell(object sender, SourceGrid2.PositionEventArgs e)
		{
			if (e.Position.Row < grid.FixedRows && e.Position.Column < grid.FixedColumns)
				e.Cell = m_Header;
			else if (e.Position.Row < grid.FixedRows)
				e.Cell = m_Column;
			else if (e.Position.Column < grid.FixedColumns)
				e.Cell = m_Row;
			else
				e.Cell = m_Cell;
		}

		private class WorkSheetCell : SourceGrid2.Cells.Virtual.CellVirtual
		{
			private WorkSheet1 m_Worksheet;


			public WorkSheetCell(WorkSheet1 p_WorkSheet)
			{
				m_Worksheet = p_WorkSheet;
                
				DataModel = SourceGrid2.Utility.CreateDataModel(typeof(string));
               
                 
                 
			}

			public override object GetValue(SourceGrid2.Position p_Position)
			{
				return m_Worksheet.m_Data[p_Position.Row-1, p_Position.Column-1];
			}

			public override void SetValue(SourceGrid2.Position p_Position, object p_Value)
			{
				if (p_Value is String)
				{
					m_Worksheet.m_Data[p_Position.Row-1, p_Position.Column-1] = (string)p_Value;
					OnValueChanged(new SourceGrid2.PositionEventArgs(p_Position, this));
				}
				else if (p_Value == null)
				{
					m_Worksheet.m_Data[p_Position.Row-1, p_Position.Column-1] = "";
					OnValueChanged(new SourceGrid2.PositionEventArgs(p_Position, this));
				}
			}
		}
		private class WorkSheetColumn : SourceGrid2.Cells.Virtual.ColumnHeader
		{
			public WorkSheetColumn()
			{
				TextAlignment = ContentAlignment.MiddleCenter;
			}

			public override object GetValue(SourceGrid2.Position p_Position)
			{
				return WorkSheet1.ConvertColumnIndexToCaption(p_Position.Column);
			}
			public override void SetValue(SourceGrid2.Position p_Position, object p_Value)
			{
			
			}
			public override SourceGrid2.SortStatus GetSortStatus(SourceGrid2.Position p_Position)
			{
				return new SourceGrid2.SortStatus (SourceGrid2.GridSortMode.None, false);
			}
			public override void SetSortMode(SourceGrid2.Position p_Position, SourceGrid2.GridSortMode p_Mode)
			{
			}
		}
		private class WorkSheetRow : SourceGrid2.Cells.Virtual.RowHeader
		{
			public override object GetValue(SourceGrid2.Position p_Position)
			{
				return p_Position.Row;
			}		
			public override void SetValue(SourceGrid2.Position p_Position, object p_Value)
			{
			
			}
		}
		private class WorkSheetHeader : SourceGrid2.Cells.Virtual.Header
		{
			public override object GetValue(SourceGrid2.Position p_Position)
			{
				return null;
			}		
			public override void SetValue(SourceGrid2.Position p_Position, object p_Value)
			{
			
			}
		}

        private void grid_Paint(object sender, PaintEventArgs e)
        {
              
        }

        private void grid_SettingCell(object sender, SourceGrid2.PositionEventArgs e)
        {
           
        }
	}
}
