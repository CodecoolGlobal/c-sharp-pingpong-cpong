using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ball ball;
        DispatcherTimer dispatcherTimer;
        Paddle paddle;
        Powerup powerup;
        int Score;

        public MainWindow()
        {
            InitializeComponent();
            ball = new Ball(canvas);
            powerup = new Powerup(canvas);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
            Score = 0;

        }


            public void dispatcherTimer_tick(object sender, EventArgs e)
            {
                ball.movement();
            powerup.movement();

            if(ball.x <= 0 || ball.x >= ActualWidth -30)
            {
                ball.bounceX();
                Score += 10;
                score.Content = "Score: " + Score;
            }

            if(ball.y <= 0)
            {
                ball.bounceY();
                Score += 10;
                score.Content = "Score: " + Score;
            }

            if (ball.y >= ActualHeight - 30)
            {
                ball.bounceY();
                Score -= 15;
                score.Content = "Score: " + Score;
            }

            if (ball.y >= paddle.posY - paddle.height && (paddle.posX <= ball.x && ball.x <= paddle.posX + paddle.width))
            {
                ball.bounceY();
            }
        }


            public void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (dispatcherTimer.IsEnabled)
                {
                    if (e.Key == Key.Space)
                    {
                        dispatcherTimer.IsEnabled = false;
                        paused.Visibility = Visibility.Visible;
                    }

                    if (e.Key == Key.Left)
                    {
                        paddle.move(Direction.Left);
                    }

                    if (e.Key == Key.Right)
                    {
                        paddle.move(Direction.Right);
                    }
            }
                else
                {
                    dispatcherTimer.IsEnabled = true;
                    paused.Visibility = Visibility.Hidden;
                }
                if (e.Key == Key.Escape)
                {
                    dispatcherTimer.IsEnabled = false;
                    MessageBoxResult result = MessageBox.Show("Are you sure to quit from the best game ever?", "PingPong", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Close();
                            break;
                        case MessageBoxResult.No:
                            dispatcherTimer.IsEnabled = true;
                            break;
                    }
                }
            }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            paddle = new Paddle(canvas);
            ball.spawn();
            powerup.spawn();
            dispatcherTimer.IsEnabled = false;
            paused.Visibility = Visibility.Hidden;
            score.Content = "Score: " + Score;
            Console.WriteLine(canvas.ActualWidth);
            Console.WriteLine(canvas.Width);
        }
    }
}
