using System;
using System.Windows;
using System.Windows.Input;

using WpfApp.Constants;

namespace WpfApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Set initial skin
        CurrentSkin = SetCurrentSkin(Global.LightSkinName);
    }

    private static string CurrentSkin { get; set; } = Global.LightSkinName;

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void SkinButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentSkin = ChangeSkin(CurrentSkin);
    }

    private static string ChangeSkin(string currentSkin)
    {
        return currentSkin switch
        {
            Global.LightSkinName => SetCurrentSkin(Global.DarkSkinName),
            Global.DarkSkinName => SetCurrentSkin(Global.LightSkinName),
            _ => throw new ArgumentOutOfRangeException(nameof(currentSkin), currentSkin, "Can not found theme skin.")
        };
    }

    private static string SetCurrentSkin(string skinName)
    {
        Application.Current.Resources = Application.Current.Properties[skinName] as ResourceDictionary;
        return skinName;
    }
}