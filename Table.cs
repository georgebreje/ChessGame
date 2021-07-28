using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    public class Table
    {
        public Field[,] Fields { get; set; } = new Field[8, 8];

        public float Width { get; set; }

        public float Height { get; set; }

        public Field this[int row, int column]
        {
            get => Fields[row, column];
            set => Fields[row, column] = value;
        }

        public Table(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public void InitializeFields()
        {
            float BorderW = Width / 8;
            float BorderH = Height / 8;
            Field.a = 0;
            for (int i = 0; i < 8; i++)
            {
                Field.b = 0;
                for (int j = 0; j < 8; j++)
                {
                    Field f = new Field(BorderW, BorderH);
                    f.CreatePolygon();
                    Fields[i, j] = f;
                    Field.b += BorderW;
                }
                Field.a += BorderH;
            }

        }
    }
}
