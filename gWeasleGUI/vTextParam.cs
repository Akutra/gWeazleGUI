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
        bool validationError = false;

        const int WM_NC_PAINT = 0x85;
        //const int WM_PAINT = 0x0f;
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
            Color ExpectedColor = ColorDraw(m.Msg);
            if (
                m.Msg == WM_NC_PAINT &&
                !this.Multiline &&
                this.BorderStyle == BorderStyle.Fixed3D &&
                ExpectedColor != Color.Transparent)
            {
                Pen p = new Pen(ExpectedColor);

                IntPtr hWindowContext = GetWindowDC(this.Handle);
                Graphics g = Graphics.FromHdcInternal(hWindowContext);
                
                g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                
                ReleaseDC(this.Handle, hWindowContext);
                g.Dispose();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private Color ColorDraw(int msg)
        {
            if (this.Focused && !this.validationError)
                return focusColor;

            if (this.validationError)
                return errorColor;

            return Color.Transparent;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FLAGS);
        }
    }
}
