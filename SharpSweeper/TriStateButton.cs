using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSweeper
{
    public delegate void StatusChangedEventHandler(object sender, bool newStatus);

    [Designer(typeof(GridControlDesigner))]
    public class TriStateButton : Control
    {
        public TriStateButton()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        #region Propriétés désactivées

        [Browsable(false)]
        public override System.Drawing.Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                this.Size = value.Size;
                //Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }


        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        #endregion


        private Image _idleimg, _hovimg, _downimg = null;

        [Category("Appearance")]
        public Image IdleImage
        {
            get { return _idleimg; }
            set { _idleimg = value; Invalidate(); }
        }

        [Category("Appearance")]
        public bool Toggle
        {
            get;
            set;
        }

        [Category("Appearance")]
        public Image HoverImage
        {
            get { return _hovimg; }
            set { _hovimg = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Image DownImage
        {
            get { return _downimg; }
            set { _downimg = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SetImage();
        }



        internal void SetImage()
        {
            if (_state)
            {
                if (_downimg != null)
                    this.BackgroundImage = _downimg;
            }
            else
            {
                if (_hover)
                {
                    if (_down)
                    {
                        if (_downimg != null)
                            this.BackgroundImage = _downimg;
                    }
                    else
                    {
                        if (_hovimg != null)
                            this.BackgroundImage = _hovimg;
                    }
                }
                else
                {
                    if (_idleimg != null)
                        this.BackgroundImage = _idleimg;
                }
            }
        }

        internal bool _hover = false;
        internal bool _down = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _hover = true;
            SetImage();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hover = false;
            SetImage();
        }



        public event StatusChangedEventHandler StatusChanged;

        protected virtual void OnStatusChanged()
        {
            if (StatusChanged != null)
                StatusChanged(this, _state);
        }

        public void ResetStatus()
        {
            _state = false;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if(Toggle)
            {
                _state = !_state;
                OnStatusChanged();
            }


            _down = true;

            SetImage();
        }

        public bool _state = false;

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);

            /*if(!Toggle)
            {
                _state = false;
            }
            
            if(_state)
            {
                _state = false;
            }*/

            _down = false;
            SetImage();
        }
    }
}
