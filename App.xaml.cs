using Microsoft.Maui.Controls;

namespace ShoppingList;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState) // Użyj ? dla nullable
    {
        return new Window(new Views.MainPage());
    }
}