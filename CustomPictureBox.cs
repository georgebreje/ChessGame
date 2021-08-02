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


        public Piece Piece { get; set; }

        public CustomPictureBox(IContainer container)
        {
            container.Add(this);

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            // TODO
            // if there's another selected piece deselect it

            // select functionality
            clickCount++;
            if (clickCount % 2 == 0)
            {
                this.BackColor = AuxColor;
                Selected = false;
                Piece.Field.Selected = false;

            }
            else
            {
                this.BackColor = Color.Yellow;
                Selected = true;
                Piece.Field.Selected = true;
            }


            // available movements

            this.Piece.Direction();
            base.OnMouseClick(e);

        }




        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public bool ToDeselect()
        {
            if (this.BackColor != AuxColor)
                return true;
            return false;
        }
    }
}

