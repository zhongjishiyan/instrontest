//  Copyright (c) 2006, Gustavo Franco
//  Email:  gustavo_franco@hotmail.com
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer. 
//  Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution. 

//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;

using CustomControls.Controls;

namespace CustomControls
{
    [Author("Franco, Gustavo")]
    public partial class TxtOpenFileDialog : OpenFileDialogEx
    {
        public int xchsel = 0;
        public int ychsel = 0;

        public Boolean firstread = false;
      
        public Boolean good = false;

        #region Constructors
        public TxtOpenFileDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        public override void OnFileNameChanged(string filePath)
        {
            string firstline = "";
            if (filePath.ToLower().EndsWith(".txt"))
            {
                richTextBox1.Clear();

                try
                {
                    FileInfo fi = new FileInfo(filePath);
                    int i = 0;
                    bool r = true;
                    StreamReader m_streamReader = new StreamReader(filePath, System.Text.Encoding.Default);
                    try
                    {
                        //使用StreamReader类来读取文件
                        m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                        // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容
                        this.richTextBox1.Text = "";
                        string strLine = m_streamReader.ReadLine();
                        firstline = strLine;
                        

                        while (r==true)
                        {
                            
                            this.richTextBox1.Text =this.richTextBox1.Text+ strLine + "\r\n";
                            strLine = m_streamReader.ReadLine();

                            if (strLine == null)
                            {
                                r = false;

                            }

                            i = i + 1;
                            if(i>30)
                            {
                                r=false;
                            }
                        }
                        //关闭此StreamReader对象
                        m_streamReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    lblSizeValue.Text   = (fi.Length / 1024).ToString() + "KB";
                    //lblColorsValue.Text = "";


                    lblFormatValue.Text = "";


                 
                    int j = 0;
                   


                    char[] sp;
                    char[] sp1;
                    string[] ww;

                   

                    sp = new char[2];
                    sp1 = new char[2];

                    sp[0] = Convert.ToChar(" ");

                    ww = firstline.Split(sp);

                    cbox.Items.Clear();
                    cboy.Items.Clear();

                    for (j = 0; j < ww.Length-1; j++)
                    {


                        cbox.Items.Add(ww[j]);
                        cboy.Items.Add(ww[j]);

                        


                    }

                   


                    Boolean mb = false;

                    good = true;
                    for (j = 0; j < ww.Length - 1; j++)
                    {

                        mb = false; 
                        for (int k=0;k<ClsStaticStation.m_Global.mycls.allsignals.Count;k++)
                        {
                            if (ww[j] ==ClsStaticStation.m_Global.mycls.allsignals[k].cName)
                            {
                                mb = true;
                            }
                        }

                        if(mb==false)
                        {
                            lblFormatValue.Text = "数据格式不兼容";
                            good = false;
                            break;
                        }

                    }

                    if (good == true)
                    {
                        if (firstread == true)
                        {
                            cbox.SelectedIndex = xchsel;
                            cboy.SelectedIndex = ychsel;

                        }
                    }
                    else
                    {
                        cbox.SelectedIndex = 0;
                        cboy.SelectedIndex = 0;
                    }



                }
                catch (Exception){}
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        public override void OnFolderNameChanged(string folderName)
        {
            richTextBox1.Clear();
            lblSizeValue.Text   = string.Empty;
          
            lblFormatValue.Text = string.Empty;
        }

        public override void OnClosingDialog()
        {
            richTextBox1.Clear();
        }
        #endregion

        #region Private Methods
        private string GetColorsCountFromImage(Image image)
        {
            switch(image.PixelFormat)
            {
                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                    return "16 bits (65536 colors)";
                case PixelFormat.Format1bppIndexed:
                    return "1 bit (Black & White)";
                case PixelFormat.Format24bppRgb:
                    return "24 bits (True Colors)";
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return "32 bits (Alpha Channel)";
                case PixelFormat.Format4bppIndexed:
                    return "4 bits (16 colors)";
                case PixelFormat.Format8bppIndexed:
                    return "8 bits (256 colors)";
            }
            return string.Empty;
        }

        private string GetFormatFromImage(Image image)
        {
            if (image.RawFormat.Equals(ImageFormat.Bmp))
                return "BMP";
            else if (image.RawFormat.Equals(ImageFormat.Gif))
                return "GIF";
            else if (image.RawFormat.Equals(ImageFormat.Jpeg))
                return "JPG";
            else if (image.RawFormat.Equals(ImageFormat.Png))
                return "PNG";
            else if (image.RawFormat.Equals(ImageFormat.Tiff))
                return "TIFF";
            return string.Empty;
        }
        #endregion

        private void cbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.xchsel = cbox.SelectedIndex;

        }

        private void cboy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ychsel = cboy.SelectedIndex;
        }

        private void lblSizeValue_Click(object sender, EventArgs e)
        {

        }
    }
}