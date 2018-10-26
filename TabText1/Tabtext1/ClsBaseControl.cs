﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XLNet;

namespace ClsStaticStation
{
   public  class ClsBaseControl
    {



        public int tcount = 0;


        public int oldcount = 0;

        public double DataTransmissionRate = 0.001;

        public UInt32  debug;


      
        public Boolean mtestrun = false; //程序执行完成判断
        public Boolean mprotect = false; //保护 

        public long merrorcount = 0;
        public Boolean mdemo = false;
        public int mcurseg = 0;

        public XLDOPE.Edc myedc;

        public double keepingtime;//显示保持时间

        public Boolean keepingstate;//显示保持状态

        public Boolean duanliebaohu;//断裂保护

        public Boolean dianyabaohu;//电压保护

        public bool m_dianyabaohucontrol = false;

        public int current_returncount;//大循环次数
        public int total_returncount;//大循环总次数

        public long count = 0;//试验次数

        public virtual bool Connected()
        {
            return false;
        }


        public virtual bool DriverOn()
        {
            return false; 
        }

        public string mtishi = "";


        public double dogtime = 0;

        public virtual void  fatigstop()
        {

        }
        public virtual  void fatigtest(int wavekind, float freq, float ave, float  range, double count)
        {

        }

        public virtual void SetBaseCount(int count)
        {

        }
        public virtual  void Init(int handle)
        {


        }
        public virtual  void btnkey(Button b)
        {

        }
        public virtual void findzero(double speed)
        {

        }
        public virtual  void btnzeroall()
        {

        }

        public virtual void btnrestoreall()
        {

        }
        public virtual   void  btnzero(Button b)
        {
        }
        public virtual  void CrossDown(int ctrlmode, double speed)
        {

        }
        public virtual  void CrossStop(int ctrlmode)
        {

        }
        public virtual  void CrossUp(int ctrlmode, double speed)
        {
        }
        public virtual  void DelayS(double t)
        {
        }

       
        public  virtual    void demo()
        {

        }
        public virtual  void demotest(bool testing)
        {

        }

        public virtual  void DestStop(int ctrlmode)
        {
        }

        public virtual  void DriveOff()
        {
        }

        public virtual  void DriveOn()
        {
        }

        public virtual  void endcontrol()
        {


        }


        public virtual void cleartime()
        {

        }
        public virtual  void startcontrol()
        {

        }

         public virtual  void  restorezero(Button b)
        {
        }

        public  virtual  void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount,int action,int destmode)
        {
        }

        public virtual  void setrunstate(int m)
        {
        }

        public virtual  void readdemo(string fileName)
        {

        }

        public virtual  bool getlimit(int ch)
        {
            return false;
        }

        public virtual  int getrunstate() // 1运行 0 停止
        {
            return 0;
        }
        public virtual  void endtest()
        {
        }

        public virtual  bool getEmergencyStop()
        {
            return false;
        }

        public virtual  void DestStart(int ctrlmode, double dest, double speed)
        {
        }
        public virtual void ReturnZero(int ctrlmode,  double speed)
        {


        }
        public  virtual  int OpenConnection()
        {

            return 0;
        }

        public virtual  int CloseConnection()
        {
            return 0;
        }

        public virtual  int ConvertCtrlMode(int ctrl)
        {
            return 0;
        }

        public virtual  void Exit()
        {

        }

        public virtual  void starttest(int spenum)
        {
        }

    }
}
