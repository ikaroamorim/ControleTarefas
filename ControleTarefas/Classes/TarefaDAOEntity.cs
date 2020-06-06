using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class TarefaDAOEntity : IDisposable
  {
    private TarefaContext contexto;

    public TarefaDAOEntity()
    {
      this.contexto = new TarefaContext();
    }

    /*
     *   Tarefas
     */
    public void AdicionarTarefa(Tarefa t)
    {
      contexto.Tarefa.Add(t);
      contexto.SaveChanges();
    }

    public void AtualizarTarefa(Tarefa t)
    {
      contexto.Tarefa.Update(t);
      contexto.SaveChanges();
    }

    public void ExcluirTarefa(Tarefa t)
    {
      contexto.Tarefa.Remove(t);
      contexto.SaveChanges();
    }

    public IList<Tarefa> Tarefas()
    {
      return contexto.Tarefa.ToList();
    }


    /*
     * Alunos
     */

    public void AdicionaraAluno(Aluno a)
    {
      contexto.Alunos.Add(a);
      contexto.SaveChanges();
    }

    public void AtualizarAluno(Aluno a)
    {
      contexto.Alunos.Update(a);
      contexto.SaveChanges();
    }

    public void RemoverAluno(Aluno a)
    {
      contexto.Alunos.Remove(a);
      contexto.SaveChanges();
    }

    public IList<Aluno> Alunos()
    {
      return contexto.Alunos.ToList();
    }

    public void Dispose()
    {
      contexto.Dispose();
    }
  }
}
