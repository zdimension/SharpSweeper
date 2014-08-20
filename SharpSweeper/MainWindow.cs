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
    public partial class MainWindow : Form
    {
        DifficultyLevel lvl = DifficultyLevels.Easy;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sweeper.NewGame(lvl);
            btnGame.IdleImage = sweeper.Theme.GameGood;
            btnGame.HoverImage = sweeper.Theme.GameGood;
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LevelSelect();
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lvl = new DifficultyLevel(new Size(frm.SelectedWidth, frm.SelectedHeight), frm.SelectedMines);
            }
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = true;

            newToolStripMenuItem_Click(sender, e);
            ResizeFrm();
        }

        void ResizeFrm()
        {
            this.Size = new Size(sweeper.Width + 40, sweeper.Height + 109);
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvl = DifficultyLevels.Easy;
            beginnerToolStripMenuItem.Checked = true;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;

            newToolStripMenuItem_Click(sender, e);
            ResizeFrm();
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvl = DifficultyLevels.Intermediate;
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = true;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;

            newToolStripMenuItem_Click(sender, e);
            ResizeFrm();
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvl = DifficultyLevels.Expert;
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = true;
            customToolStripMenuItem.Checked = false;

            newToolStripMenuItem_Click(sender, e);
            ResizeFrm();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            btnGame.IdleImage = sweeper.Theme.GameGood;
            btnGame.DownImage = sweeper.Theme.GameGoodDown;
            btnGame.HoverImage = sweeper.Theme.GameGood;
        }

        private void sweeper_Lost(object sender, EventArgs e)
        {
            btnGame.IdleImage = sweeper.Theme.GameDead;
            btnGame.HoverImage = sweeper.Theme.GameDead;
        }

        private void sweeper_Won(object sender, EventArgs e)
        {
            btnGame.IdleImage = sweeper.Theme.GameWin;
            btnGame.HoverImage = sweeper.Theme.GameWin;
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
            btnGame.IdleImage = sweeper.Theme.GameGood;
            btnGame.HoverImage = sweeper.Theme.GameGood;
        }

        private void sweeper_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
                btnGame.IdleImage = sweeper.Theme.GameWarn;
        }

        private void sweeper_MouseUp(object sender, MouseEventArgs e)
        {
            btnGame.IdleImage = sweeper.Theme.GameGood;
        }

        private void sweeper_FlagCountChanged(object sender, int newflag)
        {
            counterControl1.Value = sweeper.Mines - newflag;
        }
    }
}
