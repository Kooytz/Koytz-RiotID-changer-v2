using System;
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

namespace Koytz_RiotID_changer_v2 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void RemoveText(object sender, RoutedEventArgs e) {
            if (NewGameName.Text == "GAME NAME") {
                NewGameName.Text = "";
                NewGameName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
            }
        }

        private void AddText(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NewGameName.Text)) {
                NewGameName.Text = "GAME NAME";
                NewGameName.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

















        private void SaveChangesButton_Click(object sender, RoutedEventArgs e) {
        }

        private void NewGameName_TextChanged(object sender, TextChangedEventArgs e) {
        }

        private void NewTagLine_TextChanged(object sender, TextChangedEventArgs e) {
        }
    }
}
