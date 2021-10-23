using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace DD_File_Editor
{
    public class ToggleControl : CheckBox
    {
        Color ONBackColor = Color.MediumSlateBlue;
        Color ONToggleColor = Color.WhiteSmoke;
        Color OFFBackColor = Color.Gray;
        Color OFFToggleColor = Color.Gainsboro;


        GraphicsPath GetControlPath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize -2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();


            return path;
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                pevent.Graphics.FillPath(new SolidBrush(ONBackColor), GetControlPath());

                pevent.Graphics.FillEllipse(new SolidBrush(ONToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));

            }
            else
            {
                pevent.Graphics.FillPath(new SolidBrush(OFFBackColor), GetControlPath());

                pevent.Graphics.FillEllipse(new SolidBrush(OFFToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));

            }
        }

    }
}
