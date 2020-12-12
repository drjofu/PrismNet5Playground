using FullApp3.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApp3.Core
{
  public interface IShellService
  {
    void ShowInRegion(string regionName, object view);
    void ShowInRegion<T>(string regionName); //where T:ViewModelBase;
  }
}
