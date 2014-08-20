using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpSweeper
{
    [Designer(typeof(GridControlDesigner))]
    public class CounterControl : Control
    {
        private int _dig = 3;
        [Category("Appearance")]
        public int Digits { get { return _dig; } set { _dig = value; SizeDigits(); Invalidate(); } }

        private int _val = 0;
        [Category("Appearance")]
        public int Value { get { return _val; } set { _val = value; Invalidate(); } }

        public Size DigSize { get { return new Size(13, 23); } }

        void SizeDigits()
        {
            this.Size = new Size(DigSize.Width * Digits, DigSize.Height);
        }

        public CounterControl()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SizeDigits();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string vv = "";
            if(Value >= 0)
            {
                vv = Value.IntToStringWithLeftPad(_dig);
            }
            else
            {
                vv = "-" + (Value * -1).IntToStringWithLeftPad(_dig - 1);
            }

            for(int i = 1; i <= _dig; i++)
            {
                if (vv[i - 1] == '-')
                {
                    e.Graphics.DrawImage(SharpSweeper.Properties.Resources.numbers.GetRegion(10 * DigSize.Width, 0, DigSize), (i - 1) * DigSize.Width, 0);
                }
                else
                {
                    e.Graphics.DrawImage(SharpSweeper.Properties.Resources.numbers.GetRegion(int.Parse(vv[i - 1].ToString()) * DigSize.Width, 0, DigSize), (i - 1) * DigSize.Width, 0);
                }
            }
        }
    }
}
