using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public abstract class Piece
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public abstract PictureBox PictureBox { get; set; }

        public abstract void Direction();


    }
}
