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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace xamlgame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonStart.IsEnabled = true;
            buttonYes.IsEnabled = false;
            buttonNo.IsEnabled = false;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            UjKartyaHuzasa();
            Debug.WriteLine("buttonYes");
        }


        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            UjKartyaHuzasa();
            Debug.WriteLine("buttonNo");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            UjKartyaHuzasa();
            Debug.WriteLine("buttonStart");
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
            CardRight.Icon = kartypakli[dobas];
        }


    }
}
