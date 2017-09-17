using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace AppleLabApplication
{
    public partial class EmotioconsCollector : Form
    {
        int maxImage = 100;
        public ImageInfo[] images;
        public int imageCounter = 0;
        public string documentDir;
        private string programName;

        public EmotioconsCollector()
        {
            InitializeComponent();
            Location = ActiveForm.Location + SystemInformation.CaptionButtonSize + SystemInformation.FrameBorderSize;
            images = new ImageInfo[maxImage];
            for (int teller = 0; teller < maxImage; teller++)
                images[teller] = new ImageInfo();
            Text = "EmotioconsCollector - Untitled";
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
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
            String[] fileNames = openImageDialog.FileNames;
            //           imageCounter = 0;
            //           listBoxPictures.Items.Clear();
            foreach (String name in fileNames)
            {
                String fileName = Path.GetFileNameWithoutExtension(name);
                try
                {
                    images[imageCounter].img = new Bitmap(name);
                    images[imageCounter].fileName = fileName;
                    images[imageCounter].imageNumber = imageCounter;
                }
                catch
                {
                    MessageBox.Show("Afbeelding kon niet geladen worden");
                    return;
                }
                listBoxPictures.Items.Add(fileName);
                listBoxPictures.SelectedIndex = imageCounter;
                pictureBox.Image = images[imageCounter].img;
                imageCounter++;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serializeFileDialog.InitialDirectory = documentDir;
            serializeFileDialog.FileName = programName;
            serializeFileDialog.Title = "Serialiseer naar bestand";
            serializeFileDialog.Filter = "Serialize Image (*.sri)|*.sri";
            serializeFileDialog.ShowDialog();
        }

        private void serializeFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Stream stream = File.Open(serializeFileDialog.FileName, FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, imageCounter);
                for (int teller = 0; teller < imageCounter; teller++)
                {
                    bformatter.Serialize(stream, images[teller].fileName.ToString());
                    bformatter.Serialize(stream, images[teller].imageNumber.ToString());
                    bformatter.Serialize(stream, images[teller].img.GetThumbnailImage(32, 32, null, (IntPtr)0));
                }
                stream.Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            string txt = Path.GetFileName(serializeFileDialog.FileName);
            Text = "EmotioconsCollector - " + txt; ;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deserializeFileDialog.InitialDirectory = documentDir;
            deserializeFileDialog.Filter = "Serialize bestand (*.sri)|*.sri";
            deserializeFileDialog.ShowDialog();
        }

        private void deserializeFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            listBoxPictures.Items.Clear();
            try
            {
                Stream stream = File.Open(deserializeFileDialog.FileName, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                imageCounter = (int)bformatter.Deserialize(stream);
                for (int teller = 0; teller < imageCounter; teller++)
                {
                    images[teller].fileName = bformatter.Deserialize(stream).ToString();
                    listBoxPictures.Items.Add(images[teller].fileName);
                    images[teller].imageNumber = int.Parse(bformatter.Deserialize(stream).ToString());
                    images[teller].img = (Image)bformatter.Deserialize(stream);
                }
                stream.Close();
                pictureBox.Image = images[0].img;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            programName = Path.GetFileName(deserializeFileDialog.FileName);
            Text = "EmotioconsCollector - " + programName;
        }

        private void listBoxPictures_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox box = (ListBox)sender;
            KeyEventArgs args = (KeyEventArgs)e;
            if (args.KeyCode == Keys.Delete)
            {
                RemoveItem(box);
            }
        }

        /// <summary>
        /// Remove one item from the listbox
        /// 
        /// </summary>
        /// <remarks>
        /// NOTE: The item removed from the listbox,
        /// and the picture also removed.
        /// </remarks>
        /// <param name="box">Listbox who send message</param>
        private void RemoveItem(ListBox box)
        {

            if (box.SelectedIndex != -1)
            {
                for (int teller = box.SelectedIndex; teller < imageCounter - 1; teller++)
                {
                    images[teller].fileName = images[teller + 1].fileName;
                    images[teller].imageNumber = images[teller + 1].imageNumber;
                    images[teller].img = images[teller + 1].img;
                }
                imageCounter--;
                int select = box.SelectedIndex;
                box.Items.RemoveAt(box.SelectedIndex);
                if (select == imageCounter)
                    select--;
                if (select != -1)
                {
                    box.SelectedIndex = select;
                    pictureBox.Image = images[box.SelectedIndex].img;
                }
                else
                    pictureBox.Image = null;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxPictures.Items.Clear();
            pictureBox.Image = null;
            imageCounter = 0;
            Text = "EmotioconsCollector - Untitled";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItem(listBoxPictures);
        }

        private void listBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            if (box.SelectedIndex != -1)
            {
                if (images[box.SelectedIndex].img.Height != 0)
                    heightLabel.Text = images[box.SelectedIndex].img.Height.ToString();
                if (images[box.SelectedIndex].img.Width != 0)
                    widthLabel.Text = images[box.SelectedIndex].img.Width.ToString();
                pictureBox.Image = images[box.SelectedIndex].img;
                pictureSmallBox.Image = images[box.SelectedIndex].img.GetThumbnailImage(32, 32, null, (IntPtr)0);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = documentDir;
            saveFileDialog.FileName = images[listBoxPictures.SelectedIndex].fileName;
            saveFileDialog.Filter = "BitMap Image (*.bmp)|*.bmp";
            saveFileDialog.ShowDialog();

        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                images[listBoxPictures.SelectedIndex].img.Save(saveFileDialog.FileName, ImageFormat.Bmp);
            }
            catch (ExecutionEngineException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        Form showForm;
        private void showImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

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
                panel.TabIndex = 0;
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
                showForm.Location = new Point(showForm.Location.X + item.Bounds.Left, showForm.Location.Y + item.Bounds.Top);
                showForm.Text = "";
                showForm.MaximizeBox = false;
                showForm.MinimizeBox = false;
                showForm.ShowIcon = false;
                showForm.Name = "";
                showForm.ShowInTaskbar = false;
                panel.ResumeLayout(false);
                for (int counter = 0; counter < imageCounter; counter++)
                {

                    ((System.ComponentModel.ISupportInitialize)(box[counter])).EndInit();
                }
                showForm.ResumeLayout(false);

                showForm.Show();
            }
        }

        void box_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            showForm.Close();

            // here your own code for processing the clicked picture
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

        int numberColums;
        int numberRows;

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
    }
}
