using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;
using System.Data.SqlClient;
using System.IO;
namespace TabHeaderDemo
{
    public partial class UserControl数据库 : UserControl
    {
        public UserControlMethod musercontrolmethod;

        public void Init(int sel)
        {
            bool f = false;

           
            listavail.ClearItem();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mdatabaseitemlist.Count; i++)
            {
                f = false;


                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; j++)
                {
                    if (CComLibrary.GlobeVal.filesave.mdatabaseitemlist[i].Name == CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Name)
                    {
                        f = true;
                    }
                }

                
             
                    if (f == false)
                    {
                        listavail.AddItem(CComLibrary.GlobeVal.filesave.mdatabaseitemlist[i]);
                    }
                
            }
            listinclude.ClearItem();
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; i++)
            {
                listinclude.AddItem(CComLibrary.GlobeVal.filesave.mdatabaseitemselect[i]);
            }

           



        }
        public UserControl数据库()
        {
            InitializeComponent();
        }
        private void list_setvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Clear();
            for (i = 0; i < this.listinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Add(this.listinclude.mlist[i]);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (this.listavail.SelectedItem != null)
            {
                this.listinclude.AddItem(this.listavail.mlist[this.listavail.SelectedIndex]);
                this.listavail.RemoveItem(this.listavail.SelectedIndex);
                list_setvalue();

            }
        }

        private void btndec_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
               this.listavail.AddItem(this.listinclude.mlist[this.listinclude.SelectedIndex]);
                

                this.listinclude.RemoveItem(this.listinclude.SelectedIndex);

                list_setvalue();
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                this.listinclude.UpItem(this.listinclude.SelectedIndex);
                list_setvalue();
            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                this.listinclude.DownItem(this.listinclude.SelectedIndex);
                list_setvalue();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            if (System.IO.Directory.Exists(Application.StartupPath + "\\mdb")==true)
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\mdb");
            }


            if (File.Exists(Application.StartupPath  + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb")== true)
            {
                File.Delete(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb");
            }
            
            ADOX.Catalog catalog = new Catalog();
            catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb;" + "Jet OLEDB:Engine Type=5");

            ADODB.Connection cn = new ADODB.Connection();

            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb", null, null, -1);
            catalog.ActiveConnection = cn;

            ADOX.Table table = new ADOX.Table();
            table.Name = "FirstTable";

            ADOX.Column column = new ADOX.Column();
            column.ParentCatalog = catalog;
            column.Name = "RecordId";
          
            column.Type = DataTypeEnum.adInteger;
            column.DefinedSize = 9;
            column.Properties["AutoIncrement"].Value = true;
            table.Columns.Append(column, DataTypeEnum.adInteger, 9);
            table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count;i++)
            {
                column = new ADOX.Column();
               
                column.Name = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[i].Name;
                column.Attributes = ColumnAttributesEnum.adColNullable;
                table.Columns.Append(column, DataTypeEnum.adVarWChar, 80);
               
               
                
            }

           



            // table.Columns.Append("CustomerName", DataTypeEnum.adVarWChar, 50);
            // table.Columns.Append("Age", DataTypeEnum.adInteger, 9);
            // table.Columns.Append("生日", DataTypeEnum.adVarWChar, 80);

            catalog.Tables.Append(table);

           

            ADODB.Recordset rs;

            rs = new ADODB.Recordset();
            
            rs.LockType = ADODB.LockTypeEnum.adLockPessimistic;
            rs.CursorType = ADODB.CursorTypeEnum.adOpenDynamic;

            string sql = "select * from FirstTable";
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (int)ADODB.CommandTypeEnum.adCmdText);
          //  rs.MoveFirst();
          /*
            for (int i=0;i<1;i++)
            {
                
               
                object missing = System.Reflection.Missing.Value;
                rs.AddNew(missing, missing);

                rs.Fields["RecordId"].Value  = i;

                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; j++)
                {
                    rs.Fields[j+1].Value = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Value;
                   
                }
                    
               
                rs.Update();
            }
            */

            rs.Close();
            cn.Close();



            button1.Enabled = true;
          
        }
    }
}
