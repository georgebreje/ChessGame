﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
    public interface IPiece
    {
        CustomPictureBox PictureBox { get; set; }

    }
}
