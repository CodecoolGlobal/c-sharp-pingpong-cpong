using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;


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

        public MainWindow()
        {
            InitializeComponent();
            paddle = new Paddle(canvas);
            ball = new Ball(canvas);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
        }


            public void dispatcherTimer_tick(object sender, EventArgs e)
            {
                ball.movement();

                if (ball.x <= 0 || ball.x >= ActualWidth - 15)
                {
                    ball.bounceX();
                }

                if (ball.y <= 0 || ball.y >= ActualHeight - 15)
                {
                    ball.boudnceY();
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
                dispatcherTimer.IsEnabled = false;
                paused.Visibility = Visibility.Hidden;

            }
        }
    }

    

