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

namespace AflyatunovUkrashinie
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {

        public ProductPage()
        {
            InitializeComponent();

            List<Product> currentProducts = AflyatunovUkrashenieEntities.GetContext().Product.ToList();

            FiltrBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;

            ProductListView.ItemsSource = currentProducts;



            Update();
        }

        public void Update()
        {
            var currentProducts = AflyatunovUkrashenieEntities.GetContext().Product.ToList();

            if (FiltrBox.SelectedIndex == 0)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount < 100).ToList();
            }

            if (FiltrBox.SelectedIndex == 1)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount < 10).ToList();
            }

            if (FiltrBox.SelectedIndex == 2)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount >= 10 && p.ProductDiscountAmount < 15).ToList();
            }

            if (FiltrBox.SelectedIndex == 3)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount >= 15 && p.ProductDiscountAmount <= 100).ToList();
            }

            if (SortBox.SelectedIndex == 0) { }
            if (SortBox.SelectedIndex == 1)
            {
                currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
            }
            if (SortBox.SelectedIndex == 2)
            {
                currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
            }
            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            ProductListView.ItemsSource = currentProducts;

            AllQuantity.Text = AflyatunovUkrashenieEntities.GetContext().Product.ToList().Count().ToString();
            CurrentQuantity.Text = currentProducts.Count.ToString();

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FiltrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
