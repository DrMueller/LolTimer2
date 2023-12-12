using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace LolTimer2.Models;

public class FlashTimer : INotifyPropertyChanged
{
    private readonly DispatcherTimer _timer;
    private int _flashUpInSeconds;

    public FlashTimer(string roleDescription)
    {
        RoleDescription = roleDescription;
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += _timer_Tick;
    }

    public string RoleDescription { get; }

    public string TimerDescription
    {
        get
        {
            if (_flashUpInSeconds == 0) return "UP";

            var ts = TimeSpan.FromSeconds(_flashUpInSeconds);
            return ts.ToString(@"mm\:ss");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void _timer_Tick(object? sender, EventArgs e)
    {
        if (_flashUpInSeconds <= 0) _timer.Stop();

        _flashUpInSeconds--;
        OnPropertyChanged(nameof(TimerDescription));
    }

    public void StartTimer()
    {
        _flashUpInSeconds = 300;
        _timer.Start();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}