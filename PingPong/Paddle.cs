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
        int posX;
        int posY = 350;
        int width = 200;
        int height = 20;
        int step = 10;
        int leftEdge, rightEdge;

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
            Canvas.SetTop(rectangle, posY);
            posX = (int)(canvas.Width / 2) - (int)(rectangle.Width / 2);
            Canvas.SetLeft(rectangle, posX);
        }

        public void move(Direction direction)
        {
            int newPosX = posX + ((int)direction * step);
            if (newPosX < 0 || newPosX > canvas.Width - width)
            {
                newPosX = posX;
            }
            Canvas.SetLeft(rectangle, newPosX);
            posX = newPosX;
        }
    }
}
