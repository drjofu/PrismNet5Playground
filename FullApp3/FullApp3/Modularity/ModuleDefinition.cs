using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApp3.Modularity
{
  public class ModuleDefinition
  {
    public string Path { get; set; }
    public List<string> Dependencies { get; set; } = new List<string>();

  }
}
