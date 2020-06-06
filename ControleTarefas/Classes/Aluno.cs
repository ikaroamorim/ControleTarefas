using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class Aluno
  {
    public int Id { get; set; }
    public string Nome { get; set; }

    public override string ToString()
    {
      return $"Aluno Id:{Id} \t Nome:{Nome}";
    }
  }
}
