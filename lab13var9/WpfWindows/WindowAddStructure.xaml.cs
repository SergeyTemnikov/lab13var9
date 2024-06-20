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
using System.Xml.Linq;

namespace lab13var9.WpfWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddStructure.xaml
    /// </summary>
    public partial class WindowAddStructure : Window
    {

        ProductsEntities db;

        public WindowAddStructure(ProductsEntities db)
        {
            InitializeComponent();
            this.db = db;

            cmbProduct.ItemsSource = db.Products.ToList();
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txbName.Text)||
                string.IsNullOrEmpty(txbAmount.Text)||
                string.IsNullOrEmpty(txbPrice.Text)||
                string.IsNullOrEmpty(cmbProduct.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }


            Structures structure = new Structures();
            structure.Structure_Name = txbName.Text;
            try
            {
                structure.Amount = Convert.ToDecimal(txbAmount.Text);
            } catch
            {
                MessageBox.Show("Поле количества заполнено не правильно!");
            }

            try
            {

                structure.Price = decimal.Parse(txbPrice.Text);
            }
            catch
            {
                MessageBox.Show("Поле количества заполнено не правильно!");
            }
            structure.Products = cmbProduct.SelectedValue as Products;
            try
            {
                db.Structures.Add(structure);
                db.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось записать ингредиент");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
