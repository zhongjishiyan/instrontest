using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;
using MCTBuffer;

namespace ClsStaticStation
{
    

    public class ListViewEx : ListView
    {
        //public delegate void ScrollEventHandler(object sender, EventArgs e);
        public event EventHandler HScroll;
        public event EventHandler VScroll;
        public ListViewEx()
        {
        }
        const int WM_HSCROLL = 0x0114;
        const int WM_VSCROLL = 0x0115;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HSCROLL)
            {
                OnHScroll(this, new EventArgs());
            }
            else if (m.Msg == WM_VSCROLL)
            {
                OnVScroll(this, new EventArgs());
            }
            base.WndProc(ref m);
        }
        virtual protected void OnHScroll(object sender, EventArgs e)
        {
            if (HScroll != null)
                HScroll(this, e);
        }
        virtual protected void OnVScroll(object sender, EventArgs e)
        {
            if (VScroll != null)
                VScroll(this, e);
        }
    }


    [Serializable]
    public class shapeitem
    {
        public int Rect_Shape = 0;

        public int Round_Shape = 1;

        public int Double_shear_ring_Shape = 2;

        public int Tube_Shape = 3;

        public int Irregular_Shape = 4;

        public int Fiber_Shape = 5;

        public int _90_degree_stripping_Shape = 6;
        public int _180_degree_stripping_Shape = 7;

        public int T_stripping_Shape = 8;

        public int Tear_Shape = 9;

        public string shapename;

        
      
        

        public ItemSignal[]  sizeitem;

       

        public  shapeitem()
        {
            sizeitem =new ItemSignal[6];
            

            for (int i = 0; i < 6; i++)
            {
                sizeitem[i] = new ItemSignal();
                
            }
         
         }
       
    }
     [Serializable]
     public class ItemSignalStation : IDisposable
     {

        public string[] ChannelName;//通道名称
        public double[] ChannelRange;//通道量程
        public int[] ChannelDimension;//通道量纲
        public bool[] ChannelControl;//通道控制

        public int[] ChannelSampling;//通道采集方式

        public int[] ChannelControlChannel;//带双通道控制器参数选择

        public int ChannelCount = 8;//通道数量

        public int machinekind = 0;
         public List<ItemSignal> datalist=new List<ItemSignal>();

         public void initdatalist()
         {
             int i;
             int j;



             for (i = 0; i < 4; i++)
             {
                 ClsStatic.arraydata[i] = new CircularBuffer("MCTarraydata" + i.ToString(), 500, Marshal.SizeOf(typeof(RawDataDataGroup)));
                 ClsStatic.arraydatacount[i] = 0;


             }
            




         }


         public List<shapeitem> shapelist;//试样形状定义列表

         public List<ItemSignal> chsignals; //通道控制信号

         public List<ItemSignal> allsignals;//所有通道信号

         public List<ItemSignal> hardsignals; //固有通道

         public List<ItemSignal> zerosignals;//可清零通道

         public List<ItemSignal> originsignals;//原始通道
        
         public List<ItemCalcedSignal> calcparameters;//计算参数
         public List<ItemCalcedSignal> calcvariables;//计算变量

         public ItemSignal freqsignal;
         public ItemSignal timesignal;
         public ItemSignal shorttimesignal;
         public ItemSignal lengthspeedsignal;
         public ItemSignal forcespeedsignal;
         public ItemSignal countsignal;
         public ItemSignal undefinesignal;
         public ItemSignal pidfsignal;
         public ItemSignal anglespeedsignal;
         public ItemSignal torquespeedsignal;
         public string cName;
         public string[] LName;


         public List<String> TestkindList;//试验类型


         public List<ItemSignal> signalskindlist;

       

         public String[] SignalsNames;


        public int SignalsNames_Count;

         private bool disposed = false;

         private void Dispose(bool disposing)
         {
             // Check to see if Dispose has already been called.
             if (!this.disposed)
             {
                 // If disposing equals true, dispose all managed
                 // and unmanaged resources.
                 if (disposing)
                 {
                     // Dispose managed resources.
                     chsignals.Clear();
                     allsignals.Clear();
                     hardsignals.Clear();

                     calcparameters.Clear();
                     calcvariables.Clear();

                 }

                 // Call the appropriate methods to clean up
                 // unmanaged resources here.
                 // If disposing is false,
                 // only the following code is executed.


                 // Note disposing has been done.
                 disposed = true;

             }
         }
         public void Dispose()
         {
             Dispose(true);
             // This object will be cleaned up by the Dispose method.
             // Therefore, you should call GC.SupressFinalize to
             // take this object off the finalization queue
             // and prevent finalization code for this object
             // from executing a second time.
             GC.SuppressFinalize(this);
         }



         ~ItemSignalStation()
         {
             // Do not re-create Dispose clean-up code here.
             // Calling Dispose(false) is optimal in terms of
             // readability and maintainability.
             Dispose(false);
         }

         public void initchannel()
         {
             if (machinekind == 0)
             {
                 initchannel标准();
             }
             if (machinekind == 1)
             {
                initchannel标准();
            }
             if (machinekind == 2)
             {
                 initchannel岩石();
             }
             if (machinekind ==3)
            {
                initchannel标准();
            }
             if (machinekind ==4)
            {
                initchannel标准();
            }
            if (machinekind ==5)
            {
                initchannel标准();
            }

            if (machinekind ==6)
            {
                this.initchannel标准XL双通道();
            }
           

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                freqsignal.cName = freqsignal.LName[0];
                undefinesignal.cName = undefinesignal.LName[0];

            }
            else
            {
                freqsignal.cName = freqsignal.LName[1];
                undefinesignal.cName = undefinesignal.LName[1];
            }

        }

       

        public void initchannel刚度台()
        {
            int i = 0;
            chsignals.Clear();
            allsignals.Clear();
            hardsignals.Clear();
            zerosignals.Clear();
            originsignals.Clear();

            ItemSignal isi = new ItemSignal();
            isi.cName = "位移";
            isi.LName[0] = "位移";
            isi.LName[1] = "Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[0];
            isi.SamplingMode = ChannelSampling[0];

            chsignals.Add(isi);
            allsignals.Add(isi);



            if (ChannelControl[0] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "位移峰值";
            isi.LName[0] = "位移峰值";
            isi.LName[1] = "Max Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Max";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "位移谷值";
            isi.LName[0] = "位移谷值";
            isi.LName[1] = "Min Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Min";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力1";
            isi.LName[0] = "力1";
            isi.LName[1] = "Force";
            isi.originprecise = 3;
            isi.SignName = "Ch Load";
            isi.cUnitKind = 1;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[1];
            isi.SamplingMode = ChannelSampling[1];
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[1] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力1峰值";
            isi.LName[0] = "力1峰值";
            isi.LName[1] = "Max Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Max";
            isi.cUnitKind = 1;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力1谷值";
            isi.LName[0] = "力1谷值";
            isi.LName[1] = "Min Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Min";
            isi.cUnitKind = 1;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力2";
            isi.LName[0] = "力2";
            isi.LName[1] = "Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext";
            isi.cUnitKind = 1;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[2];
            isi.SamplingMode = ChannelSampling[2];
            chsignals.Add(isi);
            allsignals.Add(isi);

            if (ChannelControl[2] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力2峰值";
            isi.LName[0] = "力2峰值";
            isi.LName[1] = "Max Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Max";
            isi.cUnitKind = 1;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "力2谷值";
            isi.LName[0] = "力2谷值";
            isi.LName[1] = "Min Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Min";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = "变形1";
            isi.LName[0] = "变形1";
            isi.LName[1] = "Deformation 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor4";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[3];
            isi.fullminbase = -ChannelRange[3];
            isi.ClosedControl = ChannelControl[3];
            isi.SamplingMode = ChannelSampling[3];

            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[3] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形2";
            isi.LName[0] = "变形2";
            isi.LName[1] = "Measure Channel 1";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor5";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[4];
            isi.fullminbase = -ChannelRange[4];
            isi.ClosedControl = ChannelControl[4];
            isi.SamplingMode = ChannelSampling[4];

            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[4] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形3";
            isi.LName[0] = "变形3";
            isi.LName[1] = "Measure Channel 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor6";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[5];
            isi.fullminbase = -ChannelRange[5];
            isi.ClosedControl = ChannelControl[5];
            isi.SamplingMode = ChannelSampling[5];
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[5] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形4";
            isi.LName[0] = "变形4";
            isi.LName[1] = "Measure Channel 3";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor7";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[6];
            isi.fullminbase = -ChannelRange[6];
            isi.ClosedControl = ChannelControl[6];
            isi.SamplingMode = ChannelSampling[6];

            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[6] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();
            isi.cName = "测量1";
            isi.LName[0] = "测量1";
            isi.LName[1] = "Measure Channel 4";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor8";
            isi.cUnitKind = 5;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[7];
            isi.fullminbase = -ChannelRange[7];
            isi.ClosedControl = ChannelControl[7];
            isi.SamplingMode = ChannelSampling[7];

            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[7] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();

            isi.cName = "时间";
            isi.LName[0] = "时间";
            isi.LName[1] = "Time";
            isi.originprecise = 3;
            isi.SignName = "Ch Time";
            isi.cUnitKind = 4;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 316000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();

            isi.cName = "次数";
            isi.LName[0] = "次数";
            isi.LName[1] = "Count";
            isi.originprecise = 0;
            isi.SignName = "Ch Count";
            isi.cUnitKind = 20;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 1000000000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);


           




            if (CComLibrary.GlobeVal.filesave == null)
            {

            }

            else
            {

                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {

                    isi = (ItemSignal)CComLibrary.GlobeVal.filesave.muserchannel[i].myitemsignal.Clone();
                    isi.cName = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[0] = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[1] = "";
                    isi.originprecise = 3;
                    isi.SignName = "Ch User" + i.ToString().Trim();
                    allsignals.Add(isi);


                }
            }




            datalist.Clear();




            for (i = 0; i < allsignals.Count; i++)
            {
                datalist.Add(allsignals[i]);

            }


            for (i = 0; i < datalist.Count; i++)
            {
                datalist[i].EdcId = i;
             

            }


        }

        public void initchannel标准()
        {
            int i = 0;
            chsignals.Clear();
            allsignals.Clear();
            hardsignals.Clear();
            zerosignals.Clear();
            originsignals.Clear();

            ItemSignal isi = new ItemSignal();

            //位移
            isi.cName = ChannelName[0];
            isi.LName[0] = ChannelName[0];
            isi.LName[1] = "Displacement";
            

            isi.originprecise = 3;
            isi.SignName = "Ch Disp";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

          
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[0];
            isi.SamplingMode = ChannelSampling[0];
            isi.EdcChannleSel = ChannelControlChannel[0];


            chsignals.Add(isi);
            allsignals.Add(isi);



            if (ChannelControl[0] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[0]+ "峰值";

         
            isi.LName[0] = ChannelName[0]+ "峰值";
            isi.LName[1] = "Max Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Max";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[0]+ "谷值";
            isi.LName[0] = ChannelName[0]+"谷值";
            isi.LName[1] = "Min Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Min";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1];
            
            isi.LName[0] = ChannelName[1];
            isi.LName[1] = "Force";
            isi.originprecise = 3;
            isi.SignName = "Ch Load";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[1];
            isi.SamplingMode = ChannelSampling[1];
            isi.EdcChannleSel = ChannelControlChannel[1];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[1] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1]+ "峰值";
            isi.LName[0] = ChannelName[1]+"峰值";
            isi.LName[1] = "Max Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Max";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1]+ "谷值";
            isi.LName[0] = ChannelName[1]+"谷值";
            isi.LName[1] = "Min Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Min";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[2];
            isi.LName[0] = ChannelName[2];
            isi.LName[1] = "Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
          
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[2];
            isi.SamplingMode = ChannelSampling[2];
            isi.EdcChannleSel = ChannelControlChannel[2];

            chsignals.Add(isi);
            allsignals.Add(isi);

            if (ChannelControl[2] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[2]+ "峰值";
            isi.LName[0] = ChannelName[2]+"峰值";
            isi.LName[1] = "Max Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Max";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName =  ChannelName[2]+"谷值";
            isi.LName[0] = ChannelName[2]+"谷值";
            isi.LName[1] = "Min Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Min";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[3];
            isi.LName[0] =ChannelName[3];
            isi.LName[1] = "Deformation 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor4";
            isi.cUnitKind = ChannelDimension[3];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[3];
            isi.fullminbase = -ChannelRange[3];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

          
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[3];
            isi.SamplingMode = ChannelSampling[3];
            isi.EdcChannleSel = ChannelControlChannel[3];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[3] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[4];
            isi.LName[0] = ChannelName[4];
            isi.LName[1] = "Measurement 1";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor5";
            isi.cUnitKind = ChannelDimension[4];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[4];
            isi.fullminbase = -ChannelRange[4];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

          
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[4];
            isi.SamplingMode = ChannelSampling[4];
            isi.EdcChannleSel = ChannelControlChannel[4];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[4] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[5];
            isi.LName[0] = ChannelName[5];
            isi.LName[1] = "Measurement 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor6";
            isi.cUnitKind = ChannelDimension[5];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[5];
            isi.fullminbase = -ChannelRange[5];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
           
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[5];
            isi.SamplingMode = ChannelSampling[5];
            isi.EdcChannleSel = ChannelControlChannel[5];
            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[5] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName =ChannelName[6];
            isi.LName[0] = ChannelName[6];
            isi.LName[1] = "Measurement 3";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor7";
            isi.cUnitKind = ChannelDimension[6];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[6];
            isi.fullminbase = -ChannelRange[6];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

         
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[6];
            isi.SamplingMode = ChannelSampling[6];
            isi.EdcChannleSel = ChannelControlChannel[6];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[6] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();
            isi.cName = ChannelName[7];
            isi.LName[0] = ChannelName[7];
            isi.LName[1] = "Measurement 4";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor8";
            isi.cUnitKind = ChannelDimension[7];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[7];
            isi.fullminbase = -ChannelRange[7];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

         
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[7];
            isi.SamplingMode = ChannelSampling[7];
            isi.EdcChannleSel = ChannelControlChannel[7];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[7] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();

            isi.cName = "时间";
            isi.LName[0] = "时间";
            isi.LName[1] = "Time";
            isi.originprecise = 3;
            isi.SignName = "Ch Time";
            isi.cUnitKind = 4;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 316000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();

            isi.cName = "次数";
            isi.LName[0] = "次数";
            isi.LName[1] = "Count";
            isi.originprecise = 0;
            isi.SignName = "Ch Count";
            isi.cUnitKind = 20;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 1000000000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();

            isi.cName = "命令";
            isi.LName[0] = "命令";
            isi.LName[1] = "Command";
            isi.originprecise = 4;
            isi.SignName = "Ch Command";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 1000000000000;
            isi.fullminbase = -100000000000;
            allsignals.Add(isi);
            originsignals.Add(isi);




            if (CComLibrary.GlobeVal.filesave == null)
            {

            }

            else
            {

                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {

                    isi = (ItemSignal)CComLibrary.GlobeVal.filesave.muserchannel[i].myitemsignal.Clone();
                    isi.cName = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[0] = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[1] = "";
                    isi.originprecise = 3;
                    isi.SignName = "Ch User" + i.ToString().Trim();
                    allsignals.Add(isi);


                }
            }




            datalist.Clear();




            for (i = 0; i < allsignals.Count; i++)
            {
                datalist.Add(allsignals[i]);

            }


            for (i = 0; i < datalist.Count; i++)
            {
                datalist[i].EdcId = i;


            }


            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                for (i = 0; i < hardsignals.Count; i++)
                {
                    hardsignals[i].cName = hardsignals[i].LName[0];
                }

                for (i = 0; i < chsignals.Count; i++)
                {
                    chsignals[i].cName = chsignals[i].LName[0];
                }
                for ( i=0;i<chsignals.Count;i++)
                {
                    allsignals[i].cName = allsignals[i].LName[0];
                }
            }
            else
            {
                for (i = 0; i < hardsignals.Count; i++)
                {
                    hardsignals[i].cName = hardsignals[i].LName[1];
                }
                for (i = 0; i < chsignals.Count; i++)
                {
                    chsignals[i].cName = chsignals[i].LName[1];
                }
                for (i = 0; i < allsignals.Count; i++)
                {
                    allsignals[i].cName = allsignals[i].LName[1];
                }
            }
            

        }
        public void initchannel标准XL双通道()
        {
            int i = 0;
            chsignals.Clear();
            allsignals.Clear();
            hardsignals.Clear();
            zerosignals.Clear();
            originsignals.Clear();

            ItemSignal isi = new ItemSignal();
            isi.cName = ChannelName[0];
            isi.LName[0] = ChannelName[0];
            isi.LName[1] = "Displacement1";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if(isi.cUnitKind ==1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if(isi.cUnitKind ==10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if(isi.cUnitKind ==11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
        
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[0];
            isi.SamplingMode = ChannelSampling[0];
            isi.EdcChannleSel = ChannelControlChannel[0];




            chsignals.Add(isi);
            allsignals.Add(isi);



            if (ChannelControl[0] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[0]+"峰值";
            isi.LName[0] = ChannelName[0]+"峰值";
            isi.LName[1] = "Max Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Max";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[0]+"谷值";
            isi.LName[0] = ChannelName[0]+"谷值";
            isi.LName[1] = "Min Displacement";

            isi.originprecise = 3;
            isi.SignName = "Ch Disp Min";
            isi.cUnitKind = ChannelDimension[0];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[0];
            isi.fullminbase = -ChannelRange[0];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1];
            isi.LName[0] = ChannelName[1];
            isi.LName[1] = "Force1";
            isi.originprecise = 3;
            isi.SignName = "Ch Load";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[1];
            isi.SamplingMode = ChannelSampling[1];
            isi.EdcChannleSel = ChannelControlChannel[1];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[1] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1] + "峰值";
            isi.LName[0] = ChannelName[1]+"峰值";
            isi.LName[1] = "Max Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Max";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[1] + "谷值";
            isi.LName[0] = ChannelName[1]+"谷值";
            isi.LName[1] = "Min Force";

            isi.originprecise = 3;
            isi.SignName = "Ch Load Min";
            isi.cUnitKind = ChannelDimension[1];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[1];
            isi.fullminbase = -ChannelRange[1];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[2];
            isi.LName[0] = ChannelName[2];
            isi.LName[1] = "pos 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[2];
            isi.SamplingMode = ChannelSampling[2];
            isi.EdcChannleSel = ChannelControlChannel[2];

            chsignals.Add(isi);
            allsignals.Add(isi);

            if (ChannelControl[2] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[2] + "峰值";
            isi.LName[0] = ChannelName[2]+"峰值";
            isi.LName[1] = "Max Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Max";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[2] + "谷值";
            isi.LName[0] = ChannelName[2]+"谷值";
            isi.LName[1] = "Min Deformation";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext Min";
            isi.cUnitKind = ChannelDimension[2];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[2];
            isi.fullminbase = -ChannelRange[2];
            allsignals.Add(isi);


            isi = new ItemSignal();
            isi.cName = ChannelName[3];
            isi.LName[0] = ChannelName[3];
            isi.LName[1] = "Force 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor4";
            isi.cUnitKind = ChannelDimension[3];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[3];
            isi.fullminbase = -ChannelRange[3];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
           
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[3];
            isi.SamplingMode = ChannelSampling[3];
            isi.EdcChannleSel = ChannelControlChannel[3];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[3] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[4];
            isi.LName[0] = ChannelName[4];
            isi.LName[1] = "Measure Channel 1";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor5";
            isi.cUnitKind = ChannelDimension[4];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[4];
            isi.fullminbase = -ChannelRange[4];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

         
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[4];
            isi.SamplingMode = ChannelSampling[4];
            isi.EdcChannleSel = ChannelControlChannel[4];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[4] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[5];
            isi.LName[0] = ChannelName[5];
            isi.LName[1] = "Measure Channel 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor6";
            isi.cUnitKind = ChannelDimension[5];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[5];
            isi.fullminbase = -ChannelRange[5];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

          
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[5];
            isi.SamplingMode = ChannelSampling[5];
            isi.EdcChannleSel = ChannelControlChannel[5];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[5] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = ChannelName[6];
            isi.LName[0] = ChannelName[6];
            isi.LName[1] = "Measure Channel 3";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor7";
            isi.cUnitKind = ChannelDimension[6];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[6];
            isi.fullminbase = -ChannelRange[6];
            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

           
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[6];
            isi.SamplingMode = ChannelSampling[6];
            isi.EdcChannleSel = ChannelControlChannel[6];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[6] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();
            isi.cName = ChannelName[7];
            isi.LName[0] = ChannelName[7];
            isi.LName[1] = "Measure Channel 4";

            isi.originprecise = 3;
            isi.SignName = "Ch Sensor8";
            isi.cUnitKind = ChannelDimension[7];
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = ChannelRange[7];
            isi.fullminbase = -ChannelRange[7];

            if (isi.cUnitKind == 0)
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }
            else if (isi.cUnitKind == 1)
            {
                isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 10)
            {
                isi.speedSignal = (ItemSignal)anglespeedsignal.Clone();
            }
            else if (isi.cUnitKind == 11)
            {
                isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
            }
            else
            {
                isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            }

           
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            isi.ClosedControl = ChannelControl[7];
            isi.SamplingMode = ChannelSampling[7];
            isi.EdcChannleSel = ChannelControlChannel[7];

            chsignals.Add(isi);
            allsignals.Add(isi);
            if (ChannelControl[7] == true)
            {
                hardsignals.Add(isi);
            }
            zerosignals.Add(isi);
            originsignals.Add(isi);



            isi = new ItemSignal();

            isi.cName = "时间";
            isi.LName[0] = "时间";
            isi.LName[1] = "Time";
            isi.originprecise = 3;
            isi.SignName = "Ch Time";
            isi.cUnitKind = 4;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 316000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();

            isi.cName = "次数";
            isi.LName[0] = "次数";
            isi.LName[1] = "Count";
            isi.originprecise = 0;
            isi.SignName = "Ch Count";
            isi.cUnitKind = 20;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 1000000000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);


            isi = new ItemSignal();

            isi.cName = "命令";
            isi.LName[0] = "命令";
            isi.LName[1] = "Command";
            isi.originprecise = 4;
            isi.SignName = "Ch Command";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 1000000000000;
            isi.fullminbase = -100000000000;
            allsignals.Add(isi);
            originsignals.Add(isi);




            if (CComLibrary.GlobeVal.filesave == null)
            {

            }

            else
            {

                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {

                    isi = (ItemSignal)CComLibrary.GlobeVal.filesave.muserchannel[i].myitemsignal.Clone();
                    isi.cName = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[0] = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    isi.LName[1] = "";
                    isi.originprecise = 3;
                    isi.SignName = "Ch User" + i.ToString().Trim();
                    allsignals.Add(isi);


                }
            }




            datalist.Clear();




            for (i = 0; i < allsignals.Count; i++)
            {
                datalist.Add(allsignals[i]);

            }


            for (i = 0; i < datalist.Count; i++)
            {
                datalist[i].EdcId = i;


            }


        }
      

    

        public void initchannel岩石()
         {
             int i=0;
             chsignals.Clear();
             allsignals.Clear();
             hardsignals.Clear();
             zerosignals.Clear();
             originsignals.Clear();

             ItemSignal isi = new ItemSignal();
             isi.cName = "位移";
             isi.LName[0] = "位移";
             isi.LName[1] = "Disp.";

             isi.originprecise = 3;
             isi.SignName = "Ch Disp";
             isi.cUnitKind = 0;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 75;
             isi.fullminbase = -75;
             isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
             hardsignals.Add(isi);
             zerosignals.Add(isi);
             originsignals.Add(isi);

             isi = new ItemSignal();
             isi.cName = "位移速率";
             isi.LName[0] = "位移速率";
             isi.LName[1] = "Disp Speed";

             isi.originprecise = 3;
             isi.SignName = "Ch Disp Speed";
             isi.cUnitKind = 2;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 1000;
             isi.fullminbase = 0;
             
          
             allsignals.Add(isi);
          
             originsignals.Add(isi);


             isi = new ItemSignal();
             isi.cName = "负荷";
             isi.LName[0] = "负荷";
             isi.LName[1] = "Force";



             isi.originprecise = 3;
             isi.SignName = "Ch Load";
             isi.cUnitKind = 1;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 30;
             isi.fullminbase = -30;
             isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
             hardsignals.Add(isi);
             zerosignals.Add(isi);
             originsignals.Add(isi);


             isi = new ItemSignal();
             isi.cName = "负荷速率";
             isi.LName[0] = "负荷速率";
             isi.LName[1] = "Force Speed";

             isi.originprecise = 3;
             isi.SignName = "Ch Load Speed";
             isi.cUnitKind = 3;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 1000;
             isi.fullminbase = 0;


             allsignals.Add(isi);

             originsignals.Add(isi);



             isi = new ItemSignal();
             isi.cName = "变形";
             isi.LName[0] = "变形";
             isi.LName[1] = "Ext.";

             isi.originprecise = 3;
             isi.SignName = "Ch Ext";
             isi.cUnitKind = 0;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 5;
             isi.fullminbase = -5;
             isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             //chsignals.Add(isi);
             //allsignals.Add(isi);
             //hardsignals.Add(isi);
             //zerosignals.Add(isi);
             //originsignals.Add(isi);

             isi = new ItemSignal();

             isi.cName = "时间";
             isi.LName[0] = "时间";
             isi.LName[1] = "Time";
             isi.originprecise = 1;
             isi.SignName = "Ch Time";
             isi.cUnitKind = 4;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 316000000;
             isi.fullminbase = 0;
             allsignals.Add(isi);
             originsignals.Add(isi);

             //hardsignals.Add(isi);

             isi = new ItemSignal();
             isi.cName = "围压位移";
             isi.LName[0] = "围压位移";
             isi.LName[1] = "ambient pressure Disp. ";

             isi.originprecise = 3;
             isi.SignName = "ambient pressure Ch Disp";
             isi.cUnitKind = 0;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 75;
             isi.fullminbase = -75;
             isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
            
             zerosignals.Add(isi);

             originsignals.Add(isi);

             isi = new ItemSignal();
             isi.cName = "围压压力";
             isi.LName[0] = "围压压力";
             isi.LName[1] = "ambient pressure Force";



             isi.originprecise = 3;
             isi.SignName = "ambient pressure Ch Load";
             isi.cUnitKind = 15;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 30;
             isi.fullminbase = -30;
             isi.speedSignal = (ItemSignal)forcespeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
            hardsignals.Add(isi);
            zerosignals.Add(isi);
             originsignals.Add(isi);
             

             if (CComLibrary.GlobeVal.filesave == null)
             {

             }

             else
             {

                 for ( i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                 {
                 
                     isi = (ItemSignal)CComLibrary.GlobeVal.filesave.muserchannel[i].myitemsignal.Clone();
                     isi.cName = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                     isi.LName[0] = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                     isi.LName[1] = "";
                     isi.originprecise = 3;
                     isi.SignName = "Ch User" + i.ToString().Trim();
                     allsignals.Add(isi);


                 }
             }

           

            
             datalist.Clear();




             for (i = 0; i < allsignals.Count; i++)
             {
                 datalist.Add(allsignals[i]);

             }


             for (i = 0; i < datalist.Count; i++)
             {
                 datalist[i].EdcId = i;
               

             }

         }




        public void InitShape()
        {
            

            shapeitem c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "矩形";
            }
            else
            {
                c.shapename = "Rectangle";
            }

            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "宽度";
            c.sizeitem[0].LName[0] = "宽度";
            c.sizeitem[0].LName[1] = "Width";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;

            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "厚度";
            c.sizeitem[1].LName[0] = "厚度";
            c.sizeitem[1].LName[1] = "Thickness";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;


            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后宽度";
            c.sizeitem[3].LName[0] = "断后宽度";
            c.sizeitem[3].LName[1] = "Break Width";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;

            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "断后厚度";
            c.sizeitem[4].LName[0] = "断后厚度";
            c.sizeitem[4].LName[1] = "Break Thickness";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;

            shapelist.Add(c);

            c = new shapeitem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "圆形";

            }
            else
            {
                c.shapename = "Round";
            }

           

            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "直径";
            c.sizeitem[0].LName[0] = "直径";
            c.sizeitem[0].LName[1] = "Diameter";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "None";
            c.sizeitem[1].LName[0] = "None";
            c.sizeitem[1].LName[1] = "None";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;


            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后直径";
            c.sizeitem[3].LName[0] = "断后直径";
            c.sizeitem[3].LName[1] = "Break Diameter";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;
            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "None";
            c.sizeitem[4].LName[0] = "None";
            c.sizeitem[4].LName[1] = "None";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;

            shapelist.Add(c);




            c = new shapeitem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "双剪切环";
            }
            else
            {
                c.shapename = "Double shear ring";
            }
            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "直径";
            c.sizeitem[0].LName[0] = "直径";
            c.sizeitem[0].LName[1] = "Diameter";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "None";
            c.sizeitem[1].LName[0] = "None";
            c.sizeitem[1].LName[1] = "None";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;

            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后直径";
            c.sizeitem[3].LName[0] = "断后直径";
            c.sizeitem[3].LName[1] = "Break Diameter";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;
            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "None";
            c.sizeitem[4].LName[0] = "None";
            c.sizeitem[4].LName[1] = "None";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;


            shapelist.Add(c);

            c = new shapeitem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "管状";
            }
            else
            {
                c.shapename = "Tube";
            }
            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "外径";
            c.sizeitem[0].LName[0] = "外径";
            c.sizeitem[0].LName[1] = "Outer Diameter";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "壁厚";
            c.sizeitem[1].LName[0] = "壁厚";
            c.sizeitem[1].LName[1] = "Wall Thickness";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;

            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后外径";
            c.sizeitem[3].LName[0] = "断后外径";
            c.sizeitem[3].LName[1] = "Break Outer Diameter";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;
            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "断后壁厚";
            c.sizeitem[4].LName[0] = "断后壁厚";
            c.sizeitem[4].LName[1] = "Break Wall Thickness";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;

            shapelist.Add(c);

            c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "不规则形状";
            }
            else
            {
                c.shapename = "Irregular";
            }
            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "横截面积";
            c.sizeitem[0].LName[0] = "横截面积";
            c.sizeitem[0].LName[1] = "Cross sectiional area";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "None";
            c.sizeitem[1].LName[0] = "None";
            c.sizeitem[1].LName[1] = "None";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;

            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后横截面积";
            c.sizeitem[3].LName[0] = "断后横截面积";
            c.sizeitem[3].LName[1] = "Break Cross sectiional area";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;
            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "None";
            c.sizeitem[4].LName[0] = "None";
            c.sizeitem[4].LName[1] = "None";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;



            shapelist.Add(c);


            c = new shapeitem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "纤维";
            }
            else
            {
                c.shapename = "Fiber";
            }
            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "线密度";
            c.sizeitem[0].LName[0] = "线密度";
            c.sizeitem[0].LName[1] = "Linear density";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "None";
            c.sizeitem[1].LName[0] = "None";
            c.sizeitem[1].LName[1] = "None";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "长度";
            c.sizeitem[2].LName[0] = "长度";
            c.sizeitem[2].LName[1] = "Length";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;



            c.sizeitem[3].cUnitKind = 0;
            c.sizeitem[3].cName = "断后线密度";
            c.sizeitem[3].LName[0] = "断后线密度";
            c.sizeitem[3].LName[1] = "Break Linear density";
            c.sizeitem[3].cUnitsel = 0;
            c.sizeitem[3].InitUnit();
            c.sizeitem[3].fullmaxbase = 10000;
            c.sizeitem[3].fullminbase = 0;
            c.sizeitem[3].originprecise = 3;

            c.sizeitem[4].cUnitKind = 0;
            c.sizeitem[4].cName = "None";
            c.sizeitem[4].LName[0] = "None";
            c.sizeitem[4].LName[1] = "None";
            c.sizeitem[4].cUnitsel = 0;
            c.sizeitem[4].InitUnit();
            c.sizeitem[4].fullmaxbase = 10000;
            c.sizeitem[4].fullminbase = 0;
            c.sizeitem[4].originprecise = 3;

            c.sizeitem[5].cUnitKind = 0;
            c.sizeitem[5].cName = "断后长度";
            c.sizeitem[5].LName[0] = "断后长度";
            c.sizeitem[5].LName[1] = "Break Length";
            c.sizeitem[5].cUnitsel = 0;
            c.sizeitem[5].InitUnit();
            c.sizeitem[5].fullmaxbase = 10000;
            c.sizeitem[5].fullminbase = 0;
            c.sizeitem[5].originprecise = 3;

            shapelist.Add(c);


            c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "剥离90度";
            }
            else
            {
                c.shapename = "90 degree stripping";
            }
            c.sizeitem[0].cUnitKind = 0;
            c.sizeitem[0].cName = "宽度";
            c.sizeitem[0].LName[0] = "宽度";
            c.sizeitem[0].LName[1] = "Width";
            c.sizeitem[0].cUnitsel = 0;
            c.sizeitem[0].InitUnit();
            c.sizeitem[0].fullmaxbase = 10000;
            c.sizeitem[0].fullminbase = 0;
            c.sizeitem[0].originprecise = 3;

            c.sizeitem[1].cUnitKind = 0;
            c.sizeitem[1].cName = "None";
            c.sizeitem[1].LName[0] = "None";
            c.sizeitem[1].LName[1] = "None";
            c.sizeitem[1].cUnitsel = 0;
            c.sizeitem[1].InitUnit();
            c.sizeitem[1].fullmaxbase = 10000;
            c.sizeitem[1].fullminbase = 0;
            c.sizeitem[1].originprecise = 3;

            c.sizeitem[2].cUnitKind = 0;
            c.sizeitem[2].cName = "None";
            c.sizeitem[2].LName[0] = "None";
            c.sizeitem[2].LName[1] = "None";
            c.sizeitem[2].cUnitsel = 0;
            c.sizeitem[2].InitUnit();
            c.sizeitem[2].fullmaxbase = 10000;
            c.sizeitem[2].fullminbase = 0;
            c.sizeitem[2].originprecise = 3;

            shapelist.Add(c);

            c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "剥离180度";
            }
            else
            {
                c.shapename = "180 degree stripping";
            }
             c.sizeitem[0].cUnitKind = 0;
             c.sizeitem[0].cName = "宽度";
             c.sizeitem[0].LName[0] = "宽度";
             c.sizeitem[0].LName[1] = "Width";
             c.sizeitem[0].cUnitsel = 0;
             c.sizeitem[0].InitUnit();
             c.sizeitem[0].fullmaxbase = 10000;
             c.sizeitem[0].fullminbase = 0;
             c.sizeitem[0].originprecise = 3;

             c.sizeitem[1].cUnitKind = 0;
             c.sizeitem[1].cName = "None";
             c.sizeitem[1].LName[0] = "None";
             c.sizeitem[1].LName[1] = "None";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "None";
             c.sizeitem[2].LName[0] = "None";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);

             c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {

                c.shapename = "T剥离";
            }
            else
            {
                c.shapename = "T stripping";
            }

             c.sizeitem[0].cUnitKind = 0;
             c.sizeitem[0].cName = "宽度";
             c.sizeitem[0].LName[0] = "宽度";
             c.sizeitem[0].LName[1] = "Width";
             c.sizeitem[0].cUnitsel = 0;
             c.sizeitem[0].InitUnit();
             c.sizeitem[0].fullmaxbase = 10000;
             c.sizeitem[0].fullminbase = 0;
             c.sizeitem[0].originprecise = 3;

             c.sizeitem[1].cUnitKind = 0;
             c.sizeitem[1].cName = "None";
             c.sizeitem[1].LName[0] = "None";
             c.sizeitem[1].LName[1] = "None";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "None";
             c.sizeitem[2].LName[0] = "None";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);

             c = new shapeitem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                c.shapename = "撕裂";
            }
            else
            {
                c.shapename = "Tear";
            }
             c.sizeitem[0].cUnitKind = 0;
             c.sizeitem[0].cName = "宽度";
             c.sizeitem[0].LName[0] = "宽度";
             c.sizeitem[0].LName[1] = "Width";
             c.sizeitem[0].cUnitsel = 0;
             c.sizeitem[0].InitUnit();
             c.sizeitem[0].fullmaxbase = 10000;
             c.sizeitem[0].fullminbase = 0;
             c.sizeitem[0].originprecise = 3;

             c.sizeitem[1].cUnitKind = 0;
             c.sizeitem[1].cName = "厚度";
             c.sizeitem[1].LName[0] = "厚度";
             c.sizeitem[1].LName[1] = "Thickness";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "None";
             c.sizeitem[2].LName[0] = "None";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                for (int j = 0; j < shapelist.Count; j++)
                {
                    for (int k = 0; k < shapelist[j].sizeitem.Length; k++)
                    {
                        shapelist[j].sizeitem[k].cName = shapelist[j].sizeitem[k].LName[0];
                    }
                }
            }
            else
            {
                for (int j = 0; j < shapelist.Count; j++)
                {
                    for (int k = 0; k < shapelist[j].sizeitem.Length; k++)
                    {
                        shapelist[j].sizeitem[k].cName = shapelist[j].sizeitem[k].LName[1];
                    }
                }
            }
         }

         public void structcopy_RawDataData(ref RawDataData a, RawDataStruct b)
         {
             a.data0 = b.data[0];
             a.data1 = b.data[1];
             a.data2 = b.data[2];
             a.data3 = b.data[3];
             a.data4 = b.data[4];
             a.data5 = b.data[5];
             a.data6 = b.data[6];
             a.data7 = b.data[7];
             a.data8 = b.data[8];
             a.data9 = b.data[9];
             a.data10 = b.data[10];
             a.data11 = b.data[11];
             a.data12 = b.data[12];
             a.data13 = b.data[13];
             a.data14 = b.data[14];
             a.data15 = b.data[15];
             a.data16 = b.data[16];
             a.data17 = b.data[17];
             a.data18 = b.data[18];
             a.data19 = b.data[19];
             a.data20 = b.data[20];
             a.data21 = b.data[21];
             a.data22 = b.data[22];
             a.data23 = b.data[23];
             a.hardlimitlow = b.hardlimitlow;
             a.hardlimitup = b.hardlimitup;
             a.softlimitlow = b.softlimitlow;
             a.softlimitup = b.softlimitup;
             a.ctrlstate1 = b.ctrlstate1;
             a.ctrlstate2 = b.ctrlstate2;
             a.ctrl_state_s = b.ctrl_state_s;
             a.ctrl_state_f = b.ctrl_state_f;
             a.ctrl_state_e = b.ctrl_state_e;
             a.ctrl_halt = b.ctrl_halt;
             a.ctrl_down = b.ctrl_down;
             a.ctrl_up = b.ctrl_up;
             a.ctrl_move = b.ctrl_move;
             a.ctrl_ready = b.ctrl_ready;
             a.ctrl_soft_set = b.ctrl_soft_set;
             a.ctrl_lower_sft_s = b.ctrl_lower_sft_s;
             a.ctrl_lower_sft_f = b.ctrl_lower_sft_f;
             a.ctrl_lower_sft_e = b.ctrl_lower_sft_e;
             a.ctrl_upper_sft_s = b.ctrl_upper_sft_s;
             a.ctrl_upper_sft_f = b.ctrl_upper_sft_f;
             a.ctrl_upper_sft_e = b.ctrl_upper_sft_e;


             return;
         }
         public void structcopy_RawDataStruct(RawDataData a, ref  RawDataStruct b)
         {
             b.data[0] = a.data0;
             b.data[1] = a.data1;
             b.data[2] = a.data2;
             b.data[3] = a.data3;
             b.data[4] = a.data4;
             b.data[5] = a.data5;
             b.data[6] = a.data6;
             b.data[7] = a.data7;
             b.data[8] = a.data8;
             b.data[9] = a.data9;
             b.data[10] = a.data10;
             b.data[11] = a.data11;
             b.data[12] = a.data12;
             b.data[13] = a.data13;
             b.data[14] = a.data14;
             b.data[15] = a.data15;
             b.data[16] = a.data16;
             b.data[17] = a.data17;
             b.data[18] = a.data18;
             b.data[19] = a.data19;
             b.data[20] = a.data20;
             b.data[21] = a.data21;
             b.data[22] = a.data22;
             b.data[23] = a.data23;
             b.hardlimitlow = a.hardlimitlow;
             b.hardlimitup = a.hardlimitup;
             b.softlimitlow = a.softlimitlow;
             b.softlimitup = a.softlimitup;
             b.ctrlstate1 = a.ctrlstate1;
             b.ctrlstate2 = a.ctrlstate2;
             b.ctrl_state_s = a.ctrl_state_s;
             b.ctrl_state_f = a.ctrl_state_f;
             b.ctrl_state_e = a.ctrl_state_e;
             b.ctrl_halt = a.ctrl_halt;
             b.ctrl_down = a.ctrl_down;
             b.ctrl_up = a.ctrl_up;
             b.ctrl_move = a.ctrl_move;
             b.ctrl_ready = a.ctrl_ready;
             b.ctrl_soft_set = a.ctrl_soft_set;
             b.ctrl_lower_sft_s = a.ctrl_lower_sft_s;
             b.ctrl_lower_sft_f = a.ctrl_lower_sft_f;
             b.ctrl_lower_sft_e = a.ctrl_lower_sft_e;
             b.ctrl_upper_sft_s = a.ctrl_upper_sft_s;
             b.ctrl_upper_sft_f = a.ctrl_upper_sft_f;
             b.ctrl_upper_sft_e = a.ctrl_upper_sft_e;

             return;
         }
         public ItemSignalStation(int m)
         {
             machinekind = m;
             ItemSignal isi;
             //teststep = new List<CTestStep>();

             shapelist = new List<shapeitem>();

             InitShape();

             chsignals = new List<ItemSignal>();

             allsignals = new List<ItemSignal>();

             TestkindList = new List<string>();

             originsignals = new List<ItemSignal>();


             hardsignals = new List<ItemSignal>();
             zerosignals = new List<ItemSignal>();

             calcparameters = new List<ItemCalcedSignal>();
             calcvariables = new List<ItemCalcedSignal>();

             signalskindlist = new List<ItemSignal>();
            ChannelName = new string[20];

            ChannelControl = new bool[20];
            ChannelDimension = new int[20];
            ChannelRange = new double[20];
            ChannelSampling = new int[20];
            ChannelControlChannel = new int[20];

            for (int i = 0; i <= 18; i++)
             {
                 isi = new ItemSignal();
                 isi.cUnitKind = i;
                 isi.cUnitsel = 0;
                 isi.InitUnit();
                 signalskindlist.Add(isi);
               
             }

             SignalsNames = new String[signalskindlist.Count];
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                SignalsNames[0] = "长度";
                SignalsNames[1] = "力";
                SignalsNames[2] = "长度速度";
                SignalsNames[3] = "力速度";
                SignalsNames[4] = "时间";
                SignalsNames[5] = "电压";
                SignalsNames[6] = "频率";
                SignalsNames[7] = "段数";
                SignalsNames[8] = "pid";
                SignalsNames[9] = "命令";
                SignalsNames[10] = "角度";
                SignalsNames[11] = "扭矩";
                SignalsNames[12] = "角度速度";
                SignalsNames[13] = "扭矩速度";
                SignalsNames[14] = "温度";
                SignalsNames[15] = "应力";
                SignalsNames[16] = "流量";
                SignalsNames[17] = "刚度";
                SignalsNames[18] = "应变";

                SignalsNames_Count = 18;


                TestkindList.Add("拉伸");
                TestkindList.Add("拉伸蠕变松弛");
                TestkindList.Add("拉伸程序块循环");
                TestkindList.Add("金属");
                TestkindList.Add("沥青");

                TestkindList.Add("压缩");
                TestkindList.Add("压缩蠕变松弛");
                TestkindList.Add("压缩程序块");

                TestkindList.Add("弯曲");
                TestkindList.Add("弯曲蠕变松弛");
                TestkindList.Add("剥离");
                TestkindList.Add("撕裂");
                TestkindList.Add("摩擦");
                TestkindList.Add("扭转");
                TestkindList.Add("岩石压缩");
            }
            else
            {
                SignalsNames[0] = "Length";
                SignalsNames[1] = "Force";
                SignalsNames[2] = "Speed of length";
                SignalsNames[3] = "Force velocity";
                SignalsNames[4] = "Time";
                SignalsNames[5] = "Voltage";
                SignalsNames[6] = "Freq";
                SignalsNames[7] = "Sections";
                SignalsNames[8] = "pid";
                SignalsNames[9] = "Command";
                SignalsNames[10] = "Angle";
                SignalsNames[11] = "Torque";
                SignalsNames[12] = "Angular velocity";
                SignalsNames[13] = "Torque speed";
                SignalsNames[14] = "Temperature";
                SignalsNames[15] = "Stress";
                SignalsNames[16] = "Flow";
                SignalsNames[17] = "Stiffness";
                SignalsNames[18] = "Strain";

                SignalsNames_Count = 18;

                TestkindList.Add("Tensile");
                TestkindList.Add("Tensile creep relaxation");
                TestkindList.Add("Tensile fatigue");
                TestkindList.Add("Metal");
                TestkindList.Add("Pitch");

                TestkindList.Add("Compress");
                TestkindList.Add("Compressive creep relaxation");
                TestkindList.Add("Compression fatigue");

                TestkindList.Add("Bend");
                TestkindList.Add("Flexural creep relaxation");
                TestkindList.Add("Peel");
                TestkindList.Add("Tearing");
                TestkindList.Add("Friction");
                TestkindList.Add("Torsion");
                TestkindList.Add("Rock compression");
            }

             LName = new string[10];


             isi = new ItemSignal();
             isi.cName = "命令频率";
             isi.LName[0] = "命令频率";
             isi.LName[1] = "Command frequency";

             isi.originprecise = 3;
             isi.SignName = "Ch Command frequency";
             isi.cUnitKind = 6;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 10000;
             isi.fullminbase = 0;

             freqsignal = new ItemSignal();
             freqsignal.originprecise = 3;
             freqsignal.cName = "频率";
             freqsignal.LName[0] = "频率";
             freqsignal.LName[1] = "Freq";
             freqsignal.SignName = "Ch Freq";
             freqsignal.cUnitKind = 6;
             freqsignal.cUnitsel = 0;
             freqsignal.InitUnit();
             freqsignal.fullmaxbase = 50;
             freqsignal.fullminbase = 0;

             timesignal = new ItemSignal();
             timesignal.cName = "时间";
             timesignal.LName[0] = "时间";
             timesignal.LName[1] = "Time";
             timesignal.originprecise = 1;
             timesignal.SignName = "Time";
             timesignal.cUnitKind = 4;
             timesignal.cUnitsel = 0;
             timesignal.InitUnit();
             timesignal.fullmaxbase = 316000000;
             timesignal.fullminbase = 0;

             shorttimesignal = new ItemSignal();
             shorttimesignal.cName = "短时间";
             shorttimesignal.LName[0] = "短时间";
             shorttimesignal.LName[1] = "Short Time";
             shorttimesignal.originprecise = 1;
             shorttimesignal.SignName = "Short Time";
             shorttimesignal.cUnitKind = 4;
             shorttimesignal.cUnitsel = 0;
             shorttimesignal.InitUnit();
             shorttimesignal.fullmaxbase = 1000;
             shorttimesignal.fullminbase = 0;

             lengthspeedsignal = new ItemSignal();
             lengthspeedsignal.cName = "距离速度";
             lengthspeedsignal.LName[0] = "距离速度";
             lengthspeedsignal.LName[1] = "length speed";

             lengthspeedsignal.originprecise = 3;
             lengthspeedsignal.SignName = "length speed";
             lengthspeedsignal.cUnitKind = 2;
             lengthspeedsignal.cUnitsel = 0;
             lengthspeedsignal.InitUnit();
             lengthspeedsignal.fullmaxbase = 10000;
             lengthspeedsignal.fullminbase = 0;

             anglespeedsignal = new ItemSignal();
             anglespeedsignal.cName = "角度速度";
             anglespeedsignal.LName[0] = "角度速度";
             anglespeedsignal.LName[1] = "angle speed";

             anglespeedsignal.originprecise = 3;
             anglespeedsignal.SignName = "angle speed";
             anglespeedsignal.cUnitKind = 12;
             anglespeedsignal.cUnitsel = 0;
             anglespeedsignal.InitUnit();
             anglespeedsignal.fullmaxbase = 10000;
             anglespeedsignal.fullminbase = 0;

             torquespeedsignal = new ItemSignal();
             torquespeedsignal.cName = "扭矩速度";
             torquespeedsignal.LName[0] = "扭矩速度";
             torquespeedsignal.LName[1] = "torque speed";

             torquespeedsignal.originprecise = 3;
             torquespeedsignal.SignName = "torque speed";
             torquespeedsignal.cUnitKind = 13;
             torquespeedsignal.cUnitsel = 0;
             torquespeedsignal.InitUnit();
             torquespeedsignal.fullmaxbase = 10000;
             torquespeedsignal.fullminbase = 0;

             forcespeedsignal = new ItemSignal();
             forcespeedsignal.cName = "力速度";
             forcespeedsignal.LName[0] = "力速度";
             forcespeedsignal.LName[1] = "length speed";

             forcespeedsignal.originprecise = 3;
             forcespeedsignal.SignName = "length speed";
             forcespeedsignal.cUnitKind = 3;
             forcespeedsignal.cUnitsel = 0;
             forcespeedsignal.InitUnit();
             forcespeedsignal.fullmaxbase = 10000;
             forcespeedsignal.fullminbase = 0;

             countsignal = new ItemSignal();
             countsignal.cName = "计数";
             countsignal.LName[0] = "计数";
             countsignal.LName[1] = "Count";

             countsignal.originprecise = 0;
             countsignal.SignName = "Count";
             countsignal.cUnitKind = 7;
             countsignal.cUnitsel = 0;
             countsignal.InitUnit();
             countsignal.fullmaxbase = 10000000000000;
             countsignal.fullminbase = 0;


             undefinesignal = new ItemSignal();
             undefinesignal.cName = "未定义";
             undefinesignal.LName[0] = "未定义";
             undefinesignal.LName[1] = "undefine";

             undefinesignal.originprecise = 0;
             undefinesignal.SignName = "undefine";
             undefinesignal.cUnitKind = 8;
             undefinesignal.cUnitsel = 0;
             undefinesignal.InitUnit();
             undefinesignal.fullmaxbase = 100;
             undefinesignal.fullminbase = -100;

             pidfsignal = new ItemSignal();
             pidfsignal.cName = "pidf";
             pidfsignal.LName[0] = "pidf";
             pidfsignal.LName[1] = "pidf";
             pidfsignal.originprecise = 2;
             pidfsignal.SignName = "PIDF";
             pidfsignal.cUnitKind = 8;
             pidfsignal.cUnitsel = 0;
             pidfsignal.InitUnit();
             pidfsignal.fullmaxbase = 32767;
             pidfsignal.fullminbase = 0;

           
             

             initchannel();
             initdatalist();
         }



     }
    public sealed class m_Global
    {

        public static  List<ECanTest.xyz> madlist = new List<ECanTest.xyz>();
    
        public static Boolean savefile = false;

        public static ClsStaticStation.ItemSignalStation  mycls;

        public static double mload;
        public static double mpos;
        public static double mext;
        public static double mtime;
      
        public static double msensor4;
        public static double msensor5;
        public static double msensor6;
        public static double msensor7;
        public static double msensor8;


        public static Boolean mvalid = false; //判断计算是否有效

        public static double mload1;
        public static double mpos1;

        public static double[] mresult=new Double[100] ;

        public static double mwave;// 仿函数发生器 

        public static int  m_runstate=0;// doli控制器时运行状态
        
    }
    [Serializable]
    public class ItemBaseSignal : ICloneable
    {
        public int imageindex = 0;
        public int level = 0;
        public int parent = 0;

      

        public bool boolnode = false;
        public double correct_coefficient = 1;//修正系数
        public ItemBaseSignal()
        {

           
        }

        public virtual Object Clone()
        {
            return this.MemberwiseClone();

        }

    }
    [Serializable]
    public class ItemCalcedSignal : ItemSignal //计算信号类
    {
        public bool enabled = false;

        private string mcName;
        public string cName //信号名称
    {
        get { return mcName; }
        set { mcName = value; }

    }

        public string[] LName;


        public string _varstring = "";
        public string _programstring = "";

        public int calcedresultindex = 0;

        public ItemCalcedSignal()
        {
            LName = new string[10];

        }
        public Object Clone()
        {
            return this.MemberwiseClone();

        }

    }
    [Serializable]
    public class ItemSignal : ItemBaseSignal, IDisposable  //模拟信号类
    {

        public int SensorId;// 备用


        public int originprecise;//小数点位数
        public int Resolution;//精度位数
        public int precise=3;//小数点位数

        public ItemSignal speedSignal;

        private string mcName;
        public string cName = ""; //信号名称

        public string[] LName;


        public string[] cUnits; //单位


        public int cUnitKind;  //信号单位类型  //0 距离  1 力  2 距离速度 3 力速度  4 时间 5 电压  6 频率 // 7 段数 //8 Pid //9 命令 //10 //角度// 11扭矩 //12 角度速度 // 13 扭矩速度// 14 温度 //15 应力 16 //流量 17 //刚度 18//应变//19文本 20//次数
        public string SignName;//信号内部名称
        public double fullmaxbase;//默认单位下 满量程最大值 
        public double fullminbase;//默认单位下 满量程最小值


        public double basevalue = 0;//当前值基本单位

        public double cvalue = 0;//当前值

        public double cvaluemax = 0;//周期最大值
        public double cvaluemin = 0;//周期最大值

        public double bvaluemax = 0;//判断用最大值
        public double bvaluemin = 0;//判断用最小值

        public double rvaluemax = 0;//运行时最大值
        public double rvaluemin = 0;//运行时最小值

        public double p_cvaluemax = 0; //周期最大值
        public double p_cvaluemin = 0; //周期最小值

        public double p_bvaluemax = 0; //判断用最大值
        public double p_bvaluemin = 0;//判断用最小值

        public double p_rvaluemax = 0;//运行时最大值
        public double p_rvaluemin = 0;//运行时最小值


        public int EdcId = 0;           //Edc Id
        public int EdcChannleSel = 0;  //Edc通道   xl双通道指示

        public string cmdname = "";

        //private System.Windows.Forms.Timer mtimer;


       
        private int mcUnitsel;

        public int cUnitsel//信号单位选择
        {
            
            get { return mcUnitsel; }
            set
            {

                if (value != mcUnitsel)
                {
                    if (m_Global.savefile == true)
                    {

                    }
                    else
                    {


                        

                     double.TryParse(ChangeValue(sli_value, mcUnitsel, value),out basevalue);



                        sli_value = basevalue;


                        double.TryParse(ChangeValue(sli_max, mcUnitsel, value),out sli_max);

                        double.TryParse(ChangeValue(sli_min, mcUnitsel, value),out sli_min);


                    }

                }



                mcUnitsel = value;

            }
        }



        public int cUnitCount;//

        public double uplimit = 0;
        public double donwlimit = 0;


        public int uplimit_unitsel = 0;
        public int downlimit_unitsel = 0;

        public bool limitselect = false;
      


        public double sli_max = 0;
        public double sli_min = 0;
        public double sli_rangemax = 0;
        public double sli_rangemin = 0;
        public double sli_value = 0;

        private bool disposed = false;

        public double[] gsetvalue;
        public double[] gamendvalue;

        public bool ClosedControl = false;

        public int  SamplingMode = 0 ;//采集方式  0内部采集 1 外部采集
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //mtimer.Tick -= new EventHandler(mtimer_Tick);
                    //mtimer.Dispose();

                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.


                // Note disposing has been done.
                disposed = true;

            }
        }


        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }



        ~ItemSignal()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }




        public ItemSignal()
        {
            int i;

            LName = new string[10];

            cUnits = new string[30];

            for (i = 0; i < 30; i++)
            {
                cUnits[i] = "";
            }
            Resolution = 4;
            //mtimer = new System.Windows.Forms.Timer();
            //mtimer.Tick += new EventHandler(mtimer_Tick);

            // mtimer.Interval = 50;
            //mtimer.Enabled = true;

            gsetvalue = new double[20];
            gamendvalue = new double[20];
            for (i = 0; i < 20; i++)
            {
                gsetvalue[i] = 0;
                gamendvalue[i] = 0;
            }



        }

       


        void mtimer_Tick(object sender, EventArgs e)
        {

         
                cName = LName[CComLibrary.GlobeVal.languageselect];
          
            return;
        }

        public Object Clone()
        {
            return this.MemberwiseClone();

        }
        public ItemSignal(string mName, string mSignName, int mcUnitKind)
        {
            int i;
            cUnits = new string[30];

            for (i = 0; i < 30; i++)
            {
                cUnits[i] = "";
            }


            cName = mName;
            SignName = mSignName;
            cUnitCount = mcUnitKind;
            InitUnit();



        }




        public string format(double t, int fmt)
        {

            return t.ToString("F" + fmt);
        }

        public String GetOriValue(double oValue,int unit)  //求信号原始值
        {
            string s;
            double t;
            int old;

            old = cUnitsel;
            cUnitsel = unit;
            double m;
            double.TryParse(GetValue(1), out m);
            if (m < 0.0001)
            {
                t = 0;
            }
            else
            {
                t = oValue / m;
            }
            cUnitsel = 0;
            s = GetValue(t);
            cUnitsel = old;
            return (s);



        }

        public String GetOriValue(double oValue)  //求信号原始值
        {
            string s;
            double t;
            int old;

            old = cUnitsel;

            double m;
            double.TryParse(GetValue(1), out m);
            if (m < 0.0001)
            {
                t = 0;
            }
            else
            {
                t = oValue / m;
            }
            cUnitsel = 0;
            s = GetValue(t);
            cUnitsel = old;
            return (s);



        }



        public String ChangeValue(double oValue, int osel, int nsel)  //求信号换算值
        {
            string s="0";
            double t;
            int old;
            double m;

            old = mcUnitsel;
            mcUnitsel = osel;

            double.TryParse(GetValue(1), out m);
            try
            {
                t = oValue / m;
            }
            catch (Exception e)
            {
                //LogHelper.WriteLogError("错误", e);
                throw;
            }



            mcUnitsel = nsel;
            s = GetValue(t);

            if (s == "")
            {
                s = "0";
            }
            mcUnitsel = old;
            return (s);



        }


        public String GetValue(double cValueOrigin)  //求信号换算值
        {
            double t;

            t = 0;

            if (cUnitKind == 0)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise + 1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 1;
                    return format(t, precise);

                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0032808;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.03937;
                    precise = originprecise + 2;
                    return format(t, precise);

                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.000001;
                    precise = originprecise + 6;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise + 7;
                    return format(t, precise);

                }
                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.37;
                    precise = originprecise;
                    return format(t, precise);

                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.2137e-007;
                    precise = originprecise + 7;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 1)
            {

                if (mcUnitsel == 0)
                {

                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise +1;
                    return format(t, precise);
                }


                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 1 - 3;
                    return format(t, precise);

                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise - 3;
                    return format(t, precise);

                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1 - 3;
                    return format(t, precise);

                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4 - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3 - 3;
                    return format(t, precise);

                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;

                    precise = originprecise + 1 - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;

                    precise = originprecise - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;

                    precise = originprecise + 4 - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;

                    precise = originprecise - 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin);

                    precise = originprecise - 3;
                    return format(t, precise);
                }



            }

            if (cUnitKind == 2)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0032808;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.19685;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.039370;
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2.3622;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0036;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.370;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2362.2;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 141732;
                    precise = originprecise+3;
                    return format(t, precise);

                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0022369;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise+3;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 3)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1+3;
                    return format(t, precise);

                }

                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6118.3;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.1183;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 13.489;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 215.82;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 16)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60000;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 17)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;
                    precise = originprecise + 4+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 18)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0061183;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 19)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 20)
                {
                    t = Convert.ToDouble(cValueOrigin);
                    precise = originprecise+3;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 4)
            {

                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.000278;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0167;
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 5)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 6)
            {

                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }



            }

            if (cUnitKind == 7)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 8) //pid参数
            {
                t = Convert.ToDouble(cValueOrigin) * 1;

                precise = originprecise+1;
                return format(t, precise);

            }

            if (cUnitKind == 9) //命令
            {

                t = cValueOrigin;
                precise = originprecise+1;
                return format(t, precise);

            }

            if (cUnitKind == 10) //角度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 11) //扭矩   N.M  mN.m	N.cm  	gf.cm	kgf.cm	kgf.m	ozf.in	lbf.in
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 12) //角度速度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199 * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
            }


            if (cUnitKind == 13)  //扭矩速度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 14)  //温度  C
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 33.8;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 493.46999999999997;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 274.15;
                    precise = originprecise;
                    return format(t, precise);
                }
            }


            if (cUnitKind == 15)  //应力 MPa Pa  KPa  bar mbar kgf/cm2 cmH2O  mmH2O mmHg p.s.i
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1.02 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 7.5 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.15 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 16)  //  流量
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67 * 0.000001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 35.31 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 17)  //  刚度  kN/mm  N/m; N/mm, kN/m
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 18) // 应变
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 19) //文本
            {
                return "0";
            }
            if (cUnitKind ==20) //次数
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise + 1;
                    return format(t, precise);
                }
            }


            return format(t, precise);

        }

        public String GetValueFromUnit(double cValueOrigin, int mcUnitsel)  //求信号换算值
        {
            double t;

            t = 0;

            if (cUnitKind == 0)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise + 0;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 1;
                    return format(t, precise);

                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0032808;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.03937;
                    precise = originprecise + 2;
                    return format(t, precise);

                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.000001;
                    precise = originprecise + 6;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise + 7;
                    return format(t, precise);

                }
                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.37;
                    precise = originprecise;
                    return format(t, precise);

                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.2137e-007;
                    precise = originprecise + 7;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 1)
            {

                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise + 0;
                    return format(t, precise);
                }

                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 1;
                    return format(t, precise);

                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise;
                    return format(t, precise);

                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1;
                    return format(t, precise);

                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);

                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;
                    precise = originprecise + 1;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin);
                    precise = originprecise+3;
                    return format(t, precise);
                }



            }

            if (cUnitKind == 2)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.1;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0032808;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.19685;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.039370;
                    precise = originprecise + 2+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2.3622;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0036;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.370;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2362.2;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 141732;
                    precise = originprecise+3;
                    return format(t, precise);

                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0022369;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise+3;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 3)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+3;
                    return format(t, precise);

                }

                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6118.3;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.1183;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;
                    precise = originprecise + 1+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 13.489;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 215.82;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 16)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60000;
                    precise = originprecise+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 17)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;
                    precise = originprecise + 4+3;
                    return format(t, precise);
                }
                if (mcUnitsel == 18)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0061183;
                    precise = originprecise + 3+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 19)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise+3;
                    return format(t, precise);
                }

                if (mcUnitsel == 20)
                {
                    t = Convert.ToDouble(cValueOrigin);
                    precise = originprecise+3;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 4)
            {

                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.000278;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0167;
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 5)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 6)
            {

                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }



            }

            if (cUnitKind == 7)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 8) //pid参数
            {
                t = Convert.ToDouble(cValueOrigin) * 1;

                precise = originprecise;
                return format(t, precise);


            }

            if (cUnitKind == 9) //命令
            {
                t = cValueOrigin;
                precise = originprecise;
                return format(t, precise);

            }

            if (cUnitKind == 10) //角度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 11) //扭矩   N.M  mN.m	N.cm  	gf.cm	kgf.cm	kgf.m	ozf.in	lbf.in
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 12) //角度速度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199 * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0174532925199 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
            }


            if (cUnitKind == 13)  //扭矩速度
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10200 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.102 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 142 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 8.85 * 60;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 14)  //温度  C
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 33.8;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 493.46999999999997;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 274.15;
                    precise = originprecise;
                    return format(t, precise);
                }
            }


            if (cUnitKind == 15)  //压力 MPa Pa  KPa  bar mbar kgf/cm2 cmH2O  mmH2O mmHg p.s.i
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise+1;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 10.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1.02 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 7.5 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.15 * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 16)  //  流量
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67 * 0.000001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 16.67;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 35.31 * 0.001;
                    precise = originprecise;
                    return format(t, precise);
                }

            }

            if (cUnitKind == 17)  //  刚度  kN/mm  N/m; N/mm, kN/m
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }


            }

            if (cUnitKind == 18)  //  应变
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

              

            }

            if (cUnitKind == 19)//文本
            {
                return "0";
            }

            if (cUnitKind ==20) //次数
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }

            }



            return format(t, precise);

        }

        public void InitUnit() //信号单位初始化
        {
            if (cUnitKind == 0)  //距离
            {
                cUnits[0] = "mm";
                cUnits[1] = "cm";
                cUnits[2] = "ft";
                cUnits[3] = "in";
                cUnits[4] = "km";
                cUnits[5] = "m";
                cUnits[6] = "micron";
                cUnits[7] = "um";
                cUnits[8] = "mil";
                cUnits[9] = "mile";


                cUnitCount = 10;

            }
            if (cUnitKind == 1)  //力
            {
                cUnits[0] = "kN";
                cUnits[1] = "DaN";
                cUnits[2] = "dyn";
                cUnits[3] = "gf";
                cUnits[4] = "kgf";
                cUnits[5] = "kip";
                cUnits[6] = "kN";
                cUnits[7] = "lbf";
                cUnits[8] = "mN";
                cUnits[9] = "MT";
                cUnits[10] = "ozf";
                cUnits[11] = "N";


                cUnitCount = 12;
            }
            if (cUnitKind == 2)  //距离速度
            {
                cUnits[0] = "mm/s";
                cUnits[1] = "cm/s";
                cUnits[2] = "cm/min";
                cUnits[3] = "ft/s";
                cUnits[4] = "ft/min";
                cUnits[5] = "in/s";
                cUnits[6] = "in/min";
                cUnits[7] = "km/h";
                cUnits[8] = "m/s";
                cUnits[9] = "m/min";
                cUnits[10] = "mil/s";
                cUnits[11] = "mil/min";
                cUnits[12] = "mil/h";
                cUnits[13] = "mile/h";
                cUnits[14] = "mm/min";
                cUnitCount = 15;

            }
            if (cUnitKind == 3)  //力速度
            {
                cUnits[0] = "KN/s";
                cUnits[1] = "dyn/s";
                cUnits[2] = "dyn/min";
                cUnits[3] = "gf/s";
                cUnits[4] = "gf/min";
                cUnits[5] = "kgf/s";
                cUnits[6] = "kgf/min";
                cUnits[7] = "kip/s";
                cUnits[8] = "kip/min";
                cUnits[9] = "kN/s";
                cUnits[10] = "kN/min";
                cUnits[11] = "lbf/s";
                cUnits[12] = "lbf/min";
                cUnits[13] = "ozf/s";
                cUnits[14] = "ozf/min";
                cUnits[15] = "mN/s";
                cUnits[16] = "mN/min";
                cUnits[17] = "MT/s";
                cUnits[18] = "MT/min";
                cUnits[19] = "N/min";
                cUnits[20] = "N/s";

                cUnitCount = 21;

            }

            if (cUnitKind == 4) //时间
            {
                cUnits[0] = "s";
                cUnits[1] = "h";
                cUnits[2] = "min";
                cUnits[3] = "ms";
                cUnitCount = 4;

            }

            if (cUnitKind == 5) //电压 
            {
                cUnits[0] = "V";
                cUnits[1] = "mV";
                cUnitCount = 2;

            }

            if (cUnitKind == 6) //频率
            {
                cUnits[0] = "hz";
                cUnits[1] = "cpm";
                cUnits[2] = "rpm";
                cUnitCount = 3;

            }

            if (cUnitKind == 7) //计数
            {
                cUnits[0] = "cycles";
                //cUnits[1] = "segments";

                cUnitCount = 1;

            }

            if (cUnitKind == 8) //pid
            {
                cUnits[0] = "";
                cUnitCount = 1;

            }
            if (cUnitKind == 9) //命令
            {
                cUnits[0] = "";
                cUnitCount = 1;
            }

            if (cUnitKind == 10) //角度
            {
                cUnits[0] = "°";
                cUnits[1] = "rad";
                cUnitCount = 2;
            }

            if (cUnitKind == 11) //扭矩  N.M  mN.m	N.cm  	gf.cm	kgf.cm	kgf.m	ozf.in	lbf.in
            {
                cUnits[0] = "N.M";
                cUnits[1] = "mN.m";
                cUnits[2] = "N.cm";
                cUnits[3] = "gf.cm";
                cUnits[4] = "kgf.cm";
                cUnits[5] = "kgf.m";
                cUnits[6] = "ozf.in";
                cUnits[7] = "lbf.in";
                cUnitCount = 8;
            }
            if (cUnitKind == 12) //角度单位
            {
                cUnits[0] = "°/s";
                cUnits[1] = "°/min";
                cUnits[2] = "rad/s";
                cUnits[3] = "rad/min";
                cUnitCount = 4;
            }

            if (cUnitKind == 13) //扭矩  N.M  mN.m	N.cm  	gf.cm	kgf.cm	kgf.m	ozf.in	lbf.in
            {
                cUnits[0] = "N.M/s";
                cUnits[1] = "mN.m/s";
                cUnits[2] = "N.cm/s";
                cUnits[3] = "gf.cm/s";
                cUnits[4] = "kgf.cm/s";
                cUnits[5] = "kgf.m/s";
                cUnits[6] = "ozf.in/s";
                cUnits[7] = "lbf.in/s";
                cUnits[0] = "N.M/min";
                cUnits[1] = "mN.m/min";
                cUnits[2] = "N.cm/min";
                cUnits[3] = "gf.cm/min";
                cUnits[4] = "kgf.cm/min";
                cUnits[5] = "kgf.m/min";
                cUnits[6] = "ozf.in/min";
                cUnits[7] = "lbf.in/min";
                cUnitCount = 16;
            }

            if (cUnitKind == 14) //温度
            {
                cUnits[0] = "℃";
                cUnits[1] = "F";
                cUnits[2] = "R";
                cUnits[3] = "K";
                cUnitCount = 4;

            }
            if (cUnitKind == 15)  //压力 MPa Pa  KPa  bar mbar kgf/cm2 cmH2O  mmH2O mmHg p.s.i
            {
                cUnits[0] = "MPa";
                cUnits[1] = "Pa";
                cUnits[2] = "KPa";
                cUnits[3] = "bar";
                cUnits[4] = "mbar";
                cUnits[5] = "kgf/cm2";
                cUnits[6] = "cmH2O";
                cUnits[7] = "mmH2O";
                cUnits[8] = "mmHg";
                cUnits[9] = "p.s.i";
                cUnitCount = 10;
            }

            if (cUnitKind == 16) //流量 L/min
            {
                cUnits[0] = "L/min";
                cUnits[1] = "m3/s";
                cUnits[2] = "L/s";
                cUnits[3] = "cm3/s";
                cUnits[4] = "m3/h";
                cUnits[5] = "m3/min";
                cUnits[6] = "L/h";
                cUnits[7] = "ft/min";
                cUnitCount = 8;

            }
            if (cUnitKind == 17) //刚度kN/mm  N/m; N/mm, kN/m
            {
                cUnits[0] = "kN/mm";
                cUnits[1] = "N/m";
                cUnits[2] = "N/mm";
                cUnits[3] = "kN/m";
                cUnitCount = 4;
            }
            if (cUnitKind == 18) //应变
            {
                cUnits[0] = "%";
                cUnits[1] = "mm/mm";
                cUnitCount = 2;
            }
            if (cUnitKind == 19) //文本
            {
                cUnits[0] = " ";
                cUnitCount = 1;
            }

            if (cUnitKind ==20) //次数
            {
                cUnits[0] = "cycl";
                cUnitCount =1;
            }
        }

    }
    

  

      
    public class ClsStatic
    {
        public bool savefile = false;
        public int languageselect = 0;
        public static CircularBuffer[] arraydata = new CircularBuffer[4];


        public static int[] arraydatacount = new int[4];

        public static double[] lasttime = new double[16];

       // public static  Queue<RawDataDataGroup>[] myarraydata = new Queue<RawDataDataGroup>[4];

        public static CircularBuffer savedata = new CircularBuffer("MCTsavedata", 500, Marshal.SizeOf(typeof(RawDataDataGroup)));

        public static int savedatacount = 0;
      

        public void structcopy_RawDataStruct(RawDataData a, ref  RawDataStruct b)
        {
            b.data[0] = a.data0;
            b.data[1] = a.data1;
            b.data[2] = a.data2;
            b.data[3] = a.data3;
            b.data[4] = a.data4;
            b.data[5] = a.data5;
            b.data[6] = a.data6;
            b.data[7] = a.data7;
            b.data[8] = a.data8;
            b.data[9] = a.data9;
            b.data[10] = a.data10;
            b.data[11] = a.data11;
            b.data[12] = a.data12;
            b.data[13] = a.data13;
            b.data[14] = a.data14;
            b.data[15] = a.data15;
            b.data[16] = a.data16;
            b.data[17] = a.data17;
            b.data[18] = a.data18;
            b.data[19] = a.data19;
            b.data[20] = a.data20;
            b.data[21] = a.data21;
            b.data[22] = a.data22;
            b.data[23] = a.data23;
            b.hardlimitlow = a.hardlimitlow;
            b.hardlimitup = a.hardlimitup;
            b.softlimitlow = a.softlimitlow;
            b.softlimitup = a.softlimitup;
            b.ctrlstate1 = a.ctrlstate1;
            b.ctrlstate2 = a.ctrlstate2;
            b.ctrl_state_s = a.ctrl_state_s;
            b.ctrl_state_f = a.ctrl_state_f;
            b.ctrl_state_e = a.ctrl_state_e;
            b.ctrl_halt = a.ctrl_halt;
            b.ctrl_down = a.ctrl_down;
            b.ctrl_up = a.ctrl_up;
            b.ctrl_move = a.ctrl_move;
            b.ctrl_ready = a.ctrl_ready;
            b.ctrl_soft_set = a.ctrl_soft_set;
            b.ctrl_lower_sft_s = a.ctrl_lower_sft_s;
            b.ctrl_lower_sft_f = a.ctrl_lower_sft_f;
            b.ctrl_lower_sft_e = a.ctrl_lower_sft_e;
            b.ctrl_upper_sft_s = a.ctrl_upper_sft_s;
            b.ctrl_upper_sft_f = a.ctrl_upper_sft_f;
            b.ctrl_upper_sft_e = a.ctrl_upper_sft_e;

            return;
        }
    }
}
