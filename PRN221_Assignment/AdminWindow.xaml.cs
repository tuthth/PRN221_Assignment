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

namespace PRN221_Assignment1_WPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Show();
        }

        private void btnCarInfo_Click(object sender, RoutedEventArgs e)
        {
            CarInfoManage carInfoManage = new CarInfoManage();
            carInfoManage.Show();
        }

        private void btnRenting_Click(object sender, RoutedEventArgs e)
        {
            RentingManage rentingManage = new RentingManage();
            rentingManage.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
