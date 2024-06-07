using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using System.Diagnostics;

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
                NewGameName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
            }
        }

        private void NewGameName_TextChanged(object sender, TextChangedEventArgs e) {
            NewGameName.Foreground = new SolidColorBrush(Colors.White);

            ControlTemplate template = NewGameName.Template;

            if (template == null) return;

            Border border = template.FindName("Border", NewGameName) as Border;

            if (border != null) {
                if (NewGameName.Text.Length >= 3) {
                    border.BorderBrush = new SolidColorBrush(Colors.White);
                    border.Background = new SolidColorBrush(Colors.Transparent);
                } else {
                    border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#472748"));

                    // aqui vai entrar uma variável que vai servir pra ser utilizada quando clica fora, vai reutilizar o que está aí abaixo basicamente.
                    // última modificação foi aqui 07/06/2024.

                    //border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#382738"));
                }
            }
        }

















        private void SaveChangesButton_Click(object sender, RoutedEventArgs e) {
        }

        private void NewTagLine_TextChanged(object sender, TextChangedEventArgs e) {
        }
    }
}
