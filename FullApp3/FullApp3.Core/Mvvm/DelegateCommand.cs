using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FullApp3.Core.Mvvm
{
  public class DelegateCommand : ICommand
  {
    public DelegateCommand(Action action)
    {
      this.action = action;
    }

    private bool isEnabled = true;
    private readonly Action action;

    public bool IsEnabled
    {
      get { return isEnabled; }
      set { isEnabled = value; CanExecuteChanged?.Invoke(this, EventArgs.Empty); }
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      return isEnabled;
    }

    public void Execute(object parameter)
    {
      action?.Invoke();
    }
  }
}
