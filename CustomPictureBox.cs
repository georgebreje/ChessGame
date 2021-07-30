using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ChessGame
{
    public class CustomPictureBox : PictureBox
    {
        public bool Selected { get; set; } = true;
        public int ClickCount { get; set; }
        
        public CustomPictureBox(IContainer container)
        {
            container.Add(this);
        }

        Point point;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            point = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
                //this.Location = new Point(e.X, e.Y);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            ClickCount++;
            if (ClickCount % 2 == 0)
                this.BackColor = Color.Chocolate;
            else
                this.BackColor = Color.Yellow;
            base.OnMouseClick(e);
        }

    }
}