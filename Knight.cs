using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Knight : Piece, IPiece
    {

        public Knight(Field f, CustomPictureBox cpb) : base(f, cpb)
        {
            PictureBox = cpb;
        }

        public override void Direction()
        {
            throw new NotImplementedException();
        }
    }
}
