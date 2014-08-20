using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SharpSweeper
{
    public class GridControlDesigner : ControlDesigner
    {
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                return (base.SelectionRules & ~(SelectionRules.AllSizeable));
            }
        }
    }

    public delegate void FlagCountChangedEventHandler(object sender, int newflag);

    [Designer(typeof(GridControlDesigner))]
    public class GridControl : Control
    {
        public event EventHandler Won;

        protected virtual void OnWon()
        {
            if (Won != null)
                Won(this, null);
        }

        public event EventHandler Lost;

        protected virtual void OnLost()
        {
            if (Lost != null)
                Lost(this, null);
        }

        public event FlagCountChangedEventHandler FlagCountChanged;

        protected virtual void OnFlagCountChanged()
        {
            if (FlagCountChanged != null)
                FlagCountChanged(this, TotalFlags);
        }





        public SweeperTheme Theme { get; set; }

        public int Mines { get; private set; }

        DifficultyLevel curlevel;

        private Point LastClick;

        public Tile[,] Grid { get; private set; }

        bool waiting = true;
        bool playing = false;
        bool won = false;
        bool lost = false;

        public int TotalFlags { get { return Grid.OfType<Tile>().Count(x => x.Status == TileStatus.Flagged); } }

        int goodflags = 0;

        public int Rows
        {
            get { return Grid.GetLength(0); }
        }

        public int Cols
        {
            get { return Grid.GetLength(1); }
        }


        #region Internal functions
        private void SetDimensions(int rows, int cols)
        {
            Grid = new Tile[rows, cols];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    Grid[r, c] = new Tile(r, c);
                }
            }

            this.Size = new Size(cols * Theme.GridSize.Width, rows * Theme.GridSize.Height);
        }

        private int SurroundingMines(int row, int col)
        {
            int count = 0;
            for (int r = row - 1; r <= row + 1; ++r)
            {
                for (int c = col - 1; c <= col + 1; ++c)
                {
                    if (IsInside(r, c) && Grid[r, c].Mine)
                        count++;
                }
            }
            return count;
        }

        public bool Open(int row, int col)
        {
            var open = Grid[row, col].Open();
           // if (!open) return false;
            if (SurroundingMines(row, col) == 0)
            {
                for (int r = row - 1; r <= row + 1; ++r)
                {
                    for (int c = col - 1; c <= col + 1; ++c)
                    {
                        if (IsInside(r, c))
                            Grid[r, c].Open();
                    }
                }
            }

            LastClick = new Point(col, row);

            if(Grid[row, col].Mine)
            {
                playing = false;
                lost = true;

                Grid[row, col].Status = TileStatus.Shown;

                foreach(Tile t in Grid)
                {
                    if(t.Mine)
                    {
                        Grid[t.Row, t.Column].Status = TileStatus.Shown;
                    }
                }

                OnLost();

                waiting = true;
            }


            Invalidate();
            //Grid[row, col].Open();
            return true;
        }

        public void Flag(int row, int col)
        {
            Grid[row, col].Flag();
            OnFlagCountChanged();

            if(Grid[row, col].Mine)
            {
                if (Grid[row, col].Status == TileStatus.Flagged)
                    goodflags++;
                else
                    goodflags--;
            }

            if(goodflags == Mines)
            {
                playing = false;
                won = true;
                Invalidate();
                OnWon();
            }

            Invalidate();
        }

        private bool IsInside(int r, int c)
        {
            return r >= 0 && c >= 0 && r < Rows && c < Cols;
        }

        private void SetNumberOfMines(int count)
        {
            Mines = count;
            var random = new Random();

            var placed = 0;
            while (placed < count)
            {
                var row = random.Next() % Rows;
                var col = random.Next() % Cols;
                if (!Grid[row, col].Mine)
                {
                    Grid[row, col].Mine = true;
                    placed++;
                }
            }
        }
        #endregion

        public GridControl()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.Theme = Themes.XP;
            NewGame(DifficultyLevels.Easy);
        }

        public void NewGame(DifficultyLevel level)
        {
            curlevel = level;
            SetDimensions(level.GridSize.Height, level.GridSize.Width);
            SetNumberOfMines(level.MineCount);
            OnFlagCountChanged();
            Invalidate();
        }

        internal Point GetPosGrid(Point f)
        {
            return new Point(Convert.ToInt32(Math.Ceiling(0.0 + f.X / Theme.GridSize.Width)), Convert.ToInt32(Math.Ceiling(0.0 + f.Y / Theme.GridSize.Height)));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
 	        base.OnMouseDown(e);
            if(waiting)
            {
                waiting = false;
                playing = true;

                if (lost)
                    NewGame(curlevel);
            }

            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (lost)
                lost = false;
            else
            {


                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    Open(GetPosGrid(e.Location).Y, GetPosGrid(e.Location).X);
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    Flag(GetPosGrid(e.Location).Y, GetPosGrid(e.Location).X);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach(Tile t in Grid)
            {
                Image ti = Theme.EmptyHiddenPicture;

                switch(t.Status)
                {
                    case TileStatus.Hidden:
                        ti = Theme.EmptyHiddenPicture;
                        break;
                    case TileStatus.Flagged:
                        ti = Theme.FlagPicture;
                        break;
                    case TileStatus.Shown:
                        if (!t.Mine && SurroundingMines(t.Row, t.Column) == 0)
                            ti = Theme.EmptyPicture;
                        else if (!t.Mine)
                        {
                            switch (SurroundingMines(t.Row, t.Column))
                            {
                                case 1:
                                    ti = Theme.OnePicture;
                                    break;
                                case 2:
                                    ti = Theme.TwoPicture;
                                    break;
                                case 3:
                                    ti = Theme.ThreePicture;
                                    break;
                                case 4:
                                    ti = Theme.FourPicture;
                                    break;
                                case 5:
                                    ti = Theme.FivePicture;
                                    break;
                                case 6:
                                    ti = Theme.SixPicture;
                                    break;
                                case 7:
                                    ti = Theme.SevenPicture;
                                    break;
                                case 8:
                                    ti = Theme.EightPicture;
                                    break;
                            }
                        }
                        else
                        {
                            if (t.Row == LastClick.Y && t.Column == LastClick.X)
                                ti = Theme.DahMinePicture;
                            else
                                ti = Theme.MinePicture;
                        }
                        break;
                }

                e.Graphics.DrawImage(ti, t.Column * Theme.GridSize.Width, t.Row * Theme.GridSize.Height, Theme.GridSize.Width, Theme.GridSize.Height);
            }
        }
    }

    public class DifficultyLevel
    {
        public Size GridSize { get; set; }

        public int MineCount { get; set; }

        public DifficultyLevel(Size gsize, int mines)
        {
            GridSize = gsize;
            MineCount = mines;
        }
    }

    public class DifficultyLevels
    {
        public static DifficultyLevel Easy = new DifficultyLevel(new Size(9, 9), 10);
        public static DifficultyLevel Intermediate = new DifficultyLevel(new Size(16, 16), 40);
        public static DifficultyLevel Expert = new DifficultyLevel(new Size(30, 16), 99);
    }

    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool Mine { get; set; }

        public TileStatus Status { get; set; }

        public void Flag()
        {
            if(Status != TileStatus.Shown)
            {
                Status = (Status != TileStatus.Flagged) ? TileStatus.Flagged : TileStatus.Hidden;
            }
        }

        public bool Open()
        {
            Status = TileStatus.Shown;
            return !Mine;
        }

        public Tile(int row, int column, bool mine = false)
        {
            Row = row;
            Column = column;
            Status = TileStatus.Hidden;
            Mine = mine;
        }
    }

    public enum TileStatus
    {
        Hidden,
        Shown,
        Flagged
    }
}
