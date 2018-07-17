using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AppleLabApplication
{
   
        class newlabel : Label
        {



            protected override void OnPaint(PaintEventArgs e)
            {



                // base.OnPaint(e);

                if (Text.Length > 0)
                {

                    char[] s = new char[2];
                    s[0] = Convert.ToChar("}");

                    String[] w = Text.Split(s);

                    float ma = 0;


                    Rectangle _Rectangle = base.Bounds;



                    for (int i = 0; i < w.Length; i++)
                    {

                        if (w[i] == "")
                        {

                        }
                        else
                        {
                            string _Text;

                            string _Subscript;

                            int a = w[i].IndexOf("{");

                            if (a >= 0)
                            {
                                w[i] = w[i] + "}";
                                _Text = w[i].Substring(0, a);

                                _Subscript = w[i].Substring(w[i].IndexOf("lo ") + 3, w[i].IndexOf("}") - (w[i].IndexOf("lo ") + 3));
                            }
                            else
                            {
                                _Text = w[i];
                                _Subscript = "";
                            }







                            e.Graphics.PageUnit = GraphicsUnit.Pixel;
                            Font _MyFont1 = new Font("宋体", Font.Size);
                            Font _MyFont2 = new Font("宋体", Font.Size - 2);

                            SizeF _Size1 = e.Graphics.MeasureString(_Text, _MyFont1);
                            SizeF _Size2 = e.Graphics.MeasureString(_Subscript, _MyFont2);


                            float _X1 = ma;

                            float _X2 = _X1 + _Size1.Width - 3;

                            ma = _X2 + _Size2.Width;

                            e.Graphics.DrawString(_Text, _MyFont1, Brushes.Black, _X1, 0);
                            e.Graphics.DrawString(_Subscript, _MyFont2, Brushes.Black, _X2, _Size1.Height - _Size2.Height);
                        }
                    }

                }

            }

        }
    

}
