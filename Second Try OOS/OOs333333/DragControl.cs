using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace drawing
{
    class DragControl : Component
    {
        private Control handleControl;

        public Control SelectControl
        {
            get
            {
                return this.handleControl;
            }
            set
            {
                this.handleControl = value;
                this.handleControl.MouseDown += new MouseEventHandler(this.DrageForm_MouseDown);
            }
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr a, int msg, int wParm, int iParm);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void DrageForm_MouseDown(object sender, MouseEventArgs e)
        {
            bool Flag = e.Button == MouseButtons.Left;
            if (Flag)
            {
                DragControl.ReleaseCapture();
                DragControl.SendMessage(this.SelectControl.FindForm().Handle, 161, 2, 0);
            }
        }

    }
}
