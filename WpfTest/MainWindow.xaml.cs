using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfTest.Pages;

namespace WpfTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HomePage _homePage;
    private readonly DiscoveryPage _discoveryPage;
    private readonly FeaturedPage _featuredPage;
    
    public MainWindow()
    {
        _homePage = new HomePage();
        _discoveryPage = new DiscoveryPage();
        _featuredPage = new FeaturedPage();
        
        InitializeComponent();
        MainFrame.Navigate(new HomePage());
    }

    private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove(); // Enable dragging the window
        }
    }
    
    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized; // Minimize the window
    }

    private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : // Restore the window
            WindowState.Maximized; // Maximize the window
    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close(); // Close the application
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if ((sender as ListBox)?.SelectedItem is not ListBoxItem selectedItem) return;
        var content = selectedItem.Content.ToString();

        switch (content)
        {
            case "Home":
                MainFrame.Navigate(_homePage);
                break;
            case "Discovery":
                MainFrame.Navigate(_discoveryPage);
                break;
            case "Featured":
                MainFrame.Navigate(_featuredPage);
                break;
        }
    }
}