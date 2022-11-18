using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Fitness
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler)HandlerKeyDownEvent);
        }
        private void HandlerKeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    break;
                case Key.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }//Клавиатура
        private void sit_up(object sender, RoutedEventArgs e)
        {
            SitUp sitUp = new();
            sitUp.Show();
            this.Close();
        }
        private void push_up(object sender, RoutedEventArgs e)
        {
            PushUp pushUp = new();
            pushUp.Show();
            this.Close();
        }
        private void pull_up(object sender, RoutedEventArgs e)
        {
            PullUp pullUp = new();
            pullUp.Show();
            this.Close();
        }
    }
}
