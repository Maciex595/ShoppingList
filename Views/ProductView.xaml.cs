using ShoppingList.Models;
using System;
using Microsoft.Maui.Controls;

namespace ShoppingList.Views
{
    public partial class ProductView : ContentView
    {
        public ProductView(Product product)
        {
            InitializeComponent();
            BindingContext = product;
        }

        private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (BindingContext is Product product)
            {
                product.IsBought = e.Value;
                OnProductStatusChanged?.Invoke(this, product);
                OnRequestSave?.Invoke(this, null);
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            OnDeleteRequested?.Invoke(this, (Product)BindingContext);
        }

        private void OnIncreaseQuantityClicked(object sender, EventArgs e)
        {
            if (BindingContext is Product product)
            {
                product.Quantity++;
                OnRequestSave?.Invoke(this, null);
            }
        }

        private void OnDecreaseQuantityClicked(object sender, EventArgs e)
        {
            if (BindingContext is Product product && product.Quantity > 0)
            {
                product.Quantity--;
                OnRequestSave?.Invoke(this, null);
            }
        }

        public event EventHandler<Product>? OnDeleteRequested;
        public event EventHandler<Product>? OnProductStatusChanged;
        public event EventHandler? OnRequestSave;
    }
}
