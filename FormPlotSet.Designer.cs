namespace TabHeaderDemo
{
    partial class FormPlotSet
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
            this.lblname = new System.Windows.Forms.Label();
            this.propertyEditor1 = new NationalInstruments.UI.WindowsForms.PropertyEditor();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(93, 41);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(65, 12);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "属性名称：";
            this.lblname.Visible = false;
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Location = new System.Drawing.Point(95, 70);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(342, 21);
            this.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.button2, "BackColor");
            this.propertyEditor1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormPlotSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 236);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.propertyEditor1);
            this.Controls.Add(this.lblname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPlotSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label lblname;
        public NationalInstruments.UI.WindowsForms.PropertyEditor propertyEditor1;
    }
}