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
using TabHeaderDemo;

namespace CustomControls
{
    [Author("Franco, Gustavo")]
    public partial class MethodOpenFileDialog : OpenFileDialogEx
    {
        #region Constructors
        public MethodOpenFileDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        public override void OnFileNameChanged(string filePath)
        {
            if (filePath.ToLower().EndsWith(".dat"))
            {
                listBox1.Items.Clear();

                try
                {
                    FileInfo fi = new FileInfo(filePath);

                    if (CComLibrary.GlobeVal.filesave == null)
                    {
                        CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                    }
                    CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(filePath);

                    listBox1.Items.Clear();
                    listBox1.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                    listBox1.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                    listBox1.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);
                    if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                    {
                        listBox1.Items.Add("控制过程:" + "一般测控");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                    {
                        listBox1.Items.Add("控制过程:" + "中级测控");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                    {
                        listBox1.Items.Add("控制过程:" + "简单控制");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess ==3)
                    {
                        listBox1.Items.Add("控制过程:" + "高级测控");
                    }
                    CComLibrary.GlobeVal.filesave.InitExplainList();

                   

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                        {
                            string s = "   " + "步骤" + (i + 1).ToString()+" " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(Convert.ToInt32(GlobeVal.mysys.machinekind));
                            listBox1.Items.Add(s);
                       }
                   
                    listBox1.Items.Add("结果表格1：");
                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                    {
                        string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                        listBox1.Items.Add(s);
                    }
                    lblSizeValue.Text   = (fi.Length / 1024).ToString() + "KB";
                    
                }
                catch(Exception){}
            }
            else if (filePath.ToLower().EndsWith(".spe"))
            {
                listBox1.Items.Clear();

                try
                {
                    FileInfo fi = new FileInfo(filePath);

                    if (CComLibrary.GlobeVal.filesave == null)
                    {
                        CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                    }
                    CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(filePath);

                    listBox1.Items.Clear();
                    listBox1.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                    listBox1.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                    listBox1.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);
                    if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                    {
                        listBox1.Items.Add("控制过程:" + "一般测控");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                    {
                        listBox1.Items.Add("控制过程:" + "中级测控");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                    {
                        listBox1.Items.Add("控制过程:" + "简单控制");
                    }
                    else if (CComLibrary.GlobeVal.filesave.mcontrolprocess ==3)
                    {
                        listBox1.Items.Add("控制过程:" + "高级测控");
                    }

                    CComLibrary.GlobeVal.filesave.InitExplainList();

                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                    {
                        string s = "   " + "步骤" + (i + 1).ToString()+" " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(Convert.ToInt32( GlobeVal.mysys.machinekind));
                        listBox1.Items.Add(s);
                    }
                    listBox1.Items.Add("结果表格1：");
                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                    {
                        string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                        listBox1.Items.Add(s);
                    }
                    lblSizeValue.Text = (fi.Length / 1024).ToString() + "KB";

                }
                catch (Exception) { }
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        public override void OnFolderNameChanged(string folderName)
        {
            
            lblSizeValue.Text   = string.Empty;
           
        }

        public override void OnClosingDialog()
        {
            listBox1.Items.Clear();
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

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int t;
            Color fcolor;

            if (e.Index < 0)
            {
                return;
            }
            if (listBox1.SelectedIndex == e.Index)
            {
                fcolor = Color.Black;
            }
            else
            {
                fcolor = Color.Black;
            }

            Pen p = new Pen(Color.Gray, 2);

            e.Graphics.DrawLine(p, e.Bounds.Left

             ,
             e.Bounds.Bottom,
             e.Bounds.Right,
             e.Bounds.Bottom);
            p.Dispose();

            //e.Graphics.DrawImage(this.imageList1.Images[0], e.Bounds.Left, e.Bounds.Top);

            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);

            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width)));
            




            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, listBox1.Width, e.Font.Height * t);



            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(fcolor), rf);
            sf.Dispose();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int t;



            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);


            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width)));

            t = t + 1;
            if (t == 0)
            {
                t = 1;
            }
            e.ItemHeight = t * listBox1.Font.Height + 5;


            sf.Dispose();
        }
    }
}