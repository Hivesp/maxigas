﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.WPF;

namespace xamlgame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FontAwesomeIcon elozoKartya;
        private int Score;

        public MainWindow()
        {
            InitializeComponent();
            buttonStart.IsEnabled = true;
            buttonYes.IsEnabled = false;
            buttonNo.IsEnabled = false;
            Score = 0;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer();
            Debug.WriteLine("buttonYes");

        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            NoAswer();
            Debug.WriteLine("buttonNo");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("buttonStart");
            Start();
        }

        private void YesAnswer()
        {
            if (elozoKartya == CardRight.Icon)
            {
                JoValasz();

            }
            else
            {
                RosszValasz();
            }
            UjKartyaHuzasa();
        }
        private void NoAswer()
        {
            if (elozoKartya != CardRight.Icon)
            {
                JoValasz();
            }
            else
            {
                RosszValasz();
            }
            UjKartyaHuzasa();
        }



        private void Start()
        {
            UjKartyaHuzasa();
            buttonStart.IsEnabled = false;
            buttonYes.IsEnabled = true;
            buttonNo.IsEnabled = true;
        }

        private void UjKartyaHuzasa()
        {
            var kartypakli = new FontAwesomeIcon[6];
            kartypakli[0] = FontAwesomeIcon.Fax;
            kartypakli[1] = FontAwesomeIcon.Female;
            kartypakli[2] = FontAwesomeIcon.Download;
            kartypakli[3] = FontAwesomeIcon.Edge;
            kartypakli[4] = FontAwesomeIcon.Hashtag;
            kartypakli[5] = FontAwesomeIcon.Mars;
            var AnimationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            var AnimationIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            var dobokocka = new Random();
            var dobas = dobokocka.Next(0, 5);
            CardRight.BeginAnimation(OpacityProperty, AnimationOut);
            elozoKartya = CardRight.Icon;
            //kártya eltűntetése
            CardRight.BeginAnimation(OpacityProperty, AnimationOut);
            //új kártya húzása
            CardRight.Icon = kartypakli[dobas];
            //kártya megjelenítése
            CardRight.BeginAnimation(OpacityProperty, AnimationIn);
        }

        private void JoValasz()
        {

            CardLeft.Icon = FontAwesomeIcon.Check;
            CardLeft.Foreground = Brushes.Green;
            Debug.WriteLine("helyes");

            Scoring(true);

            VisszajelesEltuntetese();
        }

        private void RosszValasz()
        {
            CardLeft.Icon = FontAwesomeIcon.Close;
            CardLeft.Foreground = Brushes.Red;
            Debug.WriteLine("helytelen");
            VisszajelesEltuntetese();
        }

        private void Scoring(bool isGoodAnswer)
        {
            if (isGoodAnswer==true)
            {
                Score += 100;
            }
            else
            {
                Score -= 100;
            }
            LabelScore.Content = Score;


        }

        private void VisszajelesEltuntetese()
        {
            //eltűnés animálása
            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            CardLeft.BeginAnimation(OpacityProperty, animation);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Up)
            {
                Start();
            }
            if (e.Key == Key.Right)
            {
                NoAswer();
            }
            if (e.Key == Key.Left)
            {
                YesAnswer();
            }
        }
    }
}
