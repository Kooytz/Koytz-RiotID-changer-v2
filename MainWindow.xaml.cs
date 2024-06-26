using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Koytz_RiotID_changer_v2 {
    public partial class MainWindow : Window {

        private DispatcherTimer focusTimer;
        private bool isGameNameFocused;
        //private bool isTagLineFocused; tagline

        public MainWindow() {
            InitializeComponent();
            FocusTimer();
        }

        private void FocusTimer() {
            focusTimer = new DispatcherTimer();
            focusTimer.Interval = TimeSpan.FromMilliseconds(50);
            focusTimer.Tick += FocusThread;
            focusTimer.Start();
        }

        private void FocusThread(object sender, EventArgs e) {
            isGameNameFocused = NewGameName.IsKeyboardFocused;
            ControlTemplate textBoxTemplate = NewGameName.Template;

            if (textBoxTemplate == null) return;

            Border border = textBoxTemplate.FindName("Border", NewGameName) as Border;
            TextBlock placeholderTextBlock = textBoxTemplate.FindName("Placeholder", NewGameName) as TextBlock;

            if (border != null) {
                if (placeholderTextBlock.Visibility == Visibility.Collapsed) {
                    NewGameName.Foreground = new SolidColorBrush(Colors.White);
                }

                if (isGameNameFocused) {
                    border.Background = new SolidColorBrush(Colors.Transparent);

                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Collapsed;
                    }

                    if (NewGameName.Text.Length >= 3) {
                        border.BorderBrush = new SolidColorBrush(Colors.White);
                    } else {
                        border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d953e5"));
                    }
                } else {
                    if (NewGameName.Text.Length <= 2) {
                        border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#382738"));
                        border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#472748"));
                    } else {
                        border.BorderBrush = new SolidColorBrush(Colors.Transparent);
                        border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#383636"));
                    }
                    
                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Visible;
                    }
                }
            }



            //TagLine Focus here;
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










        private void SaveChangesButton_Click(object sender, RoutedEventArgs e) {
        }

        private void NewTagLine_TextChanged(object sender, TextChangedEventArgs e) {
        }
    }
}
