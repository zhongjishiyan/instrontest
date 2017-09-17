namespace AppleLabApplication
{
    partial class Form1
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
            this.workSheet12 = new SampleProject.Extensions.WorkSheet1();
            this.SuspendLayout();
            // 
            // workSheet12
            // 
            this.workSheet12.BackColor = System.Drawing.Color.DimGray;
            this.workSheet12.Location = new System.Drawing.Point(56, 33);
            this.workSheet12.Name = "workSheet12";
            this.workSheet12.Size = new System.Drawing.Size(381, 213);
            this.workSheet12.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 273);
            this.Controls.Add(this.workSheet12);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SampleProject.Extensions.WorkSheet1 workSheet11;
        private SampleProject.Extensions.WorkSheet1 workSheet12;

























    }
}