using System;
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

        public MainWindow()
        {
            InitializeComponent();
            buttonStart.IsEnabled = true;
            buttonYes.IsEnabled = false;
            buttonNo.IsEnabled = false;
            
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
            var kartypakli = new FontAwesome.WPF.FontAwesomeIcon[6];
            kartypakli[0] = FontAwesome.WPF.FontAwesomeIcon.Fax;
            kartypakli[1] = FontAwesome.WPF.FontAwesomeIcon.Female;
            kartypakli[2] = FontAwesome.WPF.FontAwesomeIcon.Download;
            kartypakli[3] = FontAwesome.WPF.FontAwesomeIcon.Edge;
            kartypakli[4] = FontAwesome.WPF.FontAwesomeIcon.Hashtag;
            kartypakli[5] = FontAwesome.WPF.FontAwesomeIcon.Mars;
            var dobokocka = new Random();
            var dobas = dobokocka.Next(0, 5);
            elozoKartya = CardRight.Icon;
            CardRight.Icon = kartypakli[dobas];
        }

        private void JoValasz()
        {
            CardLeft.Icon = FontAwesomeIcon.Check;
            CardLeft.Foreground = Brushes.Green;
            Debug.WriteLine("helyes");
            VisszajelesEltuntetese();
        }
        private void RosszValasz()
        {
            CardLeft.Icon = FontAwesomeIcon.Close;
            CardLeft.Foreground = Brushes.Red;
            Debug.WriteLine("helytelen");
            VisszajelesEltuntetese();
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
