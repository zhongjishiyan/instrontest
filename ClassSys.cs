using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace TabHeaderDemo
{



   

    [Serializable]
    public class ClassSys
    {

        public enum _MachineName:int
        {
            Electronic,
            Torsion,
             Three_axis,
            standard1
        }
        public string  softwareconfig = "AppleLab 静态试验软件";
        public string  softwareinstalldate;
        public double softwareversion = 1.0;
        public string SystemID;
        public string KeyCode;

        public int framemodel = 0;

        public int frameserialnumber = 0;

        public string macaddress = "ff ff ff ff ff ff";


        public bool securityon = false;
        public int  UserCount=0;
        public string[] UserName;
        public string[] UserPassword;
        public int[] UserLevels;

        public int startupscreen = 0;//启动模式

        public bool demo = false;//演示试验 

        public int controllerkind = 0;//

        public string[] RecentFilename;

        public string[] RecentFilenameKind;

        public string SamplePath="";//样品文件保存路径

        public string SampleFile="TestSample";//样品文件名

        public string[] RecentSampleFilename;
        public string[] RecentSampleFilenameKind;
        public string[] RecentSampleFilePath;

        public int AppUserLevel = 0;

        public string[] ControllerName;

        public int ControllerCount;

        public int CurentUserIndex=0;

        public int  machinekind = 0;//主机类型
        public string[] MachineName;

        public int MachineCount;

        public string apptitle = "";

        public bool showapptitle = false;

        public string shorttitle = "";

        public bool showshorttitle = false;


        public string bmplogo = "";
        public bool showlogo = false;

        public string[] ChannelName;//通道名称
        public double[] ChannelRange;//通道量程
        public int[] ChannelDimension;//通道量纲
        public bool[] ChannelControl;//通道控制
        public bool[] ChannelStrainControl;//通道变形控制
        public int[] ChannelSamplemode;//通道硬件采集方式

        public int ChannelCount = 8;//通道数量

       

        public ClassSys()
        {

            ControllerName = new string[20];

            ControllerName[0] = "ARM控制器";
            ControllerName[1] = "DOLI控制器";
            ControllerName[2] = "DSP控制器";
            ControllerName[3] = "直线电机";
            ControllerCount = 4;

            MachineName = new string[20];
            MachineName[0] = "电子(液压)万能试验机";
            MachineName[1] = "扭转试验机";
            MachineName[2] = "岩石三轴试验机";
            MachineName[3] = "换挡意图传感器试验机";
            MachineName[4] = "金属恒应变控制试验机";

            MachineCount = 5;
          
            ChannelRange = new double [20];
            ChannelControl = new bool[20];
            ChannelDimension = new int[20];
            ChannelSamplemode = new int[20];

            UserName = new string[100];
            UserPassword = new string[100];
            UserLevels = new int[100];
            for (int i = 0; i < 100; i++)
            {
                UserName[i] = "a";
                UserPassword[i] = "a";
                UserLevels[i] = 0;
            }
            UserCount = 1;
            UserName[0] = "AppleLab";
            UserPassword[0] = "AppleLab";
            UserLevels[0] = 3;

            RecentFilename = new string[20];
            RecentFilenameKind = new string[20];
            RecentSampleFilename = new string[20];
            RecentSampleFilenameKind = new string[20];
            RecentSampleFilePath = new string[20];

            for (int i = 0; i < 20; i++)
            {
                RecentFilename[i] = "";
                RecentFilenameKind[i] = "";
                RecentSampleFilename[i] = "";
                RecentSampleFilenameKind[i] = "";
                RecentSampleFilePath[i] = "";

                ChannelRange[i] = 10;
                ChannelControl[i] = false ;
                ChannelDimension[i] =0;
                ChannelSamplemode[i] = 0;

            }

            SampleFile = "TestSample";


        }

        public void SerializeNow(string filename)
        {

            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
            
            fileStream.Close();
        }

        public ClassSys DeSerializeNow(string filename)
        {
            ClassSys c = new ClassSys();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as ClassSys;

                    if (c.RecentFilename == null)
                    {
                        c.RecentFilename = new string[20];
                    }
                    if (c.RecentFilenameKind == null)
                    {
                        c.RecentFilenameKind = new string[20];
                    }

                    if (c.SampleFile == null)
                    {
                        c.SampleFile = "TestSample";
                    }

                    if (c.SamplePath == null)
                    {
                        c.SamplePath = "";
                    }
                    if (c.RecentSampleFilename == null)
                    {
                        c.RecentSampleFilename = new string[20];
                    }

                    if (c.RecentSampleFilenameKind == null)
                    {
                        c.RecentSampleFilenameKind = new string[20];
                    }
                    if (c.RecentSampleFilePath == null)
                    {
                        c.RecentSampleFilePath = new string[20];
                        
                    }

                    if (c.ControllerName == null)
                    {
                        c.ControllerName = new string[20];
                       

                    }

                    c.ControllerName[0] = "ARM控制器";
                    c.ControllerName[1] = "DOLI控制器";
                    c.ControllerName[2] = "DSP控制器";
                    c.ControllerName[3] = "直线电机";
                    c.ControllerCount = 4;

                    if (c.MachineName == null)
                    {
                        c.MachineName = new string[20];
                    }
                   

                    c.MachineName[0] = "电子(液压)万能试验机";
                    c.MachineName[1] = "扭转试验机";
                    c.MachineName[2] = "岩石三轴试验机";
                    c.MachineName[3] = "换挡意图传感器试验机";
                    c.MachineName[4] = "金属恒应变控制试验机";



                    c.MachineCount = 5;

                    if (c.ChannelSamplemode==null)
                    {
                        c.ChannelSamplemode = new int[20];
                    }

                    if (c.ChannelRange == null)
                    {
                        c.ChannelRange = new double[20];
                        c.ChannelControl = new bool[20];
                        c.ChannelDimension = new int[20];
                        
                        c.ChannelCount = 8;
                        for (int i = 0; i < c.ChannelCount; i++)
                        {


                            c.ChannelRange[i] = 10;
                            c.ChannelControl[i] = false;


                        }
                    }
                

        fileStream.Close();



                }
            }
            catch (Exception e1)
            {
                c = new ClassSys();

                MessageBox.Show(e1.Message, "读取文件");
            }
            finally
            {

            }
            return (c);
        }

    }
}
