using ControleTarefas.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Controllers
{
  public class AlunoController : Controller
  {
    public IActionResult AddForm()
    {
      return View("AddAlunoForm");
    }
    
    public string Consulta(int id)
    {
      TarefaDAOEntity dao = new TarefaDAOEntity();
      var aluno = dao.Alunos().First(l => l.Id == id);
      return aluno.ToString();
      
    }

    public IActionResult Cadastrar(string nome)
    {
      Aluno a1 = new Aluno();
      a1.Nome = nome;
      TarefaDAOEntity dao = new TarefaDAOEntity();
      dao.AdicionaraAluno(a1);
      return View("DoneAction");
    }

    public IActionResult Exibir()
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Alunos = _repo.Alunos();
      return View("ViewAlunos");
    }

    public IActionResult Delete(int alunoId)
    {
      var _repo = new TarefaDAOEntity();
      var aluno = _repo.Alunos().First(l => l.Id == alunoId);
      _repo.RemoverAluno(aluno);
      return View("DoneAction");
    }

    public IActionResult Edit(int alunoId, string nome )
    {
      var _repo = new TarefaDAOEntity();
      var al = _repo.Alunos().First(l => l.Id == alunoId);
      al.Nome = nome;
      _repo.AtualizarAluno(al);
      return View("DoneAction");
    }

    public IActionResult EditForm(int alunoId)
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Aluno = _repo.Alunos().First(l => l.Id == alunoId);

      return View("EditForm");
    }

  }
}
