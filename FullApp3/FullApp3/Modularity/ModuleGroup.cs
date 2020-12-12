using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApp3.Modularity
{
  [System.Windows.Markup.ContentProperty("Modules")]
  public class ModuleGroup
  {
    public string Name { get; set; }
    public string BasePath { get; set; }
    public List<ModuleDefinition> Modules { get; set; } = new List<ModuleDefinition>();

  }
}
