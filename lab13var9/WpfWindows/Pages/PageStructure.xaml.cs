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
    /// Логика взаимодействия для PageStructure.xaml
    /// </summary>
    public partial class PageStructure : Page
    {

        ProductsEntities db;

        public PageStructure(ProductsEntities db)
        {
            InitializeComponent();
            this.db=db;

            dgStructures.ItemsSource = db.Structures.ToList();
        }


        private void OpenStrucutre()
        {
            Structures structure;

            if (dgStructures.SelectedItem != null)
            {
                structure = dgStructures.SelectedValue as Structures;
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт!");
                return;
            }


            WindowOpenStructure window = new WindowOpenStructure(structure, db);
            window.ShowDialog();
        }

        private void btnOpenStructure_Click(object sender, RoutedEventArgs e)
        {
            OpenStrucutre();
        }

        private void dgStructure_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenStrucutre();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowAddStructure window = new WindowAddStructure(db);
            window.ShowDialog();
            dgStructures.ItemsSource = null;
            dgStructures.ItemsSource = db.Structures.ToList();
        }
    }
}
