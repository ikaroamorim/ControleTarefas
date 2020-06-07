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
      return View("ViewTarefas");
    }

    public IActionResult Delete(int id)
    {
      var _repo = new TarefaDAOEntity();
      var tarefa = _repo.Tarefas().First(l => l.Id == id);
      _repo.ExcluirTarefa(tarefa);
      return View("DoneAction");
    }

  }
}
