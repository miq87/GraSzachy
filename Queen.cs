using GraSzachy;
using nsFigura;

namespace nsQueen
{
    class Queen : Figura
    {
        public Queen(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Królowa";
            this.Icon = color == fColor.Black ? "img/Queen.png" : "img/Queen_White.png";
            this.Power = 9;
            this.SetOnTable();
        }
        override public bool Move(int row, int col)
        {
            int[] x = { 1, 2, 3, 4, 5, 6, 7,
                        1, 2, 3, 4, 5, 6, 7,
                        -1, -2, -3, -4, -5, -6, -7,
                        -1, -2, -3, -4, -5, -6, -7,
                        1, 2, 3, 4, 5, 6, 7,
                        -1, -2, -3, -4, -5, -6, -7,
                        0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0
            };
            int[] y = { -1, -2, -3, -4, -5, -6, -7,
                        1, 2, 3, 4, 5, 6, 7,
                        1, 2, 3, 4, 5, 6, 7,
                        -1, -2, -3, -4, -5, -6, -7,
                        0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0,
                        1, 2, 3, 4, 5, 6, 7,
                        -1, -2, -3, -4, -5, -6, -7
            };

            for (int i = 0; i < x.Length; i++)
            {
                if (((this.Position.Row - row == x[i]) && (this.Position.Col - col == y[i])))
                {
                    this.Position = new Cell(row, col);
                    return true;
                }
            }
            return false;
        }
    }
}
