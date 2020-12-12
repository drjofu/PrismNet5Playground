using FullApp3.Core;
using FullApp3.Modules.ModuleName.ViewModels;
using System;
using System.Windows;

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]


namespace FullApp3.Modules.ModuleName
{
  public class ModuleNameModule : IModule
  {
    //private readonly IEventAggregator eventAggregator;

    //public ModuleNameModule( IEventAggregator eventAggregator)
    //{
    //  this.eventAggregator = eventAggregator;
    //}

    public ModuleNameModule()
    {

    }

    public void Initialize(IShellService shellService, IServiceProvider serviceProvider)
    {
      //shellService.ShowInRegion("Region1", typeof(ViewA));
      shellService.ShowInRegion<ViewAViewModel>("Region1");
    }

    //public void OnInitialized(IContainerProvider containerProvider)
    //{
    //  //_regionManager.RequestNavigate(RegionNames.ContentRegion1, "ViewA");
    //}

    //public void RegisterTypes(IContainerRegistry containerRegistry)
    //{
    //  containerRegistry.RegisterForNavigation<ViewA>();
    //}
  }
}