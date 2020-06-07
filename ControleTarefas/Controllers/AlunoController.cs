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
      var html = new ViewResult { ViewName = "AddAlunoForm"};
      return html;
    }
    
    public string Consulta(int id)
    {
      TarefaDAOEntity dao = new TarefaDAOEntity();
      var aluno = dao.Alunos().First(l => l.Id == id);
      return aluno.ToString();
    }

    public string Cadastrar(string nome)
    {
      Aluno a1 = new Aluno();
      a1.Nome = nome;
      TarefaDAOEntity dao = new TarefaDAOEntity();
      dao.AdicionaraAluno(a1);
      return a1.ToString();
    }

    public IActionResult Exibir()
    {
      var _repo = new TarefaDAOEntity();
      ViewBag.Alunos = _repo.Alunos();
      var alunos = _repo.Alunos();
      return View("Exibir");
    }

    public string Teste()
    {
      return "Teste";
    }


  }
}
