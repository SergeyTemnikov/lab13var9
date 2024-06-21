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
    public partial class WindowOpenStructure : Window
    {

        ProductsEntities db;
        Structures structure;

        public WindowOpenStructure(Structures structure, ProductsEntities db)
        {
            InitializeComponent();
            this.structure=structure;
            this.db = db;

            txtStructure.Text += structure.Structure_Name;

            var products = db.ProductsStrucutres.Where(x => x.Id_Structure == structure.Id_Structure).Select(x => x.Id_Products).ToList();

            dgProducts.ItemsSource = db.Products.Where(x => products.Contains(x.Id_Product)).ToList();
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
