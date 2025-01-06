using EnesFidanAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnesFidanAssignment2.Services
{/// <summary>
/// ENES FİDAN
/// </summary>
    public static class DataService
    {
        public static string GetConnectionString()
        {
            return Properties.Settings.Default.DigitalOcienDb;
        }
        public static async Task HandleException(Exception ex)
        {
            string msg = ex.Message;
            MessageBox.Show(msg);
            await Task.CompletedTask;
        }

        /// <summary>
        /// VALİDATE İF İNPUT İS EMPTY OR NOT!
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool IsParameterEmpty(string title, string description)
        {
            var result = false;

            if (title == "") result = true;

            if (description == "") result = true;

            return result;
        }


        #region Async Task Retrieve Employees
        /// <summary>
        /// RETREVİNG THE LİST OF PRODUCTS
        /// </summary>
        /// <param name="products"></param>
        public async static void GetProductsAsync(ObservableCollection<Productss> products)
        {

            try
            {

                var query = "Select * from products";

                var connection = new SqlConnection(GetConnectionString());
                connection.Open();

                var cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var _product = new Productss
                    {
                        ProductId = reader.GetInt32(0)
                    };

                    if (!reader.IsDBNull(1))
                        _product.Title = reader.GetString(2);

                    if (!reader.IsDBNull(2))
                        _product.Descriptioon = reader.GetString(1);

                    // _product.Id = $"{Product.Title}";

                    products.Add(_product);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                await HandleException(ex);
                throw;

            }

        }

        #endregion
        /// <summary>
        /// İNSERT STATEMENT
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        #region Async Task Add Employee
        public static async Task AddProduct(string title, string description)
        {
            if (IsParameterEmpty(title, description))
            {
                MessageBox.Show("No textbox can be empty");
                await Task.CompletedTask;
            }
            else
            {
                string add = @"INSERT INTO products (Title,Descriptioon) Values (@Title,@Descriptioon)";

                try
                {
                    var connection = new SqlConnection(GetConnectionString());
                    await connection.OpenAsync();


                    var cmd = new SqlCommand(add, connection);
                    cmd.Parameters.AddWithValue("Title", title);
                    cmd.Parameters.AddWithValue("Descriptioon", description);

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {

                        MessageBox.Show($"Product {title} was inserted!");
                        await Task.CompletedTask;
                    }
                    else
                    {
                        MessageBox.Show($"Product {title} {description} coudent be inserted!");
                        await Task.CompletedTask;
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    await HandleException(ex);
                }
            }
        }

        #endregion

        #region Async Task Edit Employee
        /// <summary>
        /// UPDATETİNG THE PRODUCT
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static async Task EditProduct(int proId, string title, string desc)
        {
            if (IsParameterEmpty(title, desc))
            {
                MessageBox.Show("No textbox can be empty");
                await Task.CompletedTask;
            }
            else
            {

                string update = @"UPDATE products SET Descriptioon = @Descriptioon ,Title = @Title WHERE ProductId= @ProductId";

                try
                {

                    var connection = new SqlConnection(GetConnectionString());
                    await connection.OpenAsync();

                    var cmd = new SqlCommand(update, connection);

                    cmd.Parameters.AddWithValue("Descriptioon", desc);
                    cmd.Parameters.AddWithValue("Title", title);
                    cmd.Parameters.AddWithValue("ProductId", proId);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {

                        MessageBox.Show($"Product {title} was updated!");
                        await Task.CompletedTask;
                    }
                    else
                    {
                        MessageBox.Show($"Product {title} {desc} was not updated!");
                        await Task.CompletedTask;
                    }

                    connection.Close();

                }
                catch (Exception exeption)
                {
                    await HandleException(exeption);
                }

            }
        }
        #endregion
        /// <summary>
        /// DELETİNG THE PRODUCT
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static async Task DeleteProduct(int proId)
        {
            try
            {
                string delete = @"DELETE FROM products WHERE ProductId= @ProductId ";

                var connection = new SqlConnection(GetConnectionString());
                await connection.OpenAsync();
                var cmd = new SqlCommand(delete, connection);
                cmd.Parameters.AddWithValue("ProductId", proId);

                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {

                    MessageBox.Show($"Product is deleted!");
                    await Task.CompletedTask;
                }
                else
                {
                    MessageBox.Show($"Product coudent be deleted!");
                    await Task.CompletedTask;
                }
                connection.Close();
            }
            catch (Exception exeption)
            {
                await HandleException(exeption);
            }


        }
    }
}
