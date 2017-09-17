using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TabHeaderDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private BorisBord.Helper helper;
		private BorisBord.WinForms.TabButtonExtender tabButtonExtender1;
		private BorisBord.WinForms.PaintHelperRect  paintHelperRect; 
		private BorisBord.WinForms.PaintHelperRect2  paintHelperRect2; 
		private BorisBord.WinForms.PaintHelperRhomb paintHelperRhomd; 
		private BorisBord.WinForms.PaintHelperEllipse paintHelperEllipse; 
		private BorisBord.WinForms.PaintHelperRect2 paintHelper;			
		private BorisBord.WinForms.TabHeader tabHeader1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel_streak;
		private BorisBord.WinForms.TabPage tabPage_TabControl;
		private BorisBord.WinForms.TabHeader tabHeader6;
		private BorisBord.WinForms.TabButton tabButton20;
		private BorisBord.WinForms.TabButton tabButton21;
		private BorisBord.WinForms.TabHeader tabHeader7;
		private BorisBord.WinForms.TabButton tabButton24;
		private BorisBord.WinForms.TabPage tabPage_DragAndDrop;
		private BorisBord.WinForms.TabHeader tabHeader11;
		private BorisBord.WinForms.TabPage tabPage_Buttons;
		private BorisBord.WinForms.TabPage tabPage_TrackBar;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Panel panel2Right;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private BorisBord.WinForms.TabHeader tabHeader3;
		private BorisBord.WinForms.ImageButton imageButton1;
		private BorisBord.WinForms.ImageButton imageButton2;
		private BorisBord.WinForms.ImageButton imageButton_Left;
		private BorisBord.WinForms.ImageButton imageButton_Right;
		private BorisBord.WinForms.TabButton tabButton16;
		private BorisBord.WinForms.TabButton tabButton17;
		private BorisBord.WinForms.TabButton tabButton18;
		private BorisBord.WinForms.TabButton tabButton19;
		private BorisBord.WinForms.TabPage tabPageEBoris;
		private System.Windows.Forms.LinkLabel linkEboris;
		private BorisBord.WinForms.TabPage tabPage4;
		private System.Windows.Forms.TrackBar trackBar2;
		private BorisBord.WinForms.TabPage tabPage6;
		private System.Windows.Forms.RadioButton radioButton2;
		private BorisBord.WinForms.TabButton tabButtonR7;
		private System.Windows.Forms.TextBox textBox2;
		private BorisBord.WinForms.TabButton tabButtonR6;
		private BorisBord.WinForms.TabPage tabPageR5;
		private System.Windows.Forms.TextBox textBox1;
		private BorisBord.WinForms.TabButton tabButtonR5;
		private BorisBord.WinForms.TabPage tabPageR4;
		private BorisBord.WinForms.TabButton tabButtonR4;
		private BorisBord.WinForms.TabPage tabPageR3;
		private BorisBord.WinForms.TabButton tabButtonR3;
		private BorisBord.WinForms.TabPage tabPageR2;
		private BorisBord.WinForms.TabButton tabButtonR2;
		private BorisBord.WinForms.TabPage tabPageR1;
		private BorisBord.WinForms.TabButton tabButtonR1;
		private System.Windows.Forms.Panel panel1Right;
		private System.Windows.Forms.PictureBox pictureBox1Right;
		private BorisBord.WinForms.TabHeader tabHeader1Right;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panel2Left;
		private BorisBord.WinForms.TabPage tabPageL3;
		private BorisBord.WinForms.TabButton tabButtonL3;
		private BorisBord.WinForms.TabPage tabPageL2;
		private BorisBord.WinForms.TabButton tabButtonL2;
		private BorisBord.WinForms.TabPage tabPageL1;
		private BorisBord.WinForms.TabButton tabButtonL1;
		private BorisBord.WinForms.TabPage tabPageL4;
		private BorisBord.WinForms.TabButton tabButtonL4;
		private System.Windows.Forms.Panel panel1Left;
		private System.Windows.Forms.PictureBox pictureBox1Left;
		private BorisBord.WinForms.TabHeader tabHeader1Left;
		private System.Windows.Forms.Panel panel_Horizontal_ToolBar;
		private BorisBord.WinForms.ImageButton imageButton1_Left;
		private BorisBord.WinForms.ImageButton imageButton1_Right;
		private BorisBord.WinForms.TabPage tabPage_All;
		private BorisBord.WinForms.TabPage tabPage3;
		private BorisBord.WinForms.TabPage tabPage11;
		private BorisBord.WinForms.TabPage tabPage17;
		private BorisBord.WinForms.TabPage tabPage18;
		private BorisBord.WinForms.TabHeader tabHeader12;
		private BorisBord.WinForms.TabButton tabButton66;
		private BorisBord.WinForms.TabButton tabButton67;
		private BorisBord.WinForms.TabHeader tabHeader17;
		private BorisBord.WinForms.TabButton tabButton105;
		private BorisBord.WinForms.TabButton tabButton106;
		private BorisBord.WinForms.TabPage tabPage21;
		private BorisBord.WinForms.TabPage tabPage22;				
		private BorisBord.WinForms.TabHeader tabHeader_Horizontal_ToolBar;
		private System.Windows.Forms.PictureBox pictureBox_Horizontal_ToolBar;
		private System.Windows.Forms.Panel panel_HorizontalToolBar2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel linkLabelXXX;
		private System.Windows.Forms.Button button1;		
		private BorisBord.WinForms.TabButton tabButton2;
		private BorisBord.WinForms.TabButton tabButton3;
		private BorisBord.WinForms.TabButton tabButton4;
		private System.Windows.Forms.Panel panel_DAD_vert_Left;
		private System.Windows.Forms.PictureBox pictureBox_DAD_vert_Left;
		private BorisBord.WinForms.TabHeader tabHeader_DAD_vert_Left;
		private System.Windows.Forms.Panel panel_DAD_vert_Left2;
		private BorisBord.WinForms.TabButton tabButton14;
		private BorisBord.WinForms.TabButton tabButton26;
		private BorisBord.WinForms.TabButton tabButton27;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private BorisBord.WinForms.TabHeader tabHeader_DAD_vert_Right;
		private System.Windows.Forms.PictureBox pictureBox_DAD_vert_Right;
		private System.Windows.Forms.Panel panel_DAD_vert_Right;
		private BorisBord.WinForms.TabHeader tabHeader14;
		private BorisBord.WinForms.TabButton tabButton61;
		private BorisBord.WinForms.TabHeader tabHeader15;
		private BorisBord.WinForms.TabButton tabButton75;
		private System.Windows.Forms.Panel panel_DAD_vert_Right2;
		private BorisBord.WinForms.TabHeader tabHeader16;
		private BorisBord.WinForms.TabButton tabButton82;
		private BorisBord.WinForms.TabHeader tabHeader19;
		private BorisBord.WinForms.TabButton tabButton28;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private BorisBord.WinForms.TabHeader tabHeader8;
		private BorisBord.WinForms.TabButton tabButton9;
		private BorisBord.WinForms.TabHeader tabHeader9;
		private BorisBord.WinForms.TabButton tabButton29;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.PictureBox pictureBox1;
		private BorisBord.WinForms.TabButton tabButton31;
		private BorisBord.WinForms.TabButton tabButton32;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private BorisBord.WinForms.TabHeader tabHeader21;
		private BorisBord.WinForms.TabButton tabButton36;
		private BorisBord.WinForms.TabHeader tabHeader22;
		private BorisBord.WinForms.TabButton tabButton60;
		private System.Windows.Forms.Panel panel_DAD_hor_Up;
		private System.Windows.Forms.PictureBox pictureBox2;
		private BorisBord.WinForms.TabButton tabButton69;
		private BorisBord.WinForms.TabButton tabButton74;
		private BorisBord.WinForms.TabPage tabPage_email;
		private BorisBord.WinForms.TabHeader tabHeader_DAD_horiz_Bottom;
		private BorisBord.WinForms.TabHeader tabHeader_DAD_horiz_Up;
		private BorisBord.WinForms.TabButton tabButton7;
		private BorisBord.WinForms.TabButton tabButton_email;
		private BorisBord.WinForms.TabButton tabButtonEBoris;
		private BorisBord.WinForms.TabButton tabButton1_TabHeader;
		private BorisBord.WinForms.TabButton tabButton_TrackBar;
		private BorisBord.WinForms.TabPage tabPage_TextBox_BorisBord;
		private BorisBord.WinForms.TabHeader tabHeader_test;
		private BorisBord.WinForms.TabButton tabButton54;
		private BorisBord.WinForms.TabButton tabButton1;
		private BorisBord.WinForms.TabButton tabButton47;
		private BorisBord.WinForms.TabButton tabButton49;
		private BorisBord.WinForms.TabHeader tabHeader5;
		private BorisBord.WinForms.TabButton tabButton70;
		private BorisBord.WinForms.TabButton tabButton71;
		private BorisBord.WinForms.TabButton tabButton72;
		private BorisBord.WinForms.TabButton tabButton73;
		private BorisBord.WinForms.TabHeader tabHeader_Buttons_Empty;
		private BorisBord.WinForms.TabButton tabButton53;
		private BorisBord.WinForms.TabButton tabButton48;
		private BorisBord.WinForms.TabButton tabButton51;
		private BorisBord.WinForms.TabButton tabButton52;
		private BorisBord.WinForms.TabHeader tabHeader_Disabled_Buttons;
		private BorisBord.WinForms.TabButton tabButton76;
		private BorisBord.WinForms.TabButton tabButton77;
		private BorisBord.WinForms.TabButton tabButton78;
		private BorisBord.WinForms.TabButton tabButton79;
		private System.Windows.Forms.Panel panel8;
		private BorisBord.WinForms.TabButton tabButton_TabControl;
		private BorisBord.WinForms.TabButton tabButton_Buttons;
		private BorisBord.WinForms.TabButton tabButton_DragAndDrop;
		private BorisBord.WinForms.TabButton tabButton_All;
		private BorisBord.WinForms.TabButton tabButton_oval3;
		private BorisBord.WinForms.TabButton tabButton_oval4;
		private BorisBord.WinForms.TabButton tabButton_oval1;
		private BorisBord.WinForms.TabButton tabButton_oval2;
		private BorisBord.WinForms.TabButton tabButton_oval_;
		private BorisBord.WinForms.TabButton tabButton62;
		private BorisBord.WinForms.TabHeader tabHeader10;
		private BorisBord.WinForms.TabButton tabButton44;
		private BorisBord.WinForms.TabHeader tabHeader13;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.helper = new BorisBord.Helper();
            this.tabHeader1 = new BorisBord.WinForms.TabHeader();
            this.imageButton_Right = new BorisBord.WinForms.ImageButton();
            this.imageButton_Left = new BorisBord.WinForms.ImageButton();
            this.tabButton_TabControl = new BorisBord.WinForms.TabButton();
            this.tabButton_Buttons = new BorisBord.WinForms.TabButton();
            this.tabButton_DragAndDrop = new BorisBord.WinForms.TabButton();
            this.tabButton_All = new BorisBord.WinForms.TabButton();
            this.tabButton_oval3 = new BorisBord.WinForms.TabButton();
            this.tabButton24 = new BorisBord.WinForms.TabButton();
            this.tabButton_oval4 = new BorisBord.WinForms.TabButton();
            this.tabButton_oval1 = new BorisBord.WinForms.TabButton();
            this.tabButton_oval2 = new BorisBord.WinForms.TabButton();
            this.tabPage_Buttons = new BorisBord.WinForms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tabHeader_Disabled_Buttons = new BorisBord.WinForms.TabHeader();
            this.tabButton76 = new BorisBord.WinForms.TabButton();
            this.tabButton77 = new BorisBord.WinForms.TabButton();
            this.tabButton78 = new BorisBord.WinForms.TabButton();
            this.tabButton79 = new BorisBord.WinForms.TabButton();
            this.tabHeader_Buttons_Empty = new BorisBord.WinForms.TabHeader();
            this.tabButton53 = new BorisBord.WinForms.TabButton();
            this.tabButton48 = new BorisBord.WinForms.TabButton();
            this.tabButton51 = new BorisBord.WinForms.TabButton();
            this.tabButton52 = new BorisBord.WinForms.TabButton();
            this.tabHeader5 = new BorisBord.WinForms.TabHeader();
            this.tabButton70 = new BorisBord.WinForms.TabButton();
            this.tabButton71 = new BorisBord.WinForms.TabButton();
            this.tabButton72 = new BorisBord.WinForms.TabButton();
            this.tabButton73 = new BorisBord.WinForms.TabButton();
            this.tabHeader_test = new BorisBord.WinForms.TabHeader();
            this.tabButton54 = new BorisBord.WinForms.TabButton();
            this.tabButton1 = new BorisBord.WinForms.TabButton();
            this.tabButton47 = new BorisBord.WinForms.TabButton();
            this.tabButton49 = new BorisBord.WinForms.TabButton();
            this.tabPage_TrackBar = new BorisBord.WinForms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tabHeader11 = new BorisBord.WinForms.TabHeader();
            this.tabButton_oval_ = new BorisBord.WinForms.TabButton();
            this.tabPage_email = new BorisBord.WinForms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabButton_email = new BorisBord.WinForms.TabButton();
            this.tabHeader1Right = new BorisBord.WinForms.TabHeader();
            this.tabButtonR7 = new BorisBord.WinForms.TabButton();
            this.tabButtonR6 = new BorisBord.WinForms.TabButton();
            this.tabButtonR5 = new BorisBord.WinForms.TabButton();
            this.tabButtonR4 = new BorisBord.WinForms.TabButton();
            this.tabButtonR1 = new BorisBord.WinForms.TabButton();
            this.tabButtonR2 = new BorisBord.WinForms.TabButton();
            this.tabButtonR3 = new BorisBord.WinForms.TabButton();
            this.tabHeader1Left = new BorisBord.WinForms.TabHeader();
            this.tabButtonL1 = new BorisBord.WinForms.TabButton();
            this.tabButtonL2 = new BorisBord.WinForms.TabButton();
            this.tabButtonL3 = new BorisBord.WinForms.TabButton();
            this.tabButtonL4 = new BorisBord.WinForms.TabButton();
            this.tabPage_DragAndDrop = new BorisBord.WinForms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabHeader8 = new BorisBord.WinForms.TabHeader();
            this.tabButton9 = new BorisBord.WinForms.TabButton();
            this.tabButton32 = new BorisBord.WinForms.TabButton();
            this.tabHeader9 = new BorisBord.WinForms.TabHeader();
            this.tabButton29 = new BorisBord.WinForms.TabButton();
            this.tabButton31 = new BorisBord.WinForms.TabButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabHeader_DAD_horiz_Bottom = new BorisBord.WinForms.TabHeader();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabHeader21 = new BorisBord.WinForms.TabHeader();
            this.tabButton36 = new BorisBord.WinForms.TabButton();
            this.tabButton74 = new BorisBord.WinForms.TabButton();
            this.tabHeader22 = new BorisBord.WinForms.TabHeader();
            this.tabButton60 = new BorisBord.WinForms.TabButton();
            this.tabButton69 = new BorisBord.WinForms.TabButton();
            this.panel_DAD_hor_Up = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabHeader_DAD_horiz_Up = new BorisBord.WinForms.TabHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_DAD_vert_Left2 = new System.Windows.Forms.Panel();
            this.tabHeader14 = new BorisBord.WinForms.TabHeader();
            this.tabButton61 = new BorisBord.WinForms.TabButton();
            this.tabButton4 = new BorisBord.WinForms.TabButton();
            this.tabHeader13 = new BorisBord.WinForms.TabHeader();
            this.tabButton44 = new BorisBord.WinForms.TabButton();
            this.tabButton3 = new BorisBord.WinForms.TabButton();
            this.tabHeader10 = new BorisBord.WinForms.TabHeader();
            this.tabButton62 = new BorisBord.WinForms.TabButton();
            this.tabButton2 = new BorisBord.WinForms.TabButton();
            this.panel_DAD_vert_Left = new System.Windows.Forms.Panel();
            this.pictureBox_DAD_vert_Left = new System.Windows.Forms.PictureBox();
            this.tabHeader_DAD_vert_Left = new BorisBord.WinForms.TabHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_DAD_vert_Right2 = new System.Windows.Forms.Panel();
            this.tabHeader19 = new BorisBord.WinForms.TabHeader();
            this.tabButton28 = new BorisBord.WinForms.TabButton();
            this.tabButton27 = new BorisBord.WinForms.TabButton();
            this.tabHeader16 = new BorisBord.WinForms.TabHeader();
            this.tabButton82 = new BorisBord.WinForms.TabButton();
            this.tabButton26 = new BorisBord.WinForms.TabButton();
            this.tabHeader15 = new BorisBord.WinForms.TabHeader();
            this.tabButton75 = new BorisBord.WinForms.TabButton();
            this.tabButton14 = new BorisBord.WinForms.TabButton();
            this.panel_DAD_vert_Right = new System.Windows.Forms.Panel();
            this.pictureBox_DAD_vert_Right = new System.Windows.Forms.PictureBox();
            this.tabHeader_DAD_vert_Right = new BorisBord.WinForms.TabHeader();
            this.tabPageL3 = new BorisBord.WinForms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tabPage_TabControl = new BorisBord.WinForms.TabPage();
            this.tabHeader17 = new BorisBord.WinForms.TabHeader();
            this.tabButton105 = new BorisBord.WinForms.TabButton();
            this.tabButton106 = new BorisBord.WinForms.TabButton();
            this.tabHeader12 = new BorisBord.WinForms.TabHeader();
            this.tabButton66 = new BorisBord.WinForms.TabButton();
            this.tabButton67 = new BorisBord.WinForms.TabButton();
            this.tabHeader6 = new BorisBord.WinForms.TabHeader();
            this.tabButton20 = new BorisBord.WinForms.TabButton();
            this.tabButton21 = new BorisBord.WinForms.TabButton();
            this.tabHeader7 = new BorisBord.WinForms.TabHeader();
            this.tabPage22 = new BorisBord.WinForms.TabPage();
            this.tabPage3 = new BorisBord.WinForms.TabPage();
            this.tabPage11 = new BorisBord.WinForms.TabPage();
            this.tabPage17 = new BorisBord.WinForms.TabPage();
            this.tabPage18 = new BorisBord.WinForms.TabPage();
            this.tabPage21 = new BorisBord.WinForms.TabPage();
            this.tabHeader_Horizontal_ToolBar = new BorisBord.WinForms.TabHeader();
            this.tabButton7 = new BorisBord.WinForms.TabButton();
            this.tabButtonEBoris = new BorisBord.WinForms.TabButton();
            this.tabButton1_TabHeader = new BorisBord.WinForms.TabButton();
            this.tabButton_TrackBar = new BorisBord.WinForms.TabButton();
            this.imageButton1_Left = new BorisBord.WinForms.ImageButton();
            this.imageButton1_Right = new BorisBord.WinForms.ImageButton();
            this.tabPage4 = new BorisBord.WinForms.TabPage();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tabHeader3 = new BorisBord.WinForms.TabHeader();
            this.imageButton1 = new BorisBord.WinForms.ImageButton();
            this.imageButton2 = new BorisBord.WinForms.ImageButton();
            this.tabButton16 = new BorisBord.WinForms.TabButton();
            this.tabButton17 = new BorisBord.WinForms.TabButton();
            this.tabButton18 = new BorisBord.WinForms.TabButton();
            this.tabButton19 = new BorisBord.WinForms.TabButton();
            this.tabPageEBoris = new BorisBord.WinForms.TabPage();
            this.linkEboris = new System.Windows.Forms.LinkLabel();
            this.tabPage6 = new BorisBord.WinForms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tabPage_TextBox_BorisBord = new BorisBord.WinForms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPageR5 = new BorisBord.WinForms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPageR4 = new BorisBord.WinForms.TabPage();
            this.tabPageR3 = new BorisBord.WinForms.TabPage();
            this.tabPageR2 = new BorisBord.WinForms.TabPage();
            this.tabPageR1 = new BorisBord.WinForms.TabPage();
            this.tabPageL2 = new BorisBord.WinForms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPageL1 = new BorisBord.WinForms.TabPage();
            this.linkLabelXXX = new System.Windows.Forms.LinkLabel();
            this.tabPageL4 = new BorisBord.WinForms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabButtonExtender1 = new BorisBord.WinForms.TabButtonExtender();
            this.paintHelperRect = new BorisBord.WinForms.PaintHelperRect(this.components);
            this.paintHelperEllipse = new BorisBord.WinForms.PaintHelperEllipse(this.components);
            this.paintHelperRhomd = new BorisBord.WinForms.PaintHelperRhomb(this.components);
            this.paintHelperRect2 = new BorisBord.WinForms.PaintHelperRect2(this.components);
            this.paintHelper = new BorisBord.WinForms.PaintHelperRect2(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel_streak = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panel2Right = new System.Windows.Forms.Panel();
            this.panel1Right = new System.Windows.Forms.Panel();
            this.pictureBox1Right = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel2Left = new System.Windows.Forms.Panel();
            this.panel1Left = new System.Windows.Forms.Panel();
            this.pictureBox1Left = new System.Windows.Forms.PictureBox();
            this.panel_Horizontal_ToolBar = new System.Windows.Forms.Panel();
            this.panel_HorizontalToolBar2 = new System.Windows.Forms.Panel();
            this.pictureBox_Horizontal_ToolBar = new System.Windows.Forms.PictureBox();
            this.tabPage_All = new BorisBord.WinForms.TabPage();
            this.tabHeader1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_TabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_Buttons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_DragAndDrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_All)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval2)).BeginInit();
            this.tabPage_Buttons.SuspendLayout();
            this.tabHeader_Disabled_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton79)).BeginInit();
            this.tabHeader_Buttons_Empty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton52)).BeginInit();
            this.tabHeader5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton73)).BeginInit();
            this.tabHeader_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton49)).BeginInit();
            this.tabPage_TrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabHeader11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval_)).BeginInit();
            this.tabPage_email.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_email)).BeginInit();
            this.tabHeader1Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR3)).BeginInit();
            this.tabHeader1Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL4)).BeginInit();
            this.tabPage_DragAndDrop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabHeader8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton32)).BeginInit();
            this.tabHeader9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton31)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureBox1.SuspendLayout();
            this.tabHeader_DAD_horiz_Bottom.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabHeader21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton74)).BeginInit();
            this.tabHeader22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton69)).BeginInit();
            this.panel_DAD_hor_Up.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pictureBox2.SuspendLayout();
            this.tabHeader_DAD_horiz_Up.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_DAD_vert_Left2.SuspendLayout();
            this.tabHeader14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton4)).BeginInit();
            this.tabHeader13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton3)).BeginInit();
            this.tabHeader10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton2)).BeginInit();
            this.panel_DAD_vert_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DAD_vert_Left)).BeginInit();
            this.pictureBox_DAD_vert_Left.SuspendLayout();
            this.tabHeader_DAD_vert_Left.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_DAD_vert_Right2.SuspendLayout();
            this.tabHeader19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton27)).BeginInit();
            this.tabHeader16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton26)).BeginInit();
            this.tabHeader15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton14)).BeginInit();
            this.panel_DAD_vert_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DAD_vert_Right)).BeginInit();
            this.pictureBox_DAD_vert_Right.SuspendLayout();
            this.tabHeader_DAD_vert_Right.SuspendLayout();
            this.tabPageL3.SuspendLayout();
            this.tabPage_TabControl.SuspendLayout();
            this.tabHeader17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton106)).BeginInit();
            this.tabHeader12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton67)).BeginInit();
            this.tabHeader6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton21)).BeginInit();
            this.tabHeader7.SuspendLayout();
            this.tabHeader_Horizontal_ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonEBoris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton1_TabHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1_Right)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tabHeader3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton19)).BeginInit();
            this.tabPageEBoris.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage_TextBox_BorisBord.SuspendLayout();
            this.tabPageR5.SuspendLayout();
            this.tabPageL2.SuspendLayout();
            this.tabPageL1.SuspendLayout();
            this.tabPageL4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonExtender1)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panel2Right.SuspendLayout();
            this.panel1Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Right)).BeginInit();
            this.pictureBox1Right.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel2Left.SuspendLayout();
            this.panel1Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Left)).BeginInit();
            this.pictureBox1Left.SuspendLayout();
            this.panel_Horizontal_ToolBar.SuspendLayout();
            this.panel_HorizontalToolBar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Horizontal_ToolBar)).BeginInit();
            this.pictureBox_Horizontal_ToolBar.SuspendLayout();
            this.tabPage_All.SuspendLayout();
            this.SuspendLayout();
            // 
            // helper
            // 
            this.helper.BackColor = System.Drawing.Color.Lavender;
            this.helper.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helper.ForeColor = System.Drawing.SystemColors.InfoText;
            this.helper.Location = new System.Drawing.Point(0, 460);
            this.helper.Name = "helper";
            this.helper.Size = new System.Drawing.Size(812, 159);
            this.helper.TabIndex = 0;
            this.helper.TabStop = false;
            // 
            // tabHeader1
            // 
            this.tabHeader1.BackColor = System.Drawing.Color.White;
            this.tabHeader1.Controls.Add(this.imageButton_Right);
            this.tabHeader1.Controls.Add(this.imageButton_Left);
            this.tabHeader1.Controls.Add(this.tabButton_TabControl);
            this.tabHeader1.Controls.Add(this.tabButton_Buttons);
            this.tabHeader1.Controls.Add(this.tabButton_DragAndDrop);
            this.tabHeader1.Controls.Add(this.tabButton_All);
            this.tabHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.helper.SetHelpText(this.tabHeader1, "tabHeader1");
            this.tabHeader1.Interval = 5;
            this.tabHeader1.Location = new System.Drawing.Point(0, 0);
            this.tabHeader1.Multiselect = false;
            this.tabHeader1.Name = "tabHeader1";
            this.tabHeader1.SelectedButton = this.tabButton_All;
            this.tabHeader1.Size = new System.Drawing.Size(812, 43);
            this.tabHeader1.SrcollLeftButton = this.imageButton_Left;
            this.tabHeader1.SrcollRightButton = this.imageButton_Right;
            this.tabHeader1.TabIndex = 0;
            this.tabHeader1.Vertical = false;
            // 
            // imageButton_Right
            // 
            this.imageButton_Right.AllowDrag = true;
            this.imageButton_Right.AllowDrop = true;
            this.imageButton_Right.Checked = false;
            this.imageButton_Right.Image = null;
            this.imageButton_Right.Location = new System.Drawing.Point(893, 9);
            this.imageButton_Right.Name = "imageButton_Right";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton_Right, 18);
            this.imageButton_Right.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton_Right, this.paintHelperRect);
            this.imageButton_Right.Size = new System.Drawing.Size(35, 25);
            this.imageButton_Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton_Right.TabIndex = 24;
            this.imageButton_Right.TabStop = false;
            // 
            // imageButton_Left
            // 
            this.imageButton_Left.AllowDrag = true;
            this.imageButton_Left.AllowDrop = true;
            this.imageButton_Left.Checked = false;
            this.imageButton_Left.Image = null;
            this.imageButton_Left.Location = new System.Drawing.Point(845, 9);
            this.imageButton_Left.Name = "imageButton_Left";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton_Left, 17);
            this.imageButton_Left.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton_Left, this.paintHelperRect);
            this.imageButton_Left.Size = new System.Drawing.Size(35, 25);
            this.imageButton_Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton_Left.TabIndex = 23;
            this.imageButton_Left.TabStop = false;
            // 
            // tabButton_TabControl
            // 
            this.tabButton_TabControl.AllowDrag = false;
            this.tabButton_TabControl.BaseVisible = true;
            this.tabButton_TabControl.Checked = false;
            this.tabButton_TabControl.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.CheckedEnterImage")));
            this.tabButton_TabControl.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.CheckedLeaveImage")));
            this.tabButton_TabControl.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_TabControl, "tabButton_TabControl");
            this.tabButton_TabControl.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.Image")));
            this.tabButton_TabControl.Location = new System.Drawing.Point(0, 0);
            this.tabButton_TabControl.Name = "tabButton_TabControl";
            this.tabButton_TabControl.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.NormalEnterImage")));
            this.tabButton_TabControl.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.NormalLeaveImage")));
            this.tabButton_TabControl.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_TabControl.NormalPressImage")));
            this.tabButton_TabControl.Size = new System.Drawing.Size(240, 44);
            this.tabButton_TabControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_TabControl.TabIndex = 13;
            this.tabButton_TabControl.TabStop = false;
            this.tabButton_TabControl.Text = "TabControl";
            this.tabButton_TabControl.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_Buttons
            // 
            this.tabButton_Buttons.AllowDrag = false;
            this.tabButton_Buttons.BaseVisible = true;
            this.tabButton_Buttons.Checked = false;
            this.tabButton_Buttons.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.CheckedEnterImage")));
            this.tabButton_Buttons.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.CheckedLeaveImage")));
            this.tabButton_Buttons.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_Buttons, "tabButton_Buttons");
            this.tabButton_Buttons.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.Image")));
            this.tabButton_Buttons.Location = new System.Drawing.Point(245, 0);
            this.tabButton_Buttons.Name = "tabButton_Buttons";
            this.tabButton_Buttons.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.NormalEnterImage")));
            this.tabButton_Buttons.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.NormalLeaveImage")));
            this.tabButton_Buttons.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_Buttons.NormalPressImage")));
            this.tabButton_Buttons.Size = new System.Drawing.Size(80, 44);
            this.tabButton_Buttons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_Buttons.TabIndex = 12;
            this.tabButton_Buttons.TabStop = false;
            this.tabButton_Buttons.Text = "Buttons";
            this.tabButton_Buttons.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_DragAndDrop
            // 
            this.tabButton_DragAndDrop.AllowDrag = false;
            this.tabButton_DragAndDrop.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabButton_DragAndDrop.BaseVisible = true;
            this.tabButton_DragAndDrop.Checked = false;
            this.tabButton_DragAndDrop.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.CheckedEnterImage")));
            this.tabButton_DragAndDrop.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.CheckedLeaveImage")));
            this.tabButton_DragAndDrop.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_DragAndDrop, "tabButton_DragAndDrop");
            this.tabButton_DragAndDrop.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.Image")));
            this.tabButton_DragAndDrop.Location = new System.Drawing.Point(330, 0);
            this.tabButton_DragAndDrop.Name = "tabButton_DragAndDrop";
            this.tabButton_DragAndDrop.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.NormalEnterImage")));
            this.tabButton_DragAndDrop.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.NormalLeaveImage")));
            this.tabButton_DragAndDrop.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_DragAndDrop.NormalPressImage")));
            this.tabButton_DragAndDrop.Size = new System.Drawing.Size(129, 44);
            this.tabButton_DragAndDrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_DragAndDrop.TabIndex = 11;
            this.tabButton_DragAndDrop.TabStop = false;
            this.tabButton_DragAndDrop.Text = "DragAndDrop";
            this.tabButton_DragAndDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_All
            // 
            this.tabButton_All.AllowDrag = false;
            this.tabButton_All.BackColor = System.Drawing.Color.Transparent;
            this.tabButton_All.BaseVisible = true;
            this.tabButton_All.Checked = true;
            this.helper.SetHelpText(this.tabButton_All, "tabButton_All");
            this.tabButton_All.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_All.Image")));
            this.tabButton_All.InitialImage = null;
            this.tabButton_All.Location = new System.Drawing.Point(461, 16);
            this.tabButton_All.Name = "tabButton_All";
            this.tabButton_All.Size = new System.Drawing.Size(167, 27);
            this.tabButton_All.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.tabButton_All.TabIndex = 10;
            this.tabButton_All.TabStop = false;
            this.tabButton_All.Text = "werer";
            this.tabButton_All.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_oval3
            // 
            this.tabButton_oval3.AllowDrag = false;
            this.tabButton_oval3.BaseVisible = true;
            this.tabButton_oval3.Checked = true;
            this.tabButton_oval3.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.CheckedEnterImage")));
            this.tabButton_oval3.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.CheckedLeaveImage")));
            this.tabButton_oval3.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_oval3, "TabButton_Laying");
            this.tabButton_oval3.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.Image")));
            this.tabButton_oval3.Location = new System.Drawing.Point(0, 0);
            this.tabButton_oval3.Name = "tabButton_oval3";
            this.tabButton_oval3.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.NormalEnterImage")));
            this.tabButton_oval3.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.NormalLeaveImage")));
            this.tabButton_oval3.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval3.NormalPressImage")));
            this.tabButton_oval3.Size = new System.Drawing.Size(211, 38);
            this.tabButton_oval3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_oval3.TabIndex = 6;
            this.tabButton_oval3.TabStop = false;
            this.tabButton_oval3.Text = "Vertical Left";
            this.tabButton_oval3.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton24
            // 
            this.tabButton24.AllowDrag = false;
            this.tabButton24.BaseVisible = true;
            this.tabButton24.Checked = true;
            this.tabButton24.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.CheckedEnterImage")));
            this.tabButton24.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.CheckedLeaveImage")));
            this.tabButton24.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton24, "TabButton_Laying");
            this.tabButton24.Image = ((System.Drawing.Image)(resources.GetObject("tabButton24.Image")));
            this.tabButton24.Location = new System.Drawing.Point(291, 0);
            this.tabButton24.Name = "tabButton24";
            this.tabButton24.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.NormalEnterImage")));
            this.tabButton24.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.NormalLeaveImage")));
            this.tabButton24.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton24.NormalPressImage")));
            this.tabButton24.Size = new System.Drawing.Size(209, 38);
            this.tabButton24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton24.TabIndex = 5;
            this.tabButton24.TabStop = false;
            this.tabButton24.Text = "Vertical Right";
            this.tabButton24.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_oval4
            // 
            this.tabButton_oval4.AllowDrag = false;
            this.tabButton_oval4.BaseVisible = true;
            this.tabButton_oval4.Checked = true;
            this.tabButton_oval4.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.CheckedEnterImage")));
            this.tabButton_oval4.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.CheckedLeaveImage")));
            this.tabButton_oval4.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_oval4, "TabButton_Laying");
            this.tabButton_oval4.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.Image")));
            this.tabButton_oval4.Location = new System.Drawing.Point(580, 0);
            this.tabButton_oval4.Name = "tabButton_oval4";
            this.tabButton_oval4.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.NormalEnterImage")));
            this.tabButton_oval4.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.NormalLeaveImage")));
            this.tabButton_oval4.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval4.NormalPressImage")));
            this.tabButton_oval4.Size = new System.Drawing.Size(216, 38);
            this.tabButton_oval4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_oval4.TabIndex = 4;
            this.tabButton_oval4.TabStop = false;
            this.tabButton_oval4.Text = "Horizontal Bottom";
            this.tabButton_oval4.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_oval1
            // 
            this.tabButton_oval1.AllowDrag = false;
            this.tabButton_oval1.BaseVisible = true;
            this.tabButton_oval1.Checked = false;
            this.tabButton_oval1.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.CheckedEnterImage")));
            this.tabButton_oval1.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.CheckedLeaveImage")));
            this.tabButton_oval1.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_oval1, "tabButton_bookmark");
            this.tabButton_oval1.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.Image")));
            this.tabButton_oval1.Location = new System.Drawing.Point(215, 0);
            this.tabButton_oval1.Name = "tabButton_oval1";
            this.tabButton_oval1.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.NormalEnterImage")));
            this.tabButton_oval1.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.NormalLeaveImage")));
            this.tabButton_oval1.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval1.NormalPressImage")));
            this.tabButton_oval1.Size = new System.Drawing.Size(142, 34);
            this.tabButton_oval1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_oval1.TabIndex = 6;
            this.tabButton_oval1.TabStop = false;
            this.tabButton_oval1.Text = "2";
            this.tabButton_oval1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton_oval2
            // 
            this.tabButton_oval2.AllowDrag = false;
            this.tabButton_oval2.BaseVisible = true;
            this.tabButton_oval2.Checked = true;
            this.tabButton_oval2.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.CheckedEnterImage")));
            this.tabButton_oval2.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.CheckedLeaveImage")));
            this.tabButton_oval2.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_oval2, "tabButton_bookmark");
            this.tabButton_oval2.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.Image")));
            this.tabButton_oval2.Location = new System.Drawing.Point(457, 0);
            this.tabButton_oval2.Name = "tabButton_oval2";
            this.tabButton_oval2.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.NormalEnterImage")));
            this.tabButton_oval2.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.NormalLeaveImage")));
            this.tabButton_oval2.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval2.NormalPressImage")));
            this.tabButton_oval2.Size = new System.Drawing.Size(321, 34);
            this.tabButton_oval2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_oval2.TabIndex = 5;
            this.tabButton_oval2.TabStop = false;
            this.tabButton_oval2.Text = "3";
            this.tabButton_oval2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabPage_Buttons
            // 
            this.tabPage_Buttons.BackColor = System.Drawing.Color.SkyBlue;
            this.tabPage_Buttons.Controls.Add(this.panel8);
            this.tabPage_Buttons.Controls.Add(this.tabHeader_Disabled_Buttons);
            this.tabPage_Buttons.Controls.Add(this.tabHeader_Buttons_Empty);
            this.tabPage_Buttons.Controls.Add(this.tabHeader5);
            this.tabPage_Buttons.Controls.Add(this.tabHeader_test);
            this.tabPage_Buttons.Controls.Add(this.tabPage_TrackBar);
            this.tabPage_Buttons.Controls.Add(this.tabHeader11);
            this.tabPage_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_Buttons.HeaderButton = this.tabButton_Buttons;
            this.helper.SetHelpText(this.tabPage_Buttons, "tabPage_Buttons");
            this.tabPage_Buttons.Location = new System.Drawing.Point(0, 53);
            this.tabPage_Buttons.Name = "tabPage_Buttons";
            this.tabPage_Buttons.Size = new System.Drawing.Size(812, 566);
            this.tabPage_Buttons.TabIndex = 10;
            this.tabPage_Buttons.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(230)))), ((int)(((byte)(70)))));
            this.panel8.Location = new System.Drawing.Point(67, 95);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(835, 17);
            this.panel8.TabIndex = 37;
            // 
            // tabHeader_Disabled_Buttons
            // 
            this.tabHeader_Disabled_Buttons.AllowDrop = true;
            this.tabHeader_Disabled_Buttons.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tabHeader_Disabled_Buttons.Controls.Add(this.tabButton76);
            this.tabHeader_Disabled_Buttons.Controls.Add(this.tabButton77);
            this.tabHeader_Disabled_Buttons.Controls.Add(this.tabButton78);
            this.tabHeader_Disabled_Buttons.Controls.Add(this.tabButton79);
            this.helper.SetHelpText(this.tabHeader_Disabled_Buttons, "tabHeader_Disabled_Buttons");
            this.tabHeader_Disabled_Buttons.Interval = 30;
            this.tabHeader_Disabled_Buttons.Location = new System.Drawing.Point(67, 327);
            this.tabHeader_Disabled_Buttons.Multiselect = true;
            this.tabHeader_Disabled_Buttons.Name = "tabHeader_Disabled_Buttons";
            this.tabHeader_Disabled_Buttons.SelectedButton = null;
            this.tabHeader_Disabled_Buttons.Size = new System.Drawing.Size(336, 43);
            this.tabHeader_Disabled_Buttons.SrcollLeftButton = null;
            this.tabHeader_Disabled_Buttons.SrcollRightButton = null;
            this.tabHeader_Disabled_Buttons.TabIndex = 36;
            this.tabHeader_Disabled_Buttons.Vertical = false;
            // 
            // tabButton76
            // 
            this.tabButton76.AllowDrag = false;
            this.tabButton76.BaseVisible = true;
            this.tabButton76.Checked = false;
            this.tabButton76.Enabled = false;
            this.tabButton76.Image = null;
            this.tabButton76.Location = new System.Drawing.Point(0, 0);
            this.tabButton76.Name = "tabButton76";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton76, 16);
            this.tabButton76.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton76, this.paintHelperRect);
            this.tabButton76.Size = new System.Drawing.Size(48, 43);
            this.tabButton76.TabIndex = 18;
            this.tabButton76.TabStop = false;
            // 
            // tabButton77
            // 
            this.tabButton77.AllowDrag = false;
            this.tabButton77.BaseVisible = true;
            this.tabButton77.Checked = false;
            this.tabButton77.Enabled = false;
            this.tabButton77.Image = null;
            this.tabButton77.Location = new System.Drawing.Point(78, 0);
            this.tabButton77.Name = "tabButton77";
            this.tabButtonExtender1.SetNormalDisableImageIndex(this.tabButton77, 16);
            this.tabButton77.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton77, this.paintHelperEllipse);
            this.tabButton77.Size = new System.Drawing.Size(48, 43);
            this.tabButton77.TabIndex = 6;
            this.tabButton77.TabStop = false;
            // 
            // tabButton78
            // 
            this.tabButton78.AllowDrag = false;
            this.tabButton78.BaseVisible = true;
            this.tabButton78.Checked = false;
            this.tabButton78.Enabled = false;
            this.tabButton78.Image = null;
            this.tabButton78.Location = new System.Drawing.Point(156, 0);
            this.tabButton78.Name = "tabButton78";
            this.tabButtonExtender1.SetNormalDisableImageIndex(this.tabButton78, 16);
            this.tabButton78.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton78, this.paintHelperRhomd);
            this.tabButton78.Size = new System.Drawing.Size(48, 43);
            this.tabButton78.TabIndex = 17;
            this.tabButton78.TabStop = false;
            // 
            // tabButton79
            // 
            this.tabButton79.AllowDrag = false;
            this.tabButton79.BaseVisible = true;
            this.tabButton79.Checked = false;
            this.tabButton79.Enabled = false;
            this.tabButton79.Image = null;
            this.tabButton79.Location = new System.Drawing.Point(234, 0);
            this.tabButton79.Name = "tabButton79";
            this.tabButtonExtender1.SetNormalDisableImageIndex(this.tabButton79, 16);
            this.tabButton79.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton79, this.paintHelperRect2);
            this.tabButton79.Size = new System.Drawing.Size(48, 43);
            this.tabButton79.TabIndex = 16;
            this.tabButton79.TabStop = false;
            // 
            // tabHeader_Buttons_Empty
            // 
            this.tabHeader_Buttons_Empty.AllowDrop = true;
            this.tabHeader_Buttons_Empty.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_Buttons_Empty.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader_Buttons_Empty.BackgroundImage")));
            this.tabHeader_Buttons_Empty.Controls.Add(this.tabButton53);
            this.tabHeader_Buttons_Empty.Controls.Add(this.tabButton48);
            this.tabHeader_Buttons_Empty.Controls.Add(this.tabButton51);
            this.tabHeader_Buttons_Empty.Controls.Add(this.tabButton52);
            this.helper.SetHelpText(this.tabHeader_Buttons_Empty, "tabHeader_Buttons_Empty");
            this.tabHeader_Buttons_Empty.Interval = 30;
            this.tabHeader_Buttons_Empty.Location = new System.Drawing.Point(67, 258);
            this.tabHeader_Buttons_Empty.Multiselect = true;
            this.tabHeader_Buttons_Empty.Name = "tabHeader_Buttons_Empty";
            this.tabHeader_Buttons_Empty.SelectedButton = null;
            this.tabHeader_Buttons_Empty.Size = new System.Drawing.Size(336, 44);
            this.tabHeader_Buttons_Empty.SrcollLeftButton = null;
            this.tabHeader_Buttons_Empty.SrcollRightButton = null;
            this.tabHeader_Buttons_Empty.TabIndex = 35;
            this.tabHeader_Buttons_Empty.Vertical = false;
            // 
            // tabButton53
            // 
            this.tabButton53.AllowDrag = false;
            this.tabButton53.BackColor = System.Drawing.Color.Transparent;
            this.tabButton53.BaseVisible = true;
            this.tabButton53.Checked = true;
            this.helper.SetHelpText(this.tabButton53, "tabButton_Empty");
            this.tabButton53.Image = null;
            this.tabButton53.Location = new System.Drawing.Point(0, 0);
            this.tabButton53.Name = "tabButton53";
            this.tabButton53.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton53, this.paintHelperRhomd);
            this.tabButton53.Size = new System.Drawing.Size(48, 43);
            this.tabButton53.TabIndex = 19;
            this.tabButton53.TabStop = false;
            // 
            // tabButton48
            // 
            this.tabButton48.AllowDrag = false;
            this.tabButton48.BackColor = System.Drawing.Color.Transparent;
            this.tabButton48.BaseVisible = true;
            this.tabButton48.Checked = true;
            this.helper.SetHelpText(this.tabButton48, "tabButton_Empty");
            this.tabButton48.Image = null;
            this.tabButton48.Location = new System.Drawing.Point(78, 0);
            this.tabButton48.Name = "tabButton48";
            this.tabButton48.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton48, this.paintHelperEllipse);
            this.tabButton48.Size = new System.Drawing.Size(48, 43);
            this.tabButton48.TabIndex = 6;
            this.tabButton48.TabStop = false;
            // 
            // tabButton51
            // 
            this.tabButton51.AllowDrag = false;
            this.tabButton51.BackColor = System.Drawing.Color.Transparent;
            this.tabButton51.BaseVisible = true;
            this.tabButton51.Checked = true;
            this.helper.SetHelpText(this.tabButton51, "tabButton_Empty");
            this.tabButton51.Image = null;
            this.tabButton51.Location = new System.Drawing.Point(156, 0);
            this.tabButton51.Name = "tabButton51";
            this.tabButton51.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton51, this.paintHelperRect);
            this.tabButton51.Size = new System.Drawing.Size(48, 43);
            this.tabButton51.TabIndex = 17;
            this.tabButton51.TabStop = false;
            // 
            // tabButton52
            // 
            this.tabButton52.AllowDrag = false;
            this.tabButton52.BackColor = System.Drawing.Color.Transparent;
            this.tabButton52.BaseVisible = true;
            this.tabButton52.Checked = true;
            this.helper.SetHelpText(this.tabButton52, "tabButton_Empty");
            this.tabButton52.Image = null;
            this.tabButton52.Location = new System.Drawing.Point(234, 0);
            this.tabButton52.Name = "tabButton52";
            this.tabButton52.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton52, this.paintHelperRect2);
            this.tabButton52.Size = new System.Drawing.Size(48, 43);
            this.tabButton52.TabIndex = 16;
            this.tabButton52.TabStop = false;
            // 
            // tabHeader5
            // 
            this.tabHeader5.AllowDrop = true;
            this.tabHeader5.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader5.BackgroundImage")));
            this.tabHeader5.Controls.Add(this.tabButton70);
            this.tabHeader5.Controls.Add(this.tabButton71);
            this.tabHeader5.Controls.Add(this.tabButton72);
            this.tabHeader5.Controls.Add(this.tabButton73);
            this.helper.SetHelpText(this.tabHeader5, "tabHeader_test");
            this.tabHeader5.Interval = 30;
            this.tabHeader5.Location = new System.Drawing.Point(67, 190);
            this.tabHeader5.Multiselect = true;
            this.tabHeader5.Name = "tabHeader5";
            this.tabHeader5.SelectedButton = null;
            this.tabHeader5.Size = new System.Drawing.Size(336, 43);
            this.tabHeader5.SrcollLeftButton = null;
            this.tabHeader5.SrcollRightButton = null;
            this.tabHeader5.TabIndex = 34;
            this.tabHeader5.Vertical = false;
            // 
            // tabButton70
            // 
            this.tabButton70.AllowDrag = false;
            this.tabButton70.BaseVisible = true;
            this.tabButton70.Checked = false;
            this.helper.SetHelpText(this.tabButton70, "tabButton_Ext");
            this.tabButton70.Image = null;
            this.tabButton70.Location = new System.Drawing.Point(0, 0);
            this.tabButton70.Name = "tabButton70";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton70, 16);
            this.tabButton70.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton70, this.paintHelperRect);
            this.tabButton70.Size = new System.Drawing.Size(48, 43);
            this.tabButton70.TabIndex = 20;
            this.tabButton70.TabStop = false;
            // 
            // tabButton71
            // 
            this.tabButton71.AllowDrag = false;
            this.tabButton71.BaseVisible = true;
            this.tabButton71.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton71, 15);
            this.helper.SetHelpText(this.tabButton71, "tabButton_Ext");
            this.tabButton71.Image = null;
            this.tabButton71.Location = new System.Drawing.Point(78, 0);
            this.tabButton71.Name = "tabButton71";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton71, 14);
            this.tabButton71.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton71, this.paintHelperEllipse);
            this.tabButton71.Size = new System.Drawing.Size(48, 43);
            this.tabButton71.TabIndex = 18;
            this.tabButton71.TabStop = false;
            // 
            // tabButton72
            // 
            this.tabButton72.AllowDrag = false;
            this.tabButton72.BaseVisible = true;
            this.tabButton72.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton72, 0);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButton72, 7);
            this.helper.SetHelpText(this.tabButton72, "tabButton_Ext");
            this.tabButton72.Image = null;
            this.tabButton72.Location = new System.Drawing.Point(156, 0);
            this.tabButton72.Name = "tabButton72";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton72, 1);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton72, 7);
            this.tabButton72.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton72, this.paintHelperRhomd);
            this.tabButton72.Size = new System.Drawing.Size(48, 43);
            this.tabButton72.TabIndex = 17;
            this.tabButton72.TabStop = false;
            // 
            // tabButton73
            // 
            this.tabButton73.AllowDrag = false;
            this.tabButton73.BaseVisible = true;
            this.tabButton73.Checked = false;
            this.helper.SetHelpText(this.tabButton73, "tabButton_Ext");
            this.tabButton73.Image = null;
            this.tabButton73.Location = new System.Drawing.Point(234, 0);
            this.tabButton73.Name = "tabButton73";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButton73, 3);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton73, 1);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton73, 2);
            this.tabButton73.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton73, this.paintHelperRect2);
            this.tabButton73.Size = new System.Drawing.Size(48, 43);
            this.tabButton73.TabIndex = 16;
            this.tabButton73.TabStop = false;
            // 
            // tabHeader_test
            // 
            this.tabHeader_test.AllowDrop = true;
            this.tabHeader_test.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_test.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader_test.BackgroundImage")));
            this.tabHeader_test.Controls.Add(this.tabButton54);
            this.tabHeader_test.Controls.Add(this.tabButton1);
            this.tabHeader_test.Controls.Add(this.tabButton47);
            this.tabHeader_test.Controls.Add(this.tabButton49);
            this.helper.SetHelpText(this.tabHeader_test, "tabHeader_test");
            this.tabHeader_test.Interval = 30;
            this.tabHeader_test.Location = new System.Drawing.Point(67, 129);
            this.tabHeader_test.Multiselect = true;
            this.tabHeader_test.Name = "tabHeader_test";
            this.tabHeader_test.SelectedButton = null;
            this.tabHeader_test.Size = new System.Drawing.Size(336, 43);
            this.tabHeader_test.SrcollLeftButton = null;
            this.tabHeader_test.SrcollRightButton = null;
            this.tabHeader_test.TabIndex = 33;
            this.tabHeader_test.Vertical = false;
            // 
            // tabButton54
            // 
            this.tabButton54.AllowDrag = false;
            this.tabButton54.BaseVisible = true;
            this.tabButton54.Checked = false;
            this.tabButtonExtender1.SetCheckedEnterImageIndex(this.tabButton54, 5);
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton54, 3);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButton54, 4);
            this.helper.SetHelpText(this.tabButton54, "tabButton_8_Kind");
            this.tabButton54.Image = null;
            this.tabButton54.Location = new System.Drawing.Point(0, 0);
            this.tabButton54.Name = "tabButton54";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButton54, 2);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton54, 0);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton54, 1);
            this.tabButton54.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton54, this.paintHelper);
            this.tabButton54.Size = new System.Drawing.Size(48, 43);
            this.tabButton54.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tabButton54.TabIndex = 22;
            this.tabButton54.TabStop = false;
            // 
            // tabButton1
            // 
            this.tabButton1.AllowDrag = false;
            this.tabButton1.BaseVisible = true;
            this.tabButton1.Checked = false;
            this.tabButtonExtender1.SetCheckedEnterImageIndex(this.tabButton1, 5);
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton1, 3);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButton1, 4);
            this.helper.SetHelpText(this.tabButton1, "tabButton_8_Kind");
            this.tabButton1.Image = null;
            this.tabButton1.Location = new System.Drawing.Point(78, 0);
            this.tabButton1.Name = "tabButton1";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButton1, 2);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton1, 0);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton1, 1);
            this.tabButton1.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton1, this.paintHelper);
            this.tabButton1.Size = new System.Drawing.Size(48, 43);
            this.tabButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton1.TabIndex = 21;
            this.tabButton1.TabStop = false;
            // 
            // tabButton47
            // 
            this.tabButton47.AllowDrag = false;
            this.tabButton47.BaseVisible = true;
            this.tabButton47.Checked = true;
            this.tabButtonExtender1.SetCheckedEnterImageIndex(this.tabButton47, 5);
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton47, 3);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButton47, 4);
            this.helper.SetHelpText(this.tabButton47, "tabButton_8_Kind");
            this.tabButton47.Image = null;
            this.tabButton47.Location = new System.Drawing.Point(156, 0);
            this.tabButton47.Name = "tabButton47";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButton47, 2);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton47, 0);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton47, 1);
            this.tabButton47.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton47, this.paintHelper);
            this.tabButton47.Size = new System.Drawing.Size(48, 43);
            this.tabButton47.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tabButton47.TabIndex = 18;
            this.tabButton47.TabStop = false;
            // 
            // tabButton49
            // 
            this.tabButton49.AllowDrag = false;
            this.tabButton49.BaseVisible = true;
            this.tabButton49.Checked = false;
            this.tabButtonExtender1.SetCheckedEnterImageIndex(this.tabButton49, 5);
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton49, 3);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButton49, 4);
            this.helper.SetHelpText(this.tabButton49, "tabButton_8_Kind");
            this.tabButton49.Image = null;
            this.tabButton49.Location = new System.Drawing.Point(234, 0);
            this.tabButton49.Name = "tabButton49";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButton49, 2);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton49, 0);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton49, 1);
            this.tabButton49.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton49, this.paintHelper);
            this.tabButton49.Size = new System.Drawing.Size(48, 43);
            this.tabButton49.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tabButton49.TabIndex = 17;
            this.tabButton49.TabStop = false;
            // 
            // tabPage_TrackBar
            // 
            this.tabPage_TrackBar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage_TrackBar.Controls.Add(this.trackBar1);
            this.helper.SetHelpText(this.tabPage_TrackBar, "tabPage_TrackBar");
            this.tabPage_TrackBar.Location = new System.Drawing.Point(461, 155);
            this.tabPage_TrackBar.Name = "tabPage_TrackBar";
            this.tabPage_TrackBar.Size = new System.Drawing.Size(441, 147);
            this.tabPage_TrackBar.TabIndex = 27;
            // 
            // trackBar1
            // 
            this.helper.SetHelpText(this.trackBar1, "tabPage_TrackBar");
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(19, 52);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(403, 42);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 190;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tabHeader11
            // 
            this.tabHeader11.AllowDrop = true;
            this.tabHeader11.BackColor = System.Drawing.Color.SkyBlue;
            this.tabHeader11.Controls.Add(this.tabButton_oval_);
            this.tabHeader11.Controls.Add(this.tabButton_oval1);
            this.tabHeader11.Controls.Add(this.tabButton_oval2);
            this.tabHeader11.Interval = 100;
            this.tabHeader11.Location = new System.Drawing.Point(67, 60);
            this.tabHeader11.Multiselect = true;
            this.tabHeader11.Name = "tabHeader11";
            this.tabHeader11.SelectedButton = null;
            this.tabHeader11.Size = new System.Drawing.Size(835, 35);
            this.tabHeader11.SrcollLeftButton = null;
            this.tabHeader11.SrcollRightButton = null;
            this.tabHeader11.TabIndex = 1;
            this.tabHeader11.Vertical = false;
            // 
            // tabButton_oval_
            // 
            this.tabButton_oval_.AllowDrag = false;
            this.tabButton_oval_.BaseVisible = true;
            this.tabButton_oval_.Checked = false;
            this.tabButton_oval_.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.CheckedEnterImage")));
            this.tabButton_oval_.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.CheckedLeaveImage")));
            this.tabButton_oval_.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton_oval_, "tabButton_bookmark");
            this.tabButton_oval_.Image = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.Image")));
            this.tabButton_oval_.Location = new System.Drawing.Point(0, 0);
            this.tabButton_oval_.Name = "tabButton_oval_";
            this.tabButton_oval_.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.NormalEnterImage")));
            this.tabButton_oval_.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.NormalLeaveImage")));
            this.tabButton_oval_.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton_oval_.NormalPressImage")));
            this.tabButton_oval_.Size = new System.Drawing.Size(115, 34);
            this.tabButton_oval_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton_oval_.TabIndex = 7;
            this.tabButton_oval_.TabStop = false;
            this.tabButton_oval_.Text = "1";
            this.tabButton_oval_.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabPage_email
            // 
            this.tabPage_email.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage_email.Controls.Add(this.linkLabel1);
            this.tabPage_email.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPage_email.HeaderButton = this.tabButton_email;
            this.helper.SetHelpText(this.tabPage_email, "tabPage_email");
            this.tabPage_email.Location = new System.Drawing.Point(0, 334);
            this.tabPage_email.Name = "tabPage_email";
            this.tabPage_email.Size = new System.Drawing.Size(313, 32);
            this.tabPage_email.TabIndex = 18;
            this.tabPage_email.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkLabel1.Location = new System.Drawing.Point(106, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 24);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "support@eboris.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabButton_email
            // 
            this.tabButton_email.AllowDrag = true;
            this.tabButton_email.AllowDrop = true;
            this.tabButton_email.BaseVisible = true;
            this.tabButton_email.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton_email, 1);
            this.helper.SetHelpText(this.tabButton_email, "tabButton_email");
            this.tabButton_email.Image = null;
            this.tabButton_email.Location = new System.Drawing.Point(0, 0);
            this.tabButton_email.Name = "tabButton_email";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton_email, 5);
            this.tabButton_email.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton_email, this.paintHelperRect);
            this.tabButton_email.Size = new System.Drawing.Size(48, 43);
            this.tabButton_email.TabIndex = 28;
            this.tabButton_email.TabStop = false;
            // 
            // tabHeader1Right
            // 
            this.tabHeader1Right.AllowDrop = true;
            this.tabHeader1Right.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader1Right.Controls.Add(this.tabButtonR7);
            this.tabHeader1Right.Controls.Add(this.tabButtonR6);
            this.tabHeader1Right.Controls.Add(this.tabButtonR5);
            this.tabHeader1Right.Controls.Add(this.tabButtonR4);
            this.tabHeader1Right.Controls.Add(this.tabButtonR1);
            this.tabHeader1Right.Controls.Add(this.tabButtonR2);
            this.tabHeader1Right.Controls.Add(this.tabButtonR3);
            this.tabHeader1Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader1Right, "tabHeader_DAD");
            this.tabHeader1Right.Interval = 1;
            this.tabHeader1Right.Location = new System.Drawing.Point(0, 0);
            this.tabHeader1Right.Multiselect = true;
            this.tabHeader1Right.Name = "tabHeader1Right";
            this.tabHeader1Right.SelectedButton = null;
            this.tabHeader1Right.Size = new System.Drawing.Size(48, 523);
            this.tabHeader1Right.SrcollLeftButton = null;
            this.tabHeader1Right.SrcollRightButton = null;
            this.tabHeader1Right.TabIndex = 5;
            this.tabHeader1Right.Vertical = true;
            this.tabHeader1Right.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader1Right.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButtonR7
            // 
            this.tabButtonR7.AllowDrag = true;
            this.tabButtonR7.AllowDrop = true;
            this.tabButtonR7.BaseVisible = true;
            this.tabButtonR7.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR7, 9);
            this.helper.SetHelpText(this.tabButtonR7, "tabButton_DAD_Heading");
            this.tabButtonR7.Image = null;
            this.tabButtonR7.Location = new System.Drawing.Point(0, 0);
            this.tabButtonR7.Name = "tabButtonR7";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR7, 13);
            this.tabButtonR7.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR7, this.paintHelperRhomd);
            this.tabButtonR7.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR7.TabIndex = 12;
            this.tabButtonR7.TabStop = false;
            // 
            // tabButtonR6
            // 
            this.tabButtonR6.AllowDrag = true;
            this.tabButtonR6.AllowDrop = true;
            this.tabButtonR6.BaseVisible = true;
            this.tabButtonR6.Checked = false;
            this.tabButtonExtender1.SetCheckedEnterImageIndex(this.tabButtonR6, 0);
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR6, 1);
            this.tabButtonExtender1.SetCheckedPressImageIndex(this.tabButtonR6, 2);
            this.helper.SetHelpText(this.tabButtonR6, "tabButton_DAD_Heading");
            this.tabButtonR6.Image = null;
            this.tabButtonR6.Location = new System.Drawing.Point(0, 44);
            this.tabButtonR6.Name = "tabButtonR6";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonR6, 4);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR6, 5);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonR6, 7);
            this.tabButtonR6.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR6, this.paintHelperEllipse);
            this.tabButtonR6.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR6.TabIndex = 11;
            this.tabButtonR6.TabStop = false;
            // 
            // tabButtonR5
            // 
            this.tabButtonR5.AllowDrag = true;
            this.tabButtonR5.AllowDrop = true;
            this.tabButtonR5.BaseVisible = true;
            this.tabButtonR5.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR5, 1);
            this.helper.SetHelpText(this.tabButtonR5, "tabButton_DAD_Heading");
            this.tabButtonR5.Image = null;
            this.tabButtonR5.Location = new System.Drawing.Point(0, 88);
            this.tabButtonR5.Name = "tabButtonR5";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonR5, 7);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR5, 5);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonR5, 4);
            this.tabButtonR5.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR5, this.paintHelperRhomd);
            this.tabButtonR5.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR5.TabIndex = 10;
            this.tabButtonR5.TabStop = false;
            // 
            // tabButtonR4
            // 
            this.tabButtonR4.AllowDrag = true;
            this.tabButtonR4.AllowDrop = true;
            this.tabButtonR4.BaseVisible = true;
            this.tabButtonR4.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR4, 9);
            this.helper.SetHelpText(this.tabButtonR4, "tabButton_DAD_Heading");
            this.tabButtonR4.Image = null;
            this.tabButtonR4.Location = new System.Drawing.Point(0, 132);
            this.tabButtonR4.Name = "tabButtonR4";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonR4, 11);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR4, 8);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonR4, 12);
            this.tabButtonR4.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR4, this.paintHelperRect2);
            this.tabButtonR4.Size = new System.Drawing.Size(48, 44);
            this.tabButtonR4.TabIndex = 9;
            this.tabButtonR4.TabStop = false;
            // 
            // tabButtonR1
            // 
            this.tabButtonR1.AllowDrag = true;
            this.tabButtonR1.AllowDrop = true;
            this.tabButtonR1.BaseVisible = true;
            this.tabButtonR1.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR1, 3);
            this.helper.SetHelpText(this.tabButtonR1, "tabButton_DAD_Heading");
            this.tabButtonR1.Image = null;
            this.tabButtonR1.Location = new System.Drawing.Point(0, 177);
            this.tabButtonR1.Name = "tabButtonR1";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR1, 11);
            this.tabButtonR1.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR1, this.paintHelperRect);
            this.tabButtonR1.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR1.TabIndex = 8;
            this.tabButtonR1.TabStop = false;
            // 
            // tabButtonR2
            // 
            this.tabButtonR2.AllowDrag = true;
            this.tabButtonR2.AllowDrop = true;
            this.tabButtonR2.BaseVisible = true;
            this.tabButtonR2.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR2, 9);
            this.helper.SetHelpText(this.tabButtonR2, "tabButton_DAD_Heading");
            this.tabButtonR2.Image = null;
            this.tabButtonR2.Location = new System.Drawing.Point(0, 221);
            this.tabButtonR2.Name = "tabButtonR2";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonR2, 13);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR2, 15);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonR2, 12);
            this.tabButtonR2.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR2, this.paintHelperEllipse);
            this.tabButtonR2.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR2.TabIndex = 7;
            this.tabButtonR2.TabStop = false;
            // 
            // tabButtonR3
            // 
            this.tabButtonR3.AllowDrag = true;
            this.tabButtonR3.AllowDrop = true;
            this.tabButtonR3.BaseVisible = true;
            this.tabButtonR3.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonR3, 9);
            this.helper.SetHelpText(this.tabButtonR3, "tabButton_DAD_Heading");
            this.tabButtonR3.Image = null;
            this.tabButtonR3.Location = new System.Drawing.Point(0, 265);
            this.tabButtonR3.Name = "tabButtonR3";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonR3, 10);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonR3, 14);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonR3, 6);
            this.tabButtonR3.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonR3, this.paintHelperEllipse);
            this.tabButtonR3.Size = new System.Drawing.Size(48, 43);
            this.tabButtonR3.TabIndex = 6;
            this.tabButtonR3.TabStop = false;
            // 
            // tabHeader1Left
            // 
            this.tabHeader1Left.AllowDrop = true;
            this.tabHeader1Left.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader1Left.Controls.Add(this.tabButtonL1);
            this.tabHeader1Left.Controls.Add(this.tabButtonL2);
            this.tabHeader1Left.Controls.Add(this.tabButtonL3);
            this.tabHeader1Left.Controls.Add(this.tabButtonL4);
            this.tabHeader1Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader1Left, "tabHeader_DAD");
            this.tabHeader1Left.Interval = 1;
            this.tabHeader1Left.Location = new System.Drawing.Point(0, 0);
            this.tabHeader1Left.Multiselect = true;
            this.tabHeader1Left.Name = "tabHeader1Left";
            this.tabHeader1Left.SelectedButton = null;
            this.tabHeader1Left.Size = new System.Drawing.Size(48, 523);
            this.tabHeader1Left.SrcollLeftButton = null;
            this.tabHeader1Left.SrcollRightButton = null;
            this.tabHeader1Left.TabIndex = 5;
            this.tabHeader1Left.Vertical = true;
            this.tabHeader1Left.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader1Left.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButtonL1
            // 
            this.tabButtonL1.AllowDrag = false;
            this.tabButtonL1.BaseVisible = true;
            this.tabButtonL1.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonL1, 1);
            this.helper.SetHelpText(this.tabButtonL1, "tabButton_DAD_Heading");
            this.tabButtonL1.Image = null;
            this.tabButtonL1.Location = new System.Drawing.Point(0, 0);
            this.tabButtonL1.Name = "tabButtonL1";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonL1, 4);
            this.tabButtonL1.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonL1, this.paintHelperRect2);
            this.tabButtonL1.Size = new System.Drawing.Size(48, 43);
            this.tabButtonL1.TabIndex = 9;
            this.tabButtonL1.TabStop = false;
            // 
            // tabButtonL2
            // 
            this.tabButtonL2.AllowDrag = true;
            this.tabButtonL2.AllowDrop = true;
            this.tabButtonL2.BaseVisible = true;
            this.tabButtonL2.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonL2, 1);
            this.helper.SetHelpText(this.tabButtonL2, "tabButton_DAD_Heading");
            this.tabButtonL2.Image = null;
            this.tabButtonL2.Location = new System.Drawing.Point(0, 44);
            this.tabButtonL2.Name = "tabButtonL2";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonL2, 3);
            this.tabButtonL2.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonL2, this.paintHelperRhomd);
            this.tabButtonL2.Size = new System.Drawing.Size(48, 43);
            this.tabButtonL2.TabIndex = 8;
            this.tabButtonL2.TabStop = false;
            // 
            // tabButtonL3
            // 
            this.tabButtonL3.AllowDrag = true;
            this.tabButtonL3.AllowDrop = true;
            this.tabButtonL3.BaseVisible = true;
            this.tabButtonL3.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonL3, 1);
            this.helper.SetHelpText(this.tabButtonL3, "tabButton_DAD_Heading");
            this.tabButtonL3.Image = null;
            this.tabButtonL3.Location = new System.Drawing.Point(0, 88);
            this.tabButtonL3.Name = "tabButtonL3";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonL3, 0);
            this.tabButtonL3.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonL3, this.paintHelperEllipse);
            this.tabButtonL3.Size = new System.Drawing.Size(48, 43);
            this.tabButtonL3.TabIndex = 7;
            this.tabButtonL3.TabStop = false;
            // 
            // tabButtonL4
            // 
            this.tabButtonL4.AllowDrag = true;
            this.tabButtonL4.AllowDrop = true;
            this.tabButtonL4.BaseVisible = true;
            this.tabButtonL4.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonL4, 1);
            this.helper.SetHelpText(this.tabButtonL4, "tabButton_DAD_Heading");
            this.tabButtonL4.Image = null;
            this.tabButtonL4.Location = new System.Drawing.Point(0, 132);
            this.tabButtonL4.Name = "tabButtonL4";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonL4, 2);
            this.tabButtonL4.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonL4, this.paintHelperRect);
            this.tabButtonL4.Size = new System.Drawing.Size(48, 44);
            this.tabButtonL4.TabIndex = 6;
            this.tabButtonL4.TabStop = false;
            // 
            // tabPage_DragAndDrop
            // 
            this.tabPage_DragAndDrop.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage_DragAndDrop.Controls.Add(this.panel2);
            this.tabPage_DragAndDrop.Controls.Add(this.panel6);
            this.tabPage_DragAndDrop.Controls.Add(this.panel4);
            this.tabPage_DragAndDrop.Controls.Add(this.panel1);
            this.tabPage_DragAndDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_DragAndDrop.HeaderButton = this.tabButton_DragAndDrop;
            this.helper.SetHelpText(this.tabPage_DragAndDrop, "tabPage_DragAndDrop");
            this.tabPage_DragAndDrop.Location = new System.Drawing.Point(0, 53);
            this.tabPage_DragAndDrop.Name = "tabPage_DragAndDrop";
            this.tabPage_DragAndDrop.Size = new System.Drawing.Size(812, 566);
            this.tabPage_DragAndDrop.TabIndex = 9;
            this.tabPage_DragAndDrop.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(36, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 377);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Aquamarine;
            this.panel3.Controls.Add(this.tabHeader8);
            this.panel3.Controls.Add(this.tabHeader9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 330);
            this.panel3.TabIndex = 24;
            // 
            // tabHeader8
            // 
            this.tabHeader8.AllowDrop = true;
            this.tabHeader8.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader8.BackgroundImage")));
            this.tabHeader8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader8.Controls.Add(this.tabButton9);
            this.tabHeader8.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabHeader8.HeaderButton = this.tabButton32;
            this.helper.SetHelpText(this.tabHeader8, "tabHeader_DAD_child");
            this.tabHeader8.Interval = 1;
            this.tabHeader8.Location = new System.Drawing.Point(53, 0);
            this.tabHeader8.Multiselect = true;
            this.tabHeader8.Name = "tabHeader8";
            this.tabHeader8.SelectedButton = this.tabButton9;
            this.tabHeader8.Size = new System.Drawing.Size(53, 330);
            this.tabHeader8.SrcollLeftButton = null;
            this.tabHeader8.SrcollRightButton = null;
            this.tabHeader8.TabIndex = 23;
            this.tabHeader8.Vertical = true;
            this.tabHeader8.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader8.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton9
            // 
            this.tabButton9.AllowDrag = true;
            this.tabButton9.AllowDrop = true;
            this.tabButton9.BackColor = System.Drawing.Color.Transparent;
            this.tabButton9.BaseVisible = true;
            this.tabButton9.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton9, 9);
            this.helper.SetHelpText(this.tabButton9, "Buttons_DragAndDrop");
            this.tabButton9.Image = null;
            this.tabButton9.Location = new System.Drawing.Point(0, 0);
            this.tabButton9.Name = "tabButton9";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton9, 13);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton9, 15);
            this.tabButton9.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton9, this.paintHelperEllipse);
            this.tabButton9.Size = new System.Drawing.Size(48, 43);
            this.tabButton9.TabIndex = 9;
            this.tabButton9.TabStop = false;
            // 
            // tabButton32
            // 
            this.tabButton32.AllowDrag = true;
            this.tabButton32.AllowDrop = true;
            this.tabButton32.BaseVisible = true;
            this.tabButton32.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton32, 2);
            this.helper.SetHelpText(this.tabButton32, "tabButton_DAD_Heading");
            this.tabButton32.Image = null;
            this.tabButton32.Location = new System.Drawing.Point(52, 0);
            this.tabButton32.Name = "tabButton32";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton32, 5);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton32, 0);
            this.tabButton32.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton32, this.paintHelperRect);
            this.tabButton32.Size = new System.Drawing.Size(48, 43);
            this.tabButton32.TabIndex = 8;
            this.tabButton32.TabStop = false;
            // 
            // tabHeader9
            // 
            this.tabHeader9.AllowDrop = true;
            this.tabHeader9.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader9.BackgroundImage")));
            this.tabHeader9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader9.Controls.Add(this.tabButton29);
            this.tabHeader9.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabHeader9.ForeColor = System.Drawing.Color.Black;
            this.tabHeader9.HeaderButton = this.tabButton31;
            this.helper.SetHelpText(this.tabHeader9, "tabHeader_DAD_child");
            this.tabHeader9.Interval = 1;
            this.tabHeader9.Location = new System.Drawing.Point(0, 0);
            this.tabHeader9.Multiselect = true;
            this.tabHeader9.Name = "tabHeader9";
            this.tabHeader9.SelectedButton = this.tabButton29;
            this.tabHeader9.Size = new System.Drawing.Size(53, 330);
            this.tabHeader9.SrcollLeftButton = null;
            this.tabHeader9.SrcollRightButton = null;
            this.tabHeader9.TabIndex = 22;
            this.tabHeader9.Vertical = true;
            this.tabHeader9.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader9.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton29
            // 
            this.tabButton29.AllowDrag = true;
            this.tabButton29.AllowDrop = true;
            this.tabButton29.BackColor = System.Drawing.Color.Transparent;
            this.tabButton29.BaseVisible = true;
            this.tabButton29.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton29, 9);
            this.helper.SetHelpText(this.tabButton29, "Buttons_DragAndDrop");
            this.tabButton29.Image = null;
            this.tabButton29.Location = new System.Drawing.Point(0, 0);
            this.tabButton29.Name = "tabButton29";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton29, 13);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton29, 15);
            this.tabButton29.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton29, this.paintHelperEllipse);
            this.tabButton29.Size = new System.Drawing.Size(48, 43);
            this.tabButton29.TabIndex = 9;
            this.tabButton29.TabStop = false;
            // 
            // tabButton31
            // 
            this.tabButton31.AllowDrag = true;
            this.tabButton31.AllowDrop = true;
            this.tabButton31.BaseVisible = true;
            this.tabButton31.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton31, 2);
            this.helper.SetHelpText(this.tabButton31, "tabButton_DAD_Heading");
            this.tabButton31.Image = null;
            this.tabButton31.Location = new System.Drawing.Point(0, 0);
            this.tabButton31.Name = "tabButton31";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton31, 5);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton31, 0);
            this.tabButton31.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton31, this.paintHelperRect);
            this.tabButton31.Size = new System.Drawing.Size(48, 43);
            this.tabButton31.TabIndex = 9;
            this.tabButton31.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(356, 43);
            this.panel5.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Controls.Add(this.tabHeader_DAD_horiz_Bottom);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabHeader_DAD_horiz_Bottom
            // 
            this.tabHeader_DAD_horiz_Bottom.AllowDrop = true;
            this.tabHeader_DAD_horiz_Bottom.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_DAD_horiz_Bottom.Controls.Add(this.tabButton31);
            this.tabHeader_DAD_horiz_Bottom.Controls.Add(this.tabButton32);
            this.tabHeader_DAD_horiz_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader_DAD_horiz_Bottom, "tabHeader_DAD");
            this.tabHeader_DAD_horiz_Bottom.Interval = 4;
            this.tabHeader_DAD_horiz_Bottom.Location = new System.Drawing.Point(0, 0);
            this.tabHeader_DAD_horiz_Bottom.Multiselect = true;
            this.tabHeader_DAD_horiz_Bottom.Name = "tabHeader_DAD_horiz_Bottom";
            this.tabHeader_DAD_horiz_Bottom.SelectedButton = null;
            this.tabHeader_DAD_horiz_Bottom.Size = new System.Drawing.Size(356, 43);
            this.tabHeader_DAD_horiz_Bottom.SrcollLeftButton = null;
            this.tabHeader_DAD_horiz_Bottom.SrcollRightButton = null;
            this.tabHeader_DAD_horiz_Bottom.TabIndex = 5;
            this.tabHeader_DAD_horiz_Bottom.Vertical = false;
            this.tabHeader_DAD_horiz_Bottom.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader_DAD_horiz_Bottom.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel_DAD_hor_Up);
            this.panel6.Location = new System.Drawing.Point(36, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(360, 204);
            this.panel6.TabIndex = 29;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Aquamarine;
            this.panel7.Controls.Add(this.tabHeader21);
            this.panel7.Controls.Add(this.tabHeader22);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(356, 157);
            this.panel7.TabIndex = 26;
            // 
            // tabHeader21
            // 
            this.tabHeader21.AllowDrop = true;
            this.tabHeader21.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader21.BackgroundImage")));
            this.tabHeader21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader21.Controls.Add(this.tabButton36);
            this.tabHeader21.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabHeader21.HeaderButton = this.tabButton74;
            this.helper.SetHelpText(this.tabHeader21, "tabHeader_DAD_child");
            this.tabHeader21.Interval = 1;
            this.tabHeader21.Location = new System.Drawing.Point(53, 0);
            this.tabHeader21.Multiselect = true;
            this.tabHeader21.Name = "tabHeader21";
            this.tabHeader21.SelectedButton = this.tabButton36;
            this.tabHeader21.Size = new System.Drawing.Size(53, 157);
            this.tabHeader21.SrcollLeftButton = null;
            this.tabHeader21.SrcollRightButton = null;
            this.tabHeader21.TabIndex = 24;
            this.tabHeader21.Vertical = true;
            this.tabHeader21.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader21.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton36
            // 
            this.tabButton36.AllowDrag = true;
            this.tabButton36.AllowDrop = true;
            this.tabButton36.BackColor = System.Drawing.Color.Transparent;
            this.tabButton36.BaseVisible = true;
            this.tabButton36.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton36, 9);
            this.helper.SetHelpText(this.tabButton36, "Buttons_DragAndDrop");
            this.tabButton36.Image = null;
            this.tabButton36.Location = new System.Drawing.Point(0, 0);
            this.tabButton36.Name = "tabButton36";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton36, 15);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton36, 13);
            this.tabButton36.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton36, this.paintHelperEllipse);
            this.tabButton36.Size = new System.Drawing.Size(48, 43);
            this.tabButton36.TabIndex = 8;
            this.tabButton36.TabStop = false;
            // 
            // tabButton74
            // 
            this.tabButton74.AllowDrag = true;
            this.tabButton74.AllowDrop = true;
            this.tabButton74.BackColor = System.Drawing.Color.Transparent;
            this.tabButton74.BaseVisible = true;
            this.tabButton74.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton74, 2);
            this.helper.SetHelpText(this.tabButton74, "tabButton_DAD_Heading");
            this.tabButton74.Image = null;
            this.tabButton74.Location = new System.Drawing.Point(52, 0);
            this.tabButton74.Name = "tabButton74";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton74, 7);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton74, 0);
            this.tabButton74.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton74, this.paintHelperRect);
            this.tabButton74.Size = new System.Drawing.Size(48, 43);
            this.tabButton74.TabIndex = 8;
            this.tabButton74.TabStop = false;
            // 
            // tabHeader22
            // 
            this.tabHeader22.AllowDrop = true;
            this.tabHeader22.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader22.BackgroundImage")));
            this.tabHeader22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader22.Controls.Add(this.tabButton60);
            this.tabHeader22.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabHeader22.HeaderButton = this.tabButton69;
            this.helper.SetHelpText(this.tabHeader22, "tabHeader_DAD_child");
            this.tabHeader22.Interval = 1;
            this.tabHeader22.Location = new System.Drawing.Point(0, 0);
            this.tabHeader22.Multiselect = true;
            this.tabHeader22.Name = "tabHeader22";
            this.tabHeader22.SelectedButton = this.tabButton60;
            this.tabHeader22.Size = new System.Drawing.Size(53, 157);
            this.tabHeader22.SrcollLeftButton = null;
            this.tabHeader22.SrcollRightButton = null;
            this.tabHeader22.TabIndex = 23;
            this.tabHeader22.Vertical = true;
            this.tabHeader22.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader22.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton60
            // 
            this.tabButton60.AllowDrag = true;
            this.tabButton60.AllowDrop = true;
            this.tabButton60.BackColor = System.Drawing.Color.Transparent;
            this.tabButton60.BaseVisible = true;
            this.tabButton60.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton60, 9);
            this.helper.SetHelpText(this.tabButton60, "Buttons_DragAndDrop");
            this.tabButton60.Image = null;
            this.tabButton60.Location = new System.Drawing.Point(0, 0);
            this.tabButton60.Name = "tabButton60";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton60, 15);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton60, 13);
            this.tabButton60.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton60, this.paintHelperEllipse);
            this.tabButton60.Size = new System.Drawing.Size(48, 43);
            this.tabButton60.TabIndex = 8;
            this.tabButton60.TabStop = false;
            // 
            // tabButton69
            // 
            this.tabButton69.AllowDrag = true;
            this.tabButton69.AllowDrop = true;
            this.tabButton69.BackColor = System.Drawing.Color.Transparent;
            this.tabButton69.BaseVisible = true;
            this.tabButton69.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton69, 2);
            this.helper.SetHelpText(this.tabButton69, "tabButton_DAD_Heading");
            this.tabButton69.Image = null;
            this.tabButton69.Location = new System.Drawing.Point(0, 0);
            this.tabButton69.Name = "tabButton69";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton69, 7);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton69, 0);
            this.tabButton69.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton69, this.paintHelperRect);
            this.tabButton69.Size = new System.Drawing.Size(48, 43);
            this.tabButton69.TabIndex = 9;
            this.tabButton69.TabStop = false;
            // 
            // panel_DAD_hor_Up
            // 
            this.panel_DAD_hor_Up.Controls.Add(this.pictureBox2);
            this.panel_DAD_hor_Up.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_DAD_hor_Up.Location = new System.Drawing.Point(0, 157);
            this.panel_DAD_hor_Up.Name = "panel_DAD_hor_Up";
            this.panel_DAD_hor_Up.Size = new System.Drawing.Size(356, 43);
            this.panel_DAD_hor_Up.TabIndex = 25;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Controls.Add(this.tabHeader_DAD_horiz_Up);
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(356, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabHeader_DAD_horiz_Up
            // 
            this.tabHeader_DAD_horiz_Up.AllowDrop = true;
            this.tabHeader_DAD_horiz_Up.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_DAD_horiz_Up.Controls.Add(this.tabButton69);
            this.tabHeader_DAD_horiz_Up.Controls.Add(this.tabButton74);
            this.tabHeader_DAD_horiz_Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader_DAD_horiz_Up, "tabHeader_DAD");
            this.tabHeader_DAD_horiz_Up.Interval = 4;
            this.tabHeader_DAD_horiz_Up.Location = new System.Drawing.Point(0, 0);
            this.tabHeader_DAD_horiz_Up.Multiselect = true;
            this.tabHeader_DAD_horiz_Up.Name = "tabHeader_DAD_horiz_Up";
            this.tabHeader_DAD_horiz_Up.SelectedButton = null;
            this.tabHeader_DAD_horiz_Up.Size = new System.Drawing.Size(356, 43);
            this.tabHeader_DAD_horiz_Up.SrcollLeftButton = null;
            this.tabHeader_DAD_horiz_Up.SrcollRightButton = null;
            this.tabHeader_DAD_horiz_Up.TabIndex = 5;
            this.tabHeader_DAD_horiz_Up.Vertical = false;
            this.tabHeader_DAD_horiz_Up.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader_DAD_horiz_Up.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel_DAD_vert_Left2);
            this.panel4.Controls.Add(this.panel_DAD_vert_Left);
            this.panel4.Location = new System.Drawing.Point(432, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 538);
            this.panel4.TabIndex = 28;
            // 
            // panel_DAD_vert_Left2
            // 
            this.panel_DAD_vert_Left2.BackColor = System.Drawing.Color.Aquamarine;
            this.panel_DAD_vert_Left2.Controls.Add(this.tabHeader14);
            this.panel_DAD_vert_Left2.Controls.Add(this.tabHeader13);
            this.panel_DAD_vert_Left2.Controls.Add(this.tabHeader10);
            this.panel_DAD_vert_Left2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DAD_vert_Left2.Location = new System.Drawing.Point(0, 0);
            this.panel_DAD_vert_Left2.Name = "panel_DAD_vert_Left2";
            this.panel_DAD_vert_Left2.Size = new System.Drawing.Size(200, 534);
            this.panel_DAD_vert_Left2.TabIndex = 24;
            // 
            // tabHeader14
            // 
            this.tabHeader14.AllowDrop = true;
            this.tabHeader14.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader14.BackgroundImage")));
            this.tabHeader14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader14.Controls.Add(this.tabButton61);
            this.tabHeader14.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader14.HeaderButton = this.tabButton4;
            this.helper.SetHelpText(this.tabHeader14, "tabHeader_DAD_child");
            this.tabHeader14.Interval = 1;
            this.tabHeader14.Location = new System.Drawing.Point(0, 95);
            this.tabHeader14.Multiselect = true;
            this.tabHeader14.Name = "tabHeader14";
            this.tabHeader14.SelectedButton = this.tabButton61;
            this.tabHeader14.Size = new System.Drawing.Size(200, 47);
            this.tabHeader14.SrcollLeftButton = null;
            this.tabHeader14.SrcollRightButton = null;
            this.tabHeader14.TabIndex = 24;
            this.tabHeader14.Vertical = false;
            this.tabHeader14.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader14.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton61
            // 
            this.tabButton61.AllowDrag = true;
            this.tabButton61.AllowDrop = true;
            this.tabButton61.BaseVisible = true;
            this.tabButton61.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton61, 10);
            this.helper.SetHelpText(this.tabButton61, "Buttons_DragAndDrop");
            this.tabButton61.Image = null;
            this.tabButton61.Location = new System.Drawing.Point(0, 0);
            this.tabButton61.Name = "tabButton61";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton61, 11);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton61, 14);
            this.tabButton61.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton61, this.paintHelperRhomd);
            this.tabButton61.Size = new System.Drawing.Size(48, 43);
            this.tabButton61.TabIndex = 9;
            this.tabButton61.TabStop = false;
            // 
            // tabButton4
            // 
            this.tabButton4.AllowDrag = true;
            this.tabButton4.AllowDrop = true;
            this.tabButton4.BaseVisible = true;
            this.tabButton4.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton4, 2);
            this.helper.SetHelpText(this.tabButton4, "tabButton_DAD_Heading");
            this.tabButton4.Image = null;
            this.tabButton4.Location = new System.Drawing.Point(0, 94);
            this.tabButton4.Name = "tabButton4";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton4, 3);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton4, 0);
            this.tabButton4.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton4, this.paintHelperRect2);
            this.tabButton4.Size = new System.Drawing.Size(48, 43);
            this.tabButton4.TabIndex = 7;
            this.tabButton4.TabStop = false;
            // 
            // tabHeader13
            // 
            this.tabHeader13.AllowDrop = true;
            this.tabHeader13.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader13.BackgroundImage")));
            this.tabHeader13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader13.Controls.Add(this.tabButton44);
            this.tabHeader13.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader13.HeaderButton = this.tabButton3;
            this.helper.SetHelpText(this.tabHeader13, "tabHeader_DAD_child");
            this.tabHeader13.Interval = 1;
            this.tabHeader13.Location = new System.Drawing.Point(0, 47);
            this.tabHeader13.Multiselect = true;
            this.tabHeader13.Name = "tabHeader13";
            this.tabHeader13.SelectedButton = this.tabButton44;
            this.tabHeader13.Size = new System.Drawing.Size(200, 48);
            this.tabHeader13.SrcollLeftButton = null;
            this.tabHeader13.SrcollRightButton = null;
            this.tabHeader13.TabIndex = 23;
            this.tabHeader13.Vertical = false;
            this.tabHeader13.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader13.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton44
            // 
            this.tabButton44.AllowDrag = true;
            this.tabButton44.AllowDrop = true;
            this.tabButton44.BackColor = System.Drawing.Color.Transparent;
            this.tabButton44.BaseVisible = true;
            this.tabButton44.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton44, 10);
            this.helper.SetHelpText(this.tabButton44, "Buttons_DragAndDrop");
            this.tabButton44.Image = null;
            this.tabButton44.Location = new System.Drawing.Point(0, 0);
            this.tabButton44.Name = "tabButton44";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton44, 11);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton44, 14);
            this.tabButton44.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton44, this.paintHelperRhomd);
            this.tabButton44.Size = new System.Drawing.Size(48, 43);
            this.tabButton44.TabIndex = 9;
            this.tabButton44.TabStop = false;
            // 
            // tabButton3
            // 
            this.tabButton3.AllowDrag = true;
            this.tabButton3.AllowDrop = true;
            this.tabButton3.BaseVisible = true;
            this.tabButton3.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton3, 2);
            this.helper.SetHelpText(this.tabButton3, "tabButton_DAD_Heading");
            this.tabButton3.Image = null;
            this.tabButton3.Location = new System.Drawing.Point(0, 47);
            this.tabButton3.Name = "tabButton3";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton3, 3);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton3, 0);
            this.tabButton3.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton3, this.paintHelperRect2);
            this.tabButton3.Size = new System.Drawing.Size(48, 43);
            this.tabButton3.TabIndex = 8;
            this.tabButton3.TabStop = false;
            // 
            // tabHeader10
            // 
            this.tabHeader10.AllowDrop = true;
            this.tabHeader10.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader10.BackgroundImage")));
            this.tabHeader10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader10.Controls.Add(this.tabButton62);
            this.tabHeader10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader10.ForeColor = System.Drawing.Color.Black;
            this.tabHeader10.HeaderButton = this.tabButton2;
            this.helper.SetHelpText(this.tabHeader10, "tabHeader_DAD_child");
            this.tabHeader10.Interval = 1;
            this.tabHeader10.Location = new System.Drawing.Point(0, 0);
            this.tabHeader10.Multiselect = true;
            this.tabHeader10.Name = "tabHeader10";
            this.tabHeader10.SelectedButton = this.tabButton62;
            this.tabHeader10.Size = new System.Drawing.Size(200, 47);
            this.tabHeader10.SrcollLeftButton = null;
            this.tabHeader10.SrcollRightButton = null;
            this.tabHeader10.TabIndex = 22;
            this.tabHeader10.Vertical = false;
            this.tabHeader10.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader10.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton62
            // 
            this.tabButton62.AllowDrag = true;
            this.tabButton62.AllowDrop = true;
            this.tabButton62.BackColor = System.Drawing.Color.Transparent;
            this.tabButton62.BaseVisible = true;
            this.tabButton62.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton62, 10);
            this.tabButton62.ForeColor = System.Drawing.Color.Black;
            this.helper.SetHelpText(this.tabButton62, "Buttons_DragAndDrop");
            this.tabButton62.Image = null;
            this.tabButton62.Location = new System.Drawing.Point(0, 0);
            this.tabButton62.Name = "tabButton62";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton62, 11);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton62, 14);
            this.tabButton62.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton62, this.paintHelperRhomd);
            this.tabButton62.Size = new System.Drawing.Size(48, 43);
            this.tabButton62.TabIndex = 9;
            this.tabButton62.TabStop = false;
            // 
            // tabButton2
            // 
            this.tabButton2.AllowDrag = true;
            this.tabButton2.AllowDrop = true;
            this.tabButton2.BaseVisible = true;
            this.tabButton2.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton2, 2);
            this.helper.SetHelpText(this.tabButton2, "tabButton_DAD_Heading");
            this.tabButton2.Image = null;
            this.tabButton2.Location = new System.Drawing.Point(0, 0);
            this.tabButton2.Name = "tabButton2";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton2, 3);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton2, 0);
            this.tabButton2.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton2, this.paintHelperRect2);
            this.tabButton2.Size = new System.Drawing.Size(48, 43);
            this.tabButton2.TabIndex = 9;
            this.tabButton2.TabStop = false;
            // 
            // panel_DAD_vert_Left
            // 
            this.panel_DAD_vert_Left.Controls.Add(this.pictureBox_DAD_vert_Left);
            this.panel_DAD_vert_Left.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_DAD_vert_Left.Location = new System.Drawing.Point(200, 0);
            this.panel_DAD_vert_Left.Name = "panel_DAD_vert_Left";
            this.panel_DAD_vert_Left.Size = new System.Drawing.Size(48, 534);
            this.panel_DAD_vert_Left.TabIndex = 23;
            // 
            // pictureBox_DAD_vert_Left
            // 
            this.pictureBox_DAD_vert_Left.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_DAD_vert_Left.Controls.Add(this.tabHeader_DAD_vert_Left);
            this.pictureBox_DAD_vert_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_DAD_vert_Left.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DAD_vert_Left.Image")));
            this.pictureBox_DAD_vert_Left.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_DAD_vert_Left.Name = "pictureBox_DAD_vert_Left";
            this.pictureBox_DAD_vert_Left.Size = new System.Drawing.Size(48, 534);
            this.pictureBox_DAD_vert_Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DAD_vert_Left.TabIndex = 0;
            this.pictureBox_DAD_vert_Left.TabStop = false;
            // 
            // tabHeader_DAD_vert_Left
            // 
            this.tabHeader_DAD_vert_Left.AllowDrop = true;
            this.tabHeader_DAD_vert_Left.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_DAD_vert_Left.Controls.Add(this.tabButton2);
            this.tabHeader_DAD_vert_Left.Controls.Add(this.tabButton3);
            this.tabHeader_DAD_vert_Left.Controls.Add(this.tabButton4);
            this.tabHeader_DAD_vert_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader_DAD_vert_Left, "tabHeader_DAD");
            this.tabHeader_DAD_vert_Left.Interval = 4;
            this.tabHeader_DAD_vert_Left.Location = new System.Drawing.Point(0, 0);
            this.tabHeader_DAD_vert_Left.Multiselect = true;
            this.tabHeader_DAD_vert_Left.Name = "tabHeader_DAD_vert_Left";
            this.tabHeader_DAD_vert_Left.SelectedButton = null;
            this.tabHeader_DAD_vert_Left.Size = new System.Drawing.Size(48, 534);
            this.tabHeader_DAD_vert_Left.SrcollLeftButton = null;
            this.tabHeader_DAD_vert_Left.SrcollRightButton = null;
            this.tabHeader_DAD_vert_Left.TabIndex = 5;
            this.tabHeader_DAD_vert_Left.Vertical = true;
            this.tabHeader_DAD_vert_Left.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader_DAD_vert_Left.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel_DAD_vert_Right2);
            this.panel1.Controls.Add(this.panel_DAD_vert_Right);
            this.panel1.Location = new System.Drawing.Point(686, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 538);
            this.panel1.TabIndex = 27;
            // 
            // panel_DAD_vert_Right2
            // 
            this.panel_DAD_vert_Right2.BackColor = System.Drawing.Color.Aquamarine;
            this.panel_DAD_vert_Right2.Controls.Add(this.tabHeader19);
            this.panel_DAD_vert_Right2.Controls.Add(this.tabHeader16);
            this.panel_DAD_vert_Right2.Controls.Add(this.tabHeader15);
            this.panel_DAD_vert_Right2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DAD_vert_Right2.Location = new System.Drawing.Point(48, 0);
            this.panel_DAD_vert_Right2.Name = "panel_DAD_vert_Right2";
            this.panel_DAD_vert_Right2.Size = new System.Drawing.Size(200, 534);
            this.panel_DAD_vert_Right2.TabIndex = 26;
            // 
            // tabHeader19
            // 
            this.tabHeader19.AllowDrop = true;
            this.tabHeader19.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader19.BackgroundImage")));
            this.tabHeader19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader19.Controls.Add(this.tabButton28);
            this.tabHeader19.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader19.HeaderButton = this.tabButton27;
            this.helper.SetHelpText(this.tabHeader19, "tabHeader_DAD_child");
            this.tabHeader19.Interval = 1;
            this.tabHeader19.Location = new System.Drawing.Point(0, 95);
            this.tabHeader19.Multiselect = true;
            this.tabHeader19.Name = "tabHeader19";
            this.tabHeader19.SelectedButton = this.tabButton28;
            this.tabHeader19.Size = new System.Drawing.Size(200, 47);
            this.tabHeader19.SrcollLeftButton = null;
            this.tabHeader19.SrcollRightButton = null;
            this.tabHeader19.TabIndex = 25;
            this.tabHeader19.Vertical = false;
            this.tabHeader19.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader19.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton28
            // 
            this.tabButton28.AllowDrag = true;
            this.tabButton28.AllowDrop = true;
            this.tabButton28.BaseVisible = true;
            this.tabButton28.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton28, 9);
            this.helper.SetHelpText(this.tabButton28, "Buttons_DragAndDrop");
            this.tabButton28.Image = null;
            this.tabButton28.Location = new System.Drawing.Point(0, 0);
            this.tabButton28.Name = "tabButton28";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton28, 12);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton28, 13);
            this.tabButton28.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton28, this.paintHelperRhomd);
            this.tabButton28.Size = new System.Drawing.Size(48, 43);
            this.tabButton28.TabIndex = 8;
            this.tabButton28.TabStop = false;
            // 
            // tabButton27
            // 
            this.tabButton27.AllowDrag = true;
            this.tabButton27.AllowDrop = true;
            this.tabButton27.BaseVisible = true;
            this.tabButton27.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton27, 2);
            this.helper.SetHelpText(this.tabButton27, "tabButton_DAD_Heading");
            this.tabButton27.Image = null;
            this.tabButton27.Location = new System.Drawing.Point(0, 94);
            this.tabButton27.Name = "tabButton27";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton27, 4);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton27, 0);
            this.tabButton27.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton27, this.paintHelperRect);
            this.tabButton27.Size = new System.Drawing.Size(48, 43);
            this.tabButton27.TabIndex = 7;
            this.tabButton27.TabStop = false;
            // 
            // tabHeader16
            // 
            this.tabHeader16.AllowDrop = true;
            this.tabHeader16.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader16.BackgroundImage")));
            this.tabHeader16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader16.Controls.Add(this.tabButton82);
            this.tabHeader16.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader16.HeaderButton = this.tabButton26;
            this.helper.SetHelpText(this.tabHeader16, "tabHeader_DAD_child");
            this.tabHeader16.Interval = 1;
            this.tabHeader16.Location = new System.Drawing.Point(0, 47);
            this.tabHeader16.Multiselect = true;
            this.tabHeader16.Name = "tabHeader16";
            this.tabHeader16.SelectedButton = this.tabButton82;
            this.tabHeader16.Size = new System.Drawing.Size(200, 48);
            this.tabHeader16.SrcollLeftButton = null;
            this.tabHeader16.SrcollRightButton = null;
            this.tabHeader16.TabIndex = 24;
            this.tabHeader16.Vertical = false;
            this.tabHeader16.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader16.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton82
            // 
            this.tabButton82.AllowDrag = true;
            this.tabButton82.AllowDrop = true;
            this.tabButton82.BaseVisible = true;
            this.tabButton82.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton82, 9);
            this.helper.SetHelpText(this.tabButton82, "Buttons_DragAndDrop");
            this.tabButton82.Image = null;
            this.tabButton82.Location = new System.Drawing.Point(0, 0);
            this.tabButton82.Name = "tabButton82";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton82, 12);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton82, 13);
            this.tabButton82.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton82, this.paintHelperRhomd);
            this.tabButton82.Size = new System.Drawing.Size(48, 43);
            this.tabButton82.TabIndex = 8;
            this.tabButton82.TabStop = false;
            // 
            // tabButton26
            // 
            this.tabButton26.AllowDrag = true;
            this.tabButton26.AllowDrop = true;
            this.tabButton26.BaseVisible = true;
            this.tabButton26.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton26, 2);
            this.helper.SetHelpText(this.tabButton26, "tabButton_DAD_Heading");
            this.tabButton26.Image = null;
            this.tabButton26.Location = new System.Drawing.Point(0, 47);
            this.tabButton26.Name = "tabButton26";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton26, 4);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton26, 0);
            this.tabButton26.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton26, this.paintHelperRect);
            this.tabButton26.Size = new System.Drawing.Size(48, 43);
            this.tabButton26.TabIndex = 8;
            this.tabButton26.TabStop = false;
            // 
            // tabHeader15
            // 
            this.tabHeader15.AllowDrop = true;
            this.tabHeader15.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabHeader15.BackgroundImage")));
            this.tabHeader15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader15.Controls.Add(this.tabButton75);
            this.tabHeader15.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader15.HeaderButton = this.tabButton14;
            this.helper.SetHelpText(this.tabHeader15, "tabHeader_DAD_child");
            this.tabHeader15.Interval = 1;
            this.tabHeader15.Location = new System.Drawing.Point(0, 0);
            this.tabHeader15.Multiselect = true;
            this.tabHeader15.Name = "tabHeader15";
            this.tabHeader15.SelectedButton = this.tabButton75;
            this.tabHeader15.Size = new System.Drawing.Size(200, 47);
            this.tabHeader15.SrcollLeftButton = null;
            this.tabHeader15.SrcollRightButton = null;
            this.tabHeader15.TabIndex = 23;
            this.tabHeader15.Vertical = false;
            this.tabHeader15.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader15.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton75
            // 
            this.tabButton75.AllowDrag = true;
            this.tabButton75.AllowDrop = true;
            this.tabButton75.BaseVisible = true;
            this.tabButton75.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton75, 9);
            this.helper.SetHelpText(this.tabButton75, "Buttons_DragAndDrop");
            this.tabButton75.Image = null;
            this.tabButton75.Location = new System.Drawing.Point(0, 0);
            this.tabButton75.Name = "tabButton75";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton75, 12);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton75, 13);
            this.tabButton75.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton75, this.paintHelperRhomd);
            this.tabButton75.Size = new System.Drawing.Size(48, 43);
            this.tabButton75.TabIndex = 8;
            this.tabButton75.TabStop = false;
            // 
            // tabButton14
            // 
            this.tabButton14.AllowDrag = true;
            this.tabButton14.AllowDrop = true;
            this.tabButton14.BaseVisible = true;
            this.tabButton14.Checked = true;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton14, 2);
            this.helper.SetHelpText(this.tabButton14, "tabButton_DAD_Heading");
            this.tabButton14.Image = null;
            this.tabButton14.Location = new System.Drawing.Point(0, 0);
            this.tabButton14.Name = "tabButton14";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton14, 4);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButton14, 0);
            this.tabButton14.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton14, this.paintHelperRect);
            this.tabButton14.Size = new System.Drawing.Size(48, 43);
            this.tabButton14.TabIndex = 9;
            this.tabButton14.TabStop = false;
            // 
            // panel_DAD_vert_Right
            // 
            this.panel_DAD_vert_Right.Controls.Add(this.pictureBox_DAD_vert_Right);
            this.panel_DAD_vert_Right.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_DAD_vert_Right.Location = new System.Drawing.Point(0, 0);
            this.panel_DAD_vert_Right.Name = "panel_DAD_vert_Right";
            this.panel_DAD_vert_Right.Size = new System.Drawing.Size(48, 534);
            this.panel_DAD_vert_Right.TabIndex = 25;
            // 
            // pictureBox_DAD_vert_Right
            // 
            this.pictureBox_DAD_vert_Right.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_DAD_vert_Right.Controls.Add(this.tabHeader_DAD_vert_Right);
            this.pictureBox_DAD_vert_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_DAD_vert_Right.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DAD_vert_Right.Image")));
            this.pictureBox_DAD_vert_Right.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_DAD_vert_Right.Name = "pictureBox_DAD_vert_Right";
            this.pictureBox_DAD_vert_Right.Size = new System.Drawing.Size(48, 534);
            this.pictureBox_DAD_vert_Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DAD_vert_Right.TabIndex = 0;
            this.pictureBox_DAD_vert_Right.TabStop = false;
            // 
            // tabHeader_DAD_vert_Right
            // 
            this.tabHeader_DAD_vert_Right.AllowDrop = true;
            this.tabHeader_DAD_vert_Right.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_DAD_vert_Right.Controls.Add(this.tabButton14);
            this.tabHeader_DAD_vert_Right.Controls.Add(this.tabButton26);
            this.tabHeader_DAD_vert_Right.Controls.Add(this.tabButton27);
            this.tabHeader_DAD_vert_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader_DAD_vert_Right, "tabHeader_DAD");
            this.tabHeader_DAD_vert_Right.Interval = 4;
            this.tabHeader_DAD_vert_Right.Location = new System.Drawing.Point(0, 0);
            this.tabHeader_DAD_vert_Right.Multiselect = true;
            this.tabHeader_DAD_vert_Right.Name = "tabHeader_DAD_vert_Right";
            this.tabHeader_DAD_vert_Right.SelectedButton = null;
            this.tabHeader_DAD_vert_Right.Size = new System.Drawing.Size(48, 534);
            this.tabHeader_DAD_vert_Right.SrcollLeftButton = null;
            this.tabHeader_DAD_vert_Right.SrcollRightButton = null;
            this.tabHeader_DAD_vert_Right.TabIndex = 5;
            this.tabHeader_DAD_vert_Right.Vertical = true;
            this.tabHeader_DAD_vert_Right.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader_DAD_vert_Right.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabPageL3
            // 
            this.tabPageL3.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageL3.Controls.Add(this.linkLabel2);
            this.tabPageL3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageL3.HeaderButton = this.tabButtonL3;
            this.helper.SetHelpText(this.tabPageL3, "TabPages_Example");
            this.tabPageL3.Location = new System.Drawing.Point(0, 0);
            this.tabPageL3.Name = "tabPageL3";
            this.tabPageL3.Size = new System.Drawing.Size(394, 523);
            this.tabPageL3.TabIndex = 7;
            this.tabPageL3.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkLabel2.Location = new System.Drawing.Point(115, 233);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(144, 24);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "support@eboris.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabPage_TabControl
            // 
            this.tabPage_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(230)))), ((int)(((byte)(70)))));
            this.tabPage_TabControl.Controls.Add(this.tabHeader17);
            this.tabPage_TabControl.Controls.Add(this.tabHeader12);
            this.tabPage_TabControl.Controls.Add(this.tabHeader6);
            this.tabPage_TabControl.Controls.Add(this.tabHeader7);
            this.tabPage_TabControl.Controls.Add(this.tabPage22);
            this.tabPage_TabControl.Controls.Add(this.tabPage3);
            this.tabPage_TabControl.Controls.Add(this.tabPage11);
            this.tabPage_TabControl.Controls.Add(this.tabPage17);
            this.tabPage_TabControl.Controls.Add(this.tabPage18);
            this.tabPage_TabControl.Controls.Add(this.tabPage21);
            this.tabPage_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_TabControl.HeaderButton = this.tabButton_TabControl;
            this.helper.SetHelpText(this.tabPage_TabControl, "tabPage_TabControl");
            this.tabPage_TabControl.Location = new System.Drawing.Point(0, 53);
            this.tabPage_TabControl.Name = "tabPage_TabControl";
            this.tabPage_TabControl.Size = new System.Drawing.Size(812, 566);
            this.tabPage_TabControl.TabIndex = 8;
            this.tabPage_TabControl.Visible = false;
            // 
            // tabHeader17
            // 
            this.tabHeader17.AllowDrop = true;
            this.tabHeader17.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabHeader17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader17.Controls.Add(this.tabButton105);
            this.tabHeader17.Controls.Add(this.tabButton106);
            this.tabHeader17.HeaderButton = this.tabButton_oval4;
            this.helper.SetHelpText(this.tabHeader17, "TabHeader_BottomHorizontally");
            this.tabHeader17.Location = new System.Drawing.Point(667, 302);
            this.tabHeader17.Multiselect = true;
            this.tabHeader17.Name = "tabHeader17";
            this.tabHeader17.SelectedButton = this.tabButton105;
            this.tabHeader17.Size = new System.Drawing.Size(240, 43);
            this.tabHeader17.SrcollLeftButton = null;
            this.tabHeader17.SrcollRightButton = null;
            this.tabHeader17.TabIndex = 28;
            this.tabHeader17.Vertical = false;
            this.tabHeader17.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader17.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton105
            // 
            this.tabButton105.AllowDrag = true;
            this.tabButton105.AllowDrop = true;
            this.tabButton105.BaseVisible = true;
            this.tabButton105.Checked = true;
            this.tabButton105.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.CheckedEnterImage")));
            this.tabButton105.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.CheckedLeaveImage")));
            this.tabButton105.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton105, "TabButton_BottomHorizontally");
            this.tabButton105.Image = ((System.Drawing.Image)(resources.GetObject("tabButton105.Image")));
            this.tabButton105.Location = new System.Drawing.Point(0, 0);
            this.tabButton105.Name = "tabButton105";
            this.tabButton105.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.NormalEnterImage")));
            this.tabButton105.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.NormalLeaveImage")));
            this.tabButton105.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton105.NormalPressImage")));
            this.tabButton105.Size = new System.Drawing.Size(96, 34);
            this.tabButton105.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton105.TabIndex = 2;
            this.tabButton105.TabStop = false;
            this.tabButton105.Text = "HB";
            this.tabButton105.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton106
            // 
            this.tabButton106.AllowDrag = true;
            this.tabButton106.AllowDrop = true;
            this.tabButton106.BaseVisible = true;
            this.tabButton106.Checked = false;
            this.tabButton106.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.CheckedEnterImage")));
            this.tabButton106.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.CheckedLeaveImage")));
            this.tabButton106.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton106, "TabButton_BottomHorizontally");
            this.tabButton106.Image = ((System.Drawing.Image)(resources.GetObject("tabButton106.Image")));
            this.tabButton106.Location = new System.Drawing.Point(96, 0);
            this.tabButton106.Name = "tabButton106";
            this.tabButton106.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.NormalEnterImage")));
            this.tabButton106.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.NormalLeaveImage")));
            this.tabButton106.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton106.NormalPressImage")));
            this.tabButton106.Size = new System.Drawing.Size(96, 34);
            this.tabButton106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton106.TabIndex = 1;
            this.tabButton106.TabStop = false;
            this.tabButton106.Text = "HB";
            this.tabButton106.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabHeader12
            // 
            this.tabHeader12.AllowDrop = true;
            this.tabHeader12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabHeader12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader12.Controls.Add(this.tabButton66);
            this.tabHeader12.Controls.Add(this.tabButton67);
            this.tabHeader12.HeaderButton = this.tabButton24;
            this.helper.SetHelpText(this.tabHeader12, "TabHeader_RightVertical");
            this.tabHeader12.Interval = 5;
            this.tabHeader12.Location = new System.Drawing.Point(502, 181);
            this.tabHeader12.Multiselect = true;
            this.tabHeader12.Name = "tabHeader12";
            this.tabHeader12.SelectedButton = this.tabButton66;
            this.tabHeader12.Size = new System.Drawing.Size(105, 164);
            this.tabHeader12.SrcollLeftButton = null;
            this.tabHeader12.SrcollRightButton = null;
            this.tabHeader12.TabIndex = 24;
            this.tabHeader12.Vertical = true;
            this.tabHeader12.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader12.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton66
            // 
            this.tabButton66.AllowDrag = true;
            this.tabButton66.AllowDrop = true;
            this.tabButton66.BaseVisible = true;
            this.tabButton66.Checked = true;
            this.tabButton66.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.CheckedEnterImage")));
            this.tabButton66.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.CheckedLeaveImage")));
            this.tabButton66.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton66, "TabButton_RightVertical");
            this.tabButton66.Image = ((System.Drawing.Image)(resources.GetObject("tabButton66.Image")));
            this.tabButton66.Location = new System.Drawing.Point(0, 0);
            this.tabButton66.Name = "tabButton66";
            this.tabButton66.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.NormalEnterImage")));
            this.tabButton66.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.NormalLeaveImage")));
            this.tabButton66.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton66.NormalPressImage")));
            this.tabButton66.Size = new System.Drawing.Size(96, 34);
            this.tabButton66.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton66.TabIndex = 2;
            this.tabButton66.TabStop = false;
            this.tabButton66.Text = "VR";
            this.tabButton66.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton67
            // 
            this.tabButton67.AllowDrag = true;
            this.tabButton67.AllowDrop = true;
            this.tabButton67.BaseVisible = true;
            this.tabButton67.Checked = false;
            this.tabButton67.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.CheckedEnterImage")));
            this.tabButton67.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.CheckedLeaveImage")));
            this.tabButton67.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton67, "TabButton_RightVertical");
            this.tabButton67.Image = ((System.Drawing.Image)(resources.GetObject("tabButton67.Image")));
            this.tabButton67.Location = new System.Drawing.Point(0, 39);
            this.tabButton67.Name = "tabButton67";
            this.tabButton67.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.NormalEnterImage")));
            this.tabButton67.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.NormalLeaveImage")));
            this.tabButton67.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton67.NormalPressImage")));
            this.tabButton67.Size = new System.Drawing.Size(96, 34);
            this.tabButton67.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton67.TabIndex = 1;
            this.tabButton67.TabStop = false;
            this.tabButton67.Text = "VR";
            this.tabButton67.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabHeader6
            // 
            this.tabHeader6.AllowDrop = true;
            this.tabHeader6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabHeader6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabHeader6.Controls.Add(this.tabButton20);
            this.tabHeader6.Controls.Add(this.tabButton21);
            this.tabHeader6.HeaderButton = this.tabButton_oval3;
            this.helper.SetHelpText(this.tabHeader6, "TabHeader_LeftVertical");
            this.tabHeader6.Interval = 5;
            this.tabHeader6.Location = new System.Drawing.Point(67, 181);
            this.tabHeader6.Multiselect = true;
            this.tabHeader6.Name = "tabHeader6";
            this.tabHeader6.SelectedButton = this.tabButton20;
            this.tabHeader6.Size = new System.Drawing.Size(106, 164);
            this.tabHeader6.SrcollLeftButton = null;
            this.tabHeader6.SrcollRightButton = null;
            this.tabHeader6.TabIndex = 2;
            this.tabHeader6.Vertical = true;
            this.tabHeader6.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader6.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton20
            // 
            this.tabButton20.AllowDrag = true;
            this.tabButton20.AllowDrop = true;
            this.tabButton20.BaseVisible = true;
            this.tabButton20.Checked = true;
            this.tabButton20.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.CheckedEnterImage")));
            this.tabButton20.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.CheckedLeaveImage")));
            this.tabButton20.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton20, "TabButton_LeftVertical");
            this.tabButton20.Image = ((System.Drawing.Image)(resources.GetObject("tabButton20.Image")));
            this.tabButton20.Location = new System.Drawing.Point(0, 0);
            this.tabButton20.Name = "tabButton20";
            this.tabButton20.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.NormalEnterImage")));
            this.tabButton20.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.NormalLeaveImage")));
            this.tabButton20.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton20.NormalPressImage")));
            this.tabButton20.Size = new System.Drawing.Size(96, 34);
            this.tabButton20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton20.TabIndex = 2;
            this.tabButton20.TabStop = false;
            this.tabButton20.Text = "VL";
            this.tabButton20.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabButton21
            // 
            this.tabButton21.AllowDrag = true;
            this.tabButton21.AllowDrop = true;
            this.tabButton21.BaseVisible = true;
            this.tabButton21.Checked = false;
            this.tabButton21.CheckedEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.CheckedEnterImage")));
            this.tabButton21.CheckedLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.CheckedLeaveImage")));
            this.tabButton21.CheckedPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.CheckedPressImage")));
            this.helper.SetHelpText(this.tabButton21, "TabButton_LeftVertical");
            this.tabButton21.Image = ((System.Drawing.Image)(resources.GetObject("tabButton21.Image")));
            this.tabButton21.Location = new System.Drawing.Point(0, 39);
            this.tabButton21.Name = "tabButton21";
            this.tabButton21.NormalEnterImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.NormalEnterImage")));
            this.tabButton21.NormalLeaveImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.NormalLeaveImage")));
            this.tabButton21.NormalPressImage = ((System.Drawing.Image)(resources.GetObject("tabButton21.NormalPressImage")));
            this.tabButton21.Size = new System.Drawing.Size(96, 34);
            this.tabButton21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabButton21.TabIndex = 1;
            this.tabButton21.TabStop = false;
            this.tabButton21.Text = "VL";
            this.tabButton21.Paint += new System.Windows.Forms.PaintEventHandler(this.tabButton_8_Paint_);
            // 
            // tabHeader7
            // 
            this.tabHeader7.AllowDrop = true;
            this.tabHeader7.BackColor = System.Drawing.Color.PowderBlue;
            this.tabHeader7.Controls.Add(this.tabButton_oval3);
            this.tabHeader7.Controls.Add(this.tabButton24);
            this.tabHeader7.Controls.Add(this.tabButton_oval4);
            this.helper.SetHelpText(this.tabHeader7, "TabHeader_TopHorizontally");
            this.tabHeader7.Interval = 80;
            this.tabHeader7.Location = new System.Drawing.Point(67, 60);
            this.tabHeader7.Multiselect = true;
            this.tabHeader7.Name = "tabHeader7";
            this.tabHeader7.SelectedButton = null;
            this.tabHeader7.Size = new System.Drawing.Size(840, 35);
            this.tabHeader7.SrcollLeftButton = null;
            this.tabHeader7.SrcollRightButton = null;
            this.tabHeader7.TabIndex = 1;
            this.tabHeader7.Vertical = false;
            // 
            // tabPage22
            // 
            this.tabPage22.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage22.HeaderButton = this.tabButton106;
            this.helper.SetHelpText(this.tabPage22, "TabPage_");
            this.tabPage22.Location = new System.Drawing.Point(667, 181);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Size = new System.Drawing.Size(240, 121);
            this.tabPage22.TabIndex = 29;
            this.tabPage22.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SpringGreen;
            this.tabPage3.HeaderButton = this.tabButton21;
            this.helper.SetHelpText(this.tabPage3, "TabPage_");
            this.tabPage3.Location = new System.Drawing.Point(173, 181);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(134, 164);
            this.tabPage3.TabIndex = 21;
            this.tabPage3.Visible = false;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.Aquamarine;
            this.tabPage11.HeaderButton = this.tabButton20;
            this.helper.SetHelpText(this.tabPage11, "TabPage_");
            this.tabPage11.Location = new System.Drawing.Point(173, 181);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(134, 164);
            this.tabPage11.TabIndex = 22;
            // 
            // tabPage17
            // 
            this.tabPage17.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage17.HeaderButton = this.tabButton66;
            this.helper.SetHelpText(this.tabPage17, "TabPage_");
            this.tabPage17.Location = new System.Drawing.Point(367, 181);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Size = new System.Drawing.Size(135, 164);
            this.tabPage17.TabIndex = 27;
            // 
            // tabPage18
            // 
            this.tabPage18.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage18.HeaderButton = this.tabButton67;
            this.helper.SetHelpText(this.tabPage18, "TabPage_");
            this.tabPage18.Location = new System.Drawing.Point(367, 181);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Size = new System.Drawing.Size(135, 164);
            this.tabPage18.TabIndex = 26;
            this.tabPage18.Visible = false;
            // 
            // tabPage21
            // 
            this.tabPage21.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage21.HeaderButton = this.tabButton105;
            this.helper.SetHelpText(this.tabPage21, "TabPage_");
            this.tabPage21.Location = new System.Drawing.Point(667, 181);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Size = new System.Drawing.Size(240, 121);
            this.tabPage21.TabIndex = 30;
            // 
            // tabHeader_Horizontal_ToolBar
            // 
            this.tabHeader_Horizontal_ToolBar.AllowDrop = true;
            this.tabHeader_Horizontal_ToolBar.BackColor = System.Drawing.Color.Transparent;
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.tabButton_email);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.tabButton7);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.tabButtonEBoris);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.tabButton1_TabHeader);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.tabButton_TrackBar);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.imageButton1_Left);
            this.tabHeader_Horizontal_ToolBar.Controls.Add(this.imageButton1_Right);
            this.tabHeader_Horizontal_ToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper.SetHelpText(this.tabHeader_Horizontal_ToolBar, "tabHeader_Horizontal_ToolBar");
            this.tabHeader_Horizontal_ToolBar.Interval = 1;
            this.tabHeader_Horizontal_ToolBar.Location = new System.Drawing.Point(0, 0);
            this.tabHeader_Horizontal_ToolBar.Multiselect = true;
            this.tabHeader_Horizontal_ToolBar.Name = "tabHeader_Horizontal_ToolBar";
            this.tabHeader_Horizontal_ToolBar.SelectedButton = null;
            this.tabHeader_Horizontal_ToolBar.Size = new System.Drawing.Size(812, 43);
            this.tabHeader_Horizontal_ToolBar.SrcollLeftButton = this.imageButton1_Left;
            this.tabHeader_Horizontal_ToolBar.SrcollRightButton = this.imageButton1_Right;
            this.tabHeader_Horizontal_ToolBar.TabIndex = 5;
            this.tabHeader_Horizontal_ToolBar.Vertical = false;
            this.tabHeader_Horizontal_ToolBar.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader_Horizontal_ToolBar.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // tabButton7
            // 
            this.tabButton7.AllowDrag = true;
            this.tabButton7.AllowDrop = true;
            this.tabButton7.BaseVisible = true;
            this.tabButton7.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton7, 1);
            this.tabButton7.Image = null;
            this.tabButton7.Location = new System.Drawing.Point(49, 0);
            this.tabButton7.Name = "tabButton7";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton7, 3);
            this.tabButton7.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton7, this.paintHelperEllipse);
            this.tabButton7.Size = new System.Drawing.Size(48, 43);
            this.tabButton7.TabIndex = 32;
            this.tabButton7.TabStop = false;
            // 
            // tabButtonEBoris
            // 
            this.tabButtonEBoris.AllowDrag = false;
            this.tabButtonEBoris.BaseVisible = true;
            this.tabButtonEBoris.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButtonEBoris, 1);
            this.helper.SetHelpText(this.tabButtonEBoris, "tabButton_EBoris");
            this.tabButtonEBoris.Image = null;
            this.tabButtonEBoris.Location = new System.Drawing.Point(98, 0);
            this.tabButtonEBoris.Name = "tabButtonEBoris";
            this.tabButtonExtender1.SetNormalEnterImageIndex(this.tabButtonEBoris, 15);
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButtonEBoris, 13);
            this.tabButtonExtender1.SetNormalPressImageIndex(this.tabButtonEBoris, 12);
            this.tabButtonEBoris.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButtonEBoris, this.paintHelperRect);
            this.tabButtonEBoris.Size = new System.Drawing.Size(171, 43);
            this.tabButtonEBoris.TabIndex = 31;
            this.tabButtonEBoris.TabStop = false;
            this.tabButtonEBoris.Text = "www.eBoris.com";
            // 
            // tabButton1_TabHeader
            // 
            this.tabButton1_TabHeader.AllowDrag = true;
            this.tabButton1_TabHeader.AllowDrop = true;
            this.tabButton1_TabHeader.BaseVisible = true;
            this.tabButton1_TabHeader.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton1_TabHeader, 1);
            this.helper.SetHelpText(this.tabButton1_TabHeader, "tabButton_Heading");
            this.tabButton1_TabHeader.Image = null;
            this.tabButton1_TabHeader.Location = new System.Drawing.Point(270, 0);
            this.tabButton1_TabHeader.Name = "tabButton1_TabHeader";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton1_TabHeader, 7);
            this.tabButton1_TabHeader.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton1_TabHeader, this.paintHelperRect);
            this.tabButton1_TabHeader.Size = new System.Drawing.Size(48, 43);
            this.tabButton1_TabHeader.TabIndex = 30;
            this.tabButton1_TabHeader.TabStop = false;
            // 
            // tabButton_TrackBar
            // 
            this.tabButton_TrackBar.AllowDrag = true;
            this.tabButton_TrackBar.AllowDrop = true;
            this.tabButton_TrackBar.BaseVisible = true;
            this.tabButton_TrackBar.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton_TrackBar, 1);
            this.helper.SetHelpText(this.tabButton_TrackBar, "tabButton_TrackBar");
            this.tabButton_TrackBar.Image = null;
            this.tabButton_TrackBar.Location = new System.Drawing.Point(319, 0);
            this.tabButton_TrackBar.Name = "tabButton_TrackBar";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton_TrackBar, 6);
            this.tabButton_TrackBar.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton_TrackBar, this.paintHelperRect);
            this.tabButton_TrackBar.Size = new System.Drawing.Size(48, 43);
            this.tabButton_TrackBar.TabIndex = 29;
            this.tabButton_TrackBar.TabStop = false;
            // 
            // imageButton1_Left
            // 
            this.imageButton1_Left.AllowDrag = true;
            this.imageButton1_Left.AllowDrop = true;
            this.imageButton1_Left.Checked = false;
            this.imageButton1_Left.Image = null;
            this.imageButton1_Left.Location = new System.Drawing.Point(-64, 9);
            this.imageButton1_Left.Name = "imageButton1_Left";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton1_Left, 17);
            this.imageButton1_Left.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton1_Left, this.paintHelperRect);
            this.imageButton1_Left.Size = new System.Drawing.Size(48, 25);
            this.imageButton1_Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton1_Left.TabIndex = 22;
            this.imageButton1_Left.TabStop = false;
            // 
            // imageButton1_Right
            // 
            this.imageButton1_Right.AllowDrag = true;
            this.imageButton1_Right.AllowDrop = true;
            this.imageButton1_Right.Checked = false;
            this.imageButton1_Right.Image = null;
            this.imageButton1_Right.Location = new System.Drawing.Point(-35, 9);
            this.imageButton1_Right.Name = "imageButton1_Right";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton1_Right, 18);
            this.imageButton1_Right.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton1_Right, this.paintHelperRect);
            this.imageButton1_Right.Size = new System.Drawing.Size(35, 25);
            this.imageButton1_Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton1_Right.TabIndex = 21;
            this.imageButton1_Right.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage4.Controls.Add(this.trackBar2);
            this.tabPage4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPage4.HeaderButton = this.tabButton_TrackBar;
            this.helper.SetHelpText(this.tabPage4, "tabPage_TrackBar");
            this.tabPage4.Location = new System.Drawing.Point(0, 226);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(313, 32);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Visible = false;
            // 
            // trackBar2
            // 
            this.helper.SetHelpText(this.trackBar2, "tabPage_TrackBar");
            this.trackBar2.LargeChange = 3;
            this.trackBar2.Location = new System.Drawing.Point(86, 0);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(288, 42);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.Value = 190;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // tabHeader3
            // 
            this.tabHeader3.AllowDrop = true;
            this.tabHeader3.BackColor = System.Drawing.Color.Turquoise;
            this.tabHeader3.Controls.Add(this.imageButton1);
            this.tabHeader3.Controls.Add(this.imageButton2);
            this.tabHeader3.Controls.Add(this.tabButton16);
            this.tabHeader3.Controls.Add(this.tabButton17);
            this.tabHeader3.Controls.Add(this.tabButton18);
            this.tabHeader3.Controls.Add(this.tabButton19);
            this.tabHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabHeader3.HeaderButton = this.tabButton1_TabHeader;
            this.helper.SetHelpText(this.tabHeader3, "tabHeader_DAD_child");
            this.tabHeader3.Interval = 1;
            this.tabHeader3.Location = new System.Drawing.Point(0, 291);
            this.tabHeader3.Multiselect = true;
            this.tabHeader3.Name = "tabHeader3";
            this.tabHeader3.SelectedButton = null;
            this.tabHeader3.Size = new System.Drawing.Size(313, 43);
            this.tabHeader3.SrcollLeftButton = this.imageButton1;
            this.tabHeader3.SrcollRightButton = this.imageButton2;
            this.tabHeader3.TabIndex = 17;
            this.tabHeader3.Vertical = false;
            this.tabHeader3.Visible = false;
            this.tabHeader3.DragDropButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragDropButtons);
            this.tabHeader3.DragOverButtons += new BorisBord.WinForms.DragControlsEventHandler(this.DragOverButtons);
            // 
            // imageButton1
            // 
            this.imageButton1.AllowDrag = true;
            this.imageButton1.AllowDrop = true;
            this.imageButton1.Checked = false;
            this.imageButton1.Image = null;
            this.imageButton1.Location = new System.Drawing.Point(-64, 9);
            this.imageButton1.Name = "imageButton1";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton1, 17);
            this.imageButton1.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton1, this.paintHelperRect);
            this.imageButton1.Size = new System.Drawing.Size(48, 25);
            this.imageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton1.TabIndex = 22;
            this.imageButton1.TabStop = false;
            this.imageButton1.Visible = false;
            // 
            // imageButton2
            // 
            this.imageButton2.AllowDrag = true;
            this.imageButton2.AllowDrop = true;
            this.imageButton2.Checked = false;
            this.imageButton2.Image = null;
            this.imageButton2.Location = new System.Drawing.Point(-35, 9);
            this.imageButton2.Name = "imageButton2";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.imageButton2, 18);
            this.imageButton2.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.imageButton2, this.paintHelperRect);
            this.imageButton2.Size = new System.Drawing.Size(35, 25);
            this.imageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton2.TabIndex = 21;
            this.imageButton2.TabStop = false;
            this.imageButton2.Visible = false;
            // 
            // tabButton16
            // 
            this.tabButton16.AllowDrag = true;
            this.tabButton16.AllowDrop = true;
            this.tabButton16.BaseVisible = true;
            this.tabButton16.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton16, 9);
            this.helper.SetHelpText(this.tabButton16, "Buttons_DragAndDrop");
            this.tabButton16.Image = null;
            this.tabButton16.Location = new System.Drawing.Point(0, 0);
            this.tabButton16.Name = "tabButton16";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton16, 8);
            this.tabButton16.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton16, this.paintHelperEllipse);
            this.tabButton16.Size = new System.Drawing.Size(48, 43);
            this.tabButton16.TabIndex = 18;
            this.tabButton16.TabStop = false;
            // 
            // tabButton17
            // 
            this.tabButton17.AllowDrag = true;
            this.tabButton17.AllowDrop = true;
            this.tabButton17.BaseVisible = true;
            this.tabButton17.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton17, 9);
            this.helper.SetHelpText(this.tabButton17, "Buttons_DragAndDrop");
            this.tabButton17.Image = null;
            this.tabButton17.Location = new System.Drawing.Point(49, 0);
            this.tabButton17.Name = "tabButton17";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton17, 10);
            this.tabButton17.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton17, this.paintHelperRect);
            this.tabButton17.Size = new System.Drawing.Size(48, 43);
            this.tabButton17.TabIndex = 6;
            this.tabButton17.TabStop = false;
            // 
            // tabButton18
            // 
            this.tabButton18.AllowDrag = true;
            this.tabButton18.AllowDrop = true;
            this.tabButton18.BaseVisible = true;
            this.tabButton18.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton18, 9);
            this.helper.SetHelpText(this.tabButton18, "Buttons_DragAndDrop");
            this.tabButton18.Image = null;
            this.tabButton18.Location = new System.Drawing.Point(98, 0);
            this.tabButton18.Name = "tabButton18";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton18, 11);
            this.tabButton18.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton18, this.paintHelperRhomd);
            this.tabButton18.Size = new System.Drawing.Size(48, 43);
            this.tabButton18.TabIndex = 17;
            this.tabButton18.TabStop = false;
            // 
            // tabButton19
            // 
            this.tabButton19.AllowDrag = true;
            this.tabButton19.AllowDrop = true;
            this.tabButton19.BaseVisible = true;
            this.tabButton19.Checked = false;
            this.tabButtonExtender1.SetCheckedLeaveImageIndex(this.tabButton19, 9);
            this.helper.SetHelpText(this.tabButton19, "Buttons_DragAndDrop");
            this.tabButton19.Image = null;
            this.tabButton19.Location = new System.Drawing.Point(147, 0);
            this.tabButton19.Name = "tabButton19";
            this.tabButtonExtender1.SetNormalLeaveImageIndex(this.tabButton19, 12);
            this.tabButton19.OwnerDraw = true;
            this.tabButtonExtender1.SetPaintExtender(this.tabButton19, this.paintHelperRect);
            this.tabButton19.Size = new System.Drawing.Size(48, 43);
            this.tabButton19.TabIndex = 16;
            this.tabButton19.TabStop = false;
            // 
            // tabPageEBoris
            // 
            this.tabPageEBoris.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPageEBoris.Controls.Add(this.linkEboris);
            this.tabPageEBoris.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageEBoris.HeaderButton = this.tabButtonEBoris;
            this.helper.SetHelpText(this.tabPageEBoris, "tabPageEBoris");
            this.tabPageEBoris.Location = new System.Drawing.Point(0, 258);
            this.tabPageEBoris.Name = "tabPageEBoris";
            this.tabPageEBoris.Size = new System.Drawing.Size(313, 33);
            this.tabPageEBoris.TabIndex = 15;
            this.tabPageEBoris.Visible = false;
            // 
            // linkEboris
            // 
            this.linkEboris.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkEboris.Location = new System.Drawing.Point(106, 9);
            this.linkEboris.Name = "linkEboris";
            this.linkEboris.Size = new System.Drawing.Size(120, 24);
            this.linkEboris.TabIndex = 1;
            this.linkEboris.TabStop = true;
            this.linkEboris.Text = "www.eboris.com";
            this.linkEboris.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEboris_LinkClicked);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Transparent;
            this.tabPage6.Controls.Add(this.radioButton2);
            this.tabPage6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPage6.HeaderButton = this.tabButtonR7;
            this.helper.SetHelpText(this.tabPage6, "TabPages_Example");
            this.tabPage6.Location = new System.Drawing.Point(0, 194);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(313, 32);
            this.tabPage6.TabIndex = 12;
            this.tabPage6.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(19, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(125, 26);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Boris Bord";
            // 
            // tabPage_TextBox_BorisBord
            // 
            this.tabPage_TextBox_BorisBord.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_TextBox_BorisBord.Controls.Add(this.textBox2);
            this.tabPage_TextBox_BorisBord.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPage_TextBox_BorisBord.HeaderButton = this.tabButtonR6;
            this.helper.SetHelpText(this.tabPage_TextBox_BorisBord, "TabPages_Example");
            this.tabPage_TextBox_BorisBord.Location = new System.Drawing.Point(0, 162);
            this.tabPage_TextBox_BorisBord.Name = "tabPage_TextBox_BorisBord";
            this.tabPage_TextBox_BorisBord.Size = new System.Drawing.Size(313, 32);
            this.tabPage_TextBox_BorisBord.TabIndex = 11;
            this.tabPage_TextBox_BorisBord.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(249, 21);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Boris Bord";
            // 
            // tabPageR5
            // 
            this.tabPageR5.BackColor = System.Drawing.Color.Transparent;
            this.tabPageR5.Controls.Add(this.textBox1);
            this.tabPageR5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageR5.HeaderButton = this.tabButtonR5;
            this.helper.SetHelpText(this.tabPageR5, "TabPages_Example");
            this.tabPageR5.Location = new System.Drawing.Point(0, 129);
            this.tabPageR5.Name = "tabPageR5";
            this.tabPageR5.Size = new System.Drawing.Size(313, 33);
            this.tabPageR5.TabIndex = 10;
            this.tabPageR5.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "www.eboris.com";
            // 
            // tabPageR4
            // 
            this.tabPageR4.BackColor = System.Drawing.Color.PowderBlue;
            this.tabPageR4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageR4.HeaderButton = this.tabButtonR4;
            this.helper.SetHelpText(this.tabPageR4, "TabPages_Example");
            this.tabPageR4.Location = new System.Drawing.Point(0, 97);
            this.tabPageR4.Name = "tabPageR4";
            this.tabPageR4.Size = new System.Drawing.Size(313, 32);
            this.tabPageR4.TabIndex = 9;
            this.tabPageR4.Visible = false;
            // 
            // tabPageR3
            // 
            this.tabPageR3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPageR3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageR3.HeaderButton = this.tabButtonR3;
            this.helper.SetHelpText(this.tabPageR3, "TabPages_Example");
            this.tabPageR3.Location = new System.Drawing.Point(0, 65);
            this.tabPageR3.Name = "tabPageR3";
            this.tabPageR3.Size = new System.Drawing.Size(313, 32);
            this.tabPageR3.TabIndex = 8;
            this.tabPageR3.Visible = false;
            // 
            // tabPageR2
            // 
            this.tabPageR2.BackColor = System.Drawing.Color.SkyBlue;
            this.tabPageR2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageR2.HeaderButton = this.tabButtonR2;
            this.helper.SetHelpText(this.tabPageR2, "TabPages_Example");
            this.tabPageR2.Location = new System.Drawing.Point(0, 32);
            this.tabPageR2.Name = "tabPageR2";
            this.tabPageR2.Size = new System.Drawing.Size(313, 33);
            this.tabPageR2.TabIndex = 7;
            this.tabPageR2.Visible = false;
            // 
            // tabPageR1
            // 
            this.tabPageR1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPageR1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPageR1.HeaderButton = this.tabButtonR1;
            this.helper.SetHelpText(this.tabPageR1, "TabPages_Example");
            this.tabPageR1.Location = new System.Drawing.Point(0, 0);
            this.tabPageR1.Name = "tabPageR1";
            this.tabPageR1.Size = new System.Drawing.Size(313, 32);
            this.tabPageR1.TabIndex = 6;
            this.tabPageR1.Visible = false;
            // 
            // tabPageL2
            // 
            this.tabPageL2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPageL2.Controls.Add(this.groupBox1);
            this.tabPageL2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageL2.HeaderButton = this.tabButtonL2;
            this.helper.SetHelpText(this.tabPageL2, "TabPages_Example");
            this.tabPageL2.Location = new System.Drawing.Point(0, 0);
            this.tabPageL2.Name = "tabPageL2";
            this.tabPageL2.Size = new System.Drawing.Size(394, 523);
            this.tabPageL2.TabIndex = 6;
            this.tabPageL2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(38, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boris Bord";
            // 
            // tabPageL1
            // 
            this.tabPageL1.BackColor = System.Drawing.Color.SkyBlue;
            this.tabPageL1.Controls.Add(this.linkLabelXXX);
            this.tabPageL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageL1.HeaderButton = this.tabButtonL1;
            this.helper.SetHelpText(this.tabPageL1, "TabPages_Example");
            this.tabPageL1.Location = new System.Drawing.Point(0, 0);
            this.tabPageL1.Name = "tabPageL1";
            this.tabPageL1.Size = new System.Drawing.Size(394, 523);
            this.tabPageL1.TabIndex = 5;
            this.tabPageL1.Visible = false;
            // 
            // linkLabelXXX
            // 
            this.linkLabelXXX.LinkColor = System.Drawing.Color.BlueViolet;
            this.linkLabelXXX.Location = new System.Drawing.Point(96, 112);
            this.linkLabelXXX.Name = "linkLabelXXX";
            this.linkLabelXXX.Size = new System.Drawing.Size(125, 25);
            this.linkLabelXXX.TabIndex = 0;
            this.linkLabelXXX.TabStop = true;
            this.linkLabelXXX.Text = "www.borisbord.com";
            this.linkLabelXXX.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBorisBord_LinkClicked);
            // 
            // tabPageL4
            // 
            this.tabPageL4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPageL4.Controls.Add(this.button1);
            this.tabPageL4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageL4.HeaderButton = this.tabButtonL4;
            this.helper.SetHelpText(this.tabPageL4, "TabPages_Example");
            this.tabPageL4.Location = new System.Drawing.Point(0, 0);
            this.tabPageL4.Name = "tabPageL4";
            this.tabPageL4.Size = new System.Drawing.Size(394, 523);
            this.tabPageL4.TabIndex = 8;
            this.tabPageL4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click me!!!";
            // 
            // tabButtonExtender1
            // 
            this.tabButtonExtender1.ImageList = this.imageList1;
            // 
            // paintHelperRect
            // 
            this.paintHelperRect.Alpha = ((byte)(120));
            this.paintHelperRect.BackColor = System.Drawing.Color.Empty;
            this.paintHelperRect.BorderColor = System.Drawing.Color.RoyalBlue;
            this.paintHelperRect.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.paintHelperRect.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.paintHelperRect.LeaveBackColor = System.Drawing.Color.Transparent;
            this.paintHelperRect.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // paintHelperEllipse
            // 
            this.paintHelperEllipse.Alpha = ((byte)(120));
            this.paintHelperEllipse.BackColor = System.Drawing.Color.Empty;
            this.paintHelperEllipse.BorderColor = System.Drawing.Color.Red;
            this.paintHelperEllipse.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.paintHelperEllipse.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.paintHelperEllipse.LeaveBackColor = System.Drawing.Color.Transparent;
            this.paintHelperEllipse.PressBackColor = System.Drawing.Color.DarkRed;
            // 
            // paintHelperRhomd
            // 
            this.paintHelperRhomd.Alpha = ((byte)(190));
            this.paintHelperRhomd.BackColor = System.Drawing.Color.Empty;
            this.paintHelperRhomd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.paintHelperRhomd.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.paintHelperRhomd.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.paintHelperRhomd.LeaveBackColor = System.Drawing.Color.Transparent;
            this.paintHelperRhomd.PressBackColor = System.Drawing.Color.Green;
            // 
            // paintHelperRect2
            // 
            this.paintHelperRect2.Alpha = ((byte)(100));
            this.paintHelperRect2.BackColor = System.Drawing.Color.Empty;
            this.paintHelperRect2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.paintHelperRect2.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.paintHelperRect2.EnterBackColor = System.Drawing.Color.Yellow;
            this.paintHelperRect2.LeaveBackColor = System.Drawing.Color.Transparent;
            this.paintHelperRect2.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            // 
            // paintHelper
            // 
            this.paintHelper.Alpha = ((byte)(0));
            this.paintHelper.BackColor = System.Drawing.Color.Empty;
            this.paintHelper.BorderColor = System.Drawing.Color.Transparent;
            this.paintHelper.CheckBackColor = System.Drawing.Color.Transparent;
            this.paintHelper.EnterBackColor = System.Drawing.Color.Transparent;
            this.paintHelper.LeaveBackColor = System.Drawing.Color.Transparent;
            this.paintHelper.PressBackColor = System.Drawing.Color.Transparent;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 451);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(812, 9);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // panel_streak
            // 
            this.panel_streak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(230)))), ((int)(((byte)(70)))));
            this.panel_streak.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_streak.Location = new System.Drawing.Point(0, 43);
            this.panel_streak.Name = "panel_streak";
            this.panel_streak.Size = new System.Drawing.Size(812, 10);
            this.panel_streak.TabIndex = 7;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panel2Right);
            this.panelRight.Controls.Add(this.panel1Right);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(451, 43);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(361, 523);
            this.panelRight.TabIndex = 7;
            // 
            // panel2Right
            // 
            this.panel2Right.BackColor = System.Drawing.Color.LightBlue;
            this.panel2Right.Controls.Add(this.tabPage_email);
            this.panel2Right.Controls.Add(this.tabHeader3);
            this.panel2Right.Controls.Add(this.tabPageEBoris);
            this.panel2Right.Controls.Add(this.tabPage4);
            this.panel2Right.Controls.Add(this.tabPage6);
            this.panel2Right.Controls.Add(this.tabPage_TextBox_BorisBord);
            this.panel2Right.Controls.Add(this.tabPageR5);
            this.panel2Right.Controls.Add(this.tabPageR4);
            this.panel2Right.Controls.Add(this.tabPageR3);
            this.panel2Right.Controls.Add(this.tabPageR2);
            this.panel2Right.Controls.Add(this.tabPageR1);
            this.panel2Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2Right.Location = new System.Drawing.Point(0, 0);
            this.panel2Right.Name = "panel2Right";
            this.panel2Right.Size = new System.Drawing.Size(313, 523);
            this.panel2Right.TabIndex = 8;
            // 
            // panel1Right
            // 
            this.panel1Right.Controls.Add(this.pictureBox1Right);
            this.panel1Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1Right.Location = new System.Drawing.Point(313, 0);
            this.panel1Right.Name = "panel1Right";
            this.panel1Right.Size = new System.Drawing.Size(48, 523);
            this.panel1Right.TabIndex = 7;
            // 
            // pictureBox1Right
            // 
            this.pictureBox1Right.Controls.Add(this.tabHeader1Right);
            this.pictureBox1Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1Right.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1Right.Image")));
            this.pictureBox1Right.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1Right.Name = "pictureBox1Right";
            this.pictureBox1Right.Size = new System.Drawing.Size(48, 523);
            this.pictureBox1Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1Right.TabIndex = 0;
            this.pictureBox1Right.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(442, 43);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(9, 523);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.panel2Left);
            this.panelLeft.Controls.Add(this.panel1Left);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 43);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(442, 523);
            this.panelLeft.TabIndex = 4;
            // 
            // panel2Left
            // 
            this.panel2Left.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2Left.Controls.Add(this.tabPageL1);
            this.panel2Left.Controls.Add(this.tabPageL4);
            this.panel2Left.Controls.Add(this.tabPageL3);
            this.panel2Left.Controls.Add(this.tabPageL2);
            this.panel2Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2Left.Location = new System.Drawing.Point(48, 0);
            this.panel2Left.Name = "panel2Left";
            this.panel2Left.Size = new System.Drawing.Size(394, 523);
            this.panel2Left.TabIndex = 7;
            // 
            // panel1Left
            // 
            this.panel1Left.Controls.Add(this.pictureBox1Left);
            this.panel1Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1Left.Location = new System.Drawing.Point(0, 0);
            this.panel1Left.Name = "panel1Left";
            this.panel1Left.Size = new System.Drawing.Size(48, 523);
            this.panel1Left.TabIndex = 6;
            // 
            // pictureBox1Left
            // 
            this.pictureBox1Left.Controls.Add(this.tabHeader1Left);
            this.pictureBox1Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1Left.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1Left.Image")));
            this.pictureBox1Left.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1Left.Name = "pictureBox1Left";
            this.pictureBox1Left.Size = new System.Drawing.Size(48, 523);
            this.pictureBox1Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1Left.TabIndex = 0;
            this.pictureBox1Left.TabStop = false;
            // 
            // panel_Horizontal_ToolBar
            // 
            this.panel_Horizontal_ToolBar.Controls.Add(this.panel_HorizontalToolBar2);
            this.panel_Horizontal_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Horizontal_ToolBar.Location = new System.Drawing.Point(0, 0);
            this.panel_Horizontal_ToolBar.Name = "panel_Horizontal_ToolBar";
            this.panel_Horizontal_ToolBar.Size = new System.Drawing.Size(812, 43);
            this.panel_Horizontal_ToolBar.TabIndex = 1;
            // 
            // panel_HorizontalToolBar2
            // 
            this.panel_HorizontalToolBar2.Controls.Add(this.pictureBox_Horizontal_ToolBar);
            this.panel_HorizontalToolBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_HorizontalToolBar2.Location = new System.Drawing.Point(0, 0);
            this.panel_HorizontalToolBar2.Name = "panel_HorizontalToolBar2";
            this.panel_HorizontalToolBar2.Size = new System.Drawing.Size(812, 43);
            this.panel_HorizontalToolBar2.TabIndex = 2;
            // 
            // pictureBox_Horizontal_ToolBar
            // 
            this.pictureBox_Horizontal_ToolBar.Controls.Add(this.tabHeader_Horizontal_ToolBar);
            this.pictureBox_Horizontal_ToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Horizontal_ToolBar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Horizontal_ToolBar.Image")));
            this.pictureBox_Horizontal_ToolBar.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Horizontal_ToolBar.Name = "pictureBox_Horizontal_ToolBar";
            this.pictureBox_Horizontal_ToolBar.Size = new System.Drawing.Size(812, 43);
            this.pictureBox_Horizontal_ToolBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Horizontal_ToolBar.TabIndex = 1;
            this.pictureBox_Horizontal_ToolBar.TabStop = false;
            // 
            // tabPage_All
            // 
            this.tabPage_All.Controls.Add(this.panelRight);
            this.tabPage_All.Controls.Add(this.splitter1);
            this.tabPage_All.Controls.Add(this.panelLeft);
            this.tabPage_All.Controls.Add(this.panel_Horizontal_ToolBar);
            this.tabPage_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_All.HeaderButton = this.tabButton_All;
            this.tabPage_All.Location = new System.Drawing.Point(0, 53);
            this.tabPage_All.Name = "tabPage_All";
            this.tabPage_All.Size = new System.Drawing.Size(812, 566);
            this.tabPage_All.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(812, 619);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.helper);
            this.Controls.Add(this.tabPage_All);
            this.Controls.Add(this.tabPage_Buttons);
            this.Controls.Add(this.tabPage_TabControl);
            this.Controls.Add(this.tabPage_DragAndDrop);
            this.Controls.Add(this.panel_streak);
            this.Controls.Add(this.tabHeader1);
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximumSize = new System.Drawing.Size(984, 646);
            this.MinimumSize = new System.Drawing.Size(360, 646);
            this.Name = "Form1";
            this.Text = "Boris Bord";
            this.tabHeader1.ResumeLayout(false);
            this.tabHeader1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_TabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_Buttons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_DragAndDrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_All)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval2)).EndInit();
            this.tabPage_Buttons.ResumeLayout(false);
            this.tabHeader_Disabled_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton79)).EndInit();
            this.tabHeader_Buttons_Empty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton52)).EndInit();
            this.tabHeader5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton73)).EndInit();
            this.tabHeader_test.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton49)).EndInit();
            this.tabPage_TrackBar.ResumeLayout(false);
            this.tabPage_TrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabHeader11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_oval_)).EndInit();
            this.tabPage_email.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_email)).EndInit();
            this.tabHeader1Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonR3)).EndInit();
            this.tabHeader1Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonL4)).EndInit();
            this.tabPage_DragAndDrop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabHeader8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton32)).EndInit();
            this.tabHeader9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton31)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureBox1.ResumeLayout(false);
            this.tabHeader_DAD_horiz_Bottom.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabHeader21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton74)).EndInit();
            this.tabHeader22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton69)).EndInit();
            this.panel_DAD_hor_Up.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pictureBox2.ResumeLayout(false);
            this.tabHeader_DAD_horiz_Up.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel_DAD_vert_Left2.ResumeLayout(false);
            this.tabHeader14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton4)).EndInit();
            this.tabHeader13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton3)).EndInit();
            this.tabHeader10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton2)).EndInit();
            this.panel_DAD_vert_Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DAD_vert_Left)).EndInit();
            this.pictureBox_DAD_vert_Left.ResumeLayout(false);
            this.tabHeader_DAD_vert_Left.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_DAD_vert_Right2.ResumeLayout(false);
            this.tabHeader19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton27)).EndInit();
            this.tabHeader16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton26)).EndInit();
            this.tabHeader15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton14)).EndInit();
            this.panel_DAD_vert_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DAD_vert_Right)).EndInit();
            this.pictureBox_DAD_vert_Right.ResumeLayout(false);
            this.tabHeader_DAD_vert_Right.ResumeLayout(false);
            this.tabPageL3.ResumeLayout(false);
            this.tabPage_TabControl.ResumeLayout(false);
            this.tabHeader17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton106)).EndInit();
            this.tabHeader12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton67)).EndInit();
            this.tabHeader6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton21)).EndInit();
            this.tabHeader7.ResumeLayout(false);
            this.tabHeader_Horizontal_ToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonEBoris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton1_TabHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton_TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1_Right)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.tabHeader3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabButton19)).EndInit();
            this.tabPageEBoris.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage_TextBox_BorisBord.ResumeLayout(false);
            this.tabPage_TextBox_BorisBord.PerformLayout();
            this.tabPageR5.ResumeLayout(false);
            this.tabPageR5.PerformLayout();
            this.tabPageL2.ResumeLayout(false);
            this.tabPageL1.ResumeLayout(false);
            this.tabPageL4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabButtonExtender1)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panel2Right.ResumeLayout(false);
            this.panel1Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Right)).EndInit();
            this.pictureBox1Right.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panel2Left.ResumeLayout(false);
            this.panel1Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Left)).EndInit();
            this.pictureBox1Left.ResumeLayout(false);
            this.panel_Horizontal_ToolBar.ResumeLayout(false);
            this.panel_HorizontalToolBar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Horizontal_ToolBar)).EndInit();
            this.pictureBox_Horizontal_ToolBar.ResumeLayout(false);
            this.tabPage_All.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}		

		private void DragDropButtons(object sender, BorisBord.WinForms.DragControlsEventArgs me)
		{
			BorisBord.WinForms.TabDragHelper tdh= new BorisBord.WinForms.TabDragHelper();
			tdh.DragDropButtons(sender,me);		
		}

		private void DragOverButtons(object sender, BorisBord.WinForms.DragControlsEventArgs me)
		{
			BorisBord.WinForms.TabDragHelper tdh= new BorisBord.WinForms.TabDragHelper();
			tdh.DragOverButtons(sender,me);		
		}

		private void tabButton_8_Paint_(object sender, System.Windows.Forms.PaintEventArgs e)
		{          
			this.paintHelper.Paint(sender,e);
		}

		private void trackBar2_Scroll(object sender, System.EventArgs e)
		{
			paintHelperEllipse.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			paintHelperRhomd.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			paintHelperRect.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;			
			paintHelperRect2.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			this.Refresh();		
		}

		private void linkEboris_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{			
			linkEboris.LinkVisited = true ;
			System.Diagnostics.Process.Start("www.eboris.com");
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkEboris.LinkVisited = true ;
			System.Diagnostics.Process.Start("mailto:support@eboris.com");
		
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			paintHelperEllipse.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			paintHelperRhomd.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			paintHelperRect.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;			
			paintHelperRect2.Alpha= (byte)((System.Windows.Forms.TrackBar)sender).Value;
			this.Refresh();				
		}
		
		private void linkBorisBord_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkEboris.LinkVisited = true ;
			System.Diagnostics.Process.Start("www.borisbord.com");
		}

	}
}
