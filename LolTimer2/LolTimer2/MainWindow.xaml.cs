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
using System.Windows.Threading;
using LolTimer2.Models;

namespace LolTimer2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FlashTimer TopTimer { get; set; }
        public FlashTimer JungleTimer { get; set; }
        public FlashTimer MidTimer { get; set; }
        public FlashTimer AdTimer { get; set; }
        public FlashTimer SupportTimer { get; set; }

        public MainWindow()
        {
            TopTimer = new FlashTimer("Top");
            JungleTimer = new FlashTimer("Jung");
            MidTimer = new FlashTimer("Mid");
            AdTimer = new FlashTimer("Ad");
            SupportTimer = new FlashTimer("Sup");
            
            this.DataContext = this;
            InitializeComponent();
        }

        private void TopTimer_Tick(object? sender, EventArgs e)
        {
        }

        private void TopClicked(object sender, RoutedEventArgs e)
        {
            TopTimer.StartTimer();
        }


        private void MidClicked(object sender, RoutedEventArgs e)
        {
            MidTimer.StartTimer();
        }

        private void SupportClicked(object sender, RoutedEventArgs e)
        {
            SupportTimer.StartTimer();
        }

        private void AdClicked(object sender, RoutedEventArgs e)
        {
            AdTimer.StartTimer();
        }

        private void JungleClicked(object sender, RoutedEventArgs e)
        {
            JungleTimer.StartTimer();
        }
    }
}