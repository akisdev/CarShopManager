using CarShopManager.Repository;
using CarShopManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContext databaseContext = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListCars();   
        }
        private void delete_car(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                List<Car> cars = databaseContext.Cars.ToList();
                string row = CarsGrid.SelectedCells.FirstOrDefault().Item.ToString();
                Car selectedCar = cars.FirstOrDefault(c => c.Id == GetSelectedId(row));
                List<Contract> contracts = databaseContext.Contracts.Where(t => t.CarId == selectedCar.Id).ToList();
                foreach (Contract contract in contracts)
                {
                    databaseContext.Contracts.Remove(contract);
                }
                databaseContext.Cars.Remove(selectedCar);
                databaseContext.SaveChanges();
                ListCars();

            }

        }
        private void refresh(object sender, EventArgs e)
        {
            ListCars();
        }
        private void update_car(object sender, EventArgs e)
        {
            string row = CarsGrid.SelectedCells.FirstOrDefault().Item.ToString();

            UpdateCar updateCar = new UpdateCar(GetSelectedId(row));
            updateCar.Show();
        }
        public void ListCars()
        {
            CarsGrid.ItemsSource = "";
            var query =
            from Car in databaseContext.Cars
            select new { Car.Id, Car.CarMake, Car.CarModel, Car.CarPrice, Car.CarYear };

            CarsGrid.ItemsSource = query.ToList();

            CarsGrid.Columns[0].Header = "ID";
            CarsGrid.Columns[1].Header = "Make";
            CarsGrid.Columns[2].Header = "Model";
            CarsGrid.Columns[3].Header = "Price";
            CarsGrid.Columns[4].Header = "Year";
        }
        private int GetSelectedId(string row)
        {
            string s = Regex.Match(row, "Id = (.*), CarMake =").Groups[1].Value;
            int idSelected = -1;
            Int32.TryParse(s, out idSelected);
            return idSelected;
        }

        private void insert_car(object sender, RoutedEventArgs e)
        {
            InsertCar insertCar = new InsertCar();
            insertCar.Show();
        }

        private void switch_to_clients(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Close();
        }
    }
}
