using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class BishopFactory : IPieceFactory
    {
        public override Piece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new Bishop(f, cpb);
        }
    }
}
