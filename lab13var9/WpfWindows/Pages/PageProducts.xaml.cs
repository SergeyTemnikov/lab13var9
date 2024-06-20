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
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab13var9.MyDatabase;

namespace lab13var9.WpfWindows.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {

        ProductsEntities db;

        public PageProducts(ProductsEntities db)
        {
            InitializeComponent();
            this.db=db;

            dgProducts.ItemsSource = db.Products.ToList();
        }

        private void OpenProduct()
        {
            Products product;

            if(dgProducts.SelectedItem != null)
            {
                product = dgProducts.SelectedValue as Products;
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт!");
                return;
            }


            WindowOpenProduct window = new WindowOpenProduct(product, db);  
            window.ShowDialog();
        }

        private void btnOpenProduct_Click(object sender, RoutedEventArgs e)
        {
            OpenProduct();
        }

        private void dgProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenProduct();
        }
    }
}
