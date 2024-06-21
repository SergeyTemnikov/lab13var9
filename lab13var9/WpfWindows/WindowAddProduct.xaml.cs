using lab13var9.MyDatabase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для WindowAddProduct.xaml
    /// </summary>
    public partial class WindowAddProduct : Window
    {

        ProductsEntities db;
        byte[] image;
        ImageSourceConverter converter = new ImageSourceConverter();
        List<Structures> structures = new List<Structures>();

        public WindowAddProduct(ProductsEntities db)
        {
            InitializeComponent();
            this.db = db;

            cmbStructure.ItemsSource = db.Structures.ToList();
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
                string.IsNullOrEmpty(txbArticul.Text)||
                string.IsNullOrEmpty(txbPrice.Text)||
                structures.Count == 0 ||
                string.IsNullOrEmpty(txbBarcode.Text) ||
                string.IsNullOrEmpty(txbVolume.Text) ||
                string.IsNullOrEmpty(txbWeigth.Text) ||
                image == null) 
            {
                MessageBox.Show("Не все поля заполнены!");
            }


            Products product = new Products();
            product.Product_Name = txbName.Text;
            product.Articul = txbArticul.Text;
            product.Barcode = txbBarcode.Text;
            product.Photo = image;
            try
            {
                product.Volume = int.Parse(txbVolume.Text);
            } catch
            {
                MessageBox.Show("Поле объема заполнено не правильно!");
            }

            try
            {

                product.Price = decimal.Parse(txbPrice.Text);
            }
            catch
            {
                MessageBox.Show("Поле количества заполнено не правильно!");
            }

            try
            {

                product.Weight = int.Parse(txbWeigth.Text);
            }
            catch
            {
                MessageBox.Show("Поле количества заполнено не правильно!");
            }
            try
            {
                db.Products.Add(product);
                foreach(var s in structures)
                {
                    db.ProductsStrucutres.Add(new ProductsStrucutres()
                    {
                        Id_Products = product.Id_Product,
                        Id_Structure = s.Id_Structure
                    });
                }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
            };
            if (openFile.ShowDialog() == true)
            {
                image = File.ReadAllBytes(openFile.FileName);
                imgPhoto.Source = converter.ConvertFrom(openFile.FileName) as ImageSource;
            }
        }

        private void btnAddStructure_Click(object sender, RoutedEventArgs e)
        {
            if(cmbStructure.SelectedItem == null) 
            {
                MessageBox.Show("Выберите ингредиент для добавления!");
                return;
            }
            structures.Add(cmbStructure.SelectedValue as Structures);
            listStructures.ItemsSource = null;
            listStructures.ItemsSource = structures;
        }
    }
}
