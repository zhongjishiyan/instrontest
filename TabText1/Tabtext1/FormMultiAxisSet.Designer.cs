namespace AppleLabApplication
{
    partial class FormMultiAxisSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiAxisSet));
            this.grid1 = new SourceGrid2.Grid();
            this.grid2 = new SourceGrid2.Grid();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // grid1
            // 
            resources.ApplyResources(this.grid1, "grid1");
            this.grid1.AutoSizeMinHeight = 10;
            this.grid1.AutoSizeMinWidth = 10;
            this.grid1.AutoStretchColumnsToFitWidth = false;
            this.grid1.AutoStretchRowsToFitHeight = false;
            this.grid1.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid1.CustomSort = false;
            this.grid1.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid1.GridToolTipActive = true;
            this.grid1.Name = "grid1";
            this.grid1.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape)));
            // 
            // grid2
            // 
            resources.ApplyResources(this.grid2, "grid2");
            this.grid2.AutoSizeMinHeight = 10;
            this.grid2.AutoSizeMinWidth = 10;
            this.grid2.AutoStretchColumnsToFitWidth = true;
            this.grid2.AutoStretchRowsToFitHeight = false;
            this.grid2.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid2.CustomSort = false;
            this.grid2.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid2.GridToolTipActive = true;
            this.grid2.Name = "grid2";
            this.grid2.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape)));
            this.grid2.CellGotFocus += new SourceGrid2.PositionCancelEventHandler(this.grid2_CellGotFocus);
            this.grid2.CellLostFocus += new SourceGrid2.PositionCancelEventHandler(this.grid2_CellLostFocus);
            this.grid2.LocationChanged += new System.EventHandler(this.grid2_LocationChanged);
            this.grid2.Paint += new System.Windows.Forms.PaintEventHandler(this.grid2_Paint);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMultiAxisSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.grid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMultiAxisSet";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid2.Grid grid1;
        private SourceGrid2.Grid grid2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
    }
}