using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class Tarefa
  {
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public string Nome { get; set; }
    public string Materia { get; set; }
    public DateTime Prazo { get; set; }
    public DateTime DtEntrega { get; set; }

    public override string ToString()
    {
      return $"Tarefa \n Id: {Id} \t Matéria:{Nome} \t Aluno:{Aluno.Nome} \t Prazo de Entrega: {Prazo} \t Data de Entrega: {DtEntrega}.";
    }

  }
}
