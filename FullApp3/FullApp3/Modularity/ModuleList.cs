using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApp3.Modularity
{
  [System.Windows.Markup.ContentProperty("ModuleGroups")]
  public class ModuleList
  {
    public List<ModuleGroup> ModuleGroups { get; set; } = new List<ModuleGroup>();
  }
}
