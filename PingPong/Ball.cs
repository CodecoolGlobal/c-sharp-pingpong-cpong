using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PingPong
{
    class Ball
    {
        Rectangle rectangle = new Rectangle();
        public int posX, posY, size;
        int xdir, ydir;
        int speed = 5;
        Canvas canvas;
        public bool paddleHit = false;

        public Ball(Canvas canvas)
        {
            this.canvas = canvas;
            SolidColorBrush color = new SolidColorBrush();
            size = 15;
            xdir = speed;
            ydir = speed;
            color.Color = Color.FromRgb(255,0,0);
            rectangle.Fill = color;
            rectangle.Width = size;
            rectangle.Height = size;
            canvas.Children.Add(rectangle);
        }

        public void spawn(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            Canvas.SetTop(rectangle, posY);
            Canvas.SetLeft(rectangle, posX);
        }
        public void movement()
        {
            posX += xdir;
            posY += ydir;
            Canvas.SetTop(rectangle, posY);
            Canvas.SetLeft(rectangle, posX);
        }

        public void bounceFromVertical()
        {
            if(xdir == 5)
            {
                xdir = -5;
            }
            else
            {
                xdir = 5;
            }
        }

        public void bounceFromHorizontal()
        {
            if(ydir == 5)
            {
                ydir = -5;
            }
            else
            {
                ydir = 5;
            }
        }

        public void checkCollision(Paddle paddle)
        {
            checkVerticalWallCollision();
            checkHorizontalWallCollision();
            checkPaddleCollision(paddle);
        }

        public bool isOutOfBounds()
        {
            if (posY >= canvas.Height - 30)
            {
                bounceFromHorizontal();
                return true;
            }
            return false;
        }

        private void checkPaddleCollision(Paddle paddle)
        {
            if (posY >= paddle.posY - paddle.height && (paddle.posX <= posX && posX <= paddle.posX + paddle.width))
            {
                paddleHit = true;
                bounceFromHorizontal();
            }
            paddleHit = false;
        }

        private void checkHorizontalWallCollision()
        {
            if (posY <= 0)
            {
                bounceFromHorizontal();
            }
        }

        private void checkVerticalWallCollision()
        {
            if (posX <= 0 || posX >= canvas.Width - 30)
            {
                bounceFromVertical();
            }
        }
    }


}
