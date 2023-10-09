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
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        public CarInformationRepo CarInformationRepo;
        public RentingDetailRepo RentingDetailRepo;
        public RentingTransactionRepo RentingTransactionRepo;
        public CustomerRepo CustomerRepo;
        public List<RentingDetail> rentingDetails; 
        public AddTransaction()
        {
            InitializeComponent();
            CarInformationRepo = new CarInformationRepo();
            RentingTransactionRepo = new RentingTransactionRepo();
            RentingDetailRepo = new RentingDetailRepo();
            CustomerRepo = new CustomerRepo();
            rentingDetails = new List<RentingDetail>();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboCar.ItemsSource = CarInformationRepo.GetCarListInformation().Select(c => c.CarId);
            cboCustomerId.ItemsSource = CustomerRepo.GetAll().Select(c => c.CustomerId);
        }


        private void btnAddDetail_Click(object sender, RoutedEventArgs e)
        {

            if (cboCar.SelectedItem == null || dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null || string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime startDate = dpStartDate.SelectedDate.Value;
            DateTime endDate = dpEndDate.SelectedDate.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be less than or equal to end date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            RentingDetail detail = new RentingDetail
            {
                RentingTransactionId = RentingTransactionRepo.GetAll().Count(),
                CarId = Int32.Parse(cboCar.SelectedItem.ToString()),
                StartDate = startDate,
                EndDate = endDate,
                Price = decimal.Parse(txtPrice.Text)
            };

            rentingDetails.Add(detail);


            cboCar.SelectedItem = null;
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;

            MessageBox.Show("Add new renting car to transaction success");
        }

        private void btnSaveTransaction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rentingDetails.Count == 0)
                {
                    MessageBox.Show("Please add at least one renting detail before saving the transaction.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                decimal? totalPrice = 0;
                foreach (var detail in rentingDetails)
                {
                    int numberOfDays = (int)(detail.EndDate - detail.StartDate).TotalDays;
                    totalPrice += detail.Price * numberOfDays;
                }

                RentingTransaction transaction = new RentingTransaction
                {
                    RentingTransationId = RentingTransactionRepo.GetAll().Count(),
                    RentingDate = DateTime.Now.Date,
                    CustomerId = Int32.Parse(cboCustomerId.SelectedItem.ToString()),
                    TotalPrice = totalPrice,
                    RentingDetails = rentingDetails,
                    RentingStatus = 0
                };

                MessageBoxResult confirmationResult = MessageBox.Show("Are you sure you want to save this transaction?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirmationResult == MessageBoxResult.Yes)
                {
                    RentingTransactionRepo.Add(transaction);
                    foreach (var a in rentingDetails)
                    {
                        RentingDetailRepo.Add(a);
                    }
                    Window_Loaded(sender, e);
                    MessageBox.Show("Transaction saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                Window_Loaded(sender, e);
            }
            
        }

        
        private void cboCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCar.SelectedItem != null)
            {
                int selectedId;
                if (Int32.TryParse(cboCar.SelectedItem.ToString(), out selectedId))
                {
                    CarInformation selectedCar = CarInformationRepo.GetCarId(selectedId);
                    if (selectedCar != null)
                    {
                        txtPrice.Text = selectedCar.CarRentingPricePerDay.ToString();
                    }
                    else
                    {
                        txtPrice.Clear();
                    }
                }
                else
                {
                    txtPrice.Clear();
                }
            }
            else
            {
                txtPrice.Clear();
            }
        }

        private void cboCustomerId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
