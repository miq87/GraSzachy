using System.Windows;
using System.Windows.Controls;

namespace GraSzachy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal object Grid1;
        private Chessboard myBoard;
        public MainWindow()
        {
            InitializeComponent();
            myBoard = new Chessboard(this);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content.ToString().Equals("SZACHY"))
            {
                myBoard = new Chessboard(this);
                myBoard.SetAllChessPieces();
                myBoard.ShowAllFigureIds();
            }
            else
            {
                myBoard = new Chessboard(this);
                myBoard.SetAllCheckers();
                myBoard.ShowAllFigureIds();
            }  
        }
    }
}
