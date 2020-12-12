using FullApp3.Core;
using Module2.ViewModels;
using System;
using System.Windows;

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

namespace Module2
{
  public class Module2Module : IModule
  {
    public Module2Module()
    {

    }

    public void Initialize(IShellService shellService, IServiceProvider serviceProvider)
    {
      shellService.ShowInRegion<ViewAViewModel>("Region2");
    }

    //public void OnInitialized(IContainerProvider containerProvider)
    //{
    //  //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));
    //  //_regionManager.RequestNavigate(RegionNames.ContentRegion2, "ViewA");
    //}

    //public void RegisterTypes(IContainerRegistry containerRegistry)
    //{
    //  containerRegistry.RegisterForNavigation<ViewA>();
    //}
  }
}