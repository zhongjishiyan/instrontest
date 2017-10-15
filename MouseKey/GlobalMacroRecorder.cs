using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
namespace TabHeaderDemo
{

    /// <summary>
    /// All possible events that macro can record
    /// </summary>
    [Serializable]
    public enum MacroEventType
    {
        MouseMove,
        MouseDown,
        MouseUp,
        MouseWheel,
        KeyDown,
        KeyUp
    }

    /// <summary>
    /// Series of events that can be recorded any played back
    /// </summary>
    [Serializable]



    public class MacroEvent
    {

        public double  width;
        public double  height;

        public MouseButtons button;
        public int clicks;
        public int x;
        public int y;
        public int delta;


        bool Control;
        bool Alt;
        bool Shift;
        bool Handled;

        public Keys KeyCode;
        public Keys KeyData;
        public int KeyValue;

        public MacroEventType MacroEventType;
        [NonSerialized]
        public EventArgs  EventArgs;

      
        public int TimeSinceLastEvent;

        public MacroEvent(MacroEventType macroEventType, EventArgs eventArgs, int timeSinceLastEvent,int mwidth,int mheight)
        {
            width = mwidth;
            height = mheight;

            if (eventArgs is MouseEventArgs)
            {
                button = (eventArgs as MouseEventArgs).Button;
                clicks = (eventArgs as MouseEventArgs).Clicks;
                x = (eventArgs as MouseEventArgs).X;
                y = (eventArgs as MouseEventArgs).Y;
                delta = (eventArgs as MouseEventArgs).Delta;

            }


            if (eventArgs is KeyEventArgs)
            {
                KeyCode = (eventArgs as KeyEventArgs).KeyCode;
                KeyData= (eventArgs as KeyEventArgs).KeyData ;
                KeyValue = (eventArgs as KeyEventArgs).KeyValue;
                Control = (eventArgs as KeyEventArgs).Control;
                Alt = (eventArgs as KeyEventArgs).Alt ;
                Shift =(eventArgs as KeyEventArgs).Shift;
            }

            MacroEventType = macroEventType;
            EventArgs = eventArgs;
            TimeSinceLastEvent = timeSinceLastEvent;

        }

    }

    [Serializable]
    public class MacroRecord
    {

        public List<MacroEvent> events;

        public MacroRecord()
        {

            events = new List<MacroEvent>();
        }

        public void SerializeNow(string filename)
        {

            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);

            fileStream.Close();
        }

        public MacroRecord DeSerializeNow(string filename)
        {
            MacroRecord c = new MacroRecord();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as MacroRecord;



                    for (int i = 0; i < c.events.Count; i++)
                    {
                        if ((c.events[i].MacroEventType== MacroEventType.MouseUp) ||(c.events[i].MacroEventType == MacroEventType.MouseDown)||
                            (c.events[i].MacroEventType == MacroEventType.MouseMove) || (c.events[i].MacroEventType == MacroEventType.MouseMove))

                        {
                            c.events[i].EventArgs = new MouseEventArgs((MouseButtons)c.events[i].button, c.events[i].clicks, c.events[i].x, c.events[i].y, c.events[i].delta);
                            
                        }

                        if ((c.events[i].MacroEventType == MacroEventType.KeyUp) || (c.events[i].MacroEventType == MacroEventType.KeyDown))
                        {
                            
                            c.events[i].EventArgs = new KeyEventArgs(c.events[i].KeyData);
                            
                        }

                    }


                    fileStream.Close();



                }
            }
            catch (Exception e1)
            {
                c = new MacroRecord();

                MessageBox.Show(e1.Message, "读取文件");
            }
            finally
            {

            }
            return (c);
        }
    }
}

