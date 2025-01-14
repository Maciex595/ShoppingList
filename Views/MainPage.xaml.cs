using ShoppingList.Models;
using ShoppingList.Services;
using ShoppingList.Views;

namespace ShoppingList.Views
{
    public partial class MainPage : ContentPage
    {
        private List<Product> _products;
        private FileService _fileService;

        public MainPage()
        {
            InitializeComponent();
            _fileService = new FileService();
            _products = new List<Product>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = _fileService.LoadProducts();
            RefreshProductList();
        }

        private void OnAddProduct(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameEntry.Text) ||
                string.IsNullOrWhiteSpace(ProductWeightEntry.Text) ||
                string.IsNullOrWhiteSpace(ProductQuantityEntry.Text))
                return;

            var newProduct = new Product
            {
                Name = ProductNameEntry.Text,
                Weight = double.TryParse(ProductWeightEntry.Text, out var weight) ? weight : 0,
                Quantity = double.TryParse(ProductQuantityEntry.Text, out var quantity) ? quantity : 0
            };

            _products.Add(newProduct);
            RefreshProductList();
            _fileService.SaveProducts(_products);

            ProductNameEntry.Text = string.Empty;
            ProductWeightEntry.Text = string.Empty;
            ProductQuantityEntry.Text = string.Empty;
        }

        private void RefreshProductList()
        {
            ProductList.Children.Clear();
            var boughtProducts = _products.Where(p => p.IsBought).ToList();
            var availableProducts = _products.Where(p => !p.IsBought).ToList();

            foreach (var product in availableProducts)
            {
                var productView = new ProductView(product);
                productView.OnDeleteRequested += (s, p) =>
                {
                    _products.Remove(p);
                    RefreshProductList();
                    _fileService.SaveProducts(_products);
                };
                productView.OnProductStatusChanged += (s, p) =>
                {
                    // Move the product to the bottom of the list if it's bought
                    _products.Remove(p);
                    _products.Add(p);
                    RefreshProductList();
                };
                productView.OnRequestSave += (s, _) =>
                {
                    _fileService.SaveProducts(_products); // Save changes
                };
                ProductList.Children.Add(productView);
            }

            foreach (var product in boughtProducts)
            {
                var productView = new ProductView(product);
                productView.OnDeleteRequested += (s, p) =>
                {
                    _products.Remove(p);
                    RefreshProductList();
                    _fileService.SaveProducts(_products);
                };
                productView.OnRequestSave += (s, _) =>
                {
                    _fileService.SaveProducts(_products); // Save changes
                };
                ProductList.Children.Add(productView);
            }
        }
    }
}