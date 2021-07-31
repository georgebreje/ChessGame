using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class IPieceFactory
    {
        public IPiece MakePiece(Field f, CustomPictureBox cpb)
        {
            IPiece piece = CreatePiece(f, cpb);

            return piece;
        }
        public abstract IPiece CreatePiece(Field f, CustomPictureBox cpb);
    }
}
