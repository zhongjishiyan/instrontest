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
    

    

    
     [Serializable]
    public class shapeitem
    {
        
        public string shapename;

        
      
        

        public ItemSignal[]  sizeitem;
       
        public  shapeitem()
        {
            sizeitem =new ItemSignal[3];
            for (int i = 0; i < 3; i++)
            {
                sizeitem[i] = new ItemSignal(); 

            }
         
         }
       
    }
     [Serializable]
     public class ItemSignalStation : IDisposable
     {

         private int machinekind = 0;
         public List<ItemSignal> datalist=new List<ItemSignal>();

         public void initdatalist()
         {
             int i;
             int j;



             for (i = 0; i < 4; i++)
             {
                 ClsStatic.arraydata[i] = new CircularBuffer("MCTarraydata" + i.ToString(), 1000, Marshal.SizeOf(typeof(RawDataDataGroup)));
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
                 initchannel扭转();
             }
             if (machinekind == 2)
             {
                 initchannel岩石();
             }
             if (machinekind ==3)
            {
                initchannel标准1(); 
            }
         }

         public void initchannel扭转()
         {
             int i = 0;
             chsignals.Clear();
             allsignals.Clear();
             hardsignals.Clear();
             zerosignals.Clear();
             originsignals.Clear();

             ItemSignal isi = new ItemSignal();
             isi.cName = "扭角";
             isi.LName[0] = "扭角";
             isi.LName[1] = "Disp.";

             isi.originprecise = 3;
             isi.SignName = "Ch Disp";
             isi.cUnitKind = 10;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 75;
             isi.fullminbase = -75;
             isi.speedSignal = (ItemSignal) anglespeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
             hardsignals.Add(isi);
             zerosignals.Add(isi);
             originsignals.Add(isi);



             isi = new ItemSignal();
             isi.cName = "扭矩";
             isi.LName[0] = "扭矩";
             isi.LName[1] = "Force";
             isi.originprecise = 3;
             isi.SignName = "Ch Load";
             isi.cUnitKind = 11;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 30;
             isi.fullminbase = -30;
             isi.speedSignal = (ItemSignal)torquespeedsignal.Clone();
             isi.speedSignal.fullmaxbase = isi.fullmaxbase;
             isi.speedSignal.fullminbase = 0;
             chsignals.Add(isi);
             allsignals.Add(isi);
             hardsignals.Add(isi);
             zerosignals.Add(isi);
             originsignals.Add(isi);

            


             isi = new ItemSignal();

             isi.cName = "时间";
             isi.LName[0] = "时间";
             isi.LName[1] = "Time";
             isi.originprecise = 4;
             isi.SignName = "Ch Time";
             isi.cUnitKind = 4;
             isi.cUnitsel = 0;
             isi.InitUnit();
             isi.fullmaxbase = 316000000;
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
                     isi = new ItemSignal();
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
                 datalist[i].EdcChannleSel = 0;

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
             isi.cName = "力";
             isi.LName[0] = "力";
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
             chsignals.Add(isi);
             allsignals.Add(isi);
             hardsignals.Add(isi);
             zerosignals.Add(isi);
             originsignals.Add(isi);


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


             if (CComLibrary.GlobeVal.filesave == null)
             {

             }

             else
             {

                 for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                 {
                     isi = new ItemSignal();
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
                 datalist[i].EdcChannleSel = 0;

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
            
             zerosignals.Add(isi);
             originsignals.Add(isi);
             

             if (CComLibrary.GlobeVal.filesave == null)
             {

             }

             else
             {

                 for ( i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                 {
                     isi = new ItemSignal();
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
                 datalist[i].EdcChannleSel = 0;

             }

         }

        public void initchannel标准1()
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
            isi.cName = "负荷1";
            isi.LName[0] = "负荷1";
            isi.LName[1] = "Force1";



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
            isi.cName = "负荷2";
            isi.LName[0] = "负荷2";
            isi.LName[1] = "Force2";



            isi.originprecise = 3;
            isi.SignName = "Ch Load2";
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
            isi.cName = "变形1";
            isi.LName[0] = "变形1";
            isi.LName[1] = "Ext 1";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext1";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 5;
            isi.fullminbase = -5;
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            hardsignals.Add(isi);
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形2";
            isi.LName[0] = "变形2";
            isi.LName[1] = "Ext 2";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext2";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 5;
            isi.fullminbase = -5;
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;

            chsignals.Add(isi);
            allsignals.Add(isi);
            hardsignals.Add(isi);
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形3";
            isi.LName[0] = "变形3";
            isi.LName[1] = "Ext 3";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext3";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 5;
            isi.fullminbase = -5;
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            hardsignals.Add(isi);
            zerosignals.Add(isi);
            originsignals.Add(isi);

            isi = new ItemSignal();
            isi.cName = "变形4";
            isi.LName[0] = "变形4";
            isi.LName[1] = "Ext 4";

            isi.originprecise = 3;
            isi.SignName = "Ch Ext4";
            isi.cUnitKind = 0;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 5;
            isi.fullminbase = -5;
            isi.speedSignal = (ItemSignal)lengthspeedsignal.Clone();
            isi.speedSignal.fullmaxbase = isi.fullmaxbase;
            isi.speedSignal.fullminbase = 0;
            chsignals.Add(isi);
            allsignals.Add(isi);
            hardsignals.Add(isi);
            zerosignals.Add(isi);
            originsignals.Add(isi);

            //chsignals.Add(isi);
            //allsignals.Add(isi);
            //hardsignals.Add(isi);
            //zerosignals.Add(isi);
            //originsignals.Add(isi);

            isi = new ItemSignal();

            isi.cName = "时间";
            isi.LName[0] = "时间";
            isi.LName[1] = "Time";
            isi.originprecise = 4;
            isi.SignName = "Ch Time";
            isi.cUnitKind = 4;
            isi.cUnitsel = 0;
            isi.InitUnit();
            isi.fullmaxbase = 316000000;
            isi.fullminbase = 0;
            allsignals.Add(isi);
            originsignals.Add(isi);

            //hardsignals.Add(isi);

          


            if (CComLibrary.GlobeVal.filesave == null)
            {

            }

            else
            {

                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {
                    isi = new ItemSignal();
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
                datalist[i].EdcChannleSel = 0;

            }

        }


        public void InitShape()
         {
             shapeitem c = new shapeitem();
             c.shapename = "矩形";

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

             

             shapelist.Add(c);

             c = new shapeitem();
             c.shapename = "圆形";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
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

             shapelist.Add(c);




             c = new shapeitem();

             c.shapename = "双剪切环";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
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

             shapelist.Add(c);

             c = new shapeitem();

             c.shapename = "管状";

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

             shapelist.Add(c);

             c = new shapeitem();

             c.shapename = "不规则形状";

             c.sizeitem[0].cUnitKind = 0;
             c.sizeitem[0].cName = "横截面积";
             c.sizeitem[0].LName[0] = "横截面积";
             c.sizeitem[0].LName[1] = "Cross-sectiional area";
             c.sizeitem[0].cUnitsel = 0;
             c.sizeitem[0].InitUnit();
             c.sizeitem[0].fullmaxbase = 10000;
             c.sizeitem[0].fullminbase = 0;
             c.sizeitem[0].originprecise = 3;

             c.sizeitem[1].cUnitKind = 0;
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
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

             shapelist.Add(c);


             c = new shapeitem();

             c.shapename = "纤维";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
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

             shapelist.Add(c);


             c = new shapeitem();

             c.shapename = "剥离90度";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
             c.sizeitem[1].LName[1] = "None";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "无";
             c.sizeitem[2].LName[0] = "无";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);

             c = new shapeitem();

             c.shapename = "剥离180度";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
             c.sizeitem[1].LName[1] = "None";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "无";
             c.sizeitem[2].LName[0] = "无";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);

             c = new shapeitem();

             c.shapename = "T剥离";

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
             c.sizeitem[1].cName = "无";
             c.sizeitem[1].LName[0] = "无";
             c.sizeitem[1].LName[1] = "None";
             c.sizeitem[1].cUnitsel = 0;
             c.sizeitem[1].InitUnit();
             c.sizeitem[1].fullmaxbase = 10000;
             c.sizeitem[1].fullminbase = 0;
             c.sizeitem[1].originprecise = 3;

             c.sizeitem[2].cUnitKind = 0;
             c.sizeitem[2].cName = "无";
             c.sizeitem[2].LName[0] = "无";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);

             c = new shapeitem();

             c.shapename = "撕裂";

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
             c.sizeitem[2].cName = "无";
             c.sizeitem[2].LName[0] = "无";
             c.sizeitem[2].LName[1] = "None";
             c.sizeitem[2].cUnitsel = 0;
             c.sizeitem[2].InitUnit();
             c.sizeitem[2].fullmaxbase = 10000;
             c.sizeitem[2].fullminbase = 0;
             c.sizeitem[2].originprecise = 3;

             shapelist.Add(c);


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

            


             for (int i = 0; i <= 18; i++)
             {
                 isi = new ItemSignal();
                 isi.cUnitKind = i;
                 isi.cUnitsel = 0;
                 isi.InitUnit();
                 signalskindlist.Add(isi);
             }

             SignalsNames = new String[signalskindlist.Count];

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
        public static int languageselect = 0;
        public static Boolean savefile = false;

        public static ClsStaticStation.ItemSignalStation  mycls;

        public static double mload;
        public static double mpos;
        public static double mext;
        public static double mtime;
        public static Boolean mvalid = false; //判断计算是否有效

        public static double mload1;
        public static double mpos1;

        public static double[] mresult=new Double[100] ;
        
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

        
        public int originprecise;//小数点位数
        public int Resolution;//精度位数
        public int precise=3;//小数点位数

        public ItemSignal speedSignal;

        private string mcName;
        public string cName=""; //信号名称

        public string[] LName;


        public string[] cUnits; //单位


        public int cUnitKind;  //信号单位类型  //0 距离  1 力  2 距离速度 3 力速度  4 时间 5 电压  6 频率 // 7 段数 //8 Pid //9 命令 //10 //角度// 11扭矩 //12 角度速度 // 13 扭矩速度// 14 温度 //15 应力 16 //流量 17 //刚度 18//应变//19文本
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
        public int EdcChannleSel = 0;  //Edc通道

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

        public bool uplimitselect = false;
        public bool downlimitselect = false;


        public double sli_max = 0;
        public double sli_min = 0;
        public double sli_rangemax = 0;
        public double sli_rangemin = 0;
        public double sli_value = 0;

        private bool disposed = false;

        public double[] gsetvalue;
        public double[] gamendvalue;


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

            cUnits = new string[20];

            for (i = 0; i < 20; i++)
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

            if (m_Global.languageselect == 0)
            {
                cName = LName[m_Global.languageselect];
            }
            else
            {
                cName = LName[m_Global.languageselect];
            }
            return;
        }

        public Object Clone()
        {
            return this.MemberwiseClone();

        }
        public ItemSignal(string mName, string mSignName, int mcUnitKind)
        {
            int i;
            cUnits = new string[20];

            for (i = 0; i < 20; i++)
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

        public String GetOriValue(double oValue)  //求信号原始值
        {
            string s;
            double t;
            int old;

            old = cUnitsel;

            double m;
            double.TryParse(GetValue(1), out m);
            if (m == 0)
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
                    precise = originprecise;
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
                    t = Convert.ToDouble(cValueOrigin) * 6;
                    precise = originprecise;
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
                    precise = originprecise + 1;
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
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0036;
                    precise = originprecise + 3;
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
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.370;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2362.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 141732;
                    precise = originprecise;
                    return format(t, precise);

                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0022369;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 3)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);

                }

                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6118.3;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.1183;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;
                    precise = originprecise + 1;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 13.489;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 215.82;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 16)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 17)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;
                    precise = originprecise + 4;
                    return format(t, precise);
                }
                if (mcUnitsel == 18)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0061183;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 19)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
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


            if (cUnitKind == 15)  //应力 MPa Pa  KPa  bar mbar kgf/cm2 cmH2O  mmH2O mmHg p.s.i
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

            if (cUnitKind == 18) // 应变
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);
                }
            }

            if (cUnitKind == 19) //文本
            {
                return "0";
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
                    precise = originprecise;
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
                    t = Convert.ToDouble(cValueOrigin) * 6;
                    precise = originprecise;
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
                    precise = originprecise + 1;
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
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0036;
                    precise = originprecise + 3;
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
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 39.370;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 2362.2;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 141732;
                    precise = originprecise;
                    return format(t, precise);

                }

                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0022369;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
                    return format(t, precise);
                }



            }


            if (cUnitKind == 3)
            {
                if (mcUnitsel == 0)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1;
                    precise = originprecise;
                    return format(t, precise);

                }

                cValueOrigin = cValueOrigin * 1000;

                if (mcUnitsel == 1)
                {
                    t = Convert.ToDouble(cValueOrigin) * 100000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 2)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 3)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6000000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 4)
                {
                    t = Convert.ToDouble(cValueOrigin) * 101.97;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 5)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6118.3;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 6)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.10197;
                    precise = originprecise + 1;
                    return format(t, precise);
                }
                if (mcUnitsel == 7)
                {
                    t = Convert.ToDouble(cValueOrigin) * 6.1183;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 8)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00022481;
                    precise = originprecise + 4;
                    return format(t, precise);
                }

                if (mcUnitsel == 9)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.001;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 10)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.06;
                    precise = originprecise + 2;
                    return format(t, precise);
                }

                if (mcUnitsel == 11)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.22481;
                    precise = originprecise + 1;
                    return format(t, precise);
                }

                if (mcUnitsel == 12)
                {
                    t = Convert.ToDouble(cValueOrigin) * 13.489;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 13)
                {
                    t = Convert.ToDouble(cValueOrigin) * 3.5969;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 14)
                {
                    t = Convert.ToDouble(cValueOrigin) * 215.82;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 15)
                {
                    t = Convert.ToDouble(cValueOrigin) * 1000;
                    precise = originprecise;
                    return format(t, precise);
                }

                if (mcUnitsel == 16)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60000;
                    precise = originprecise;
                    return format(t, precise);
                }
                if (mcUnitsel == 17)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.00010197;
                    precise = originprecise + 4;
                    return format(t, precise);
                }
                if (mcUnitsel == 18)
                {
                    t = Convert.ToDouble(cValueOrigin) * 0.0061183;
                    precise = originprecise + 3;
                    return format(t, precise);
                }

                if (mcUnitsel == 19)
                {
                    t = Convert.ToDouble(cValueOrigin) * 60;
                    precise = originprecise;
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

                cUnitCount = 20;

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
                cUnits[0] = "mm/mm";
                cUnitCount = 1;
            }
            if (cUnitKind == 19) //文本
            {
                cUnits[0] = " ";
                cUnitCount = 1;
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



        public static CircularBuffer savedata = new CircularBuffer("MCTsavedata", 100, Marshal.SizeOf(typeof(RawDataDataGroup)));

        public static CircularBuffer btwdata = new CircularBuffer("MCTbtwdata", 100, Marshal.SizeOf(typeof(RawDataDataGroup)));


        public static int savedatacount = 0;
        public static int btwdatacount = 0;

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
