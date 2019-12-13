using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListViewExample_week10
{
    public class MainViewModel
    {
        private Product _oldProduct;

        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Name = "Honda Civic HB",
                    IsVisible = false
                },
                new Product
                {
                    Name = "Honda Civic Sedan",
                    IsVisible = false
                },
                new Product
                {
                    Name = "Honda CRV",
                    IsVisible = false
                },
                new Product
                {
                    Name = "Honda HRV",
                    IsVisible = false
                },
                new Product
                {
                    Name = "Honda Jazz",
                    IsVisible = false
                }
            };
        }

        internal void HideOrShowProduct(Product product)
        {
            /*
            product.IsVisible = true;

            UpdateProducts(product);

            _oldProduct = product; */
            if (_oldProduct == product)
            {
                product.IsVisible = !product.IsVisible;
                UpdateProducts(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    _oldProduct.IsVisible = false;
                    UpdateProducts(_oldProduct);
                }
                product.IsVisible = true;
                UpdateProducts(product);
            }

            _oldProduct = product;
        }

        private void UpdateProducts(Product product)
        {
            var index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(index, product);
        }
    }
}
