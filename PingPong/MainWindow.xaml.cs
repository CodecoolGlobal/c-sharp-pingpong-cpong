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
        Paddle paddle;
        Powerup powerup;
        DispatcherTimer dispatcherTimer;
        DispatcherTimer _powerupTimer;
        int Score;
        int powerupTimer = 30;

        public MainWindow()
        {
            InitializeComponent();
            _powerupTimer = new DispatcherTimer();
            _powerupTimer.Interval = new TimeSpan(0, 0, 1);
            _powerupTimer.Tick += new EventHandler(powerupTimer_tick);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
            Score = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ball = new Ball(canvas);
            paddle = new Paddle(canvas);
            powerup = new Powerup(canvas);
            ball.spawn(Util.GetRandomNumber(30, (int)ActualWidth - 30), 50);
            powerup.spawn(Util.GetRandomNumber(30, (int)ActualWidth - 30), 50);
            dispatcherTimer.IsEnabled = false;
            _powerupTimer.IsEnabled = true;
            paused.Visibility = Visibility.Hidden;
            score.Content = "Score: " + Score;
        }

        public void dispatcherTimer_tick(object sender, EventArgs e)
        {
            ballActionsOnTimeTick();
            powerUpActionsOnTimeTick();
            if (paddle.powerUpPickedUp)
            {
                paddle.checkTimer();
            }
        }

        private void ballActionsOnTimeTick()
        {
            ball.movement();
            ball.checkCollision(paddle);
            if (ball.paddleHit)
            {
                Score += 15;
                score.Content = "Score: " + Score;
                ball.paddleHit = false;
            }

            if (ball.isOutOfWindow())
            {
                ball.spawn(Util.GetRandomNumber(30, (int)ActualWidth - 30), 50);
                Score -= 15;
                score.Content = "Score: " + Score;
            }
        }

        private void powerUpActionsOnTimeTick()
        {
            if (powerup.isSpawned)
            {
                powerup.movement();
                powerup.checkPaddleCollision(paddle);
            }
            if (powerup.paddleHit)
            {
                paddle.pickUpPowerUp(powerup);
                powerup.paddleHit = false;
                powerup.deSpawn();
            }

            if (powerup.isOutOfWindow())
            {
                powerup.spawn(Util.GetRandomNumber(30, (int)ActualWidth - 30), 50);
            }

            if (powerup.isActive)
            {
                powerup.checkTimeUp();
            }
        }

        public void powerupTimer_tick(object sender, EventArgs e)
        {

            powerupTimerLabel.Content = powerupTimer -= 1;
          
        }


        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (dispatcherTimer.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.Space:
                        dispatcherTimer.IsEnabled = false;
                        paused.Visibility = Visibility.Visible;
                        break;

                    case Key.Left:
                        paddle.move(KeyDirection.Left);
                        break;

                    case Key.Right:
                        paddle.move(KeyDirection.Right);
                        break;
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
    }
}
