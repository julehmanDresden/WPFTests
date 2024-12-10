using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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
    
}