using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClsStaticStation
{
   public  class ClsBaseControl
    {
       public Boolean connected = false;//判断是否联机
        public Boolean mtestrun = false; //程序执行完成判断
       public long merrorcount = 0;
       public Boolean mdemo = false;
       public int mcurseg = 0;
        public double keepingtime;//显示保持时间

        public Boolean keepingstate;//显示保持状态

        public Boolean duanliebaohu;//断裂保护

        public int current_returncount;//大循环次数
        public int total_returncount;//大循环总次数

        public virtual  void Init(int handle)
        {


        }
        public virtual  void btnkey(Button b)
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

        public virtual  void startcontrol()
        {

        }

         public virtual  void  restorezero(Button b)
        {
        }

        public  virtual  void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount)
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

        public virtual  void starttest()
        {
        }

    }
}
