﻿using Microsoft.Maui.Controls;

namespace ShoppingList;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new Views.MainPage());
    }
}
