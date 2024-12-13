using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTest.ViewModels.Pages;

/// <summary>
/// ViewModel DiscoveryPage
/// </summary>
public sealed class DiscoveryPageViewModel:INotifyPropertyChanged
{
    /// <summary>
    /// Initializes DiscoveryPage
    /// </summary>
    public DiscoveryPageViewModel()
    {
        FirstName = "Julius";
        LastName = "Lehmann";
    }
    
    private string _firstName;
    
    /// <summary>
    /// Binding FirstName
    /// </summary>
    public string FirstName   { 
        get => _firstName;
        set
        {
            if (_firstName == value) return;
            _firstName= value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }
    
    private string _lastName;
    
    /// <summary>
    /// Binding LastName
    /// </summary>
    public string LastName 
    { 
        get => _lastName; 
        set
        {
            if (_lastName == value) return;
            _lastName= value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }
    
    /// <summary>
    /// BindingFullName
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}