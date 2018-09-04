namespace AppleLabApplication
{
    partial class FormSpeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpeInput));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblcaption = new System.Windows.Forms.Label();
            this.txtvalue = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.lblcaption);
            this.panel1.Name = "panel1";
            // 
            // lblcaption
            // 
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.Name = "lblcaption";
            // 
            // txtvalue
            // 
            resources.ApplyResources(this.txtvalue, "txtvalue");
            this.txtvalue.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.txtvalue.Name = "txtvalue";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSpeInput
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSpeInput";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public NationalInstruments.UI.WindowsForms.NumericEdit txtvalue;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblcaption;
    }
}