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
        private bool isTagLineFocused;

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
                if (placeholderTextBlock.Visibility == Visibility.Hidden) {
                    NewGameName.Foreground = new SolidColorBrush(Colors.White);
                }

                if (isGameNameFocused) {
                    border.Background = new SolidColorBrush(Colors.Transparent);
                    NewGameNameTitle.Visibility = Visibility.Visible;
                    NewGameNameTitleNumberLength.Visibility = Visibility.Visible;
                    NewGameNameTitle.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b8b8b8"));

                    int maxLength = 16;
                    int remainingChars = maxLength - NewGameName.Text.Length;

                    NewGameNameTitleNumberLength.Text = remainingChars.ToString();

                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Hidden;
                    }

                    if (NewGameName.Text.Length >= 3) {
                        border.BorderBrush = new SolidColorBrush(Colors.White);
                        NewGameNameTitleNumberLength.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b8b8b8"));
                    } else {
                        border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d953e5"));
                        NewGameNameTitleNumberLength.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
                    }
                } else {
                    NewGameNameTitleNumberLength.Visibility = Visibility.Hidden;

                    if (NewGameName.Text.Length == 0) {
                        NewGameNameTitle.Visibility = Visibility.Hidden;
                    }

                    if (NewGameName.Text.Length < 3) {
                        NewGameNameTitle.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
                    }

                    if (NewGameName.Text.Length <= 2) {
                        border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#382738"));
                        border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#472748"));
                    } else {
                        border.BorderBrush = new SolidColorBrush(Colors.Transparent);
                        border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333131"));
                    }
                    
                    if (NewGameName.Text.Length == 0) {
                        placeholderTextBlock.Visibility = Visibility.Visible;
                    }
                }
            }

            isTagLineFocused = NewTagLine.IsKeyboardFocused;
            ControlTemplate NewTagLine_textBoxTemplate = NewTagLine.Template;

            if (NewTagLine_textBoxTemplate == null) return;

            Border NewTagLine_border = NewTagLine_textBoxTemplate.FindName("Border", NewTagLine) as Border;
            TextBlock NewTagLine_placeholderTextBlock = NewTagLine_textBoxTemplate.FindName("Placeholder", NewTagLine) as TextBlock;

            if (NewTagLine_border != null) {
                if (NewTagLine_placeholderTextBlock.Visibility == Visibility.Hidden) {
                    NewTagLine.Foreground = new SolidColorBrush(Colors.White);
                }

                if (isTagLineFocused) {
                    NewTagLine_border.Background = new SolidColorBrush(Colors.Transparent);
                    NewTaglineTitle.Visibility = Visibility.Visible;
                    NewTaglineNumberLength.Visibility = Visibility.Visible;
                    NewTaglineTitle.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b8b8b8"));
                    GenerateRandomTaglineButton.Visibility = Visibility.Visible;

                    int maxLength = 5;
                    int remainingChars = maxLength - NewTagLine.Text.Length;

                    NewTaglineNumberLength.Text = remainingChars.ToString();

                    if (NewTagLine.Text.Length == 0) {
                        NewTagLine_placeholderTextBlock.Visibility = Visibility.Hidden;
                    }

                    if (NewTagLine.Text.Length >= 3) {
                        NewTagLine_border.BorderBrush = new SolidColorBrush(Colors.White);
                        NewTaglineNumberLength.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b8b8b8"));
                    } else {
                        NewTagLine_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d953e5"));
                        NewTaglineNumberLength.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
                    }
                } else {
                    NewTaglineNumberLength.Visibility = Visibility.Hidden;
                    GenerateRandomTaglineButton.Visibility = Visibility.Hidden;

                    if (NewTagLine.Text.Length == 0) {
                        NewTaglineTitle.Visibility = Visibility.Hidden;
                    }

                    if (NewTagLine.Text.Length < 3) {
                        NewTaglineTitle.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e74ff5"));
                    }

                    if (NewTagLine.Text.Length <= 2) {
                        NewTagLine_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#382738"));
                        NewTagLine_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#472748"));
                    } else {
                        NewTagLine_border.BorderBrush = new SolidColorBrush(Colors.Transparent);
                        NewTagLine_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333131"));
                    }

                    if (NewTagLine.Text.Length == 0) {
                        NewTagLine_placeholderTextBlock.Visibility = Visibility.Visible;
                    }
                }
            }

            if (isTagLineFocused || NewTagLine.Text.Length > 0) {
                HashtagNewTagline.Visibility = Visibility.Visible;
            } else {
                HashtagNewTagline.Visibility = Visibility.Hidden;
            }

            if (GenerateRandomTaglineButton.Visibility == Visibility.Visible) {
                //GenerateRandomTaglineButton.Click -= GenerateRandomTagline;
                //GenerateRandomTaglineButton.Click += GenerateRandomTagline;
            }
        }

        /*private void GenerateRandomTagline(object sender, RoutedEventArgs e) {
            Console.WriteLine("Clicado");

            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);
            NewTagLine.Text = randomNumber.ToString();
            NewTagLine.Focus();
        }*/

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
    }
}
