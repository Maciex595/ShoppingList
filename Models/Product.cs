using System.ComponentModel;

namespace ShoppingList.Models
{
    public class Product : INotifyPropertyChanged
    {
        private double _quantity;
        private double _weight;
        private bool _isBought;

        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Name { get; set; }

        public double Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public bool IsBought
        {
            get => _isBought;
            set
            {
                if (_isBought != value)
                {
                    _isBought = value;
                    OnPropertyChanged(nameof(IsBought));
                }
            }
        }

        public string Unit { get; set; } = "szt.";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}