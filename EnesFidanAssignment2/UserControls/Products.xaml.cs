using EnesFidanAssignment2.Models;
using EnesFidanAssignment2.ViewModels;
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

namespace EnesFidanAssignment2.UserControls
{
    /// <summary>
    /// EnesFİDAN
    /// </summary>
    public partial class Products : UserControl
    {
        ProductsViewModel ViewModel = new ProductsViewModel();
        /// <summary>
        /// İNİTİLİZE THE VARİABLES
        /// </summary>
        public Products()
        {
            InitializeComponent();
            ViewModel.InitializeUserInput(product_name, description);
            this.DataContext = ViewModel;
        }
        private void ProItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Productss selectedProduct = (Productss)button.DataContext;
            int ProductId = selectedProduct.ProductId;
            ViewModel.ProductId = ProductId;
            ViewModel.SelectProduct(ProductId);
        }

        /// <summary>
        /// aDDS A PRODUCT TO THE DATABASE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddPro_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.AddProduct();
        }
        /// <summary>
        /// Clear the input and refresh 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshProduct_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RefreshProdcut();
            ViewModel.LoadData();
        }
        /// <summary>
        /// EDİT THE PRODUCT İNFORMATİON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EditPro_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.EditProduct();
        }
        /// <summary>
        /// delete the product based on its Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Delete_Product(object sender, RoutedEventArgs e)
        {
            await ViewModel.DeleteProduct();
        }

    }
}
