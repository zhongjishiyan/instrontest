namespace TabHeaderDemo
{
    partial class UserControlResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlResult));
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid1 = new SourceGrid2.Grid();
            this.grid2 = new SourceGrid2.Grid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "结果1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Selector_Status_Tested.ico");
            this.imageList1.Images.SetKeyName(1, "Selector_Status_Tested_Rejected.ico");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 21);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grid2);
            this.splitContainer1.Size = new System.Drawing.Size(457, 407);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 5;
            // 
            // grid1
            // 
            this.grid1.AutoSizeMinHeight = 10;
            this.grid1.AutoSizeMinWidth = 10;
            this.grid1.AutoStretchColumnsToFitWidth = true;
            this.grid1.AutoStretchRowsToFitHeight = false;
            this.grid1.BackColor = System.Drawing.Color.White;
            this.grid1.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid1.CustomSort = false;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid1.GridToolTipActive = true;
            this.grid1.Location = new System.Drawing.Point(0, 0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(457, 195);
            this.grid1.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V)
                        | SourceGrid2.GridSpecialKeys.Ctrl_X)
                        | SourceGrid2.GridSpecialKeys.Delete)
                        | SourceGrid2.GridSpecialKeys.Arrows)
                        | SourceGrid2.GridSpecialKeys.Tab)
                        | SourceGrid2.GridSpecialKeys.PageDownUp)
                        | SourceGrid2.GridSpecialKeys.Enter)
                        | SourceGrid2.GridSpecialKeys.Escape)));
            this.grid1.TabIndex = 9;
            this.grid1.HScrollPositionChanged += new SourceGrid2.ScrollPositionChangedEventHandler(this.grid1_HScrollPositionChanged);
            // 
            // grid2
            // 
            this.grid2.AutoSizeMinHeight = 10;
            this.grid2.AutoSizeMinWidth = 10;
            this.grid2.AutoStretchColumnsToFitWidth = true;
            this.grid2.AutoStretchRowsToFitHeight = false;
            this.grid2.BackColor = System.Drawing.Color.White;
            this.grid2.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid2.CustomSort = false;
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.FocusStyle = SourceGrid2.FocusStyle.None;
            this.grid2.GridToolTipActive = true;
            this.grid2.Location = new System.Drawing.Point(0, 0);
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(457, 208);
            this.grid2.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V)
                        | SourceGrid2.GridSpecialKeys.Ctrl_X)
                        | SourceGrid2.GridSpecialKeys.Delete)
                        | SourceGrid2.GridSpecialKeys.Arrows)
                        | SourceGrid2.GridSpecialKeys.Tab)
                        | SourceGrid2.GridSpecialKeys.PageDownUp)
                        | SourceGrid2.GridSpecialKeys.Enter)
                        | SourceGrid2.GridSpecialKeys.Escape)));
            this.grid2.TabIndex = 10;
            this.grid2.VScrollPositionChanged += new SourceGrid2.ScrollPositionChangedEventHandler(this.grid2_VScrollPositionChanged);
            this.grid2.HScrollPositionChanged += new SourceGrid2.ScrollPositionChangedEventHandler(this.grid2_HScrollPositionChanged);
            // 
            // UserControlResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlResult";
            this.Size = new System.Drawing.Size(457, 428);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public SourceGrid2.Grid grid1;
        public SourceGrid2.Grid grid2;

    }
}
