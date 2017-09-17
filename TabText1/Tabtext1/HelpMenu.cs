using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class HelpMenu : MenuStrip
    {
        private ToolStripMenuItem backToolStripMenuItem;

        public HelpMenu()
        {
            backToolStripMenuItem = new ToolStripMenuItem();
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            backToolStripMenuItem.Text = "Back";
            // 
            // menuStrip1
            // 
            Items.Add(backToolStripMenuItem);
            Location = new System.Drawing.Point(0, 0);
            Name = "menuStrip1";
            Size = new System.Drawing.Size(292, 24);
            TabIndex = 1;
            Text = "";
            SuspendLayout();

        }

    }
}
