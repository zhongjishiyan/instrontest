using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AppleLabApplication
{
    public enum LanguageEnum
    {
        LanguageCN,
        LanguageEN,
    }

    public class ManageLanguage
    {
       // public static ManageLanguage Instance = new ManageLanguage();

        ArrayList objectList = new ArrayList();

        /// <summary>
        /// 注册FORM
        /// </summary>
        /// <param name="item"></param>
        public void RegObject(FormBase item)
        {

            if (objectList.Contains(item) != true)
            {
                objectList.Add(item);
            }
        }

        /// <summary>
        /// 设置语言
        /// </summary>
        /// <param name="lg">语言种类</param>
        public void SetLanguage(LanguageEnum lg)
        {
            switch (lg)
            {
                case LanguageEnum.LanguageCN:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
                   // System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("zh-CHS");
                    CallBackLanguage();
                    break;
                case LanguageEnum.LanguageEN:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");

                    
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

                    CallBackLanguage();
                    break;
            }
        }

        /// <summary>
        /// 遍历注册过的FORM，切换语言
        /// </summary>
        void CallBackLanguage()
        {
            //遍历所有Form，以切换其语言
            foreach (FormBase form in objectList)
            {

                form.Language();
            }
        }
    }

    public partial class LabelT : Label
    {
        public LabelT()
        {

        }
    }
    public partial class UserT : UserControl
    {
        public UserT()
        {

        }
    }

    public class UserBase : UserControl
    {
        private System.ComponentModel.ComponentResourceManager resources;
        public UserBase()
        {
            resources = new System.ComponentModel.ComponentResourceManager(this.GetType());


            //ManageLanguage.Instance.RegObject(this);
        }


        /// <summary>
        /// 语言切换的接口
        /// </summary>
        /// 


        private void GetListViewAllName(ref ArrayList arr, ColumnHeader tsmi, System.ComponentModel.ComponentResourceManager resources, ListView l)
        {

            if (l == null) return;

            for (int i = 0; i < l.Columns.Count; i++)
            {
                ColumnHeader item = (ColumnHeader)l.Columns[i];

                arr.Add(item.Text);



                resources.ApplyResources(item, item.Tag as string);


            }

        }
        private void GetMenuAllName(ref ArrayList arr, ToolStripMenuItem tsmi, int level,
            System.ComponentModel.ComponentResourceManager resources, MenuStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetMenuAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {
                if (tsmi != null && tsmi.DropDownItems.Count > 0)
                {
                    for (int i = 0; i < tsmi.DropDownItems.Count; i++)
                    {
                        if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)tsmi.DropDownItems[i];
                            arr.Add(item.Text);
                            resources.ApplyResources(item, item.Name);

                            GetMenuAllName(ref arr, item, level + 1, resources, f);
                        }
                    }
                }
            }
        }



        private void GetToolButtonAllName(ref ArrayList arr, ToolStripItem tsmi, int level, System.ComponentModel.ComponentResourceManager resources, ToolStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripItem item = f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {

                if (tsmi is ToolStripDropDownButton)
                {
                    if (tsmi != null && (tsmi as ToolStripDropDownButton).DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < (tsmi as ToolStripDropDownButton).DropDownItems.Count; i++)
                        {
                            //if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                            {
                                ToolStripMenuItem item = (ToolStripMenuItem)(tsmi as ToolStripDropDownButton).DropDownItems[i];
                                arr.Add(item.Text);
                                resources.ApplyResources(item, item.Name);

                                GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                            }
                        }
                    }
                }
            }
        }




        public virtual void Language()
        {

            if (resources.GetString("$this.Text") != "")
            {
                this.Text = resources.GetString("$this.Text");
            }


            ArrayList list = new ArrayList();
            //



            // ToolStripMenuItem tsmi=default(ToolStripMenuItem);
            //GetMenuAllName(ref list,null, 0, resources);

            list.Clear();


            FindControls(list, this);

            //foreach (Control ctl in list)
            {
                // resources.ApplyResources(ctl, ctl.Name);
            }
        }

        /// <summary>
        /// 把可以本地化的控件放入LIST
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ctl"></param>
        private void FindControls(ArrayList list, Control ctl)
        {
            //容器不可以本地化





            if (ctl is ContainerControl)
            {

            }
            else if (ctl is TableLayoutPanel)
            {

            }
            else if (ctl is UserT)
            {

            }

            else if (ctl is UserSubBase)
            {
            }


            else
            {
                if (ctl is MenuStrip)
                {
                    GetMenuAllName(ref list, null, 0, resources, ctl as MenuStrip);

                }
                else if (ctl is ToolStrip)
                {
                    GetToolButtonAllName(ref list, null, 0, resources, ctl as ToolStrip);
                }
                else if (ctl is ListView)
                {
                    GetListViewAllName(ref list, null, resources, (ctl as ListView));
                }

                else
                {
                    resources.ApplyResources(ctl, ctl.Name);
                }
                list.Add(ctl);

            }

            if (ctl is UserT)
            {




            }
            else if (ctl is UserSubBase)
            {
                (ctl as UserSubBase).Language();
            }
            else
            {
                if (ctl.HasChildren)
                {
                    //Application.DoEvents();
                    foreach (Control c in ctl.Controls)
                    {

                        if (c is Form)
                        {
                        }
                        else
                        {
                            FindControls(list, c);
                        }
                    }
                }
            }
        }




    }

    public class UserSubBase : UserControl
    {
        private System.ComponentModel.ComponentResourceManager resources;
        public UserSubBase()
        {
            resources = new System.ComponentModel.ComponentResourceManager(this.GetType());


            //ManageLanguage.Instance.RegObject(this);
        }


        /// <summary>
        /// 语言切换的接口
        /// </summary>
        /// 

        private void GetMenuAllName(ref ArrayList arr, ToolStripMenuItem tsmi, int level, System.ComponentModel.ComponentResourceManager resources, MenuStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetMenuAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {
                if (tsmi != null && tsmi.DropDownItems.Count > 0)
                {
                    for (int i = 0; i < tsmi.DropDownItems.Count; i++)
                    {
                        if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)tsmi.DropDownItems[i];
                            arr.Add(item.Text);
                            resources.ApplyResources(item, item.Name);

                            GetMenuAllName(ref arr, item, level + 1, resources, f);
                        }
                    }
                }
            }
        }



        private void GetToolButtonAllName(ref ArrayList arr, ToolStripItem tsmi, int level, System.ComponentModel.ComponentResourceManager resources, ToolStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripItem item = f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {

                if (tsmi is ToolStripDropDownButton)
                {
                    if (tsmi != null && (tsmi as ToolStripDropDownButton).DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < (tsmi as ToolStripDropDownButton).DropDownItems.Count; i++)
                        {
                            //if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                            {
                                ToolStripMenuItem item = (ToolStripMenuItem)(tsmi as ToolStripDropDownButton).DropDownItems[i];
                                arr.Add(item.Text);
                                resources.ApplyResources(item, item.Name);

                                GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                            }
                        }
                    }
                }
            }
        }




        public virtual void Language()
        {
            if (resources.GetString("$this.Text") != "")
            {
                this.Text = resources.GetString("$this.Text");
            }


            ArrayList list = new ArrayList();
            //



            // ToolStripMenuItem tsmi=default(ToolStripMenuItem);
            //GetMenuAllName(ref list,null, 0, resources);

            list.Clear();


            FindControls(list, this);

            //foreach (Control ctl in list)
            {
                // resources.ApplyResources(ctl, ctl.Name);
            }
        }

        /// <summary>
        /// 把可以本地化的控件放入LIST
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ctl"></param>
        private void FindControls(ArrayList list, Control ctl)
        {
            //容器不可以本地化





            if (ctl is ContainerControl)
            {

            }
            else if (ctl is TableLayoutPanel)
            {

            }
            else if (ctl is UserT)
            {

            }

            else
            {
                if (ctl is MenuStrip)
                {
                    GetMenuAllName(ref list, null, 0, resources, ctl as MenuStrip);

                }
                else if (ctl is ToolStrip)
                {
                    GetToolButtonAllName(ref list, null, 0, resources, ctl as ToolStrip);
                }

                else
                {
                    resources.ApplyResources(ctl, ctl.Name);
                }
                list.Add(ctl);

            }

            if (ctl is UserT)
            {




            }
            else
            {
                if (ctl.HasChildren)
                {
                    foreach (Control c in ctl.Controls)
                    {
                        if (c is Form)
                        {
                        }
                        else
                        {
                            FindControls(list, c);
                        }
                    }
                }
            }
        }




    }


    public class FormBase : Form
    {
        private System.ComponentModel.ComponentResourceManager resources;
        public FormBase()
        {
            resources = new System.ComponentModel.ComponentResourceManager(this.GetType());


           CComLibrary.GlobeVal.mylanguage.RegObject(this);
        }


        /// <summary>
        /// 语言切换的接口
        /// </summary>
        /// 

        private void GetMenuAllName(ref ArrayList arr, ToolStripMenuItem tsmi, int level, System.ComponentModel.ComponentResourceManager resources, MenuStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetMenuAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {
                if (tsmi != null && tsmi.DropDownItems.Count > 0)
                {
                    for (int i = 0; i < tsmi.DropDownItems.Count; i++)
                    {
                        if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)tsmi.DropDownItems[i];
                            arr.Add(item.Text);
                            resources.ApplyResources(item, item.Name);

                            GetMenuAllName(ref arr, item, level + 1, resources, f);
                        }
                    }
                }
            }
        }


        private void GetToolButtonAllName(ref ArrayList arr, ToolStripItem tsmi, int level, System.ComponentModel.ComponentResourceManager resources, ToolStrip f)
        {

            if (f == null) return;

            if (level == 0)
            {
                for (int i = 0; i < f.Items.Count; i++)
                {
                    ToolStripItem item = f.Items[i];
                    arr.Add(item.Text);
                    resources.ApplyResources(item, item.Name);
                    GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                }
            }
            else
            {

                if (tsmi is ToolStripDropDownButton)
                {
                    if (tsmi != null && (tsmi as ToolStripDropDownButton).DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < (tsmi as ToolStripDropDownButton).DropDownItems.Count; i++)
                        {
                            //if (tsmi.DropDownItems[i] is ToolStripMenuItem)
                            {
                                ToolStripMenuItem item = (ToolStripMenuItem)(tsmi as ToolStripDropDownButton).DropDownItems[i];
                                arr.Add(item.Text);
                                resources.ApplyResources(item, item.Name);

                                GetToolButtonAllName(ref arr, item, level + 1, resources, f);
                            }
                        }
                    }
                }
            }
        }




        public virtual void Language()
        {


            ArrayList list = new ArrayList();
            //
            if (resources.GetString("$this.Text") != null)
            {
                this.Text = resources.GetString("$this.Text");
            }


            // ToolStripMenuItem tsmi=default(ToolStripMenuItem);
            //GetMenuAllName(ref list,null, 0, resources);

            list.Clear();


            FindControls(list, this);

            //foreach (Control ctl in list)
            {
                // resources.ApplyResources(ctl, ctl.Name);
            }
        }

        /// <summary>
        /// 把可以本地化的控件放入LIST
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ctl"></param>
        private void FindControls(ArrayList list, Control ctl)
        {
            //容器不可以本地化





            if (ctl is ContainerControl)
            {

            }
            else if (ctl is TableLayoutPanel)
            {

            }
            else if (ctl is UserBase)
            {

            }
            else
            {
                if (ctl is MenuStrip)
                {
                    GetMenuAllName(ref list, null, 0, resources, ctl as MenuStrip);

                }
                else if (ctl is ToolStrip)
                {
                    GetToolButtonAllName(ref list, null, 0, resources, ctl as ToolStrip);
                }
                else
                {

                    resources.ApplyResources(ctl, ctl.Name);
                }
                list.Add(ctl);

            }


            if (ctl is UserBase)
            {
                (ctl as UserBase).Language();
            }
            else
            {
                if (ctl.HasChildren)
                {
                    foreach (Control c in ctl.Controls)
                    {
                        //Application.DoEvents();
                        if (c is Form)
                        {
                        }
                        else
                        {
                            FindControls(list, c);
                        }
                    }
                }
            }
        }



    }
}
