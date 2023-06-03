using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gWeasleGUI
{
    public class vTextParam : TextBox
    {
        Color errorColor = Color.Red;
        Color focusColor = Color.Blue;
        Color borderColor = Color.Transparent;
        bool validationError = false;
        bool didPaint = false;

        const int WM_NCPAINT = 0x85;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;
        const uint RDW_FLAGS = RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE;

        // Imports
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        
        public bool ValidationFailure
        {
            get { return validationError; }
            set
            {
                validationError = value;
                RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FLAGS);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Color ExpectedColor = ColorDraw(m.Msg);
            if (ExpectedColor != Color.Transparent && borderColor != ExpectedColor)
            {
                Pen p = new Pen(ExpectedColor);

                IntPtr hWindowContext = GetWindowDC(this.Handle);
                using (Graphics g = Graphics.FromHdcInternal(hWindowContext))
                {
                    g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                    borderColor = p.Color;
                }
                
                ReleaseDC(this.Handle, hWindowContext);
            }
        }

        private Color ColorDraw(int msg)
        {
            if(msg == WM_NCPAINT && BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                if (this.Focused)
                    return focusColor;

                if (this.validationError)
                    return errorColor;
            }
            return Color.Transparent;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            borderColor = Color.Transparent;
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FLAGS);
        }
    }
}
