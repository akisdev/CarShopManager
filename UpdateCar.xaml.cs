using CarShopManager.Repository;
using CarShopManager.Repository.Models;
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

namespace CarShopManager
{
    /// <summary>
    /// Interaction logic for UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar : Window
    {
        int carID;
        DatabaseContext databaseContext = new();

        public UpdateCar(int id)
        {
            carID = id;
            InitializeComponent();
        }
        private void update_car_apply(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the selected item?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                ID.Text = carID.ToString();
                List<Car> cars = databaseContext.Cars.ToList();
                Car selectedCar = cars.FirstOrDefault(c => c.Id == carID);
                databaseContext.Remove(selectedCar);
                Car car = new Car{ Id = carID, CarMake = Make.Text, CarPrice = ConvertToInt(Price.Text), CarModel = Model.Text, CarYear = Year.Text };
                databaseContext.Cars.Add(car);
                databaseContext.SaveChanges();
                MessageBox.Show("Update successful!", "Update", MessageBoxButton.OKCancel);
                this.Close();
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ID.Text = carID.ToString();
            List<Car> cars = databaseContext.Cars.ToList();
            Car selectedCar = cars.FirstOrDefault(c => c.Id == carID);
            Make.Text = selectedCar.CarMake.ToString();
            Model.Text = selectedCar.CarModel.ToString();
            Year.Text = selectedCar.CarYear.ToString();
            Price.Text = selectedCar.CarPrice.ToString();
        }
        private int ConvertToInt(string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
