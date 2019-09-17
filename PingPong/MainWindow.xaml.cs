using System.Windows;
using System.Windows.Input;

namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Paddle paddle;
        public MainWindow()
        {
            InitializeComponent();
            paddle = new Paddle(canvas);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                paddle.move(Direction.Left);
            }

            if (e.Key == Key.Right)
            {
                paddle.move(Direction.Right);
            }
        }
    }
}
