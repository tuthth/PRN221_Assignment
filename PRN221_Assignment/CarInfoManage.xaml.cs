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
    /// Interaction logic for CarInfoManage.xaml
    /// </summary>
    public partial class CarInfoManage : Window
    {
        public CarInformationRepo CarInformationRepo;
        public RentingDetailRepo RentingDetailRepo;
        public CarInfoManage()
        {
            InitializeComponent();
            CarInformationRepo = new CarInformationRepo();
            RentingDetailRepo = new RentingDetailRepo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvCarInfors.ItemsSource = CarInformationRepo.GetCarListInformation();
            HiddenField();
            cboIDs.ItemsSource = CarInformationRepo.GetCarListInformation().Select(c => c.CarId);
        }
        private void HiddenField()
        {
            foreach(DataGridColumn dataGridColumn in  dgvCarInfors.Columns)
            {
                if (dataGridColumn.Header.ToString() == "Manufacturer" || dataGridColumn.Header.ToString() == "RentingDetails" || dataGridColumn.Header.ToString() == "Supplier")
                {
                    dataGridColumn.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void cboIDs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboIDs.SelectedItem == null)
            {
                ClearTextBoxes();
                return;
            }

            int selectedId;
            if (Int32.TryParse(cboIDs.SelectedItem.ToString(), out selectedId))
            {
                CarInformation car = CarInformationRepo.GetCarId(selectedId);
                if (car != null)
                {
                    txtDescription.Text = car.CarDescription;
                    txtFuelType.Text = car.FuelType.ToString();
                    txtManufacturerID.Text = car.ManufacturerId.ToString();
                    txtName.Text = car.CarName;
                    txtNoOfDoors.Text = car.NumberOfDoors.ToString();
                    txtRentPerDay.Text = car.CarRentingPricePerDay.ToString();
                    txtSeatCapacity.Text = car.SeatingCapacity.ToString();
                    txtStatus.Text = car.CarStatus.ToString();
                    txtSupplierID.Text = car.SupplierId.ToString();
                    txtYear.Text = car.Year.ToString();
                }
                else
                {
                    ClearTextBoxes();
                }
            }
            else
            {
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            txtDescription.Clear();
            txtFuelType.Clear();
            txtManufacturerID.Clear();
            txtName.Clear();
            txtNoOfDoors.Clear();
            txtRentPerDay.Clear();
            txtSeatCapacity.Clear();
            txtStatus.Clear();
            txtSupplierID.Clear();
            txtYear.Clear();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(cboIDs.SelectedItem == null)
            {
                MessageBox.Show("No ID has been selected");
                return;
            }
            int selectedId = Int32.Parse(cboIDs.SelectedItem.ToString());
            CarInformation carInformation = CarInformationRepo.GetCarId(selectedId);
            if (carInformation != null)
            {
                carInformation.SeatingCapacity = Int32.Parse(txtSeatCapacity.Text);
                carInformation.SupplierId = Int32.Parse(txtSupplierID.Text);
                carInformation.ManufacturerId = Int32.Parse((string)txtManufacturerID.Text);
                carInformation.CarRentingPricePerDay = Decimal.Parse(txtRentPerDay.Text);
                carInformation.CarStatus = Byte.Parse(txtStatus.Text);
                carInformation.Year = Int32.Parse(txtYear.Text);
                carInformation.CarDescription = txtDescription.Text;
                carInformation.FuelType = txtFuelType.Text;
                carInformation.CarName = txtName.Text;
                carInformation.NumberOfDoors = Int32.Parse(txtNoOfDoors.Text);

                CarInformationRepo.Update(carInformation);
                MessageBox.Show("Update success", "Confirmation", MessageBoxButton.OK);
                Window_Loaded(sender, e);
            }
            else
            {
                MessageBox.Show("This car is not existed in database");
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cboIDs.SelectedItem == null)
            {
                MessageBox.Show("No ID has been selected");
                return;
            }

            int selectedId = Int32.Parse(cboIDs.SelectedItem.ToString());
            CarInformation carInformation = CarInformationRepo.GetCarId(selectedId);

            if (carInformation != null)
            {
                if (RentingDetailRepo.CarIdExist(selectedId) == true)
                {
                    carInformation.CarStatus = 1;
                    MessageBoxResult confirmationResult = MessageBox.Show("Are you sure you want to disable this car for renting?", "Confirmation", MessageBoxButton.YesNo);

                    if (confirmationResult == MessageBoxResult.Yes)
                    {
                        CarInformationRepo.Update(carInformation);
                        MessageBox.Show("This car has been disabled for renting", "Confirmation", MessageBoxButton.OK);
                        Window_Loaded(sender, e);
                    }
                }
                else
                {
                    MessageBoxResult confirmationResult = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation", MessageBoxButton.YesNo);

                    if (confirmationResult == MessageBoxResult.Yes)
                    {
                        CarInformationRepo.Delete(carInformation);
                        MessageBox.Show("Delete success", "Confirmation", MessageBoxButton.OK);
                        cboIDs.SelectedItem = null;
                        Window_Loaded(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error when choosing car", "Confirmation", MessageBoxButton.OK);
                Window_Loaded(sender, e);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CarInfoCreate carInfoCreate = new CarInfoCreate();
            carInfoCreate.Show();
        }

        private void dgvCarInfors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
