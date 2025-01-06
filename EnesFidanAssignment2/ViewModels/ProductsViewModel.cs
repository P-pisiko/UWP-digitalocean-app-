

using EnesFidanAssignment2.Models;
using EnesFidanAssignment2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EnesFidanAssignment2.ViewModels
{/// <summary>
/// eNES FİDAN
/// </summary>
    public partial class ProductsViewModel
    {

        private TextBox Description;

        public TextBox TbFName
        {
            get { return Description; }
            set { Description = value; }
        }

        private TextBox Title;

        public TextBox TbLName
        {
            get { return Title; }
            set { Title = value; }
        }

        public int ProductId
        {
            get { return userid; }
            set { userid = value; }
        }


        #region Private Members

        public ObservableCollection<Productss> ProductList { get; set; } = new ObservableCollection<Productss>();


        private string userfname;


        private string userlname;


        private int userid;


        #endregion

        #region Constructor

        public ProductsViewModel()
        {
            Description = new TextBox();

            Title = new TextBox();


            LoadData();


        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void LoadData()
        {

            if (ProductList != null)
            {
                ProductList.Clear();
                DataService.GetProductsAsync(ProductList);////////
            }
        }



        #region Initialize Listview
        public void InitializeUserInput(TextBox description, TextBox title)
        {
            Description = description;

            Title = title;


        }

        #endregion

        #region Helpers

        public void ClearUserInput()
        {
            Description.Text = string.Empty;
            Title.Text = string.Empty;
        }

        public void Refresh_Page()
        {
            ClearUserInput();
            LoadData();
            userid = -1;
        }
        #endregion

        #region SENDİNG DATA TO DATASERVİCE


        public void SelectProduct(int id)
        {

            ProductId = id;

            var query = from p in ProductList
                        where p.ProductId == ProductId
                        select p;

            foreach (var item in query)
            {
                Description.Text = item.Descriptioon;
                Title.Text = item.Title; 

            }

        }

        /// <summary>
        /// GET THE İNFORMATİON FROM THE TEXTBOX AND ADD A NEW PRODUCT
        /// </summary>
        /// <returns></returns>
        public async Task AddProduct()
        {
            var fname = Description.Text;
            var lname = Title.Text;

            await DataService.AddProduct(fname, lname);
            Refresh_Page();
        }

        /// <summary>
        /// VALİDATE THAT WE ARE NOT DELETİNG ANY DEFAULT PRODUCT AND CALL THE DELETE 
        /// </summary>
        /// <returns></returns>
        public async Task DeleteProduct()
        {
            if (ProductId >= 6)
            {
                await DataService.DeleteProduct(ProductId);
                Refresh_Page();
            }
            else
            {
                MessageBox.Show("You cant delete the original Products!");
            }

            
        }

        /// <summary>
        /// GET THE İNFORMATİON FROM THE TEXTBOX AND SEND İT TO DATASERVİCE 
        /// </summary>
        /// <returns></returns>
        public async Task EditProduct()
        {
            var updatedescription = Description.Text;
            var updateltitle = Title.Text;
            await DataService.EditProduct(ProductId, updatedescription, updateltitle);
            Refresh_Page();

        }


        public void RefreshProdcut()
        {
            Refresh_Page();
        }
        #endregion

    }
}

