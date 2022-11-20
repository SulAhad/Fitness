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
using System.Windows.Shapes;

namespace Fitness
{
    public partial class SitUp : Window
    {
        public SitUp()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            DataBaseSitUpsContext dataBaseSitUpsContext = new();
            SitUpOrder.ItemsSource = dataBaseSitUpsContext.DataBaseSitUps.ToList();

            double[] touch1X = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Id).ToArray();
            double[] touch1Y = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.First_approach).ToArray();
            touch1.Plot.AddScatter(touch1X, touch1Y);
            touch1.Refresh();

            double[] touch2X = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Id).ToArray();
            double[] touch2Y = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Second_approach).ToArray();
            touch2.Plot.AddScatter(touch2X, touch2Y);
            touch2.Refresh();

            double[] touch3X = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Id).ToArray();
            double[] touch3Y = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Third_approach).ToArray();
            touch3.Plot.AddScatter(touch3X, touch3Y);
            touch3.Refresh();

            double[] touch4X = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Id).ToArray();
            double[] touch4Y = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Fourth_approach).ToArray();
            touch4.Plot.AddScatter(touch4X, touch4Y);
            touch4.Refresh();

            double[] touch5X = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Id).ToArray();
            double[] touch5Y = dataBaseSitUpsContext.DataBaseSitUps.Select(x => (double)x.Fiveth_approach).ToArray();
            touch5.Plot.AddScatter(touch5X, touch5Y);
            touch5.Refresh();
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
            if (firstP.Text == string.Empty ||
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

                DataBaseSitUpsContext db = new();
                DataBaseSitUp tim = new DataBaseSitUp
                {
                    First_approach = Convert.ToDouble(firstP.Text),
                    Second_approach = Convert.ToDouble(secondP.Text),
                    Third_approach = Convert.ToDouble(thirdP.Text),
                    Fourth_approach = Convert.ToDouble(fourP.Text),
                    Fiveth_approach = Convert.ToDouble(fiveP.Text),
                    Date = DateTime.Now.ToString()
                };

                db.DataBaseSitUps.Add(tim);
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
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DataBaseSitUpsContext db = new();
            if (TextArea.Text == "")
            {
                DownTrayBuyerOrders.Content = "Не ввели номер!";
                DownTrayBuyerOrders.Background = Brushes.LightCoral;
            }
            else
            {
                TextArea.Text = TextArea.Text.Trim();
                int key = Convert.ToInt32(TextArea.Text.Trim());
                var item = db.DataBaseSitUps.Find(key);
                if (item != null)
                {

                    db.DataBaseSitUps.Remove(item);
                    db.SaveChanges();
                    Update();
                    DownTrayBuyerOrders.Background = Brushes.LightGreen;
                    DownTrayBuyerOrders.Content = "Удалена запись --" + TextArea.Text;
                    TextArea.Text = "";
                }
                else
                {
                    MessageBox.Show("Введена некорректная цифра!");
                }
            }
        }
        private void PreviewIdInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
