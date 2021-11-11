using System;
using System.Drawing;
using System.Windows.Forms;
using Plasmoid.Extensions;

/*
 * Class defines a standard 6-side die by default, but allows up to 9-sides.  A
 * method is provided to 'roll' the die.  Default constructor creates an
 * 'empty' die.  The other constructors create the die with the appropriate die
 * face, rotation value and number of sides (faces).
 * You should really only set the size, fore color and back color for this
 * component.  Height and Width should be equal sizes, though don't have
 * to be.  Anything smaller than ~30x30 starts to draw funny.  Typically, a
 * 50x50 size is really good.  Corner radius > 10 start to look a little
 * circle-ish.
 * To reset border color back to use the set fore color, use Color.Empty as
 * the value of the border color.
 * Component uses a custom OnPaint, a custom OnBackColorChanged and a
 * custom OnForeColorChanged method (overrides).
 * Paint event inspired by a Dice component created for Delphi (author unknown).
 *
 * Author:  M. G. Slack
 * Written: 2014-01-29
 * Version: 1.0.2.0
 *
 * ----------------------------------------------------------------------------
 * 
 * Updated: 2014-02-07 - Updated to be up to a 9-sided die.  Added rounded
 *                       corners to the die, on by default, but can be turned
 *                       off.  Also added a radius property (range 5 - 30) for
 *                       the rounded corner radius.
 *          2014-02-28 - Overrode the border style property to not allow it to
 *                       change from BorderStyle.None. Added a BorderColor
 *                       property, might be useful for implementing 'selected'
 *                       Die.
 *
 */
namespace Dice
{
    /* Die face value enum.  dfn0 is blank (empty), otherwise value is 1 - 9. */
    public enum DieFace { dfn0, dfn1, dfn2, dfn3, dfn4, dfn5, dfn6, dfn7, dfn8, dfn9 };

    /*
     * Rotation to do to die for display.  Only affects 2, 3, 6 and 7.
     * Default (no rotation) view:
     * [   ] [o  ] [o  ] [o o] [o o] [o o] [o o] [ooo] [ooo]
     * [ o ] [   ] [ o ] [   ] [ o ] [o o] [ooo] [o o] [ooo]
     * [   ] [  o] [  o] [o o] [o o] [o o] [o o] [ooo] [ooo]
     * Rotated left view:
     * [   ] [  o] [  o] [o o] [o o] [ooo] [ooo] [ooo] [ooo]
     * [ o ] [   ] [ o ] [   ] [ o ] [   ] [ o ] [o o] [ooo]
     * [   ] [o  ] [o  ] [o o] [o o] [ooo] [ooo] [ooo] [ooo]
     */
    public enum DieRotation { Default, RotateLeft, RotateRandom };

    public class Die : UserControl
    {
        private const int OFFSET_DIV = 20;

        private readonly static Color DEF_FORECOLOR = Color.Black;
        private readonly static Color DEF_BACKCOLOR = Color.White;

        private System.ComponentModel.IContainer components = null;
        private Pen pen = new Pen(DEF_FORECOLOR); // border
        private Brush brush = new SolidBrush(DEF_FORECOLOR); // die dots
        private Brush backBrush = new SolidBrush(DEF_BACKCOLOR); // die face color
        private bool rotate23 = false, rotate6 = false;

        // --------------------------------------------------------------------

        #region Properties

        private bool _borderColorSet = false;
        private Color _borderColor = DEF_FORECOLOR;
        public Color BorderColor { 
            get { return _borderColor; }
            set { _borderColorSet = !(value == Color.Empty);
                  if (_borderColorSet)
                      _borderColor = value;
                  else
                      _borderColor = this.ForeColor;
                  pen = new Pen(_borderColor);
                  this.Invalidate(); }
        }
        
        public new BorderStyle BorderStyle {
            get { return base.BorderStyle; }
            set { base.BorderStyle = BorderStyle.None; }
        }

        /* Range is 5 - 30 - default = 6 */
        private int _cornerRadius = 6;
        public int CornerRadius {
            get { return _cornerRadius; }
            set { if ((value >= 5) && (value <= 30)) {
                      _cornerRadius = value;
                      this.Invalidate();
                  } }
        }

        private DieFace _face = DieFace.dfn0;
        public DieFace Face {
            get { return _face; }
            set { if (value <= _maxFaces) {
                      _face = value;
                      CheckRotation();
                      this.Invalidate();
                  } }
        }

        private DieFace _maxFaces = DieFace.dfn6; // default to 6-sided die
        public DieFace MaxFaces {
            get { return _maxFaces; }
            set { _maxFaces = value; if (_face > _maxFaces) Face = _maxFaces; }
        }

        private DieRotation _rotation = DieRotation.Default;
        public DieRotation Rotation { 
            get { return _rotation; }
            set { _rotation = value;
                  CheckRotation();
                  this.Invalidate(); }
        }

        private bool _roundedCorners = true;
        public bool RoundedCorners
        {
            get { return _roundedCorners; }
            set { _roundedCorners = value; this.Invalidate(); }
        }

        public int Value { get { return (int) _face; } }

        #endregion

        // --------------------------------------------------------------------

        #region Constructors

        /* Empty die creation, dfn0, max dfn6 (6 sided) and default (no) rotation. */
        public Die() : this(DieFace.dfn6, DieFace.dfn0, DieRotation.Default) { }

        /* Die with dfn0 face, max dfn6 (6 sided) and given rotation value. */
        public Die(DieRotation rotation) : this(DieFace.dfn6, DieFace.dfn0, rotation) { }

        /* Die with given initial face value, max dfn6 (6 sided) and default (no) rotation. */
        public Die(DieFace curFace) : this(DieFace.dfn6, curFace, DieRotation.Default) { }

        /* Die with given initial face value and max faces (sides). */
        public Die(DieFace maxFaces, DieFace curFace) : this(maxFaces, curFace, DieRotation.Default) { }

        /* Die created with given face value, and rotation value. */
        public Die(DieFace maxFaces, DieFace curFace, DieRotation rotation)
        {
            InitializeComponent();
            _maxFaces = maxFaces;
            if (curFace <= _maxFaces) _face = curFace; // else leave at dfn0
            _rotation = rotation;
            CheckRotation();
        }

        #endregion

        // --------------------------------------------------------------------

        #region Private methods

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Die
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = DEF_BACKCOLOR;
            this.ForeColor = DEF_FORECOLOR;
            this.Name = "Die";
            this.Size = new Size(100, 100);
            this.ResumeLayout(false);
        }

        private void CheckRotation()
        {
            rotate23 = false;
            rotate6 = false;

            if (_rotation != DieRotation.Default) {
                bool rotate = (DieRotation.RotateRandom == _rotation) ? SingleRandom.Instance.Next(100) > 50 : true;
                if ((rotate) && ((_face == DieFace.dfn2) || (_face == DieFace.dfn3)))
                    rotate23 = true;
                if ((rotate) && ((_face == DieFace.dfn6) || (_face == DieFace.dfn7)))
                    rotate6 = true;
            }
        }

        #endregion

        // --------------------------------------------------------------------

        #region Protected / Overridden methods

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            backBrush = new SolidBrush(this.BackColor);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (!_borderColorSet) _borderColor = this.ForeColor;
            pen = new Pen(_borderColor);
            brush = new SolidBrush(this.ForeColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            int x, y, w, h, offw, offh;

            if (_roundedCorners) {
                graphics.Clear(this.Parent.BackColor); // make rounded background 'pseudo-transparent'
                graphics.FillRoundedRectangle(backBrush, 1, 1, this.Width-2, this.Height-2, _cornerRadius);
                graphics.DrawRoundedRectangle(pen, 0, 0, this.Width-1, this.Height-1, _cornerRadius);
            }
            else {
                graphics.Clear(this.BackColor);
                graphics.DrawRectangle(pen, 0, 0, this.Width-1, this.Height-1);
            }

            // use the offsets to spread out the 'dots' a little when painting them
            // paint routine this is based on seem to have the dots a little squeezed together
            offw = (this.Width > OFFSET_DIV) ? this.Width / OFFSET_DIV : 0;
            offh = (this.Height > OFFSET_DIV) ? this.Height / OFFSET_DIV : 0;

            // 1, 3, 5, 7, 9 (center dot)
            if ((_face == DieFace.dfn1) || (_face == DieFace.dfn3) || (_face == DieFace.dfn5) ||
                (_face == DieFace.dfn7) || (_face == DieFace.dfn9)) {
                x = (this.Width / 2) - ((this.Width / 5) / 2); y = (this.Height / 2) - ((this.Height / 5) / 2);
                w = (this.Width / 2) + ((this.Width / 5) / 2) - x; h = (this.Height / 2) + ((this.Height / 5) / 2) - y;
                graphics.FillEllipse(brush, x, y, w, h);
            }

            // (2, 3) - default, 4, 5, 6, 7, 8, 9 (up left, lower right dot)
            if ((_face != DieFace.dfn0) && (_face != DieFace.dfn1) && (!rotate23)) {
                x = this.Width / 5; y = this.Height / 5;
                w = ((this.Width / 5) * 2) - x; h = ((this.Height / 5) * 2) - y;
                graphics.FillEllipse(brush, x - offw, y - offh, w, h);
                x = this.Width - ((this.Width / 5) * 2); y = this.Height - ((this.Height / 5) * 2);
                w = this.Width - (this.Width / 5) - x; h = this.Height - (this.Height / 5) - y;
                graphics.FillEllipse(brush, x + offw, y + offh, w, h);
            }

            // (2, 3) - rotated, 4, 5, 6, 7, 8, 9 (up right, lower left dot)
            if ((rotate23) || (_face >= DieFace.dfn4)) {
                x = this.Width - ((this.Width / 5) * 2); y = this.Height / 5;
                w = this.Width - (this.Width / 5) - x; h = ((this.Height / 5) * 2) - y;
                graphics.FillEllipse(brush, x + offw, y - offh, w, h);
                x = this.Width / 5; y = this.Height - ((this.Height / 5) * 2);
                w = ((this.Width / 5) * 2) - x; h = this.Height - (this.Height / 5) - y;
                graphics.FillEllipse(brush, x - offw, y + offh, w, h);
            }

            // 6, 7, 8, 9 (upper middle and lower middle AND/OR left middle and right middle dot)
            if (_face >= DieFace.dfn6) {
                if ((rotate6) || (_face == DieFace.dfn8) || (_face == DieFace.dfn9)) {
                    x = (this.Width / 2) - ((this.Width / 5) / 2); y = this.Height / 5;
                    w = (this.Width / 2) + ((this.Width / 5) / 2) - x; h = ((this.Height / 5) * 2) - y;
                    graphics.FillEllipse(brush, x, y - offh, w, h);
                    x = (this.Width / 2) - ((this.Width / 5) / 2); y = this.Height - ((this.Height / 5) * 2);
                    w = (this.Width / 2) + ((this.Width / 5) / 2) - x; h = this.Height - (this.Height / 5) - y;
                    graphics.FillEllipse(brush, x, y + offh, w, h);
                }
                if ((!rotate6) || (_face == DieFace.dfn8) || (_face == DieFace.dfn9)) {
                    x = this.Width / 5; y = (this.Height / 2) - ((this.Height / 5) / 2);
                    w = ((this.Width / 5) * 2) - x; h = (this.Height / 2) + ((this.Height / 5) / 2) - y;
                    graphics.FillEllipse(brush, x - offw, y, w, h);
                    x = this.Width - ((this.Width / 5) * 2); y = (this.Height / 2) - ((this.Height / 5) / 2);
                    w = this.Width - (this.Width / 5) - x; h = (this.Height / 2) + ((this.Height / 5) / 2) - y;
                    graphics.FillEllipse(brush, x + offw, y, w, h);
                }
            }
        }

        #endregion

        // --------------------------------------------------------------------

        /*
         * Method allows a random die roll to be performed on the Die component.
         * Sets the die face to a random value (dfn1 - MaxFaces).
         * If MaxFaces is dfn0, this method does nothing.
         */
        public void RollDie()
        {
            if (_maxFaces > DieFace.dfn0) {
                SingleRandom rnd = SingleRandom.Instance;
                int roll = rnd.Next((int) _maxFaces) + 1; // rnd's range is 0 - up to 8
                Face = (DieFace) roll;
            }
        }
    }
}
