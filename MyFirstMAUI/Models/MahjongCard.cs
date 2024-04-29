using System.ComponentModel;

namespace MyFirstMAUI.Models;

public class MahjongCard : INotifyPropertyChanged
{
    public int Value { get;  }
    public string UrlFront { get; }
    public string UrlBack { get; init; } = "back.jpg";
    public string UrlShow => (IsSelected || IsMatched) ? UrlFront : UrlBack;

    public bool _isSelected;
    public bool IsSelected
    {
        get { return _isSelected; }
        set { _isSelected = value; NotifyPropertyChanged(nameof(IsSelected)); NotifyPropertyChanged(nameof(UrlShow)); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public bool IsMatched { get; set; } = false;

    public MahjongCard(int value, string urlFront, bool isSelected = false, bool isMatched = false, string urlBack = "back.jpg") =>
        (Value, UrlFront, IsSelected, IsMatched, UrlBack) = (value, urlFront, isSelected, isMatched, urlBack);

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void ChangeSelectedStauts() => this.IsSelected = !IsSelected ;
    public void ChangeMatchStauts() => this.IsMatched= !IsMatched;
}
