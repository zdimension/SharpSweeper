namespace SharpSweeper
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bestTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterControl1 = new SharpSweeper.CounterControl();
            this.btnGame = new SharpSweeper.TriStateButton();
            this.sweeper = new SharpSweeper.GridControl();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(168, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem,
            this.toolStripSeparator2,
            this.bestTimesToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Checked = true;
            this.beginnerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beginnerToolStripMenuItem.Text = "&Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.intermediateToolStripMenuItem.Text = "&Intermediate";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.intermediateToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expertToolStripMenuItem.Text = "&Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customToolStripMenuItem.Text = "&Custom...";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // bestTimesToolStripMenuItem
            // 
            this.bestTimesToolStripMenuItem.Name = "bestTimesToolStripMenuItem";
            this.bestTimesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bestTimesToolStripMenuItem.Text = "Best &Times";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // counterControl1
            // 
            this.counterControl1.Digits = 3;
            this.counterControl1.Location = new System.Drawing.Point(12, 27);
            this.counterControl1.Name = "counterControl1";
            this.counterControl1.Size = new System.Drawing.Size(39, 23);
            this.counterControl1.TabIndex = 3;
            this.counterControl1.Text = "counterControl1";
            this.counterControl1.Value = 10;
            // 
            // btnGame
            // 
            this.btnGame.DownImage = null;
            this.btnGame.HoverImage = null;
            this.btnGame.IdleImage = null;
            this.btnGame.Location = new System.Drawing.Point(74, 27);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(23, 23);
            this.btnGame.TabIndex = 2;
            this.btnGame.Toggle = false;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // sweeper
            // 
            this.sweeper.Location = new System.Drawing.Point(12, 56);
            this.sweeper.Name = "sweeper";
            this.sweeper.Size = new System.Drawing.Size(144, 144);
            this.sweeper.TabIndex = 0;
            this.sweeper.Text = "gridControl1";
            this.sweeper.Won += new System.EventHandler(this.sweeper_Won);
            this.sweeper.Lost += new System.EventHandler(this.sweeper_Lost);
            this.sweeper.FlagCountChanged += new SharpSweeper.FlagCountChangedEventHandler(this.sweeper_FlagCountChanged);
            this.sweeper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sweeper_MouseDown);
            this.sweeper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sweeper_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 214);
            this.Controls.Add(this.counterControl1);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.sweeper);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SharpSweeper";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GridControl sweeper;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bestTimesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private TriStateButton btnGame;
        private CounterControl counterControl1;
    }
}

