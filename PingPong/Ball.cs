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
        BallDirection.Direction directionX, directionY;
        Canvas canvas;
        public int posX, posY;
        int size = 15;
        int speed = 5;
        public bool paddleHit = false;

        public Ball(Canvas canvas)
        {
            this.canvas = canvas;
            SolidColorBrush color = new SolidColorBrush();
            directionX = BallDirection.RandomDirection();
            directionY = BallDirection.Direction.Positive;
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
            directionX = BallDirection.RandomDirection();
            directionY = BallDirection.Direction.Positive;
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
        }
        public void movement()
        {
            posX += speed * (int)directionX;
            posY += speed * (int)directionY;
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
        }

        public void checkCollision(Paddle paddle)
        {
            checkWallCollision();
            checkPaddleCollision(paddle);
        }

        private void checkWallCollision()
        {
            bool ballLeftSideOut = posX <= 0;
            bool ballRightSideOut = posX >= canvas.Width - 30;
            bool ballTopOut = posY <= 0;

            if (ballLeftSideOut || ballRightSideOut)
            {
                bounce(WallPlane.Vertical);
            }

            if (ballTopOut)
            {
                bounce(WallPlane.Horizontal);
            }
        }

        private void checkPaddleCollision(Paddle paddle)
        {
            bool ballAndPaddleSameHorizontal = paddle.posX <= posX && posX <= paddle.rightEdge;
            bool ballAndPaddleSameVertical = posY >= paddle.posY - paddle.height;

            if (ballAndPaddleSameHorizontal && ballAndPaddleSameVertical)
            {
                paddleHit = true;
                bounce(WallPlane.Horizontal);
            }
        }

        public void bounce(WallPlane plane)
        {
            if (plane.Equals(WallPlane.Vertical))
            {
                directionX = BallDirection.SwitchDirection(directionX);
            }
            if (plane.Equals(WallPlane.Horizontal))
            {
                directionY = BallDirection.SwitchDirection(directionY);
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
