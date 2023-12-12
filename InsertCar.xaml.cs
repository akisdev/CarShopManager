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
    /// Interaction logic for InsertCar.xaml
    /// </summary>
    public partial class InsertCar : Window
    {
        DatabaseContext databaseContext = new();
        public InsertCar()
        {
            InitializeComponent();
        }

        private void insert_car_apply(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to inset this item?", "Insert", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                Car car = new Car {CarMake = Make.Text, CarPrice = ConvertToInt(Price.Text), CarModel = Model.Text, CarYear = Year.Text };
                databaseContext.Cars.Add(car);
                databaseContext.SaveChanges();
                MessageBox.Show("Insert successful!", "Insert", MessageBoxButton.OKCancel);
                this.Close();
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ID.Text = String.Empty;
            Make.Text = String.Empty;
            Model.Text = String.Empty;
            Year.Text = String.Empty;
            Price.Text = String.Empty;
        }
        private int ConvertToInt(string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
