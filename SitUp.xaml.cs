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
                    First_approach = firstP.Text,
                    Second_approach = secondP.Text,
                    Third_approach = thirdP.Text,
                    Fourth_approach = fourP.Text,
                    Fiveth_approach = fiveP.Text,
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
    }
}
