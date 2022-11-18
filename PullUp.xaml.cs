using System.Linq;
using System.Windows;
using System;
using System.Windows.Media;

namespace Fitness
{
    public partial class PullUp : Window
    {
        public PullUp()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            DataBasePullUpsContext dataBasePullUpsContext = new();
            PullUpOrder.ItemsSource = dataBasePullUpsContext.DataBasePullUps.ToList();
            /*double[] xs = orderForBuyersContext.OrderForBuyers.Select(x => (double)x.Id).ToArray();
            double[] ys = orderForBuyersContext.OrderForBuyers.Select(x => (double)x.OrderPrice).ToArray();
            WpfPlot.Plot.AddScatter(xs, ys);
            WpfPlot.Refresh();*/
        }
        public void ClearText()
        {
            firstP.Text = string.Empty;
            secondP.Text = string.Empty;
            thirdP.Text = string.Empty;
            fourP.Text = string.Empty;
            fiveP.Text = string.Empty;
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if(firstP.Text == string.Empty ||
            secondP.Text == string.Empty ||
            thirdP.Text == string.Empty ||
            fourP.Text == string.Empty ||
            fiveP.Text == string.Empty) 
            {
                DownTrayBuyerOrders.Content = "Не ввели данные!";
                DownTrayBuyerOrders.Background = Brushes.LightCoral;
            }
            else
            {
                firstP.Text = firstP.Text.Trim(' ');
                secondP.Text = secondP.Text.Trim(' ');
                thirdP.Text = thirdP.Text.Trim(' ');
                fourP.Text = fourP.Text.Trim(' ');
                fiveP.Text = fiveP.Text.Trim(' ');

                DataBasePullUpsContext db = new();
                DataBasePullUp tim = new DataBasePullUp
                {
                    First_approach = firstP.Text,
                    Second_approach = secondP.Text,
                    Third_approach = thirdP.Text,
                    Fourth_approach = fourP.Text,
                    Fiveth_approach = fiveP.Text,
                    Date = DateTime.Now.ToString()
                };

                db.DataBasePullUps.Add(tim);
                db.SaveChanges();
                Update();
                ClearText();
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }
    }
}
