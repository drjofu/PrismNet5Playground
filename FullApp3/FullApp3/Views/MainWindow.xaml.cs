using FullApp3.Core;
using FullApp3.Core.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FullApp3.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, IShellService
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    public void ShowInRegion(string regionName, object view)
    {
      ContentControl contentControl = this.FindName(regionName) as ContentControl;
      if (contentControl == null) throw new ApplicationException($"Region {regionName} not found in MainWindow");
      contentControl.Content = view;
    }

    public IServiceProvider Services { get; internal set; }

    public void ShowInRegion<T>(string regionName) //where T : ViewModelBase
    {
      var vm = Services.GetService(typeof(T));
      ShowInRegion(regionName, vm);
    }
  }
}
