using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class KnightFactory : IPieceFactory
    {
        public override IPiece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new Knight(f, cpb);
        }
    }
}