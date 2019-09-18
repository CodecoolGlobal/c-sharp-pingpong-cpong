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
    class Powerup
    {
        Rectangle rectangle = new Rectangle();
        public int posX, posY, size;
        int speed = 5;

        public Powerup(Canvas canvas)
        {
            SolidColorBrush color = new SolidColorBrush();
            size = 15;
            color.Color = Color.FromRgb(0, 255, 0);
            rectangle.Fill = color;
            rectangle.Width = size;
            rectangle.Height = size;
            canvas.Children.Add(rectangle);
        }

        public void spawn()
        {
            posX = 50;
            posY = 50;
            Canvas.SetLeft(rectangle, posX);
            Canvas.SetTop(rectangle, posY);
        }

        public void movement()
        {
            posY += speed;
            Canvas.SetTop(rectangle, posY);
        }
    }
}
