using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpSweeper
{
    public static class Extensions
    {
        public static Size SizeFromString(string s)
        {
            string w = s.Split(',')[0];
            string h = s.Split(',')[1];
            return new Size(int.Parse(w), int.Parse(h));
        }

        public static Image GetRegion(this Image img, Rectangle r)
        {
            Bitmap orig = new Bitmap(img);
            return (Image)orig.Clone(r, orig.PixelFormat);
        }

        public static Image GetRegion(this Image img, int x, int y, int w, int h)
        {
            return GetRegion(img, new Rectangle(x, y, w, h));
        }

        public static Image GetRegion(this Image img, int x, int y, Size s, bool relative = false, int starty = 0)
        {
            if (!relative)
            {
                return GetRegion(img, new Rectangle(x, y, s.Width, s.Height));
            }
            else
            {
                return GetRegion(img, new Rectangle(x * s.Width, y * s.Height + starty, s.Width, s.Height));
            }
        }

        public static string IntToStringWithLeftPad(this int number, int totalWidth)
        {
            return number.ToString().PadLeft(totalWidth, '0');
        }

        public static int GetDigit(this int i, int digit)
        {
            if (i.ToString().Count() < digit)
                return 0;
            else
                return int.Parse(i.ToString()[digit - 1].ToString());
        }
    }
}
