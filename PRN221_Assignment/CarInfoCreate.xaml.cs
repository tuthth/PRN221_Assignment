using CarRental.Models;
using DAL.Repo;
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
    /// Interaction logic for CarInfoCreate.xaml
    /// </summary>
    public partial class CarInfoCreate : Window
    {
        public CarInformationRepo CarInformationRepo;
        public CarInfoCreate()
        {
            InitializeComponent();
            CarInformationRepo = new CarInformationRepo();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarInformation car = new CarInformation
                {
                    CarName = txtCarName.Text,
                    CarDescription = txtCarDescription.Text,
                    CarRentingPricePerDay = Decimal.Parse(txtRentingPricePerDay.Text),
                    CarStatus = Byte.Parse(txtCarStatus.Text),
                    FuelType = txtFuelType.Text,
                    ManufacturerId = Int32.Parse(txtManufacturerId.Text),
                    Year = Int32.Parse(txtYear.Text),
                    SeatingCapacity = Int32.Parse(txtSeatingCapacity.Text),
                    SupplierId = Int32.Parse (txtSupplierId.Text),
                    NumberOfDoors = Int32.Parse(txtNumberOfDoors.Text)
                };
                CarInformationRepo.Add(car);
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
