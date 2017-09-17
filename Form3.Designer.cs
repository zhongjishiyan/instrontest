namespace TabHeaderDemo
{
    partial class FormHand
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
            this.paneltest = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // paneltest
            // 
            this.paneltest.BackColor = System.Drawing.Color.Transparent;
            this.paneltest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneltest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneltest.Location = new System.Drawing.Point(0, 0);
            this.paneltest.Name = "paneltest";
            this.paneltest.Size = new System.Drawing.Size(485, 565);
            this.paneltest.TabIndex = 33;
            this.paneltest.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltest_Paint);
            // 
            // FormHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 565);
            this.Controls.Add(this.paneltest);
            this.Name = "FormHand";
            this.Text = "手动控制";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel paneltest;








    }
}