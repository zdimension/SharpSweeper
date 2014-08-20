using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SharpSweeper
{
    public class SweeperTheme
    {
        public string Name { get; set; }
        public Image MainPict { get; set; }
        public string PictPath{get;set;}
        public Size GridSize { get; set; }
        public Size ButtonSize { get; set; }

        #region Pictures
        public Image EmptyHiddenPicture { get { return MainPict.GetRegion(0, 0, GridSize, true); } }
        public Image EmptyPicture { get { return MainPict.GetRegion(1, 0, GridSize, true); } }
        public Image FlagPicture { get { return MainPict.GetRegion(5, 2, GridSize, true); } }
        public Image OnePicture { get { return MainPict.GetRegion(2, 0, GridSize, true); } }
        public Image TwoPicture { get { return MainPict.GetRegion(3, 0, GridSize, true); } }
        public Image ThreePicture { get { return MainPict.GetRegion(4, 0, GridSize, true); } }
        public Image FourPicture { get { return MainPict.GetRegion(5, 0, GridSize, true); } }
        public Image FivePicture { get { return MainPict.GetRegion(0, 1, GridSize, true); } }
        public Image SixPicture { get { return MainPict.GetRegion(1, 1, GridSize, true); } }
        public Image SevenPicture { get { return MainPict.GetRegion(2, 1, GridSize, true); } }
        public Image EightPicture { get { return MainPict.GetRegion(3, 1, GridSize, true); } }
        public Image MinePicture { get { return MainPict.GetRegion(4, 1, GridSize, true); } }
        public Image DahMinePicture { get { return MainPict.GetRegion(5, 1, GridSize, true); } }
        public Image FakeFlagPicture { get { return MainPict.GetRegion(5, 3, GridSize, true); } }



        public Image GameGood { get { return MainPict.GetRegion(0, 0, ButtonSize, true, 32); } }
        public Image GameGoodDown { get { return MainPict.GetRegion(1, 0, ButtonSize, true, 32); } }
        public Image GameDead { get { return MainPict.GetRegion(2, 0, ButtonSize, true, 32); } }
        public Image GameWarn { get { return MainPict.GetRegion(0, 1, ButtonSize, true, 32); } }
        public Image GameWin { get { return MainPict.GetRegion(1, 1, ButtonSize, true, 32); } }
        #endregion

        

        public SweeperTheme(string name, string pictpath, Size gridsize, Size btnsize)
        {
            Name = name;
            MainPict = Image.FromFile(pictpath);
            PictPath = pictpath;
            GridSize = gridsize;
            ButtonSize = btnsize;
        }

        public SweeperTheme(string name, Image mainpict, Size gridsize, Size btnsize)
        {
            Name = name;
            MainPict = mainpict;
            PictPath = "";
            GridSize = gridsize;
            ButtonSize = btnsize;
        }

        public static SweeperTheme FromFile(string filePath)
        {
            SweeperTheme t;

            var d = XDocument.Load(filePath);

            var th = d.Element("Theme");

            t = new SweeperTheme(th.Element("Name").Value, th.Element("MainPict").Value, Extensions.SizeFromString(th.Element("GridSize").Value), Extensions.SizeFromString(th.Element("ButtonSize").Value));

            return t;
        }

        private XDocument ToXml()
        {
            var doc = new XDocument(new XElement("Theme",
                new XElement("Name", Name),
                new XElement("MainPict", PictPath),
                new XElement("GridSize", GridSize.Width + "," + GridSize.Height),
                new XElement("ButtonSize", ButtonSize.Width + "," + ButtonSize.Height)));

            return doc;
        }
    }

    public class Themes
    {
        public static SweeperTheme XP = new SweeperTheme("XP", SharpSweeper.Properties.Resources.XP, new Size(16, 16), new Size(26, 26));
    }
}
