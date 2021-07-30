using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class IPieceFactory
    {
        public IPiece MakePiece()
        {
            IPiece piece = CreatePiece();

            return piece;
        }
        public abstract IPiece CreatePiece();
    }
}
