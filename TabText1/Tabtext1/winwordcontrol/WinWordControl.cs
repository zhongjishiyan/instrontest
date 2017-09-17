/// This code is written by Matthias Haenel
/// contact: www.intercopmu.de
/// 
/// you can use it free of charge, but please 
/// mention my name ;)
/// 
/// WinWordControl utilizes MS-WinWord2000 and 
/// WinWord-XP
/// 
/// It simulates a form element, with simple tricks.
///


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Microsoft.Office.Core;  

namespace WinWordControl
{
	public class DocumentInstanceException : Exception
	{}
	
	public class ValidDocumentException : Exception
	{}

	public class WordInstanceException : Exception
	{}

	/// <summary>
	/// WinWordControl allows you to load doc-Files to your
	/// own application without any loss, because it uses 
	/// the real WinWord.
	/// </summary>
	public class WinWordControl : System.Windows.Forms.UserControl
	{

		[DllImport("user32.dll")]
		public static extern int FindWindow(string strclassName, string strWindowName);

		[DllImport("user32.dll")]
		static extern int SetParent( int hWndChild, int hWndNewParent);

		[DllImport("user32.dll", EntryPoint="SetWindowPos")]
		static extern bool SetWindowPos(
			int hWnd,               // handle to window
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags             // window-positioning options
		);
		
		[DllImport("user32.dll", EntryPoint="MoveWindow")]
		static extern bool MoveWindow(
			int Wnd, 
			int X, 
			int Y, 
			int Width, 
			int Height, 
			bool  Repaint
		);

				

		/* I was testing wheater i could fix some exploid bugs or not.
		 * I left this stuff in here for people who need to know how to 
		 * interface the Win32-API

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, ref RECT rc);
		
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(
			int hWnd, 
			int msg, 
			int wParam, 
			int lParam
		);
		*/

		const int SWP_DRAWFRAME = 0x20;
		const int SWP_NOMOVE = 0x2;
		const int SWP_NOSIZE = 0x1;
		const int SWP_NOZORDER = 0x4;


		private Word.Document document;
		private static Word.ApplicationClass wd = null;
		public  static int wordWnd				= 0;
		private static string filename			= null;
		private static bool	deactivateevents	= false;

		/// <summary>
		/// needed designer variable
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinWordControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// cleanup Ressources
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			CloseControl();
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// !do not alter this code! It's designer code
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// WinWordControl
			// 
			this.Name = "WinWordControl";
			this.Size = new System.Drawing.Size(440, 336);
			this.Resize += new System.EventHandler(this.OnResize);			
		}
		#endregion


		/// <summary>
		/// Preactivation
		/// It's usefull, if you need more speed in the main Program
		/// so you can preload Word.
		/// </summary>
		public void PreActivate()
		{
			if(wd == null) wd = new Word.ApplicationClass();
		}


		/// <summary>
		/// Close the current Document in the control --> you can 
		/// load a new one with LoadDocument
		/// </summary>
		public void CloseControl()
		{
			/*
			* this code is to reopen Word.
			*/
		
			try
			{
				deactivateevents = true;
				object dummy=null;
				document.Close(ref dummy, ref dummy, ref dummy);
				document.Application.Quit(ref dummy, ref dummy, ref dummy);
				deactivateevents = false;
			}
			catch 
			{
			}
		}


		/// <summary>
		/// catches Word's close event 
		/// starts a Thread that send a ESC to the word window ;)
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="test"></param>
		private void OnClose(Word.Document doc, ref bool chancel)
		{
			if(!deactivateevents)
			{
				chancel=true;
			}
		}

		/// <summary>
		/// catches Word's open event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		private void OnOpenDoc(Word.Document doc)
		{
			OnNewDoc(doc);
		}

		/// <summary>
		/// catches Word's newdocument event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		private void OnNewDoc(Word.Document doc)
		{
			if(!deactivateevents)
			{
				deactivateevents=true;
				object dummy = null;
				doc.Close(ref dummy,ref dummy,ref dummy);
				deactivateevents=false;
			}
		}

		/// <summary>
		/// catches Word's quit event
		/// normally it should not fire, but just to be shure
		/// safely release the internal Word Instance 
		/// </summary>
		private void OnQuit()
		{
			//wd=null;
		}


		/// <summary>
		/// Loads a document into the control
		/// </summary>
		/// <param name="t_filename">path to the file (every type word can handle)</param>
		public void LoadDocument(string t_filename)
		{
			deactivateevents = true;
			filename = t_filename;
		
			if(wd == null) wd = new Word.ApplicationClass();
			try 
			{
				wd.CommandBars.AdaptiveMenus = false;
                
				wd.DocumentBeforeClose +=new  Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(OnClose);
                //wd.NewDocument += new Word.ApplicationEvents3_NewDocumentEventHandler(OnNewDoc);  
                   // new Word.ApplicationEvents4_NewDocumentEventHandler(OnNewDoc);
				wd.DocumentOpen+= new Word.ApplicationEvents4_DocumentOpenEventHandler(OnOpenDoc);

				wd.ApplicationEvents2_Event_Quit+=new Word.ApplicationEvents2_QuitEventHandler(OnQuit);
        
			}
			catch{}

			if(document != null) 
			{
				try
				{
					object dummy=null;
					wd.Documents.Close(ref dummy, ref dummy, ref dummy);
				}
				catch{}
			}

			if( wordWnd==0 ) wordWnd = FindWindow( "Opusapp", null);
			if (wordWnd!=0)
			{
				SetParent( wordWnd, this.Handle.ToInt32());				
			
				object fileName = filename;
				object newTemplate = false;
				object docType = 0;
				object readOnly = true;
				object isVisible = true;
				object missing = System.Reflection.Missing.Value;
			
				try
				{
					if( wd == null )
					{
						throw new WordInstanceException();
					}

					if( wd.Documents == null )
					{
						throw new DocumentInstanceException();
					}
				
					if( wd != null && wd.Documents != null )
					{
						document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
					}
							
					if(document == null)
					{
						throw new ValidDocumentException();
					}
				}
				catch
				{
				}

				try
				{
					wd.ActiveWindow.DisplayRightRuler=false;
					wd.ActiveWindow.DisplayScreenTips=false;
					wd.ActiveWindow.DisplayVerticalRuler=false;
					wd.ActiveWindow.DisplayRightRuler=false;
					wd.ActiveWindow.ActivePane.DisplayRulers=false;
					wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdWebView; // .wdNormalView;
				}
				catch
				{

				}

				int counter = wd.ActiveWindow.Application.CommandBars.Count;
				for(int i = 0; i < counter;i++)
				{
					try
					{
						wd.ActiveWindow.Application.CommandBars[i].Enabled=false;
					}
					catch
					{

					}
				}
				try
				{
					wd.Visible = true;
					wd.Activate();
				
					SetWindowPos(wordWnd,this.Handle.ToInt32(),0,0,this.Bounds.Width+20,this.Bounds.Height+20, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME);
					MoveWindow(wordWnd,-5,-33,this.Bounds.Width+10,this.Bounds.Height+57,true);
				}
				catch
				{
					MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
				}
				this.Parent.Focus();
				
			}
			deactivateevents = false;
		}


		/// <summary>
		/// restores Word.
		/// If the program crashed somehow.
		/// Sometimes Word saves it's temporary settings :(
		/// </summary>
		public void RestoreWord()
		{
			try
			{
				int counter = wd.ActiveWindow.Application.CommandBars.Count;
				for(int i = 0; i < counter;i++)
				{
					try
					{
						wd.ActiveWindow.Application.CommandBars[i].Enabled=true;
					}
					catch
					{

					}
				}
			}
			catch{};
		}

		/// <summary>
		/// internal resize function
		/// utilizes the size of the surrounding control
		/// 
		/// optimzed for Word2000 but it works pretty good with WordXP too.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnResize(object sender, System.EventArgs e)
		{
			MoveWindow(wordWnd,-5,-33,this.Bounds.Width+10,this.Bounds.Height+57,true);
		}
	}
}
