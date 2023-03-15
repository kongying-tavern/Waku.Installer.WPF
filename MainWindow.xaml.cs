using System;
using System.Windows;
using System.Windows.Input;

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
        SetCurrentSkin();
    }

    private string CurrentSkin { get; set; } = GlobalVars.LightSkin;

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
        if (string.Equals(CurrentSkin, "LightSkin"))
        {
            CurrentSkin = "DarkSkin";
            SetCurrentSkin();
        }
        else if (string.Equals(CurrentSkin, "DarkSkin"))
        {
            CurrentSkin = "LightSkin";
            SetCurrentSkin();
        }
        else
        {
            throw new NotImplementedException("Can not found theme skin.");
        }
    }

    private void SetCurrentSkin()
    {
        Application.Current.Resources = Application.Current.Properties[CurrentSkin] as ResourceDictionary;
    }
}