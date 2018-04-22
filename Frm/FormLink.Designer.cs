namespace TabHeaderDemo.Frm
{
    partial class FormLink
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
            this.label2 = new TabHeaderDemo.WordArt();
            this.progress_CPI = new CircularIndeterminateProgress.CircularIndeterminateProgress();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Caption = "请等待....";
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(307, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 100);
            this.label2.TabIndex = 2;
            this.label2.WordArtBackColor = System.Drawing.Color.Maroon;
            this.label2.WordArtEffect = TabHeaderDemo.WordArtEffectStyle.slope;
            this.label2.WordArtFont = new System.Drawing.Font("宋体", 15F);
            this.label2.WordArtForeColor = System.Drawing.Color.Black;
            this.label2.WordArtSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.label2.WordArtTextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // progress_CPI
            // 
            this.progress_CPI.Animate = false;
            this.progress_CPI.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.progress_CPI.CirclesCount = 8;
            this.progress_CPI.ControlWidthHeight = 160;
            this.progress_CPI.IndicatorColor = System.Drawing.Color.Green;
            this.progress_CPI.IndicatorDiameter = 30;
            this.progress_CPI.IndicatorType = CircularIndeterminateProgress.CircularIndeterminateProgress.INDICATORTYPES.PULSED;
            this.progress_CPI.Location = new System.Drawing.Point(35, 22);
            this.progress_CPI.Margin = new System.Windows.Forms.Padding(2);
            this.progress_CPI.Name = "progress_CPI";
            this.progress_CPI.Size = new System.Drawing.Size(160, 160);
            this.progress_CPI.TabIndex = 1;
            // 
            // FormLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(545, 207);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progress_CPI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联机";
            this.Load += new System.EventHandler(this.FormLink_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormLink_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularIndeterminateProgress.CircularIndeterminateProgress progress_CPI;
        public WordArt label2;
    }
}