using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iwona_Maraskiewicz_BBS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int numberP = Int32.Parse(TextP.Text);
            int numberQ = Int32.Parse(TextQ.Text);
            int numberZiarno = Int32.Parse(TextZiarno.Text);
            int numberDlugosc = Int32.Parse(Dlugosc.Text);
            BBS bbs = new BBS(numberP, numberQ, numberZiarno);
            bbs.wygenerujLosowyBit();
            bbs.wygenerujLosowyBajt();
            Wynik.Text = bbs.wygenerujLosowyCiag(numberDlugosc);

            //przykład : p = 19, q = 23, ziarno = 8, dlugosc = 32
        }
    }
}
