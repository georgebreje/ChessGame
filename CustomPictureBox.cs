using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ChessGame
{
    public class CustomPictureBox : PictureBox
    {
        private int clickCount;
        public Color AuxColor;
        public bool Selected { get; set; } = false;
        public CustomPictureBox(IContainer container)
        {
            container.Add(this);
            
        }

        Point point;

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Left += e.X - point.X;
        //        this.Top += e.Y - point.Y;
        //        //this.Location = new Point(e.X, e.Y);
        //    }
        //    base.OnMouseMove(e);
        //}

        protected override void OnMouseClick(MouseEventArgs e)
        {
            // TODO
            // if there's another selected piece deselect it

            clickCount++;
            
            if (clickCount % 2 == 0)
            {
                this.BackColor = AuxColor;
                Selected = false;
            }
            else
            {
                this.BackColor = Color.Yellow;
                Selected = true;
            }
            base.OnMouseClick(e);
        }

        public bool ToDeselect()
        {
            if (this.BackColor != AuxColor)
                return true;
            return false;
        }
    }
}
