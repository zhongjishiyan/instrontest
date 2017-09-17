using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Compenkie;

namespace AppleLabApplication
{
    public partial class SearchAndReplace : Form
    {
        public int index;
        int allPageIndex = 0;
        public int maxTab;
        public RichTextBoxExtend[] boxen;
        public TabPage[] pages;
        int positie = 0;
        public string language;

        public SearchAndReplace()
        {
            InitializeComponent();
        }

        private void toolStripbtnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            switch (language)
            {
                case "Nederlands":
                    {
                        Nederlands();
                        break;
                    }
                case "English":
                    {
                        English();
                        break;
                    }
            }

            //            richTextBox.AppendRtf(boxen[index].Rtf.ToString() );
            this.Controls.Clear();
            this.Controls.Add(boxen[index]);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(toolStrip2);
            toolStripbtnZoekverderinPaginas.Enabled = false;

        }

        private void toolStripbtnSearch_Click(object sender, EventArgs e)
        {
            positie++;
            positie = boxen[index].FindMyText(toolStripTextBoxZoeken.Text, positie, boxen[index].Text.Length, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[index].Focus();
 
       }

        private void toolStripntnChange_Click(object sender, EventArgs e)
        {
            boxen[index].FindAndReplace(toolStripTextBoxZoeken.Text, toolStripTextBoxVervangen.Text, false, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[index].Focus();
 
        }

        private void toolStripbtnChangeAll_Click(object sender, EventArgs e)
        {
            boxen[index].FindAndReplace(toolStripTextBoxZoeken.Text, toolStripTextBoxVervangen.Text, true, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[index].Focus();

 
        }

        private void toolStripbtnChangeAllPages_Click(object sender, EventArgs e)
        {
            int aantal = 0;
            allPageIndex = 0;
            this.Controls.Clear();
            this.Controls.Add(boxen[allPageIndex]);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(toolStrip2);
            toolStripTextBoxPagenummer.Text = pages[allPageIndex].Text.ToString();

            aantal += boxen[allPageIndex].FindAndReplace(toolStripTextBoxZoeken.Text, toolStripTextBoxVervangen.Text, true, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[allPageIndex].Focus();
            toolStripbtnZoekAllePaginas.Enabled = false;
            toolStripbtnZoekverderinPaginas.Enabled = true;
            while (allPageIndex < maxTab)
            {
                pages[allPageIndex].Controls.Add(boxen[allPageIndex]);
                allPageIndex++;
                this.Controls.Clear();
                this.Controls.Add(boxen[allPageIndex]);
                this.Controls.Add(toolStrip1);
                this.Controls.Add(toolStrip2);
                toolStripTextBoxPagenummer.Text = pages[allPageIndex].Text.ToString();
                aantal += boxen[allPageIndex].FindAndReplace(toolStripTextBoxZoeken.Text, toolStripTextBoxVervangen.Text, true, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
                boxen[allPageIndex].Focus();
            }
                pages[allPageIndex].Controls.Add(boxen[allPageIndex]);
            toolStripbtnZoekAllePaginas.Enabled = true;
            toolStripbtnZoekverderinPaginas.Enabled = false;
            this.Controls.Clear();
            this.Controls.Add(boxen[index]);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(toolStrip2);
            toolStripTextBoxPagenummer.Text = pages[index].Text.ToString();
            Focus();
            MessageBox.Show(aantal.ToString() + "wijzigingen");
            return;
        }

        private void toolStripbtnZoekAllePaginas_Click(object sender, EventArgs e)
        {
            allPageIndex = 0;
            positie++;
            this.Controls.Clear();
            this.Controls.Add(boxen[allPageIndex]);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(toolStrip2);
            toolStripTextBoxPagenummer.Text = pages[allPageIndex].Text.ToString();

            positie = boxen[allPageIndex].FindMyText(toolStripTextBoxZoeken.Text, positie, boxen[allPageIndex].Text.Length, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[allPageIndex].Focus();
            toolStripbtnZoekAllePaginas.Enabled = false;
            toolStripbtnZoekverderinPaginas.Enabled = true;
            while (positie == -1)
                if (allPageIndex + 1 > maxTab)
                {
                    toolStripbtnZoekAllePaginas.Enabled = true;
                    toolStripbtnZoekverderinPaginas.Enabled = false;
                    this.Controls.Clear();
                    this.Controls.Add(boxen[index]);
                    this.Controls.Add(toolStrip1);
                    this.Controls.Add(toolStrip2);
                    toolStripTextBoxPagenummer.Text = pages[index].Text.ToString();
                    Focus();
                    MessageBox.Show("Alle pagina's doorzocht");
                    return;
                }
                else
                {
                    pages[allPageIndex].Controls.Add(boxen[allPageIndex]);
                    allPageIndex++;
                    this.Controls.Clear();
                    this.Controls.Add(boxen[allPageIndex]);
                    this.Controls.Add(toolStrip1);
                    this.Controls.Add(toolStrip2);
                    toolStripTextBoxPagenummer.Text = pages[allPageIndex].Text.ToString();
                    positie++;
                    positie = boxen[allPageIndex].FindMyText(toolStripTextBoxZoeken.Text, positie, boxen[allPageIndex].Text.Length, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
                    boxen[allPageIndex].Focus();
                }
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pages[index].Controls.Add(boxen[index]);
        }

        private void toolStripbtnZoekverderinPaginas_Click(object sender, EventArgs e)
        {

            positie++;
            positie = boxen[allPageIndex].FindMyText(toolStripTextBoxZoeken.Text, positie, boxen[allPageIndex].Text.Length, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
            boxen[allPageIndex].Focus();
            while (positie == -1)
                if (allPageIndex + 1 > maxTab)
                {
                    toolStripbtnZoekAllePaginas.Enabled = true;
                    toolStripbtnZoekverderinPaginas.Enabled = false;
                    this.Controls.Clear();
                    this.Controls.Add(boxen[index]);
                    this.Controls.Add(toolStrip1);
                    this.Controls.Add(toolStrip2);
                    toolStripTextBoxPagenummer.Text = pages[index].Text.ToString();
                    Focus();
                    MessageBox.Show("Alle pagina's doorzocht");
                    return;
                }
                else
                {
                    pages[allPageIndex].Controls.Add(boxen[allPageIndex]);
                    allPageIndex++;
                    this.Controls.Clear();
                    this.Controls.Add(boxen[allPageIndex]);
                    this.Controls.Add(toolStrip1);
                    this.Controls.Add(toolStrip2);
                    toolStripTextBoxPagenummer.Text = pages[allPageIndex].Text.ToString();
                    positie++;
                    positie = boxen[allPageIndex].FindMyText(toolStripTextBoxZoeken.Text, positie, boxen[allPageIndex].Text.Length, toolStripButtonCaseSenvity.Checked, toolStripButtonWholeWord.Checked);
                    boxen[allPageIndex].Focus();
                }
        }

        void Nederlands()
        {
            // 
            // toolStripbtnSluiten
            // 
           this.toolStripbtnSluiten.Text = "Sluiten";
            // 
            // toolStripbtnSearch
            // 
            this.toolStripbtnSearch.Text = "Zoeken";
            // 
            // toolStripbtnZoekAllePaginas
            // 
            this.toolStripbtnZoekAllePaginas.Text = "Zoek in alle pagina\'s";
            // 
            // toolStripbtnChange
            // 
            this.toolStripbtnChange.Text = "Vervangen";
            // 
            // toolStripbtnChangeAll
            // 
            this.toolStripbtnChangeAll.Text = "Vervang alles";
            // 
            // toolStripbtnChangeAllPages
            // 
            this.toolStripbtnChangeAllPages.Text = "Vervang alles in alle pagina\'s";
            // 
            // toolStripTextBoxPagenummer
            // 
            this.toolStripTextBoxPagenummer.Name = "toolStripTextBoxPagenummer";
            this.toolStripTextBoxPagenummer.Size = new System.Drawing.Size(140, 23);
            // 
            // toolStripComboHeelWoord
            // 
            this.toolStripButtonWholeWord.Text = "Hele woord";
          // 
            // toolStripComboHoofdLetters
            // 
            this.toolStripButtonCaseSenvity.Text = "Hoofletter gevoelig";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Text = "Zoektekst";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Text = "Vervangtekst";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Text = "Document";
           // 
            // toolStripbtnZoekverderinPaginas
            // 
            this.toolStripbtnZoekverderinPaginas.Text = "Zoek verder in pagina\'s";
            this.Text = "Zoeken en vervangen";
        }

        void English()
        {
            // 
            // toolStripbtnSluiten
            // 
           this.toolStripbtnSluiten.Text = "Close";
            // 
            // toolStripbtnSearch
            // 
            this.toolStripbtnSearch.Text = "Search";
            // 
            // toolStripbtnZoekAllePaginas
            // 
            this.toolStripbtnZoekAllePaginas.Text = "Search in all pages";
            // 
            // toolStripbtnChange
            // 
            this.toolStripbtnChange.Text = "Replace";
            // 
            // toolStripbtnChangeAll
            // 
            this.toolStripbtnChangeAll.Text = "Replace all";
            // 
            // toolStripbtnChangeAllPages
            // 
            this.toolStripbtnChangeAllPages.Text = "Replace all in all pages";
            // 
            // toolStripComboHeelWoord
            // 
           this.toolStripButtonWholeWord.Text = "Whole word";
          // 
            // toolStripComboHoofdLetters
            // 
            this.toolStripButtonCaseSenvity.Text = "Cace sensivity";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Text = "Search";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Text = "Replace";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Text = "Document";
           // 
            // toolStripbtnZoekverderinPaginas
            // 
            this.toolStripbtnZoekverderinPaginas.Text = "Search next";
            this.Text = "Search and replace";
        }

        private void toolStripButtonWholeWord_Click(object sender, EventArgs e)
        {
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;

        }

        private void toolStripButtonCaseSenvity_Click(object sender, EventArgs e)
        {
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;

        }

    }
}

