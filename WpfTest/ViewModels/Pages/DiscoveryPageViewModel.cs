using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfTest.Commands;

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
        //short Lamda writing methods
        this.ClearCommand = new DelegateCommand(
            (canExecuteObject) => !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName),
            (executeMethod) => { this.FirstName = ""; this.LastName = ""; }
            );
        
        FirstName = "Julius";
        LastName = "Lehmann";
    }
    
    public DelegateCommand ClearCommand { get; set; }
    
    private string? _firstName;
    
    /// <summary>
    /// Binding FirstName
    /// </summary>
    public string? FirstName   { 
        get => _firstName;
        set
        {
            if (_firstName == value) return;
            _firstName= value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
            
            //check if button is clickable again
            this.ClearCommand.RaiseCanExecuteChanged();
        }
    }
    
    private string? _lastName;
    
    /// <summary>
    /// Binding LastName
    /// </summary>
    public string? LastName 
    { 
        get => _lastName; 
        set
        {
            if (_lastName == value) return;
            _lastName= value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
            
            //check if button is clickable again
            this.ClearCommand.RaiseCanExecuteChanged();
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