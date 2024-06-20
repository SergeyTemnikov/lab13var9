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
using lab13var9.WpfWindows.Pages;

namespace lab13var9.WpfWindows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductsEntities db = new ProductsEntities();

        MainPage mainPage;
        PageProducts pageProducts;
        PageStructure pageStructure;

        public MainWindow()
        {
            InitializeComponent();


            mainPage = new MainPage();
            pageProducts = new PageProducts(db);
            pageStructure = new PageStructure(db);

            MainFrame.Navigate(mainPage);
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
            Application.Current.Shutdown();
        }

        private void goProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(pageProducts);
        }

        private void goStructure_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(pageStructure);
        }
    }
}
