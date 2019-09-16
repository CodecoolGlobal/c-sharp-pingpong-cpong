﻿using System;
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
        DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            ball = new Ball(canvas);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,25);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);

        }

        public void dispatcherTimer_tick(object sender, EventArgs e)
        {
            ball.movement();

            if(ball.x <= 0 || ball.x >= ActualWidth - 15)
            {
                ball.bounceX();
            }

            if(ball.y <= 0 || ball.y >= ActualHeight -15)
            {
                ball.boudnceY();
            }
        }


        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (dispatcherTimer.IsEnabled)
            {
                if (e.Key == Key.Space)
                {
                    dispatcherTimer.IsEnabled = false;
                    paused.Visibility = Visibility.Visible;
                }
            }
            else
                {
                    dispatcherTimer.IsEnabled = true;
                    paused.Visibility = Visibility.Hidden;
                }
            if(e.Key == Key.Escape)
            {
                Close();
            }
            }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.IsEnabled = false;
            paused.Visibility = Visibility.Hidden;
        }
    }
}
