using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using nsFigura;
using nsPawn;
using nsRook;
using nsBishop;
using nsKnight;
using nsKing;
using nsQueen;
using nsChecker;

namespace GraSzachy
{
    class Chessboard
    {
        private readonly int size = 8;
        private readonly MainWindow mainWindow;
        private readonly Rectangle[,] rect;
        private Grid grid;
        private Button tmpButton;
        public Button[,] ButtonArray { get; set; }
        FigureList ListaFigur { get; set; }
        
        public Chessboard(MainWindow mainWindow)
        {
            staticCounter.Reset();
            this.mainWindow = mainWindow;
            this.ListaFigur = new FigureList
            {
                Figury = new List<Figura>()
            };
            this.ButtonArray = new Button[size, size];
            this.rect = new Rectangle[size, size];
            MakeGrid();
            AddButtons();
        }
        public void MakeGrid()
        {
            this.grid = new Grid();

            for (int row = 0; row < this.size; row++)
            {
                RowDefinition rowDefinition = new RowDefinition()
                { Name = "Row_" + row, Height = new GridLength(80, GridUnitType.Pixel) };
                this.grid.RowDefinitions.Add(rowDefinition);
            }
            for (int col = 0; col < this.size; col++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition()
                { Name = "Col_" + col, Width = new GridLength(80, GridUnitType.Pixel) };
                this.grid.ColumnDefinitions.Add(columnDefinition);
            }
            Grid.SetColumn(grid, 1);
            Grid.SetRow(grid, 1);
            this.mainWindow.Grid1.Children.Add(grid);
        }
        public void AddButtons()
        {
            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    ButtonArray[row, col] = new Button()
                    { Width = 60, Height = 60, Name = "Btn" + row.ToString() + col.ToString(), BorderThickness = new Thickness(0),
                      Tag = 0, Background = Brushes.Transparent };


                    ButtonArray[row, col].Click += Button_Click;

                    this.rect[row, col] = new Rectangle() { Width = 76, Height = 76, Stroke = Brushes.Black };

                    if ((row % 2 == 0 && col % 2 == 1) || (row % 2 == 1 && col % 2 == 0))
                    {
                        this.rect[row, col].Fill = Brushes.MediumPurple;
                    }
                    else
                    {
                        this.rect[row, col].Fill = Brushes.LightSkyBlue;
                    }
                    Grid.SetColumn(this.rect[row, col], col);
                    Grid.SetRow(this.rect[row, col], row);
                    grid.Children.Add(this.rect[row, col]);
                    Grid.SetColumn(ButtonArray[row, col], col);
                    Grid.SetRow(ButtonArray[row, col], row);
                    grid.Children.Add(ButtonArray[row, col]);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Tag.ToString());

            if (tmpButton != null)
            {
                int btnId = Int32.Parse(tmpButton.Tag.ToString());

                int row = Int32.Parse((sender as Button).Name.Substring(3, 1)); // nazwa Btn(2)2 - row
                int col = Int32.Parse((sender as Button).Name.Substring(4, 1)); // nazwa Btn2(2) - col

                if (SearchById(btnId).Move(row, col))
                {
                    (sender as Button).Background = this.tmpButton.Background;
                    (sender as Button).Tag = this.tmpButton.Tag;
                    tmpButton.Background = Brushes.Transparent;
                    tmpButton.Tag = 0;
                }
                else
                {
                    MessageBox.Show("Niedozwolony ruch!");
                }
                tmpButton = null;
            }
            else
            {
                tmpButton = (sender as Button);
                int btnId = Int32.Parse(tmpButton.Tag.ToString());
                if (btnId == 0) tmpButton = null;
            }
        }
        public void InsertFigure(Figura figura)
        {
            ListaFigur.Figury.Add(figura);
        }
        public void SetBlackChessPieces()
        {
            InsertFigure(new King(this, new Cell(0, 3), fColor.Black));
            InsertFigure(new Queen(this, new Cell(0, 4), fColor.Black));
            InsertFigure(new Bishop(this, new Cell(0, 2), fColor.Black));
            InsertFigure(new Bishop(this, new Cell(0, 5), fColor.Black));
            InsertFigure(new Knight(this, new Cell(0, 1), fColor.Black));
            InsertFigure(new Knight(this, new Cell(0, 6), fColor.Black));
            InsertFigure(new Rook(this, new Cell(0, 0), fColor.Black));
            InsertFigure(new Rook(this, new Cell(0, 7), fColor.Black));

            for (int j = 0; j < 8; j++)
                InsertFigure(new Pawn(this, new Cell(1, j), fColor.Black));
        }
        public void SetWhiteChessPieces()
        {
            InsertFigure(new King(this, new Cell(7, 3), fColor.White));
            InsertFigure(new Queen(this, new Cell(7, 4), fColor.White));
            InsertFigure(new Bishop(this, new Cell(7, 2), fColor.White));
            InsertFigure(new Bishop(this, new Cell(7, 5), fColor.White));
            InsertFigure(new Knight(this, new Cell(7, 1), fColor.White));
            InsertFigure(new Knight(this, new Cell(7, 6), fColor.White));
            InsertFigure(new Rook(this, new Cell(7, 0), fColor.White));
            InsertFigure(new Rook(this, new Cell(7, 7), fColor.White));

            for (int j = 0; j < 8; j++)
                InsertFigure(new Pawn(this, new Cell(6, j), fColor.White));
        }
        public void SetBlackCheckers()
        {
            int[,] array = new int[,] { { 0, 1 }, { 0, 3 }, { 0, 5 }, { 0, 7 }, { 1, 0 }, { 1, 2 }, { 1, 4 }, { 1, 6 },
            { 2, 1 }, { 2, 3 }, { 2, 5 }, { 2, 7 } };

            for(int i = 0; i < (array.Length/2); i++)
            {
                InsertFigure(new Checker(this, new Cell(array[i,0], array[i,1]), fColor.Black));
            }
        }
        public void SetWhiteCheckers()
        {
            int[,] array = new int[,] { { 5, 0 }, { 5, 2 }, { 5, 4 }, { 5, 6 }, { 6, 1 }, { 6, 3 }, { 6, 5 }, { 6, 7 },
            { 7, 0 }, { 7, 2 }, { 7, 4 }, { 7, 6 } };

            for (int i = 0; i < (array.Length / 2); i++)
            {
                InsertFigure(new Checker(this, new Cell(array[i, 0], array[i, 1]), fColor.White));
            }
        }
        public void SetAllChessPieces()
        {
            SetBlackChessPieces();
            SetWhiteChessPieces();
            MessageBox.Show(LiczbaFigur(fColor.Black) + LiczbaFigur(fColor.White));
            MessageBox.Show(WyswietlPozycjePionkow());
        }
        public void SetAllCheckers()
        {
            SetBlackCheckers();
            SetWhiteCheckers();
        }
        public void ShowAllFigureIds()
        {
            ListBox listBox = new ListBox() { Height = 400 };
            listBox.Margin = new Thickness(10, 10, 10, 10);

            foreach(Figura figura in ListaFigur)
            {
                listBox.Items.Add(figura.ToString());
                
            }
            Grid.SetColumn(listBox, 2);
            Grid.SetRow(listBox, 1);
            this.mainWindow.Grid1.Children.Add(listBox);
        }
        public Figura SearchById(int id)
        {
            if (id == 0) return (null);

            foreach (Figura figura in ListaFigur)
            {
                if (figura.Id == id) return (figura);
            }
            return (null);
        }
        public string LiczbaFigur(fColor color)
        {
            IEnumerable<Figura> wynik =
                from score in ListaFigur
                where score.Color == color
                select score;

            return "Liczba figur koloru '" + color + "' wynosi: " + wynik.Count().ToString() + "\n";
        }
        public string WyswietlPozycjePionkow()
        {
            string retString = "";
            IEnumerable<Figura> wynik =
                from score in ListaFigur
                where score.Name == "Pionek"
                select score;

            foreach(Figura pionek in wynik)
            {
                retString += "Pionek id: " + pionek.Id + " [Row:" + pionek.Position.Row.ToString() + ", Col:" + pionek.Position.Col.ToString() + "]\n";
            }
            return retString;
        }
    }
}
