using FullApp3.Core;
using FullApp3.Modularity;
using FullApp3.ViewModels;
using FullApp3.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace FullApp3
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {

    public static IHost AppHost;
    private MainWindow mainWindow;
    private ModuleLoader moduleLoader;

    protected async override void OnStartup(StartupEventArgs e)
    {

      // Hauptfenster einrichten
      mainWindow = new MainWindow();


      // Host konfigurieren
      AppHost = Host.CreateDefaultBuilder(e.Args)
       .ConfigureServices(ConfigureServices)
       .Build();

      mainWindow.Services = AppHost.Services;

      // Host starten
      await AppHost.StartAsync();

      // ViewModel aus DI-Container laden
      mainWindow.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
      mainWindow.Show();

      moduleLoader.InitializeModules(AppHost.Services);
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
      services.AddSingleton<MainWindowViewModel>();
      services.AddSingleton<IShellService>(mainWindow);

      // externe Module laden
      moduleLoader = new ModuleLoader(services);
      moduleLoader.Load().Wait();

    }

    protected override async void OnExit(ExitEventArgs e)
    {
      // Beim Beenden Host stoppen und alles aufräumen
      using (AppHost) await AppHost.StopAsync();
    }


    //protected override Window CreateShell()
    //{
    //  return Container.Resolve<MainWindow>();
    //}

    //protected override void RegisterTypes(IContainerRegistry containerRegistry)
    //{
    //  containerRegistry.RegisterSingleton<IMessageService, MessageService>();
    //}

    //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    //{
    //  //moduleCatalog.AddModule<ModuleNameModule>();
    //}


  }
}
