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
                if (isGameNameFocused) {
                    Console.WriteLine("está focado!");
                    border.Background = new SolidColorBrush(Colors.Transparent);

                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Collapsed;
                    }

                } else {
                    if (NewGameName.Text.Length < 3) {
                        border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#382738"));
                    } 
                    
                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Visible;
                    }
                }
            }

            // AO TERMINAR, VOLTAR AS CORREÇÕES DA BORDA -- LEMBRAR DE PEGAR DO MÉTODO LÁ NO BLOCO DE NOTAS CHAMADO NewGameName_TextChanged



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
