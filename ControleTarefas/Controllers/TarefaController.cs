using ControleTarefas.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Controllers
{
  public class TarefaController : Controller
  {
    public IActionResult Cadastrar(int alunoid, string tarefa, string materia, DateTime prazo, DateTime entrega)
    {
      var t = new Tarefa();
      var contexto = new TarefaDAOEntity();

      var aluno = contexto.contexto.Alunos.First(l => l.Id == alunoid);
      t.Aluno = aluno;
      t.Nome = tarefa;
      t.Materia = materia;
      t.Prazo = prazo;
      t.DtEntrega = entrega;
      contexto.AdicionarTarefa(t);
      return View("DoneAction");
    }

    public IActionResult AddForm()
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Alunos = _repo.Alunos();
      return View("AddTarefaForm");
    }

    public IActionResult Exibir()
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Tarefas = _repo.Tarefas();
      ViewBag.Alunos = _repo.Alunos();
      var t = _repo.Alunos();
      return View("ViewTarefas");
    }

    public IActionResult Delete(int tarefaId)
    {
      var _repo = new TarefaDAOEntity();
      var tarefa = _repo.Tarefas().First(l => l.Id == tarefaId);
      _repo.ExcluirTarefa(tarefa);
      return View("DoneAction");
    }

    public IActionResult DeleteForm()
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Tarefas = _repo.Tarefas();
      return View("DeleteTarefaForm");
    }

    public IActionResult Edit(int tarefaId, int alunoid, string tarefa, string materia, DateTime prazo, DateTime entrega)
    {
      var _repo = new TarefaDAOEntity();
      var tar = _repo.Tarefas().First(l => l.Id == tarefaId);
      tar.Nome = tarefa;
      tar.Materia = materia;
      if (prazo.Ticks != 0)
      {
        tar.Prazo = prazo;
      }
      if (entrega.Ticks != 0)
      {
        tar.DtEntrega = entrega;
      }
      _repo.AtualizarTarefa(tar);
      return View("DoneAction");
    }

    public IActionResult EditForm(int tarefaId)
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Tarefa = _repo.Tarefas().First(l => l.Id == tarefaId);
      var t = _repo.Tarefas().First(l => l.Id == tarefaId);
      ViewBag.Aluno = _repo.Alunos().First(l => l.Id == t.AlunoId);
      
      return View("EditForm");
    }


  }
}
