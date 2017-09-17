using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using MicrosoftMSDN;

namespace Compenkie
{

    /// <summary>
    /// An extension for RichTextBox suitable for printing.
    /// </summary>
    public class RichTextBoxExtend : RichTextBoxExt
    {
        public int printMarginTop;
        public int printMarginLeft;
        public int printMarginRight;
        public int printMarginBottom;
        public bool printLandScape;


        #region Find
        public void FindAndReplace(string FindText, string ReplaceText)
        {
            this.Find(FindText);
            if (this.SelectionLength == 0)
                this.SelectedText = ReplaceText;
            else
                MessageBox.Show("De volgende tekst is niet gevonden:   " + FindText);
        }

        public int FindAndReplace(string FindText, string ReplaceText, bool ReplaceAll, bool MatchCase, bool WholeWord)
        {
            if (ReplaceAll == false)
            {
                if (MatchCase == true)
                {
                    if (WholeWord == true)
                    {
                        Find(FindText, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                    }
                    else
                    {
                        Find(FindText, RichTextBoxFinds.MatchCase);
                    }
                }
                else
                {
                    if (WholeWord == true)
                    {
                        Find(FindText, RichTextBoxFinds.WholeWord);
                    }
                    else
                    {
                        Find(FindText);
                    }
                }
                if (SelectionLength != 0)
                    SelectedText = ReplaceText;
                else
                    MessageBox.Show("De volgende tekst is niet gevonden:   " + FindText);
                return 1;
            }
            else
            {
                for (int i = 0; i != TextLength; i++)
                {

                    if (MatchCase == true)
                    {
                        if (WholeWord == true)
                        {
                            Find(FindText, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                        }
                        else
                        {
                            Find(FindText, RichTextBoxFinds.MatchCase);
                        }
                    }
                    else
                    {
                        if (WholeWord == true)
                        {
                            Find(FindText, RichTextBoxFinds.WholeWord);
                        }
                        else
                        {
                            Find(FindText);
                        }
                    }

                    if (SelectionLength != 0)
                        SelectedText = ReplaceText;
                    else
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
        public int FindMyText(string searchText, int searchStart, int searchEnd, bool MatchCase, bool WholeWord)
        {
            // Initialize the return value to false by default.
            int returnValue = -1;

            // Ensure that a search string and a valid starting point are specified.
            if (searchText.Length > 0 && searchStart >= 0)
            {
                // Ensure that a valid ending value is provided.
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    int indexToText;
                    if (MatchCase == true)
                    {
                        if (WholeWord == true)
                        {
                            indexToText = Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                        }
                        else
                        {
                            indexToText = Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase);
                        }
                    }
                    else
                    {
                        if (WholeWord == true)
                        {
                            indexToText = Find(searchText, searchStart, searchEnd, RichTextBoxFinds.WholeWord);
                        }
                        else
                        {
                            indexToText = Find(searchText, searchStart, searchEnd, RichTextBoxFinds.None);
                        }
                    }
                    // Determine whether the text was found in richTextBox1.
                    if (indexToText >= 0)
                    {
                        // Return the index to the specified search text.
                        returnValue = indexToText;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region Table
        /// <summary>
        /// Voegt een tabel toe
        /// 
        /// </summary>
        /// <remarks>
        /// NOTE: De tabel wordt ingevoegd op de plaats van de invoeg-cursor,
        /// and if any text is selected, that text is replaced.
        /// </remarks>
        /// <param name="Column">Het aantal kolommen</param>
        /// <param name="row">Het aantal rijen</param>
        /// <param name="pwidth">Breedte totale tabel</param>


        public void InsertTable(int Column, int row, int pwidth)
        {
            int width = HundredthInchToTwips(pwidth);

            string border = "\\brdrs\\brdrw15";
            StringBuilder tablestring = new StringBuilder();

            tablestring.Append("\\trowd\\trgraph70\\trleft170");
            tablestring.Append("\\trbrdrt" + border);
            tablestring.Append("\\trbrdrl" + border);
            tablestring.Append("\\trbrdrb" + border);
            tablestring.Append("\\trbrdrr" + border);

            for (int kolom = 0; kolom < Column; kolom++)
            {
                tablestring.Append("\\clbrdrt" + border);
                tablestring.Append("\\clbrdrl" + border);
                tablestring.Append("\\clbrdrb" + border);
                tablestring.Append("\\clbrdrr" + border);
                int breedte = (width / Column) * (kolom + 1);
                tablestring.Append("\\cellx");
                tablestring.Append(breedte.ToString());
            }

            tablestring.Append("\\pard");

            for (int rij = 0; rij < row; rij++)
            {
                tablestring.Append("\\intbl");
                for (int kolom = 0; kolom < row; kolom++)
                {
                    tablestring.Append("\\cell");
                }
                tablestring.Append("\\row");
            }
            tablestring.Append("\\pard\\par}");

            InsertTextAsRtf(tablestring.ToString());
        }

        #endregion

        [DllImportAttribute("user32.dll")]
        private static extern uint GetKeyState(int keystate);

        public uint GetKeyStateInsert()
        {
            return GetKeyState(45); // Keynumber InsertKey

        }
    }
}


