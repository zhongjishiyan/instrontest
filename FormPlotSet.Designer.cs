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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlotSet));
            this.lblname = new System.Windows.Forms.Label();
            this.propertyEditor1 = new NationalInstruments.UI.WindowsForms.PropertyEditor();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblname
            // 
            resources.ApplyResources(this.lblname, "lblname");
            this.lblname.Name = "lblname";
            // 
            // propertyEditor1
            // 
            resources.ApplyResources(this.propertyEditor1, "propertyEditor1");
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.button2, "BackColor");
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormPlotSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.propertyEditor1);
            this.Controls.Add(this.lblname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPlotSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label lblname;
        public NationalInstruments.UI.WindowsForms.PropertyEditor propertyEditor1;
    }
}