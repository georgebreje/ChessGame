using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Pawn : Piece, IPiece
    {
        public bool FirstMove { get; set; } = true;
        public Pawn(Field f, CustomPictureBox pictureBox) : base(f, pictureBox)
        {

        }

        public override void Direction()
        {


            int i = this.Field.Row;
            int j = this.Field.Col;
            if (this.Black == true)
            {
                if (FirstMove == true)
                {
                    Form1.Fields[i + 1, j].Select(Form1.grp);
                    Form1.Fields[i + 2, j].Select(Form1.grp);
                }
                else
                {
                    Form1.Fields[i + 1, j].Select(Form1.grp);
                }
            }
            else if (this.White == true)
            {
                if (FirstMove == true)
                {
                    Form1.Fields[i - 1, j].Select(Form1.grp);
                    Form1.Fields[i - 2, j].Select(Form1.grp);
                }
                else
                {
                    Form1.Fields[i - 1, j].Select(Form1.grp);
                }
            }







        }
    }
}
