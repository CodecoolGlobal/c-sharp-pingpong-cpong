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
        int x, y, size;
        int xdir, ydir;
        int speed = 5;

        public Ball(Canvas canvas)
        {

            SolidColorBrush color = new SolidColorBrush();
            x = 50;
            y = 50;
            size = 15;
            color.Color = Color.FromRgb(255,0,0);
            rectangle.Fill = color;
            rectangle.Width = size;
            rectangle.Height = size;
            Canvas.SetTop(rectangle, y);
            Canvas.SetLeft(rectangle, x);
            canvas.Children.Add(rectangle);
            
        }
    }
}
