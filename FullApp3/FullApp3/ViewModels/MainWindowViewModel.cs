using FullApp3.Core;
using FullApp3.Core.Mvvm;

namespace FullApp3.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    private readonly IShellService shellService;
    public string Title { get; set; } = "Testprogramm ohne Prism";

    public MainWindowViewModel(IShellService shellService)
    {
      this.shellService = shellService;
      shellService.ShowInRegion("Region1", "Hallo Welt");
    }
  }
}
