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
        public int x, y, size;
        int xdir, ydir;
        int speed = 5;

        public Ball(Canvas canvas)
        {

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

        public void span()
        {
            x = 50;
            y = 50;
            Canvas.SetTop(rectangle, y);
            Canvas.SetLeft(rectangle, x);
        }
        public void movement()
        {
            x += xdir;
            y += ydir;
            Canvas.SetTop(rectangle, y);
            Canvas.SetLeft(rectangle, x);
        }

        public void bounceX()
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

        public void boudnceY()
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
    }


}
