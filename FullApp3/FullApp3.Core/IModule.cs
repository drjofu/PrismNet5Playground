using System;

namespace FullApp3.Core
{
  public interface IModule
  {
    void Initialize(IShellService shellService, IServiceProvider serviceProvider);
  }
}
