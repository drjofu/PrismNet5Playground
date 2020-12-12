
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FullApp3.Core.Mvvm
{
  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ViewModelBase()
    {

    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void Destroy()
    {

    }
  }
}
