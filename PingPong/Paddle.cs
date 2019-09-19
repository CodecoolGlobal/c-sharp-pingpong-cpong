using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PingPong
{
    internal class Paddle
    {
        Rectangle rectangle = new Rectangle();
        Canvas canvas;
        Powerup powerup;
        public int posX;
        public int posY;
        public int width = 200;
        public int height = 20;
        public int rightEdge;
        public bool powerUpPickedUp = false;
        int step = 5;

        public Paddle(Canvas canvas)
        {
            SolidColorBrush color = new SolidColorBrush();
            this.canvas = canvas;
            color.Color = Color.FromRgb(0, 0, 0);
            rectangle.Fill = color;
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = color;
            canvas.Children.Add(rectangle);
            posX = (int)(canvas.Width / 2) - (int)(rectangle.Width / 2);
            posY = (int)canvas.Height - 50;
            rightEdge = posX + width;
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
        }

        public void move(KeyDirection direction)
        {
            int newPosX = posX + ((int)direction * step);
            bool leftSideOut = newPosX < 0;
            bool rightSideOut = newPosX > canvas.Width - (width + 20);

            if (leftSideOut || rightSideOut)
            {
                newPosX = posX;
            }
            Canvas.SetLeft(rectangle, newPosX);
            posX = newPosX;
            rightEdge = posX + width;
        }

        public void checkTimer()
        {
            if (!powerup.isActive)
            {
                powerUpOff(powerup);
            }
        }

        public void pickUpPowerUp(Powerup powerup)
        {
            this.powerup = powerup;
            powerUpPickedUp = true;
            switch (powerup.type)
            {
                case PowerUpType.Type.Fast:
                    step *= 2;
                    break;

                case PowerUpType.Type.Slow:
                    step /= 2;
                    break;

                case PowerUpType.Type.Wide:
                    width *= 2;
                    rectangle.Width = width;
                    break;

                case PowerUpType.Type.Narrow:
                    width /= 2;
                    rectangle.Width = width;
                    break;
            }
        }

        public void powerUpOff(Powerup powerup)
        {
            powerUpPickedUp = false;
            switch (powerup.type)
            {
                case PowerUpType.Type.Fast:
                    step /= 2;
                    break;

                case PowerUpType.Type.Slow:
                    step *= 2;
                    break;

                case PowerUpType.Type.Wide:
                    width /= 2;
                    rectangle.Width = width;
                    break;

                case PowerUpType.Type.Narrow:
                    width *= 2;
                    rectangle.Width = width;
                    break;
            }
        }
    }
}
