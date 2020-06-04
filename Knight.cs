using GraSzachy;
using nsFigura;

namespace nsKnight
{
    class Knight : Figura
    {
        public Knight(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Rycerz";
            this.Icon = color == fColor.Black ? "img/Knight.png" : "img/Knight_White.png";
            this.Power = 3;
            this.SetOnTable();
        }
        override public bool Move(int row, int col) // row & col są nową pozycją
        {
            int[] x = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] y = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for(int i = 0; i < x.Length; i++)
            {
                if((this.Position.Row - row == x[i]) && (this.Position.Col - col == y[i]))
                {
                    this.Position = new Cell(row, col);
                    return true;
                }
            }
            return false;
        }
    }
}
