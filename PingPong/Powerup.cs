using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PingPong
{
    class Powerup
    {
        Rectangle rectangle = new Rectangle();
        Canvas canvas;
        Stopwatch stopwatch = new Stopwatch();
        public PowerUpType.Type type;
        public int posX, posY, size;
        public bool paddleHit = false;
        public bool isSpawned = false;
        public bool isActive = false;
        int speed = 5;
        int lifeSpanInSecs = 20;

        public Powerup(Canvas canvas)
        {
            this.canvas = canvas;
            SolidColorBrush color = new SolidColorBrush();
            size = 15;
            color.Color = Color.FromRgb(0, 255, 0);
            rectangle.Fill = color;
            rectangle.Width = size;
            rectangle.Height = size;
            canvas.Children.Add(rectangle);
        }

        public void spawn(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            type = PowerUpType.RandomType();
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
            isSpawned = true;
            rectangle.Visibility = Visibility.Visible;
        }

        public void deSpawn()
        {
            isSpawned = false;
            rectangle.Visibility = Visibility.Hidden;
            posX = 0;
            posY = 0;
        }

        public void movement()
        {
            posY += speed;
            Canvas.SetTop(rectangle, posY);
        }

        public void checkPaddleCollision(Paddle paddle)
        {
            bool ballAndPaddleSameHorizontal = paddle.posX <= posX && posX <= paddle.rightEdge;
            bool ballAndPaddleSameVertical = posY >= paddle.posY - paddle.height;

            if (ballAndPaddleSameHorizontal && ballAndPaddleSameVertical)
            {
                paddleHit = true;
                startTimer();
            }
        }

        public bool isOutOfWindow()
        {
            bool ballBottomOut = posY >= canvas.Height - 30;

            if (ballBottomOut)
            {
                return true;
            }
            return false;
        }

        private void startTimer()
        {
            stopwatch.Start();
            isActive = true;
        }

        private void stopTimer()
        {
            stopwatch.Stop();
            isActive = false;
        }

        public void checkTimeUp()
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            bool timeIsUp = lifeSpanInSecs <= timeSpan.TotalSeconds;

            if (timeIsUp)
            {
                stopTimer();
            }
        }
    }
}
