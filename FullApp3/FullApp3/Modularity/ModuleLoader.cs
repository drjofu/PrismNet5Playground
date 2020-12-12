using FullApp3.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace FullApp3.Modularity
{
  public class ModuleLoader
  {
    private readonly IServiceCollection services;

    public ModuleLoader(IServiceCollection services)
    {

      this.services = services;
    }

    private ModuleList moduleList;

    private List<IModule> modules = new List<IModule>();

    public async Task Load()
    {
      GetModuleListFromXaml();

      foreach (var group in moduleList.ModuleGroups)
      {
        foreach (var moduleDefinition in group.Modules)
        {
          var path = Path.Combine(group.BasePath, moduleDefinition.Path);
          var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

          AddIModuleImplementations(assembly);
          AddExports(assembly);
        }
      }

    }

    private void AddExports(System.Reflection.Assembly assembly)
    {
      foreach (var type in assembly.DefinedTypes)
      {
        var exportAttribute = (ExportAttribute)type.GetCustomAttributes(typeof(ExportAttribute), false).FirstOrDefault();
        if (exportAttribute != null)
        {
          var partCreationPolicyAttribute = (PartCreationPolicyAttribute)type.GetCustomAttributes(typeof(PartCreationPolicyAttribute), false).FirstOrDefault();
          if(partCreationPolicyAttribute?.CreationPolicy== CreationPolicy.Shared)
          {
            if (exportAttribute.ContractType != null)
              services.AddSingleton(exportAttribute.ContractType, type);
            else
              services.AddSingleton(type);
          }
          else
          {
            if (exportAttribute.ContractType != null)
              services.AddTransient(exportAttribute.ContractType, type);
            else
              services.AddTransient(type);
          }
        }
      }
      Console.WriteLine();
    }

    private void AddIModuleImplementations(System.Reflection.Assembly assembly)
    {
      var moduleTypes = assembly.DefinedTypes.Where(t => t.GetInterface("IModule") != null);
      foreach (var moduleType in moduleTypes)
      {
        services.AddSingleton(typeof(IModule), moduleType.AsType());
      }
    }

    private void GetModuleListFromXaml()
    {
      XamlReader xamlReader = new();
      var obj = xamlReader.LoadAsync(File.OpenRead("Modules.xaml"));
      var dict = obj as ResourceDictionary;

      moduleList = dict?["m"] as ModuleList;
    }

    public void InitializeModules(IServiceProvider serviceProvider)
    {
      IShellService shellService = serviceProvider.GetRequiredService<IShellService>();

      var list = serviceProvider.GetServices<IModule>();
      foreach (var module in list)
      {
        module.Initialize(shellService, serviceProvider);
      }
      Console.WriteLine();

    }
  }
}
