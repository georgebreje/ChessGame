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
        public Pawn(Field f, CustomPictureBox pictureBox) : base(f, pictureBox)
        {

        }
        public void Direction()
        {
            throw new NotImplementedException();
        }
    }
}
