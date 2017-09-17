namespace TabHeaderDemo
{
    partial class Form仿真
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
            this.switch1 = new NationalInstruments.UI.WindowsForms.Switch();
            this.led1 = new NationalInstruments.UI.WindowsForms.Led();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            this.SuspendLayout();
            // 
            // switch1
            // 
            this.switch1.Location = new System.Drawing.Point(243, 12);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(64, 72);
            this.switch1.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalToggle3D;
            this.switch1.TabIndex = 0;
            this.switch1.StateChanged += new NationalInstruments.UI.ActionEventHandler(this.switch1_StateChanged);
            // 
            // led1
            // 
            this.led1.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led1.Location = new System.Drawing.Point(97, 34);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(40, 41);
            this.led1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "仿真";
            // 
            // Form仿真
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.switch1);
            this.Name = "Form仿真";
            this.Text = "Form仿真";
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Switch switch1;
        private NationalInstruments.UI.WindowsForms.Led led1;
        private System.Windows.Forms.Label label1;
    }
}