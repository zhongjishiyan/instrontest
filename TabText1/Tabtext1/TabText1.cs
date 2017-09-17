using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
//using TabText1.Properties;
using AppleLabApplication.Properties; 
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Resources;
using System.Reflection;
using System.Threading;
using Compenkie;
using Microsoft.VisualBasic.Devices;

namespace AppleLabApplication
{
    public partial class TabText1 : Form
    {
        #region variables

        
        public RichTextBoxExtend[] richTextBox = new RichTextBoxExtend[17];
        TabPage[] tabPages = new TabPage[17];
        public HelpControl helpControl = new HelpControl();
        public HelpMenu helpMenu = new HelpMenu();
        public Keyboard board = new Keyboard();
        int maxTab = 0;
        TextBox box;
        int index;
        private int m_nFirstCharOnPage;
        string language;
        Rectangle rectNormal;
        string[] kleur = new string[]{"AliceBlue","AntiqueWhite","Aqua","Aquamarine","Azure",
            "Beige","Bisque","Black","BlanchedAlmond","Blue","BlueViolet","Brown","BurlyWood"
            ,"CadetBlue","Chartreuse","Chocolate","Coral","CornflowerBlue","Cornsilk","Crimson"
            ,"Cyan","DarkBlue","DarkCyan","DarkGoldenrod","DarkGray","DarkGreen","DarkKhaki"
            ,"DarkMagenta","DarkOliveGreen","DarkOrange","DarkOrchid","DarkRed","DarkSalmon"
            ,"DarkSeaGreen","DarkSlateBlue","DarkSlateGray","DarkTurquoise","DarkViolet","DeepPink"
            ,"DeepSkyBlue","DimGray","DodgerBlue","Firebrick","FloralWhite","ForestGreen","Fuchsia"
            ,"Gainsboro","GhostWhite","Gold","Goldenrod","Gray","Green","GreenYellow","Honeydew"
            ,"HotPink","IndianRed","Indigo","Ivory","Khaki","Lavender","LavenderBlush","LawnGreen"
            ,"LemonChiffon","LightBlue","LightCoral","LightCyan","LightGoldenrodYellow","LightGray"
            ,"LightGreen","LightPink","LightSalmon","LightSeaGreen","LightSkyBlue","LightSlateGray"
            ,"LightSteelBlue","LightYellow","Lime","LimeGreen","Linen","Magenta","Maroon"
            ,"MediumAquamarine","MediumBlue","MediumOrchid","MediumPurple","MediumSeaGreen"
            ,"MediumSlateBlue","MediumSpringGreen","MediumTurquoise","MediumVioletRed","MidnightBlue"
            ,"MintCream","MistyRose","Moccasin","NavajoWhite","Navy","OldLace","Olive","OliveDrab"
            ,"Orange","OrangeRed","Orchid","PaleGoldenrod","PaleGreen","PaleTurquoise","PaleVioletRed"
            ,"PapayaWhip","PeachPuff","Peru","Pink","Plum","PowderBlue","Purple","Red","RosyBrown"
            ,"RoyalBlue","SaddleBrown","Salmon","SandyBrown","SeaGreen","SeaShell","Sienna","Silver"
            ,"SkyBlue","SlateBlue","SlateGray","Snow","SpringGreen","SteelBlue","Tan","Teal","Thistle"
            ,"Tomato","Transparent","Turquoise","Violet","Wheat","White","WhiteSmoke","Yellow","YellowGreen"};

        int imageCounter = 0;
        int maxImage = 100;
        public ImageInfo[] images;


        private ToolStripMenuItem[] recentFiles = new ToolStripMenuItem[11];
        int maxRecent;

        private string documentDir = null;
        private string filenaamEmoticons = "<Default>";
        private string filenameTextFragments = "<Default>";
        bool standaard = true;

        string strRegKey = "Software\\Compenkie\\TabText1\\";
        // Strings for registry
        const string strWinState = "WindowState";
        const string strLocationX = "LocationX";
        const string strLocationY = "LocationY";
        const string strWidth = "Width";
        const string strHeight = "Height";
        const string strWordWrap = "WordWrap";
        const string strFontFace = "FontFace";
        const string strFontSize = "FontSize";
        const string strFontStyle = "FontStyle";
        const string strForeColor = "ForeColor";
        const string strBackColor = "BackColor";
        const string strCustomClr = "CustomColor";

        protected string strProgName = "TabText1";
        protected string strFileName;

        Image image;

        Form showForm;
        int numberColums;
        int numberRows;


          

        #endregion



        public TabText1()
        {
            

            InitializeComponent();
            
            Application.DoEvents();
            for (int teller = 0; teller < 17; teller++)
            {
                richTextBox[teller] = new RichTextBoxExtend();
                // 
                // richTextBox1
                // 
                
                richTextBox[teller].AcceptsTab = true;
                richTextBox[teller].Dock = System.Windows.Forms.DockStyle.Fill;
                richTextBox[teller].Location = new System.Drawing.Point(3, 3);
                richTextBox[teller].Name = "richTextBox" + teller.ToString();
                richTextBox[teller].Size = new System.Drawing.Size(397, 380);
                richTextBox[teller].TabIndex = teller;
                richTextBox[teller].TabStop = true;
                richTextBox[teller].Text = "";
                richTextBox[teller].SelectionChanged += new EventHandler(TabText1_SelectionChanged);
                richTextBox[teller].CursorPositionChanged += new EventHandler(TabText1_CursorPositionChanged);
                richTextBox[teller].AllowDrop = false;
                richTextBox[teller].DragDrop += new DragEventHandler(TabText1_DragDrop);
                richTextBox[teller].DragEnter += new DragEventHandler(TabText1_DragEnter);
                richTextBox[teller].Settings.Keywords.Add("function");
                richTextBox[teller].Settings.Keywords.Add("if");
                richTextBox[teller].Settings.Keywords.Add("then");
                richTextBox[teller].Settings.Keywords.Add("else");
                richTextBox[teller].Settings.Keywords.Add("elseif");
                richTextBox[teller].Settings.Keywords.Add("end");

                richTextBox[teller].Settings.Comment = "//";

                // Set the colors that will be used.
                richTextBox[teller].Settings.KeywordColor = Color.Blue;
                richTextBox[teller].Settings.CommentColor = Color.Green;
                richTextBox[teller].Settings.StringColor = Color.Gray;
                richTextBox[teller].Settings.IntegerColor = Color.Red;

                // Let's not process strings and integers.
                richTextBox[teller].Settings.EnableStrings = true ;
                richTextBox[teller].Settings.EnableIntegers = true ;

                // Let's make the settings we just set valid by compiling
                // the keywords to a regular expression.
                richTextBox[teller].CompileKeywords();

                // Load a file and update the syntax highlighting.
                //m_syntaxRichTextBox.LoadFile("script.txt", RichTextBoxStreamType.PlainText);
                richTextBox[teller].ProcessAllLines();


            }
            addComboboxLetters();
            addComboboxkleur();

            timer.Start();

            defaultTextFragments();

            splitContainer.SplitterDistance = splitContainer.Size.Width;
            formatleftToolStripButton.Checked = true;

            helpMenu.Click += new System.EventHandler(backToolStripMenuItem_Click);
        }


        #region File-menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Clear();
            for (int teller = 0; teller < 17; teller++)
                richTextBox[teller].Clear();
            maxTab = 0;
            AddPage(maxTab++);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;
            if (tab == null)
                AddPage(maxTab++);
            else
                openFileDialog.FileName = tab.Text;

            // Initialize the OpenFileDialog to look for RTF files.
            openFileDialog.InitialDirectory = documentDir;
            openFileDialog.DefaultExt = "*.rtf";
            openFileDialog.Filter = "RTF bestanden (*.rtf)|*.rtf|" + "Tekst Bestanden|*.txt";

            // Determine whether the user selected a file from the OpenFileDialog.
            openFileDialog.ShowDialog();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;
            if (tab.Text.Length > 0)
            {
                saveFile(tab);
                
            }
            else
            {
                // Initialize the SaveFileDialog to specify the RTF extention for the file.
                saveFileDialog.InitialDirectory = documentDir;
                saveFileDialog.DefaultExt = "*.rtf";
                saveFileDialog.Filter = "RTF bestanden (*.rtf)|*.rtf|" + "Tekst Bestanden|*.txt";
                saveFileDialog.FileName = tab.Text;

                // Determine whether the user selected a file name from the saveFileDialog.
                saveFileDialog.ShowDialog();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFileDialog.InitialDirectory = documentDir;
            saveFileDialog.DefaultExt = "*.rtf";
            saveFileDialog.Filter = "RTF bestanden (*.rtf)|*.rtf|" + "Tekst Bestanden|*.txt";
            saveFileDialog.FileName = tab.Text;

            // Determine whether the user selected a file name from the saveFileDialog.
            saveFileDialog.ShowDialog();

        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAll();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;
            saveFile(tab);
            int index = ZoekTab();
            tabControl.Controls.RemoveAt(index);
            for (int teller = index; teller < 16; teller++)
            {
                richTextBox[teller].Rtf = richTextBox[teller + 1].Rtf;
            }
            for (int teller = index; teller < tabControl.TabPages.Count; teller++)
            {
                tabControl.SelectTab(teller);
                tab.TabIndex = teller;
                tab.Controls.Clear();
                tab.Controls.Add(richTextBox[teller]);
            }
            maxTab--;
            if (maxTab == 0)
                AddPage(maxTab++);
            else
                this.Text = "TabText1 - " + tab.Text;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAll();
            tabControl.Controls.Clear();
            for (int teller = 0; teller < maxTab; teller++)
                richTextBox[teller].Clear();
            maxTab = 0;
            AddPage(maxTab++);
        }


        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call Dialog Box
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                int index = ZoekTab();
                richTextBox[index].printMarginTop = pageSetupDialog.PageSettings.Margins.Top;
                richTextBox[index].printMarginLeft = pageSetupDialog.PageSettings.Margins.Left;
                richTextBox[index].printMarginRight = pageSetupDialog.PageSettings.Margins.Right;
                richTextBox[index].printMarginBottom = pageSetupDialog.PageSettings.Margins.Bottom;
                richTextBox[index].printLandScape = pageSetupDialog.PageSettings.Landscape;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call Dialog Box
            printPreviewDialog.ShowDialog();

        }

        private void previewtoolStripMeniItem_Click(object sender, EventArgs e)
        {
            // Call Dialog Box
            printPreviewDialog.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serializeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serializeFileDialog.InitialDirectory = documentDir;
            serializeFileDialog.Filter = "Serialize bestand (*.srl)|*.srl";
            serializeFileDialog.ShowDialog();
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deserializeFileDialog.InitialDirectory = documentDir;
            deserializeFileDialog.Filter = "Serialize bestand (*.srl)|*.srl";

            deserializeFileDialog.ShowDialog();
        }

        #endregion

        #region recent files




        #endregion

        #region Filemenu - routines

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            loadFile(openFileDialog.FileName);
        }

         /// <summary>
        /// open en load file in the selected tab-page
        /// </summary>
        /// <param name="fileName">File name</param>
        private void loadFile(string fileName)
        {
            TabPage tab = tabControl.SelectedTab;
            try
            {
                int index = ZoekTab();
                string extentie = Path.GetExtension(fileName);
                if (extentie == ".rtf")
                    richTextBox[index].LoadFile(fileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox[index].LoadFile(fileName, RichTextBoxStreamType.PlainText);
                richTextBox[index].Modified = false;
                tab.Tag = fileName; ;
                tab.Text = Path.GetFileName(fileName);
                this.Text = "TabText1 - " + tab.Text;
                // add successfully opened file to recent file list
                removeRecentFile(fileName);
                addRecentFile(fileName);
            }
            catch (IOException ex)
            {
                removeRecentFile(fileName);

                Trace.WriteLine(ex.Message, "Error loading from file");
            }
        }


       private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;
            tab.Tag = saveFileDialog.FileName;
            tab.Text = Path.GetFileName(saveFileDialog.FileName);
            saveFile(tab);
            this.Text = "TabText1 - " + tab.Text;
        }

        /// <summary>
        /// save alle tab-page's
        /// </summary>
        private void saveAll()
        {
            for (int index = 0; index < maxTab; index++)
            {
                tabControl.SelectedIndex = index;
                TabPage tab = tabControl.SelectedTab;
                saveFile(tab);
            }
        }

        /// <summary>
        /// save file in the tab-page
        /// </summary>
        /// <param name="tab">TabPage</param>
        private void saveFile(TabPage tab)
        {
            int index = ZoekTab();
            if (richTextBox[index].Modified == true)
            {
                string messageString = "Save file " + tab.Text.ToString() + "?";
                if (MessageBox.Show(messageString, "TabText1", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string directorie = Path.GetDirectoryName(tab.Tag.ToString());
                    if (Directory.Exists(directorie) == false)
                        Directory.CreateDirectory(directorie);
                    string extentie = Path.GetExtension(tab.Tag.ToString());

                    if (extentie == ".rtf")
                        richTextBox[index].SaveFile(tab.Tag.ToString(), RichTextBoxStreamType.RichText);
                    else
                        richTextBox[index].SaveFile(tab.Tag.ToString(), RichTextBoxStreamType.PlainText);
                    richTextBox[index].Modified = false;
                }
            }
            addRecentFile(tab.Tag.ToString());
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            // Start at the beginning of the text
            m_nFirstCharOnPage = 0;

        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int index = ZoekTab();

            // To print the boundaries of the current page margins
            // uncomment the next line:
//            e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);

            // make the RichTextBoxEx calculate and render as much text as will
            // fit on the page and remember the last character printed for the
            // beginning of the next page
            m_nFirstCharOnPage = richTextBox[index].FormatRange(false,
                e,
                m_nFirstCharOnPage,
                richTextBox[index].TextLength);

            // check if there are more pages to print
            if (m_nFirstCharOnPage < richTextBox[index].TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            int index = ZoekTab();
            // Clean up cached information
            richTextBox[index].FormatRangeDone();

        }

        private void serializeFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            sbpMenu.Text = "Serialize alle pagina's";
            Stream stream = File.Open(serializeFileDialog.FileName, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, maxTab);
            for (int teller = 0; teller < maxTab; teller++)
            {
                bformatter.Serialize(stream, richTextBox[teller].printLandScape);
                bformatter.Serialize(stream, richTextBox[teller].printMarginTop);
                bformatter.Serialize(stream, richTextBox[teller].printMarginLeft);
                bformatter.Serialize(stream, richTextBox[teller].printMarginRight);
                bformatter.Serialize(stream, richTextBox[teller].printMarginBottom);
                bformatter.Serialize(stream, tabPages[teller].Text.ToString());
                bformatter.Serialize(stream, tabPages[teller].Tag.ToString());
                richTextBox[teller].SelectAll();
                bformatter.Serialize(stream, richTextBox[teller].SelectedRtf);
                richTextBox[teller].DeselectAll();
            }
            stream.Close();
            sbpMenu.Text = "Gereed";
        }

        private void deserializeFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            sbpMenu.Text = "Deserialize alle pagina's";
            //Open the file written above and read values from it.
            saveAll();
            tabControl.TabPages.Clear();
            Stream stream = File.Open(deserializeFileDialog.FileName, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            maxTab = (int)bformatter.Deserialize(stream);
            for (int teller = 0; teller < maxTab; teller++)
            {
                AddPage(teller);
                richTextBox[teller].Clear();
                richTextBox[teller].printLandScape = (bool)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginTop = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginLeft = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginRight = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginBottom = (int)bformatter.Deserialize(stream);
                tabPages[teller].Text = bformatter.Deserialize(stream).ToString();
                tabPages[teller].Tag = bformatter.Deserialize(stream).ToString();
                richTextBox[teller].SelectedRtf = bformatter.Deserialize(stream).ToString();
            }
            stream.Close();
            sbpMenu.Text = "Gereed";
        }

        #endregion

        #region Edit-menu

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            undoToolStripMenuItem.Enabled = richTextBox[index].CanUndo;
            redoToolStripMenuItem.Enabled = richTextBox[index].CanRedo;
            cutToolStripMenuItem.Enabled = (richTextBox[index].SelectionLength > 0);
            copyToolStripMenuItem.Enabled = (richTextBox[index].SelectionLength > 0);
            pasteToolStripMenuItem.Enabled = Clipboard.GetDataObject().GetDataPresent(typeof(string));
            selectAllToolStripMenuItem.Enabled = richTextBox[index].CanSelect;
            deleteToolStripMenuItem.Enabled = (richTextBox[index].SelectionLength > 0);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();

            // Determine if last operation can be undone in text box.   
            if (richTextBox[index].CanUndo == true)
            {
                // Undo the last operation.
                richTextBox[index].Undo();
                // Clear the undo buffer to prevent last action from being redone.
                //                richTextBox[index].ClearUndo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            // Determines if a Redo operation can be performed.
            if (richTextBox[index].CanRedo == true)
            {
                // Determines if the redo operation deletes text.
                if (richTextBox[index].RedoActionName != "Delete")
                    // Perform the redo.
                    richTextBox[index].Redo();
            }

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            // Ensure that text is currently selected in the text box.   
            if (richTextBox[index].SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox[index].Cut();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            // Ensure that text is selected in the text box.   
            if (richTextBox[index].SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBox[index].Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBox[index].SelectionLength > 0)
                {
                    // Move selection to the point after the current selection and paste.
                    richTextBox[index].SelectionStart = richTextBox[index].SelectionStart + richTextBox[index].SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBox[index].Paste();
            }
        }

        private void searchandreplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchAndReplace form = new SearchAndReplace();
            int index = ZoekTab();
            form.index = index;
            form.language = language;
            form.maxTab = maxTab - 1;
            TabPage page = tabControl.SelectedTab;
            form.toolStripTextBoxPagenummer.Text = page.Text;
            form.pages = tabPages;
            form.boxen = richTextBox;
            form.toolStripTextBoxZoeken.Text = richTextBox[index].SelectedText.ToString();
            form.Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            // Determine if any text is selected in the TextBox control.
            if (richTextBox[index].SelectionLength == 0)
                // Select all text in the text box.
                richTextBox[index].SelectAll();

            // Copy the contents of the control to the Clipboard.
            richTextBox[index].Copy();

        }

        private void deleteToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectedText = "";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].Clear();
        }

        #endregion

        #region Insert-menu

        /// <summary>
        /// index selected tabpage
        /// </summary>
        /// <returns>index tab-page.</returns>

        public int ZoekTab()
        {
            TabPage tab = tabControl.SelectedTab;
            return tabControl.SelectedIndex;
        }

        /// <summary>
        /// add tab-page to control
        /// </summary>
        /// <param name="pagenummer">Index new TabPage</param>
        public void AddPage(int pagenummer)
        {
            // tabPage
            //

            tabPages[pagenummer] = new TabPage();
            tabPages[pagenummer].Location = new System.Drawing.Point(4, 22);
            tabPages[pagenummer].Name = "tabPage" + pagenummer.ToString();
            tabPages[pagenummer].Padding = new System.Windows.Forms.Padding(3);
            tabPages[pagenummer].Size = new System.Drawing.Size(403, 386);
            tabPages[pagenummer].TabIndex = pagenummer;
            tabPages[pagenummer].MouseHover += new EventHandler(TabText1_MouseHover);
            tabPages[pagenummer].MouseLeave += new EventHandler(TabText1_MouseLeave);
            tabPages[pagenummer].ToolTipText = "Dubbelklikken voor wijzigen naam tab";
            tabPages[pagenummer].Text = "tabPage" + pagenummer.ToString();
            tabPages[pagenummer].Tag = documentDir + "\\" + tabPages[pagenummer].Text + ".rtf";
            tabPages[pagenummer].UseVisualStyleBackColor = true;
            tabPages[pagenummer].Controls.Add(richTextBox[pagenummer]);
            tabControl.Controls.Add(tabPages[pagenummer]);
            tabPages[pagenummer].SuspendLayout();
            tabPages[pagenummer].ResumeLayout(false);
            int aantal = tabControl.Controls.Count;
            tabControl.SelectedIndex = aantal - 1;
            this.Text = "TabText1 - " + tabPages[pagenummer].Text;
        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            TabControl conTrol = (TabControl)sender;
            index = conTrol.SelectedIndex;
            richTextBox[index].Dock = DockStyle.None;
            richTextBox[index].Location = new Point(0, 25);
            richTextBox[index].Size = new Size(this.Size.Width, Size.Height - 25);
            box = new TextBox();
            box.Leave += new System.EventHandler(this.box_Leave);
            box.Text = tabPages[index].Text.ToString();
            tabPages[index].Controls.Add(box);
            box.Show();
            box.Focus();
        }

        private void box_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            tabPages[index].Text = box.Text.ToString();
            if (Path.GetExtension(tabPages[index].Text.ToString()) == "")

                tabPages[index].Tag = documentDir + "\\" + tabPages[index].Text + ".rtf";
            else
                tabPages[index].Tag = documentDir + "\\" + tabPages[index].Text;

            box.Hide();
            richTextBox[index].Dock = DockStyle.Fill;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl conTrol = (TabControl)sender;
            int index = conTrol.SelectedIndex;
            if (index != -1)
            {
                RichTextBox text = richTextBox[index];
                comboboxtext.Text = text.SelectionFont.FontFamily.Name.ToString();
                comboboxcolor.Text = text.SelectionColor.Name.ToString();
                comboboxsize.Text = text.SelectionFont.Size.ToString();
            }
            UpdateSelectionChange();
            UpdateStatusBarPosition();
        }

        private void tabPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maxTab > 15)
                MessageBox.Show("Maximaal aantal pagina's bereikt");
            else
                AddPage(maxTab++);
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.SelectedTab;
            this.Text = "TabText1 - " + tab.Text;
            int index = tabControl.SelectedIndex;
            pageSetupDialog.PageSettings.Margins.Top = richTextBox[index].printMarginTop;
            pageSetupDialog.PageSettings.Margins.Left = richTextBox[index].printMarginLeft;
            pageSetupDialog.PageSettings.Margins.Right = richTextBox[index].printMarginRight;
            pageSetupDialog.PageSettings.Margins.Bottom = richTextBox[index].printMarginBottom;
            pageSetupDialog.PageSettings.Landscape = richTextBox[index].printLandScape;
        }

        private void contextmenuemoticonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            EventArgs args = (EventArgs)e;
            
            if (showForm != null)
            {
                showForm.Hide();  // first hide, you can not twice Show a form.
                showForm.Location = new Point(rectNormal.X + 200, rectNormal.Y + 200);
                showForm.Show();
            }
            else
                MessageBox.Show("No Icons selectede");
        }

        void box_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            showForm.Hide();

            int index = ZoekTab();
            try
            {
                richTextBox[index].InsertImage(box.Image);
            }
            catch (Exception _e)
            {
                MessageBox.Show("Rtf Image Insert Error\n\n" + _e.ToString());
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImageDialog.InitialDirectory = documentDir;
            openImageDialog.Title = "Open een afbeelding";
            openImageDialog.DefaultExt = ".jpg";
            openImageDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;" +
                              "*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf|" +
                       "Windows Bitmap (*.bmp)|*.bmp|" +
                       "Windows Icon (*.ico)|*.ico|" +
                       "Graphics Interchange Format (*.gif)|*.gif|" +
                       "JPEG File Interchange Format (*.jpg)|" +
                              "*.jpg;*.jpeg;*.jfif|" +
                       "Portable Network Graphics (*.png)|*.png|" +
                       "Tag Image File Format (*.tif)|*.tif;*.tiff|" +
                       "Windows Metafile (*.wmf)|*.wmf|" +
                       "Enhanced Metafile (*.emf)|*.emf|" +
                       "All Files (*.*)|*.*";
            openImageDialog.ShowDialog();
        }

        private void openImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            Image[] img = new Image[1];
            try
            {
                img[0] = new Bitmap(openImageDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Afbeelding kon niet geladen worden");
                return;
            }
            int index = ZoekTab();
            try
            {
                richTextBox[index].InsertImage(img[0]);
            }
            catch (Exception _e)
            {
                MessageBox.Show("Rtf Image Insert Error\n\n" + _e.ToString());
            }
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTextDialog.InitialDirectory = documentDir;
            openTextDialog.Title = "Open een tekstbestand";
            openTextDialog.DefaultExt = ".txt";
            openTextDialog.Filter = "Tekst bestand (*.txt)|*.txt|" +
                        "All Files (*.*)|*.*";
            openTextDialog.ShowDialog();

        }

        private void openTextDialog_FileOk(object sender, CancelEventArgs e)
        {
            int index = ZoekTab();
            string str;
            StreamReader stream = new StreamReader(openTextDialog.FileName);
            str = stream.ReadToEnd();
            stream.Close();

            richTextBox[index].AppendText(str);

        }

        private void contextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenu_Text.Show(this, new Point(200, 200));
        }

        private void contextMenu_Text_Click(object sender, EventArgs _args)
        {
            int index = ZoekTab();
            ToolStripMenuItem _item = (ToolStripMenuItem)sender;
            try
            {
                if (standaard)
                    richTextBox[index].InsertTextAsRtf((string)_item.Tag);
                else
                    richTextBox[index].InsertRtf((string)_item.Tag);
            }
            catch (Exception _e)
            {
                MessageBox.Show("Text Insert Error\n\n" + _e.ToString());
            }
        }

        private void cmenu_Teksten_MouseHover(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            splitContainer.SplitterDistance = (splitContainer.Size.Width / 3) * 2;
            richTextBoxPreview.Clear();
            if (standaard)
                richTextBoxPreview.AppendText(item.Tag.ToString());
            else
                richTextBoxPreview.AppendRtf(item.Tag.ToString());
        }

        private void cmenu_Teksten_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            splitContainer.SplitterDistance = splitContainer.Size.Width;
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Table dlg = new Add_Table();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int index = ZoekTab();
                int kolommen = int.Parse(dlg.textBoxKolommen.Text.ToString());
                int rijen = int.Parse(dlg.textBoxRijen.Text.ToString());
                int width = (int)pageSetupDialog.PageSettings.PrintableArea.Width;
                int margin = pageSetupDialog.PageSettings.Margins.Left + pageSetupDialog.PageSettings.Margins.Right;

                richTextBox[index].InsertTable(kolommen, rijen, width - margin);
            }
        }

        #endregion

        #region Layout-menu

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            mi.Checked ^= true;
            richTextBox[index].WordWrap = mi.Checked;
        }

        private void bulletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            mi.Checked ^= true;
            richTextBox[index].SelectionBullet = mi.Checked;
            richTextBox[index].BulletIndent = 30;
        }

        private void BulletToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;
            richTextBox[index].SelectionBullet = mi.Checked;
            richTextBox[index].BulletIndent = 30;

        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //            FontDialog myFontDialog = new FontDialog();
            int index = ZoekTab();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox[index].SelectedText.Length > 0)
                    // Set the control's font.
                    richTextBox[index].SelectionFont = fontDialog.Font;
                else
                    richTextBox[index].Font = fontDialog.Font;
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the control's font.
                if (richTextBox[index].SelectedText.Length > 0)
                    // Set the control's font.
                    richTextBox[index].SelectionColor = colorDialog.Color;
                else
                    richTextBox[index].ForeColor = colorDialog.Color;
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = ZoekTab();
            richTextBox[index].SetSelectionSize(int.Parse(item.Text));

        }

        private void formatrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Right;
            formatrightToolStripMenuItem.Checked = true;
            formatrightToolStripButton.Checked = true;
            formatcenterToolStripMenuItem.Checked = false;
            formatcenterToolStripButton.Checked = false;
            formatleftToolStripMenuItem.Checked = false;
            formatleftToolStripButton.Checked = false;
        }

        private void formatrightToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Right;
            formatrightToolStripMenuItem.Checked = true;
            formatrightToolStripButton.Checked = true;
            formatcenterToolStripMenuItem.Checked = false;
            formatcenterToolStripButton.Checked = false;
            formatleftToolStripMenuItem.Checked = false;
            formatleftToolStripButton.Checked = false;
        }

        private void formatcenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Center;
            formatcenterToolStripMenuItem.Checked = true;
            formatcenterToolStripButton.Checked = true;
            formatrightToolStripMenuItem.Checked = false;
            formatrightToolStripButton.Checked = false;
            formatleftToolStripMenuItem.Checked = false;
            formatleftToolStripButton.Checked = false;
        }

        private void formatcenterToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Center;
            formatcenterToolStripMenuItem.Checked = true;
            formatcenterToolStripButton.Checked = true;
            formatrightToolStripMenuItem.Checked = false;
            formatrightToolStripButton.Checked = false;
            formatleftToolStripMenuItem.Checked = false;
            formatleftToolStripButton.Checked = false;
        }

        private void formatleftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Left;
            formatleftToolStripMenuItem.Checked = true;
            formatleftToolStripButton.Checked = true;
            formatcenterToolStripMenuItem.Checked = false;
            formatcenterToolStripButton.Checked = false;
            formatrightToolStripMenuItem.Checked = false;
            formatrightToolStripButton.Checked = false;
        }

        private void formatleftToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionAlignment = HorizontalAlignment.Left;
            formatleftToolStripMenuItem.Checked = true;
            formatleftToolStripButton.Checked = true;
            formatcenterToolStripMenuItem.Checked = false;
            formatcenterToolStripButton.Checked = false;
            formatrightToolStripMenuItem.Checked = false;
            formatrightToolStripButton.Checked = false;
        }

        private void moreindentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionIndent += 20;
            lessindentToolStripButton.Enabled = true;
            lessindentToolStripMenuItem.Enabled = true;
        }

        private void moreindentToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionIndent += 20;
            lessindentToolStripButton.Enabled = true;
            lessindentToolStripMenuItem.Enabled = true;
        }

        private void lessindentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionIndent > 0)
                richTextBox[index].SelectionIndent -= 20;
            if (richTextBox[index].SelectionIndent > 0)
            {
                lessindentToolStripButton.Enabled = true;
                lessindentToolStripMenuItem.Enabled = true;
            }
            else
            {
                lessindentToolStripButton.Enabled = false;
                lessindentToolStripMenuItem.Enabled = false;
            }
        }

        private void lessindentToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionIndent > 0)
                richTextBox[index].SelectionIndent -= 20;
            if (richTextBox[index].SelectionIndent > 0)
            {
                lessindentToolStripButton.Enabled = true;
                lessindentToolStripMenuItem.Enabled = true;
            }
            else
            {
                lessindentToolStripButton.Enabled = false;
                lessindentToolStripMenuItem.Enabled = false;
            }
        }

        private void moreindentrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionRightIndent += 20;
            lessindentrightToolStripButton.Enabled = true;
            lessindentrightToolStripMenuItem.Enabled = true;
        }

        private void moreindentrightToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionRightIndent += 20;
            lessindentrightToolStripButton.Enabled = true;
            lessindentrightToolStripMenuItem.Enabled = true;
        }

        private void lessindentrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionRightIndent > 0)
                richTextBox[index].SelectionRightIndent -= 20;
            if (richTextBox[index].SelectionRightIndent > 0)
            {
                lessindentrightToolStripButton.Enabled = true;
                lessindentrightToolStripMenuItem.Enabled = true;
            }
            else
            {
                lessindentrightToolStripButton.Enabled = false;
                lessindentrightToolStripMenuItem.Enabled = false;
            }
        }

        private void lessindentrightToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionRightIndent > 0)
                richTextBox[index].SelectionRightIndent -= 20;
            if (richTextBox[index].SelectionRightIndent > 0)
            {
                lessindentrightToolStripButton.Enabled = true;
                lessindentrightToolStripMenuItem.Enabled = true;
            }
            else
            {
                lessindentrightToolStripButton.Enabled = false;
                lessindentrightToolStripMenuItem.Enabled = false;
            }
        }

        private void morehangindentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionHangingIndent += 20;
            lesshangindentToolStripButton.Enabled = true;
            lesshangindentToolStripMenuItem.Enabled = true;
        }

        private void morehangindentToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].SelectionHangingIndent += 20;
            lesshangindentToolStripButton.Enabled = true;
            lesshangindentToolStripMenuItem.Enabled = true;
        }

        private void lesshangindentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionHangingIndent > 0)
                richTextBox[index].SelectionHangingIndent -= 20;
            if (richTextBox[index].SelectionHangingIndent > 0)
            {
                lesshangindentToolStripButton.Enabled = true;
                lesshangindentToolStripMenuItem.Enabled = true;
            }
            else
            {
                lesshangindentToolStripButton.Enabled = false;
                lesshangindentToolStripMenuItem.Enabled = false;
            }
        }

        private void lesshangindentToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].SelectionHangingIndent > 0)
                richTextBox[index].SelectionHangingIndent -= 20;
            if (richTextBox[index].SelectionHangingIndent > 0)
            {
                lesshangindentToolStripButton.Enabled = true;
                lesshangindentToolStripMenuItem.Enabled = true;
            }
            else
            {
                lesshangindentToolStripButton.Enabled = false;
                lesshangindentToolStripMenuItem.Enabled = false;
            }
        }

        private void formatboldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;
            richTextBox[index].SetSelectionBold(mi.Checked);

        }

        private void formatitalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;
            richTextBox[index].SetSelectionItalic(mi.Checked);

        }

        private void formatunderscoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;
            richTextBox[index].SetSelectionUnderlined(mi.Checked);

        }

        private void formatstrikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            ToolStripButton mi = (ToolStripButton)sender;
            mi.Checked ^= true;
            richTextBox[index].SetSelectionStrike(mi.Checked);

        }

        private void backcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                if (richTextBox[index].SelectionLength > 0)
                    richTextBox[index].SelectionBackColor = colorDialog.Color;
                else
                    richTextBox[index].BackColor = colorDialog.Color;
        }

        private void kleurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            layoutToolStripMenuItem.Checked = richTextBox[index].WordWrap;
        }

        private Color zoekColor(String naam)
        {
            Color kleur = new Color();
            switch (naam)
            {
                case "AliceBlue":
                    kleur = Color.AliceBlue;
                    break;
                case "AntiqueWhite":
                    kleur = Color.AntiqueWhite;
                    break;
                case "Aqua":
                    kleur = Color.Aqua;
                    break;
                case "Aquamarine":
                    kleur = Color.Aquamarine;
                    break;
                case "Azure":
                    kleur = Color.Azure;
                    break;
                case "Beige":
                    kleur = Color.Beige;
                    break;
                case "Bisque":
                    kleur = Color.Bisque;
                    break;
                case "Black":
                    kleur = Color.Black;
                    break;
                case "BlanchedAlmond":
                    kleur = Color.BlanchedAlmond;
                    break;
                case "Blue":
                    kleur = Color.Blue;
                    break;
                case "BlueViolet":
                    kleur = Color.BlueViolet;
                    break;
                case "Brown":
                    kleur = Color.Brown;
                    break;
                case "BurlyWood":
                    kleur = Color.BurlyWood;
                    break;
                case "CadetBlue":
                    kleur = Color.CadetBlue;
                    break;
                case "Chartreuse":
                    kleur = Color.Chartreuse;
                    break;
                case "Chocolate":
                    kleur = Color.Chocolate;
                    break;
                case "Coral":
                    kleur = Color.Coral;
                    break;
                case "CornflowerBlue":
                    kleur = Color.CornflowerBlue;
                    break;
                case "Cornsilk":
                    kleur = Color.Cornsilk;
                    break;
                case "Crimson":
                    kleur = Color.Crimson;
                    break;
                case "Cyan":
                    kleur = Color.Cyan;
                    break;
                case "DarkBlue":
                    kleur = Color.DarkBlue;
                    break;
                case "DarkCyan":
                    kleur = Color.DarkCyan;
                    break;
                case "DarkGoldenrod":
                    kleur = Color.DarkGoldenrod;
                    break;
                case "DarkGray":
                    kleur = Color.DarkGray;
                    break;
                case "DarkGreen":
                    kleur = Color.DarkGreen;
                    break;
                case "DarkKhaki":
                    kleur = Color.DarkKhaki;
                    break;
                case "DarkMagenta":
                    kleur = Color.DarkMagenta;
                    break;
                case "DarkOliveGreen":
                    kleur = Color.DarkOliveGreen;
                    break;
                case "DarkOrange":
                    kleur = Color.DarkOrange;
                    break;
                case "DarkOrchid":
                    kleur = Color.DarkOrchid;
                    break;
                case "DarkRed":
                    kleur = Color.DarkRed;
                    break;
                case "DarkSalmon":
                    kleur = Color.DarkSalmon;
                    break;
                case "DarkSeaGreen":
                    kleur = Color.DarkSeaGreen;
                    break;
                case "DarkSlateBlue":
                    kleur = Color.DarkSlateBlue;
                    break;
                case "DarkSlateGray":
                    kleur = Color.DarkSlateGray;
                    break;
                case "DarkTurquoise":
                    kleur = Color.DarkTurquoise;
                    break;
                case "DarkViolet":
                    kleur = Color.DarkViolet;
                    break;
                case "DeepPink":
                    kleur = Color.DeepPink;
                    break;
                case "DeepSkyBlue":
                    kleur = Color.DeepSkyBlue;
                    break;
                case "DimGray":
                    kleur = Color.DimGray;
                    break;
                case "DodgerBlue":
                    kleur = Color.DodgerBlue;
                    break;
                case "Firebrick":
                    kleur = Color.Firebrick;
                    break;
                case "FloralWhite":
                    kleur = Color.FloralWhite;
                    break;
                case "ForestGreen":
                    kleur = Color.ForestGreen; ;
                    break;
                case "Fuchsia":
                    kleur = Color.Fuchsia;
                    break;
                case "Gainsboro":
                    kleur = Color.Gainsboro;
                    break;
                case "GhostWhite":
                    kleur = Color.GhostWhite;
                    break;
                case "Gold":
                    kleur = Color.Gold;
                    break;
                case "Goldenrod":
                    kleur = Color.Goldenrod;
                    break;
                case "Gray":
                    kleur = Color.Gray;
                    break;
                case "Green":
                    kleur = Color.Green;
                    break;
                case "GreenYellow":
                    kleur = Color.GreenYellow;
                    break;
                case "Honeydew":
                    kleur = Color.Honeydew;
                    break;
                case "HotPink":
                    kleur = Color.HotPink;
                    break;
                case "IndianRed":
                    kleur = Color.IndianRed;
                    break;
                case "Indigo":
                    kleur = Color.Indigo;
                    break;
                case "Ivory":
                    kleur = Color.Ivory;
                    break;
                case "Khaki":
                    kleur = Color.Khaki;
                    break;
                case "Lavender":
                    kleur = Color.Lavender;
                    break;
                case "LavenderBlush":
                    kleur = Color.LavenderBlush;
                    break;
                case "LawnGreen":
                    kleur = Color.LawnGreen;
                    break;
                case "LemonChiffon":
                    kleur = Color.LemonChiffon;
                    break;
                case "LightBlue":
                    kleur = Color.LightBlue;
                    break;
                case "LightCoral":
                    kleur = Color.LightCoral;
                    break;
                case "LightCyan":
                    kleur = Color.LightCyan;
                    break;
                case "LightGoldenrodYellow":
                    kleur = Color.LightGoldenrodYellow;
                    break;
                case "LightGray":
                    kleur = Color.LightGray;
                    break;
                case "LightGreen":
                    kleur = Color.LightGreen;
                    break;
                case "LightPink":
                    kleur = Color.LightPink;
                    break;
                case "LightSalmon":
                    kleur = Color.LightSalmon;
                    break;
                case "LightSeaGreen":
                    kleur = Color.LightSeaGreen;
                    break;
                case "LightSkyBlue":
                    kleur = Color.LightSkyBlue;
                    break;
                case "LightSlateGray":
                    kleur = Color.LightSlateGray;
                    break;
                case "LightSteelBlue":
                    kleur = Color.LightSteelBlue;
                    break;
                case "LightYellow":
                    kleur = Color.LightYellow;
                    break;
                case "Lime":
                    kleur = Color.Lime;
                    break;
                case "LimeGreen":
                    kleur = Color.LimeGreen;
                    break;
                case "Linen":
                    kleur = Color.Linen;
                    break;
                case "Magenta":
                    kleur = Color.Magenta;
                    break;
                case "Maroon":
                    kleur = Color.Maroon;
                    break;
                case "MediumAquamarine":
                    kleur = Color.MediumAquamarine;
                    break;
                case "MediumBlue":
                    kleur = Color.MediumBlue;
                    break;
                case "MediumOrchid":
                    kleur = Color.MediumOrchid;
                    break;
                case "MediumPurple":
                    kleur = Color.MediumPurple;
                    break;
                case "MediumSeaGreen":
                    kleur = Color.MediumSeaGreen;
                    break;
                case "MediumSlateBlue":
                    kleur = Color.MediumSlateBlue;
                    break;
                case "MediumSpringGreen":
                    kleur = Color.MediumSpringGreen;
                    break;
                case "MediumTurquoise":
                    kleur = Color.MediumTurquoise;
                    break;
                case "MediumVioletRed":
                    kleur = Color.MediumVioletRed;
                    break;
                case "MidnightBlue":
                    kleur = Color.MidnightBlue;
                    break;
                case "MintCream":
                    kleur = Color.MintCream;
                    break;
                case "MistyRose":
                    kleur = Color.MistyRose;
                    break;
                case "Moccasin":
                    kleur = Color.Moccasin;
                    break;
                case "NavajoWhite":
                    kleur = Color.NavajoWhite;
                    break;
                case "Navy":
                    kleur = Color.Navy;
                    break;
                case "OldLace ":
                    kleur = Color.OldLace;
                    break;
                case "Olive":
                    kleur = Color.Olive;
                    break;
                case "OliveDrab":
                    kleur = Color.OliveDrab;
                    break;
                case "Orange":
                    kleur = Color.Orange;
                    break;
                case "OrangeRed":
                    kleur = Color.OrangeRed;
                    break;
                case "Orchid":
                    kleur = Color.Orchid;
                    break;
                case "PaleGoldenrod":
                    kleur = Color.PaleGoldenrod;
                    break;
                case "PaleGreen":
                    kleur = Color.PaleGreen;
                    break;
                case "PaleTurquoise":
                    kleur = Color.PaleTurquoise;
                    break;
                case "PaleVioletRed":
                    kleur = Color.PaleVioletRed;
                    break;
                case "PapayaWhip":
                    kleur = Color.PapayaWhip;
                    break;
                case "PeachPuff":
                    kleur = Color.PeachPuff;
                    break;
                case "Peru":
                    kleur = Color.Peru;
                    break;
                case "Pink":
                    kleur = Color.Pink;
                    break;
                case "Plum":
                    kleur = Color.Plum;
                    break;
                case "PowderBlue":
                    kleur = Color.PowderBlue;
                    break;
                case "Purple":
                    kleur = Color.Purple;
                    break;
                case "Red":
                    kleur = Color.Red;
                    break;
                case "RosyBrown":
                    kleur = Color.RosyBrown;
                    break;
                case "RoyalBlue":
                    kleur = Color.RoyalBlue;
                    break;
                case "SaddleBrown":
                    kleur = Color.SaddleBrown;
                    break;
                case "Salmon":
                    kleur = Color.Salmon;
                    break;
                case "SandyBrown":
                    kleur = Color.SandyBrown;
                    break;
                case "SeaGreen":
                    kleur = Color.SeaGreen;
                    break;
                case "SeaShell":
                    kleur = Color.SeaShell;
                    break;
                case "Sienna":
                    kleur = Color.Sienna;
                    break;
                case "Silver":
                    kleur = Color.Silver;
                    break;
                case "SkyBlue":
                    kleur = Color.SkyBlue;
                    break;
                case "SlateBlue":
                    kleur = Color.SlateBlue;
                    break;
                case "SlateGray":
                    kleur = Color.SlateGray;
                    break;
                case "Snow":
                    kleur = Color.Snow;
                    break;
                case "SpringGreen":
                    kleur = Color.SpringGreen;
                    break;
                case "SteelBlue": ;
                    kleur = Color.SteelBlue;
                    break;
                case "Tan":
                    kleur = Color.Tan;
                    break;
                case "Teal":
                    kleur = Color.Teal;
                    break;
                case "Thistle":
                    kleur = Color.Thistle;
                    break;
                case "Tomato":
                    kleur = Color.Tomato;
                    break;
                case "Transparent":
                    kleur = Color.Transparent;
                    break;
                case "Turquoise":
                    kleur = Color.Turquoise;
                    break;
                case "Violet":
                    kleur = Color.Violet;
                    break;
                case "Wheat":
                    kleur = Color.Wheat;
                    break;
                case "White":
                    kleur = Color.White;
                    break;
                case "WhiteSmoke":
                    kleur = Color.WhiteSmoke;
                    break;
                case "Yellow":
                    kleur = Color.Yellow;
                    break;
                case "YellowGreen":
                    kleur = Color.YellowGreen;
                    break;
            }
            return kleur;
        }

        private void zoominToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            richTextBox[index].ZoomFactor += 1;
        }

        private void zoomoutToolStripButton_Click(object sender, EventArgs e)
        {
            int index = ZoekTab();
            if (richTextBox[index].ZoomFactor > 1)
                richTextBox[index].ZoomFactor -= 1;

        }

        #endregion

        #region Help-menu

        private void emoticonsCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmotioconsCollector dlg = new EmotioconsCollector();
            dlg.documentDir = documentDir;
            dlg.ShowDialog();
            imageCounter = dlg.imageCounter;
            for (int teller = 0; teller < imageCounter; teller++)
            {
                images[teller].fileName = dlg.images[teller].fileName;
                images[teller].imageNumber = dlg.images[teller].imageNumber;
                images[teller].img = dlg.images[teller].img;
            }
        }

        private void createImagePanel(ImageInfo[] images, int imageCounter)
        {
            if (showForm != null)
                showForm.Close();
            if (imageCounter != 0)
            {
                showForm = new Form();
                barBreak(imageCounter);
                Panel panel = new System.Windows.Forms.Panel();
                PictureBox[] box = new PictureBox[imageCounter];
                for (int counter = 0; counter < imageCounter; counter++)
                {
                    box[counter] = new System.Windows.Forms.PictureBox();
                    panel.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(box[counter])).BeginInit();
                    // 
                    // panel
                    //
                    panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    panel.Controls.Add(box[counter]);
                }
                int imageNumber = 0;
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Name = "panel";
                panel.Size = new Size(numberRows * 32, numberColums * 32);
                panel.Leave += new EventHandler(panel_Leave);
                for (int kolom = 0; kolom < numberColums; kolom++)
                    for (int rij = 0; rij < numberRows; rij++)
                    {
                        // 
                        // pictureBox
                        //
                        if (imageNumber < imageCounter)
                        {
                            box[imageNumber].Location = new Point(rij * 32, kolom * 32);
                            box[imageNumber].Name = "";
                            box[imageNumber].Size = new System.Drawing.Size(32, 32);
                            box[imageNumber].BorderStyle = BorderStyle.Fixed3D;
                            box[imageNumber].TabIndex = imageNumber;
                            box[imageNumber].TabStop = true;
                            box[imageNumber].Image = images[imageNumber].img.GetThumbnailImage(32, 32, null, (IntPtr)0);
                            box[imageNumber].MouseClick += new MouseEventHandler(box_MouseClick);
                            box[imageNumber].MouseHover += new EventHandler(box_MouseHover);
                            box[imageNumber].MouseLeave += new EventHandler(box_MouseLeave);
                        }
                        imageNumber++;
                    }
                // 
                // ShowPanel
                //
                box[0].Focus();
                showForm.AutoSize = true;
                showForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                showForm.ClientSize = new Size(numberRows * 32, numberColums * 32);
                showForm.ControlBox = false;
                showForm.Controls.Add(panel);
                showForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                showForm.StartPosition = FormStartPosition.Manual;
                showForm.Location = new Point(rectNormal.X + 200, rectNormal.Y + 200);
                showForm.Text = "";
                showForm.MaximizeBox = false;
                showForm.MinimizeBox = false;
                showForm.ShowIcon = false;
                showForm.Name = "";
                showForm.ShowInTaskbar = false;
                showForm.Leave += new EventHandler(showForm_Leave);
                panel.ResumeLayout(false);
                for (int counter = 0; counter < imageCounter; counter++)
                {

                    ((System.ComponentModel.ISupportInitialize)(box[counter])).EndInit();
                }
                showForm.ResumeLayout(false);
            }
        }

        void panel_Leave(object sender, EventArgs e)
        {
            showForm.Hide();
        }

        void showForm_Leave(object sender, EventArgs e)
        {
            showForm.Hide();
        }

        private void barBreak(int number)
        {
            numberColums = numberRows = (int)Math.Sqrt(number);
            int numberPanels = numberColums * numberRows;
            int rest = number - numberPanels;
            if (rest > 0)
                numberColums = numberColums + 1;
            numberPanels = numberColums * numberRows;
            rest = number - numberPanels;
            if (rest > 0)
                numberRows = numberRows + 1;
        }

        void box_MouseLeave(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            box.BorderStyle = BorderStyle.Fixed3D;
        }

        void box_MouseHover(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            box.BorderStyle = BorderStyle.FixedSingle;
        }

        private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();

            options.documentDir = documentDir;
            options.filenaamEmoticons = filenaamEmoticons;
            options.filenameTextFragments = filenameTextFragments;

            if (options.ShowDialog() == DialogResult.OK)
            {
                documentDir = options.documentDir;
                filenameTextFragments = options.comboBoxTextFragmenten.Text.ToString();
                filenaamEmoticons = options.comboBoxEmoticons.Text.ToString();

                if (filenameTextFragments == "<Default>")
                {
                    defaultTextFragments();
                }
                else
                {
                    loadTextFragments();
                }

                if (filenaamEmoticons == "<Default>")
                {
                    defaultImagePanel();
                }
                else
                {
                    loadImagePanel();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void languagetoolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox box = (ToolStripComboBox)sender;
            language = box.Text.ToString();
            switch (box.Text)
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
        }

        void Nederlands()
        {
            // Menu Bestand
            fileToolStripMenuItem.Text = "&Bestand";
            // Nieuw menu
            newToolStripMenuItem.Tag = "Sla de huidige bestanden op, sluit de pagina's en maak een nieuw bestand aan";
            newToolStripMenuItem.Text = "&Nieuw";
            newToolStripMenuItem.ToolTipText = "Maak een nieuw bestand aan";
            // Open menu
            openToolStripMenuItem.Tag = "Open een bestaand bestand in de geselecteerde pagina";
            openToolStripMenuItem.Text = "&Openen";
            openToolStripMenuItem.ToolTipText = "Open bestaand bestand";
            // Deserialisatie
            deserializeToolStripMenuItem.Tag = "Laad een geserialiseerd bestand in pagina\'s";
            deserializeToolStripMenuItem.Text = "Deseriali&ze";
            deserializeToolStripMenuItem.ToolTipText = "Laad een .srl bestand";
            // Bewaar menu
            saveToolStripMenuItem.Tag = "Bewaar de geselecteerde pagina in een bestand onder de naam van de pagina-tab";
            saveToolStripMenuItem.Text = "Ops&laan";
            saveToolStripMenuItem.ToolTipText = "Sla pagina op";
            // Bewaar als menu
            saveAsToolStripMenuItem.Tag = "Bewaar de geselecteerde pagina in een op te geven bestand";
            saveAsToolStripMenuItem.Text = "O&pslaan Als...";
            saveAsToolStripMenuItem.ToolTipText = "Sla pagina op in bestand";
            // bewaar alles menu
            saveAllToolStripMenuItem.Tag = "Bewaar alle pagina\'s in bestanden onder de naam van de pagina tab";
            saveAllToolStripMenuItem.Text = "All&es opslaan";
            saveAllToolStripMenuItem.ToolTipText = "Sla alle pagina's op";
            // Serialisatie menu
            serializeAllToolStripMenuItem.Tag = "Bewaar alle pagina\'s in een geserialiseerd bestans";
            serializeAllToolStripMenuItem.Text = "Serialize All";
            serializeAllToolStripMenuItem.ToolTipText = "Maak een .srl bestand";
            // Sluit menu
            closeToolStripMenuItem.Tag = "Sluit de geselecteerde tab-pagina";
            closeToolStripMenuItem.Text = "&Sluiten";
            closeToolStripMenuItem.ToolTipText = "Sluit pagina";
            // sluit Allemenu
            closeAllToolStripMenuItem.Tag = "Sluit alle tab-pagina\'s";
            closeAllToolStripMenuItem.Text = "Alles Sl&uiten";
            closeAllToolStripMenuItem.ToolTipText = "Alle pagina's sluiten";
            // Pagina instellingen menu
            pageSetupToolStripMenuItem.Tag = "Toon dialoogkader Pagina instellingen en stel ze in";
            pageSetupToolStripMenuItem.Text = "Pagina Instell&ing";
            pageSetupToolStripMenuItem.ToolTipText = "Geef de pagina instellingen";
            // Afdruk Menu
            printToolStripMenuItem.Tag = "Druk de geselecteerde pagina af";
            printToolStripMenuItem.Text = "Af&drukken";
            printToolStripMenuItem.ToolTipText = "Druk pagina af";
            // Print voorbeeld menu
            printPreviewToolStripMenuItem.Tag = "Toon afdrukvoorbeeld van de geselecteerde pagina op scherm";
            printPreviewToolStripMenuItem.Text = "A&fdruk voorbeeld";
            printPreviewToolStripMenuItem.ToolTipText = "Geef afdruk voorbeeld";
            // Laatst geopen menu
            recentfilelistToolstripMenuItem.Text = "Laatst geöpend";
            // afsluiten menu
            exitToolStripMenuItem.Tag = "Sluit het programma af";
            exitToolStripMenuItem.Text = "Afsluiten";
            exitToolStripMenuItem.ToolTipText = "Sluit programma";


            // Menu Bewerken
            editToolStripMenuItem.Text = "&Bewerken";
            // Menu undo
            undoToolStripMenuItem.Tag = "De laatste bewerking die gedaan is wordt ongedaan gemnaakt";
            undoToolStripMenuItem.Text = "Ongedaan";
            undoToolStripMenuItem.ToolTipText = "Maak de laatste bewerking ongedaan";
            //Menu redo
            redoToolStripMenuItem.Tag = "Herstel ongedaan";
            redoToolStripMenuItem.Text = "&Herstel";
            redoToolStripMenuItem.ToolTipText = "Herstel de laaste bewerking die ongedaan is gemaakt";
            //Menu knippen
            cutToolStripMenuItem.Tag = "Knip selectie en kopieer naar klembord";
            cutToolStripMenuItem.Text = "Knippen";
            cutToolStripMenuItem.ToolTipText = "Knip en Kopieer";
            // Menu Kopieren
            copyToolStripMenuItem.Tag = "Kopieer selectie naar klembord";
            copyToolStripMenuItem.Text = "&Kopiëren";
            copyToolStripMenuItem.ToolTipText = "Kopieer";
            // Menu Plakken
            pasteToolStripMenuItem.Tag = "Plak tekst uit klembord";
            pasteToolStripMenuItem.Text = "&Plakken";
            pasteToolStripMenuItem.ToolTipText = "Plak";
            // Menu Zoek en vervang
            searchandreplaceToolStripMenuItem.Tag = "Roept het dialoog kader aan voor het Zoeken of wijzig tekesten";
            searchandreplaceToolStripMenuItem.Text = "Zoeken en Vervangen...";
            searchandreplaceToolStripMenuItem.ToolTipText = "Zoeken en wijzigen van teksten";
            // Menu Selecteer alles
            selectAllToolStripMenuItem.Tag = "Selecteer alles op de pagina";
            selectAllToolStripMenuItem.Text = "Selecteer &Alles";
            selectAllToolStripMenuItem.ToolTipText = "Selecteer alle tekst";
            // Menu Verwijderen
            deleteToolStripMenuItem.Tag = "Verwijder de geselecteerde tekst";
            deleteToolStripMenuItem.Text = "Verwijder";
            deleteToolStripMenuItem.ToolTipText = "Verwijder tekst";

            // Menu Toevoegen
            insertToolStripMenuItem.Text = "Toevoegen";
            // Menu Nieuwe Pagina
            tabPageToolStripMenuItem.Tag = "Voeg een nieuw tabpagina toe";
            tabPageToolStripMenuItem.Text = "Pagina";
            tabPageToolStripMenuItem.ToolTipText = "Nieuwe pagina";
            // Menu Emoticons
            contextmenuemoticonsToolStripMenuItem.Tag = "Er verschijnt een popup menu waaruit U een emoticon kunt toevoegen";
            contextmenuemoticonsToolStripMenuItem.Text = "Emoticons";
            contextmenuemoticonsToolStripMenuItem.ToolTipText = "Voeg een emoticon toe";
            // Menu Afbeelding
            imageToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een afbeelding toe te voegen";
            imageToolStripMenuItem.Text = "Afbeelding";
            imageToolStripMenuItem.ToolTipText = "Voeg een afbeelding toe";
            //Menu Tekst
            txtToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een een teksbestand toe te voegen";
            txtToolStripMenuItem.Text = "Tekst";
            txtToolStripMenuItem.ToolTipText = "Voeg tekst bestand toe";
            //Menu Tekst fragment
            contextmenutextToolStripMenuItem.Tag = "Er verschijnt een popup menu waaruit U een tekst fragment kunt toevoegen";
            contextmenutextToolStripMenuItem.Text = "Tekst fragment";
            contextmenutextToolStripMenuItem.ToolTipText = "Voeg tekst fragment toe";

            // Menu Opmaak
            layoutToolStripMenuItem.Text = "Opmaak";

            wordWrapToolStripMenuItem.Text = "Automatische terugloop";
            wordWrapToolStripMenuItem.Tag = "Regels lopen door of worden afgebroken naar de volegende regel";
            wordWrapToolStripMenuItem.ToolTipText = "Wel of niet woord afbreken";

            bulletToolStripMenuItem.Tag = "Spring in met een bullet";
            bulletToolStripMenuItem.Text = "Opsommings teken";
            bulletToolStripMenuItem.ToolTipText = "Wel of geen opsommings teken";

            fontsToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een letter type te kiezen";
            fontsToolStripMenuItem.Text = "Letters";
            fontsToolStripMenuItem.ToolTipText = "Wijzig lettertype";

            colorToolStripMenuItem.Tag = "Er verschijnt een dialoogkader  waaruit U een kleur kunt kiezen";
            colorToolStripMenuItem.Text = "Kleur letters";
            colorToolStripMenuItem.ToolTipText = "Wijzig kleur letters";

            backcolorToolStripMenuItem.Text = "Kleur achtergrond";
            backcolorToolStripMenuItem.Tag = "Er verschijnt een dialoogkader waaruit U een kleur kunt kiezen";

            txtsizeToolStripMenuItem.Tag = "Selecteer een grootte voor de geselecteerde tekst";
            txtsizeToolStripMenuItem.Text = "Grootte letters";
            txtsizeToolStripMenuItem.ToolTipText = "Wijzig grootte";

            size10ToolStripMenuItem.Text = "10";
            size12ToolStripMenuItem.Text = "12";
            size14ToolStripMenuItem.Text = "14";
            size16ToolStripMenuItem.Text = "16";
            size18ToolStripMenuItem.Text = "18";
            size20ToolStripMenuItem.Text = "20";
            size24ToolStripMenuItem.Text = "24";
            size30ToolStripMenuItem.Text = "30";
            size36ToolStripMenuItem.Text = "36";
            size72ToolStripMenuItem.Text = "72";

            indentToolStripMenuItem.Text = "Linker Marge";
            indentToolStripMenuItem.Tag = "De linker marge kan vergroot of verkleind worden";
            indentToolStripMenuItem.ToolTipText = "Stel linker marge in";

            lessindentToolStripMenuItem.Text = "Verkleinen";
            lessindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de linker marge verlaagd met 30 punten";
            lessindentToolStripMenuItem.ToolTipText = "Verklein linker marge";

            moreindentToolStripMenuItem.Text = "Vergroten";
            moreindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de linker marge verhoogd met 30 punten";
            moreindentToolStripMenuItem.ToolTipText = "Vergroot linker marge";


            indentrightToolStripMenuItem.Text = "Rechter Marge";
            indentrightToolStripMenuItem.Tag = "De rechter marge kan vergroot of verkleind worden";
            indentrightToolStripMenuItem.ToolTipText = "Stel rechter marge";

            moreindentrightToolStripMenuItem.Text = "Vergroten";
            moreindentrightToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de rechter marge verhoogd met 30 punten";
            moreindentrightToolStripMenuItem.ToolTipText = "Vergroot rechter marge";

            lessindentrightToolStripMenuItem.Text = "Verkleinen";
            lessindentrightToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de rechter marge verlaagd met 30 punten";
            lessindentrightToolStripMenuItem.ToolTipText = "Verklein rechter marge";

            hangindentToolStripMenuItem.Text = "Alinia inspringen";
            hangindentToolStripMenuItem.Tag = "Het inspringen van de alinia kan vergroot of verkleind worden. De eerste regel van de zin springt niet mee";
            hangindentToolStripMenuItem.ToolTipText = "Stel alinia inspringen in";

            morehangindentToolStripMenuItem.Text = "Vergroten";
            morehangindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de alinia marge verhoogd met 30 punten. De eerste regel van de zin springt niet mee";
            morehangindentToolStripMenuItem.ToolTipText = "Vergroot alinia marge";

            lesshangindentToolStripMenuItem.Text = "Verkleinen";
            lesshangindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de alinia marge verkleind met 30 punten. De eerste regel van de zin springt niet mee";
            lesshangindentToolStripMenuItem.ToolTipText = "Verkleinen alinia marge";
            // formatrightToolStripMenuItem
            // 
            formatleftToolStripMenuItem.Text = "Tekst links";
            formatleftToolStripMenuItem.Tag = "De tekst word aan de linker kant uitgelijnd";
            formatleftToolStripMenuItem.ToolTipText = "Tekst links uitlijnen";
            // 
            // formatleftToolStripMenuItem
            // 
            formatrightToolStripMenuItem.Text = "Tekst rechts";
            formatrightToolStripMenuItem.Tag = "De tekst word aan de rechter kant uitgelijnd";
            formatrightToolStripMenuItem.ToolTipText = "Tekst rechts uitlijnen";
            // 
            // formatcenterToolStripMenuItem
            // 
            formatcenterToolStripMenuItem.Text = "Tekst centreer";
            formatcenterToolStripMenuItem.Tag = "De tekst wordt gecentreerd";
            formatcenterToolStripMenuItem.ToolTipText = "Tekst gecentreerd uitlijnen";
            // 
            // tekstVetToolStripMenuItem
            // 
            formatboldToolStripMenuItem.Text = "Tekst vet";
            formatboldToolStripMenuItem.Tag = "De geselecteerde tekst wordt vet weergegeven";
            formatboldToolStripMenuItem.ToolTipText = "Tekst vet weergeven";
            // 
            // formatitalicToolStripMenuItem
            // 
            formatitalicToolStripMenuItem.Text = "Tekst schuin";
            formatitalicToolStripMenuItem.Tag = "De geselecteerde tekst wordt schuin weergegeven";
            formatitalicToolStripMenuItem.ToolTipText = "Tekst schuin weergeven";
            // 
            // tekstToolStripMenuItem1
            // 
            formatunderscoreToolStripMenuItem.Text = "Tekst onderstreept";
            formatunderscoreToolStripMenuItem.Tag = "De geselecteerde tekst wordt onderstreept weergegeven";
            formatunderscoreToolStripMenuItem.ToolTipText = "Tekst onderstreept weergeven";
            // 
            // tekstDoorgegehaaldToolStripMenuItem
            // 
            formatstrikeToolStripMenuItem.Text = "Tekst doorgegehaald";
            formatstrikeToolStripMenuItem.Tag = "De geselecteerde tekst wordt doorgehaald weergegeven";
            formatstrikeToolStripMenuItem.ToolTipText = "Tekst doorgegehaald weergeven";

            //Menu Beeld
            beeldToolStripMenuItem.Text = "Beeld";

            toolBarToolStripMenuItem.Tag = "Schakel toolbar aan of uit";
            toolBarToolStripMenuItem.Text = "Werkbalk";
            toolBarToolStripMenuItem.ToolTipText = "Toolbalk aan of uit";

            statusBarToolStripMenuItem.Tag = "Schakel statusbalk aan of uit/";
            statusBarToolStripMenuItem.Text = "Statusbalk";
            statusBarToolStripMenuItem.ToolTipText = "Statusbalk aan of uit";

            // Menu Help
            optiesToolStripMenuItem.Tag = "Stel directorie\'s in en tekstfragmenten in";
            optiesToolStripMenuItem.Text = "Optie's";
            optiesToolStripMenuItem.ToolTipText = "stel uw optie's in";

            aboutToolStripMenuItem.Tag = "Laat de infobox zien";
            aboutToolStripMenuItem.Text = "&Info...";

            // Tool strip
            // Toolstrip

            newToolStripButton.Tag = newToolStripMenuItem.Tag.ToString();
            newToolStripButton.ToolTipText = newToolStripMenuItem.ToolTipText.ToString();

            openToolStripButton.Tag = openToolStripMenuItem.Tag.ToString();
            openToolStripButton.ToolTipText = openToolStripMenuItem.ToolTipText.ToString();

            saveToolStripButton.Tag = saveToolStripMenuItem.Tag.ToString();
            saveToolStripButton.ToolTipText = saveToolStripMenuItem.ToolTipText.ToString();

            printpreviewToolStripButton.Tag = printPreviewToolStripMenuItem.Tag.ToString();
            printpreviewToolStripButton.ToolTipText = printPreviewToolStripMenuItem.ToolTipText.ToString();

            printToolStripButton.Tag = printToolStripMenuItem.Tag.ToString();
            printToolStripButton.ToolTipText = printToolStripMenuItem.ToolTipText.ToString();

            cutToolStripButton.Tag = cutToolStripMenuItem.Tag.ToString();
            cutToolStripButton.ToolTipText = cutToolStripMenuItem.ToolTipText.ToString();

            copyToolStripButton.Tag = copyToolStripMenuItem.Tag.ToString();
            copyToolStripButton.ToolTipText = copyToolStripMenuItem.ToolTipText.ToString();

            pasteToolStripButton.Tag = pasteToolStripMenuItem.Tag.ToString(); ;
            pasteToolStripButton.ToolTipText = pasteToolStripMenuItem.ToolTipText.ToString();

            formatboldToolStripButton.Tag = formatboldToolStripMenuItem.Tag.ToString();
            formatboldToolStripButton.ToolTipText = formatboldToolStripMenuItem.ToolTipText.ToString();

            formatitalicToolStripButton.Tag = formatitalicToolStripMenuItem.Tag.ToString();
            formatitalicToolStripButton.ToolTipText = formatitalicToolStripMenuItem.ToolTipText.ToString();

            formatstrikeToolStripButton.Tag = formatunderscoreToolStripMenuItem.Tag.ToString();
            formatstrikeToolStripButton.ToolTipText = formatunderscoreToolStripMenuItem.ToolTipText.ToString();

            formatunderscoreToolStripButton.Tag = formatunderscoreToolStripMenuItem.Tag.ToString();
            formatunderscoreToolStripButton.ToolTipText = formatunderscoreToolStripMenuItem.ToolTipText.ToString();

            formatleftToolStripButton.Tag = formatrightToolStripMenuItem.Tag.ToString();
            formatleftToolStripButton.ToolTipText = formatrightToolStripMenuItem.ToolTipText.ToString();

            formatcenterToolStripButton.Tag = formatcenterToolStripMenuItem.Tag.ToString();
            formatcenterToolStripButton.ToolTipText = formatcenterToolStripMenuItem.ToolTipText.ToString();

            formatrightToolStripButton.Tag = formatleftToolStripMenuItem.Tag.ToString();
            formatrightToolStripButton.ToolTipText = formatleftToolStripMenuItem.ToolTipText.ToString();

            bulletToolStripButton.Tag = bulletToolStripMenuItem.Tag.ToString();
            bulletToolStripButton.ToolTipText = bulletToolStripMenuItem.ToolTipText.ToString();

            lessindentToolStripButton.Tag = lessindentToolStripMenuItem.Tag.ToString();
            lessindentToolStripButton.ToolTipText = lessindentToolStripMenuItem.ToolTipText.ToString();

            moreindentToolStripButton.Tag = moreindentToolStripMenuItem.Tag.ToString();
            moreindentToolStripButton.ToolTipText = moreindentToolStripMenuItem.ToolTipText.ToString();

            lessindentrightToolStripButton.Tag = lessindentrightToolStripMenuItem.Tag.ToString();
            lessindentrightToolStripButton.ToolTipText = lessindentrightToolStripMenuItem.ToolTipText.ToString();

            moreindentrightToolStripButton.Tag = moreindentrightToolStripMenuItem.Tag.ToString();
            moreindentrightToolStripButton.ToolTipText = moreindentrightToolStripMenuItem.ToolTipText.ToString();

            lesshangindentToolStripButton.Tag = lesshangindentToolStripMenuItem.Tag.ToString();
            lesshangindentToolStripButton.ToolTipText = lesshangindentToolStripMenuItem.ToolTipText.ToString();

            morehangindentToolStripButton.Tag = morehangindentToolStripMenuItem.Tag.ToString();
            morehangindentToolStripButton.ToolTipText = morehangindentToolStripMenuItem.ToolTipText.ToString();

            zoominToolStripButton.Tag = "Met iedere klik worden de letters twee maal vergroot";
            zoominToolStripButton.ToolTipText = "Vergroot letters";

            zoomoutToolStripButton.Tag = "Met iedere klik worden de letters twee maal verkleint";
            zoomoutToolStripButton.Text = "verklein letters";

            comboboxsize.Tag = "Kies een letter grootte";
            comboboxsize.ToolTipText = "Letter grootte";

            comboboxcolor.Tag = "Kies een kleur";
            comboboxcolor.ToolTipText = "141 kleuren";

            comboboxtext.Tag = "Kies een letter type";
            comboboxtext.ToolTipText = "Lettertypes";

            clearToolStripMenuItem.Text = "Wissen";
            clearToolStripMenuItem.ToolTipText = "Wis document ";
            clearToolStripMenuItem.Tag = "Maak het gehele document leeg";

            languagetoolStripComboBox.Tag = "Geef het gehele programma in een andere taal weer";
            languagetoolStripComboBox.ToolTipText = "Wijzig taal";

            sbpMenu.Text = "Gereed";
        }

        void English()
        {
            // Menu Bestand
            fileToolStripMenuItem.Text = "&File";
            // New menu
            newToolStripMenuItem.Tag = "Save the ecxist files, close all the tab-pages and make a new tab-page";
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.ToolTipText = "Make a new document";
            // Open menu
            openToolStripMenuItem.Tag = "Open een bestaand bestand in de geselecteerde pagina";
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.ToolTipText = "Open bestaand bestand";
            // Deserialisatie
            deserializeToolStripMenuItem.Tag = "Laad een geserialiseerd bestand in pagina\'s";
            deserializeToolStripMenuItem.Text = "Deseriali&ze";
            deserializeToolStripMenuItem.ToolTipText = "Laad een .srl bestand";
            // Bewaar menu
            saveToolStripMenuItem.Tag = "Bewaar de geselecteerde pagina in een bestand onder de naam van de pagina-tab";
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.ToolTipText = "Sla pagina op";
            // Bewaar als menu
            saveAsToolStripMenuItem.Tag = "Bewaar de geselecteerde pagina in een op te geven bestand";
            saveAsToolStripMenuItem.Text = "Save as...";
            saveAsToolStripMenuItem.ToolTipText = "Sla pagina op in bestand";
            // bewaar alles menu
            saveAllToolStripMenuItem.Tag = "Bewaar alle pagina\'s in bestanden onder de naam van de pagina tab";
            saveAllToolStripMenuItem.Text = "Save all";
            saveAllToolStripMenuItem.ToolTipText = "Sla alle pagina's op";
            // Serialisatie menu
            serializeAllToolStripMenuItem.Tag = "Bewaar alle pagina\'s in een geserialiseerd bestans";
            serializeAllToolStripMenuItem.Text = "Serialize All";
            serializeAllToolStripMenuItem.ToolTipText = "Maak een .srl bestand";
            // Sluit menu
            closeToolStripMenuItem.Tag = "Sluit de geselecteerde tab-pagina";
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.ToolTipText = "Sluit pagina";
            // sluit Allemenu
            closeAllToolStripMenuItem.Tag = "Sluit alle tab-pagina\'s";
            closeAllToolStripMenuItem.Text = "Close all";
            closeAllToolStripMenuItem.ToolTipText = "Alle pagina's sluiten";
            // Pagina instellingen menu
            pageSetupToolStripMenuItem.Tag = "Toon dialoogkader Pagina instellingen en stel ze in";
            pageSetupToolStripMenuItem.Text = "Page Setup";
            pageSetupToolStripMenuItem.ToolTipText = "Geef de pagina instellingen";
            // Afdruk Menu
            printToolStripMenuItem.Tag = "Druk de geselecteerde pagina af";
            printToolStripMenuItem.Text = "Print";
            printToolStripMenuItem.ToolTipText = "Druk pagina af";
            // Print voorbeeld menu
            printPreviewToolStripMenuItem.Tag = "Toon afdrukvoorbeeld van de geselecteerde pagina op scherm";
            printPreviewToolStripMenuItem.Text = "Print preview";
            printPreviewToolStripMenuItem.ToolTipText = "Geef afdruk voorbeeld";
            // Laatst geopen menu
            recentfilelistToolstripMenuItem.Text = "Recent opened documents";
            // afsluiten menu
            exitToolStripMenuItem.Tag = "Sluit het programma af";
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.ToolTipText = "Exit Program";


            // Menu Bewerken
            editToolStripMenuItem.Text = "&Edit";
            // Menu undo
            undoToolStripMenuItem.Tag = "De laatste bewerking die gedaan is wordt ongedaan gemnaakt";
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.ToolTipText = "Maak de laatste bewerking ongedaan";
            //Menu redo
            redoToolStripMenuItem.Tag = "Herstel ongedaan";
            redoToolStripMenuItem.Text = "&Redo";
            redoToolStripMenuItem.ToolTipText = "Herstel de laaste bewerking die ongedaan is gemaakt";
            //Menu knippen
            cutToolStripMenuItem.Tag = "Knip selectie en kopieer naar klembord";
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.ToolTipText = "Knip en Kopieer";
            // Menu Kopieren
            copyToolStripMenuItem.Tag = "Kopieer selectie naar klembord";
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.ToolTipText = "Kopieer";
            // Menu Plakken
            pasteToolStripMenuItem.Tag = "Plak tekst uit klembord";
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.ToolTipText = "Plak";
            // Menu Zoek en vervang
            searchandreplaceToolStripMenuItem.Tag = "Roept het dialoog kader aan voor het Zoeken of wijzig tekesten";
            searchandreplaceToolStripMenuItem.Text = "Search and Change...";
            searchandreplaceToolStripMenuItem.ToolTipText = "Zoeken en wijzigen van teksten";
            // Menu Selecteer alles
            selectAllToolStripMenuItem.Tag = "Selecteer alles op de pagina";
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.ToolTipText = "Selecteer alle tekst";
            // Menu Verwijderen
            deleteToolStripMenuItem.Tag = "Verwijder de geselecteerde tekst";
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.ToolTipText = "Verwijder tekst";

            // Menu Toevoegen
            insertToolStripMenuItem.Text = "Add";
            // Menu Nieuwe Pagina
            tabPageToolStripMenuItem.Tag = "Voeg een nieuw tabpagina toe";
            tabPageToolStripMenuItem.Text = "Tab";
            tabPageToolStripMenuItem.ToolTipText = "Nieuwe pagina";
            // Menu Emoticons
            contextmenuemoticonsToolStripMenuItem.Tag = "Er verschijnt een popup menu waaruit U een emoticon kunt toevoegen";
            contextmenuemoticonsToolStripMenuItem.Text = "Emoticons";
            contextmenuemoticonsToolStripMenuItem.ToolTipText = "Voeg een emoticon toe";
            // Menu Afbeelding
            imageToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een afbeelding toe te voegen";
            imageToolStripMenuItem.Text = "Image";
            imageToolStripMenuItem.ToolTipText = "Voeg een afbeelding toe";
            //Menu Tekst
            txtToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een een teksbestand toe te voegen";
            txtToolStripMenuItem.Text = "Text";
            txtToolStripMenuItem.ToolTipText = "Voeg tekst bestand toe";
            //Menu Tekst fragment
            contextmenutextToolStripMenuItem.Tag = "Er verschijnt een popup menu waaruit U een tekst fragment kunt toevoegen";
            contextmenutextToolStripMenuItem.Text = "Text fragment";
            contextmenutextToolStripMenuItem.ToolTipText = "Voeg tekst fragment toe";

            // Menu Opmaak
            layoutToolStripMenuItem.Text = "Format";

            wordWrapToolStripMenuItem.Text = "Word wrap";
            wordWrapToolStripMenuItem.Tag = "Regels lopen door of worden afgebroken naar de volegende regel";
            wordWrapToolStripMenuItem.ToolTipText = "Wel of niet woord afbreken";

            bulletToolStripMenuItem.Tag = "Spring in met een bullet";
            bulletToolStripMenuItem.Text = "Bullet";
            bulletToolStripMenuItem.ToolTipText = "Wel of geen opsommings teken";

            fontsToolStripMenuItem.Tag = "Er verschijnt een dialoogkader om een letter type te kiezen";
            fontsToolStripMenuItem.Text = "Font";
            fontsToolStripMenuItem.ToolTipText = "Wijzig lettertype";

            colorToolStripMenuItem.Tag = "Er verschijnt een dialoogkader  waaruit U een kleur kunt kiezen";
            colorToolStripMenuItem.Text = "Color";
            colorToolStripMenuItem.ToolTipText = "Wijzig kleur letters";

            backcolorToolStripMenuItem.Text = "Back color";
            backcolorToolStripMenuItem.Tag = "Er verschijnt een dialoogkader waaruit U een kleur kunt kiezen";

            txtsizeToolStripMenuItem.Tag = "Selecteer een grootte voor de geselecteerde tekst";
            txtsizeToolStripMenuItem.Text = "Size";
            txtsizeToolStripMenuItem.ToolTipText = "Wijzig grootte";

            size10ToolStripMenuItem.Text = "10";
            size12ToolStripMenuItem.Text = "12";
            size14ToolStripMenuItem.Text = "14";
            size16ToolStripMenuItem.Text = "16";
            size18ToolStripMenuItem.Text = "18";
            size20ToolStripMenuItem.Text = "20";
            size24ToolStripMenuItem.Text = "24";
            size30ToolStripMenuItem.Text = "30";
            size36ToolStripMenuItem.Text = "36";
            size72ToolStripMenuItem.Text = "72";

            indentToolStripMenuItem.Text = "Indent";
            indentToolStripMenuItem.Tag = "De linker marge kan vergroot of verkleind worden";
            indentToolStripMenuItem.ToolTipText = "Stel linker marge in";

            lessindentToolStripMenuItem.Text = "Less";
            lessindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de linker marge verlaagd met 30 punten";
            lessindentToolStripMenuItem.ToolTipText = "Verklein linker marge";

            moreindentToolStripMenuItem.Text = "More";
            moreindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de linker marge verhoogd met 30 punten";
            moreindentToolStripMenuItem.ToolTipText = "Vergroot linker marge";


            indentrightToolStripMenuItem.Text = "Right Indent";
            indentrightToolStripMenuItem.Tag = "De rechter marge kan vergroot of verkleind worden";
            indentrightToolStripMenuItem.ToolTipText = "Stel rechter marge";

            moreindentrightToolStripMenuItem.Text = "More";
            moreindentrightToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de rechter marge verhoogd met 30 punten";
            moreindentrightToolStripMenuItem.ToolTipText = "Vergroot rechter marge";

            lessindentrightToolStripMenuItem.Text = "Less";
            lessindentrightToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de rechter marge verlaagd met 30 punten";
            lessindentrightToolStripMenuItem.ToolTipText = "Verklein rechter marge";

            hangindentToolStripMenuItem.Text = "Hang Indent";
            hangindentToolStripMenuItem.Tag = "Het inspringen van de alinia kan vergroot of verkleind worden. De eerste regel van de zin springt niet mee";
            hangindentToolStripMenuItem.ToolTipText = "Stel alinia inspringen in";

            morehangindentToolStripMenuItem.Text = "More";
            morehangindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de alinia marge verhoogd met 30 punten. De eerste regel van de zin springt niet mee";
            morehangindentToolStripMenuItem.ToolTipText = "Vergroot alinia marge";

            lesshangindentToolStripMenuItem.Text = "Less";
            lesshangindentToolStripMenuItem.Tag = "Bij meerdere keren aanklikken wordt de alinia marge verkleind met 30 punten. De eerste regel van de zin springt niet mee";
            lesshangindentToolStripMenuItem.ToolTipText = "Verkleinen alinia marge";
            // formatrightToolStripMenuItem
            // 
            formatleftToolStripMenuItem.Text = "Format right";
            formatleftToolStripMenuItem.Tag = "De tekst word aan de linker kant uitgelijnd";
            formatleftToolStripMenuItem.ToolTipText = "Tekst links uitlijnen";
            // 
            // formatleftToolStripMenuItem
            // 
            formatrightToolStripMenuItem.Text = "Format left";
            formatrightToolStripMenuItem.Tag = "De tekst word aan de rechter kant uitgelijnd";
            formatrightToolStripMenuItem.ToolTipText = "Tekst rechts uitlijnen";
            // 
            // formatcenterToolStripMenuItem
            // 
            formatcenterToolStripMenuItem.Text = "Format center";
            formatcenterToolStripMenuItem.Tag = "De tekst wordt gecentreerdd";
            formatcenterToolStripMenuItem.ToolTipText = "Tekst gecentreerd uitlijnen";
            // formatrightToolStripButton
            // 
            formatrightToolStripButton.Text = "Format right";
            formatrightToolStripButton.Tag = "De tekst word aan de linker kant uitgelijnd";
            formatrightToolStripButton.ToolTipText = "Tekst links uitlijnen";
            // 
            // formatleftToolStripButton
            // 
            formatleftToolStripButton.Text = "Format left";
            formatleftToolStripButton.Tag = "De tekst word aan de rechter kant uitgelijnd";
            formatleftToolStripButton.ToolTipText = "Tekst rechts uitlijnen";
            // 
            // formatcenterToolStripButton
            // 
            formatcenterToolStripButton.Text = "Format center";
            formatcenterToolStripButton.Tag = "De tekst wordt gecentreerdd";
            formatcenterToolStripButton.ToolTipText = "Tekst gecentreerd uitlijnen";
            // 
            // tekstVetToolStripMenuItem
            // 
            formatboldToolStripMenuItem.Text = "Bold";
            formatboldToolStripMenuItem.Tag = "De geselecteerde tekst wordt vet weergegeven";
            formatboldToolStripMenuItem.ToolTipText = "Tekst vet weergeven";
            // 
            // formatitalicToolStripMenuItem
            // 
            formatitalicToolStripMenuItem.Text = "Italic";
            formatitalicToolStripMenuItem.Tag = "De geselecteerde tekst wordt schuin weergegeven";
            formatitalicToolStripMenuItem.ToolTipText = "Tekst schuin weergeven";
            // 
            // tekstToolStripMenuItem1
            // 
            formatunderscoreToolStripMenuItem.Text = "Underscore";
            formatunderscoreToolStripMenuItem.Tag = "De geselecteerde tekst wordt onderstreept weergegeven";
            formatunderscoreToolStripMenuItem.ToolTipText = "Tekst onderstreept weergeven";
            // 
            // tekstDoorgegehaaldToolStripMenuItem
            // 
            formatstrikeToolStripMenuItem.Text = "Strike";
            formatstrikeToolStripMenuItem.Tag = "De geselecteerde tekst wordt doorgehaald weergegeven";
            formatstrikeToolStripMenuItem.ToolTipText = "Tekst doorgegehaald weergeven";

            //Menu Beeld
            beeldToolStripMenuItem.Text = "View";

            toolBarToolStripMenuItem.Tag = "Schakel toolbar aan of uit";
            toolBarToolStripMenuItem.Text = "Toolbar";
            toolBarToolStripMenuItem.ToolTipText = "Toolbalk aan of uit";

            statusBarToolStripMenuItem.Tag = "Schakel statusbalk aan of uit/";
            statusBarToolStripMenuItem.Text = "Statusbar";
            statusBarToolStripMenuItem.ToolTipText = "Statusbalk aan of uit";

            // Menu Help
            optiesToolStripMenuItem.Tag = "Stel directorie\'s in en tekstfragmenten in";
            optiesToolStripMenuItem.Text = "Options";
            optiesToolStripMenuItem.ToolTipText = "stel uw optie's in";

            aboutToolStripMenuItem.Tag = "Laat de infobox zien";
            aboutToolStripMenuItem.Text = "&About...";

            // Tool strip
            // Toolstrip

            newToolStripButton.Tag = newToolStripMenuItem.Tag.ToString();
            newToolStripButton.ToolTipText = newToolStripMenuItem.ToolTipText.ToString();

            openToolStripButton.Tag = openToolStripMenuItem.Tag.ToString();
            openToolStripButton.ToolTipText = openToolStripMenuItem.ToolTipText.ToString();

            saveToolStripButton.Tag = saveToolStripMenuItem.Tag.ToString();
            saveToolStripButton.ToolTipText = saveToolStripMenuItem.ToolTipText.ToString();

            printpreviewToolStripButton.Tag = printPreviewToolStripMenuItem.Tag.ToString();
            printpreviewToolStripButton.ToolTipText = printPreviewToolStripMenuItem.ToolTipText.ToString();

            printToolStripButton.Tag = printToolStripMenuItem.Tag.ToString();
            printToolStripButton.ToolTipText = printToolStripMenuItem.ToolTipText.ToString();

            cutToolStripButton.Tag = cutToolStripMenuItem.Tag.ToString();
            cutToolStripButton.ToolTipText = cutToolStripMenuItem.ToolTipText.ToString();

            copyToolStripButton.Tag = copyToolStripMenuItem.Tag.ToString();
            copyToolStripButton.ToolTipText = copyToolStripMenuItem.ToolTipText.ToString();

            pasteToolStripButton.Tag = pasteToolStripMenuItem.Tag.ToString(); ;
            pasteToolStripButton.ToolTipText = pasteToolStripMenuItem.ToolTipText.ToString();

            formatboldToolStripButton.Tag = formatboldToolStripMenuItem.Tag.ToString();
            formatboldToolStripButton.ToolTipText = formatboldToolStripMenuItem.ToolTipText.ToString();

            formatitalicToolStripButton.Tag = formatitalicToolStripMenuItem.Tag.ToString();
            formatitalicToolStripButton.ToolTipText = formatitalicToolStripMenuItem.ToolTipText.ToString();

            formatstrikeToolStripButton.Tag = formatunderscoreToolStripMenuItem.Tag.ToString();
            formatstrikeToolStripButton.ToolTipText = formatunderscoreToolStripMenuItem.ToolTipText.ToString();

            formatunderscoreToolStripButton.Tag = formatunderscoreToolStripMenuItem.Tag.ToString();
            formatunderscoreToolStripButton.ToolTipText = formatunderscoreToolStripMenuItem.ToolTipText.ToString();

            formatleftToolStripButton.Tag = formatrightToolStripMenuItem.Tag.ToString();
            formatleftToolStripButton.ToolTipText = formatrightToolStripMenuItem.ToolTipText.ToString();

            formatcenterToolStripButton.Tag = formatcenterToolStripMenuItem.Tag.ToString();
            formatcenterToolStripButton.ToolTipText = formatcenterToolStripMenuItem.ToolTipText.ToString();

            formatrightToolStripButton.Tag = formatleftToolStripMenuItem.Tag.ToString();
            formatrightToolStripButton.ToolTipText = formatleftToolStripMenuItem.ToolTipText.ToString();

            bulletToolStripButton.Tag = bulletToolStripMenuItem.Tag.ToString();
            bulletToolStripButton.ToolTipText = bulletToolStripMenuItem.ToolTipText.ToString();

            lessindentToolStripButton.Tag = lessindentToolStripMenuItem.Tag.ToString();
            lessindentToolStripButton.ToolTipText = lessindentToolStripMenuItem.ToolTipText.ToString();

            moreindentToolStripButton.Tag = moreindentToolStripMenuItem.Tag.ToString();
            moreindentToolStripButton.ToolTipText = moreindentToolStripMenuItem.ToolTipText.ToString();

            lessindentrightToolStripButton.Tag = lessindentrightToolStripMenuItem.Tag.ToString();
            lessindentrightToolStripButton.ToolTipText = lessindentrightToolStripMenuItem.ToolTipText.ToString();

            moreindentrightToolStripButton.Tag = moreindentrightToolStripMenuItem.Tag.ToString();
            moreindentrightToolStripButton.ToolTipText = moreindentrightToolStripMenuItem.ToolTipText.ToString();

            lesshangindentToolStripButton.Tag = lesshangindentToolStripMenuItem.Tag.ToString();
            lesshangindentToolStripButton.ToolTipText = lesshangindentToolStripMenuItem.ToolTipText.ToString();

            morehangindentToolStripButton.Tag = morehangindentToolStripMenuItem.Tag.ToString();
            morehangindentToolStripButton.ToolTipText = morehangindentToolStripMenuItem.ToolTipText.ToString();

            zoominToolStripButton.Tag = "Met iedere klik worden de letters twee maal vergroot";
            zoominToolStripButton.ToolTipText = "Vergroot letters";

            zoomoutToolStripButton.Tag = "Met iedere klik worden de letters twee maal verkleint";
            zoomoutToolStripButton.Text = "verklein letters";

            comboboxsize.Tag = "Kies een letter grootte";
            comboboxsize.ToolTipText = "Letter grootte";

            comboboxcolor.Tag = "Kies een kleur";
            comboboxcolor.ToolTipText = "141 kleuren";

            comboboxtext.Tag = "Kies een letter type";
            comboboxtext.ToolTipText = "Lettertypes";

            languagetoolStripComboBox.Tag = "Geef het gehele programma in een andere taal weer";
            languagetoolStripComboBox.ToolTipText = "Change language";

            sbpMenu.Text = "Gereed";

            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.ToolTipText = "Clear document ";
            clearToolStripMenuItem.Tag = "Clear the whole document";
        }

        #endregion

        #region combotoolbar

        private void addComboboxkleur()
        {
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));

            foreach (String kleurnaam in kleur)
                comboboxcolor.Items.Add(kleurnaam);
            comboboxcolor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboboxcolor.ComboBox.DrawItem += new DrawItemEventHandler(ComboBoxKleur_DrawItem);
        }

        private void ComboBoxKleur_DrawItem(object sender, DrawItemEventArgs e)
        {
            // If the index is invalid then simply exit.
            if (e.Index == -1 || e.Index >= comboboxcolor.Items.Count)
                return;

            // Draw the background of the item.
            e.DrawBackground();

            // Should we draw the focus rectangle?
            if ((e.State & DrawItemState.Focus) != 0)
                e.DrawFocusRectangle();
            Brush b = null;

            try
            {
                // Create a new background brush.
                b = new SolidBrush(zoekColor(comboboxcolor.Items[e.Index].ToString()));
                Font font = new Font(comboboxcolor.Items[e.Index].ToString(), 10F, FontStyle.Bold);
                // Draw the item.
                e.Graphics.DrawString(comboboxcolor.Items[e.Index].ToString(), font, b, e.Bounds);
            } // End try
            finally
            {
                // Should we cleanup the brush?
                if (b != null)
                    b.Dispose();
                b = null;
            } // End finally
        }

        private void comboboxcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox box = (ToolStripComboBox)sender;
            int index = ZoekTab();
            richTextBox[index].SelectionColor = zoekColor(box.Text);
            richTextBox[index].Focus();
        }

        private void addComboboxLetters()
        {

            // Get an array of the available font families.
            FontFamily[] families = FontFamily.Families;

            // Draw text using each of the font families.
            Font familiesFont;

            foreach (FontFamily family in families)
            {
                if (family.IsStyleAvailable(FontStyle.Regular))
                {
                    familiesFont = new Font(family, 10);
                    comboboxtext.Items.Add((new Font(family, 10F)).Name);
                }
                comboboxtext.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
                comboboxtext.ComboBox.DrawItem += new DrawItemEventHandler(ComboBoxLetters_DrawItem);
            }
            this.Focus();
        }

        private void ComboBoxLetters_DrawItem(object sender, DrawItemEventArgs e)
        {
            // If the index is invalid then simply exit.
            if (e.Index == -1 || e.Index >= comboboxtext.Items.Count)
                return;

            // Draw the background of the item.
            e.DrawBackground();

            // Should we draw the focus rectangle?
            if ((e.State & DrawItemState.Focus) != 0)
                e.DrawFocusRectangle();
            Brush b = null;

            try
            {
                // Create a new background brush.
                b = new SolidBrush(e.ForeColor);
                // Draw the item.
                e.Graphics.DrawString(comboboxtext.Items[e.Index].ToString(), new Font(comboboxtext.Items[e.Index].ToString(), 10F), b, e.Bounds);
            } // End try
            finally
            {
                // Should we cleanup the brush?
                if (b != null)
                    b.Dispose();
                b = null;
            } // End finally
        }

        private void comboboxtext_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox box = (ToolStripComboBox)sender;
            int index = ZoekTab();
            richTextBox[index].SetSelectionFont(box.Text);
            richTextBox[index].Focus();

        }

        private void comboboxsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox box = (ToolStripComboBox)sender;
            int index = ZoekTab();
            richTextBox[index].SetSelectionSize(int.Parse(box.Text));
        }

        #endregion

        #region Bars

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonStrip.Visible = toolBarToolStripMenuItem.Checked;
            comboStrip.Visible = toolBarToolStripMenuItem.Checked;

        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;

        }

        void TabText1_CursorPositionChanged(object sender, EventArgs e)
        {
            UpdateStatusBarPosition();
        }

        void TabText1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectionChange();
        }

        void UpdateSelectionChange()
        {
            int index = ZoekTab();
            if (index != -1)
            {
                int start = richTextBox[index].SelectionStart;
                int end = richTextBox[index].SelectionEnd;
                int length = richTextBox[index].SelectionLength;

                sbpSelectieStatusLabel.Text = "Selectie: Start " + start + ", Eind " + end + ", Lengte " + length;
            }
        }

        private void UpdateStatusBarPosition()
        {
            int index = ZoekTab();
            if (index != -1)
            {
                int line = richTextBox[index].CurrentLine;
                int col = richTextBox[index].CurrentColumn;
                int pos = richTextBox[index].CurrentPosition;

                sbpPositionStatusLabel.Text = "In tekst: Regel " + line + ", Kolom " + col + ", Plaats " + pos;

                HorizontalAlignment al = richTextBox[index].SelectionAlignment;
                if (al == HorizontalAlignment.Left)
                {
                    formatleftToolStripButton.Checked = true;
                    formatcenterToolStripButton.Checked = false;
                    formatrightToolStripButton.Checked = false;
                    formatrightToolStripMenuItem.Checked = false;
                    formatcenterToolStripMenuItem.Checked = false;
                    formatleftToolStripMenuItem.Checked = true;
                }
                if (al == HorizontalAlignment.Center)
                {
                    formatcenterToolStripButton.Checked = true;
                    formatleftToolStripButton.Checked = false;
                    formatrightToolStripButton.Checked = false;
                    formatcenterToolStripMenuItem.Checked = true;
                    formatrightToolStripMenuItem.Checked = false;
                    formatleftToolStripMenuItem.Checked = false;
                }
                if (al == HorizontalAlignment.Right)
                {
                    formatcenterToolStripButton.Checked = false;
                    formatleftToolStripButton.Checked = false;
                    formatrightToolStripButton.Checked = true;
                    formatcenterToolStripMenuItem.Checked = false;
                    formatrightToolStripMenuItem.Checked = true;
                    formatleftToolStripMenuItem.Checked = false;
                }
                if (richTextBox[index].SelectionBullet == true)
                {
                    bulletToolStripButton.Checked = true;
                    bulletToolStripMenuItem.Checked = true;
                }
                else
                {
                    bulletToolStripButton.Checked = false;
                    bulletToolStripMenuItem.Checked = false;
                }

                if (richTextBox[index].SelectionFont.Bold == true)
                {
                    formatboldToolStripButton.Checked = true;
                    formatboldToolStripMenuItem.Checked = true;
                }
                else
                {
                    formatboldToolStripButton.Checked = false;
                    formatboldToolStripMenuItem.Checked = false;
                }

                if (richTextBox[index].SelectionFont.Italic == true)
                {
                    formatitalicToolStripMenuItem.Checked = true;
                    formatitalicToolStripButton.Checked = true;
                }
                else
                {
                    formatitalicToolStripButton.Checked = false;
                    formatitalicToolStripMenuItem.Checked = false;
                }

                if (richTextBox[index].SelectionFont.Underline == true)
                {
                    formatunderscoreToolStripButton.Checked = true;
                    formatunderscoreToolStripMenuItem.Checked = true;
                }
                else
                {
                    formatunderscoreToolStripButton.Checked = false;
                    formatunderscoreToolStripMenuItem.Checked = false;
                }

                if (richTextBox[index].SelectionFont.Strikeout == true)
                {
                    formatstrikeToolStripButton.Checked = true;
                    formatstrikeToolStripMenuItem.Checked = true;
                }
                else
                {
                    formatstrikeToolStripButton.Checked = false;
                    formatstrikeToolStripMenuItem.Checked = false;
                }

                if (richTextBox[index].SelectionHangingIndent > 0)
                {
                    lesshangindentToolStripButton.Enabled = true;
                    lesshangindentToolStripMenuItem.Enabled = true;
                }
                else
                {
                    lesshangindentToolStripButton.Enabled = false;
                    lesshangindentToolStripMenuItem.Enabled = false;
                }

                if (richTextBox[index].SelectionIndent > 0)
                {
                    lessindentToolStripMenuItem.Enabled = true;
                    lessindentToolStripMenuItem.Enabled = true;
                }
                else
                {
                    lessindentToolStripButton.Enabled = false;
                    lessindentToolStripMenuItem.Enabled = false;
                }

                if (richTextBox[index].SelectionRightIndent > 0)
                {
                    lessindentrightToolStripMenuItem.Enabled = true;
                    lessindentrightToolStripMenuItem.Enabled = true;
                }
                else
                {
                    lessindentrightToolStripButton.Enabled = false;
                    lessindentrightToolStripMenuItem.Enabled = false;
                }
                Font font = richTextBox[index].SelectionFont;
                comboboxtext.Text = font.Name.ToString();
                Color color = richTextBox[index].SelectionColor;
                comboboxcolor.Text = color.Name.ToString();
                comboboxsize.Text = richTextBox[index].SelectionFont.Size.ToString();
            }
        }

        #endregion

        #region Registry

        protected virtual void SaveRegistryInfo(RegistryKey regkey)
        {
            int index = ZoekTab();
            regkey.SetValue("filenaamEmoticons", filenaamEmoticons);
            regkey.SetValue("filenameTextFragments", filenameTextFragments);
            regkey.SetValue(strWinState, (int)WindowState);
            regkey.SetValue(strLocationX, rectNormal.X);
            regkey.SetValue(strLocationY, rectNormal.Y);
            regkey.SetValue(strWidth, rectNormal.Width);
            regkey.SetValue(strHeight, rectNormal.Height);
            regkey.SetValue(strWordWrap, Convert.ToInt32(richTextBox[index].WordWrap));
            regkey.SetValue(strFontFace, richTextBox[index].Font.Name);
            regkey.SetValue(strFontSize, richTextBox[index].Font.SizeInPoints.ToString());
            regkey.SetValue(strFontStyle, (int)richTextBox[index].Font.Style);
            regkey.SetValue(strForeColor, richTextBox[index].ForeColor.ToArgb());
            regkey.SetValue(strBackColor, richTextBox[index].BackColor.ToArgb());

            for (int i = 0; i < 16; i++)
                regkey.SetValue(strCustomClr + i, colorDialog.CustomColors[i]);
        }

        protected virtual void LoadRegistryInfo(RegistryKey regkey)
        {
            int index = ZoekTab();
            filenameTextFragments =(string) regkey.GetValue("filenameTextFragments");
            filenaamEmoticons =(string) regkey.GetValue("filenaamEmoticons");
            int x = (int)regkey.GetValue(strLocationX, 100);
            int y = (int)regkey.GetValue(strLocationY, 100);
            int cx = (int)regkey.GetValue(strWidth, 300);
            int cy = (int)regkey.GetValue(strHeight, 300);

            rectNormal = new Rectangle(x, y, cx, cy);

            // Adjust rectangle for any change in desktop size.

            Rectangle rectDesk = SystemInformation.WorkingArea;

            rectNormal.Width = Math.Min(rectNormal.Width, rectDesk.Width);
            rectNormal.Height = Math.Min(rectNormal.Height, rectDesk.Height);
            rectNormal.X -= Math.Max(rectNormal.Right - rectDesk.Right, 0);
            rectNormal.Y -= Math.Max(rectNormal.Bottom - rectDesk.Bottom, 0);

            // Set form properties.

            DesktopBounds = rectNormal;
            WindowState = (FormWindowState)regkey.GetValue(strWinState, 0);

            richTextBox[index].WordWrap = Convert.ToBoolean((int)regkey.GetValue(strWordWrap));
            richTextBox[index].Font = new Font((string)regkey.GetValue(strFontFace), float.Parse((string)regkey.GetValue(strFontSize)), (FontStyle)regkey.GetValue(strFontStyle));
            richTextBox[index].ForeColor = Color.FromArgb((int)regkey.GetValue(strForeColor));
            richTextBox[index].BackColor = Color.FromArgb((int)regkey.GetValue(strBackColor));

            int[] aiColors = new int[16];

            for (int i = 0; i < 16; i++)
                aiColors[i] = (int)regkey.GetValue(strCustomClr + i);

            colorDialog.CustomColors = aiColors;

        }
      
        #endregion

        #region TabText1 routines

        private void TabText1_Load(object sender, EventArgs e)
        {
            strRegKey = strRegKey + strFileName;
            for (int index = 0; index < 10; index++)
                recentFiles[index] = new ToolStripMenuItem();
            RegistryKey dirkey = Registry.CurrentUser.OpenSubKey(strRegKey);
            if (dirkey != null)
                documentDir = (string)dirkey.GetValue("documentDir");
            if (documentDir == null)
            {

                String dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                dir = dir + "\\Compenkie\\TabText1";
                Directory.CreateDirectory(dir);
                if (Directory.Exists(dir))
                    documentDir = dir;
                else
                    documentDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                AddPage(maxTab++);
            }
            else
            {
                AddPage(maxTab++);

                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegKey);

                if (regkey != null)
                {
                    LoadRegistryInfo(regkey);
                    regkey.Close();
                }

                RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegKey + "Recent File List\\");
                if (key != null)
                {
                    try
                    {

                        for (maxRecent = 0; maxRecent < 10; maxRecent++)
                        {
                            string sKey = "file" + maxRecent.ToString();
                            string longfileNaam = (string)key.GetValue(sKey, "");
                            if (longfileNaam.Length == 0)
                                break;

                            recentFiles[maxRecent].ToolTipText = longfileNaam.ToString();
                            recentFiles[maxRecent].Text = GetShortDisplayName(longfileNaam, 40);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Loading Recent Files from Registry failed: " + ex.Message);
                    }
                    key.Close();
                }

                if (recentFiles[0].Text != "")
                    loadFile(recentFiles[0].ToolTipText.ToString());
                richTextBox[0].Focus();
            }

            
            English();

            if (filenameTextFragments == "<Default>")
            {
                defaultTextFragments();
            }
            else
            {
                loadTextFragments();
            }

            if (filenaamEmoticons == "<Default>")
            {
                defaultImagePanel();
            }
            else
            {
                loadImagePanel();
            }
            UpdateStatusBarPosition();
            UpdateSelectionChange();
        }

        private void defaultImagePanel()
        {
             images = new ImageInfo[maxImage];
            for (int teller = 0; teller < maxImage; teller++)
                images[teller] = new ImageInfo();
            // Load Emoticon Images

            try
            {
                MemoryStream stream = new MemoryStream(Resources._default);
                BinaryFormatter bformatter = new BinaryFormatter();
                imageCounter = (int)bformatter.Deserialize(stream);
                for (int teller = 0; teller < imageCounter; teller++)
                {
                    string dummy = bformatter.Deserialize(stream).ToString();
                    dummy = bformatter.Deserialize(stream).ToString();
                    images[teller].img = (Image)bformatter.Deserialize(stream);
                }
                stream.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            createImagePanel(images, imageCounter);
       }

        private void loadImagePanel()
        {
             images = new ImageInfo[maxImage];
            for (int teller = 0; teller < maxImage; teller++)
                images[teller] = new ImageInfo();
            // Load Emoticon Images
            try
            {
                Stream stream = File.Open(documentDir + "\\" + filenaamEmoticons, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                imageCounter = (int)bformatter.Deserialize(stream);
                //                       emoticons = new Image[imageCounter];
                for (int teller = 0; teller < imageCounter; teller++)
                {
                    string dummyName = bformatter.Deserialize(stream).ToString();
                    string dummyNumber = bformatter.Deserialize(stream).ToString();
                    images[teller].img = (Image)bformatter.Deserialize(stream);
                }
                stream.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            string txt = Path.GetFileName(deserializeFileDialog.FileName);
            Text = "EmotioconsCollector - " + txt; ;

            // Create Emoticon Panel
            standaard = false;
            createImagePanel(images, imageCounter);
        }


        private void defaultTextFragments()
        {
            // 
            // toolStripMenuDatumLang
            // 
            toolStripMenuDatumLang = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuDatumLang.Name = "toolStripMenuDatumLang";
            toolStripMenuDatumLang.Text = "Datum lang";
            toolStripMenuDatumLang.MouseHover += new System.EventHandler(this.cmenu_Teksten_MouseHover);
            toolStripMenuDatumLang.Click += new System.EventHandler(this.contextMenu_Text_Click);
            // 
            // toolStripMenuDatumKort
            // 
            toolStripMenuTijdKort = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuDatumKort = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuDatumKort.Name = "toolStripMenuDatumKort";
            toolStripMenuDatumKort.Text = "Datum Kort";
            toolStripMenuDatumKort.MouseHover += new System.EventHandler(this.cmenu_Teksten_MouseHover);
            toolStripMenuDatumKort.Click += new System.EventHandler(this.contextMenu_Text_Click);
            // 
            // toolStripMenuTijdLang
            // 
            toolStripMenuTijdLang = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuTijdLang.Name = "toolStripMenuTijdLang";
            toolStripMenuTijdLang.Text = "Tijd lang";
            toolStripMenuTijdLang.MouseHover += new System.EventHandler(this.cmenu_Teksten_MouseHover);
            toolStripMenuTijdLang.Click += new System.EventHandler(this.contextMenu_Text_Click);
            // 
            // toolStripMenuTijdKort
            // 
            toolStripMenuTijdKort.Name = "toolStripMenuTijdKort";
            toolStripMenuTijdKort.Text = "Tijd Kort";
            toolStripMenuTijdKort.MouseHover += new System.EventHandler(this.cmenu_Teksten_MouseHover);
            toolStripMenuTijdKort.Click += new System.EventHandler(this.contextMenu_Text_Click);

            // 
            // contextMenu_Text
            // 
            contextMenu_Text.Items.Clear();
            contextMenu_Text.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuDatumLang,
            toolStripMenuDatumKort,
            toolStripMenuTijdLang,
            toolStripMenuTijdKort});
            //
            // Date and Time
            //
            DateTime time = DateTime.Now;
            toolStripMenuDatumKort.Tag = time.ToShortDateString() + "\n";
            toolStripMenuDatumLang.Tag = time.ToLongDateString() + "\n";
            toolStripMenuTijdKort.Tag = time.ToShortTimeString() + "\n";
            toolStripMenuTijdLang.Tag = time.ToLongTimeString() + "\n";
            toolStripMenuDatumKort.ToolTipText = time.ToShortDateString() + "\n";
            toolStripMenuDatumLang.ToolTipText = time.ToLongDateString() + "\n";
            toolStripMenuTijdKort.ToolTipText = time.ToShortTimeString() + "\n";
            toolStripMenuTijdLang.ToolTipText = time.ToLongTimeString() + "\n";
            standaard = true;
        }

        private void loadTextFragments()
        {
            contextMenu_Text.Items.Clear();

            Stream stream = File.Open(documentDir + "\\" + filenameTextFragments, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            int maxMenu = (int)bformatter.Deserialize(stream);
            ToolStripMenuItem[] item = new ToolStripMenuItem[maxMenu];

            for (int teller = 0; teller < maxMenu; teller++)
            {
                item[teller] = new ToolStripMenuItem();
                item[teller].Click += new System.EventHandler(this.contextMenu_Text_Click);
                item[teller].MouseHover += new System.EventHandler(this.cmenu_Teksten_MouseHover);
                bool dummy = (bool)bformatter.Deserialize(stream);
                int  dummie = (int)bformatter.Deserialize(stream);
                dummie = (int)bformatter.Deserialize(stream);
                dummie = (int)bformatter.Deserialize(stream);
                dummie= (int)bformatter.Deserialize(stream);
                item[teller].Text = bformatter.Deserialize(stream).ToString();
                item[teller].Tag = bformatter.Deserialize(stream).ToString();
                item[teller].Tag = bformatter.Deserialize(stream).ToString();
                contextMenu_Text.Items.Add(item[teller]);
                standaard = false;

            }
            stream.Close();
        }

        private void TabText1_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveAll();
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegKey, true);

            if (regkey == null)
                regkey = Registry.CurrentUser.CreateSubKey(strRegKey);

            try
            {
                regkey.SetValue("documentDir", documentDir);
            }
            catch
            {
                Trace.WriteLine("SaveSettingsToRegistry failed");
            }
            SaveRegistryInfo(regkey);
            regkey.Close();

            RegistryKey key = Registry.CurrentUser.CreateSubKey(strRegKey + "Recent File List\\");

            if (key != null)
            {
                RegistryKey subkey = Registry.CurrentUser.CreateSubKey(strRegKey);
                subkey.DeleteSubKey("Recent File List");
                subkey.Close();
            }
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(strRegKey + "Recent File List\\");
            try
            {
                for (int n = 0; n < maxRecent; n++)
                {
                    if (recentFiles[n] != null)
                    {
                        string sKey = "file" + n.ToString();
                        key.SetValue(sKey, recentFiles[n].ToolTipText.ToString());
                    }
                    else
                        return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Saving Recent Files to Registry failed: ");
            }
            timer.Stop();
        }

        private void TabText1_TimerTick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            sbpDate.Text = dt.ToShortDateString();
            sbpTime.Text = dt.ToShortTimeString();

            if (board.CapsLock)
                sbpCapsKey.Text = "Caps on";
            else
                sbpCapsKey.Text = "Caps off";
            if (board.NumLock)
                sbpNumberKey.Text = "Num on";
            else
                sbpNumberKey.Text = "Num off";
            if (board.ScrollLock)
                sbpScrollLock.Text = "Scroll on";
            else
                sbpScrollLock.Text = "Scroll off";
            int index = ZoekTab();
            if (richTextBox[index].GetKeyStateInsert() == 1)
                sbpInsert.Text = "Insert";
            else
                sbpInsert.Text = "Overwrite";
        }

        private void TabText1_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                rectNormal = DesktopBounds;

        }

        private void TabText1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                rectNormal = DesktopBounds;

        }

        void TabText1_DragEnter(object sender, DragEventArgs e)
        {
            RichTextBox box = (RichTextBox)sender;
            DragEventArgs args = (DragEventArgs)e;
            Trace.WriteLine("Drag Enter");
            if (args.Data.GetDataPresent(DataFormats.FileDrop) ||
                args.Data.GetDataPresent(DataFormats.StringFormat) ||
                args.Data.GetDataPresent(typeof(Metafile)) ||
                args.Data.GetDataPresent(typeof(Metafile)))
            {
                if ((args.AllowedEffect & DragDropEffects.Move) != 0)
                    args.Effect = DragDropEffects.Move;
                if (((args.AllowedEffect & DragDropEffects.Copy) != 0) && ((args.KeyState & 0x08) != 0))
                {
                    args.Effect = DragDropEffects.Copy;
                }

            }
        }

        void TabText1_DragDrop(object sender, DragEventArgs e)
        {
            RichTextBox box = (RichTextBox)sender;
            DragEventArgs args = (DragEventArgs)e;
            Trace.WriteLine("Drag Drop");
            int index = ZoekTab();

            if (args.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])args.Data.GetData(DataFormats.FileDrop);
                try
                {
                    image = Image.FromFile(file[0]);
                    richTextBox[index].InsertImage(image);
                }
                catch
                {
                    try
                    {
                        string ext = Path.GetExtension(file[0]);
                        string tekst = File.ReadAllText(file[0]);
                        if (ext == ".rtf")
                        {
                            richTextBox[index].InsertRtf(tekst);
                        }
                        else
                            if (ext == ".txt")
                            {
                                richTextBox[index].InsertTextAsRtf(tekst);
                            }
                            else
                            {
                                MessageBox.Show(Resources.alleenRtfTxt, "TabText1");
                                return;
                            }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "TabText1");
                        return;
                    }
                }
                return;
            }
            if (args.Data.GetDataPresent(typeof(Metafile)))
            {
                image = (Image)args.Data.GetData(typeof(Metafile));
                richTextBox[index].InsertImage(image);
                return;
            }
            if (args.Data.GetDataPresent(typeof(Bitmap)))
            {
                image = (Image)args.Data.GetData(typeof(Bitmap));
                richTextBox[index].InsertImage(image);
                return;
            }
            if (args.Data.GetDataPresent(DataFormats.StringFormat))
            {
                richTextBox[index].InsertTextAsRtf((string)args.Data.GetData(DataFormats.StringFormat));
                return;
            }
        }

        void TabText1_MouseLeave(object sender, EventArgs e)
        {
            sbpMenu.Text = "Gereed";
        }

        void TabText1_MouseHover(object sender, EventArgs e)
        {
            sbpMenu.Text = "Dubbelklik om tekst te wijzigen van tab";
        }

        #endregion

        #region Context Help

        private void toolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            sbpMenu.Text = (string)menu.Tag;
        }

        private void toolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            sbpMenu.Text = "Gereed";
        }

        private void toolBarButton_MouseHover(object sender, EventArgs e)
        {
            ToolStripButton menu = (ToolStripButton)sender;
            sbpMenu.Text = (string)menu.Tag;
        }

        private void toolBarButton_MouseLeave(object sender, EventArgs e)
        {
            sbpMenu.Text = "Gereed";
        }

        private void toolBarComboBox_MouseHover(object sender, EventArgs e)
        {
            ToolStripComboBox menu = (ToolStripComboBox)sender;
            sbpMenu.Text = menu.Tag.ToString();
        }

        private void toolBarComboBox_MouseLeave(object sender, EventArgs e)
        {
            sbpMenu.Text = "Gereed";
        }

        private void helpHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Remove(this.splitContainer);
            Controls.Remove(this.comboStrip);
            Controls.Remove(this.buttonStrip);
            Controls.Remove(this.menuStrip);
            Controls.Remove(this.statusStrip);
            Controls.Add(helpControl);
            Controls.Add(helpMenu);
        }

        public void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Add(splitContainer);
            Controls.Add(comboStrip);
            Controls.Add(buttonStrip);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            Controls.Remove(helpControl);
            Controls.Remove(helpMenu);

        }
        
        #endregion

        #region recent fileList

        private void recentfilelistToolstripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (maxRecent == 0)
                item.Enabled = false;
            else
            {
                item.Enabled = true;
                item.DropDownItems.Clear();
                for (int teller = 0; teller < maxRecent; teller++)
                {
                    ToolStripMenuItem dropItem = recentFiles[teller];
                    dropItem.Click += new EventHandler(dropItem_Click);
                    if (dropItem != null)
                        item.DropDownItems.Add(dropItem);
                }
            }

        }

        void dropItem_Click(object sender, EventArgs e)
        {
            // cast sender object to MenuItem
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                loadFile(item.ToolTipText.ToString());
            }

        }

        void addRecentFile(string longFileName)
        {
            for (int teller = 0; teller < maxRecent; teller++)
                if (recentFiles[teller].ToolTipText == longFileName)
                    return;
            if (maxRecent < 10)
            {
                for (int index = maxRecent++; index != 0; index--)
                {
                    recentFiles[index].ToolTipText = recentFiles[index - 1].ToolTipText.ToString();
                    recentFiles[index].Text = recentFiles[index - 1].Text.ToString();
                }
                recentFiles[0].ToolTipText = longFileName;
                recentFiles[0].Text = GetShortDisplayName(longFileName, 40);
                return;
            }
            for (int index = maxRecent - 1; index != 0; index--)
            {
                recentFiles[index].ToolTipText = recentFiles[index - 1].ToolTipText.ToString();
                recentFiles[index].Text = recentFiles[index - 1].Text.ToString();
            }
            recentFiles[0].ToolTipText = longFileName;
            recentFiles[0].Text = GetShortDisplayName(longFileName, 40);

        }

        void removeRecentFile(string longFileName)
        {
            for (int teller = 0; teller < maxRecent; teller++)
                if (recentFiles[teller].ToolTipText == longFileName)
                {
                    for (int index = teller; index != maxRecent - 1; index++)
                    {
                        recentFiles[index].ToolTipText = recentFiles[index + 1].ToolTipText.ToString();
                        recentFiles[index].Text = recentFiles[index + 1].Text.ToString();
                    }
                    maxRecent--;
                    return;
                }
        }

        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern bool PathCompactPathEx(StringBuilder pszOut, string pszPath, int cchMax, int reserved);

        private string GetShortDisplayName(string longName, int maxLen)
        {
            StringBuilder pszOut = new StringBuilder(maxLen + maxLen + 2);  // for safety

            if (PathCompactPathEx(pszOut, longName, maxLen, 0))
            {
                return pszOut.ToString();
            }
            else
            {
                return longName;
            }
        }

        #endregion

        private void TabText1_Activated(object sender, EventArgs e)
        {
           
        }

        private void languagetoolStripComboBox_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


    }

    public class ImageInfo
    {
        public string fileName;
        public int imageNumber;
        public Image img;

        public ImageInfo()
        {
        }
    }
}


    


