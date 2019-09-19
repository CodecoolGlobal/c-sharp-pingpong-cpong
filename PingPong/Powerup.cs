using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PingPong
{
    class Powerup
    {
        Rectangle rectangle = new Rectangle();
        Canvas canvas;
        public int posX, posY, size;
        int speed = 5;
        public bool paddleHit = false;

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
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
            rectangle.Visibility = Visibility.Visible;
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
                rectangle.Visibility = Visibility.Hidden;
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
    }
}
