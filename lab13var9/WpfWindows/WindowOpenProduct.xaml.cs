using lab13var9.MyDatabase;
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

namespace lab13var9.WpfWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowOpenProduct.xaml
    /// </summary>
    public partial class WindowOpenProduct : Window
    {

        ProductsEntities db;
        Products product;

        public WindowOpenProduct(Products product, ProductsEntities db)
        {
            InitializeComponent();
            this.product=product;
            this.db = db;

            txtProduct.Text += product.Product_Name;

            dgStructures.ItemsSource = db.Structures.Where(x => x.Id_Product == product.Id_Product).ToList();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void appExit(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
