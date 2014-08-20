using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpSweeper
{
    public partial class LevelSelect : Form
    {
        public int SelectedWidth { get { return int.Parse(txtWidth.Text); } }
        public int SelectedHeight { get { return int.Parse(txtHeight.Text); } }
        public int SelectedMines { get { return int.Parse(txtMines.Text); } }


        public LevelSelect()
        {
            InitializeComponent();
        }
    }
}
