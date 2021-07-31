using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class RookFactory : IPieceFactory
    {
        public override Piece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new Rook(f, cpb);
        }
    }
}
